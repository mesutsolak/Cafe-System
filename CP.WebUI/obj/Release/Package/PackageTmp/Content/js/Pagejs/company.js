$(document).on("click", ".InformationDelete", function () {
    var _id = $(this).data("id");

    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();

    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/InformationRemove",
        fullname: "Bilgi" ,
        Method: CompanyList
    };

    RemoveBasicOperations(RemoveItems);

});

function CompanyList() {
    $.post("/BilgiList", null, function (result) {
        $(".information-list").html(result);
    });
}

$(document).on("click", ".InformationUpdate", function () {
    var _id = $(this).data("id");

    $.post("/BilgiGüncelle", { id: _id }, function (result) {
        $(".information-update").html(result);
        ModalShow('InformationUpdateModal');
    });

});