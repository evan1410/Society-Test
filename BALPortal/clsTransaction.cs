using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DALPortal;

namespace BALPortal
{
    public class clsTransaction
    {
        clsConnection Conn = new clsConnection();

        public DataTable Transaction(string[] pparamval, string pprocname)
        {
            try
            {
                string parameterValue = string.Empty;
                for (int i = 0; i < pparamval.Length; i++)
                {
                    if (i == 0) { parameterValue = pparamval[i].ToString(); }
                    else { parameterValue = parameterValue + "|" + pparamval[i].ToString(); }
                }

                DataTable dtRet = Conn.ReturnDataTable(pprocname, parameterValue);
                return dtRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetFilenametoDownload(string filename)
        {
            string retfilename = string.Empty;

            if (filename != "")
            {
                switch (filename)
                {
                    case "Client":
                        retfilename = "Client.xlsx";
                        break;
                    case "Cost Head":
                        retfilename = "Cost Head.xlsx";
                        break;
                    case "Manpower Cost Element":
                        retfilename = "Manpower Cost Element.xlsx";
                        break;
                    case "Market Rate":
                        retfilename = "Market Rate.xlsx";
                        break;
                    case "Non Manpower Cost Element":
                        retfilename = "Non Manpower Cost Element.xlsx";
                        break;
                    case "Production House":
                        retfilename = "Production House.xlsx";
                        break;
                    case "Union Labour Rate":
                        retfilename = "Union Labour Rate.xlsx";
                        break;
                    case "Vendor":
                        retfilename = "Vendor.xlsx";
                        break;
                }
            }

            return retfilename;
        }
        public string GetProc(string uploadname)
        {
            string retProc = string.Empty;

            if(uploadname != "")
            {
                switch (uploadname)
                {
                    case "Client":
                        retProc = "usp_UPLD_Client";
                        break;
                    case "Cost Head":
                        retProc = "usp_UPLD_CostHead";
                        break;
                    case "Manpower Cost Element":
                        retProc = "usp_UPLD_CostElementManpower";
                        break;
                    case "Market Rate":
                        retProc = "usp_UPLD_MarketRateMaster";
                        break;
                    case "Non Manpower Cost Element":
                        retProc = "usp_UPLD_CostElementNonManpower";
                        break;
                    case "Production House":
                        retProc = "usp_UPLD_ProductionHouse";
                        break;
                    case "Union Labour Rate":
                        retProc = "usp_UPLD_UnionRateMaster";
                        break;
                    case "Vendor":
                        retProc = "usp_UPLD_Vendor";
                        break;
                    case "Budget":
                        retProc = "usp_UPLD_Budget";
                        break;
                    case "Contract":
                        retProc = "usp_UPLD_Contract";
                        break;
                    case "Contract Items":
                        retProc = "usp_UPLD_ContractItems";
                        break;
                }
            }

            return retProc;
        }
    }
}
