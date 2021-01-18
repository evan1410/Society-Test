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
    public partial class paymentvoucher : System.Web.UI.Page
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
        public static string LoadPaymentVoucher(string pvid)
        {
            DataTable dtListing;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtListing = new DataTable();
            string[] strSelect = new string[] { pvid.ToString() };
            dtListing = objTrn.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_PaymentVoucher));

            if (pvid == "0")
            {
                if (dtListing != null)
                {
                    //strbld.Append("<table class=\"table table-bordered\" id=\"listing\" width=\"100%\" cellspacing=\"0\">");
                    strbld.Append("<thead>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">pvid</th>");
                    strbld.Append("<th>Voucher No</th>");
                    strbld.Append("<th>VoucherDate</th>");
                    strbld.Append("<th>FromAccount</th>");
                    strbld.Append("<th>Trandesc</th>");
                    strbld.Append("<th>Subtotal</th>");
                    strbld.Append("<th>Discount</th>");
                    strbld.Append("<th>Gst</th>");
                    strbld.Append("<th>TotalAmt</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</thead>");
                    strbld.Append("<tfoot>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">pvid</th>");
                    strbld.Append("<th>Voucher No</th>");
                    strbld.Append("<th>VoucherDate</th>");
                    strbld.Append("<th>FromAccount</th>");
                    strbld.Append("<th>Trandesc</th>");
                    strbld.Append("<th>Subtotal</th>");
                    strbld.Append("<th>Discount</th>");
                    strbld.Append("<th>Gst</th>");
                    strbld.Append("<th>TotalAmt</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</tfoot>");
                    strbld.Append("<tbody>");
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append("<tr>");
                        strbld.Append("<td class=\"hide\">" + dr["pvid"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["voucherno"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["voucherdate"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["ledgerfrom"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["trandesc"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["subtotal"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["discount"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["gst"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["totalamt"].ToString() + "</td>");
                        strbld.Append("<td class=\"text-center\"><i class=\"fa fa-eye\" aria-hidden=\"true\" title=\"View\" onclick=\"LoadPayment(" + dr["pvid"].ToString() + ")\">&nbsp&nbsp</i><i class=\"fa fa-trash\" title=\"Delete\" aria-hidden=\"true\" onclick=\"DeleteRecord(" + dr["pvid"].ToString() + ")\"></i></td>");
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
                        strbld.Append(dr["pvid"].ToString() + "|");
                        strbld.Append(dr["voucherno"].ToString() + "|");
                        strbld.Append(dr["voucherdate"].ToString() + "|");
                        strbld.Append(dr["ledgerfrom"].ToString() + "|");
                        strbld.Append(dr["trandesc"].ToString() + "|");
                        strbld.Append(dr["subtotal"].ToString() + "|");
                        strbld.Append(dr["discount"].ToString() + "|");
                        strbld.Append(dr["gst"].ToString() + "|");
                        strbld.Append(dr["totalamt"].ToString());
                    }
                }

            }
            return strbld.ToString();
        }


        [WebMethod]
        public static string SavePaymentVoucher(string pvid, string voucherno, string voucherdate, string ledgerfrom, string trandesc, string subtotal,
                                         string discount, string gst, string totalamt)
        {
            DataTable dtPaymentVoucher = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            if (pvid == "0")
            {
                string[] strInsert = new string[] {pvid.ToString()
                                                    ,voucherno.ToString()
                                                    ,Convert.ToDateTime(voucherdate).ToString("yyyy-MM-dd")
                                                    ,ledgerfrom.ToString()
                                                    ,trandesc.ToString()
                                                    ,subtotal.ToString()
                                                    ,discount.ToString()
                                                    ,gst.ToString()
                                                    ,totalamt.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};

                dtPaymentVoucher = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_PaymentVoucher));

                strBld = dtPaymentVoucher.Rows[0]["i_IDENTITY"].ToString() + '|' + dtPaymentVoucher.Rows[0]["msg"].ToString();
            }
            else
            {
                string[] strUpdate = new string[] { pvid.ToString()
                                                    ,voucherno.ToString()
                                                    ,Convert.ToDateTime(voucherdate).ToString("yyyy-MM-dd")
                                                    ,ledgerfrom.ToString()
                                                    ,trandesc.ToString()
                                                    ,subtotal.ToString()
                                                    ,discount.ToString()
                                                    ,gst.ToString()
                                                    ,totalamt.ToString()
                                                    ,""//HttpContext.Current.Session["userid"].ToString()
                                                    ,"1"
                                                    ,(clsEnumRequestType.UPDATE).ToString()};

                dtPaymentVoucher = objTrn.Transaction(strUpdate, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_PaymentVoucher));

                strBld = dtPaymentVoucher.Rows[0]["i_IDENTITY"].ToString() + '|' + dtPaymentVoucher.Rows[0]["msg"].ToString();
            }

            return strBld.ToString();
        }


        [WebMethod]
        public static string SavePaymentDtls(string id, string pvid, string ledgerto, string qty, string rate, string amount, string gstamt, string total)
        {
            DataTable dtPaymentVoucher = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            if (pvid == "0")
            {
                string[] strInsert = new string[] {id.ToString()
                                                    ,pvid.ToString()
                                                    ,ledgerto.ToString()
                                                    ,qty.ToString()
                                                    ,rate.ToString()
                                                    ,amount.ToString()
                                                    ,gstamt.ToString()
                                                    ,total.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};

                dtPaymentVoucher = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_PaymentVoucherDtls));

                strBld = dtPaymentVoucher.Rows[0]["i_IDENTITY"].ToString() + '|' + dtPaymentVoucher.Rows[0]["msg"].ToString();
            }
            else
            {
                string[] strUpdate = new string[] { id.ToString()
                                                    ,pvid.ToString()
                                                    ,ledgerto.ToString()
                                                    ,qty.ToString()
                                                    ,rate.ToString()
                                                    ,amount.ToString()
                                                    ,gstamt.ToString()
                                                    ,total.ToString()
                                                    ,""//HttpContext.Current.Session["userid"].ToString()
                                                    ,"1"
                                                    ,(clsEnumRequestType.UPDATE).ToString()};

                dtPaymentVoucher = objTrn.Transaction(strUpdate, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_PaymentVoucherDtls));

                strBld = dtPaymentVoucher.Rows[0]["i_IDENTITY"].ToString() + '|' + dtPaymentVoucher.Rows[0]["msg"].ToString();
            }

            return strBld.ToString();
        }



        [WebMethod]
        public static string DeletePaymentVoucher(string pvid)
        {
            DataTable dtPaymentVoucher = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            string[] strDelete = new string[] { pvid.ToString()
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

            dtPaymentVoucher = objTrn.Transaction(strDelete, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_PaymentVoucher));
            dtPaymentVoucher = objTrn.Transaction(strDelete, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_PaymentVoucherDtls));

            strBld = dtPaymentVoucher.Rows[0]["i_IDENTITY"].ToString() + '|' + dtPaymentVoucher.Rows[0]["msg"].ToString();

            return strBld.ToString();
        }
    }
}