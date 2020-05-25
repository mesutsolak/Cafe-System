function SliderList() {
    $.post("/SliderList", null, function (result) {
        $(".slider-list").html(result);
    });
}

$("#btnSliderAdd").on("click", function () {
    $("#SliderAddModal").modal("show");
});

//SliderAddModal