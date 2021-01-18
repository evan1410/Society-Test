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
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using BALPortal;
using DALPortal;

namespace webPortal
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static string signin(string username, string password)
        {
            try
            {
                DataTable dtRegistration;
                clsTransaction objTrn = new clsTransaction();
                string strBld = string.Empty;
                dtRegistration = new DataTable();

                string email = username;
                int indexOfAt = email.IndexOf('@');
                string domain = email.Substring(indexOfAt + 1);

                if (domain == "deloitte.com")
                {
                    string pathh = "LDAP://ATRAPA.Deloitte.com:389";
                    var pc = new PrincipalContext(ContextType.Domain, "ATRAPA");
                    var user = UserPrincipal.FindByIdentity(pc, username);

                    Boolean success = false;
                    DirectoryEntry entry = new DirectoryEntry(pathh, username, password, AuthenticationTypes.FastBind);
                    DirectorySearcher searcher = new DirectorySearcher(entry);
                    searcher.SearchScope = System.DirectoryServices.SearchScope.Base;

                    System.DirectoryServices.SearchResult result = searcher.FindOne();


                    HttpContext.Current.Session["empid"] = user.EmployeeId;
                    HttpContext.Current.Session["groupid"] = "3";
                    HttpContext.Current.Session["name"] = user.Name;
                    HttpContext.Current.Session["email"] = user.EmailAddress;
                    
                    strBld = "";
                }
                else
                {
                    string[] strLogin = new string[] { username, password };

                    dtRegistration = objTrn.Transaction(strLogin, clsConnection.GetEnumDescription(clsEnumSP.usp_Login));

                    if (dtRegistration.Rows[0]["userid"].ToString() != "0")
                    {
                        HttpContext.Current.Session["empid"] = dtRegistration.Rows[0]["userid"].ToString();
                        HttpContext.Current.Session["groupid"] = dtRegistration.Rows[0]["groupid"].ToString();
                        HttpContext.Current.Session["name"] = dtRegistration.Rows[0]["username"].ToString();
                        HttpContext.Current.Session["email"] = dtRegistration.Rows[0]["emailid"].ToString();

                        strBld = "";
                    }
                    else
                    {
                        strBld = dtRegistration.Rows[0]["username"].ToString();
                    }
                }
                return strBld.ToString();
            }
            catch (Exception ex)
            {
                string strBld = string.Empty;
                strBld = ex.Message;
                return strBld;
            }
        }
    }
}