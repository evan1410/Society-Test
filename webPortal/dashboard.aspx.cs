using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BALPortal;
using DALPortal;
using System.Text;

namespace webPortal
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static string GetMenu(string groupid)
        {
            DataTable dtMenu;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            dtMenu = new DataTable();

            string[] strMenu = new string[] { groupid };

            dtMenu = objTrn.Transaction(strMenu, clsConnection.GetEnumDescription(clsEnumSP.SelectMenuAuth));

            if (dtMenu != null)
            {
                //strbld.Append("<ul class=\"navbar-nav navbar-sidenav\" id=\"exampleAccordion\">");
                DataView dvRecordList = dtMenu.DefaultView;
                dvRecordList.RowFilter = "parentmenuid = 0";

                //Sidebar - Brand
                strbld.Append("<a class=\"sidebar-brand d-flex align-items-center justify-content-center\" href=\"dashboard.aspx\">");

                strbld.Append("<div><img src=\"img/logo.png\"></div>");

                //strbld.Append("<div class=\"sidebar-brand-icon rotate-n-15\">");
                //strbld.Append("<i class=\"fas fa-laugh-wink\"></i>");
                //strbld.Append("</div>");
                //strbld.Append("<div class=\"sidebar-brand-text mx-3\">Deloitte</div>");
                strbld.Append("</a>");

                
                foreach (DataRowView row in dvRecordList)
                {


                    strbld.Append("<li class=\"nav-item\">");

                    strbld.Append("<a class=\"nav-link collapsed\" href=\"#\" data-toggle=\"collapse\" data-target=\"#collapsePages" + row["menuid"].ToString() + "\" aria-expanded=\"true\" aria-controls=\"collapsePages" + row["menuid"].ToString() + "\">");
                    strbld.Append("<i class=\"fas fa-fw fa-folder\"></i>");
                    strbld.Append("<span>" + row["menuname"].ToString() + "</span>");
                    strbld.Append("</a>");

                    strbld.Append("<div id =\"collapsePages" + row["menuid"].ToString() + "\" class=\"collapse\" aria-labelledby=\"headingPages\" data-parent=\"#accordionSidebar\">");
                    strbld.Append("<div class=\"bg-white py-2 collapse-inner rounded\">");
                    DataView dvSubmenu = dtMenu.DefaultView;
                    dvSubmenu.RowFilter = "parentmenuid = " + row["menuid"].ToString();
                    strbld.Append("<h6 class=\"collapse -header\"></h6>");
                    foreach (DataRowView dr in dvSubmenu)
                    {                        
                        strbld.Append("<a class=\"collapse-item\" href=\"" + dr["pagename"].ToString() + "\">" + dr["menuname"].ToString() + "</a>");
                    }
                    strbld.Append("</div>");
                    strbld.Append("</div>");
                    strbld.Append("</li>");
                }

                //Divider
                //strbld.Append("<hr class=\"sidebar -divider d-none d-md-block\">");

                ////Sidebar Toggler(Sidebar)
                //strbld.Append("<div class=\"text-center d-none d-md-inline\">");
                //strbld.Append("<button class=\"rounded-circle border-0\" id=\"sidebarToggle\"></button>");
                //strbld.Append("</div>");
                //strbld.Append("</ul>");
            }
            return strbld.ToString();
        }

        [WebMethod(EnableSession = true)]
        public static string logout()
        {
            string strret = "";
            HttpContext.Current.Session["empid"] = null;
            HttpContext.Current.Session["groupid"] = null;
            HttpContext.Current.Session["name"] = null;
            HttpContext.Current.Session["email"] = null;

            strret = "0";
            return strret;
        }
    }
}