$(document).ready(function () {
    ShowList();
    $('#hdnContraId').val('0');
    LoadContraVoucher(0);
    BindLedgerFrom();
    BindLedgerTo();
    testvalid();
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
        url: "contravoucher.aspx/BindLedgerFrom",
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
        url: "contravoucher.aspx/BindLedgerTo",
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

function LoadContraVoucher(ContraId) {
    //$('#dataTable').empty();      
    $.ajax({
        type: "POST",
        async: false,
        url: "contravoucher.aspx/LoadContraVoucher",
        data: '{"id":"' + ContraId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                if (ContraId === 0) {
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

                    $('#hdnContraId').val(str_array[0]);
                    $('#txtVoucherNo').val(str_array[1]);
                    $('#txtVoucherDate').val(str_array[2]);
                    $('#cmbLedgerFrom').val(str_array[3]);
                    $('#cmbLedgerTo').val(str_array[4]);
                    $('#txtAmount').val(str_array[5]);
                    $('#txtDesc').val(str_array[6]);
                    AddList();
                }
            }
        }
        //error: function (data) { }
    });

}

function SaveContraVoucher() {

    if (document.getElementById('txtVoucherNo').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter a Voucher No.");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtVoucherDate').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter a Voucher Date");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbLedgerFrom').value === "" || document.getElementById('cmbLedgerFrom').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select a From Ledger");
        $('#myModal').modal('show');
        return;
    }
    if (document.getElementById('cmbLedgerTo').value === "" || document.getElementById('cmbLedgerTo').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select a To Ledger");
        $('#myModal').modal('show');
        return;
    }
    if (document.getElementById('txtAmount').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter an amount");
        $('#myModal').modal('show');
        return;
    }

    var id = $('#hdnContraId').val();
    var voucherno = $('#txtVoucherNo').val();
    var voucherdate = $('#txtVoucherDate').val();
    var ledgerfrom = $('#cmbLedgerFrom').val();
    var ledgerto = $('#cmbLedgerTo').val();
    var amount = $('#txtAmount').val();
    var trandesc = $('#txtDesc').val();

    //alert(yourArray);
    $.ajax({
        type: "POST",
        async: false,
        url: "contravoucher.aspx/SaveContraVoucher",
        data: '{"id":"' + id + '","voucherno":"' + voucherno + '","voucherdate":"' + voucherdate + '","ledgerfrom":"' + ledgerfrom + '","ledgerto":"' + ledgerto + '","amount":"' + amount + '","trandesc":"' + trandesc + '"}',
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
                    LoadContraVoucher(0);
                    $('#listing').removeClass('hide');
                    $('#entryform').addClass('hide');
                }
                else {
                    //alert(str_array[1]);                   
                    $('#lblMessage').empty();
                    $('#lblMessage').append(str_array[1]);
                    $('#frmMessage').removeClass('hide');
                }
                location.reload();
                ResetControls();
            }
        }
        //error: function (data) { }
    });
}

function ResetControls() {
    $('#hdnContraId').val('0');
    $('#txtVoucherNo').val('');
    $('#txtVoucherDate').val('');
    $('#cmbLedgerFrom').val('0');
    $('#cmbLedgerTo').val('0');
    $('#txtAmount').val('');
    $('#txtDesc').val('');
}

function DeleteRecord(ContraId) {
    if (confirm("Do you really want to delete the record?")) {

        if (ContraId !== 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: "contravoucher.aspx/DeleteContraVoucher",
                data: '{"ContraId":"' + ContraId + '"}',
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

var sysdate = new Date();
var currentDate = sysdate.getDate() + sysdate.getMonth() + sysdate.getFullYear();
$('#txtVoucherDate').val(currentDate);