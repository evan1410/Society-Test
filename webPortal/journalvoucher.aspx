<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="journalvoucher.aspx.cs" Inherits="webPortal.journalvoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <script src="appscript/journalvoucher.js"></script>
    <script src="appscript/commfun.js"></script>
    <div class="container-fluid">
        <div class="card shadow mb-12">

            <div class="card-body" id="listing">
                <div class="col-sm-12 row">
                    <h1 class="h3 mb-4 text-gray-800">Journal Voucher</h1>
                    <br />
                </div>
                <hr />
                <a class="btn btn-primary btn-icon-split" onclick="AddList()" style="margin-bottom: 10px;">
                    <span class="icon text-white-50">
                        <i class="fas fa-plus"></i>
                    </span>
                    <span class="text">Add Voucher</span>
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
                                    <h1 class="h3 mb-4 text-gray-800">Journal Voucher</h1>
                                    <br />
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-4 mb-3 mb-sm-0">
                                        <label class="col-form-label">Voucher No. *</label>
                                        <input type="text" class="form-control " id="txtVoucherNo" maxlength="15" readonly>
                                    </div>
                                    <div class="col-sm-4 mb-3 mb-sm-0">
                                        <label class="col-form-label">Voucher Date *</label>
                                        <input type="text" class="form-control simple_date" id="txtVoucherDate" placeholder="DD/MM/YYYY" maxlength="15">
                                    </div>
                                    <div class="col-sm-4">
                                        <label class="col-form-label">Name *</label>
                                        <select id="cmbLedgerFrom" class="form-control"></select>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Particulars *</label>
                                        <select id="cmbLedgerTo" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="col-form-label">Quantity *</label>
                                        <input type="text" class="form-control numberOnly" oninput="CalculateAmt()" id="txtQuantity" placeholder="Total Units">
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="col-form-label get-rate">Rate *</label>
                                        <input type="text" class="form-control numberOnly" oninput="CalculateAmt()" id="txtRate" placeholder="Rate">
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="col-form-label">Amount *</label>
                                        <input type="text" class="form-control " id="txtAmount" placeholder="Amount" readonly>
                                    </div>
                                    <div class="col-sm-1">
                                        <label class="col-form-label">GST *</label>
                                        <input type="text" class="form-control floatOnly" oninput="CalculateAmt()" id="txtGst" placeholder="GST">
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="col-form-label">Total Amount</label>
                                        <input type="text" class="form-control " id="txtTotalAmt" placeholder="Total" readonly>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-9">
                                        <%--<a class="btn btn-primary btn-user btn-block" onclick="addVoucher()">Add</a>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <a class="btn btn-primary btn-user btn-block" onclick="addVoucher()">Add</a>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="table-responsive">
                                        <table class="table table-bordered" id="dtVoucher" width="100%" cellspacing="0">
                                            <thead>
                                                <tr>
                                                    <th>To</th>
                                                    <th>Quantity</th>
                                                    <th>Rate</th>
                                                    <th>Amount</th>
                                                    <th>GST</th>
                                                    <th>Total Amount</th>
                                                    <th>Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <th>To</th>
                                                    <th>Quantity</th>
                                                    <th>Rate</th>
                                                    <th>Amount</th>
                                                    <th>GST</th>
                                                    <th>Amount</th>
                                                    <th>Action</th>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-6">
                                        <label class="col-form-label">Description</label>
                                        <textarea class="form-control" id="txtDesc" rows="6" cols="5"></textarea>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label fa-pull-right">Sub Total</label><br />
                                        <br />
                                        <label class="col-form-label fa-pull-right">Discount</label><br />
                                        <br />
                                        <label class="col-form-label fa-pull-right">GST</label><br />
                                        <br />
                                        <label class="col-form-label fa-pull-right">Grand Total</label>
                                    </div>
                                    <div class="col-sm-3 row">
                                        <input class="form-control text-sm-right" type="text" id="txtSubTotal" placeholder="Sub Total" readonly>
                                        <input class="form-control text-sm-right" type="text" id="txtDiscount" oninput="GetDiscount()" placeholder="Discount">
                                        <input class="form-control text-sm-right" type="text" id="txtGstTotal" placeholder="GST" readonly>
                                        <input class="form-control text-sm-right" type="text" id="txtTotal" placeholder="Grand Total" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6">
                                        <input type="hidden" class="form-control " id="hdnJournalId">
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <a class="btn btn-primary btn-user btn-block" onclick="SaveJournalVoucher()">Save</a>
                                    </div>
                                    <div class="col-sm-3">
                                        <a class="btn btn-primary btn-user btn-block" onclick="ResetControls(),LoadJournalVoucher(0),ShowList()">Cancel</a>
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
                                <!-- Button trigger modal -->
                                <!-- Modal -->
                                <div class="modal fade" id="newModal" data-keyboard="false" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="ModalLabel" aria-hidden="true">
                                    <div class="modal-dialog modal-lg" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="modalTitle">Update Row</h5>
                                                <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">×</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <div class="form-group row">
                                                    <div class="col-sm-4">
                                                        <label class="col-form-label" style="margin-bottom: 30px">To:-</label>
                                                        <br />
                                                        <label class="col-form-label" style="margin-bottom: 30px">Quantity:-</label>
                                                        <br />
                                                        <label class="col-form-label" style="margin-bottom: 30px">Rate:-</label>
                                                        <br />
                                                        <label class="col-form-label" style="margin-bottom: 30px">GST:-</label>
                                                        <br />
                                                        <label class="col-form-label" style="margin-bottom: 30px">Amount:-</label>
                                                        <br />
                                                        <label class="col-form-label" style="margin-bottom: 30px">Total Amount:-</label>
                                                    </div>
                                                    <div class="col-sm-8">
                                                        <select class="form-control text-sm-center" id="cmbUpdateLedgerTo"></select><br />
                                                        <input class="form-control text-sm-center" type="text" pattern="[0-9]" title="Numbers only" oninput="CalculateModal()" id="txtUpdateQty" placeholder="Quantity"><br />
                                                        <input class="form-control text-sm-center" type="text" oninput="CalculateModal()" id="txtUpdateRate" placeholder="Rate"><br />
                                                        <input class="form-control text-sm-center" type="text" id="txtUpdateGst" readonly><br />
                                                        <input class="form-control text-sm-center" type="text" id="txtUpdateAmount" placeholder="Amount" readonly><br />
                                                        <input class="form-control text-sm-center" type="text" id="txtUpdateTotalAmt" placeholder="Total Amount" readonly><br />
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                    <button type="button" class="btn btn-primary" onclick="SaveRow()">Save changes</button>
                                                </div>
                                                <div class="modal fade" id="rowModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                                    <div class="modal-dialog" role="document">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <h5 class="modal-title" id="exampleModal">Information</h5>
                                                                <button class="close" type="button" aria-label="Close">
                                                                    <span aria-hidden="true">×</span>
                                                                </button>
                                                            </div>
                                                            <div class="modal-body" id="lblMessageRow"></div>
                                                            <div class="modal-footer">
                                                                <button class="btn btn-secondary" type="button" onclick="CloseModal()">Ok</button>
                                                                <%--<a class="btn btn-primary" onclick="logout()">Logout</a>--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
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
