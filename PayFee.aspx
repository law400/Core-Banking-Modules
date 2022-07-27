<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PayFee.aspx.vb" Inherits="PayFee" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml"><head id="j_idt4">
            <meta http-equiv="X-UA-Compatible" content="IE=edge" />
            <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
            <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
            <meta name="apple-mobile-web-app-capable" content="yes" />
            <meta name="theme-color" content="#545b61" /><link type="text/css" rel="stylesheet" href="/javax.faces.resource/theme.css.jsf?ln=primefaces-atlantis-steel" /><link type="text/css" rel="stylesheet" href="/javax.faces.resource/fa/font-awesome.css.jsf?ln=primefaces&amp;v=6.2" /><link type="text/css" rel="stylesheet" href="/javax.faces.resource/components.css.jsf?ln=primefaces&amp;v=6.2" /><script type="text/javascript" src="/javax.faces.resource/jquery/jquery.js.jsf?ln=primefaces&amp;v=6.2"></script><script type="text/javascript" src="/javax.faces.resource/jquery/jquery-plugins.js.jsf?ln=primefaces&amp;v=6.2"></script><script type="text/javascript" src="/javax.faces.resource/core.js.jsf?ln=primefaces&amp;v=6.2"></script><script type="text/javascript" src="/javax.faces.resource/components.js.jsf?ln=primefaces&amp;v=6.2"></script><script type="text/javascript" src="/javax.faces.resource/printer/printer.js.jsf?ln=primefaces&amp;v=6.2"></script><link type="text/css" rel="stylesheet" href="/javax.faces.resource/css/nanoscroller.css.jsf?ln=atlantis-layout" /><link type="text/css" rel="stylesheet" href="/javax.faces.resource/css/animate.css.jsf?ln=atlantis-layout" /><link type="text/css" rel="stylesheet" href="/javax.faces.resource/css/layout-dark.css.jsf?ln=atlantis-layout" /><script type="text/javascript" src="/javax.faces.resource/validation/validation.js.jsf?ln=primefaces&amp;v=6.2"></script><script type="text/javascript" src="/javax.faces.resource/validation/beanvalidation.js.jsf?ln=primefaces&amp;v=6.2"></script><script type="text/javascript">if(window.PrimeFaces){PrimeFaces.settings.locale='en';PrimeFaces.settings.validateEmptyFields=true;PrimeFaces.settings.considerEmptyStringNull=false;PrimeFaces.settings.projectStage='Development';}</script>
        <title>
        Receipt
    </title>
        <link rel="shortcut icon" href="/javax.faces.resource/images/fav.png.jsf?ln=vanilla-layout" type="image/png" /><script type="text/javascript" src="/javax.faces.resource/js/nanoscroller.js.jsf?ln=atlantis-layout"></script><script type="text/javascript" src="/javax.faces.resource/js/layout.js.jsf?ln=atlantis-layout"></script>
            <style type="text/css">
                .auto-style1 {
                    height: 29px;
                }
            </style>
</head><body class="main-body">

        <div>
