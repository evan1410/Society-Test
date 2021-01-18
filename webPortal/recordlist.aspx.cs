using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BALPortal;
using DALPortal;

namespace webPortal
{
    public partial class recordlist : System.Web.UI.Page
    {
        DataTable dtRecordList = new DataTable();
        clsCommonFunction objCommon = new clsCommonFunction();
        clsTransaction objTran = new clsTransaction();

        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadRecordList();
        }

        private void LoadRecordList(string sRecordName)
        {
            string sFrmName = string.Empty;
            string iRecordID = "0";
            string[] strSelect = new string[] { iRecordID.ToString() };

            switch (sRecordName)
            {
                case "Cost Head":
                    dtRecordList = objTran.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_CostHead));
                    gvRecordList.DataSource = dtRecordList;
                    break;
                case "Manpower Cost Element":
                    dtRecordList = objTran.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_CostElementManpower));
                    gvRecordList.DataSource = dtRecordList;
                    break;
                case "Non Manpower Cost Element":
                    dtRecordList = objTran.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_CostElementNonManpower));
                    gvRecordList.DataSource = dtRecordList;
                    break;
                case "Vendor":
                    dtRecordList = objTran.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_Vendor));
                    gvRecordList.DataSource = dtRecordList;
                    break;
                case "Market Rate":
                    dtRecordList = objTran.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_MarketRate));
                    gvRecordList.DataSource = dtRecordList;
                    break;
                case "Union Labour Rate":
                    dtRecordList = objTran.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_UnionRate));
                    gvRecordList.DataSource = dtRecordList;
                    break;
                case "Client":
                    dtRecordList = objTran.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_Client));
                    gvRecordList.DataSource = dtRecordList;
                    break;
                case "Production House":
                    dtRecordList = objTran.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_ProductionHouse));
                    gvRecordList.DataSource = dtRecordList;
                    break;
                case "User Role":
                    dtRecordList = objTran.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_UserGroup));
                    gvRecordList.DataSource = dtRecordList;
                    break;
                case "User":
                    dtRecordList = objTran.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_User));
                    gvRecordList.DataSource = dtRecordList;
                    break;
                default:
                    gvRecordList.DataSource = null;
                    break;
            }
        }
    }
}