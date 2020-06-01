$(function () {
    setTimeout(function () {
        TableConvertDataTables("tblcategory");
    }, 750);
    NiceScrool(new ScroolModel("modal-body", "10px", "#A5A5A5"))
});

$("#CategoryAdd").on("click", function () {
    $("#CategoryAddModal").modal("show");
});

$("#CategorySave").on("click", function () {
    FormPost('frmCategoryAdd');
});

$("#CategoryClear").on("click", function () {
    FormClear('frmCategoryAdd');
});

$(document).on("click", ".categoryUpdate", function () {
    var _id = $(this).data("id");
    $.get("/KategoriUpdate", { id: _id }, function (result) {
        $(".modal-update").html(result);
        $(document).find('#CategoryUpdateModal').modal('show');
    });
});


function CategoryList() {
    $.get('/KategoriList', null, function (result) {
        $(".category-body").html(result);
    });
}

$(document).on("click", "#CategoryUpdateSave", function () {
    FormPost('frmCategoryUpdate');
});

$(document).on("click", "#CategoryUpdateClear", function () {
    FormClear('frmCategoryUpdate');
});
$(document).on("click", ".categoryDelete", function () {
    var _id = $(this).data("id");
    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();
    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/RemoveCategory",
        fullname: _fullname + " isimli ürün",
        Method: CategoryList
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

