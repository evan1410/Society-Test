<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="ledger.aspx.cs" Inherits="webPortal.ledgermaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <script src="appscript/ledger.js"></script>
    <script src="appscript/commfun.js"></script>
    <div class="container-fluid">
        <%--<h1 class="h3 mb-4 text-gray-800">Ledger</h1>--%>
        <div class="card shadow mb-12">
            <div class="card-body" id="listing">
                <div class="col-sm-12 row">
                    <h1 class="h3 mb-4 text-gray-800">Ledger</h1>
                    <br />
                </div>
                <hr />
                <a class="btn btn-primary btn-icon-split" onclick="AddList()" style="margin-bottom: 10px;">
                    <span class="icon text-white-50">
                        <i class="fas fa-plus"></i>
                    </span>
                    <span class="text">Add Ledger</span>
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
                                <div class="col-sm-12 row">
                                    <h1 class="h3 mb-4 text-gray-800">Ledger</h1>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Account Group *</label>
                                        <select id="cmbAcGrpCode" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Ledger Code *</label>
                                        <input type="text" class="form-control" id="txtLedgerCode" maxlength="10">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Ledger Name *</label>
                                        <input type="text" class="form-control" id="txtLedgerName" pattern="[A-Za-z]" title="Alphabets only" placeholder="Name" maxlength="50">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Description</label>
                                        <input type="text" class="form-control" id="txtDesc" placeholder="Description">
                                    </div>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label class="col-form-label">Is Details?</label>
                                        <input type="checkbox" name="Details" id="chkDetails" onclick="showDetails()">
                                    </div>
                                </div>
                                <div class="form-group" id="divDetails">
                                    <hr />
                                    <div class="form-group row">
                                        <div class="col-sm-6">
                                            <label class="col-form-label">Address *</label>
                                            <input type="text" class="form-control" id="txtAddress" placeholder="Address">
                                        </div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <label class="col-form-label">Country *</label>
                                            <select id="cmbCountry" onchange="BindState()" class="form-control"></select>
                                        </div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <label class="col-form-label">State *</label>
                                            <select id="cmbState" onchange="BindCity()" class="form-control"></select>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <label class="col-form-label">City *</label>
                                            <select id="cmbCity" class="form-control"></select>
                                        </div>
                                        <div class="col-sm-3">
                                            <label class="col-form-label">Pincode *</label>
                                            <input type="text" class="form-control numberOnly" id="txtPinCode" placeholder="pincode">
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label class="col-form-label">GST Applicable</label>
                                        <input type="checkbox" id="chkGst" onclick="showGst()">
                                    </div>
                                </div>
                                <div class="form-group" id="divGst">
                                    <hr />
                                    <div class="form-group row">
                                        <div class="col-sm-3">
                                            <label class="col-form-label">GST No *</label>
                                            <input type="text" class="form-control" id="txtGstNo" placeholder="GST No">
                                        </div>
                                        <div class="col-sm-3">
                                            <label class="col-form-label">GST Percent *</label>
                                            <input type="text" class="form-control floatOnly" id="txtGstPercent" placeholder="Percent">
                                        </div>
                                        <div class="col-sm-3">
                                            <label class="col-form-label">Pan No</label>
                                            <input type="text" class="form-control" id="txtPanno" placeholder="Pan No.">
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label class="col-form-label">Adjustment Applicable</label>
                                        <input type="checkbox" id="chkAdjust" onclick="showAdjust()">
                                    </div>
                                </div>
                                <div class="form-group" id="divAdjust">
                                    <hr />
                                    <div class="form-group row">
                                        <div class="col-sm-3">
                                            <label class="col-form-label">Adjustment *</label>
                                            <select id="cmbAdjustment" class="form-control"></select>
                                        </div>
                                        <div class="col-sm-3">
                                            <label class="col-form-label">Value *</label>
                                            <input type="text" class="form-control numberOnly" id="txtAdjustVal" placeholder="Value">
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6">
                                        <input type="hidden" class="form-control" id="hdnLedgerId">
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <a class="btn btn-primary btn-user btn-block" onclick="SaveLedger()">Save</a>
                                    </div>
                                    <div class="col-sm-3">
                                        <a class="btn btn-primary btn-user btn-block" onclick="ResetControls(),LoadLedger(0),ShowList()">Cancel</a>
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
