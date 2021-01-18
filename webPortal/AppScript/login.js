function signin() {
    if (document.getElementById('txtUsername').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Username");
        $('#myModal').modal('show');//$('#frmMessage').removeClass('hide');
        return;
    }

    if (document.getElementById('txtPassword').value === "") {
        $('#lblMessage').empty();
        $('#lblMessage').append("Enter Password");
        $('#myModal').modal('show');//$('#frmMessage').removeClass('hide');
        return;
    }

    var username = $('#txtUsername').val();
    var password = $('#txtPassword').val();

    $.ajax({
        type: "POST",
        url: "Login.aspx/signin",
        async: false,
        data: '{"username":"' + username + '","password":"' + password + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== '') {
                $('#lblMessage').empty();
                $('#lblMessage').append(data.d);
                $('#myModal').modal('show');//$('#frmMessage').removeClass('hide');
                //alert(data.d);
            }
            else {
                //$('#frmMessage').removeClass('hide');
                window.location = "dashboard.aspx";
                //alert('Login Sucessfully');
            }
        }
    });
}