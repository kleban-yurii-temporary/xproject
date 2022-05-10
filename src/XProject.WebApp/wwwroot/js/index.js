$(
  function () {
    updateData();
});

function updateData() {

    $.ajax({
        url: '/home/getdata',
        type: 'get',
        success: function (result) {
           
            var content = "<div class='row'>";
          
            for (let i = 0; i < result.length; i++) {

                var contentItem = "<div class='col-md-2 mb-5 item-card'><div class='card h-100 shadow'>";

                contentItem += "<div class='card-body'><canvas id='chart" + result[i].id + "'></canvas><div class='num-block'>"
                    + "<img src='eq/image/" + result[i].equipmentType.id + "' alt='' />"
                    + "<h5>" + result[i].count + "</h5>"
                    + "<h6>+" + result[i].countPlus + "</h6></div>"
                    + "<a href='/eq/details/" + result[i].id
                    + "' class='title'>" + result[i].equipmentType.title + " <i class='bi bi-arrow-right'></i></a></div>";

                contentItem += "</div></div>";

                content += contentItem;
            }
            content += "</div>";
            $("#data-row").html(content);

            for (let i = 0; i < result.length; i++) {

             
                $.ajax({
                    url: '/home/getminichartdata/' + result[i].equipmentType.id,
                    type: 'get',
                    success: function (result2) {

                        updateMiniCharts(result[i].id, result2);

                    }
                });

               
            }
        }
    });

}

var colors = ["#00FFFF", "#32CD32", "#BA55D3", "#4B0082", "#A52A2A", "#4169E1", "#B22222"]

function updateMiniCharts(data_id, result2) {

    var color = colors[Math.floor(Math.random() * (colors.length - 1))];      

    let ctx = document.getElementById('chart' + data_id).getContext('2d');

    var gradient = ctx.createLinearGradient(0, 0, 120, 100);
    gradient.addColorStop(0, 'rgba(229, 239, 255, 1)');
    gradient.addColorStop(1, '#FFFFFF');

    let chart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: result2.key,
            datasets: [
                {
                    data: result2.value,
                    backgroundColor: '#EEE'
                }
            ]
        },
        options: {
            responsive: false,
            legend: {
                display: false
            },
            elements: {
                line: {
                    borderColor: color,
                    borderWidth: 3
                },
                point: {
                    radius: 0
                }
            },
            tooltips: {
                enabled: false
            },
            scales: {
                yAxes: [
                    {
                        display: false
                    }
                ],
                xAxes: [
                    {
                        display: false
                    }
                ]
            }
        }
    });

}