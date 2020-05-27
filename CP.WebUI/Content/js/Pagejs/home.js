
$(function () {
    ProductsBar();
    CategoryLine();
});

function ProductsBar() {

  
}

function CategoryLine() {
    
}


/**
 * 
 * @param {string} inputname Chart'ın oluşacağı canvas id'si
 * @param {string[]} labels  Chart'ın gözükecek isimleri
 * @param {string} Title Chart'ın başlığını belli eder
 * @param {number[]} values Chart'ın gözükecek değerleri
 * @param {string} ChartType Chart'ın tipini belli eder
 */
function ChartCreate(canvasId, Title, labels, values, ChartType) {
    var ctx = document.getElementById(canvasId).getContext('2d');
    var myChart = new Chart(ctx, {
        type: ChartType,
        data: {
            labels: labels,
            datasets: [{
                label: Title,
                data: values,
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