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
    public partial class ledgermaster : System.Web.UI.Page
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
        public static string BindAdjustment()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "ADJUSTMENT", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Adjustment</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string LoadLedger(string ledgerid)
        {
            DataTable dtListing;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtListing = new DataTable();
            string[] strSelect = new string[] { ledgerid.ToString() };
            dtListing = objTrn.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_LedgerMaster));

            if (ledgerid == "0")
            {
                if (dtListing != null)
                {
                    //strbld.Append("<table class=\"table table-bordered\" id=\"listing\" width=\"100%\" cellspacing=\"0\">");
                    strbld.Append("<thead>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">ledgerid</th>");
                    strbld.Append("<th>A/c Group Code</th>");
                    strbld.Append("<th>Ledger Code</th>");
                    strbld.Append("<th>Ledger Name</th>");
                    strbld.Append("<th>Ledger Desc</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</thead>");
                    strbld.Append("<tfoot>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">ledgerid</th>");
                    strbld.Append("<th>A/c Group Code</th>");
                    strbld.Append("<th>Ledger Code</th>");
                    strbld.Append("<th>Ledger Name</th>");
                    strbld.Append("<th>Ledger Desc</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</tfoot>");
                    strbld.Append("<tbody>");
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append("<tr>");
                        strbld.Append("<td class=\"hide\">" + dr["ledgerid"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["A/c Group Name"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["Ledger Code"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["Ledger Name"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["Description"].ToString() + "</td>");
                        strbld.Append("<td class=\"text-center\"><i class=\"fa fa-eye\" aria-hidden=\"true\" title=\"View\" onclick=\"LoadLedger(" + dr["ledgerid"].ToString() + ")\">&nbsp&nbsp</i><i class=\"fa fa-trash\" title=\"Delete\" aria-hidden=\"true\" onclick=\"DeleteRecord(" + dr["ledgerid"].ToString() + ")\"></i></td>");
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
                        strbld.Append(dr["ledgerid"].ToString() + "|");
                        strbld.Append(dr["acgrpcode"].ToString() + "|");
                        strbld.Append(dr["ledgercode"].ToString() + "|");
                        strbld.Append(dr["ledgername"].ToString() + "|");
                        strbld.Append(dr["ledgerdesc"].ToString() + "|");
                        strbld.Append(dr["isdetails"].ToString() + "|");
                        strbld.Append(dr["address"].ToString() + "|");
                        strbld.Append(dr["city"].ToString() + "|");
                        strbld.Append(dr["state"].ToString() + "|");
                        strbld.Append(dr["country"].ToString() + "|");
                        strbld.Append(dr["pincode"].ToString() + "|");
                        strbld.Append(dr["panno"].ToString() + "|");
                        strbld.Append(dr["isgstapplicable"].ToString() + "|");
                        strbld.Append(dr["gstno"].ToString() + "|");
                        strbld.Append(dr["gstpercent"].ToString() + "|");
                        strbld.Append(dr["isadjustment"].ToString() + "|");
                        strbld.Append(dr["adjustment"].ToString() + "|");
                        strbld.Append(dr["adjustmentvalue"].ToString());

                    }
                }

            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string SaveLedger(string ledgerid, string acgrpcode, string ledgercode, string ledgername, string ledgerdesc, string isdetails, string address, string city, string state, string country, string pincode, string panno, string isgstapplicable, string gstno, string gstpercent, string isadjustment, string adjustment, string adjustmentvalue)
        {
            DataTable dtLedger = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            if (ledgerid == "0")
            {
                string[] strInsert = new string[] {ledgerid.ToString()
                                                    ,acgrpcode.ToString()
                                                    ,ledgercode.ToString()
                                                    ,ledgername.ToString()
                                                    ,ledgerdesc.ToString()
                                                    ,isdetails.ToString()
                                                    ,address.ToString()
                                                    ,city.ToString()
                                                    ,state.ToString()
                                                    ,country.ToString()
                                                    ,pincode.ToString()
                                                    ,isgstapplicable.ToString()
                                                    ,gstno.ToString()
                                                    ,gstpercent.ToString()
                                                    ,panno.ToString()
                                                    ,isadjustment.ToString()
                                                    ,adjustment.ToString()
                                                    ,adjustmentvalue.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};

                dtLedger = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_LedgerMaster));

                strBld = dtLedger.Rows[0]["i_IDENTITY"].ToString() + '|' + dtLedger.Rows[0]["msg"].ToString();
            }
            else
            {
                string[] strUpdate = new string[] { ledgerid.ToString()
                                                    ,acgrpcode.ToString()
                                                    ,ledgercode.ToString()
                                                    ,ledgername.ToString()
                                                    ,ledgerdesc.ToString()
                                                    ,isdetails.ToString()
                                                    ,address.ToString()
                                                    ,city.ToString()
                                                    ,state.ToString()
                                                    ,country.ToString()
                                                    ,pincode.ToString()
                                                    ,isgstapplicable.ToString()
                                                    ,gstno.ToString()
                                                    ,gstpercent.ToString()
                                                    ,panno.ToString()
                                                    ,isadjustment.ToString()
                                                    ,adjustment.ToString()
                                                    ,adjustmentvalue.ToString()
                                                    ,""//HttpContext.Current.Session["userid"].ToString()
                                                    ,"1"
                                                    ,(clsEnumRequestType.UPDATE).ToString()};

                dtLedger = objTrn.Transaction(strUpdate, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_LedgerMaster));

                strBld = dtLedger.Rows[0]["i_IDENTITY"].ToString() + '|' + dtLedger.Rows[0]["msg"].ToString();
            }

            return strBld.ToString();
        }
        [WebMethod]
        public static string DeleteLedger(string ledgerid)
        {
            DataTable dtLedger = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            string[] strDelete = new string[] { ledgerid.ToString()
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

            dtLedger = objTrn.Transaction(strDelete, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_LedgerMaster));

            strBld = dtLedger.Rows[0]["i_IDENTITY"].ToString() + '|' + dtLedger.Rows[0]["msg"].ToString();


            return strBld.ToString();
        }
    }
}