    $(document).ready(function () {
    ShowList();
    $('#hdnUnitId').val('0');
    LoadUnit(0);
    BindCountry();
    BindSocietyName();
    BindAccountGroup();
    BindOccupiedBy();
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
        url: "unitmaster.aspx/BindSocietyName",
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
        url: "unitmaster.aspx/BindBldgNo",
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
        url: "unitmaster.aspx/BindFloorNo",
        data: '{"societycode":"' + societycode + '","bldgno":"' + bldgno + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbFloorNo').empty();
                $('#cmbFloorNo').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindUnitType() {
    var floorno = $('#cmbFloorNo').val();
    $.ajax({
        type: "POST",
        async: false,
        url: "unitmaster.aspx/BindUnitType",
        data: '{"floorno":"' + floorno + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbUnitType').empty();
                $('#cmbUnitType').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindOccupiedBy() {
    var unittype = $('#cmbUnitType').val();
    $.ajax({
        type: "POST",
        async: false,
        url: "unitmaster.aspx/BindOccupiedBy",
        data: '{"unittype":"' + unittype + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbOccupiedBy').empty();
                $('#cmbOccupiedBy').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindAccountGroup() {
    $.ajax({
        type: "POST",
        async: false,
        url: "unitmaster.aspx/BindAccountGroup",
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
        url: "unitmaster.aspx/BindCountry",
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
        url: "unitmaster.aspx/BindState",
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
        url: "unitmaster.aspx/BindCity",
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


function LoadUnit(UnitId) {
    //$('#dataTable').empty();      
    $.ajax({
        type: "POST",
        async: false,
        url: "unitmaster.aspx/LoadUnit",
        data: '{"UnitId":"' + UnitId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                if (UnitId === 0) {
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
                    $('#hdnUnitId').val(str_array[0]);
                    $('#cmbSocietyCode').val(str_array[1]);

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "unitmaster.aspx/BindBldgNo",
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
                        url: "unitmaster.aspx/BindUnitType",
                        data: '{"floorno":"' + str_array[3] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbUnitType').empty();
                                $('#cmbUnitType').append(data.d);
                                $('#cmbUnitType').val(str_array[5]);
                            }
                        }
                    });

                    $('#txtUnitNo').val(str_array[4]);
                    $('#txtUnitArea').val(str_array[6]);
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "unitmaster.aspx/BindOccupiedBy",
                        data: '{"unittype":"' + str_array[5] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbOccupiedBy').empty();
                                $('#cmbOccupiedBy').append(data.d);
                                $('#cmbOccupiedBy').val(str_array[7]);
                            }
                        }
                    });

                    $('#cmbAcGrpCode').val(str_array[8]);
                    $('#txtLedgerCode').val(str_array[9]);
                    $('#txtUnitOwner').val(str_array[10]);
                    $('#txtAddress').val(str_array[11]);
                    $('#txtLocation').val(str_array[12]);
                    $('#cmbCountry').val(str_array[15]);
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "unitmaster.aspx/BindState",
                        data: '{"countryid":"' + str_array[15] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbState').empty();
                                $('#cmbState').append(data.d);
                                $('#cmbState').val(str_array[14]);
                            }
                        }
                        //error: function (data) { }
                    });
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "unitmaster.aspx/BindCity",
                        data: '{"stateid":"' + str_array[14] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbCity').empty();
                                $('#cmbCity').append(data.d);
                                $('#cmbCity').val(str_array[13]);
                            }
                        }
                        //error: function (data) { }
                    });

                    $('#txtPinCode').val(str_array[16]);
                    $('#txtContact1').val(str_array[17]);
                    $('#txtContact2').val(str_array[18]);
                    $('#txtEmailId').val(str_array[19]);
                    $('#txtPanNo').val(str_array[20]);
                    AddList();
                }
            }
        }
        //error: function (data) { }
    });

}

