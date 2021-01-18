<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="societymaster.aspx.cs" Inherits="webPortal.societymaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <script src="appscript/societymaster.js"></script>
    <script src="appscript/commfun.js"></script>
    <div class="container-fluid">
        <h1 class="h3 mb-4 text-gray-800">Society Master</h1>
        <div class="card shadow mb-12">
            <div class="card-body" id="listing">
                <a class="btn btn-primary btn-icon-split" onclick="AddList()" style="margin-bottom: 10px;">
                    <span class="icon text-white-50">
                        <i class="fas fa-plus"></i>
                    </span>
                    <span class="text">Add Society</span>
                </a>
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid hide" id="entryform">
        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="p-5">
                            <form class="user">
                                <div class="form-group row">
                                    <h4 class="col-sm-12">Society's Information</h4>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Society Code *</label>
                                        <input type="text" class="form-control " id="txtSocietyCode" placeholder="Society Code">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Society Name *</label>
                                        <input type="text" class="form-control " id="txtSocietyName" placeholder="Society Name">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Society Type *</label>
                                        <select id="cmbSocietyType" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Buildings *</label>
                                        <input type="text" class="form-control numberOnly" id="txtTotalBldg" placeholder="Total no. of Buildings">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Pan No *</label>
                                        <input type="text" class="form-control " id="txtPanNo" placeholder="Society's Pan No.">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Registration No *</label>
                                        <input type="text" class="form-control " id="txtRegNo" placeholder="Society's Registration No.">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Registration Date *</label>
                                        <input type="text" class="form-control simple_date" id="txtRegDate" placeholder="DD/MM/YYYY">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <h4 class="col-sm-12">Address Information</h4>                                    
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-6">
                                        <label class="col-form-label">Address *</label>
                                        <input type="text" class="form-control " id="txtAddress" placeholder="Society's Address">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Location *</label>
                                        <input type="text" class="form-control alphaOnly" id="txtLocation" placeholder="Location">
                                    </div>

                                    <div class="col-sm-3">
                                        <label class="col-form-label">Country *</label>
                                        <select id="cmbCountry" onchange="BindState()" class="form-control"></select>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3">
                                        <label class="col-form-label">State *</label>
                                        <select id="cmbState" onchange="BindCity()" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">City *</label>
                                        <select id="cmbCity" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Pin Code *</label>
                                        <input type="text" class="form-control numberOnly" id="txtPinCode" placeholder="Pin code">
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <h4 class="col-sm-12">Contact Person's Information</h4>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Person's Name *</label>
                                        <input type="text" class="form-control alphaOnly" id="txtContactPerson" placeholder="Name of Contact Person">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Contact 1 *</label>
                                        <input type="text" class="form-control numberOnly" id="txtContact1" placeholder="Contact 1" maxlength="10">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Contact 2</label>
                                        <input type="text" class="form-control numberOnly" id="txtContact2" placeholder="Contact 2" maxlength="10">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Email Id</label>
                                        <input type="text" class="form-control " id="txtMailId" placeholder="Eg:- john@gmail.com">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6">
                                        <input type="hidden" class="form-control " id="hdnSocietyId">
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <a class="btn btn-primary btn-user btn-block" onclick="SaveSociety()">Save</a>
                                    </div>
                                    <div class="col-sm-3">
                                        <a class="btn btn-primary btn-user btn-block" onclick="ResetControls(),LoadSociety(0),ShowList()">Cancel</a>
                                    </div>
                                </div>
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
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>
</asp:Content>
