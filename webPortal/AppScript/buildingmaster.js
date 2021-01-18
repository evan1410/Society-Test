$(document).ready(function () {
    ShowList();
    $('#hdnBldgId').val('0');
    LoadBuilding(0);
    BindSocietyName();
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
        url: "buildingmaster.aspx/BindSocietyName",
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

function LoadBuilding(BldgId) {
    //$('#dataTable').empty();      
    $.ajax({
        type: "POST",
        async: false,
        url: "buildingmaster.aspx/LoadBuilding",
        data: '{"bldgid":"' + BldgId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                if (BldgId === 0) {
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

                    $('#hdnBldgId').val(str_array[0]);
                    $('#cmbSocietyCode').val(str_array[1]);
                    $('#txtBldgNo').val(str_array[2]);
                    $('#txtTotalFloor').val(str_array[3]);
                    $('#txtTotalUnit').val(str_array[4]);
                    AddList();
                }
            }
        }
        //error: function (data) { }
    });

}

function SaveBuilding() {

    if (document.getElementById('cmbSocietyCode').value === "" || document.getElementById('cmbSocietyCode').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Society");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtBldgNo').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter building number");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtTotalFloor').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter total number of floors");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtTotalUnit').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter total number of flats");
        $('#myModal').modal('show');
        return;
    }

    var bldgid = $('#hdnBldgId').val();
    var societycode = $('#cmbSocietyCode').val();
    var bldgno = $('#txtBldgNo').val();
    var totalfloor = $('#txtTotalFloor').val();
    var totalunit = $('#txtTotalUnit').val();

    //alert(yourArray);
    $.ajax({
        type: "POST",
        async: false,
        url: "buildingmaster.aspx/SaveBuilding",
        data: '{"bldgid":"' + bldgid + '","societycode":"' + societycode + '","bldgno":"' + bldgno + '","totalfloor":"' + totalfloor + '","totalunit":"' + totalunit + '"}',
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
                    LoadBuilding(0);
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
    $('#hdnBldgId').val('0');
    $('#cmbSocietyCode').val('');
    $('#txtBldgNo').val('');
    $('#txtTotalFloor').val('');
    $('#txtTotalUnit').val('');
}


function DeleteRecord(BldgId) {
    if (confirm("Do you really want to delete the record?")) {

        if (BldgId !== 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: "buildingmaster.aspx/DeleteBuilding",
                data: '{"bldgid":"' + BldgId + '"}',
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
                },
                error: function (data) {
                    alert(data.d);
                }
            });
        }
    }
}