$(document).ready(function () {
    ShowList();
    LoadUser(0);
    BindUserGroup();
    BindStaffType();
    BindDesignation();
    $('#hdnUserID').val('0');

});

function ShowList() {

    $('#listing').removeClass('hide');
    $('#entryform').addClass('hide');

}

function AddList() {
    $('#listing').addClass('hide');
    $('#entryform').removeClass('hide');
}

function BindUserGroup() {
    $.ajax({
        type: "POST",
        async: false,
        url: "user.aspx/BindUserGroup",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbGroup').empty();
                $('#cmbGroup').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindStaffType() {
    $.ajax({
        type: "POST",
        async: false,
        url: "user.aspx/BindStaffType",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbStaffType').empty();
                $('#cmbStaffType').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindDesignation() {
    $.ajax({
        type: "POST",
        async: false,
        url: "user.aspx/BindDesignation",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbDesignation').empty();
                $('#cmbDesignation').append(data.d);
            }
        }
        //error: function (data) { }
    });
}


function LoadUser(userid) {
    //$('#dataTable').empty();    
    $.ajax({
        type: "POST",
        async: false,
        url: "user.aspx/LoadUser",
        data: '{"userid":"' + userid + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                if (userid === 0) {
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

                    $('#hdnUserID').val(str_array[0]);
                    $('#cmbGroup').val(str_array[1]);
                    $('#txtFirstName').val(str_array[2]);
                    $('#txtLastName').val(str_array[3]);
                    $('#cmbStaffType').val(str_array[4]);
                    $('#cmbDesignation').val(str_array[5]);
                    $('#txtMobile').val(str_array[6]);
                    $('#txtEmail').val(str_array[7]);
                    $('#txtPassword').val(str_array[8]);
                    $('#txtConPassword').val(str_array[8]);
                    AddList();
                }
            }
        }
        //error: function (data) { }
    });

}

function SaveUser() {

    if ($('#cmbGroup').val() === '0') {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select User Group");
        $('#frmMessage').removeClass('hide');
        return;
    }

    if (document.getElementById('txtFirstName').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter First Name");
        $('#frmMessage').removeClass('hide');
        return;
    }

    if (document.getElementById('txtLastName').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Last Name");
        $('#frmMessage').removeClass('hide');
        return;
    }

    if (document.getElementById('cmbStaffType').value === '0') {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Staff Type");
        $('#frmMessage').removeClass('hide');
        return;
    }

    if (document.getElementById('txtMobile').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Mobile Number");
        $('#frmMessage').removeClass('hide');
        return;
    }

    if (document.getElementById('txtEmail').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Email");
        $('#frmMessage').removeClass('hide');
        return;
    }

    if (document.getElementById('txtPassword').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Password");
        $('#frmMessage').removeClass('hide');
        return;
    }

    if (document.getElementById('txtConPassword').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Confirm Password");
        $('#frmMessage').removeClass('hide');
        return;
    }

    if (document.getElementById('txtPassword').value !== document.getElementById('txtConPassword').value) {
        $('#lblMessage').empty();
        $('#lblMessage').append("Password and Confirm Password does not match");
        $('#frmMessage').removeClass('hide');
        return;
    }

    var userid = $('#hdnUserID').val();
    var groupcode = $('#cmbGroup').val();
    var firstname = $('#txtFirstName').val();
    var lastname = $('#txtLastName').val();
    var stafftype = $('#cmbStaffType').val();
    var designation = $('#cmbDesignation').val();
    var mobile = $('#txtMobile').val();
    var emailid = $('#txtEmail').val();
    var password = $('#txtConPassword').val();

    //alert(yourArray);
    $.ajax({
        type: "POST",
        async: false,
        url: "user.aspx/SaveUser",
        data: '{"userid": "' + userid + '","groupid": "' + groupid + '","firstname": "' + firstname + '","lastname": "' + lastname + '","stafftype": "' + stafftype + '","designation": "' + designation + '","mobile": "' + mobile + '","emailid": "' + emailid + '","password": "' + password + '"}',
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
                    $('#frmMessage').removeClass('hide');
                }                
                ResetControls();
                location.reload();
            }
        }
        //error: function (data) { }
    });
}

function ResetControls() {
    $('#hdnUserID').val('0');
    $('#cmbGroup').val('0');
    $('#txtFirstName').val('');
    $('#txtLastName').val('');
    $('#cmbStaffType').val('0');
    $('#cmbDesignation').val('0');
    $('#txtMobile').val('');
    $('#txtEmail').val('');
    $('#txtPassword').val('');
    $('#txtConPassword').val('');
}


function DeleteRecord(userid) {
    if (confirm("Do you really want to delete the record?")) {

        if (userid !== 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: "user.aspx/DeleteUser",
                data: '{"userid":"' + userid + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d !== '') {
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
                        ResetControls();
                        location.reload();
                    }
                }
                //error: function (data) { }
            });
        }
    }
}