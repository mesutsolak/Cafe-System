$("#btnInformationAdd").on("click", function () {
    if ($("#TdCompanyList").html().trim().length <= 0) {
        $("#InformationAddModal").modal("show");
    }
    else {
        SweetAlert("error", "Hata", "Bilgi Zaten Var");
    }
});

$(document).on("click", ".btnInformationDelete", function () {
    var _id = $(this).data("id");
    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();
    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/InformationRemove",
        fullname: _fullname + " isimli bilgi",
        Method: InformationList
    };
    RemoveBasicOperations(RemoveItems);
});

function InformationList() {
    $.post("/BilgiList", null, function (result) {
        $(".information-list").html(result);
    });
}


$(document).on("click", ".btnInformationUpdate", function () {
    var _id = $(this).data("id");

    $.post("/BilgiGüncelle", { id: _id }, function (result) {
        $(".information-update").html(result);
        ModalShow('InformationUpdateModal');
    });

});