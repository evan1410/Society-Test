$(document).ready(function () {
    ShowList();
    $('#hdnAcGrpId').val('0');
    LoadAccountGroup(0);
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

function LoadAccountGroup(AcGrpId) {
    //$('#dataTable').empty();
    $.ajax({
        type: "POST",
        async: false,
        url: "accountgroup.aspx/LoadAccountGroup",
        data: '{"acgrpid":"' + AcGrpId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                if (AcGrpId === 0) {
                    $('#dataTable').empty();
                    $('#dataTable').append(data.d);
                    $('#dataTable').DataTable();
                    ShowList();
                }
                else {
                    var str = data.d;
                    var str_array = str.split('|');

                    for (var i = 0; i < str_array.length; i++) {
                        str_array[i] = str_array[i].replace(/^\s/, "").replace(/\s$/, "");
                    }

                    $('#hdnAcGrpId').val(str_array[0]);
                    $('#txtAcGrpCode').val(str_array[1]);
                    $('#txtAcGrpName').val(str_array[2]);
                    $('#txtAcGrpDesc').val(str_array[3]);
                    AddList();
                }
            }
        }
        //error: function (data) { }
    });
}


function SaveAccountGroup() {

    if (document.getElementById('txtAcGrpCode').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Account Group Code");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtAcGrpName').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Account Group Name");
        $('#myModal').modal('show');
        return;
    }

    var acgrpid = $('#hdnAcGrpId').val();
    var acgrpcode = $('#txtAcGrpCode').val();
    var acgrpname = $('#txtAcGrpName').val();
    var acgrpdesc = $('#txtAcGrpDesc').val();

    //alert(yourArray);
    $.ajax({
        type: "POST",
        async: false,
        url: "accountgroup.aspx/SaveAccountGroup",
        data: '{"acgrpid":"' + acgrpid + '","acgrpcode":"' + acgrpcode + '","acgrpname":"' + acgrpname + '","acgrpdesc":"' + acgrpdesc + '"}',
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
                    LoadAccountGroup(0);
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
        }
        //error: function (data) { }
    });
}

function ResetControls() {
    $('#hdnAcgrpId').val('0');
    $('#txtAcGrpCode').val('');
    $('#txtAcGrpName').val('');
    $('#txtAcGrpDesc').val('');
}


function DeleteRecord(AcGrpId) {
    if (confirm("Do you really want to delete the record?")) {
        if (AcGrpId !== 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: "accountgroup.aspx/DeleteAccountGroup",
                data: '{"acgrpid":"' + AcGrpId + '"}',
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