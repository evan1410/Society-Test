<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="webPortal.user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Custom styles for this page -->
  <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    
    <%--<script src="vendor/jquery/jquery.js"></script>--%>
    <script src="appscript/user.js"></script>
    <script src="appscript/commfun.js"></script>
    
    
    
    <div class="container-fluid">

          <!-- Page Heading -->
          <h1 class="h3 mb-4 text-gray-800">User</h1>
          <%--<p class="mb-4">DataTables is a third party plugin that is used to generate the demo table below. For more information about DataTables, please visit the <a target="_blank" href="https://datatables.net">official DataTables documentation</a>.</p>--%>

          <!-- DataTales Example -->
          <div class="card shadow mb-12" >
            
            <div class="card-body" id="listing">
                <a class="btn btn-primary btn-icon-split" onclick="AddList()" style="margin-bottom:10px;">
                    <span class="icon text-white-50">
                      <i class="fas fa-plus"></i>
                    </span>
                    <span class="text">Add User</span>
                  </a>
              <div class="table-responsive">
                   
                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">                  
                </table>
              </div>
            </div>
          </div>

        </div>
        <!-- /.container-fluid -->

    <div class="container-fluid hide" id="entryform">
        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
            <!-- Nested Row within Card Body -->
            <div class="row">
              <%--<div class="col-lg-5 d-none d-lg-block bg-register-image"></div>--%>
              <div class="col-lg-12">
                <div class="p-5">
                  <%--<div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">User</h1>
                  </div>--%>
                  <form class="user">
                    <%--<div class="form-group row hide" id="frmMessage">
                         <label id="lblMessage" class="col-form-label"></label>
                    </div>--%>
                    <div class="form-group row">
                      <div class="col-sm-3 mb-3 mb-sm-0">
                          <label class="col-form-label">Ueer Group</label>
                        <select id="cmbGroup" class="form-control"></select>
                      </div>
                      <div class="col-sm-3">
                          <label class="col-form-label">First Name</label>
                        <input type="text" class="form-control form-control-user" id="txtFirstName" placeholder="First Name" maxlength="30">
                      </div>
                      <div class="col-sm-3">
                          <label class="col-form-label">Last Name</label>
                        <input type="text" class="form-control form-control-user" id="txtLastName" placeholder="Last Name" maxlength="30">
                      </div>
                      <div class="col-sm-3">
                          <label class="col-form-label">Staff Type</label>
                        <select id="cmbStaffType" class="form-control"></select>
                      </div>                      
                    </div>
                    <div class="form-group row">
                      <div class="col-sm-3 mb-3 mb-sm-0">
                          <label class="col-form-label">Designation</label>
                        <select id="cmbDesignation" class="form-control"></select>
                      </div>
                      <div class="col-sm-3">
                          <label class="col-form-label">Mobile</label>
                        <input type="text" class="form-control form-control-user" id="txtMobile" placeholder="Mobile" maxlength="10">
                      </div>
                      <div class="col-sm-3">
                          <label class="col-form-label">Email ID</label>
                        <input type="text" class="form-control form-control-user" id="txtEmail" placeholder="Email" maxlength="80">
                      </div>
                      <div class="col-sm-3">
                          <label class="col-form-label">Password</label>
                        <input type="password" class="form-control form-control-user" id="txtPassword" placeholder="Password" maxlength="10">
                      </div>                      
                    </div>
                    <div class="form-group row">
                      <div class="col-sm-3 mb-3 mb-sm-0">
                          <label class="col-form-label">Confirm Password</label>
                        <input type="password" class="form-control form-control-user" id="txtConPassword" placeholder="Confirm Pasword" maxlength="10">
                      </div>
                      <div class="col-sm-3">
                        <input type="hidden" class="form-control form-control-user" id="hdnUserID">
                      </div>
                      <div class="col-sm-3">
                        
                      </div>
                      <div class="col-sm-3">
                        
                      </div>                      
                    </div>

                    <div class="form-group row">
                      <div class="col-sm-3 mb-3 mb-sm-0">
                        <a  class="btn btn-primary btn-user btn-block" onclick="SaveUser()">Save</a>
                      </div>
                      <div class="col-sm-3">
                        <a class="btn btn-primary btn-user btn-block" onclick="ResetControls(),LoadUser(0),ShowList()">Cancel</a>
                      </div>
                      <div class="col-sm-9">
                        <input type="hidden" class="form-control form-control-user" id="hdnGroupID">
                      </div>
                    </div>
                    
                      <!-- Logout Modal-->
                    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Information</h5>
                            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                            </button>
                        </div>
                        <div class="modal-body" id="lblMessage"></div>
                        <div class="modal-footer">
                            <button class="btn btn-secondary" type="button" data-dismiss="modal">Ok</button>
                            <%--<a class="btn btn-primary" onclick="logout()">Logout</a>--%>
                        </div>
                        </div>
                    </div>
                    </div>

                  </form>                  
                </div>
              </div>
            </div>
          </div>
        </div>
    </div>

    <!-- Page level plugins -->
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>

    <!-- Page level custom scripts -->
    <%--<script src="js/demo/datatables-demo.js"></script>--%>
</asp:Content>