function SaveUnit() {

    if (document.getElementById('cmbSocietyCode').value === "" || document.getElementById('cmbSocietyCode').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Society's Name");
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
        $('#lblMessage').append("Select Floor No");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbUnitType').value === "" || document.getElementById('cmbUnitType').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Unit Type");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtUnitNo').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Unit Number");
        $('#myModal').modal('show');
        return;
    }
    if (document.getElementById('txtUnitArea').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Unit Area");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbOccupiedBy').value === "" || document.getElementById('cmbOccupiedBy').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Occupied By.");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbAcGrpCode').value === "" || document.getElementById('cmbAcGrpCode').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Account Group");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtLedgerCode').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter ledger Code");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtUnitOwner').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Owner's Name");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtAddress').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Address");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtLocation').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append('Enter the location');
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
        $('#lblMessage').append("Enter the Pan No.");
        $('#myModal').modal('show');
        return;
    }

    var unitid = $('#hdnUnitId').val();
    var societycode = $('#cmbSocietyCode').val();
    var bldgno = $('#cmbBldgNo').val();
    var floorno = $('#cmbFloorNo').val();
    var unitno = $('#txtUnitNo').val();
    var unittype = $('#cmbUnitType').val();
    var unitarea = $('#txtUnitArea').val();
    var occupiedby = $('#cmbOccupiedBy').val();
    var acgrpcode = $('#cmbAcGrpCode').val();
    var ledgercode = $('#txtLedgerCode').val();
    var unitowner = $('#txtUnitOwner').val();
    var address = $('#txtAddress').val();
    var location = $('#txtLocation').val();
    var city = $('#cmbCity').val();
    var state = $('#cmbState').val();
    var country = $('#cmbCountry').val();
    var pincode = $('#txtPinCode').val();
    var contact1 = $('#txtContact1').val();
    var contact2 = $('#txtContact2').val();
    var emailid = $('#txtEmailId').val();
    var panno = $('#txtPanNo').val();
    $.ajax({
        type: "POST",
        async: false,
        url: "unitmaster.aspx/SaveUnit",
        data: '{"unitid": "' + unitid + '","societycode":"' + societycode + '","bldgno": "' + bldgno + '","floorno": "' + floorno + '","unitno": "' + unitno + '","unittype": "' + unittype + '","unitarea": "' + unitarea + '","occupiedby": "' + occupiedby + '","acgrpcode": "' + acgrpcode + '","ledgercode": "' + ledgercode + '","unitowner": "' + unitowner + '","address": "' + address + '","location": "' + location + '","city": "' + city + '","state": "' + state + '","country": "' + country + '","pincode": "' + pincode + '","contact1": "' + contact1 + '","contact2": "' + contact2 + '","emailid": "' + emailid + '","panno": "' + panno + '"}',
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
                    LoadUnit(0);
                    $('#listing').removeClass('hide');
                    $('#entryform').addClass('hide');
                }
                else {
                    //alert(str_array[1]);                   
                    $('#lblMessage').empty();
                    $('#lblMessage').append(str_array[1]);
                    $('#frmMessage').removeClass('hide');
                }
                //location.reload();
                ResetControls();
            }
        }
        //error: function (data) { }
    });

}

function ResetControls() {
    $('#hdnUnitId').val('0');
    $('#cmbSocietyCode').val('0');
    $('#cmbBldgNo').val('');
    $('#cmbFloorNo').val('');
    $('#cmbUnitType').val('');
    $('#txtUnitNo').val('');
    $('#txtUnitArea').val('');
    $('#cmbOccupiedBy').val('0');
    $('#cmbAcGrpCode').val('');
    $('#txtLedgerCode').val('');
    $('#txtUnitOwner').val('');
    $('#txtAddress').val('');
    $('#txtLocation').val('');
    $('#cmbCity').val('');
    $('#cmbState').val('');
    $('#cmbCountry').val('0');
    $('#txtPinCode').val('');
    $('#txtContact1').val('');
    $('#txtContact2').val('');
    $('#txtEmailId').val('');
    $('#txtPanNo').val('');
}


function DeleteRecord(UnitId) {
    if (confirm("Do you really want to delete the record?")) {

        if (UnitId !== 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: "unitmaster.aspx/DeleteUnit",
                data: '{"unitid":"' + UnitId + '"}',
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