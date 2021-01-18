using BALPortal;
using DALPortal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webPortal
{
    public partial class configuration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string BindCategory()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "CONFIGCATEGORY", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Category</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindValueType(string category)
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "VALUETYPE", "BLANK", category.ToString() };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Value Type</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string LoadConfiguration(string id)
        {
            DataTable dtListing;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtListing = new DataTable();
            string[] strSelect = new string[] { id.ToString() };
            dtListing = objTrn.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_Configuration));
            if (id == "0")
            {
                if (dtListing != null)
                {
                    //strbld.Append("<table class=\"table table-bordered\" id=\"listing\" width=\"100%\" cellspacing=\"0\">");
                    strbld.Append("<thead>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">id</th>");
                    strbld.Append("<th>Category</th>");
                    strbld.Append("<th>Value Type</th>");
                    strbld.Append("<th>Rate</th>");
                    strbld.Append("<th>Due Date</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</thead>");
                    strbld.Append("<tfoot>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">configid</th>");
                    strbld.Append("<th>Category</th>");
                    strbld.Append("<th>Value Type</th>");
                    strbld.Append("<th>Rate</th>");
                    strbld.Append("<th>Due Date</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</tfoot>");
                    strbld.Append("<tbody>");
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append("<tr>");
                        strbld.Append("<td class=\"hide\">" + dr["id"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["category"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["Value Type"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["Rate"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["Due Date"].ToString() + "</td>");
                        strbld.Append("<td class=\"text-center\"><i class=\"fa fa-eye\" aria-hidden=\"true\" title=\"View\" onclick=\"LoadConfiguration(" + dr["id"].ToString() + ")\">&nbsp&nbsp</i><i class=\"fa fa-trash\" title=\"Delete\" aria-hidden=\"true\" onclick=\"DeleteRecord(" + dr["id"].ToString() + ")\"></i></td>");
                        strbld.Append("</tr>");
                    }
                    strbld.Append("</tbody>");
                    //strbld.Append("</table>");
                }
            }
            else
            {
                if (dtListing != null)
                {
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append(dr["id"].ToString() + "|");
                        strbld.Append(dr["category"].ToString() + "|");
                        strbld.Append(dr["valuetype"].ToString() + "|");
                        strbld.Append(dr["rate"].ToString() + "|");
                        strbld.Append(dr["duedate"].ToString());
                    }
                }

            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string SaveConfiguration(string id, string category, string valuetype, string rate, string duedate)
        {
            DataTable dtConfiguration = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            if (id == "0")
            {
                string[] strInsert = new string[] {id.ToString()
                                                    ,category.ToString()
                                                    ,valuetype.ToString()
                                                    ,rate.ToString()
                                                    ,duedate.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};

                dtConfiguration = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_Configuration));

                strBld = dtConfiguration.Rows[0]["i_IDENTITY"].ToString() + '|' + dtConfiguration.Rows[0]["msg"].ToString();
            }
            else
            {
                string[] strUpdate = new string[] { id.ToString()
                                                    ,category.ToString()
                                                    ,valuetype.ToString()
                                                    ,rate.ToString()
                                                    ,duedate.ToString()
                                                    ,""//HttpContext.Current.Session["userid"].ToString()
                                                    ,"1"
                                                    ,(clsEnumRequestType.UPDATE).ToString()};

                dtConfiguration = objTrn.Transaction(strUpdate, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_Configuration));

                strBld = dtConfiguration.Rows[0]["i_IDENTITY"].ToString() + '|' + dtConfiguration.Rows[0]["msg"].ToString();
            }

            return strBld.ToString();
        }

        [WebMethod]
        public static string DeleteConfiguration(string id)
        {
            DataTable dtConfiguration = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            string[] strDelete = new string[] { id.ToString()
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""//HttpContext.Current.Session["userid"].ToString()
                                                ,"1"
                                                ,(clsEnumRequestType.DELETE).ToString()};

            dtConfiguration = objTrn.Transaction(strDelete, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_Configuration));

            strBld = dtConfiguration.Rows[0]["i_IDENTITY"].ToString() + '|' + dtConfiguration.Rows[0]["msg"].ToString();


            return strBld.ToString();
        }
    }
}