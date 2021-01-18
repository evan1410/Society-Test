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
    public partial class accountgroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        [WebMethod]
        public static string SaveAccountGroup(string acgrpid, string acgrpcode, string acgrpname, string acgrpdesc)
        {
            DataTable dtAcGrp = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            if (acgrpid == "0")
            {
                string[] strInsert = new string[] {acgrpid.ToString()
                                                    ,acgrpcode.ToString()
                                                    ,acgrpname.ToString()
                                                    ,acgrpdesc.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};
                dtAcGrp = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_AccountGroupMaster));
                strBld = dtAcGrp.Rows[0]["i_IDENTITY"].ToString() + '|' + dtAcGrp.Rows[0]["msg"].ToString();
            }
            else
            {
                string[] strUpdate = new string[] { acgrpid.ToString()
                                                    ,acgrpcode.ToString()
                                                    ,acgrpname.ToString()
                                                    ,acgrpdesc.ToString()
                                                    ,""//HttpContext.Current.Session["userid"].ToString()
                                                    ,"1"
                                                    ,(clsEnumRequestType.UPDATE).ToString()};
                dtAcGrp = objTrn.Transaction(strUpdate, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_AccountGroupMaster));
                strBld = dtAcGrp.Rows[0]["i_IDENTITY"].ToString() + '|' + dtAcGrp.Rows[0]["msg"].ToString();
            }
            return strBld.ToString();
        }


        [WebMethod]
        public static string LoadAccountGroup(string acgrpid)
        {
            DataTable dtListing;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtListing = new DataTable();
            string[] strSelect = new string[] { acgrpid.ToString() };
            dtListing = objTrn.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_AccountGroupMaster));

            if (acgrpid == "0")
            {
                if (dtListing != null)
                {
                    //strbld.Append("<table class=\"table table-bordered\" id=\"listing\" width=\"100%\" cellspacing=\"0\">");
                    strbld.Append("<thead>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">acgrpid</th>");
                    strbld.Append("<th>A/C Group Code</th>");
                    strbld.Append("<th>A/C Name</th>");
                    strbld.Append("<th>Description</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</thead>");
                    strbld.Append("<tfoot>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">acgrpid</th>");
                    strbld.Append("<th>A/C Group Code</th>");
                    strbld.Append("<th>A/C Name</th>");
                    strbld.Append("<th>Description</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</tfoot>");
                    strbld.Append("<tbody>");
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append("<tr>");
                        strbld.Append("<td class=\"hide\">" + dr["acgrpid"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["A/c Group Code"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["A/c Group Name"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["Description"].ToString() + "</td>");
                        strbld.Append("<td class=\"text-center\"><i class=\"fa fa-eye\" aria-hidden=\"true\" title=\"View\" onclick=\"LoadAccountGroup(" + dr["acgrpid"].ToString() + ")\">&nbsp&nbsp</i><i class=\"fa fa-trash\" title=\"Delete\" aria-hidden=\"true\" onclick=\"DeleteRecord(" + dr["acgrpid"].ToString() + ")\"></i></td>");
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
                        strbld.Append(dr["acgrpid"].ToString() + "|");
                        strbld.Append(dr["acgrpcode"].ToString() + "|");
                        strbld.Append(dr["acgrpname"].ToString() + "|");
                        strbld.Append(dr["acgrpdesc"].ToString());                        
                    }
                }

            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string DeleteAccountGroup(string acgrpid)
        {
            DataTable dtAcGrp = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            string[] strDelete = new string[] { acgrpid.ToString()
                                                ,""
                                                ,""
                                                ,""
                                                ,""//HttpContext.Current.Session["userid"].ToString()
                                                ,"1"
                                                ,(clsEnumRequestType.DELETE).ToString()};

            dtAcGrp = objTrn.Transaction(strDelete, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_AccountGroupMaster));

            strBld = dtAcGrp.Rows[0]["i_IDENTITY"].ToString() + '|' + dtAcGrp.Rows[0]["msg"].ToString();
           
            return strBld.ToString();
        }
    }
}
