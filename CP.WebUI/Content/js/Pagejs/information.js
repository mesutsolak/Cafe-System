$("#btnInformationAdd").on("click", function () {
    if ($("#TdCompanyList").html() == null) {
        $("#InformationAddModal").modal("show");
    }
    else {
        SweetAlert("error", "Hata", "Bilgi Zaten Var");
    }
});

$(document).on("click", ".InformationDelete", function () {
    var _id = $(this).data("id");
    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();
    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/InformationRemove",
        fullname: _fullname + " isimli bilgi",
        Method: CategoryList
    };
    RemoveBasicOperations(RemoveItems);
});