$(function () {
    //RegisterFill();
});

$("#btnRegister").on("click", function () {
    $("#UserAddModal").modal("show");
});

function RegisterFill() {
    $.get("/Register", null, function (result) {
        $(".modal-register").html(result);
    });
}

$("#PasswordForget").on("click", function () {
    $("#PasswordModal").modal("show");
});

$("#PasswordClear").on("click", function () {
    FormClear('frmPasswordForget');
});

$("#PasswordSave").on("click", function () {
    FormPost('frmPasswordForget');
});

$("#UserSave").on("click", function () {
    FormPost('frmUserAdd');
});

$("#UserClear").on("click", function () {
    FormClear('frmUserAdd');
});

