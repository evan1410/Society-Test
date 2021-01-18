    $(document).ready(function () {
    $('#hdnTenantId').val('0');
    ShowList();
    LoadTenant(0);
    BindSocietyName();
    BindCountry();
    BindAccountGroup();
        BindTenantType();
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

function BindSocietyName() {
    $.ajax({
        type: "POST",
        async: false,
        url: "tenantmaster.aspx/BindSocietyName",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbSocietyCode').empty();
                $('#cmbSocietyCode').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindBldgNo() {
    var societycode = $('#cmbSocietyCode').val();
    $.ajax({
        type: "POST",
        async: false,
        url: "tenantmaster.aspx/BindBldgNo",
        data: '{"societycode":"' + societycode + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbBldgNo').empty();
                $('#cmbBldgNo').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindFloorNo() {
    var societycode = $('#cmbSocietyCode').val();
    var bldgno = $('#cmbBldgNo').val();
    $.ajax({
        type: "POST",
        async: false,
        url: "tenantmaster.aspx/BindFloorNo",
        data: '{"societycode":"' + societycode + '","bldgno":"' + bldgno + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbFloorNo').empty();
                $('#cmbFloorNo').append(data.d);
            }
        }
    });
}

function BindUnitNo() {
    var societycode = $('#cmbSocietyCode').val();
    var bldgno = $('#cmbBldgNo').val();
    var floorno = $("#cmbFloorNo").val();
    $.ajax({
        type: "POST",
        async: false,
        url: "tenantmaster.aspx/BindUnitNo",
        data: '{"societycode":"' + societycode + '","bldgno":"' + bldgno + '","floorno":"' + floorno + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbUnitNo').empty();
                $('#cmbUnitNo').append(data.d);
            }
        }
    });
}

function BindTenantType() {
    $.ajax({
        type: "POST",
        async: false,
        url: "tenantmaster.aspx/BindTenantType",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbTenantType').empty();
                $('#cmbTenantType').append(data.d);
            }
        }
    });
}

function BindAccountGroup() {
    $.ajax({
        type: "POST",
        async: false,
        url: "tenantmaster.aspx/BindAccountGroup",
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

function BindLedger() {
    var acgrpid = $('#cmbAcGrpCode').val();
    $.ajax({
        type: "POST",
        async: false,
        url: "tenantmaster.aspx/BindLedger",
        data: '{"acgrpid":"' + acgrpid + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbLedgerCode').empty();
                $('#cmbLedgerCode').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindCountry() {
    $.ajax({
        type: "POST",
        async: false,
        url: "tenantmaster.aspx/BindCountry",
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
        url: "tenantmaster.aspx/BindState",
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
        url: "tenantmaster.aspx/BindCity",
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

function LoadTenant(TenantId) {
    //$('#dataTable').empty();      
    $.ajax({
        type: "POST",
        async: false,
        url: "tenantmaster.aspx/LoadTenant",
        data: '{"tenantid":"' + TenantId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                if (TenantId === 0) {
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

                    $('#hdnTenantId').val(str_array[0]);
                    $('#cmbSocietyCode').val(str_array[1]);

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "tenantmaster.aspx/BindBldgNo",
                        data: '{"societycode":"' + str_array[1] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbBldgNo').empty();
                                $('#cmbBldgNo').append(data.d);
                                $('#cmbBldgNo').val(str_array[2]);
                            }
                        }
                    });

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "tenantmaster.aspx/BindFloorNo",
                        data: '{"societycode":"' + str_array[1] + '","bldgno":"' + str_array[2] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbFloorNo').empty();
                                $('#cmbFloorNo').append(data.d);
                                $('#cmbFloorNo').val(str_array[3]);
                            }
                        }
                    });

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "tenantmaster.aspx/BindUnitNo",
                        data: '{"societycode":"' + str_array[1] + '","bldgno":"' + str_array[2] + '","floorno":"' + str_array[3] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbUnitNo').empty();
                                $('#cmbUnitNo').append(data.d);
                                $('#cmbUnitNo').val(str_array[4]);
                            }
                        }
                    });

                    $('#txtTenantName').val(str_array[5]);
                    $('#cmbTenantType').val(str_array[6]);
                    $('#txtAddress').val(str_array[7]);
                    $('#txtLocation').val(str_array[8]);
                    $('#cmbCountry').val(str_array[11]);

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "unitmaster.aspx/BindState",
                        data: '{"countryid":"' + str_array[11] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbState').empty();
                                $('#cmbState').append(data.d);
                                $('#cmbState').val(str_array[10]);
                            }
                        }
                        //error: function (data) { }
                    });
                
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "unitmaster.aspx/BindCity",
                        data: '{"stateid":"' + str_array[10] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbCity').empty();
                                $('#cmbCity').append(data.d);
                                $('#cmbCity').val(str_array[9]);
                            }
                        }
                        //error: function (data) { }
                    });

                    $('#txtPinCode').val(str_array[12]);
                    $('#txtContact1').val(str_array[13]);
                    $('#txtContact2').val(str_array[14]);
                    $('#txtEmailId').val(str_array[15]);
                    $('#txtPanNo').val(str_array[16]);
                    AddList();
                }
            }
        }
        //error: function (data) { }
    });

}

