
$(function () {
    setTimeout(function () {
        TableConvertDataTables("tblProduct");
    }, 750);
    //ConvertCkEditor("ProductDetail", "tr");
    ProductList();
    NiceScrool(new ScroolModel("modal-body", "10px", "#A5A5A5"))
});

$(document).ready(function () {
});


$(document).on("click", ".ProductDelete", function () {
    var _id = $(this).data("id");
    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();
    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/RemoveProduct",
        fullname: _fullname + " isimli ürün",
        Method: ProductList
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

function ProductList() {
    $.get("/ProductList", null, function (result) {
        debugger;
        $(document).find(".product-body").html(result);
    });
}


$("#ProductAdd").on("click", function () {
    $("#ProductAddModal").modal("show");
});

$(document).on("click", ".ProductUpdate", function () {
    var _id = $(this).data("id");

    $.ajax({
        type: 'POST',
        url: "/ProductUpdate",
        data: { id: _id },
        dataType: 'html',
        success: function (data) {
            $(".product-update-modal").html(data);
            $(document).find("#ProductUpdateModal").modal("show");
            NiceScrool(new ScroolModel("modal-product-update", "10px", "#A5A5A5"))
            //$(".modal-product-update").niceScroll({ cursorwidth: '10px', autohidemode: false, zindex: 999, cursorcolor: "#A5A5A5" });
        },
        error: function (xhr) { // if error occured
            alert("Error occured.please try again" + xhr.statusText + xhr.responseText);
        },
    });
});


$(document).on("click", "#ProductUpdateSave", function () {
    FormPost('frmProductUpdate')
});



$(document).on("click", "#ProductUpdateClear", function () {
    FormClear('frmProductUpdate');
});

$("#ProductSave").on("click", function () {
    FormPost("frmProductAdd");
});

$("#ProductClear").on("click", function () {
    FormClear("frmProductAdd");
});


$(document).on("click", ".product-detail", function () {
    var value = $(this).attr("value");
    $("#ProductDetailModal").modal("show");
    $(".product-detail-modals").html(value);
});

function SweetAlert2(erroricon, errortitle, errortext) {
    Swal.fire({
        icon: erroricon,
        title: errortitle,
        text: errortext
    })
}



