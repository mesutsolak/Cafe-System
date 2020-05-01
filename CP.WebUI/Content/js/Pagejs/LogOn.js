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