function SaveTenant() {
    if (document.getElementById('cmbSocietyCode').value === "" || document.getElementById('cmbSocietyCode').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Society");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbBldgNo').value === "" || document.getElementById('cmbBldgNo').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Building Number");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbFloorNo').value === "" || document.getElementById('cmbFloorNo').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Floor Number");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbUnitNo').value === "" || document.getElementById('cmbUnitNo').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select unit no");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbTenantType').value === "" || document.getElementById('cmbTenantType').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Tenant Type");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbAcGrpCode').value === "" || document.getElementById('cmbAcGrpCode').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Account Group");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbLedgerCode').value === "" || document.getElementById('cmbLedgerCode').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Ledger");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtTenantName').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Tenant's Name.");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtAddress').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Society's Address.");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtLocation').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Location");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbCountry').value === "" || document.getElementById('cmbCountry').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select a Country.");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbState').value === "" || document.getElementById('cmbState').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select a State.");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbCity').value === "" || document.getElementById('cmbCity').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select a City.");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtPinCode').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter the Pincode.");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtContact1').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter the Mobile No.");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtPanNo').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Pan No.");
        $('#myModal').modal('show');
        return;
    }

    var tenantid = $('#hdnTenantId').val();
    var societycode = $('#cmbSocietyCode').val();
    var bldgno = $('#cmbBldgNo').val();
    var floorno = $('#cmbFloorNo').val();
    var unitno = $('#cmbUnitNo').val();
    var acgrpcode = $('#cmbAcGrpCode').val();
    var ledgercode = $('#cmbLedgerCode').val();
    var tenantname = $('#txtTenantName').val();
    var desc = $('#txtDesc').val();
    var tenanttype = $('#cmbTenantType').val();
    var address = $('#txtAddress').val();
    var location = $('#txtLocation').val();
    var country = $('#cmbCountry').val();
    var state = $('#cmbState').val();
    var city = $('#cmbCity').val();
    var pincode = $('#txtPinCode').val();
    var contact1 = $('#txtContact1').val();
    var contact2 = $('#txtContact2').val();
    var emailid = $('#txtEmailId').val();
    var panno = $('#txtPanNo').val();
    //alert(yourArray);
    $.ajax({
        type: "POST",
        async: false,
        url: "tenantmaster.aspx/SaveTenant",
        data: '{"tenantid":"' + tenantid + '","societycode":"' + societycode + '","bldgno":"' + bldgno + '","floorno":"' + floorno + '","unitno":"' + unitno + '","acgrpcode":"' + acgrpcode + '","ledgercode":"' + ledgercode + '","tenantname":"' + tenantname + '","tenantdesc":"' + desc + '","tenanttype":"' + tenanttype + '","address":"' + address + '","location":"' + location + '","city":"' + city + '","state":"' + state + '","country":"' + country + '","pincode":"' + pincode + '","contact1":"' + contact1 + '","contact2":"' + contact2 + '","emailid":"' + emailid + '","panno":"' + panno + '"}',
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
                    LoadTenant(0);
                    $('#listing').removeClass('hide');
                    $('#entryform').addClass('hide');
                }
                else {
                    //alert(str_array[1]);                   
                    $('#lblMessage').empty();
                    $('#lblMessage').append(str_array[1]);
                    $('#myModal').modal('show');
                }
                //location.reload();
                ResetControls();
            }
        },
        error: function (data) {
            alert(data.d);
        }
        //error: function (data) { }
    });
}

