<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="tenantmaster.aspx.cs" Inherits="webPortal.tenantmaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script src="appscript/tenantmaster.js"></script>
    <script src="appscript/commfun.js"></script>
    <div class="container-fluid">
        <h1 class="h3 mb-4 text-gray-800">Tenant Master</h1>
        <div class="card shadow mb-12">
            <div class="card-body" id="listing">
                <a class="btn btn-primary btn-icon-split" onclick="AddList()" style="margin-bottom: 10px;">
                    <span class="icon text-white-50">
                        <i class="fas fa-plus"></i>
                    </span>
                    <span class="text">Add Tenant</span>
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
                                    <h4 class="col-sm-12">Flat Information</h4>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Society Name *</label>
                                        <select onchange="BindBldgNo()" id="cmbSocietyCode" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Building No *</label>
                                        <select onchange="BindFloorNo()" id="cmbBldgNo" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Floor No *</label>
                                        <select onchange="BindUnitNo()" id="cmbFloorNo" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Unit No *</label>
                                        <select id="cmbUnitNo" class="form-control"></select>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <h4 class="col-sm-12">Tenant Information</h4>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Tenant Type *</label>
                                        <select onchange="GetOwner()" id="cmbTenantType" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Account Group *</label>
                                        <select class="form-control" onchange="BindLedger()" id="cmbAcGrpCode"></select>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Ledger *</label>
                                        <select class="form-control" id="cmbLedgerCode"></select>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6">
                                        <label class="col-form-label">Tenant Name *</label>
                                        <input type="text" class="form-control alphaOnly" id="txtTenantName" placeholder="Tenant Name">
                                    </div>
                                    <div class="col-sm-6">
                                        <label class="col-form-label">Description</label>
                                        <input type="text" class="form-control " id="txtDesc" placeholder="Description" maxlength="200">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6">
                                        <label class="col-form-label">Address *</label>
                                        <input type="text" class="form-control " id="txtAddress" placeholder="Tenant Address" maxlength="100">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Location *</label>
                                        <input type="text" class="form-control alphaOnly" id="txtLocation" placeholder="Location">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Country *</label>
                                        <select onchange="BindState()" id="cmbCountry" class="form-control"></select>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3">
                                        <label class="col-form-label">State *</label>
                                        <select onchange="BindCity()" id="cmbState" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">City *</label>
                                        <select id="cmbCity" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Pincode *</label>
                                        <input type="text" class="form-control numberOnly"  id="txtPinCode" placeholder="Pincode" maxlength="10">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <h4 class="col-sm-12">Contact Information</h4>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Contact1 *</label>
                                        <input type="text" class="form-control numberOnly" id="txtContact1" placeholder="Contact1" maxlength="10">
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Contact2</label>
                                        <input type="text" class="form-control numberOnly" id="txtContact2" placeholder="Contact2" maxlength="10">
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Email Id</label>
                                        <input type="text" class="form-control " id="txtEmailId" placeholder="Email Id">
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Pan No *</label>
                                        <input type="text" class="form-control " id="txtPanNo" placeholder="Pan No" maxlength="10">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6">
                                        <input type="hidden" class="form-control " id="hdnTenantId">
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <a class="btn btn-primary btn-user btn-block" onclick="SaveTenant()">Save</a>
                                    </div>
                                    <div class="col-sm-3">
                                        <a class="btn btn-primary btn-user btn-block" onclick="ResetControls(),LoadTenant(0),ShowList()">Cancel</a>
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
