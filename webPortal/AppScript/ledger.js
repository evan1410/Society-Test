$(document).ready(function () {
    ShowList();
    hideDiv();
    $('#hdnLedgerId').val('0');
    LoadLedger(0);
    BindAccountGroup();
    BindCountry();
    BindAdjustment();
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

function BindAccountGroup() {
    $.ajax({
        type: "POST",
        async: false,
        url: "ledger.aspx/BindAccountGroup",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbAcGrpCode').empty();
                $('#cmbAcGrpCode').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindCountry() {
    $.ajax({
        type: "POST",
        async: false,
        url: "ledger.aspx/BindCountry",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbCountry').empty();
                $('#cmbCountry').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindState() {
    var countryid = $("#cmbCountry").val();
    $.ajax({
        type: "POST",
        async: false,
        url: "ledger.aspx/BindState",
        data: '{"countryid":"' + countryid + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbState').empty();
                $('#cmbState').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindCity() {
    var stateid = $("#cmbState").val();
    $.ajax({
        type: "POST",
        async: false,
        url: "ledger.aspx/BindCity",
        data: '{"stateid":"' + stateid + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbCity').empty();
                $('#cmbCity').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindAdjustment() {
    $.ajax({
        type: "POST",
        async: false,
        url: "ledger.aspx/BindAdjustment",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbAdjustment').empty();
                $('#cmbAdjustment').append(data.d);
            }
        }
        //error: function (data) { }
    });
}


function LoadLedger(LedgerId) {
    //$('#dataTable').empty();      
    $.ajax({
        type: "POST",
        async: false,
        url: "ledger.aspx/LoadLedger",
        data: '{"ledgerid":"' + LedgerId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                if (LedgerId === 0) {
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
                    $('#hdnLedgerId').val(str_array[0]);
                    $('#cmbAcGrpCode').val(str_array[1]);
                    $('#txtLedgerCode').val(str_array[2]);
                    $('#txtLedgerName').val(str_array[3]);
                    $('#txtDesc').val(str_array[4]);
                    if(str_array[5] === "True"){
                        $("#chkDetails").prop("checked", true);
                        showDetails();
                    }
                    $('#txtAddress').val(str_array[6]);
                    $('#cmbCountry').val(str_array[9]);
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "ledger.aspx/BindState",
                        data: '{"countryid":"' + str_array[9] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbState').empty();
                                $('#cmbState').append(data.d);
                                $('#cmbState').val(str_array[8]);
                            }
                        }
                        //error: function (data) { }
                    });
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "ledger.aspx/BindCity",
                        data: '{"stateid":"' + str_array[8] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbCity').empty();
                                $('#cmbCity').append(data.d);
                                $('#cmbCity').val(str_array[7]);
                            }
                        }
                        //error: function (data) { }
                    });
                    $('#txtPinCode').val(str_array[10]);
                    if (str_array[12] === "True") {
                        $("#chkGst").prop("checked", true);
                        showGst();
                    }
                    $('#txtGstNo').val(str_array[13]);
                    $('#txtGstPercent').val(str_array[14]);
                    $('#txtPanno').val(str_array[11]);
                    if (str_array[15] === "True") {
                        $("#chkAdjust").prop("checked", true);
                        showAdjust();
                    }
                    $('#cmbAdjustment').val(str_array[16]); 
                    $('#txtAdjustVal').val(str_array[17]);
                    AddList();
                }
            }
        }
        //error: function (data) { }
    });

}

function SaveLedger() {

    if (document.getElementById('cmbAcGrpCode').value === "" || document.getElementById('cmbAcGrpCode').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Group Code");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtLedgerCode').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Ledger Code");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtLedgerName').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Ledger Name");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('chkDetails').checked === true) {
        if (document.getElementById('txtAddress').value === "") {
            $('#lblMessage').empty();
            $('#lblMessage').append("Enter Address");
            $('#myModal').modal('show');
            return;
        }
        if (document.getElementById('cmbCountry').value === "" || document.getElementById('cmbCountry').value === "0") {
            $('#lblMessage').empty();
            $('#lblMessage').append("Select Country");
            $('#myModal').modal('show');
            return;
        }
        if (document.getElementById('cmbState').value === "" || document.getElementById('cmbState').value === "0") {
            $('#lblMessage').empty();
            $('#lblMessage').append("Select State");
            $('#myModal').modal('show');
            return;
        }
        if (document.getElementById('cmbCity').value === "" || document.getElementById('cmbCity').value === "0") {
            $('#lblMessage').empty();
            $('#lblMessage').append("Select City");
            $('#myModal').modal('show');
            return;
        }
        if (document.getElementById('txtPinCode').value === "") {
            $('#lblMessage').empty();
            $('#lblMessage').append("Enter PinCode");
            $('#myModal').modal('show');
            return;
        }
    }
 
    if (document.getElementById('chkGst').checked === true) {
        if (document.getElementById('txtGstNo').value === "") {
            $('#lblMessage').empty();
            $('#lblMessage').append("Enter Gst Number");
            $('#myModal').modal('show');
            return;
        }
        if (document.getElementById('txtGstPercent').value === "") {
            $('#lblMessage').empty();
            $('#lblMessage').append("Enter Gst Percent");
            $('#myModal').modal('show');
            return;
        }
    }

    if (document.getElementById('chkAdjust').checked === true) {
        if (document.getElementById('cmbAdjustment').value === "" || document.getElementById('cmbAdjustment').value === "0") {
            $('#lblMessage').empty();
            $('#lblMessage').append("Select an Adjustment");
            $('#myModal').modal('show');
            return;
        }
        if (document.getElementById('txtAdjustVal').value === "") {
            $('#lblMessage').empty();
            $('#lblMessage').append("Enter Adjustment Value");
            $('#myModal').modal('show');
            return;
        }
    }

    var ledgerid = $('#hdnLedgerId').val();
    var acgrpcode = $('#cmbAcGrpCode').val();
    var ledgercode = $('#txtLedgerCode').val();
    var ledgername = $('#txtLedgerName').val();
    var ledgerdesc = $('#txtDesc').val();
    var isdetails = $('#chkDetails').is(':checked');
    var address = $('#txtAddress').val();
    var city = $('#cmbCity').val();
    var state = $('#cmbState').val();
    var country = $('#cmbCountry').val();
    var pincode = $('#txtPinCode').val();
    var isgstapplicable = $('#chkGst').is(':checked');
    var gstno = $('#txtGstNo').val();
    var gstpercent = $('#txtGstPercent').val();
    var panno = $('#txtPanno').val();
    var isadjustment = $('#chkAdjust').is(':checked');
    var adjusment = $('#cmbAdjustment').val();
    var adjustmentvalue = $('#txtAdjustVal').val();

    //alert(yourArray);
    $.ajax({
        type: "POST",
        async: false,
        url: "ledger.aspx/SaveLedger",
        data: '{"ledgerid":"' + ledgerid + '","acgrpcode":"' + acgrpcode + '","ledgercode":"' + ledgercode + '","ledgername":"' + ledgername + '","ledgerdesc":"' + ledgerdesc + '","isdetails":"' + isdetails + '","address":"' + address + '","city":"' + city + '","state":"' + state + '","country":"' + country + '","pincode":"' + pincode + '","isgstapplicable":"' + isgstapplicable + '","gstno":"' + gstno + '","gstpercent":"' + gstpercent + '","panno":"' + panno + '","isadjustment":"' + isadjustment + '","adjustment":"' + adjusment + '","adjustmentvalue":"' + adjustmentvalue + '"}',
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
                    LoadLedger(0);
                    $('#listing').removeClass('hide');
                    $('#entryform').addClass('hide');
                }
                else {
                    //alert(str_array[1]);                   
                    $('#lblMessage').empty();
                    $('#lblMessage').append(str_array[1]);
                    $('#myModal').modal('show');
                }
                location.reload();
                ResetControls();
            }
        }
        //error: function (data) { }
    });
}

