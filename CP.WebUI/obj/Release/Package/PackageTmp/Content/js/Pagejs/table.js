$(function () {
    setTimeout(function () {
        TableConvertDataTables("tblTable");
    }, 500);
    NiceScrool(new ScroolModel("modal-body", "10px", "#A5A5A5"))
});



function TableList() {
    $.get("/MasaList", null, function (result) {
        $(document).find(".table-body").html(result);
        setTimeout(function () {
            TableConvertDataTables("tblCampaign");
        }, 750);
    });
}


$(document).on("click", ".TableUpdate", function () {
    var _id = $(this).data("id");
    $.get("/MasaGüncelle", { id: _id }, function (result) {
        $(".modal-table-update").html(result);
        $(document).find('#TableUpdateModal').modal('show');
    });
});


$(document).on("click", ".TableDelete", function () {
    var _id = $(this).data("id");
    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();
    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/RemoveTable",
        fullname: _fullname + " numaralı masa",
        Method: TableList
    };
    RemoveBasicOperations(RemoveItems);
});

