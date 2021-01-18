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
    public partial class tenantmaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string BindAccountGroup()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "ACGROUP", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Account Group</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindLedger(string acgrpid)
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "LEDGER", "BLANK", acgrpid.ToString() };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Ledger</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindSocietyName()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "SOCIETY", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Society Name</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindBldgNo(string societycode)
        {
            DataTable dtDropDown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropDown = new DataTable();
            string[] strDropDown = new string[] { "BUILDING", "BLANK", societycode.ToString() };
            dtDropDown = objTrn.Transaction(strDropDown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));
            if (dtDropDown != null)
            {
                strbld.Append("<option value =\"0\">Select Building No</option>");
                foreach (DataRow dr in dtDropDown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindFloorNo(string societycode, string bldgno)
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropDown = new string[] { "FLOOR", "BLANK", societycode.ToString(), bldgno.ToString() };
            //string[] strDropdown = new string[] { "FLOOR", "BLANK", bldgno.ToString()};
            dtDropdown = objTrn.Transaction(strDropDown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Floor No</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindUnitNo(string societycode, string bldgno, string floorno)
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "UNIT", "BLANK", societycode.ToString(), bldgno.ToString(), floorno.ToString() };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Unit No</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindTenantType()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "OCCUPIEDBY", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Tenant Type</option>");
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
        public static string LoadTenant(string tenantid)
        {
            DataTable dtListing;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtListing = new DataTable();
            string[] strSelect = new string[] { tenantid.ToString() };
            dtListing = objTrn.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_TenantMaster));

            if (tenantid == "0")
            {
                if (dtListing != null)
                {
                    //strbld.Append("<table class=\"table table-bordered\" id=\"listing\" width=\"100%\" cellspacing=\"0\">");
                    strbld.Append("<thead>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">tenantid</th>");
                    strbld.Append("<th>societyname</th>");
                    strbld.Append("<th>bldgno</th>");
                    strbld.Append("<th>floorno</th>");
                    strbld.Append("<th>unitno</th>");
                    strbld.Append("<th>tenantname</th>");
                    strbld.Append("<th>tenanttype</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</thead>");
                    strbld.Append("<tfoot>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">tenantid</th>");
                    strbld.Append("<th>societyname</th>");
                    strbld.Append("<th>bldgno</th>");
                    strbld.Append("<th>floorno</th>");
                    strbld.Append("<th>unitno</th>");
                    strbld.Append("<th>tenantname</th>");
                    strbld.Append("<th>tenanttype</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</tfoot>");
                    strbld.Append("<tbody>");
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append("<tr>");
                        strbld.Append("<td class=\"hide\">" + dr["tenantid"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["societycode"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["bldgno"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["floorno"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["unitno"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["tenantname"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["tenanttype"].ToString() + "</td>");
                        strbld.Append("<td class=\"text-center\"><i class=\"fa fa-eye\" aria-hidden=\"true\" title=\"View\" onclick=\"LoadTenant(" + dr["tenantid"].ToString() + ")\">&nbsp&nbsp</i><i class=\"fa fa-trash\" title=\"Delete\" aria-hidden=\"true\" onclick=\"DeleteRecord(" + dr["tenantid"].ToString() + ")\"></i></td>");
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
                        strbld.Append(dr["tenantid"].ToString() + "|");
                        strbld.Append(dr["societycode"].ToString() + "|");
                        strbld.Append(dr["bldgno"].ToString() + "|");
                        strbld.Append(dr["floorno"].ToString() + "|");
                        strbld.Append(dr["unitno"].ToString() + "|");
                        strbld.Append(dr["tenantname"].ToString() + "|");
                        strbld.Append(dr["tenanttype"].ToString() + "|");
                        strbld.Append(dr["address"].ToString() + "|");
                        strbld.Append(dr["location"].ToString() + "|");
                        strbld.Append(dr["city"].ToString() + "|");
                        strbld.Append(dr["state"].ToString() + "|");
                        strbld.Append(dr["country"].ToString() + "|");
                        strbld.Append(dr["pincode"].ToString() + "|");
                        strbld.Append(dr["contact1"].ToString() + "|");
                        strbld.Append(dr["contact2"].ToString() + "|");
                        strbld.Append(dr["emailid"].ToString() + "|");
                        strbld.Append(dr["panno"].ToString());
                    }
                }

            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string SaveTenant(string tenantid, string societycode, string bldgno, string floorno, string unitno,
                                        string acgrpcode, string ledgercode, string tenantname, string tenantdesc, string tenanttype, 
                                        string address, string location, string city, string state, string country, 
                                        string pincode, string contact1, string contact2, string emailid, string panno)
        {
            DataTable dtTenantMaster = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            if (tenantid == "0")
            {
                string[] strInsert = new string[] {tenantid.ToString()
                                                    ,societycode.ToString()
                                                    ,bldgno.ToString()
                                                    ,floorno.ToString()
                                                    ,unitno.ToString()
                                                    ,acgrpcode.ToString()
                                                    ,ledgercode.ToString()
                                                    ,tenantname.ToString()
                                                    ,tenantdesc.ToString()
                                                    ,tenanttype.ToString()
                                                    ,address.ToString()
                                                    ,location.ToString()
                                                    ,city.ToString()
                                                    ,state.ToString()
                                                    ,country.ToString()
                                                    ,pincode.ToString()
                                                    ,contact1.ToString()
                                                    ,contact2.ToString()
                                                    ,emailid.ToString()
                                                    ,panno.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};

                     dtTenantMaster = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_TenantMaster));
                
                    strBld = dtTenantMaster.Rows[0]["i_IDENTITY"].ToString() + '|' + dtTenantMaster.Rows[0]["msg"].ToString();
                
            }
            else
            {
                string[] strUpdate = new string[] { tenantid.ToString()
                                                    ,societycode.ToString()
                                                    ,bldgno.ToString()
                                                    ,floorno.ToString()
                                                    ,unitno.ToString()
                                                    ,acgrpcode.ToString()
                                                    ,ledgercode.ToString()
                                                    ,tenantname.ToString()
                                                    ,tenantdesc.ToString()
                                                    ,tenanttype.ToString()
                                                    ,address.ToString()
                                                    ,location.ToString()
                                                    ,city.ToString()
                                                    ,state.ToString()
                                                    ,country.ToString()
                                                    ,pincode.ToString()
                                                    ,contact1.ToString()
                                                    ,contact2.ToString()
                                                    ,emailid.ToString()
                                                    ,panno.ToString()
                                                    ,""//HttpContext.Current.Session["userid"].ToString()
                                                    ,"1"
                                                    ,(clsEnumRequestType.UPDATE).ToString()};

                dtTenantMaster = objTrn.Transaction(strUpdate, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_TenantMaster));

                strBld = dtTenantMaster.Rows[0]["i_IDENTITY"].ToString() + '|' + dtTenantMaster.Rows[0]["msg"].ToString();
            }

            return strBld.ToString();
        }
        [WebMethod]
        public static string DeleteTenant(string tenantid)
        {
            DataTable dtTenantMaster = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            string[] strDelete = new string[] { tenantid.ToString()
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
                                                ,""
                                                ,""
                                                ,""//HttpContext.Current.Session["userid"].ToString()
                                                ,"1"
                                                ,(clsEnumRequestType.DELETE).ToString()};

                dtTenantMaster = objTrn.Transaction(strDelete, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_TenantMaster));
             
                strBld = dtTenantMaster.Rows[0]["i_IDENTITY"].ToString() + '|' + dtTenantMaster.Rows[0]["msg"].ToString();

            return strBld.ToString();
        }
        [WebMethod]
        public static string GetOwner(string unitno)
        {
            DataTable dtListing;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            dtListing = new DataTable();
            string[] strSelect = new string[] { unitno.ToString() };
            dtListing = objTrn.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_UnitMaster));
            if (unitno != "0" && unitno != null)
                if (dtListing != null)
                {
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        {
                            strbld.Append(dr["unitid"].ToString() + "|");
                            strbld.Append(dr["societycode"].ToString() + "|");
                            strbld.Append(dr["bldgno"].ToString() + "|");
                            strbld.Append(dr["floorno"].ToString() + "|");
                            strbld.Append(dr["unitno"].ToString() + "|");
                            strbld.Append(dr["unittype"].ToString() + "|");
                            strbld.Append(dr["unitarea"].ToString() + "|");
                            strbld.Append(dr["occupiedby"].ToString() + "|");
                            strbld.Append(dr["unitowner"].ToString() + "|");
                            strbld.Append(dr["address"].ToString() + "|");
                            strbld.Append(dr["location"].ToString() + "|");
                            strbld.Append(dr["city"].ToString() + "|");
                            strbld.Append(dr["state"].ToString() + "|");
                            strbld.Append(dr["country"].ToString() + "|");
                            strbld.Append(dr["pincode"].ToString() + "|");
                            strbld.Append(dr["contact1"].ToString() + "|");
                            strbld.Append(dr["contact2"].ToString() + "|");
                            strbld.Append(dr["emailid"].ToString() + "|");
                            strbld.Append(dr["panno"].ToString());
                        }
                    }
                }
            return strbld.ToString();
        }
    }
}

