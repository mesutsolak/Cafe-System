$(function () {

    setTimeout(function () {
        TableConvertDataTables("tblUser");
    }, 500);
});

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
    $.post("/UserUpdate", { id: _id }, function (result) {
        $(".modal-user-update").html(result);
        $('#UserUpdateModal').modal('show');
    });

});

function UserList() {
    $.get("/KullanıcıListele", null, function (result) {
        $(".User-body").html(result);
    });
}

$(document).on("click", "#UserUpdatesSave", function () {
    FormPost('frmUserUpdate');
});

$(document).on('click', '#UserUpdateClear', function () {
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

$(document).on("click", ".CancelConfirm", function () {
    var _id = $(this).data("id");
    var _Name = $(this).parent().parent().children(":nth-child(2)").html().trim();

    Swal.fire({
        title: 'Kaldırma İşlemi',
        text: _Name + " isimli kullanıcının onayı kaldırılsın mı ?",
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet',
        cancelButtonText: "Kapat"
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                async: false,
                url: "/OnayKaldırma",
                data: '{id:' + _id + '}',
                dataType: 'json',
                success: function (data) {
                    if (data.Description.includes("Başarıyla")) {
                        SweetAlert(data.Icon, "Kaldırma İşlemi", "Onay Başarıyla Silindi");
                        UserList();
                    }
                    else {
                        SweetAlert("error", "Kaldırma İşlemi", data.Description);
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert("error", ajaxOptions + "" + xhr.status + "" + thrownError);
                }
            });
        }
    });
});

$(document).on("click", ".TrueConfirm", function () {
    var _id = $(this).data("id");
    var _Name = $(this).parent().parent().children(":nth-child(2)").html().trim();

    Swal.fire({
        title: 'Onaylama İşlemi',
        text: _Name + " isimli kullanıcı onaylansın mı?",
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet',
        cancelButtonText: "Kapat"
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                async: false,
                url: "/OnaylaEkle",
                data: '{id:' + _id + '}',
                dataType: 'json',
                success: function (data) {
                    if (data.Description.includes("Başarıyla")) {
                        SweetAlert(data.Icon, "Onaylama İşlemi", data.Description);
                        UserList();
                    }
                    else {
                        SweetAlert("error", "Onaylama İşlemi", data.Description);
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert("error", ajaxOptions + "" + xhr.status + "" + thrownError);
                }
            });
        }
    });
});

$(document).on("click", ".UserRole", function () {

    var _id = $(this).data("id");
    $.post("/UserFindRole", { UserId: _id }, function (result) {
        $(".role-user-modal").html(result);
        ModalShow('RoleShowModal');
    });

});

$(document).on("click", "#RoleClear", function () {
    $("input:checkbox").prop('checked', false);
});