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
    public partial class societymaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string BindSocietyType()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "SOCIETYTYPE", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Society Type</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }


        [WebMethod]
        public static string BindCountry()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "COUNTRY", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Country</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }


        [WebMethod]
        public static string BindState(string countryid)
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "STATE", "BLANK", countryid.ToString() };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select State</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }


        [WebMethod]
        public static string BindCity(string stateid)
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "CITY", "BLANK", stateid.ToString() };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select City</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }


        [WebMethod]
        public static string LoadSociety(string SocietyId)
        {
            DataTable dtListing;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtListing = new DataTable();
            string[] strSelect = new string[] { SocietyId.ToString() };
            dtListing = objTrn.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_SocietyMaster));

            if (SocietyId == "0")
            {
                if (dtListing != null)
                {
                    //strbld.Append("<table class=\"table table-bordered\" id=\"listing\" width=\"100%\" cellspacing=\"0\">");
                    strbld.Append("<thead>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">societyid</th>");
                    strbld.Append("<th>societycode</th>");
                    strbld.Append("<th>societyname</th>");
                    strbld.Append("<th>regno</th>");
                    strbld.Append("<th>reddate</th>");
                    strbld.Append("<th>panno</th>");
                    strbld.Append("<th>contactperson</th>");
                    strbld.Append("<th>contact1</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</thead>");
                    strbld.Append("<tfoot>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">societyid</th>");
                    strbld.Append("<th>societycode</th>");
                    strbld.Append("<th>societyname</th>");
                    strbld.Append("<th>regno</th>");
                    strbld.Append("<th>reddate</th>");
                    strbld.Append("<th>panno</th>");
                    strbld.Append("<th>contactperson</th>");
                    strbld.Append("<th>contact1</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</tfoot>");
                    strbld.Append("<tbody>");
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append("<tr>");
                        strbld.Append("<td class=\"hide\">" + dr["societyid"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["societycode"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["societyname"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["regno"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["reddate"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["panno"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["contactperson"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["contact1"].ToString() + "</td>");
                        strbld.Append("<td class=\"text-center\"><i class=\"fa fa-eye\" aria-hidden=\"true\" title=\"View\" onclick=\"LoadSociety(" + dr["societyid"].ToString() + ")\">&nbsp&nbsp</i><i class=\"fa fa-trash\" title=\"Delete\" aria-hidden=\"true\" onclick=\"DeleteRecord(" + dr["societyid"].ToString() + ")\"></i></td>");
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
                        strbld.Append(dr["societyid"].ToString() + "|");
                        strbld.Append(dr["societycode"].ToString() + "|");
                        strbld.Append(dr["societyname"].ToString() + "|");
                        strbld.Append(dr["societytype"].ToString() + "|");
                        strbld.Append(dr["regno"].ToString() + "|");
                        strbld.Append(dr["reddate"].ToString() + "|");
                        strbld.Append(dr["panno"].ToString() + "|");
                        strbld.Append(dr["contactperson"].ToString() + "|");
                        strbld.Append(dr["contact1"].ToString() + "|");
                        strbld.Append(dr["contact2"].ToString() + "|");
                        strbld.Append(dr["emailid"].ToString() + "|");
                        strbld.Append(dr["address"].ToString() + "|");
                        strbld.Append(dr["location"].ToString() + "|");
                        strbld.Append(dr["city"].ToString() + "|");
                        strbld.Append(dr["state"].ToString() + "|");
                        strbld.Append(dr["country"].ToString() + "|");
                        strbld.Append(dr["pincode"].ToString() + "|");
                        strbld.Append(dr["noofbldg"].ToString());
                    }
                }
            }
            return strbld.ToString();
        }


        [WebMethod]
        public static string SaveSociety(string societyid, string societycode, string societyname, string societytype, string regno
                                        , string reddate, string panno, string contactperson, string contact1, string contact2
                                        , string emailid, string address, string location, string city, string state
                                        , string country, string pincode, string noofbldg)
        {
            DataTable dtSocietyMaster = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            if (societyid == "0")
            {
                string[] strInsert = new string[] {societyid.ToString()
                                                    ,societycode.ToString()
                                                    ,societyname.ToString()
                                                    ,societytype.ToString()
                                                    ,regno.ToString()
                                                    ,Convert.ToDateTime(reddate).ToString("yyyy-MM-dd")
                                                    ,panno.ToString()
                                                    ,contactperson.ToString()
                                                    ,contact1.ToString()
                                                    ,contact2.ToString()
                                                    ,emailid.ToString()
                                                    ,address.ToString()
                                                    ,location.ToString()
                                                    ,city.ToString()
                                                    ,state.ToString()
                                                    ,country.ToString()
                                                    ,pincode.ToString()
                                                    ,noofbldg.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};

                dtSocietyMaster = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_SocietyMaster));

                strBld = dtSocietyMaster.Rows[0]["i_IDENTITY"].ToString() + '|' + dtSocietyMaster.Rows[0]["msg"].ToString();
            }
            else
            {
                string[] strUpdate = new string[] { societyid.ToString()
                                                    ,societycode.ToString()
                                                    ,societyname.ToString()
                                                    ,societytype.ToString()
                                                    ,regno.ToString()
                                                    ,Convert.ToDateTime(reddate).ToString("yyyy-MM-dd")
                                                    ,panno.ToString()
                                                    ,contactperson.ToString()
                                                    ,contact1.ToString()
                                                    ,contact2.ToString()
                                                    ,emailid.ToString()
                                                    ,address.ToString()
                                                    ,location.ToString()
                                                    ,city.ToString()
                                                    ,state.ToString()
                                                    ,country.ToString()
                                                    ,pincode.ToString()
                                                    ,noofbldg.ToString()
                                                    ,""//HttpContext.Current.Session["userid"].ToString()
                                                    ,"1"
                                                    ,(clsEnumRequestType.UPDATE).ToString()};
                dtSocietyMaster = objTrn.Transaction(strUpdate, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_SocietyMaster));

                strBld = dtSocietyMaster.Rows[0]["i_IDENTITY"].ToString() + '|' + dtSocietyMaster.Rows[0]["msg"].ToString();
            }

            return strBld.ToString();
        }

        [WebMethod]
        public static string DeleteSociety(string SocietyId)
        {
            DataTable dtSocietyMaster = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            string[] strDelete = new string[] { SocietyId.ToString()
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
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

            dtSocietyMaster = objTrn.Transaction(strDelete, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_SocietyMaster));

            strBld = dtSocietyMaster.Rows[0]["i_IDENTITY"].ToString() + '|' + dtSocietyMaster.Rows[0]["msg"].ToString();


            return strBld.ToString();
        }
    }
}