<form id="j_idt13" name="j_idt13" method="post" action="/account/payment-receipt" enctype="application/x-www-form-urlencoded">
<input type="hidden" name="j_idt13" value="j_idt13" />
<span id="j_idt13:globalGrowl" class="ui-growl-pl" data-widget="widget_j_idt13_globalGrowl" data-summary="data-summary" data-severity="all,error" data-redisplay="true"></span><script id="j_idt13:globalGrowl_s" type="text/javascript">$(function(){PrimeFaces.cw("Growl","widget_j_idt13_globalGrowl",{id:"j_idt13:globalGrowl",sticky:false,life:6000,escape:true,keepAlive:false,msgs:[]});});</script><input type="hidden" name="javax.faces.ViewState" id="j_id1:javax.faces.ViewState:0" value="-4063173668612026501:-5230104544957363001" autocomplete="off" />
</form>
        </div>

        <div class="layout-wrapper layout-inline-menu layout-ltr ">

    

    <div class="topbar">
        <div class="logo">&nbsp;</div>

        <!--&lt;p:graphicImage name="images/appname.svg" library="atlantis-layout" styleClass="app-name"/&gt;-->
        
        <a id="topbar-menu-button" href="#">
            <i class="fa fa-bars"></i>
        </a>
        
        <ul class="topbar-menu fadeInDown animated">
            <li class="profile-item">
                <a href="#">                            
                    <div class="profile-image">
                    </div>
                    <div class="profile-info">
                        <span class="topbar-item-name profile-name"> </span>
                        <span class="topbar-item-name profile-role">
                            
                        </span>
                    </div>
                </a>
                
                <%--<ul class="animated">
                    <li role="menuitem">
                        <a href="/app/account/user/profile">
                            <i class="fa fa-fw fa-user"></i>
                            <span>Profile</span>
                        </a>
                    </li>
                    <li role="menuitem" style="display: none">
                        <a href="#">
                            <i class="fa fa-fw fa-user-secret"></i>
                            <span>Privacy</span>
                            <span class="topbar-submenuitem-badge">2</span>
                        </a>
                    </li>
                    <!--&lt;li role="menuitem"&gt;-->
                        <!--&lt;a href="#"&gt;-->
                            <!--&lt;i class="fa fa-fw fa-cog"&gt;&lt;/i&gt;-->
                            <!--&lt;span&gt;Settings&lt;/span&gt;-->
                        <!--&lt;/a&gt;-->
                    <!--&lt;/li&gt;-->
                    
                </ul>--%>
            </li>
            <li style="display: none">
                <a href="#">
                    <i class="topbar-icon fa fa-fw fa-cog"></i>
                    <span class="topbar-item-name">Settings</span>
                </a>
                <ul class="animated">
                    <li role="menuitem">
                        <a href="#">
                            <i class="fa fa-fw fa-paint-brush"></i>
                            <span>Change Theme</span>
                            <span class="topbar-submenuitem-badge">4</span>
                        </a>
                    </li>
                    <li role="menuitem">
                        <a href="#">
                            <i class="fa fa-fw fa-star-o"></i>
                            <span>Favorites</span>
                        </a>
                    </li>
                    <li role="menuitem">
                        <a href="#">
                            <i class="fa fa-fw fa-lock"></i>
                            <span>Lock Screen</span>
                            <span class="topbar-submenuitem-badge">2</span>
                        </a>
                    </li>
                    <li role="menuitem">
                        <a href="#">
                            <i class="fa fa-fw fa-picture-o"></i>
                            <span>Wallpaper</span>
                        </a>
                    </li>
                </ul>
            </li>
            <li style="display: none">
                <a href="#">
                    <i class="topbar-icon material-icons animated swing fa fa-fw fa-envelope-o"></i>
                    <span class="topbar-badge animated rubberBand">5</span>
                    <span class="topbar-item-name">Messages</span>
                </a>
                <ul class="animated">
                    <li role="menuitem">
                        <a href="#" class="topbar-message"><img id="j_idt19" src="/javax.faces.resource/images/avatar1.png.jsf?ln=atlantis-layout" alt="" width="35" />
                            <span>Give me a call</span>
                        </a>
                    </li>
                    <li role="menuitem">
                        <a href="#" class="topbar-message"><img id="j_idt21" src="/javax.faces.resource/images/avatar2.png.jsf?ln=atlantis-layout" alt="" width="35" />
                            <span>Reports attached</span>
                        </a>
                    </li>
                    <li role="menuitem">
                        <a href="#" class="topbar-message"><img id="j_idt23" src="/javax.faces.resource/images/avatar3.png.jsf?ln=atlantis-layout" alt="" width="35" />
                            <span>About your invoice</span>
                        </a>
                    </li>
                    <li role="menuitem">
                        <a href="#" class="topbar-message"><img id="j_idt25" src="/javax.faces.resource/images/avatar2.png.jsf?ln=atlantis-layout" alt="" width="35" />
                            <span>Meeting today</span>
                        </a>
                    </li>
                    <li role="menuitem">
                        <a href="#" class="topbar-message"><img id="j_idt27" src="/javax.faces.resource/images/avatar4.png.jsf?ln=atlantis-layout" alt="" width="35" />
                            <span>Out of office</span>
                        </a>
                    </li>
                </ul>
            </li>
            <li style="display: none">
                <a href="#">
                    <i class="topbar-icon fa fa-fw fa-bell-o"></i>
                    <span class="topbar-badge animated rubberBand" style="display: none">
                        0
                    </span>
                    <span class="topbar-item-name">Notifications</span>
                </a>
                <ul class="animated">
                    <li role="menuitem">
                        <a href="#">
                            <i class="fa fa-fw fa-tasks"></i>
                            <span>Pending tasks</span>
                            <span class="topbar-submenuitem-badge">
                                1
                            </span>
                        </a>
                    </li>
                    <li role="menuitem">
                        <a href="#">
                            <i class="fa fa-fw fa-calendar-check-o"></i>
                            <span>Meeting today</span>
                        </a>
                    </li>
                    <li role="menuitem">
                        <a href="#">
                            <i class="fa fa-fw fa-download"></i>
                            <span>Download</span>
                        </a>
                    </li>
                    <li role="menuitem">
                        <a href="#">
                            <i class="fa fa-fw fa-plane"></i>
                            <span>Book flight</span>
                        </a>
                    </li>
                </ul>
            </li>
            <li class="search-item" style="display: none">
