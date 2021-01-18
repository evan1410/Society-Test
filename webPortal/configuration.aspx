<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="configuration.aspx.cs" Inherits="webPortal.configuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <script src="appscript/configuration.js"></script>
    <script src="appscript/commfun.js"></script>
    <div class="container-fluid">
        <%--<h1 class="h3 mb-4 text-gray-800">Configuration</h1>--%>
        <div class="card shadow mb-12">
            <div class="card-body" id="listing">
                <div class="col-sm-12 row">
                    <h1 class="h3 mb-4 text-gray-800">Configuration</h1>
                    <br />
                </div>
                <hr />
                <a class="btn btn-primary btn-icon-split" onclick="AddList()" style="margin-bottom: 10px;">
                    <span class="icon text-white-50">
                        <i class="fas fa-plus"></i>
                    </span>
                    <span class="text">Add Configuration</span>
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
                                    <h1 class="h3 mb-4 text-gray-800">Configuration</h1>
                                    <br />
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Category *</label>
                                        <select id="cmbCategory" onchange="BindValueType()" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <label class="col-form-label">Value Type *</label>
                                        <select id="cmbValueType" class="form-control"></select>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Rate *</label>
                                        <input type="text" class="form-control numberOnly" id="txtRate" placeholder="Rate" maxlength="50">
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="col-form-label">Due Date *</label>
                                        <input type="text" class="form-control" id="txtDueDate" placeholder="Due Date">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6">
                                        <input type="hidden" class="form-control" id="hdnConfigId">
                                    </div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <a class="btn btn-primary btn-user btn-block" onclick="SaveConfiguration()">Save</a>
                                    </div>
                                    <div class="col-sm-3">
                                        <a class="btn btn-primary btn-user btn-block" onclick="ResetControls(),LoadConfiguration(0),ShowList()">Cancel</a>
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
