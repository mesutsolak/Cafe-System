function SliderList() {
    $.post("/SliderList", null, function (result) {
        $(".slider-list").html(result);
    });
}

$(function () {
    setTimeout(function () {
        TableConvertDataTables("tblSlider");
    }, 750);
    NiceScrool(new ScroolModel("modal-body", "10px", "#A5A5A5"))
});

$("#btnSliderAdd").on("click", function () {
    $("#SliderAddModal").modal("show");
});

$(document).on("click", ".SliderDelete", function () {

    var _id = $(this).data("id");

    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();

    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/InformationRemove",
        fullname: _fullname + " isimli bilgi",
        Method: SliderList
    };

    RemoveBasicOperations(RemoveItems);
});

$(document).on("click", ".SliderUpdate", function () {
    //slider - update
    var _id = $(this).data("id");

    $.post("/SliderUpdate", { id: _id }, function (result) {
        $(".slider-update").html(result);
        ModalShow('SliderUpdateModal');
    });
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