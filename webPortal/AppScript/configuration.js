$(document).ready(function () {
    ShowList();
    $('#hdnConfigId').val('0');
    LoadConfiguration(0);
    BindCategory();
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

function BindCategory() {
    $.ajax({
        type: "POST",
        async: false,
        url: "configuration.aspx/BindCategory",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbCategory').empty();
                $('#cmbCategory').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function BindValueType() {
    var category = $('#cmbCategory').val();
    $.ajax({
        type: "POST",
        async: false,
        url: "configuration.aspx/BindValueType",
        data: '{"category":"' + category + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#cmbValueType').empty();
                $('#cmbValueType').append(data.d);
            }
        }
        //error: function (data) { }
    });
}

function LoadConfiguration(Configid) {
    $.ajax({
        type: "POST",
        async: false,
        url: "configuration.aspx/LoadConfiguration",
        data: '{"id":"' + Configid + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                if (Configid === 0) {
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
                    $('#hdnConfigId').val(str_array[0]);
                    $('#cmbCategory').val(str_array[1]);
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "configuration.aspx/BindValueType",
                        data: '{"category":"' + str_array[1] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d !== '') {
                                $('#cmbValueType').empty();
                                $('#cmbValueType').append(data.d);
                                $('#cmbValueType').val(str_array[2]);
                            }
                        }
                        //error: function (data) { }
                    });
                    
                    $('#txtRate').val(str_array[3]);
                    $('#txtDueDate').val(str_array[4]);
                    AddList();
                }
            }
        }
        //error: function (data) { }
    });
}

function SaveConfiguration() {

    if (document.getElementById('cmbCategory').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select Category");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('cmbValueType').value === "" || document.getElementById('cmbValueType').value === "0") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Select ValueType");
        $('#myModal').modal('show');
        return;
    }
    if (document.getElementById('txtRate').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Rate");
        $('#myModal').modal('show');
        return;
    }

    if (document.getElementById('txtDueDate').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter DueDate");
        $('#myModal').modal('show');
        return;
    }

    var id = $('#hdnConfigId').val();
    var category = $('#cmbCategory').val();
    var valuetype = $('#cmbValueType').val();
    var rate = $('#txtRate').val();
    var duedate = $('#txtDueDate').val();

    //alert(yourArray);
    $.ajax({
        type: "POST",
        async: false,
        url: "configuration.aspx/SaveConfiguration",
        data: '{"id":"' + id + '","category":"' + category + '","valuetype":"' + valuetype + '","rate":"' + rate + '","duedate":"' + duedate + '"}',
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
                    LoadConfiguration(0);
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
    $('#hdnConfigId').val('0');
    $('#cmbCategory').val('');
    $('#cmbValuetype').val('');
    $('#txtRate').val('');
    $('#txtDueDate').val('');
}


function DeleteRecord(ConfigId) {
    if (confirm("Do you really want to delete the record?")) {

        if (ConfigId !== 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: "configuration.aspx/DeleteConfiguration",
                data: '{"id":"' + ConfigId + '"}',
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
