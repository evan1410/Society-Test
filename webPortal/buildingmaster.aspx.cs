using BALPortal;
using DALPortal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webPortal
{
    public partial class buildingmaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string BindSocietyName()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "SOCIETY", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Society Name</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string LoadBuilding(string bldgid)
        {
            DataTable dtListing;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtListing = new DataTable();
            string[] strSelect = new string[] { bldgid.ToString() };
            dtListing = objTrn.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_BuildingMaster));

            if (bldgid == "0")
            {
                if (dtListing != null)
                {
                    //strbld.Append("<table class=\"table table-bordered\" id=\"listing\" width=\"100%\" cellspacing=\"0\">");
                    strbld.Append("<thead>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">bldgid</th>");
                    strbld.Append("<th>societyname</th>");
                    strbld.Append("<th>bldgno</th>");
                    strbld.Append("<th>totalfloor</th>");
                    strbld.Append("<th>totalunit</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</thead>");
                    strbld.Append("<tfoot>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">bldgid</th>");
                    strbld.Append("<th>societyname</th>");
                    strbld.Append("<th>bldgno</th>");
                    strbld.Append("<th>totalfloor</th>");
                    strbld.Append("<th>totalunit</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</tfoot>");
                    strbld.Append("<tbody>");
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append("<tr>");
                        strbld.Append("<td class=\"hide\">" + dr["bldgid"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["societyname"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["bldgno"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["totalfloor"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["totalunit"].ToString() + "</td>");
                        strbld.Append("<td class=\"text-center\"><i class=\"fa fa-eye\" aria-hidden=\"true\" title=\"View\" onclick=\"LoadBuilding(" + dr["bldgid"].ToString() + ")\">&nbsp&nbsp</i><i class=\"fa fa-trash\" title=\"Delete\" aria-hidden=\"true\" onclick=\"DeleteRecord(" + dr["bldgid"].ToString() + ")\"></i></td>");
                        strbld.Append("</tr>");
                    }
                    strbld.Append("</tbody>");
                    //strbld.Append("</table>");
                }
            }
            else
            {
                if (dtListing != null)
                {
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append(dr["bldgid"].ToString() + "|");
                        strbld.Append(dr["societycode"].ToString() + "|");
                        strbld.Append(dr["bldgno"].ToString() + "|");
                        strbld.Append(dr["totalfloor"].ToString() + "|");
                        strbld.Append(dr["totalunit"].ToString());
                    }
                }

            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string SaveBuilding(string bldgid, string societycode, string bldgno, string totalfloor, string totalunit)
        {
            DataTable dtBuildingMaster = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            if (bldgid == "0")
            {
                string[] strInsert = new string[] {bldgid.ToString()
                                                    ,societycode.ToString()
                                                    ,bldgno.ToString()
                                                    ,totalfloor.ToString()
                                                    ,totalunit.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};

                dtBuildingMaster = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_BuildingMaster));

                strBld = dtBuildingMaster.Rows[0]["i_IDENTITY"].ToString() + '|' + dtBuildingMaster.Rows[0]["msg"].ToString();
            }
            else
            {
                string[] strUpdate = new string[] { bldgid.ToString()
                                                    ,societycode.ToString()
                                                    ,bldgno.ToString()
                                                    ,totalfloor.ToString()
                                                    ,totalunit.ToString()
                                                    ,""//HttpContext.Current.Session["userid"].ToString()
                                                    ,"1"
                                                    ,(clsEnumRequestType.UPDATE).ToString()};

                dtBuildingMaster = objTrn.Transaction(strUpdate, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_BuildingMaster));

                strBld = dtBuildingMaster.Rows[0]["i_IDENTITY"].ToString() + '|' + dtBuildingMaster.Rows[0]["msg"].ToString();
            }

            return strBld.ToString();
        }
        [WebMethod]
        public static string DeleteBuilding(string bldgid)
        {
            DataTable dtBuildingMaster = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            string[] strDelete = new string[] { bldgid.ToString()
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""//HttpContext.Current.Session["userid"].ToString()
                                                ,"1"
                                                ,(clsEnumRequestType.DELETE).ToString()};

            dtBuildingMaster = objTrn.Transaction(strDelete, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_BuildingMaster));

            strBld = dtBuildingMaster.Rows[0]["i_IDENTITY"].ToString() + '|' + dtBuildingMaster.Rows[0]["msg"].ToString();


            return strBld.ToString();
        }
    }
}