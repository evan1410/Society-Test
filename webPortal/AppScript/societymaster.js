$(document).ready(function () {
    ShowList();
    $('#hdnSocietyId').val('0');
    LoadSociety(0);
    BindSocietyType();
    BindCountry();
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

function BindSocietyType() {
    $.ajax({
        type: "POST",
        async: false,
        url: "societymaster.aspx/BindSocietyType",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbSocietyType').empty();
                $('#cmbSocietyType').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindCountry() {
    $.ajax({
        type: "POST",
        async: false,
        url: "societymaster.aspx/BindCountry",
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
        url: "societymaster.aspx/BindState",
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
        url: "societymaster.aspx/BindCity",
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


function LoadSociety(SocietyId) {
    //$('#dataTable').empty();      
    $.ajax({
        type: "POST",
        async: false,
        url: "societymaster.aspx/LoadSociety",
        data: '{"SocietyId":"' + SocietyId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                if (SocietyId === 0) {
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
                    $('#hdnSocietyId').val(str_array[0]);
                    $('#txtSocietyCode').val(str_array[1]);
                    $('#txtSocietyName').val(str_array[2]);
                    $('#cmbSocietyType').val(str_array[3]);
                    $('#txtRegNo').val(str_array[4]);
                    $('#txtRegDate').val(str_array[5]);
                    $('#txtPanNo').val(str_array[6]);
                    $('#txtContactPerson').val(str_array[7]);
                    $('#txtContact1').val(str_array[8]);
                    $('#txtContact2').val(str_array[9]);
                    $('#txtMailId').val(str_array[10]);
                    $('#txtAddress').val(str_array[11]);
                    $('#txtLocation').val(str_array[12]);
                    $('#cmbCountry').val(str_array[15]);
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "societymaster.aspx/BindState",
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
                        url: "societymaster.aspx/BindCity",
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
                    $('#txtTotalBldg').val(str_array[17]);
                    AddList();
                }
            }
        }
        //error: function (data) { }
    });

}

function SaveSociety() {

    if (document.getElementById('txtSocietyCode').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Society's Code");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtSocietyName').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Society's Name");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbSocietyType').value === "" || document.getElementById('cmbSocietyType').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Society Type");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtTotalBldg').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Number of Buildings/Wings");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtPanNo').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Society's Pan card No");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtRegNo').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Registration No.");
        $('#myModal').modal('show');
        return;
    }
    if (document.getElementById('txtRegDate').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Registration Date.");
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
        $('#lblMessage').append("Select a Country");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbState').value === "" || document.getElementById('cmbState').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select a State");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbCity').value === "" || document.getElementById('cmbCity').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select a City");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtPinCode').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter the Pincode");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtContactPerson').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter name of the Contact Person.");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtContact1').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter the Mobile No.");
        $('#myModal').modal('show');
        return;
    }
    
    var societyid = $('#hdnSocietyId').val();
    var societycode = $('#txtSocietyCode').val();
    var societyname = $('#txtSocietyName').val();
    var societytype = $('#cmbSocietyType').val();
    var regno = $('#txtRegNo').val();
    var reddate = $('#txtRegDate').val();
    var panno = $('#txtPanNo').val();
    var contactperson = $('#txtContactPerson').val();
    var contact1 = $('#txtContact1').val();
    var contact2 = $('#txtContact2').val();
    var emailid = $('#txtMailId').val();
    var address = $('#txtAddress').val();
    var location = $('#txtLocation').val();
    var city = $('#cmbCity').val();
    var state = $('#cmbState').val();
    var country = $('#cmbCountry').val();
    var pincode = $('#txtPinCode').val();
    var noofbldg = $('#txtTotalBldg').val();



    //alert(yourArray);
    $.ajax({
        type: "POST",
        async: false,
        url: "societymaster.aspx/SaveSociety",
        data: '{"societyid":"' + societyid + '","societycode":"' + societycode + '","societyname":"' + societyname + '","societytype":"' + societytype + '","regno":"' + regno + '","reddate":"' + reddate + '","panno":"' + panno + '","contactperson":"' + contactperson + '","contact1":"' + contact1 + '","contact2":"' + contact2 + '","emailid":"' + emailid + '","address":"' + address + '","location":"' + location + '","city":"' + city + '","state":"' + state + '","country":"' + country + '","pincode":"' + pincode + '","noofbldg":"' + noofbldg + '"}',        
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
                    LoadSociety(0);
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
    $('#hdnSocietyId').val('0');
    $('#txtSocietyCode').val('');
    $('#txtSocietyName').val('');
    $('#cmbSocietyType').val('0');
    $('#txtTotalBldg').val('');
    $('#txtPanNo').val('');
    $('#txtRegNo').val('');
    $('#txtRegDate').val('');
    $('#txtLocation').val('');
    $('#txtAddress').val('');
    $('#cmbCity').val('');
    $('#cmbState').val('');
    $('#txtPinCode').val('');
    $('#cmbCountry').val('0');
    $('#txtContactPerson').val('');
    $('#txtContact1').val('');
    $('#txtContact2').val('');
    $('#txtMailId').val('');
}


function DeleteRecord(SocietyId) {
    if (confirm("Do you really want to delete the record?")) {

        if (SocietyId !== 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: "societymaster.aspx/DeleteSociety",
                data: '{"SocietyId":"' + SocietyId + '"}',
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