<form id="j_idt29" name="j_idt29" method="post" action="/account/payment-receipt" enctype="application/x-www-form-urlencoded">
<input type="hidden" name="j_idt29" value="j_idt29" />

                    <i class="fa fa-search"></i><input id="j_idt29:j_idt31" name="j_idt29:j_idt31" type="text" placeholder="Search..." class="ui-inputfield ui-inputtext ui-widget ui-state-default ui-corner-all" /><script id="j_idt29:j_idt31_s" type="text/javascript">PrimeFaces.cw("InputText","widget_j_idt29_j_idt31",{id:"j_idt29:j_idt31"});</script><input type="hidden" name="javax.faces.ViewState" id="j_id1:javax.faces.ViewState:1" value="-4063173668612026501:-5230104544957363001" autocomplete="off" />
</form>
            </li>
        </ul>
    </div>

            
            <div class="layout-main">
                <div class="layout-main-content">
<form id="j_idt34" name="j_idt34" method="post" action="/account/payment-receipt" enctype="application/x-www-form-urlencoded">
<input type="hidden" name="j_idt34" value="j_idt34" />

            <div class="fadeInDownBig animated" style="width: 70%; margin: 0 auto">
                <div style="background-color: #d9ffb3; width: 98%; border-radius: 10px 10px 0px 0px; padding: 1%;">
                    <i class="fa fa-info-circle" aria-hidden="true"></i>
                    <span style="padding-left: 5px">
                      <%--  Payment Transaction Successful--%>
                        <asp:Label ID="Label_success" runat="server"></asp:Label>
                    </span>
                </div><div id="j_idt34:receiptPan" class="ui-outputpanel ui-widget card card-w-title" style="display: block;">
                    <div class="ui-fluid">
                        <div class="ui-g">
                            <div class="chat ui-g-12 ui-md-12" style="overflow: hidden;">
                                <div style="float: left; width: 10%">
                                    <img src="plugins/images/ucpweb.png" alt="Ho
                                     </div>

                                <div style="float: left; width: 80%">
                                    <p style="text-align: center; padding: 0; margin: 0">
                                        <span style="font-size: x-large; display: block; font-weight: bolder">
                                            Receipt 
                                        </span>
                                       

                                    </p>
                                </div>

                                <div style="float: left; width: 10%">&nbsp;</div>
                            </div>

                            <table border="0" cellpadding="5px" style="border-collapse: collapse; width: 100%;">
                                    <tr>
                                        <td width="25%"></td>
                                        <td width="25%"></td>
                                        <td style="font-weight: bold; width: 20%">&nbsp;</td>
                                        <td>Coop Name :</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">Date : &nbsp;&nbsp;<asp:Label ID="lbldate" runat="server" Text=""></asp:Label></td>
                                        <td width="25%"></td>
                                        <td style="font-weight: bold; width: 20%">&nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblCoopName" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td width="25%" class="auto-style1">RRR: &nbsp;<asp:Label ID="lblrrr" runat="server" Text=""></asp:Label> </td>
                                        <td width="25%" class="auto-style1"></td>
                                        <td class="auto-style1" ></td>
                                        <td class="auto-style1" >Email :</td>
                                    </tr>

                                 <tr>
                                        <td width="25%"></td>
                                        <td width="25%"></td>
                                        <td >&nbsp;</td>
                                        <td >

                                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>

                                </table>

                            <div class="chat ui-g-12 ui-md-12" style="overflow: hidden; border-bottom: solid thin #cecece">
                                <div class="ui-g-6 ui-md-6"></div>
                            </div>
                            <table border="0" cellpadding="5px" style="border-collapse: collapse; width: 100%;">
                                    <tr>
                                        <td width="25%"></td>
                                        <td width="25%"></td>
                                        <td style="font-weight: bold; width: 20%">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">&nbsp;</td>
                                        <td width="25%"></td>
                                        <td style="font-weight: bold; width: 20%">&nbsp;</td>
                                        <td>Phone Number :</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">&nbsp;</td>
                                        <td width="25%"></td>
                                        <td >&nbsp;</td>
                                        <td >
                                            <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label>

                                        </td>
                                    </tr>

                                </table>
                            <div class="chat ui-g-12 ui-md-12" style="overflow: hidden;">
                                <div class="ui-g-6 ui-md-6">
                                    &nbsp;
                                </div>
                            </div>

                            <div class="chat ui-g-12 ui-md-12" style="overflow: hidden;">
                                <div class="ui-g-6 ui-md-6">
                                    &nbsp;
                                </div>
                            </div>

                            <div class="chat ui-g-12 ui-md-12" style="overflow: hidden;">
                                <div class="ui-g-6 ui-md-6">Your Payment Details </div>
                            </div>

                            <div class="chat ui-g-12 ui-md-12" style="overflow: hidden;">
                                <table border="0" cellpadding="5px" style="border-collapse: collapse; width: 100%;">
                                    <tr style="border-bottom: solid 1px #000000; border-top: solid 1px #000000;">
                                        <td style="font-weight: bold">Transaction No</td>
                                        <td style="font-weight: bold">Description</td>
                                        <td style="font-weight: bold">Amount</td>
                                    </tr>
                                        <tr>
                                            <td style="padding-top: 5px">
                                                <asp:Label ID="lblTransactionId" runat="server" Text=""></asp:Label></td>
                                            <td><asp:Label ID="LblDescription" runat="server" Text=""></asp:Label>