function ResetControls() {

    $('#hdnTenantId').val('0');
    $('#cmbSocietyCode').val('0');
    $('#cmbBldgNo').val('');
    $('#cmbFloorNo').val('');
    $('#cmbUnitNo').val('');
    $('#txtTenantName').val('');
    $('#cmbTenantType').val('0');
    $('#txtAddress').val('');
    $('#txtLocation').val('');
    $('#cmbCity').val('');
    $('#cmbState').val('');
    $('#cmbCountry').val('');
    $('#txtPinCode').val('');
    $('#txtContact1').val('');
    $('#txtContact2').val('');
    $('#txtEmailId').val('');
    $('#txtPanNo').val('');
}


function DeleteRecord(TenantId) {
    if (confirm("Do you really want to delete the record?")) {

        if (TenantId !== 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: "tenantmaster.aspx/DeleteTenant",
                data: '{"tenantid":"' + TenantId + '"}',
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

function GetOwner() {
    var unitno = $('#cmbUnitNo').val();
    var tenanttype = $('#cmbTenantType').val();
    $.ajax({
        type: "POST",
        async: false,
        url: "tenantmaster.aspx/GetOwner",
        data: '{"unitno":"' + unitno + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                if (tenanttype == 1) {
                    var str = data.d;
                    var str_array = str.split('|');

                    for (var i = 0; i < str_array.length; i++) {
                        str_array[i] = str_array[i].replace(/^\s*/, "").replace(/\s*$/, "");
                    }
                    $('#txtTenantName').val(str_array[8]);
                    $('#txtAddress').val(str_array[9]);
                    $('#txtLocation').val(str_array[10]);
                    $('#cmbCountry').val(str_array[13]);

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "tenantmaster.aspx/BindState",
                        data: '{"countryid":"' + str_array[13] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbState').empty();
                                $('#cmbState').append(data.d);
                                $('#cmbState').val(str_array[12]);
                            }
                        }
                    });

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "tenantmaster.aspx/BindCity",
                        data: '{"stateid":"' + str_array[12] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbCity').empty();
                                $('#cmbCity').append(data.d);
                                $('#cmbCity').val(str_array[11]);
                            }
                        }
                    });

                    $('#txtPinCode').val(str_array[14]);
                    $('#txtContact1').val(str_array[15]);
                    $('#txtContact2').val(str_array[16]);
                    $('#txtEmailId').val(str_array[17]);
                    $('#txtPanNo').val(str_array[18]);
                }
                else {
                    $('#txtTenantName').val('');
                    $('#cmbTenantType').val('2');
                    $('#txtAddress').val('');
                    $('#txtLocation').val('');
                    $('#cmbCity').val('');
                    $('#cmbState').val('');
                    $('#cmbCountry').val('');
                    $('#txtPinCode').val('');
                    $('#txtcontact1').val('');
                    $('#txtcontact2').val('');
                    $('#txtEmailId').val('');
                    $('#txtPanNo').val('');
                }
            }
        }
    });
}