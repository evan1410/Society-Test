<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="contravoucher.aspx.cs" Inherits="webPortal.contravoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <script src="appscript/contravoucher.js"></script>
    <script src="appscript/commfun.js"></script>
    <div class="container-fluid">
        <div class="card shadow mb-12">

            <div class="card-body" id="listing">
                <div class="col-sm-12 row">
                    <h1 class="h3 mb-4 text-gray-800">Contra Voucher</h1>
                    <br />
                </div>
                <hr />
                <a class="btn btn-primary btn-icon-split" onclick="AddList()" style="margin-bottom: 10px;">
                    <span class="icon text-white-50">
                        <i class="fas fa-plus"></i>
                    </span>
                    <span class="text">Add Contra Voucher</span>
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
                                    <h1 class="h3 mb-4 text-gray-800">Contra Voucher</h1>
                                    <br />
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Voucher No *</label>
                                        <input type="number" class="form-control " id="txtVoucherNo" maxlength="10" value="0" readonly>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Voucher Date *</label>
                                        <input type="text" class="form-control simple_date" id="txtVoucherDate" placeholder="DD/MM/YYYY" maxlength="50">
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Name *</label>
                                        <select id="cmbLedgerFrom" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Particulars *</label>
                                        <select id="cmbLedgerTo" class="form-control"></select>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Amount *</label>
                                        <input type="text" class="form-control floatOnly" id="txtAmount" placeholder="Amount" maxlength="50">
                                    </div>
                                    <div class="col-sm-9 mb-3 mb-sm-0">
                                        <label class="col-form-label">Description</label>
                                        <input type="text" class="form-control " id="txtDesc" placeholder="Description" maxlength="200">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6">
                                        <input type="hidden" class="form-control" id="hdnContraId">
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <a class="btn btn-primary btn-user btn-block" onclick="SaveContraVoucher()">Save</a>
                                    </div>
                                    <div class="col-sm-3">
                                        <a class="btn btn-primary btn-user btn-block" onclick="ResetControls(),LoadContraVoucher(0),ShowList()">Cancel</a>
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
