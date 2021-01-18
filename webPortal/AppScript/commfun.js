//function isNotEmpty(elem) {
//    var str = elem.value;
//    var re = /.+/;
//    if (!str.match(re)) {
//        //alert("Please fill in the required field.");
//        //setTimeout("focusElement('" + elem.form.name + "', '" + elem.name + "')", 0);
//        return false;
//    } else {
//        return true;
//    }
//}

//Integer only
function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

//decimal Only
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function onlyAlphaNumeric(e, t) {
    return (e.charCode > 47 && e.charCode < 58) || (e.charCode > 64 && e.charCode < 91) || (e.charCode > 96 && e.charCode < 123) || e.charCode === 32;
}

function onlyAlphabets(e, t) {
    return (e.charCode > 64 && e.charCode < 91) || (e.charCode > 96 && e.charCode < 123) || e.charCode === 32;
}

function validEmail(emailField) {
    //var email = document.getElementById('txtEmail');
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (filter.test(emailField)) {
        //email.focus;
        return false;
    }
    return true;
}

function validateEmail(inputText) {
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (inputText.match(mailformat)) {
        //document.form1.text1.focus();
        return true;
    }
    else {
        //alert("You have entered an invalid email address!");
        //document.form1.text1.focus();
        return false;
    }
}

//Mathematical functions for datables present in voucher.aspx
function CalculateAmt() {
    var qty = parseFloat($('#txtQuantity').val());
    var rate = parseFloat($('#txtRate').val());
    var amount = parseFloat($('#txtAmount').val());
    var gst = parseFloat($('#txtGst').val());
    var totalamt;
    if (isNaN(qty) || isNaN(rate)) {
        $('#txtAmount').val('0');
        $('#txtTotalAmt').val('0');
    } else if (isNaN(gst)) {
        gst = 0;
        amount = qty * rate;
        totalamt = amount + gst;
        $('#txtAmount').val(amount);
        $('#txtTotalAmt').val(totalamt);
    } else {
        amount = qty * rate;
        totalamt = amount + gst;
        $('#txtAmount').val(amount);
        $('#txtTotalAmt').val(totalamt);
    }
}

function GetDiscount() {

    var subtotal = parseFloat($('#txtSubTotal').val());
    var discount = parseFloat($('#txtDiscount').val());
    var gst = parseFloat($('#txtGstTotal').val());
    var total = parseFloat($('#txtTotal').val());
    if (isNaN(discount)) {
        discount = 0;
        total = subtotal - discount + gst;
    } else if (isNaN(total)) {
        total = 0;
        discount = 0;
    } else {
        total = subtotal - discount + gst;
    }
    $('#txtDiscount').val(discount);
    $('#txtTotal').val(total);
}


function CalculateModal() {
    var updateqty = parseFloat($('#txtUpdateQty').val());
    var updaterate = parseFloat($('#txtUpdateRate').val());
    var updategst = parseFloat($('#txtUpdateGst').val());
    var updateamount = parseFloat($('#txtUpdateAmount').val());
    var updatetotalamt = parseFloat($('#txtUpdateTotalAmt').val());
    if (isNaN(updateqty) || isNaN(updaterate)) {
        $('#txtUpdateAmount').val('0');
        $('#txtUpdateTotalAmt').val(updategst);
    }
    else if (isNaN(updategst)) {
        updategst = 0;
        updateamount = updateqty * updaterate;
        updatetotalamt = updateamount + updategst;
        $('#txtUpdateAmount').val(updateamount);
        $('#txtUpdateTotalAmt').val(updatetotalamt);
    }
    else {
        updateamount = updateqty * updaterate;
        updatetotalamt = updateamount + updategst;
        $('#txtUpdateAmount').val(updateamount);
        $('#txtUpdateTotalAmt').val(updatetotalamt);
    }

}

//Data Manipulators for DataTable present inside voucher.aspx
var rowid;
function addVoucher() {
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

    var ledgerto = $('#cmbLedgerTo').val();
    var qty = $('#txtQuantity').val();
    var rate = $('#txtRate').val();
    var gst = parseFloat($('#txtGst').val());
    var amount = parseFloat($('#txtAmount').val());
    var totalamt = parseFloat($('#txtTotalAmt').val());
    var subtotal = parseFloat($('#txtSubTotal').val());
    var total = parseFloat($('#txtTotal').val());
    var totalgst = parseFloat($('#txtGstTotal').val());
    var table = $('#dtVoucher').DataTable();
    var action = "<div class=\"text-center\">" + "<i class=\"fa fa-eye edit-row\" aria-hidden=\"true\" title=\"View\" data-toggle=\"modal\" data-target=\"#newModal\" onclick=\"EditRow()\"></i>&nbsp" + "&nbsp<i class=\"fa fa-trash delete-row\" aria-hidden=\"true\" title=\"Delete\" onclick=\"DeleteRow()\"></i>" + "</div>";


    if (ledgerto !== null || qty !== "" || rate !== "" || gst !== "" || amount !== "") {
        table.row.add([ledgerto, qty, rate, amount, gst, totalamt, action]).draw();
        subtotal += amount;
        total += totalamt;
        totalgst += gst;
        $('#txtSubTotal').val(subtotal);
        $('#txtGstTotal').val(totalgst);
        $('#txtTotal').val(total);

    }
    else {
        alert("Enter all the fields");
    }
}


