$("#btnContactAdd").on("click", function () {
    var _td = $(document).find("#TdContactList").html().trim().length;
    if (_td <= 0) {
        $("#ContactAddModal").modal("show");
    }
    else {
        SweetAlert("error", "Hata", "Zaten iletişim eklenmiş.");
    }
});

$(document).on("click", ".btnContactDelete", function () {
    var _id = $(this).data("id");
    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();
    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/İletişimSil",
        fullname: "İletişim",
        Method: ContactList
    };
    RemoveBasicOperations(RemoveItems);
});

function ContactList() {
    $.post("/İletişimListele", null, function (result) {
        $(".contact-list").html(result);
    });
}



$(document).on("click", ".btnContactUpdate", function () {
    var _id = $(this).data("id");
    $.post("/ContactUpdate", { id: _id }, function (result) {
        $(".contact-update").html(result);
        ModalShow("ContactUpdateModal");
    });
});