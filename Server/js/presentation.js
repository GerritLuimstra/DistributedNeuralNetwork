$(document).ready(function(){

    // var chart = new CanvasJS.Chart("chartContainer", {
    //     animationEnabled: true,
    //     theme: "light1",
    //     title:{
    //         text: "Simple Line Chart"
    //     },
    //     axisY:{
    //         includeZero: false
    //     },
    //     data: [{
    //         type: "line",
    //         dataPoints: [
    //             { y: 0.80 },
    //             { y: 0.96 },
    //             { y: 0.90 },
    //         ]
    //     }]
    // });
    // chart.render();

    var timing = ["main", "client1", "client2", "client3"];

    var timerMain = new Timer();
    timerMain.start({precision: 'secondTenths'});
    timerMain.addEventListener('secondTenthsUpdated', function (e) {
        $('#secondTenthsExampleMain .values').html(timerMain.getTimeValues().toString(['minutes', 'seconds', 'secondTenths']));
    });

    var timerMainC1 = new Timer();
    var timerMainC2 = new Timer();
    var timerMainC3 = new Timer();
    var hasStarted = false;

    $("#startClients").on("click", function(){
        hasStarted = true;
        timerMainC1.start({precision: 'secondTenths'});
        timerMainC1.addEventListener('secondTenthsUpdated', function (e) {
            $('#secondTenthsExampleClient1 .values').html(timerMainC1.getTimeValues().toString(['minutes', 'seconds', 'secondTenths']));
        });

        timerMainC2.start({precision: 'secondTenths'});
        timerMainC2.addEventListener('secondTenthsUpdated', function (e) {
            $('#secondTenthsExampleClient2 .values').html(timerMainC2.getTimeValues().toString(['minutes', 'seconds', 'secondTenths']));
        });

        timerMainC3.start({precision: 'secondTenths'});
        timerMainC3.addEventListener('secondTenthsUpdated', function (e) {
            $('#secondTenthsExampleClient3 .values').html(timerMainC3.getTimeValues().toString(['minutes', 'seconds', 'secondTenths']));
        });
    });



    function check(){
        $.ajax({
            url: "php/update_status.php",
            method: "GET",
            success: function(responseText){
                var json = JSON.parse(responseText);
                if(json.main == true){
                    timerMain.stop();
                    $("#secondTenthsExampleMain .values").css({"color": "green", "font-weight": "bold"});
                }
                if(hasStarted){
                    if(json.client1 == true){
                        timerMainC1.stop();
                        $("#secondTenthsExampleClient1 .values").css({"color": "green", "font-weight": "bold"});
                    }
                    if(json.client2 == true){
                        timerMainC2.stop();
                        $("#secondTenthsExampleClient2 .values").css({"color": "green", "font-weight": "bold"});
                    }
                    if(json.client3 == true){
                        timerMainC3.stop();
                        $("#secondTenthsExampleClient3 .values").css({"color": "green", "font-weight": "bold"});
                    }
                }
            }
        });

        setTimeout(check, 2000);
    }

    setTimeout(check, 2000);





});