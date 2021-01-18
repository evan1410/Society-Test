using System.Configuration;

namespace BALPortal
{
    public static class GlobalVar
    {
        public static string strUserName { set; get; }
        public static string strUserRole { set; get; }
        public static string sFormName { set; get; }
        public static string errorlog = ConfigurationSettings.AppSettings["ErrorLog"].ToString();
        public static string errortype = ConfigurationSettings.AppSettings["ErrorType"].ToString();
        
        public static int userid { set; get; }
        public static int groupid { set; get; }

        public const string cDeleteConfirmMsg = "Do you really want to delete record?";
        public const string cEditMsg = "No records edited";
        public const string cSystemExitMsg = "Do you sure want to Exit?";
        public const string strFinRStagingConn = "Data Source = INMUMBHPANC820X; Initial Catalog = DPATStaging; User ID = sa; Password =R0ck$@1234;Connection Timeout=30000;";
        public const string uploadfolderpath = "fileupload/";
    }
}
