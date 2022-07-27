<%@ Page Language="VB" AutoEventWireup="false" CodeFile="500.aspx.vb" Inherits="_500" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
     <title>Page Expired</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="initial-scale=1.0, width=device-width" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="dist/ionicons.min.css" />
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css" />
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"/>
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css"/>
   
</head>
<body class="hold-transition login-page"">
   
                <!-- Content Header (Page header) -->
              
                    <h1>
                        UCP PORTAL
                    </h1>

                
                <!-- Main content -->
               
                    <div class="error-page">
                        <h2 class="headline text-red"> Expired</h2>
                        <div class="error-content">
                            <h3><i class="fa fa-warning text-red"></i> Oops! An Error Occurred and Session has Expired.</h3>
                            <!--<p>
                              We could not find the page you were looking for.
                              Meanwhile, you may <a href="../../index.html">return to dashboard</a> or try using the search form.
                            </p>-->
                            <p>
                                Please kindly click <asp:HyperLink ID="HyperLink1" runat="server" Visible="True" ForeColor="Red" 
                NavigateUrl="~/Default.aspx">Login</asp:HyperLink> to begin a new session. 
                            </p>
                            <!--<form class="search-form">
                              <div class="input-group">
                                <input type="text" name="search" class="form-control" placeholder="Search">
                                <div class="input-group-btn">
                                  <button type="submit" name="submit" class="btn btn-warning btn-flat"><i class="fa fa-search"></i></button>
                                </div>
                              </div> /.input-group
                            </form>-->
                        </div><!-- /.error-content -->
                    </div><!-- /.error-page -->
               
           
          <%-- <div class ="box-footer">--%>
                <div class="pull-right hidden-xs">
                    
                </div>
                <strong>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <br />
                <br />
                Copyright &copy; 2018 <a href="http://cwlgroup.com.com">CWG PLC</a>.</strong> All rights reserved.
         <%--   </div>--%>
          
  
   
</body>
</html>