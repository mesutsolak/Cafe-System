$(function () {
    setTimeout(function () {
        TableConvertDataTables("tblCampaign");
    }, 750);
    NiceScrool(new ScroolModel("modal-body", "10px", "#A5A5A5"))
});

$(document).on("click", ".CampaignDelete", function () {
    var _id = $(this).data("id");
    var _fullname = $(this).parent().parent().children(":nth-child(2)").html().trim();
    var RemoveItems = {
        id: _id,
        name: _fullname,
        url: "/RemoveCampaign",
        fullname: _fullname + " başlıklı kampanya",
        Method: CampaignList
    };
    RemoveBasicOperations(RemoveItems);
});

$(document).on("click", "#ImageView", function () {
    var _src = $(this).attr("src");

    if (_src.startsWith("/Content")) {
        SweetAlert("error", "Hata", "Resim Bulunamadı");
    }
    else {
        $("#ImgViewSrc").attr("src", _src);
        $("#ImageShowModal").modal("show");
    }

});

function CampaignList() {
    $.get("/KampanyaList", null, function (result) {
        debugger;
        $(document).find(".campaign-body").html(result);
    });
}



$(document).on("click", ".CampaignUpdate", function () {
    var _id = $(this).data("id");

    $.ajax({
        type: 'POST',
        url: "/KampanyaGüncelle",
        data: { id: _id },
        dataType: 'html',
        success: function (data) {
            $(".campaign-update-modal").html(data);
            $(document).find("#CampaignUpdateModal").modal("show");
            NiceScrool(new ScroolModel("modal-campaign-update", "10px", "#A5A5A5"))
            //$(".modal-product-update").niceScroll({ cursorwidth: '10px', autohidemode: false, zindex: 999, cursorcolor: "#A5A5A5" });
        },
        error: function (xhr) { // if error occured
            alert("Error occured.please try again" + xhr.statusText + xhr.responseText);
        },
    });
});


$(document).on("click", ".campaign-detail", function () {
    var value = $(this).attr("value");
    $("#CampaignDetailModal").modal("show");
    $(".campaign-detail-modals").html(value);
});