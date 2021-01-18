using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Configuration;
//using System.Web.Configuration;
using System.IO;
using System.ServiceModel;
using System.Reflection;
using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;

public class clsCommon
{
    #region Constructor

    public clsCommon()
    {
    }

    #endregion Constructor

    #region Methods

    public static void ExceptionLog(FaultException<clsValidationFault> e, object requestDto = null)
    {
        if (requestDto != null)
            e.HelpLink = clsCommon.GetParameterValues(requestDto);

        ExceptionLog("Validation Exception Cought", e.Detail.source, e.Detail.source + " : " + e.Detail.description, e.HelpLink);
    }

    public static void ExceptionLog(Exception e, object requestDto = null)
    {
        try
        {
            if (requestDto != null)
                e.HelpLink = clsCommon.GetParameterValues(requestDto);

            ExceptionLog(e.Message, e.StackTrace, e.Source, e.HelpLink);

        }
        catch (Exception)
        {
        }

    }

    public static void ExceptionLog(string message, string stackTrace, string source, string helpLink)
    {
        try
        {
            var dateTime = DateTime.Now;
            XmlDocument xmlDoc = new XmlDocument();
            //var filePath = ConfigurationManager.AppSettings["ErrorLog"].ToString() + @"\\" + dateTime.Year + "_" + dateTime.Month + "_" + dateTime.Day + "_LogXml.xml";
            var filePath = @"D:\\Projects\\Rahul\\LawyerOnline\\Errorlog" + @"\\" + dateTime.Year + "_" + dateTime.Month + "_" + dateTime.Day + "_LogXml.xml";

            XmlElement rootNode = null;
            XmlNode errorNode = null;

            if (File.Exists(filePath))
            {
                xmlDoc.Load(filePath);
                rootNode = xmlDoc.DocumentElement;
            }

            if (rootNode == null)
                rootNode = xmlDoc.CreateElement("Logs");

            var lstErrorNodes = xmlDoc.SelectNodes("/Logs/error");
            if (lstErrorNodes != null && lstErrorNodes.Count > 0)
                errorNode = lstErrorNodes[0];
            else
                errorNode = xmlDoc.CreateNode(XmlNodeType.Element, "error", null);

            var eventNodes = xmlDoc.SelectNodes("/error/event");

            XmlNode newEvent = xmlDoc.CreateNode(XmlNodeType.Element, "Event", null);

            XmlNode nodeTime = xmlDoc.CreateElement("Time");
            nodeTime.InnerText = dateTime.Year + "/" + dateTime.Month + "/" + dateTime.Day + " TIME : " + dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second + "." + dateTime.Millisecond;

            XmlNode nodeMessage = xmlDoc.CreateElement("Message");
            nodeMessage.InnerText = message;

            XmlNode nodeClass = xmlDoc.CreateElement("StackTrace");
            nodeClass.InnerText = stackTrace;

            XmlNode nodeMethod = xmlDoc.CreateElement("Source");
            nodeMethod.InnerText = source;

            XmlNode nodeHelpLinkParams = xmlDoc.CreateElement("Params");
            nodeHelpLinkParams.InnerText = helpLink;

            newEvent.AppendChild(nodeMessage);
            newEvent.AppendChild(nodeClass);
            newEvent.AppendChild(nodeMethod);
            newEvent.AppendChild(nodeHelpLinkParams);
            newEvent.AppendChild(nodeTime);

            errorNode.AppendChild(newEvent);
            rootNode.AppendChild(errorNode);
            xmlDoc.AppendChild(rootNode);
            //xmlDoc.DocumentElement.AppendChild(newEvent);

            xmlDoc.Save(filePath);
        }
        catch (Exception)
        {
        }
    }

    public static bool IsValidDataSet(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            clsCommon.ExceptionLog(ex);
            throw;
        }
        return false;
    }

    public static bool IsValidDataTable(DataTable dt)
    {
        try
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            clsCommon.ExceptionLog(ex);
            throw;
        }
        return false;
    }

    public static string GetParameterValues(object obj)
    {
        var paramts = "";
        try
        {
            if (obj != null)
            {
                foreach (var Property in obj.GetType().GetProperties())
                {
                    paramts += Property.Name + " : " + Property.GetValue(obj, null) + " _";
                }
            }
            else
            {
                paramts = "Parameter Object Found Null..";
            }

            return paramts;
        }
        catch (Exception ex)
        {
            clsCommon.ExceptionLog(ex);
        }
        return paramts;
    }

    public static DataTable GetDataTableFromObjects<TDataClass>(List<TDataClass> dataList) where TDataClass : class
    {
        Type t = typeof(TDataClass);

        DataTable dt = new DataTable(t.Name);

        foreach (PropertyInfo pi in t.GetProperties())
        {
            dt.Columns.Add(new DataColumn(pi.Name));
        }

        if (dataList != null)
        {
            foreach (TDataClass item in dataList)
            {
                DataRow dr = dt.NewRow();

                foreach (DataColumn dc in dt.Columns)
                {
                    dr[dc.ColumnName] =

                      item.GetType().GetProperty(dc.ColumnName).GetValue(item, null);
                }

                dt.Rows.Add(dr);
            }
        }

        return dt;
    }

    public static string GetEnumDescription(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }



    #endregion Methods
}
