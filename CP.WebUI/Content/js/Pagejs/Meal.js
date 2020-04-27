
$(function () {
    TableConvertDataTables("tblProduct");
});


$("#ProductAdd").on("click", function () {
    $("#ProductAddModal").modal("show");
});

$("#ProductSave").on("click", function () {
    FormPost("frmProductAdd");
});

$("#ProductClear").on("click", function () {
    FormClear("frmProductAdd");
});

function returnPostProductAdd(data) {
    debugger;
    SweetAlert2(data.Icon, "Ekleme İşlemi",data.Description);
}

function SweetAlert2(erroricon, errortitle, errortext) {
    Swal.fire({
        icon: erroricon,
        title: errortitle,
        text: errortext,
        confirmButtonText: "Tamam"
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