function DeleteRow() {
    var table = $('#dtVoucher').DataTable();
    $('#dtVoucher tbody').off('click').on('click', 'i.delete-row', function () {
        var id = table.row($(this).closest('tr')).index();
        var minsubtotal = table.cell(id, 3).data();
        var mintotalgst = table.cell(id, 4).data();
        var mintotal = table.cell(id, 5).data();

        var subtotal = parseFloat($('#txtSubTotal').val()) - minsubtotal;
        var totalgst = parseFloat($('#txtGstTotal').val()) - mintotalgst;
        var total = parseFloat($('#txtTotal').val()) - mintotal;

        table.rows($(this).closest('tr')).remove().draw();
        $('#txtSubTotal').val(subtotal);
        $('#txtGstTotal').val(totalgst);
        $('#txtTotal').val(total);
    });
}




function EditRow() {
    var table = $('#dtVoucher').DataTable();
    $('#dtVoucher').off('click').on('click', 'i.edit-row', function (e) {
        rowid = table.row($(this).closest('tr')).index();
        var dr = table.row(rowid).data();
        var olddata = dr.toString().split(',', 6);
        $.ajax({
            type: "POST",
            async: false,
            url: "receiptvoucher.aspx/BindLedgerTo",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d !== '') {
                    $('#cmbUpadteLedgerTo').empty();
                    $('#cmbUpdateLedgerTo').append(data.d);
                    $('#cmbUpdateLedgerTo').val(olddata[0]);
                }
            }
            //error: function (data) { }
        });
        $('#txtUpdateQty').val(olddata[1]);
        $('#txtUpdateRate').val(olddata[2]);
        $('#txtUpdateAmount').val(olddata[3]);
        $('#txtUpdateGst').val(olddata[4]);
        $('#txtUpdateTotalAmt').val(olddata[5]);
    });
}

function SaveRow() {
    if (document.getElementById('cmbUpdateLedgerTo').value === "" || document.getElementById('cmbUpdateLedgerTo').value === "0") {
        $('#lblMessageRow').empty();
        $('#lblMessageRow').append("Select To Ledger");
        $('#rowModal').modal('show');
        return;
    }

    if (document.getElementById('txtUpdateQty').value === "") {
        $('#lblMessageRow').empty();
        $('#lblMessageRow').append("Enter Quantity");
        $('#rowModal').modal('show');
        return;
    }

    if (document.getElementById('txtUpdateRate').value === "") {
        $('#lblMessageRow').empty();
        $('#lblMessageRow').append("Enter Rate");
        $('#rowModal').modal('show');
        return;
    }
    var table = $('#dtVoucher').DataTable();
    var ledgerto = $('#cmbUpdateLedgerTo').val();
    var qty = $('#txtUpdateQty').val();
    var rate = $('#txtUpdateRate').val();
    var gst = $('#txtUpdateGst').val();
    var amount = $('#txtUpdateAmount').val();
    var totalamt = $('#txtUpdateTotalAmt').val();
    var subtotal = 0;
    var totalgst = 0;
    var total = 0;
    var action = "<div class=\"text-center\">" + "<i class=\"fa fa-eye edit-row\" aria-hidden=\"true\" title=\"View\" data-toggle=\"modal\" data-target=\"#newModal\" onclick=\"EditRow(" + rowid + ")\"></i>&nbsp" + "&nbsp<i class=\"fa fa-trash delete-row\" aria-hidden=\"true\" title=\"Delete\" onclick=\"DeleteRow()\"></i>" + "</div>";
    table.row(rowid).data([ledgerto, qty, rate, amount, gst, totalamt, action]).draw();
    for (let i = 0; i < table.rows().count() ; i++) {
        subtotal += parseFloat(table.cell(i, 3).data());
        totalgst += parseFloat(table.cell(i, 4).data());
        total += parseFloat(table.cell(i, 5).data());
    }
    $('#txtSubTotal').val(subtotal);
    $('#txtTotalGst').val(totalgst);
    $('#txtTotal').val(total);
    GetDiscount();
    $('#newModal').modal('toggle');

}


function CloseModal() {
    $('#rowModal').modal('toggle');
}

function testvalid() {
    $('.row').keypress(function () {
        (function ($) {
            $.fn.inputFilter = function (inputFilter) {
                return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
                    if (inputFilter(this.value)) {
                        this.oldValue = this.value;
                        this.oldSelectionStart = this.selectionStart;
                        this.oldSelectionEnd = this.selectionEnd;
                    } else if (this.hasOwnProperty("oldValue")) {
                        this.value = this.oldValue;
                        this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
                    } else {
                        this.value = "";
                    }
                });
            };
        }(jQuery));

        $(".numberOnly").inputFilter(function (value) {
            return /^\d*$/.test(value);
        });
        $(".alphaOnly").inputFilter(function (value) {
            return /^[a-z]*$/i.test(value);
        });
        $(".floatOnly").inputFilter(function (value) {
            return /^-?\d*[.,]?\d*$/.test(value);
        });
    });
};
