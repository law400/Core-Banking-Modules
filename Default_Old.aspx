<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

										
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!--
Author: W3layouts
Author URL: http://w3layouts.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE HTML>
<html>
<head>
	<title>UCP Core Portal</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0">
        <meta name="description" content="">
        <meta name="author" content="">

        <link href="template/css/style.default.css" rel="stylesheet">

        <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!--[if lt IE 9]>
        <script src="js/html5shiv.js"></script>
        <script src="js/respond.min.js"></script>
        <![endif]-->
</head> 
<body class="signin">
        
        <form runat="server" autocomplete="off">
        <section>
            
            <div class="panel panel-signin">
                <div class="panel-body">
                    <div class="logo text-center">
                        <img src="images/logo.png" alt="Chain Logo" >
                    </div>
                    <br />
                    <h4 class="text-center mb5">Admin Login</h4>
<%--                    <p class="text-center">Sign in to your account</p>--%>
                    
                    <div class="mb30"></div>
                    
               
                        
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                         <div class="input-group mb15">
                             <span class="input-group-addon"><i class="glyphicon glyphicon-tower"></i></span>
                           <asp:TextBox runat="server"  ID ="txtCoopID" CssClass="form-control" Placeholder="Coop ID"/>
                              </div><!-- input-group -->
                                   <div class="input-group mb15">
                                         <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
							     <asp:TextBox runat="server" ID ="txtuserid" CssClass="form-control" Placeholder="User ID"/>
                                        </div><!-- input-group -->

                                    <div class="input-group mb15">
                                         <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                             <asp:TextBox runat="server"  ID ="txtpassword" CssClass="form-control" TextMode="Password" Placeholder="Password" />  
                               </div><!-- input-group -->
                        <div class="clearfix">
                            <div class="pull-left">
                                <div class="ckbox ckbox-primary mt10">
                                    <input type="checkbox" id="rememberMe" value="1">
                                    <label for="rememberMe">Remember Me</label>
                                </div>
                            </div>
                            <div class="pull-right">
                                <button runat="server" type="submit" id="Login" class="btn btn-success" onserverclick="Login_Click">Sign In <i class="fa fa-angle-right ml5"></i></button>
                                 
                            </div>
                        </div>                      
                  
                      <div class ="panel-body">
                         <div class ="panel-footer">
 &copy; <%= DateTime.Now.Year %>  <a href= "http://www.cwg-plc.com" target= "_blank" > CWG PLC</a> </br> 
<span id="siteseal"><script async type="text/javascript" src="https://seal.godaddy.com/getSeal?sealID=T6ZbFNzPFss9I0MvbZjlav0bMctwnFhBm5rEhKxv9hf4rOWPPUnjUxwf6EMh"></script></span>           
</div>
            </div>
             
            
        </section>


         </form>

    </body>
</html>