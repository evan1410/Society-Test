<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="recordlist.aspx.cs" Inherits="webPortal.recordlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">

          <!-- Page Heading -->
          <h1 class="h3 mb-4 text-gray-800">Manpower Cost Element</h1>
          <%--<p class="mb-4">DataTables is a third party plugin that is used to generate the demo table below. For more information about DataTables, please visit the <a target="_blank" href="https://datatables.net">official DataTables documentation</a>.</p>--%>

          <!-- DataTales Example -->
          <div class="card shadow mb-12" >
            
            <div class="card-body" id="listing">
                 <a class="btn btn-primary btn-icon-split" onclick="AddList()" style="margin-bottom:10px;">
                    <span class="icon text-white-50">
                      <i class="fas fa-plus"></i>
                    </span>
                    <span class="text">Add New</span>
                  </a>
              <div class="table-responsive">
                <form runat="server" class="manpower">
                <asp:GridView ID="gvRecordList" runat="server" PageIndex="20" AllowPaging="True" CssClass="table table-bordered" >
                    <Columns>
                        <asp:ButtonField CommandName="Edit" HeaderText="Edit" ShowHeader="True" Text="Edit" />
                        <asp:ButtonField CommandName="Delete" HeaderText="Delete" ShowHeader="True" Text="Delete" />
                    </Columns>
                    </asp:GridView>
                
                </form>
                <%--<table class="table table-bordered" id="dataTable" width="100%" cellspacing="0"> 
                    
                </table>--%>
              </div>
            </div>
          </div>

        </div>
        <!-- /.container-fluid -->
</asp:Content>
