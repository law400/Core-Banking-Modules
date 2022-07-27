<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Activation.aspx.vb" Inherits="Activation" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="initial-scale=1.0, width=device-width"/>

    <title>UCP</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"/>
    <!-- Theme style -->
     <link rel="stylesheet" href="dist/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="dist/ionicons.min.css"/>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css"/>
    <!-- iCheck -->
    <link rel="stylesheet" href="plugins/iCheck/flat/blue.css"/>
    <!-- Morris chart -->
    <%--    <link rel="stylesheet" href="plugins/morris/morris.css"/>--%>
    <!-- jvectormap -->
    <link rel="stylesheet" href="plugins/jvectormap/jquery-jvectormap-1.2.2.css"/>
    <!-- Date Picker -->
    <link rel="stylesheet" href="plugins/datepicker/datepicker3.css"/>
    <!-- Daterange picker -->
    <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker-bs3.css"/>
    <!-- bootstrap wysihtml5 - text editor -->
    <link rel="stylesheet" href="plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">

        function getCurrentTime() {
            var now = new Date();
            var mySecs = now.getSeconds();
            var curHour = now.getHours();
            var curMin = now.getMinutes();
            var day = now.getDay();
            var date = now.getDate();
            var year = now.getFullYear();
            var month = now.getMonth();
            var days = new Array();
            days[0] = "Sunday";
            days[1] = "Monday";
            days[2] = "Tuesday";
            days[3] = "Wednesday";
            days[4] = "Thursday";
            days[5] = "Friday";
            days[6] = "Saturday";
            var months = new Array();
            months[0] = "January";
            months[1] = "February";
            months[2] = "March";
            months[3] = "April";
            months[4] = "May";
            months[5] = "June";
            months[6] = "July";
            months[7] = "August";
            months[8] = "September";
            months[9] = "October";
            months[10] = "November";
            months[11] = "December";
            var suffix = "AM";

            if (mySecs < 10) {
                mySecs = "0" + mySecs;
            }

            if (curMin < 10) {
                curMin = "0" + curMin;
            }

            if (curHour == 12 && curMin >= 1) {
                suffix = "PM";
            }

            if (curHour == 24 && curMin >= 1) {
                curHour -= 12;
                suffix = "AM";
            }

            if (curHour > 12) {
                curHour -= 12;
                suffix = "PM";
            }

            document.getElementById('time').innerHTML = (days[day] + ", " + date + " " + (months[month]) + " " + year + " " + curHour + ":" + curMin + ":" + mySecs + " " + suffix);

        }

</script>
      <script type="text/javascript">

          function disableBackButton() {
              window.history.forward(1);

          }
          setTimeout("disableBackButton()", 0);
          var nHist = window.history.length;
          if (window.history[nHist] != window.location)
              window.history.forward();
    </script>

    </head>

<body class="hold-transition login-page" style="height: 500px; background-image: url(bg2.png); background-size: contain;">
    <form id="form1" runat="server">
         <div class="navbar navbar-inverse navbar-fixed-top" role="navigation" style="background-color: rgba(6, 64, 108, 0.62); height: 70px;">
        <!-- Brand and toggle get grouped for better mobile display -->
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" runat="server" href="~/#" style="color: White;">
                         <img src="template/images/fin2.png" /></a>
                </div>
                <div class="navbar-collapse collapse" style="font-weight: bold; font-size: larger;">
                    <ul class="nav navbar-nav">
                        <li><a runat="server" href="~/#" style=" color: white;">UCP Coop Activation</a></li>
                    </ul>
                </div>
    </div>
          </div>


       <div class="login-box" style="width: 930px; height: 200px; padding-top: 50px;">
          <div class = "panel-body" style="background-color: white; height: 260px; border-radius: 6px;">
              <h3 >
                  <asp:HyperLink ID="HyperLink1" runat="server" Text="Activation Page" NavigateUrl="#" Font-Bold="True" Font-Size="Medium" ForeColor="#06406c"></asp:HyperLink>
              </h3><br /><br />
               <div>
                   <asp:Label ID="lbl_Fullname" runat="server"></asp:Label>

          &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Font-Underline="True" NavigateUrl="SignIn.aspx" ForeColor="Green" Visible="False">LogIn</asp:HyperLink>

          </div>
           </div>
  
   </div>

    </form>
    <div style="background-color: white;">
            <footer class="main-footer" style="margin-top: 250px; margin-left: -10px; background-color: white; height: 100px;">     
        <div class="pull-right hidden-xs">
        </div>
        <strong>&nbsp;&nbsp;&nbsp;&nbsp; Copyright &copy; <%= DateTime.Now.Year %> <a href="http://www.cwg-plc.com" target= "_blank">CWG PLC</a>.</strong> All rights reserved.
      </footer>
    </div>
</body>
</html>
