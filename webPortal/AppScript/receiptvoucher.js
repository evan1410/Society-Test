﻿$(document).ready(function () {
    ShowList();
    $('#hdnReceiptId').val('0');
    LoadReceiptVoucher(0);
    BindLedgerFrom();
    BindLedgerTo();
    testvalid();
    $('#dtVoucher').DataTable();
    $('#txtSubTotal').val('0');
    $('#txtDiscount').val('0');
    $('#txtGstTotal').val('0');
    $('#txtTotal').val('0');
});

function ShowList() {
    $('#listing').removeClass('hide');
    $('#entryform').addClass('hide');
}

function AddList() {
    $('#listing').addClass('hide');
    $('#entryform').removeClass('hide');
}

function BindLedgerFrom() {
    $.ajax({
        type: "POST",
        async: false,
        url: "receiptvoucher.aspx/BindLedgerFrom",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbLedgerFrom').empty();
                $('#cmbLedgerFrom').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindLedgerTo() {
    $.ajax({
        type: "POST",
        async: false,
        url: "receiptvoucher.aspx/BindLedgerTo",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbLedgerTo').empty();
                $('#cmbLedgerTo').append(data.d);
            }
        }
        //error: function (data) { }
    });
}


function LoadReceiptVoucher(ReceiptId) {
    //$('#dataTable').empty();      
    $.ajax({
        type: "POST",
        async: false,
        url: "receiptvoucher.aspx/LoadReceiptVoucher",
        data: '{"rvid":"' + ReceiptId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                if (ReceiptId === 0) {
                    $('#dataTable').empty();
                    $('#dataTable').append(data.d);
                    $('#dataTable').DataTable();
                    ShowList();
                }
                else {
                    var str = data.d;
                    var str_array = str.split('|');

                    for (var i = 0; i < str_array.length; i++) {
                        str_array[i] = str_array[i].replace(/^\s*/, "").replace(/\s*$/, "");
                    }
                    $('#hdnReceiptId').val(str_array[0]);
                    $('#txtVoucherNo').val(str_array[1]);
                    $('#txtVoucherDate').val(str_array[2]);
                    $('#cmbLedgerFrom').val(str_array[3]);
                    $('#txtQuantity').val(str_array[4]);
                    $('#txtRate').val(str_array[5]);
                    $('#txtGst').val(str_array[6]);
                    $('#txtAmount').val(str_array[7]);
                    AddList();
                }
            }
        }
        //error: function (data) { }
    });

}

function SaveReceiptVoucher() {
    if (document.getElementById('txtVoucherDate').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select or Enter Voucher Date");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbLedgerFrom').value === "" || document.getElementById('cmbLedgerFrom').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select From Ledger");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbLedgerTo').value === "" || document.getElementById('cmbLedgerTo').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select To Ledger");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtQuantity').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Quantity");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtRate').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Rate");
        $('#myModal').modal('show');
        return;
    }
    var rvid = $('hdnReceiptId').val();
    var voucherno = $('#txtVoucherNo').val();
    var voucherdate = $('#txtVoucherDate').val();
    var ledgerfrom = $('#cmbLedgerFrom').val();
    var desc = $('#txtDesc').val();
    var subtotal = $('#txtSubTotal').val();
    var discount = $('#txtDiscount').val();
    var gst = $('#txtGstTotal').val();
    var totalamt = $('#txtTotal').val();
    $.ajax({
        type: "POST",
        async: false,
        url: "receiptvoucher.aspx/SaveReceiptVoucher",
        data: '{"rvid":"' + rvid + '","voucherno":"' + voucherno + '","voucherdate": "' + voucherdate + '","ledgerfrom": "' + ledgerfrom + '","trandesc": "' + desc + '","subtotal": "' + subtotal + '","discount": "' + discount + '","gst": "' + gst + '","totalamt": "' + totalamt + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== "") {

                var str = data.d;
                var str_array = str.split('|');

                for (var i = 0; i < str_array.length; i++) {
                    str_array[i] = str_array[i].replace(/^\s*/, "").replace(/\s*$/, "");
                }
                //alert(data.d);
                if (str_array[0] !== "0") {
                    $('#listing').removeClass('hide');
                    $('#entryform').addClass('hide');
                }
                else {
                    //alert(str_array[1]);                   
                    $('#lblMessage').empty();
                    $('#lblMessage').append(str_array[1]);
                    $('#myModal').removeClass('show');
                }
                location.reload();
                ResetControls();
            }
        }
        //error: function (data) { }
    });

    var table = $('#dtVoucher').DataTable();
    var id = 0;
    var rowcount = table.rows().count();
    var rowdata = new Array();
    var celldata = new Array();
    for (let i = 0; i < rowcount; i++) {
        rowdata = table.row(i).data();
        celldata = rowdata.toString().split(",");
        var ledgerto = celldata[0];
        var qty = celldata[1];
        var rate = celldata[2];
        var amount = celldata[3];
        var gstamt = celldata[4];
        var total = celldata[5];
        alert(rowdata);
        $.ajax({
            type: "POST",
            async: false,
            url: "receiptvoucher.aspx/SaveReceiptDtls",
            data: '{"id": "' + id + '","rvid": "' + rvid + '","ledgerto": "' + ledgerto + '","qty": "' + qty + '","rate": "' + rate + '","amount": "' + amount + '","gstamt": "' + gstamt + '","total": "' + total + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d !== "") {

                    var str = data.d;
                    var str_array = str.split('|');

                    for (var i = 0; i < str_array.length; i++) {
                        str_array[i] = str_array[i].replace(/^\s*/, "").replace(/\s*$/, "");
                    }
                }
                    //alert(data.d);
                    //if (str_array[0] !== "0") {
                    //    LoadJournalVoucher(0);
                    //    $('#listing').removeClass('hide');
                    //    $('#entryform').addClass('hide');
                    //}
                else {
                    //alert(str_array[1]);                   
                    $('#lblMessage').empty();
                    $('#lblMessage').append(str_array[1]);
                    $('#myModal').removeClass('show');
                }
                location.reload();
                ResetControls();
            }

            //error: function (data) { }
        });
    }
}

function ResetControls() {
    $('hdnReceiptId').val('0');
    $('#txtVoucherNo').val('');
    $('#txtVoucherDate').val('');
    $('#cmbLedgerFrom').val('0');
    $('#cmbLedgerTo').val('0');
    $('#txtQuantity').val('0');
    $('#txtRate').val('0');
    $('#txtAmount').val('0');
    $('#txtGst').val('0');
    $('#txtTotalAmt').val('0');
    $('#txtSubTotal').val('0');
    $('#txtDiscount').val('0');
    $('#txtGstTotal').val('0');
    $('#txtTotal').val('0');
    $('#dtVoucher').DataTable().clear().draw();
}


function DeleteRecord(ReceiptId) {
    if (confirm("Do you really want to delete the record?")) {

        if (ReceiptId !== 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: "receiptvoucher.aspx/DeleteReceipt",
                data: '{"rvid":"' + ReceiptId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d !== '') {
                        var str = data.d;
                        var str_array = str.split('|');

                        for (var i = 0; i < str_array.length; i++) {
                            str_array[i] = str_array[i].replace(/^\s*/, "").replace(/\s*$/, "");
                        }
                        if (str_array[0] !== "0") {

                            $('#listing').removeClass('hide');
                            $('#entryform').addClass('hide');
                            location.reload();
                        }
                        ResetControls();
                    }
                }
            });
        }
    }
}