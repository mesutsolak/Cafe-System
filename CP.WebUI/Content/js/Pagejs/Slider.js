function SliderList() {
    $.post("/SliderList", null, function (result) {
        $(".slider-list").html(result);
    });
}

$("#btnSliderAdd").on("click", function () {
    $("#SliderAddModal").modal("show");
});

$(document).on("click", ".SliderDelete", function () {

    var _id = $(this).data("id");

    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();

    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/SliderRemove",
        fullname: _fullname + " isimli slider",
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
