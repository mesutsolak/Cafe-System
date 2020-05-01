
$(function () {
    TableConvertDataTables("tblProduct");
    //ConvertCkEditor("ProductDetail", "tr");
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
        debugger;
        SweetAlert("error", "Hata", "Resim Bulunamadı");
    }
    else {
        $("#ImgViewSrc").attr("src", _src);
        $("#ImageShowModal").modal("show");
    }

});

function ProductList() {
    $.get("/ProductList", null, function (result) {
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
        },
        error: function (xhr) { // if error occured
            alert("Error occured.please try again" + xhr.statusText + xhr.responseText);
        },
    });


    //$.get("/ProductUpdate", , function (data) {
    //    $(".product-update-modal").html(data);
    //    $(document).find("#ProductUpdateModal").modal("show");
    //});
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


function SweetAlert2(erroricon, errortitle, errortext) {
    Swal.fire({
        icon: erroricon,
        title: errortitle,
        text: errortext
    })
}

/**
 * 
 * @param {string} _id Tablo Id'si
 * @returns {void}
 * Convert table to datatable
 */
function TableConvertDataTables(_id) {

    //bool dönücektir burda 
    /*
      Gelen id'ye sahip table datatable jquery'mi ? bunu kontrol ediyorsun eğer değilse çevir demiş olduk.Kontrol etmek
      her zaman hataları önler.
     Default olarak dil ingilizce ayarladır.Bunu Türkçeye çevirmek için ya localden ya da cdn yardımıyla json datası alınır.
    Çoklu silme işlemlerinde ya da herhangi bir tablo yapısında ilk sütunun order(sıralama) almasını istemeyebiliriz.Bu gibi durumlarda aşağıdaki kod bloğu kullanılmalıdır.Order ve columnDefs kullanilmalidir/
*/

    if (!$.fn.DataTable.isDataTable('#' + _id)) {
        $("#" + _id).DataTable({

            "language": {
                "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Turkish.json",
            },
            order: [],
            columnDefs: [
                { "orderable": false, "targets": [0] }
            ]
        });
    }
}

