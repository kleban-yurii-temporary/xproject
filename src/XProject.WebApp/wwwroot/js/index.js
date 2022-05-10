$(function () {
    updateData();
});

function updateData() {

    $.ajax({
        url: '/home/getdata',
        type: 'get',
        success: function (result) {

           
            var data = "";
          
            for (let i = 0; i < result.length; i++) {
                data += "<div>" + result[i].equipmentType.title + ": " + result[i].count + "</div>";
            }

            $("#data-row").html(data);
        }
    });

}