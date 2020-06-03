$("#ReportSelect").on("change", function () {
    if ($("#ReportSelect option:selected").text() == "Rapor Seçiniz") {
        return;
    }
    else {
        var _string = $("#ReportSelect option:selected").attr("value");
        $.post("/RaporList", { name: _string }, function (result) {
            debugger;
            $(".report-body").html(result);
        });
    }
});
