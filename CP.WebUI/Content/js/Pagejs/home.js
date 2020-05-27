
$(function () {
    ProductCategoryBar();
    UserRoleBar();
});

function ProductCategoryBar() {
    $.post("/ProcCatModel", null, function (result) {
        ChartCreate(new ChartModal("products-chart", "Ürün Sayısı", result.Category, result.Product, "pie"));
    });
}
function UserRoleBar() {
    $.post("/UserRoleModel", null, function (result) {
        ChartCreate(new ChartModal("users-chart", "Kullanıcı Sayısı", result.Role, result.User, "bar"))
    });
}



/**
 * 
 * @param {ChartModal} ChartModal
 */
function ChartCreate(ChartModal) {
    var ctx = document.getElementById(ChartModal.canvasId).getContext('2d');
    var myChart = new Chart(ctx, {
        type: ChartModal.ChartType,
        data: {
            labels: ChartModal.labels,
            datasets: [{
                label: ChartModal.Title,
                data: ChartModal.values,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

class ChartModal {
    constructor(canvasId, Title, labels, values, ChartType) {
        this.canvasId = canvasId;
        this.Title = Title;
        this.labels = labels;
        this.values = values;
        this.ChartType = ChartType;
    }
}