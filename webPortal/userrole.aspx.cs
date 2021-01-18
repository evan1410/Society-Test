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
    public partial class userrole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string LoadUserRole(string groupid)
        {
            DataTable dtListing;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtListing = new DataTable();
            string[] strSelect = new string[] { groupid.ToString() };
            dtListing = objTrn.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_UserGroup));

            if (groupid == "0")
            {
                if (dtListing != null)
                {
                    //strbld.Append("<table class=\"table table-bordered\" id=\"listing\" width=\"100%\" cellspacing=\"0\">");
                    strbld.Append("<thead>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">groupid</th>");
                    strbld.Append("<th>Group Code</th>");
                    strbld.Append("<th>Group Name</th>");
                    strbld.Append("<th>Description</th>");
                    strbld.Append("<th>Last Modified by</th>");
                    strbld.Append("<th>Last Modified On</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</thead>");
                    strbld.Append("<tfoot>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">groupid</th>");
                    strbld.Append("<th>Group Code</th>");
                    strbld.Append("<th>Group Name</th>");
                    strbld.Append("<th>Description</th>");
                    strbld.Append("<th>Last Modified by</th>");
                    strbld.Append("<th>Last Modified On</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</tfoot>");
                    strbld.Append("<tbody>");
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append("<tr>");
                        strbld.Append("<td class=\"hide\">" + dr["groupid"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["groupcode"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["groupName"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["groupdesc"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["LastModifiedBy"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["LastModifiedOn"].ToString() + "</td>");
                        strbld.Append("<td class=\"text-center\"><i class=\"fa fa-eye\" aria-hidden=\"true\" title=\"View\" onclick=\"LoadUserRole(" + dr["groupid"].ToString() + ")\">&nbsp&nbsp</i><i class=\"fa fa-trash\" title=\"Delete\" aria-hidden=\"true\" onclick=\"DeleteRecord(" + dr["groupid"].ToString() + ")\"></i></td>");
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
                        strbld.Append(dr["groupid"].ToString() + "|");
                        strbld.Append(dr["groupcode"].ToString() + "|");
                        strbld.Append(dr["groupname"].ToString() + "|");
                        strbld.Append(dr["groupdesc"].ToString());
                    }
                }

            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string SaveUserRole(string groupid, string groupcode, string groupname, string groupdesc)
        {
            DataTable dtUserRole = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            if (groupid == "0")
            {
                string[] strInsert = new string[] { groupid.ToString()
                                                    ,groupcode.ToString()
                                                    ,groupname.ToString()
                                                    ,groupdesc.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};

                dtUserRole = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_UserGroup));

                strBld = dtUserRole.Rows[0]["i_IDENTITY"].ToString() + '|' + dtUserRole.Rows[0]["msg"].ToString();
            }
            else
            {
                string[] strUpdate = new string[] { groupid.ToString()
                                                    ,groupcode.ToString()
                                                    ,groupname.ToString()
                                                    ,groupdesc.ToString()
                                                    ,""//HttpContext.Current.Session["userid"].ToString()
                                                    ,"1"
                                                    ,(clsEnumRequestType.UPDATE).ToString()};

                dtUserRole = objTrn.Transaction(strUpdate, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_UserGroup));

                strBld = dtUserRole.Rows[0]["i_IDENTITY"].ToString() + '|' + dtUserRole.Rows[0]["msg"].ToString();
            }

            return strBld.ToString();
        }

        [WebMethod]
        public static string DeleteUserRole(string groupid)
        {
            DataTable dtUserRole = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            string[] strDelete = new string[] { groupid.ToString()
                                                ,""
                                                ,""
                                                ,""
                                                ,""//HttpContext.Current.Session["userid"].ToString()
                                                ,"1"
                                                ,(clsEnumRequestType.DELETE).ToString()};

            dtUserRole = objTrn.Transaction(strDelete, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_UserGroup));

            strBld = dtUserRole.Rows[0]["i_IDENTITY"].ToString() + '|' + dtUserRole.Rows[0]["msg"].ToString();


            return strBld.ToString();
        }
    }
}