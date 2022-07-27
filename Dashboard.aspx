<%@ Page Title="" Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="Dashboard.aspx.vb" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0"/>
        <meta name="description" content=""/>
        <meta name="author" content=""/>

        <title>FinEdge</title>
    <script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script>
    <script src="//cdn.jsdelivr.net/excanvas/r3/excanvas.js" type="text/javascript"></script>
<script src="//cdn.jsdelivr.net/chart.js/0.2/Chart.js" type="text/javascript"></script>
      <script src="plugins/chartjs/Chart.min.js"></script>
        <link href="css/style.default.css" rel="stylesheet"/>
        <link href="css/morris.css" rel="stylesheet"/>
        <link href="css/select2.css" rel="stylesheet" />
           
        <script src="js/jquery-migrate-1.2.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/modernizr.min.js"></script>
        <script src="js/pace.min.js"></script>
        <script src="js/retina.min.js"></script>
        <script src="js/jquery.cookies.js"></script>
        
        <script src="js/flot/jquery.flot.min.js"></script>
        <script src="js/flot/jquery.flot.resize.min.js"></script>
        <script src="js/flot/jquery.flot.symbol.min.js"></script>
        <script src="js/flot/jquery.flot.crosshair.min.js"></script>
        <script src="js/flot/jquery.flot.categories.min.js"></script>
        <script src="js/flot/jquery.flot.pie.min.js"></script>
        <script src="js/morris.min.js"></script>
        <script src="js/raphael-2.1.0.min.js"></script>
        <script src="js/jquery.sparkline.min.js"></script>

        <script src="js/custom.js"></script>
        <script src="js/charts.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
                    <script src="template/js/jquery-1.11.1.min.js"></script>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css"/>
     <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"/>
        <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!--[if lt IE 9]>
        <script src="js/html5shiv.js"></script>
        <script src="js/respond.min.js"></script>
        <![endif]-->
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                title: 'Savings/Contribution Products',
                width: "100%",
                height: "100%",
                bar: { groupWidth: "95%" },
                legend: { position: "right" },
                isStacked: true,
                colors: ['red','yellow', 'blue','green','aqua','pink','grey','black','orange'],
            };
            $.ajax({
                type: "POST",
                url: "Dashboard.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.BarChart($("#chart")[0]);
                    chart.draw(data, options);
                    for (var i = 0; i < data.length; i++) {
                        var div = $("<div />");
                        div.css("margin-bottom", "10px");
                        div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:" + data[i].color + "'></span> " + data[i].text);
                        $("#dvLegend2").append(div);
                    }
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }



        //$(function () {
        //    LoadChart();
        //    drawChart();
        //    LoadPaymentChart();
         
        //});
//        function LoadPaymentChart() {
//            var options = {
//                title: 'Revenue Chart',
//                hAxis: {
//                    title: 'Type of Revenue',
//                    bold: true,
                   
//                },
//                vAxis: {
//                    title: 'Amount(₦)',
//                    bold: true,
//                },
            
//                width: "100%",
//                height: "100%",
//                bar: { groupWidth: "95%" },
//                legend: { position: "right" },
//                isStacked: true,
//                colors: ['green', 'yellow', 'blue', 'red', 'aqua', 'pink', 'grey', 'black', 'orange'],
//            };
//            $.ajax({
//                type: "POST",
//                url: "Dashboard.aspx/GetPaymentChartData",
//                data: '{}',
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: function (r) {
//                    var data = google.visualization.arrayToDataTable(r.d);
//                    var chart = new google.visualization.ColumnChart($("#bar-chart")[0]);
//                    chart.draw(data, options);
//                    for (var i = 0; i < data.length; i++) {
//                        var div = $("<div />");
//                        div.css("margin-bottom", "10px");
//                       // div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:" + data[i].color + "'></span> " + data[i].text);

//div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:yellow'></span> " + data[i].text);
//                        $("#dvLegend3").append(div);
//                    }
//                },
//                failure: function (r) {
//                    alert(r.d);
//                },
//                error: function (r) {
//                    alert(r.d);
//                }
//            });
//        }
//        $(function () {
//            LoadChart();
//            drawChart();
//            LoadPaymentChart();
//            LoadPaymentChart2();
//            LoadPaymentChartMonth();
//            LoadPaymentChart6Month();
//            LoadPaymentChart12Month()

//        });
        
       
//function LoadChart() {
//  //  var chartType = parseInt($("[id*=rblChartType] input:checked").val());
//    $.ajax({
//        type: "POST",
//        url: "Dashboard.aspx/GetPieChart",
//        data: "",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (r) {
//            $("#dvChart").html("");
//            $("#dvLegend").html("");
//            var data = eval(r.d);
//            var el = document.createElement('canvas');
//            $("#dvChart")[0].appendChild(el);
 
//            //Fix for IE 8
//            if ($.browser.msie && $.browser.version == "8.0") {
//                G_vmlCanvasManager.initElement(el);
//            }
//            var ctx = el.getContext('2d');
//            var userStrengthsChart;
//            //switch (chartType) {
//            //    case 1:
//            //        userStrengthsChart = new Chart(ctx).Pie(data);
//            //        break;
//            //    case 2:
//            //        userStrengthsChart = new Chart(ctx).Doughnut(data);
//            //        break;
//            //}
//            var pieOptions = {
//          //Boolean - Whether we should show a stroke on each segment
//          segmentShowStroke: true,
//          //String - The colour of each segment stroke
//          segmentStrokeColor: "#fff",
//          //Number - The width of each segment stroke
//          segmentStrokeWidth: 2,
//          //Number - The percentage of the chart that we cut out of the middle
//          percentageInnerCutout: 50, // This is 0 for Pie charts
//          //Number - Amount of animation steps
//          animationSteps: 100,
//          //String - Animation easing effect
//          animationEasing: "easeOutBounce",
//          //Boolean - Whether we animate the rotation of the Doughnut
//          animateRotate: true,
//          //Boolean - Whether we animate scaling the Doughnut from the centre
//          animateScale: false,
//          //Boolean - whether to make the chart responsive to window resizing
//          responsive: true,
//          // Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
//          maintainAspectRatio: true,
//        };
//            userStrengthsChart = new Chart(ctx).Doughnut(data, pieOptions);
//            for (var i = 0; i < data.length; i++) {
//                var div = $("<div />");
//                div.css("margin-bottom", "10px");
//                div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:" + data[i].color + "'></span> " + data[i].text);
//                $("#dvLegend").append(div);
//            }
//        },
//        failure: function (response) {
//            alert('There was an error.');
//        }
//    });   
//}

       
//function LoadPaymentChart2() {
//    var options = {
//        title: 'Revenue Chart',

//        hAxis: {
//            title: 'Date',
//            bold: true,
//        },
//        vAxis: {
//            title: 'Amount(₦)',
//            bold: true,
//        },
//        height: 350,
//        width: "100%",

//        bar: { groupWidth: "95%" },
//        legend: { position: "right" },
//        isStacked: true,
//        colors: ['orange', 'yellow', 'blue', 'red', 'pink', 'green', 'grey', 'black', 'aqua'],
//    };
//    $.ajax({
//        type: "POST",
//        url: "Dashboard.aspx/GetPaymentChartDataWeek",
//        data: '{}',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (r) {
//            var data = google.visualization.arrayToDataTable(r.d);
//            var chart = new google.visualization.ColumnChart($("#bar-chart2")[0]);
//            chart.draw(data, options);
//            $('#bar-chart2').removeClass('active');
//            for (var i = 0; i < data.length; i++) {
//                var div = $("<div />");
//                div.css("margin-bottom", "10px");
//                // div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:" + data[i].color + "'></span> " + data[i].text);

//                div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:yellow'></span> " + data[i].text);
//                $("#dvLegend4").append(div);
//            }
//        },
//        failure: function (r) {
//            alert(r.d);
//        },
//        error: function (r) {
//            alert(r.d);
//        }
//    });
//}
//function LoadPaymentChartMonth() {
//    var options = {
//        title: 'Revenue Chart',

//        hAxis: {
//            title: 'Date',
//            bold: true,
//        },
//        vAxis: {
//            title: 'Amount(₦)',
//            bold: true,
//        },
//        height: 350,
//        width: "100%",

//        bar: { groupWidth: "95%" },
//        legend: { position: "right" },
//        isStacked: true,
//        colors: ['red', 'orange', 'blue', 'yellow', 'pink', 'green', 'grey', 'black', 'aqua'],
//    };
//    $.ajax({
//        type: "POST",
//        url: "Dashboard.aspx/GetPaymentChartDataMonth",
//        data: '{}',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (r) {
//            var data = google.visualization.arrayToDataTable(r.d);
//            var chart = new google.visualization.ColumnChart($("#bar-chartmonth1")[0]);
//            chart.draw(data, options);
//            $('#bar-chartmonth1').removeClass('active');
//            for (var i = 0; i < data.length; i++) {
//                var div = $("<div />");
//                div.css("margin-bottom", "10px");
//                // div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:" + data[i].color + "'></span> " + data[i].text);

//                div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:yellow'></span> " + data[i].text);
//                $("#dvLegend4month").append(div);
//            }
//        },
//        failure: function (r) {
//            alert(r.d);
//        },
//        error: function (r) {
//            alert(r.d);
//        }
//    });
//}

//function LoadPaymentChart6Month() {
//    var options = {
//        title: 'Revenue Chart',

//        hAxis: {
//            title: 'Date',
//            bold: true,
//        },
//        vAxis: {
//            title: 'Amount(₦)',
//            bold: true,
//        },
//        height: 350,
//        width: "100%",

//        bar: { groupWidth: "95%" },
//        legend: { position: "right" },
//        isStacked: true,
//        colors: ['aqua', 'orange', 'blue', 'yellow', 'pink', 'green', 'grey', 'black', 'red'],
//    };
//    $.ajax({
//        type: "POST",
//        url: "Dashboard.aspx/GetPaymentChartDataMonth2",
//        data: '{}',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (r) {
//            var data = google.visualization.arrayToDataTable(r.d);
//            var chart = new google.visualization.ColumnChart($("#bar-chartmonth12")[0]);
//            chart.draw(data, options);
//            $('#bar-chartmonth12').removeClass('active');
//            for (var i = 0; i < data.length; i++) {
//                var div = $("<div />");
//                div.css("margin-bottom", "10px");
//                // div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:" + data[i].color + "'></span> " + data[i].text);

//                div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:yellow'></span> " + data[i].text);
//                $("#dvLegend4month1").append(div);
//            }
//        },
//        failure: function (r) {
//            alert(r.d);
//        },
//        error: function (r) {
//            alert(r.d);
//        }
//    });
//}
//function LoadPaymentChart12Month() {
//    var options = {
//        title: 'Revenue Chart',

//        hAxis: {
//            title: 'Date',
//            bold: true,
//        },
//        vAxis: {
//            title: 'Amount(?)',
//            bold: true,
//        },
//        height: 350,
//        width: "100%",

//        bar: { groupWidth: "95%" },
//        legend: { position: "right" },
//        isStacked: true,
//        colors: ['black', 'orange', 'blue', 'yellow', 'pink', 'green', 'grey', 'red', 'aqua'],
//    };
//    $.ajax({
//        type: "POST",
//        url: "Dashboard.aspx/GetPaymentChartDataMonth3",
//        data: '{}',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (r) {
//            var data = google.visualization.arrayToDataTable(r.d);
//            var chart = new google.visualization.ColumnChart($("#bar-chartmonth13")[0]);
//            chart.draw(data, options);
//            $('#bar-chartmonth13').removeClass('active');
//            for (var i = 0; i < data.length; i++) {
//                var div = $("<div />");
//                div.css("margin-bottom", "10px");
//                // div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:" + data[i].color + "'></span> " + data[i].text);

//                div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:yellow'></span> " + data[i].text);
//                $("#dvLegend4month12").append(div);
//            }
//        },
//        failure: function (r) {
//            alert(r.d);
//        },
//        error: function (r) {
//            alert(r.d);
//        }
//    });
//}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   

</asp:Content>