function ResetControls() {
    $('#hdnLedgerId').val('0')
    $('#cmbAcGrpCode').val('');
    $('#txtLedgerCode').val('');
    $('#txtLedgerName').val('');
    $('#txtDesc').val('');
    $('#chkDetails').val('');
    $('#txtAddress').val('');
    $('#cmbCity').val('');
    $('#cmbState').val('');
    $('#cmbCountry').val('');
    $('#txtPinCode').val('');
    $('#chkGst').val('');
    $('#txtGstNo').val('');
    $('#txtGstPercent').val('');
    $('#txtPanno').val('');
    $('#chkAdjust').val('');
    $('#cmbAdjustment').val('');
    $('#txtAdjustVal').val('');
}


function DeleteRecord(LedgerId) {
    if (confirm("Do you really want to delete the record?")) {

        if (LedgerId !== 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: "ledger.aspx/DeleteLedger",
                data: '{"ledgerid":"' + LedgerId + '"}',
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

function hideDiv() {
    document.getElementById('divDetails').style.display = "none";
    document.getElementById('divGst').style.display = "none";
    document.getElementById('divAdjust').style.display = "none";
}

function showDetails() {
    if (document.getElementById('chkDetails').checked == false) {
        document.getElementById('divDetails').style.display = "none";
        $('#txtAddress').val('');
        $('#cmbCity').val('');
        $('#cmbState').val('');
        $('#cmbCountry').val('0');
        $('#txtPinCode').val('');
        
    }
    else {
        document.getElementById('divDetails').style.display = "block";
    }
}

function showGst() {
    if (document.getElementById('chkGst').checked == false) {
        document.getElementById('divGst').style.display = "none";
        $('#txtGstNo').val('');
        $('#txtGstPercent').val('');
        $('#txtPanno').val('');
    }
    else {
        document.getElementById('divGst').style.display = "block";
    }
}

function showAdjust() {
    if (document.getElementById('chkAdjust').checked == false) {
        document.getElementById('divAdjust').style.display = "none";
        $('#cmbAdjustment').val('0');
        $('#txtAdjustVal').val('');
    }
    else {
        document.getElementById('divAdjust').style.display = "block";
    }
}