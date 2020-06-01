
function RoleList() {
    $.get("/RolList", null, function (result) {
        $(document).find(".role-body").html(result);
    });
}


$(document).on("click", ".RoleUpdate", function () {
    var _id = $(this).data("id");
    $.get("/RoleUpdate", { id: _id }, function (result) {
        $(".Role-Update-Modal").html(result);
        $(document).find('#RoleUpdateModal').modal('show');
    });
});


$(document).on("click", ".RoleDelete", function () {
    var _id = $(this).data("id");
    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();
    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/RemoveRole",
        fullname: _fullname + " isimli rol",
        Method: RoleList
    };
    RemoveBasicOperations(RemoveItems);
});

