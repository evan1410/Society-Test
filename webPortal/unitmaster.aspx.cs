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
    public partial class unitmaster : System.Web.UI.Page
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
        public static string BindAccountGroup()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "ACGROUP", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Account Group</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindBldgNo(string societycode)
        {
            DataTable dtDropDown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropDown = new DataTable();
            string[] strDropDown = new string[] { "BUILDING", "BLANK", societycode.ToString() };
            dtDropDown = objTrn.Transaction(strDropDown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));
            if (dtDropDown != null)
            {
                strbld.Append("<option value =\"0\">Select Building No.</option>");
                foreach (DataRow dr in dtDropDown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindFloorNo(string societycode, string bldgno)
        {
            DataTable dtDropDown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            dtDropDown = new DataTable();
            string[] strDropDown = new string[] { "FLOOR", "BLANK", societycode.ToString(), bldgno.ToString() };
            dtDropDown = objTrn.Transaction(strDropDown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));
            if (dtDropDown != null)
            {
                strbld.Append("<option value =\"0\">Select Floor No </option>");
                foreach (DataRow dr in dtDropDown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindUnitType(string floorno)
        {
            DataTable dtDropDown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            dtDropDown = new DataTable();
            string[] strDropDown = new string[] { "UNITTYPE", "BLANK", floorno.ToString() };
            dtDropDown = objTrn.Transaction(strDropDown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));
            if (dtDropDown != null)
            {
                strbld.Append("<option value =\"0\">Select Unit Type </option>");
                foreach (DataRow dr in dtDropDown.Rows)
                {
                    strbld.Append("<option value=\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindOccupiedBy(string unittype)
        {
            DataTable dtDropDown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            dtDropDown = new DataTable();
            string[] strDropDown = new string[] { "OCCUPIEDBY", "BLANK", unittype.ToString() };
            dtDropDown = objTrn.Transaction(strDropDown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));
            if (dtDropDown != null)
            {
                strbld.Append("<option value=\"0\">Select Owner type</option>");
                foreach (DataRow dr in dtDropDown.Rows)
                {
                    strbld.Append("<option value=\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
            }
            return strbld.ToString();
        }


        [WebMethod]
        public static string BindCountry()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "COUNTRY", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select Country</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindState(string countryid)
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "STATE", "BLANK", countryid.ToString() };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select State</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string BindCity(string stateid)
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "CITY", "BLANK", stateid.ToString() };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            if (dtDropdown != null)
            {
                //strbld.Append("<select id =\"cmbCountry\" class=\"form-control\" required=\"required\">");
                strbld.Append("<option value =\"0\">Select City</option>");
                foreach (DataRow dr in dtDropdown.Rows)
                {
                    strbld.Append("<option value =\"" + dr["valueid"].ToString() + "\">" + dr["valuedec"].ToString() + "</option>");
                }
                //strbld.Append("</select>");                
            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string LoadUnit(string UnitId)
        {
            DataTable dtListing;
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();

            dtListing = new DataTable();
            string[] strSelect = new string[] { UnitId.ToString() };
            dtListing = objTrn.Transaction(strSelect, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_UnitMaster));

            if (UnitId == "0")
            {
                if (dtListing != null)
                {
                    //strbld.Append("<table class=\"table table-bordered\" id=\"listing\" width=\"100%\" cellspacing=\"0\">");
                    strbld.Append("<thead>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">unitid</th>");
                    strbld.Append("<th>bldgno</th>");
                    strbld.Append("<th>floorno</th>");
                    strbld.Append("<th>unitno</th>");
                    strbld.Append("<th>unittype</th>");
                    strbld.Append("<th>unitarea</th>");
                    strbld.Append("<th>unitowner</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</thead>");
                    strbld.Append("<tfoot>");
                    strbld.Append("<tr>");
                    strbld.Append("<th class=\"hide\">unitid</th>");
                    strbld.Append("<th>bldgno</th>");
                    strbld.Append("<th>floorno</th>");
                    strbld.Append("<th>unitno</th>");
                    strbld.Append("<th>unittype</th>");
                    strbld.Append("<th>unitarea</th>");
                    strbld.Append("<th>unitowner</th>");
                    strbld.Append("<th>Action</th>");
                    strbld.Append("</tr>");
                    strbld.Append("</tfoot>");
                    strbld.Append("<tbody>");
                    foreach (DataRow dr in dtListing.Rows)
                    {
                        strbld.Append("<tr>");
                        strbld.Append("<td class=\"hide\">" + dr["unitid"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["bldgno"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["floorno"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["unitno"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["unittype"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["unitarea"].ToString() + "</td>");
                        strbld.Append("<td>" + dr["unitowner"].ToString() + "</td>");
                        strbld.Append("<td class=\"text-center\"><i class=\"fa fa-eye\" aria-hidden=\"true\" title=\"View\" onclick=\"LoadUnit(" + dr["unitid"].ToString() + ")\">&nbsp&nbsp</i><i class=\"fa fa-trash\" title=\"Delete\" aria-hidden=\"true\" onclick=\"DeleteRecord(" + dr["unitid"].ToString() + ")\"></i></td>");
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
                        strbld.Append(dr["unitid"].ToString() + "|");
                        strbld.Append(dr["societycode"].ToString() + "|");
                        strbld.Append(dr["bldgno"].ToString() + "|");
                        strbld.Append(dr["floorno"].ToString() + "|");
                        strbld.Append(dr["unitno"].ToString() + "|");
                        strbld.Append(dr["unittype"].ToString() + "|");
                        strbld.Append(dr["unitarea"].ToString() + "|");
                        strbld.Append(dr["occupiedby"].ToString() + "|");
                        strbld.Append(dr["acgrpcode"].ToString() + "|");
                        strbld.Append(dr["ledgercode"].ToString() + "|");
                        strbld.Append(dr["unitowner"].ToString() + "|");
                        strbld.Append(dr["address"].ToString() + "|");
                        strbld.Append(dr["location"].ToString() + "|");
                        strbld.Append(dr["city"].ToString() + "|");
                        strbld.Append(dr["state"].ToString() + "|");
                        strbld.Append(dr["country"].ToString() + "|");
                        strbld.Append(dr["pincode"].ToString() + "|");
                        strbld.Append(dr["contact1"].ToString() + "|");
                        strbld.Append(dr["contact2"].ToString() + "|");
                        strbld.Append(dr["emailid"].ToString() + "|");
                        strbld.Append(dr["panno"].ToString());
                    }
                }

            }
            return strbld.ToString();
        }

        [WebMethod]
        public static string SaveUnit(string unitid, string societycode, string bldgno, string floorno, string unitno,
                                         string unittype, string unitarea, string occupiedby, string acgrpcode, string ledgercode, string unitowner, string address,
                                         string location, string city, string state, string country, string pincode, string contact1,
                                         string contact2, string emailid, string panno)
        {
            DataTable dtUnitMaster = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;
            if (unitid == "0")
            {
                string[] strInsert = new string[] {unitid.ToString()
                                                    ,societycode.ToString()
                                                    ,bldgno.ToString()
                                                    ,floorno.ToString()
                                                    ,unitno.ToString()
                                                    ,unittype.ToString()
                                                    ,unitarea.ToString()
                                                    ,occupiedby.ToString()
                                                    ,acgrpcode.ToString()
                                                    ,ledgercode.ToString()
                                                    ,unitowner.ToString()
                                                    ,address.ToString()
                                                    ,location.ToString()
                                                    ,city.ToString()
                                                    ,state.ToString()
                                                    ,country.ToString()
                                                    ,pincode.ToString()
                                                    ,contact1.ToString()
                                                    ,contact2.ToString()
                                                    ,emailid.ToString()
                                                    ,panno.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};
                dtUnitMaster = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_UnitMaster));

                strBld = dtUnitMaster.Rows[0]["i_IDENTITY"].ToString() + '|' + dtUnitMaster.Rows[0]["msg"].ToString();
            }
            else
            {
                string[] strUpdate = new string[] { unitid.ToString()
                                                    ,societycode.ToString()
                                                    ,bldgno.ToString()
                                                    ,floorno.ToString()
                                                    ,unitno.ToString()
                                                    ,unittype.ToString()
                                                    ,unitarea.ToString()
                                                    ,occupiedby.ToString()
                                                    ,acgrpcode.ToString()
                                                    ,ledgercode.ToString()
                                                    ,unitowner.ToString()
                                                    ,address.ToString()
                                                    ,location.ToString()
                                                    ,city.ToString()
                                                    ,state.ToString()
                                                    ,country.ToString()
                                                    ,pincode.ToString()
                                                    ,contact1.ToString()
                                                    ,contact2.ToString()
                                                    ,emailid.ToString()
                                                    ,panno.ToString()
                                                    ,""//HttpContext.Current.Session["userid"].ToString()
                                                    ,"1"
                                                    ,(clsEnumRequestType.UPDATE).ToString()};


                dtUnitMaster = objTrn.Transaction(strUpdate, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_UnitMaster));

                strBld = dtUnitMaster.Rows[0]["i_IDENTITY"].ToString() + '|' + dtUnitMaster.Rows[0]["msg"].ToString();
            }

            return strBld.ToString();
        }

        [WebMethod]
        public static string DeleteUnit(string unitid)
        {
            DataTable dtUnitMaster = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            StringBuilder strbld = new StringBuilder();
            string strBld = string.Empty;

            string[] strDelete = new string[] { unitid.ToString()
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""
                                                ,""//HttpContext.Current.Session["userid"].ToString()
                                                ,"1"
                                                ,(clsEnumRequestType.DELETE).ToString()};
            dtUnitMaster = objTrn.Transaction(strDelete, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_UnitMaster));
            strBld = dtUnitMaster.Rows[0]["i_IDENTITY"].ToString() + '|' + dtUnitMaster.Rows[0]["msg"].ToString();
            return strBld.ToString();
        }
    }
}