</td>
                                            <td>
                                               NGN <asp:Label ID="LblAmount" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                </table>
                            </div>

                            <div class="chat ui-g-12 ui-md-12" style="overflow: hidden;">
                                <p style="margin-top: 25px; padding: 5px; background-color: #eeeeee;">
                                    Thank you for Using Online payment.</p>
                                <br />
                                <table border="0" cellpadding="5px" style="border-collapse: collapse; width: 100%;">
                                    <tr>
                                        <td width="25%"></td>
                                        <td width="25%"></td>
                                        <td style="font-weight: bold; width: 20%">Subtotal: </td>
                                        <td>
                                           NGN <asp:Label ID="lblsubamount" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="25%"></td>
                                        <td width="25%"></td>
                                        <td style="font-weight: bold; width: 20%">Charges: </td>
                                        <td>NGN <asp:Label ID="lblcharge" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td width="25%"></td>
                                        <td width="25%"></td>
                                        <td style="font-weight: bold; width: 20%;border-bottom: solid 1px #000000; border-top: solid 1px #000000">Total Amount: </td>
                                        <td style="border-bottom: solid 1px #000000; border-top: solid 1px #000000">NGN <asp:Label ID="lblTotalamount" runat="server" Text=""></asp:Label> (Paid)
                                        </td>
                                    </tr>

                                </table>
                            </div>

                            <div class="chat ui-g-12 ui-md-8" style="overflow: hidden;">
                                <h3>Thank you for using the online payment</h3>
                                Please click <a href="RegFee.aspx">here</a> to return to the home page
                            </div>
                        </div>
                    </div></div><div id="j_idt34:j_idt54" class="ui-outputpanel ui-widget card card-w-title" style="display: block; overflow: hidden;">
                    <div class="chat ui-g-12 ui-md-12" style="overflow: hidden;">


                    </div></div>


            </div><input type="hidden" name="javax.faces.ViewState" id="j_id1:javax.faces.ViewState:2" value="-4063173668612026501:-5230104544957363001" autocomplete="off" />
</form>
                </div>
    
    
            </div>
        </div><div id="j_idt62" style="width:32px;height:32px;position:fixed;right:7px;bottom:7px"><div id="j_idt62_start" style="display:none">
               <i class="fa fa-circle-o-notch fa-spin ajax-loader" aria-hidden="true"></i></div><div id="j_idt62_complete" style="display:none"></div></div><script id="j_idt62_s" type="text/javascript">$(function(){PrimeFaces.cw("AjaxStatus","widget_j_idt62",{id:"j_idt62"});});</script></body>

</html>