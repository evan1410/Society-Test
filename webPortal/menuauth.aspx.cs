using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Net.Mail;
using BALPortal;
using DALPortal;

namespace webPortal
{
    public partial class menuauth : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserGroup();
                LoadMenuCheckList("0");
            }
        }

        private void LoadUserGroup()
        {
            DataTable dtDropdown;
            clsTransaction objTrn = new clsTransaction();
            
            dtDropdown = new DataTable();
            string[] strDropdown = new string[] { "USERGROUPBYID", "BLANK" };
            dtDropdown = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Bind_DropDown));

            cmbUserRole.DataSource = dtDropdown;
            cmbUserRole.DataValueField = "valueid";
            cmbUserRole.DataTextField = "valuedec";            
            cmbUserRole.DataBind();
            cmbUserRole.Items.Insert(0, new ListItem("Select User Role", "0"));
        }

        private void LoadMenuCheckList(string menuid)
        {
            DataTable dtSelect = new DataTable(); ;
            clsTransaction objTrn = new clsTransaction();

            string[] strDropdown = new string[] { menuid.ToString() };
            dtSelect = objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.usp_Select_Menu));

            if (dtSelect.Rows.Count > 0)
            {
                DataView dvRecordList = dtSelect.DefaultView;
                dvRecordList.RowFilter = "parentmenuid = 0";

                lstMenu.Nodes.Clear();
                foreach (DataRowView masterRow in dvRecordList)
                {
                    TreeNode masterNode = new TreeNode((string)masterRow["menuname"], Convert.ToString(masterRow["menuid"]));

                    lstMenu.Nodes.Add(masterNode);

                    lstMenu.CollapseAll();

                    DataView dvSubmenu = dtSelect.DefaultView;
                    dvSubmenu.RowFilter = "parentmenuid = " + masterRow["menuid"].ToString();
                    foreach (DataRowView childRow in dvSubmenu)
                    {
                        TreeNode childNode = new TreeNode((string)childRow["menuname"],Convert.ToString(childRow["menuid"]));
                        masterNode.ChildNodes.Add(childNode);
                        childNode.Value = Convert.ToString(childRow["menuid"]);
                    }
                }                    
            }                
        }

        void LookupChecks(TreeNodeCollection nodes, List<TreeNode> list)
        {
            try
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Checked)
                        list.Add(node);

                    LookupChecks(node.ChildNodes, list);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //objCommon.ExceptionLog(GlobalVar.errorlog, ex.Message.ToString(), ex.StackTrace.ToString(), ex.Source.ToString(), DBNull.Value.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtUser = new DataTable();
            clsTransaction objTrn = new clsTransaction();
            string strBld = string.Empty;

            int iUserGroup = Convert.ToInt32(cmbUserRole.SelectedValue);

            string lLstItem = string.Empty;
            string lResultItem = string.Empty;
            var list = new List<TreeNode>();

            LookupChecks(lstMenu.Nodes, list);

            lLstItem = list.ToString();
            int count = (list.Count) - 1;
            for (int i = 0; i <= count; i++)
            {
                lLstItem = list[i].Value.ToString();

                if (lResultItem != "")
                    lResultItem = lResultItem + "," + lLstItem;
                else if (lResultItem == "")
                    lResultItem = lLstItem;
            }

            if (iUserGroup != 0)
            {
                string[] strInsert = new string[] {iUserGroup.ToString()
                                                    , lResultItem.ToString()
                                                    ,"1"//HttpContext.Current.Session["userid"].ToString()
                                                    ,""
                                                    ,(clsEnumRequestType.INSERT).ToString()};

                dtUser = objTrn.Transaction(strInsert, clsConnection.GetEnumDescription(clsEnumSP.usp_DML_MenuAuthorization));

                lblMessage.Text = dtUser.Rows[0]["msg"].ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            cmbUserRole.SelectedIndex = 0;
            //lstMenu.CheckedNodes.Clear();
            foreach (TreeNode node in lstMenu.Nodes)
            {
                node.Checked = false;
                foreach (TreeNode item1 in node.ChildNodes)
                {
                    item1.Checked = false;

                    //foreach (TreeNode item2 in item1.ChildNodes)
                    //{
                    //    item2.Checked = false;
                    //}
                }
            }
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                clsTransaction objTrn = new clsTransaction();
                //if (objCommon.CheckBlankComboBox(cmbGroup, GlobalVar.cUserGroupMsg, this.Text) == false)
                //{
                //    return;
                //}

                LoadMenuCheckList("0");
                DataTable dtMenuAuthOld = new DataTable();
                string[] strDropdown = new string[] { cmbUserRole.SelectedValue.ToString() };
                dtMenuAuthOld =  objTrn.Transaction(strDropdown, clsConnection.GetEnumDescription(clsEnumSP.SelectMenuAuth));
                if (dtMenuAuthOld != null)
                {
                    foreach (DataRow dr in dtMenuAuthOld.Rows)
                    {
                        GetNodeByName(lstMenu.Nodes, dr["menuid"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //objCommon.ExceptionLog(GlobalVar.errorlog, ex.Message.ToString(), ex.StackTrace.ToString(), ex.Source.ToString(), DBNull.Value.ToString());
            }
        }

        private TreeNode GetNodeByName(TreeNodeCollection nodes, string searchtext)
        {
            try
            {
                TreeNode n_found_node = null;
                bool b_node_found = false;

                foreach (TreeNode node in nodes)
                {

                    if (node.Value == searchtext)
                    {
                        b_node_found = true;
                        n_found_node = node;
                        n_found_node.Checked = true;
                        //return n_found_node;
                    }

                    if (!b_node_found)
                    {
                        n_found_node = GetNodeByName(node.ChildNodes, searchtext);

                        if (n_found_node != null)
                        {
                            n_found_node.Checked = false;
                            //return n_found_node;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
                //objCommon.ExceptionLog(GlobalVar.errorlog, ex.Message.ToString(), ex.StackTrace.ToString(), ex.Source.ToString(), DBNull.Value.ToString());
                return null;
            }
        }
    }
}