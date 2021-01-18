using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Net.Mail;
using BALPortal;
using DALPortal;

namespace webPortal
{
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string BindUserGroup()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "USERGROUPBYID", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select User Group</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindDesignation()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "DESIGNATION", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Designation</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindStaffType()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "STAFFTYPE", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Staff Type</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string LoadUser(string userid)
        {
            DataTable dtListing;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtListing = new DataTable();
            string[] strSelect = new string[] { userid.ToString() };
            dtListing = objTrn.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_User));

            if (userid == "0")
            {
                if (dtListing != null)
                {
                    //strbld.Append("<table class=\"table table-bordered\" id=\"listing\" width=\"100%\" cellspacing=\"0\">");
                    strbld.Append("<thead>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">userid</th>");
                    strbld.Append("<th>Group Name</th>");
                    strbld.Append("<th>User Name</th>");
                    strbld.Append("<th>Staff Type</th>");
                    strbld.Append("<th>Designation</th>");
                    //strbld.Append("<th>Mobile</th>");
                    //strbld.Append("<th>Email</th>");
                    strbld.Append("<th>Last Modified by</th>");
                    strbld.Append("<th>Last Modified On</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</thead>");
                    strbld.Append("<tfoot>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">userid</th>");
                    strbld.Append("<th>Group Name</th>");
                    strbld.Append("<th>User Name</th>");
                    strbld.Append("<th>Staff Type</th>");
                    strbld.Append("<th>Designation</th>");
                    //strbld.Append("<th>Mobile</th>");
                    //strbld.Append("<th>Email</th>");
                    strbld.Append("<th>Last Modified by</th>");
                    strbld.Append("<th>Last Modified On</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</tfoot>");
                    strbld.Append("<tbody>");
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append("<tr>");
                        strbld.Append("<td class=\"hide\">" + dr["userid"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["groupname"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["username"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["stafftype"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["designation"].ToString() + "</td>");
                        //strbld.Append("<td>" + dr["mobile"].ToString() + "</td>");
                        //strbld.Append("<td>" + dr["emailid"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["LastModifiedBy"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["LastModifiedOn"].ToString() + "</td>");
                        strbld.Append("<td class=\"text-center\"><i class=\"fa fa-eye\" aria-hidden=\"true\" title=\"View\" onclick=\"LoadUser(" + dr["userid"].ToString() + ")\">&nbsp&nbsp</i><i class=\"fa fa-trash\" title=\"Delete\" aria-hidden=\"true\" onclick=\"DeleteRecord(" + dr["userid"].ToString() + ")\"></i></td>");
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
                        strbld.Append(dr["userid"].ToString() + "|");
                        strbld.Append(dr["groupid"].ToString() + "|");
                        strbld.Append(dr["firstname"].ToString() + "|");
                        strbld.Append(dr["lastname"].ToString() + "|");
                        strbld.Append(dr["stafftype"].ToString() + "|");
                        strbld.Append(dr["designation"].ToString() + "|");
                        strbld.Append(dr["mobile"].ToString() + "|");
                        strbld.Append(dr["emailid"].ToString() + "|");
                        strbld.Append(dr["password"].ToString());
                    }
                }

            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string SaveUser(string userid, string groupid, string firstname, string lastname, string stafftype, string designation, string mobile, string emailid, string password)
        {
            DataTable dtUser = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            if (userid == "0")
            {
                string[] strInsert = new string[] {userid.ToString()
                                                    ,groupid.ToString()
                                                    ,firstname.ToString()
                                                    ,lastname.ToString()
                                                    ,stafftype.ToString()
                                                    ,designation.ToString()
                                                    ,mobile.ToString()
                                                    ,emailid.ToString()
                                                    ,password.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};

                dtUser = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_UserMaster));

                strBld = dtUser.Rows[0]["i_IDENTITY"].ToString() + '|' + dtUser.Rows[0]["msg"].ToString();
            }
            else
            {
                string[] strUpdate = new string[] { userid.ToString()
                                                    ,groupid.ToString()
                                                    ,firstname.ToString()
                                                    ,lastname.ToString()
                                                    ,stafftype.ToString()
                                                    ,designation.ToString()
                                                    ,mobile.ToString()
                                                    ,emailid.ToString()
                                                    ,password.ToString()
                                                    ,""//HttpContext.Current.Session["userid"].ToString()
                                                    ,"1"
                                                    ,(clsEnumRequestType.UPDATE).ToString()};

                dtUser = objTrn.Transaction(strUpdate, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_UserMaster));

                strBld = dtUser.Rows[0]["i_IDENTITY"].ToString() + '|' + dtUser.Rows[0]["msg"].ToString();
            }

            return strBld.ToString();
        }

        [WebMethod]
        public static string DeleteUser(string userid)
        {
            DataTable dtUser = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            string[] strDelete = new string[] { userid.ToString()
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""//HttpContext.Current.Session["userid"].ToString()
                                                ,"1"
                                                ,(clsEnumRequestType.DELETE).ToString()};

            dtUser = objTrn.Transaction(strDelete, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_UserMaster));

            strBld = dtUser.Rows[0]["i_IDENTITY"].ToString() + '|' + dtUser.Rows[0]["msg"].ToString();


            return strBld.ToString();
        }
    }
}