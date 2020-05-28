$("#UserAdd").on("click", function () {
    $("#UserAddModal").modal('show');
});
$("#UserSave").on('click', function () {
    FormPost('frmUserAdd');
});

$('#UserClear').on('click', function () {
    FormClear('frmUserAdd')
});

$(document).on("click", ".UserUpdate", function () {
    var _id = $(this).data("id");
    $.get("/UserUpdate", { id: _id }, function (result) {
        $(".modal-user-update").html(result);
        $('#UserUpdateModal').modal('show');
    });

});

function UserList() {
    $.get("/KullanıcıListele", null, function (result) {
        $(".User-Body").html(result);
    }); 
}

$(document).on("click","#UserUpdatesSave", function () {
    FormPost('frmUserUpdate');
});

$(document).on('click','#UserUpdateClear', function () {
    FormClear('frmUserUpdate');
});

$(document).on('click', ".UserDelete", function () {
    var _id = $(this).data("id");
    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();
    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/RemoveUser",
        fullname: _fullname + " isimli kullanıcı",
        Method: UserList
    };
    RemoveBasicOperations(RemoveItems);
});

$(document).on("click", "#ImageView", function () {
    var _src = $(this).attr("src");

    if (_src.startsWith("/Content")) {
        SweetAlert("error", "Hata", "Resim Bulunamadı");
    }
    else {
        $("#ImgViewSrc").attr("src", _src);
        $("#ImageShowModal").modal("show");
    }

});