using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class clsError
{
    public void ErrorLog(string strErrorLocation, Exception ex)
    {
        string strErrorMsg = ex.Message;
        File.AppendAllText(HttpContext.Current.Server.MapPath(@"Error") + "/Error" + DateTime.Now.ToString("yyyyMMdd") + ".txt", "Error Occured At: " + DateTime.Now + Environment.NewLine + "ErrorLocation: " + strErrorLocation + Environment.NewLine + "ErrorTrace:" + ex.StackTrace + Environment.NewLine + "ErrorMessage" + strErrorMsg + Environment.NewLine + Environment.NewLine + Environment.NewLine);
    }
}
