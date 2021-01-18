<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="unitmaster.aspx.cs" Inherits="webPortal.unitmaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <script src="appscript/unitmaster.js"></script>
    <script src="appscript/commfun.js"></script>
    <div class="container-fluid">
        <h1 class="h3 mb-4 text-gray-800">Unit Master</h1>
        <div class="card shadow mb-12">
            <div class="card-body" id="listing">
                <a class="btn btn-primary btn-icon-split" onclick="AddList()" style="margin-bottom: 10px;">
                    <span class="icon text-white-50">
                        <i class="fas fa-plus"></i>
                    </span>
                    <span class="text">Add Unit</span>
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
                                    <h4 class="col-sm-12">Unit Information</h4>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Society Name *</label>
                                        <select id="cmbSocietyCode" onchange="BindBldgNo()" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Building No *</label>
                                        <select id="cmbBldgNo" onchange="BindFloorNo()" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Floor No *</label>
                                        <select id="cmbFloorNo" onchange="BindUnitType()" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Unit Type *</label>
                                        <select id="cmbUnitType" class="form-control"></select>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Unit No *</label>
                                        <input type="text" class="form-control numberOnly" id="txtUnitNo" placeholder="Unit No.">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Unit Area *</label>
                                        <input type="text" class="form-control floatOnly" id="txtUnitArea" placeholder="Unit Area">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Occupied By *</label>
                                        <select id="cmbOccupiedBy" class="form-control"></select>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <h4 class="col-sm-12">Owner Information</h4>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Account Group *</label>
                                        <select class="form-control" id="cmbAcGrpCode"></select>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Ledger Code *</label>
                                        <input type="text" class="form-control" id="txtLedgerCode">
                                    </div>
                                    <div class="col-sm-6">
                                        <label class="col-form-label">Unit Owner *</label>
                                        <input type="text" class="form-control alphaOnly" id="txtUnitOwner" placeholder="Unit Owner">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6">
                                        <label class="col-form-label">Address *</label>
                                        <input type="text" class="form-control" id="txtAddress" placeholder="Address">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Location *</label>
                                        <input type="text" class="form-control alphaOnly" id="txtLocation" placeholder="Location">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Country *</label>
                                        <select id="cmbCountry" onchange="BindState()" class="form-control"></select>
                                    </div>
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
                                    <h4 class="col-sm-12">Contact Information</h4>
                                </div>
                                <hr />
                                <div class="form-group row">
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
                                        <input type="text" class="form-control" id="txtEmailId" placeholder="Eg:- john@gmail.com">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Pan No*</label>
                                        <input type="text" class="form-control" id="txtPanNo" placeholder="Pan No.">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6">
                                        <input type="hidden" class="form-control" id="hdnUnitId">
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <a class="btn btn-primary btn-user btn-block" onclick="SaveUnit()">Save</a>
                                    </div>
                                    <div class="col-sm-3">
                                        <a class="btn btn-primary btn-user btn-block" onclick="ResetControls(),LoadUnit(0),ShowList()">Cancel</a>
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
