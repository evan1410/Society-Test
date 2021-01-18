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
    public partial class contravoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string BindLedgerFrom()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "LEDGER", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Ledger From</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindLedgerTo()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "LEDGER", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Ledger To</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string LoadContraVoucher(string id)
        {
            DataTable dtListing;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtListing = new DataTable();
            string[] strSelect = new string[] { id.ToString() };
            dtListing = objTrn.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_ContraVoucher));

            if (id == "0")
            {
                if (dtListing != null)
                {
                    //strbld.Append("<table class=\"table table-bordered\" id=\"listing\" width=\"100%\" cellspacing=\"0\">");
                    strbld.Append("<thead>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">id</th>");
                    strbld.Append("<th>Voucher No</th>");
                    strbld.Append("<th>Voucher Date</th>");
                    strbld.Append("<th>From Account</th>");
                    strbld.Append("<th>To Account</th>");
                    strbld.Append("<th>Amount</th>");
                    strbld.Append("<th>Description</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</thead>");
                    strbld.Append("<tfoot>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">id</th>");
                    strbld.Append("<th>Voucher No</th>");
                    strbld.Append("<th>Voucher Date</th>");
                    strbld.Append("<th>From Account</th>");
                    strbld.Append("<th>To Account</th>");
                    strbld.Append("<th>Amount</th>");
                    strbld.Append("<th>Description</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</tfoot>");
                    strbld.Append("<tbody>");
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append("<tr>");
                        strbld.Append("<td class=\"hide\">" + dr["id"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["voucherno"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["voucherdate"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["ledgerfrom"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["ledgerto"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["amount"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["trandesc"].ToString() + "</td>");
                        strbld.Append("<td class=\"text-center\"><i class=\"fa fa-eye\" aria-hidden=\"true\" title=\"View\" onclick=\"LoadContraVoucher(" + dr["id"].ToString() + ")\">&nbsp&nbsp</i><i class=\"fa fa-trash\" title=\"Delete\" aria-hidden=\"true\" onclick=\"DeleteRecord(" + dr["id"].ToString() + ")\"></i></td>");
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
                        strbld.Append(dr["voucherno"].ToString() + "|");
                        strbld.Append(dr["voucherdate"].ToString() + "|");
                        strbld.Append(dr["ledgerfrom"].ToString() + "|");
                        strbld.Append(dr["ledgerto"].ToString() + "|");
                        strbld.Append(dr["amount"].ToString() + "|");
                        strbld.Append(dr["trandesc"].ToString());
                    }
                }

            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string SaveContraVoucher(string id, string voucherno, string voucherdate, string ledgerfrom, string ledgerto, string amount, string trandesc)
        {
            DataTable dtContraVoucher = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            if (id == "0")
            {
                string[] strInsert = new string[] {id.ToString()
                                                    ,voucherno.ToString()
                                                    ,Convert.ToDateTime(voucherdate).ToString("yyyy-MM-dd")
                                                    ,ledgerfrom.ToString()
                                                    ,ledgerto.ToString()
                                                    ,trandesc.ToString()
                                                    ,amount.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};

                dtContraVoucher = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_ContraVoucher));

                strBld = dtContraVoucher.Rows[0]["i_IDENTITY"].ToString() + '|' + dtContraVoucher.Rows[0]["msg"].ToString();
            }
            else
            {
                string[] strUpdate = new string[] { id.ToString()
                                                    ,voucherno.ToString()
                                                    ,Convert.ToDateTime(voucherdate).ToString("yyyy-MM-dd")
                                                    ,ledgerfrom.ToString()
                                                    ,ledgerto.ToString()
                                                    ,trandesc.ToString()
                                                    ,amount.ToString()
                                                    ,""//HttpContext.Current.Session["userid"].ToString()
                                                    ,"1"
                                                    ,(clsEnumRequestType.UPDATE).ToString()};

                dtContraVoucher = objTrn.Transaction(strUpdate, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_ContraVoucher));

                strBld = dtContraVoucher.Rows[0]["i_IDENTITY"].ToString() + '|' + dtContraVoucher.Rows[0]["msg"].ToString();
            }

            return strBld.ToString();
        }
        [WebMethod]
        public static string DeleteContraVoucher(string id)
        {
            DataTable dtContraVoucher = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            string[] strDelete = new string[] { id.ToString()
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""//HttpContext.Current.Session["userid"].ToString()
                                                ,"1"
                                                ,(clsEnumRequestType.DELETE).ToString()};

            dtContraVoucher = objTrn.Transaction(strDelete, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_ContraVoucher));

            strBld = dtContraVoucher.Rows[0]["i_IDENTITY"].ToString() + '|' + dtContraVoucher.Rows[0]["msg"].ToString();


            return strBld.ToString();
        }
    }
}