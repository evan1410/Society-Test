using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;

namespace DALPortal
{
    public class clsConnection
    {
        public SqlCommand SetCommandObjectProperty(CommandType varCommandType)
        {
            try
            {
                SqlCommand objSqlCommand = new SqlCommand();
                objSqlCommand.CommandType = varCommandType;
                objSqlCommand.CommandTimeout = 30000;
                //objSqlCommand.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineOfficeConnectionString"].ToString());
               objSqlCommand.Connection = new SqlConnection("Data Source = 180.149.242.68; Initial Catalog = SocietyDB; User ID = socuser; Password =yG716e?f;Connection Timeout=30000;");
                //objSqlCommand.Connection = new SqlConnection("Data Source = INMUM0717; Initial Catalog = DPATDB; User ID = bhpanchal; Password =t@ngo1234;Connection Timeout=30000;");
               //objSqlCommand.Connection = new SqlConnection("Data Source = INMUMSAKHAK820X; Initial Catalog = DPATDB;Integrated Security=True;Connection Timeout=30000;");
                SetCommandConnectionProperty(objSqlCommand, true);
                return objSqlCommand;
            }
            catch (Exception ex)
            {
                clsCommon.ExceptionLog(ex);
                throw ex;
            }
        }

        //public SqlCommand SetCommandObjectPropertyAdharVault(CommandType varCommandType)
        //{
        //    try
        //    {
        //        SqlCommand objSqlCommand = new SqlCommand();
        //        objSqlCommand.CommandType = varCommandType;
        //        objSqlCommand.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["CommandTimeOut"]);
        //        objSqlCommand.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdharDataVault"].ToString());
        //        SetCommandConnectionProperty(objSqlCommand, true); 
        //        return objSqlCommand;
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.ExceptionLog(ex);
        //        throw ex;
        //    }
        //}
        public string ExcelConString(string strFileName, string FileName)
        {
            string HDR = "Yes";
            string conString;

            if (strFileName.Substring(strFileName.LastIndexOf('.')).ToLower() == ".xlsx")
                conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";


            conString = string.Format(conString, FileName);

            return conString;
        }

