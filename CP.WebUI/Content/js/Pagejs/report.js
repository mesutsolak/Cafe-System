$("#ReportSelect").on("change", function () {
    if ($("#ReportSelect option:selected").text() == "Rapor Seçiniz") {
        return;
    }
    else {
        var $loading = $(document).find('#loading-background').hide();
        $loading.delay(1500).show();
        var _string = $("#ReportSelect option:selected").attr("value");
        $.post("/RaporList", { name: _string }, function (result) {
            debugger;
            $(".report-body").html(result);
        });
        setTimeout(function () {
            $loading.delay(1500).hide();
        }, 5000);
    }
});
