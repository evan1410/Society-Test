<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="menuauth.aspx.cs" EnableEventValidation="false"  Inherits="webPortal.menuauth" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid" id="entryform">
        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
            <!-- Nested Row within Card Body -->
            <div class="row">
              <%--<div class="col-lg-5 d-none d-lg-block bg-register-image"></div>--%>
              <div class="col-lg-12">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Menu Authorization</h1>
                  </div>
                  <form runat="server" class="user">
                    <div class="form-group row" id="frmMessage">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                         <%--<label id="lblMessage" class="col-form-label"></label>--%>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <label>User Role</label>
                            <asp:dropdownlist runat="server" cssclass="form-control" id="cmbUserRole"></asp:dropdownlist>
                        </div>
                        <div class="col-sm-3">
                            <asp:button runat="server" id="btnDisplay" text="Display" OnClick="btnDisplay_Click" style="margin-top: 25px;" cssclass="btn btn-primary btn-user btn-block" />
                            <%--<a class="btn btn-primary btn-user btn-block" onclick="ResetControls(),ShowList()">Cancel</a>--%>
                        </div>
                        <div class="col-sm-3">
                            <%--<asp:button runat="server" id="btnCancel" text="Cancel" OnClick="btnCancel_Click" cssclass="btn btn-primary btn-user btn-block" />--%>
                            <%--<input type="hidden" class="form-control form-control-user" id="hdnGroupID">--%>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label style="margin-left: 20px;font-family: inherit;">Menu</label>
                        <asp:treeview runat="server" id="lstMenu" ShowCheckBoxes="All" style="margin-left: 20px;font-family: inherit;">                            
                        </asp:treeview>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:button runat="server" id="Button1" text="Save" OnClick="btnSave_Click" cssclass="btn btn-primary btn-user btn-block" />
                            <%--<a class="btn btn-primary btn-user btn-block" onclick="ResetControls(),ShowList()">Cancel</a>--%>
                        </div>
                        <div class="col-sm-3">
                            <asp:button runat="server" id="Button2" text="Cancel" OnClick="btnCancel_Click" cssclass="btn btn-primary btn-user btn-block" />
                        </div>
                        <div class="col-sm-3">
                            
                        </div>
                    </div>

                   
                    
                  </form>                  
                </div>
              </div>
            </div>
          </div>
        </div>
    </div>
</asp:Content>
