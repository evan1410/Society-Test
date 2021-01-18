$(document).ready(function () {
    ShowList();
    LoadUserRole(0);
    $('#hdnGroupID').val('0');

});

function ShowList() {    
    
    $('#listing').removeClass('hide');
    $('#entryform').addClass('hide');
    
}

function AddList() {
    $('#listing').addClass('hide');
    $('#entryform').removeClass('hide');
}

function LoadUserRole(groupid) {
    //$('#dataTable').empty();    
        $.ajax({
            type: "POST",
            async: false,
            url: "userrole.aspx/LoadUserRole",
            data: '{"groupid":"' + groupid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d !== '') {
                    if (groupid === 0) {
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

                        $('#hdnGroupID').val(str_array[0]);
                        $('#txtGroupCode').val(str_array[1]);
                        $('#txtGroupName').val(str_array[2]);
                        $('#txtGroupDesc').val(str_array[3]);
                        AddList();
                    }
                }
            }
            //error: function (data) { }
        });
    
}

function SaveUserRole() {

    if (document.getElementById('txtGroupCode').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter role code");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtGroupName').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter role name");
        $('#myModal').modal('show');
        return;
    }

    var groupid = $('#hdnGroupID').val();
    var groupcode = $('#txtGroupCode').val();
    var groupname = $('#txtGroupName').val();
    var groupdesc = $('#txtGroupDesc').val();

    //alert(yourArray);
    $.ajax({
        type: "POST",
        async: false,
        url: "userrole.aspx/SaveUserRole",
        data: '{"groupid":"' + groupid + '","groupcode":"' + groupcode + '","groupname":"' + groupname + '","groupdesc":"' + groupdesc + '"}',
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
                    LoadUserRole(0);
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
    $('#hdnGroupID').val('0');
    $('#txtGroupCode').val('');
    $('#txtGroupName').val('');
    $('#txtGroupDesc').val('');
}


function DeleteRecord(groupid) {
    if (confirm("Do you really want to delete the record?")) {
        
        if (groupid !== 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: "userrole.aspx/DeleteUserRole",
                data: '{"groupid":"' + groupid + '"}',
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
                            location.reload();
                        }

                        ResetControls();
                    }
                }
                //error: function (data) { }
            });
        }
    }
}