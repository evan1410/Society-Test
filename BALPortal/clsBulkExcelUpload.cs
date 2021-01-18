using System;
using System.Data;
using DALPortal;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using BALPortal;
using System.Reflection;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using BALPortal;

namespace BALPortal
{
    public class clsBulkExcelUpload
    {
        clsConnection FinR = new clsConnection();
        clsCommonFunction objCommon = new clsCommonFunction();
        clsConnection conn = new clsConnection();
        //public void BulkCSVUpload(string CSVFilePath, string sTableName, Control ctrl)
        //{
        //    try
        //    {
        //        CSVDataReader rdr = new CSVDataReader(CSVFilePath);
        //        using (SqlConnection con = new SqlConnection(GlobalVar.strFinRStagingConn))
        //        {
        //            con.Open();
        //            string strQuery = "TRUNCATE TABLE " + sTableName + "";
        //            SqlCommand truncate = new SqlCommand(strQuery, con);
        //            truncate.ExecuteNonQuery();
        //            con.Close();
        //        }

        //        SqlBulkCopy bcp = new SqlBulkCopy(conn.SetCommandConnectionProperty, SqlBulkCopyOptions.KeepIdentity);
        //        bcp.BatchSize = 50000;
        //        bcp.DestinationTableName = sTableName;
        //        bcp.NotifyAfter = 100;
        //        bcp.SqlRowsCopied += (sender, e) =>
        //        {
        //            ctrl.Text = "";
        //            ctrl.Text = e.RowsCopied.ToString() + " records transferred in temporory table.";
        //            //MessageBox.Show("Written:" + e.RowsCopied.ToString() + "");
        //        };
        //        bcp.WriteToServer(rdr);
        //    }
        //    catch (Exception ex)
        //    {
        //        objCommon.ExceptionLog(GlobalVar.errorlog, ex.Message.ToString(), ex.StackTrace.ToString(), ex.Source.ToString(), DBNull.Value.ToString());
        //    }
        //}

        public void BulkExcelUpload(string ExcelConnString, DataTable dtUploadCol, string sTableName)
        {
            try
            {
                using (OleDbConnection excel_con = new OleDbConnection(ExcelConnString))
                {
                    excel_con.Open();

                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();

                    DataTable dtExcelData = new DataTable();

                    foreach (DataRow dr in dtUploadCol.Rows)
                    {
                        dtExcelData.Columns.Add(dr["colname"].ToString(), typeof(string));
                    }

                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelData);
                    }
                    excel_con.Close();
                    int TotalRecordCount = dtExcelData.Rows.Count;
                    using (SqlConnection con = new SqlConnection(GlobalVar.strFinRStagingConn))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {                                
                            sqlBulkCopy.DestinationTableName = sTableName;
                            foreach (DataRow dr in dtUploadCol.Rows)
                            {
                                sqlBulkCopy.ColumnMappings.Add(dr["colname"].ToString(), dr["colname"].ToString());
                            }
                            con.Open();
                            string strQuery = "TRUNCATE TABLE " + sTableName + "";
                            SqlCommand truncate = new SqlCommand(strQuery, con);
                            truncate.ExecuteNonQuery();
                            sqlBulkCopy.WriteToServer(dtExcelData);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objCommon.ExceptionLog(GlobalVar.errorlog, ex.Message.ToString(), ex.StackTrace.ToString(), ex.Source.ToString(), DBNull.Value.ToString());
            }
        }
    }
}
