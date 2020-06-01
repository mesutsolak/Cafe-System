function HomePageList() {
    $.post("/AnasayfaList", null, function (result) {
        $(".home-information-list").html(result);
    });
}


$(document).on("click", ".btnHomeListUpdate", function () {
    $.post("/AnasayfaGüncelle", null, function (result) {
        debugger;
        $(".home-information-update").html(result);
        ModalShow('HomePageUpdateModal');
    });

});

$(document).on("click", ".btnHomeListDelete", function () {
    var _id = $(this).data("id");

    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();

    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/HomeRemove",
        fullname: "Anasayfa bilgisi ",
        Method: HomePageList
    };

    RemoveBasicOperations(RemoveItems);

});


$("#btnHomeInformationAdd").on("click", function () {
    if ($("#tdHomeList").html().trim().length <= 0) {
        $("#HomePageAddModal").modal("show");
    }
    else {
        SweetAlert("error", "Hata", "Bilgi Zaten Var");
    }
});