using System;
using System.Data;
using DALPortal;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace BALPortal
{
    public class clsCommonFunction
    {
        public bool CompareTables(DataTable tbl1, DataTable tbl2)
        {
            if (tbl1.Rows.Count != tbl2.Rows.Count || tbl1.Columns.Count != tbl2.Columns.Count)
                return false;


            for (int i = 0; i < tbl1.Rows.Count; i++)
            {
                for (int c = 0; c < tbl1.Columns.Count; c++)
                {
                    if (!Equals(tbl1.Rows[i][c].ToString().Trim().ToUpper(), tbl2.Rows[i][c].ToString().Trim().ToUpper()))
                        return false;
                }
            }
            return true;
        }
        
        public DataTable CreateDataTable(DataTable dtNew, string parameterList)
        {
            DataTable MyDataTable = new DataTable("Buffer");
            MyDataTable = dtNew.Clone();
            MyDataTable.Rows.Add();
            for (int i = 0; i < parameterList.Split('|').Length; i++)
            {
                if (MyDataTable.Columns[i].DataType == typeof(decimal) || MyDataTable.Columns[i].DataType == typeof(int))
                {
                    if (parameterList.Split('|')[i].ToString().Trim() == "")
                    {
                        MyDataTable.Rows[0][i] = DBNull.Value;
                    }
                    else
                    {
                        MyDataTable.Rows[0][i] = parameterList.Split('|')[i];
                    }

                }
                else
                {
                    MyDataTable.Rows[0][i] = parameterList.Split('|')[i];
                }

            }
            return MyDataTable;
        }

        public void ExceptionLog(string pfilepath, string message, string stackTrace, string source, string helpLink)
        {
            try
            {
                switch (GlobalVar.errortype)
                {
                    case "1":
                        break;
                    case "2":
                        var dateTime = DateTime.Now;
                        XmlDocument xmlDoc = new XmlDocument();
                        var filePath = pfilepath.ToString() + @"\\" + dateTime.Year + "_" + dateTime.Month + "_" + dateTime.Day + "_LogXml.xml";
                        XmlElement rootNode = null;
                        XmlNode errorNode = null;
                        //MessageBox.Show(message, "FinR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        break;
                    case "3":
                        break;
                }

            }
            catch (Exception)
            {
            }
        }        


    }
}