        public void SetCommandConnectionProperty(SqlCommand objSqlCommand, bool varOpen)
        {
            try
            {
                if (varOpen == true)
                {
                    if (objSqlCommand.Connection.State == ConnectionState.Closed)
                    {
                        objSqlCommand.Connection.Open();
                    }
                }
                else
                {
                    if (objSqlCommand.Connection.State == ConnectionState.Open)
                    {
                        objSqlCommand.Connection.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                // Common.ExceptionLog(ex);
                throw ex;

            }
        }

        public string ExecuteScalar(string procedure, string parameterList)
        {
            SqlCommand My_SQLCommand = new SqlCommand();
            My_SQLCommand = SetCommandObjectProperty(CommandType.StoredProcedure);
            My_SQLCommand.CommandText = procedure;
            SqlCommandBuilder.DeriveParameters(My_SQLCommand);

            for (int i = 0, j = 0; i < parameterList.Split('|').Length; i++, j++)
            {
                if (My_SQLCommand.Parameters[j].Direction == ParameterDirection.Input)
                {
                    if (parameterList.Split('|')[i] == "" || parameterList.Split('|')[i] == null)
                    {
                        My_SQLCommand.Parameters[j].Value = DBNull.Value;
                    }
                    else
                    {
                        switch (My_SQLCommand.Parameters[j].SqlDbType)
                        {
                            case SqlDbType.Bit:
                                My_SQLCommand.Parameters[j].Value = Convert.ToBoolean(Convert.ToInt32(parameterList.Split('|')[i]));
                                break;

                            case SqlDbType.Int:
                                My_SQLCommand.Parameters[j].Value = Convert.ToInt32(parameterList.Split('|')[i]);
                                break;

                            case SqlDbType.VarChar:
                                My_SQLCommand.Parameters[j].Value = parameterList.Split('|')[i];
                                break;

                            case SqlDbType.Decimal:
                                My_SQLCommand.Parameters[j].Value = Convert.ToDecimal(parameterList.Split('|')[i]);
                                break;

                            case SqlDbType.NVarChar:
                                My_SQLCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
                                break;
                        }
                    }
                }
                else
                {
                    i--;
                }
            }
            return My_SQLCommand.ExecuteScalar().ToString();
        }

        public void ExecuteNonQuery(string procedure, string parameterList)
        {
            SqlCommand My_SQLCommand = new SqlCommand();
            My_SQLCommand = SetCommandObjectProperty(CommandType.StoredProcedure);
            My_SQLCommand.CommandText = procedure;
            SqlCommandBuilder.DeriveParameters(My_SQLCommand);
            for (int i = 0, j = 0; i < parameterList.Split('|').Length; i++, j++)
            {
                if (My_SQLCommand.Parameters[j].Direction == ParameterDirection.Input)
                {
                    if (parameterList.Split('|')[i] == "" || parameterList.Split('|')[i] == null)
                    {
                        My_SQLCommand.Parameters[j].Value = DBNull.Value;
                    }
                    else
                    {
                        switch (My_SQLCommand.Parameters[j].SqlDbType)
                        {
                            case SqlDbType.Bit:
                                My_SQLCommand.Parameters[j].Value = Convert.ToBoolean(Convert.ToInt32(parameterList.Split('|')[i]));
                                break;

                            case SqlDbType.Int:
                                My_SQLCommand.Parameters[j].Value = Convert.ToInt32(parameterList.Split('|')[i]);
                                break;

                            case SqlDbType.VarChar:
                                My_SQLCommand.Parameters[j].Value = parameterList.Split('|')[i];
                                break;

                            case SqlDbType.Decimal:
                                My_SQLCommand.Parameters[j].Value = Convert.ToDecimal(parameterList.Split('|')[i]);
                                break;

                            case SqlDbType.NVarChar:
                                My_SQLCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
                                break;
                        }
                    }
                }
                else
                {
                    i--;
                }
            }
            My_SQLCommand.ExecuteNonQuery();
        }

        public DataTable ReturnDataTable(string procedure, string parameterList)
        {

            DataTable MyDataTable = new DataTable("Buffer");
            SqlDataAdapter My_SQLDataAdapter = new SqlDataAdapter();
            My_SQLDataAdapter.SelectCommand = SetCommandObjectProperty(CommandType.StoredProcedure);
            My_SQLDataAdapter.SelectCommand.CommandText = procedure;
            SqlCommandBuilder.DeriveParameters(My_SQLDataAdapter.SelectCommand);
            try
            {
                if (parameterList != "")
                {
                    for (int i = 0, j = 0; i < parameterList.Split('|').Length; i++, j++)
                    {
                        if (My_SQLDataAdapter.SelectCommand.Parameters[j].Direction == ParameterDirection.Input)
                        {
                            if (parameterList.Split('|')[i] == "" || parameterList.Split('|')[i] == null)
                            {
                                My_SQLDataAdapter.SelectCommand.Parameters[j].Value = DBNull.Value;
                            }
                            else
                            {
                                switch (My_SQLDataAdapter.SelectCommand.Parameters[j].SqlDbType)
                                {
                                    case SqlDbType.Bit:
                                        My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToBoolean(parameterList.Split('|')[i]);
                                        break;

                                    case SqlDbType.Int:
                                        My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToInt32(parameterList.Split('|')[i]);
                                        break;

                                    case SqlDbType.VarChar:
                                        My_SQLDataAdapter.SelectCommand.Parameters[j].Value = parameterList.Split('|')[i];
                                        break;

                                    case SqlDbType.Decimal:
                                        My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToDecimal(parameterList.Split('|')[i]);
                                        break;

                                    case SqlDbType.NVarChar:
                                        My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
                                        break;

                                    case SqlDbType.TinyInt:
                                        My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToInt32(parameterList.Split('|')[i]);
                                        break;
                                                                            
                                    case SqlDbType.SmallInt:
                                        My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToInt32(parameterList.Split('|')[i]);
                                        break;

                                    case SqlDbType.Char:
                                        My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
                                        break;

                                    case SqlDbType.Date:
                                        if ((parameterList.Split('|')[i]) != null || (parameterList.Split('|')[i]) != "")
                                            My_SQLDataAdapter.SelectCommand.Parameters[j].Value = DateTime.ParseExact(parameterList.Split('|')[i], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                                        else
                                            My_SQLDataAdapter.SelectCommand.Parameters[j].Value = DBNull.Value;
                                        break;

                                    case SqlDbType.Xml:
                                        My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            i--;
                            //j--;
                        }
                    }
                }
                My_SQLDataAdapter.Fill(MyDataTable);
                return MyDataTable;
            }

            catch (Exception ex)
            {
                throw ex;
                // Error objError = new Error();
                //  objError.ErrorLog("ConnectionKYC/ReturnDatatable" , ex);
                return null;
            }
            finally
            {
                My_SQLDataAdapter.SelectCommand.Connection.Close();
            }

        }

        //public DataTable ReturnDataTableAV(string procedure, string parameterList)
        //{

        //    DataTable MyDataTable = new DataTable("Buffer");
        //    SqlDataAdapter My_SQLDataAdapter = new SqlDataAdapter();
        //    My_SQLDataAdapter.SelectCommand = SetCommandObjectPropertyAdharVault(CommandType.StoredProcedure);
        //    My_SQLDataAdapter.SelectCommand.CommandText = procedure;
        //    SqlCommandBuilder.DeriveParameters(My_SQLDataAdapter.SelectCommand);
        //    try
        //    {
        //        if (parameterList != "")
        //        {
        //            for (int i = 0, j = 0; i < parameterList.Split('|').Length; i++, j++)
        //            {
        //                if (My_SQLDataAdapter.SelectCommand.Parameters[j].Direction == ParameterDirection.Input)
        //                {
        //                    if (parameterList.Split('|')[i] == "" || parameterList.Split('|')[i] == null)
        //                    {
        //                        My_SQLDataAdapter.SelectCommand.Parameters[j].Value = DBNull.Value;
        //                    }
        //                    else
        //                    {
        //                        switch (My_SQLDataAdapter.SelectCommand.Parameters[j].SqlDbType)
        //                        {
        //                            case SqlDbType.Bit:
        //                                My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToBoolean(parameterList.Split('|')[i]);
        //                                break;

        //                            case SqlDbType.Int:
        //                                My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToInt32(parameterList.Split('|')[i]);
        //                                break;

        //                            case SqlDbType.VarChar:
        //                                My_SQLDataAdapter.SelectCommand.Parameters[j].Value = parameterList.Split('|')[i];
        //                                break;

        //                            case SqlDbType.Decimal:
        //                                My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToDecimal(parameterList.Split('|')[i]);
        //                                break;

        //                            case SqlDbType.NVarChar:
        //                                My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
        //                                break;

        //                            case SqlDbType.TinyInt:
        //                                My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
        //                                break;

        //                            case SqlDbType.SmallInt:
        //                                My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
        //                                break;

        //                            case SqlDbType.Char:
        //                                My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToChar(parameterList.Split('|')[i]);
        //                                break;

        //                            case SqlDbType.Date:
        //                                if ((parameterList.Split('|')[i]) != null || (parameterList.Split('|')[i]) != "")
        //                                    My_SQLDataAdapter.SelectCommand.Parameters[j].Value = DateTime.ParseExact(parameterList.Split('|')[i], "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
        //                                else
        //                                    My_SQLDataAdapter.SelectCommand.Parameters[j].Value = DBNull.Value;
        //                                break;

        //                            case SqlDbType.Xml:
        //                                My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
        //                                break;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    i--;
        //                    //j--;
        //                }
        //            }
        //        }
        //        My_SQLDataAdapter.Fill(MyDataTable);
        //        return MyDataTable;
        //    }

        //    catch (Exception ex)
        //    {
        //        clsError objError = new clsError();
        //        objError.ErrorLog("ConnectionKYC/ReturnDatatable", ex);
        //        return null;
        //    }
        //    finally
        //    {
        //        My_SQLDataAdapter.SelectCommand.Connection.Close();
        //    }

        //}

        public DataSet RetrurnDataset(string procedure, string parameterList)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter My_SQLDataAdapter = new SqlDataAdapter();
            My_SQLDataAdapter.SelectCommand = SetCommandObjectProperty(CommandType.StoredProcedure);
            My_SQLDataAdapter.SelectCommand.CommandText = procedure;
            SqlCommandBuilder.DeriveParameters(My_SQLDataAdapter.SelectCommand);
            try
            {
                for (int i = 0, j = 0; i < parameterList.Split('|').Length; i++, j++)
                {
                    if (My_SQLDataAdapter.SelectCommand.Parameters[j].Direction == ParameterDirection.Input)
                    {
                        if (parameterList.Split('|')[i] == "" || parameterList.Split('|')[i] == null)
                        {
                            My_SQLDataAdapter.SelectCommand.Parameters[j].Value = DBNull.Value;
                        }
                        else
                        {
                            switch (My_SQLDataAdapter.SelectCommand.Parameters[j].SqlDbType)
                            {
                                case SqlDbType.Bit:
                                    My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToBoolean(parameterList.Split('|')[i]);
                                    break;

                                case SqlDbType.Int:
                                    My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToInt32(parameterList.Split('|')[i]);
                                    break;

                                case SqlDbType.VarChar:
                                    My_SQLDataAdapter.SelectCommand.Parameters[j].Value = parameterList.Split('|')[i];
                                    break;

                                case SqlDbType.Decimal:
                                    My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToDecimal(parameterList.Split('|')[i]);
                                    break;

                                case SqlDbType.NVarChar:
                                    My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
                                    break;

                                case SqlDbType.TinyInt:
                                    My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
                                    break;

                                case SqlDbType.SmallInt:
                                    My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
                                    break;

                                case SqlDbType.Char:
                                    My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToChar(parameterList.Split('|')[i]);
                                    break;

                                case SqlDbType.Date:
                                    if ((parameterList.Split('|')[i]) != null || (parameterList.Split('|')[i]) != "")
                                        My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToDateTime(parameterList.Split('|')[i]);
                                    else
                                        My_SQLDataAdapter.SelectCommand.Parameters[j].Value = DBNull.Value;
                                    break;

                                case SqlDbType.Xml:
                                    My_SQLDataAdapter.SelectCommand.Parameters[j].Value = Convert.ToString(parameterList.Split('|')[i]);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        i--;
                    }

                }
                My_SQLDataAdapter.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                My_SQLDataAdapter.SelectCommand.Connection.Close();
            }
        }

        public DataTable CreateDataTable(string mst)
        {
            DataTable table = new DataTable();
            try
            {
                table.Columns.Add("ID", typeof(string));
                table.Columns.Add("Name", typeof(string));
                if (!string.IsNullOrEmpty(mst))
                {
                    for (int i = 0; i < mst.Split(',').Length; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToString(mst.Split(',')[i].Split('|')[0]), Convert.ToString(mst.Split(',')[i].Split('|')[1]) });
                    }
                }
            }
            catch (Exception ex)
            {
                // objGInsurance.ErrorLog("App_Code/Common/CreateDataTable", ex);
            }
            return table;
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
    }
}
