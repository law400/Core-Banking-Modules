<%@ Page Language="VB" AutoEventWireup="false"  CodeFile="Home.aspx.vb" Inherits="Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UCP Platform</title>
   <%--  <link href="default.css" rel="stylesheet" type="text/css" />
    <link href="menulist.css" rel="stylesheet" type="text/css" />--%>
     <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
    <link rel="stylesheet" href="resources/css/main.css?v=1.0.1" />
  <%--   <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <!-- Font Awesome -->
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
    <link rel="stylesheet" href="plugins/morris/morris.css"/>
    <!-- jvectormap -->
    <link rel="stylesheet" href="plugins/jvectormap/jquery-jvectormap-1.2.2.css"/>
    <!-- Date Picker -->
    <link rel="stylesheet" href="plugins/datepicker/datepicker3.css"/>
    <!-- Daterange picker -->
    <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker-bs3.css"/>
    <!-- bootstrap wysihtml5 - text editor -->
    <link rel="stylesheet" href="plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"/>--%>
    <script type="text/javascript">
        var addTab = function (tabPanel, id, url, menuname) {
            var tab = tabPanel.getComponent(id);

            if (!tab) {
                tab = tabPanel.add({
                    id: id,
                    title: url,
                    closable: true,
                    autoLoad: {
                        showMask: true,
                        url: url,
                        mode: "iframe",
                        maskMsg: "Loading " + menuname + "..."
                    }
                });


            }

            tabPanel.setActiveTab(tab);
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
    <style type="text/css">
        .formatSizeColor
        {
        	font-size: 14px;
        	
        }
    </style>
   </head>
<body onload="setInterval('getCurrentTime()', 1000);""disableBackButton()">
    <form id="form1" runat="server">
    <div>
    <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Gray" />
     <%--Home Page (Control Panel) --%>
        <ext:Viewport runat="server" Layout="BorderLayout" ID="homepage"  DefaultType="Panel">
           <Items>
                <ext:Panel
                 runat="server"
                 Title="UCP WEB PORTAL"
                 Region="North"
                 Padding="6"
                 Height="131"
                 Icon="House" ID="Stat_win"
                                Html="<div id='header' style='height:80px;margin: -10px; background-image:url(images/ucp.jpg);'><a style='float:right;margin-right:10px;' href='#' target='_blank'></a><div class='style3'></div></div>" Footer="False" LabelWidth="100">
                            <%--    Html="<div id='header' style='height:43px; background-color: #EFCCCC;'><a style='float:right;margin-right:10px;' href='#' target='_blank'><img style='margin-top: 4px;' src='images/logo_animatex.gif'/></a><div class='style3'><img style='margin-top: 4px;' src='images/logo_trim.gif'/></div></div>" Footer="False" LabelWidth="100">--%>
               <Content>
              <%-- <div style="font-family: Tahoma; color: #eF0000; font-size: small;"><strong>Today Is:</strong></span> <asp:Label  ID="lblDate" runat="server" ></asp:Label>
               <strong>Location:&nbsp;&nbsp;</span><span class="style1"><asp:Label  ID="lblLocation0" runat="server" style="color: #000000" ></asp:Label>
               <asp:Label  ID="lblLocation1" runat="server" style="color: #000000" ></asp:Label>
                  <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                    <AnonymousTemplate>
                        [ <a href="~/Login.aspx" ID="HeadLoginStatus0" runat="server">Log In</a> ]
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        <span class="style1"><strong>Welcome:</strong></span> <span class="bold"><asp:LoginName ID="HeadLoginName" runat="server" /></span>!
                        [ <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutText="Log Out" LogoutPageUrl="~/Login.aspx"/> ]
                    </LoggedInTemplate>
                </asp:LoginView>
                </div>--%>
               <div style='background-image:url(images/mtnbg.jpg);'></div>
                  
               </Content>
                 <TopBar>
                     <ext:StatusBar ID="StatusBar1" runat="server">                      
                       <Items>
                           <ext:Button runat="server" ID="ButDashboard" Text="Dashboard" Icon="Stop" NavigateUrl="~/Dashboards.aspx">
                          
                          </ext:Button>
                          <ext:Label ID="LblSystemDate" runat="server"  Icon="Time"/>  
                          <ext:Label ID="lblUsername" runat="server"  Icon="User"/>  
                          <ext:Label ID="Lbluser" runat="server"  Icon="User"/>  
                          <ext:Label ID="LblReportTo" runat="server"  Icon="Group"/>  
                          <ext:Label ID="lblTillBalance" runat="server"  Icon="Money" >
                            
                          </ext:Label> 
                          <ext:Label ID="time" runat="server" Icon="Time"/>
                          <ext:Label ID="lblBranch" runat="server"  Icon="House" Cls="formatSizeColor" />
                         <ext:Button runat="server" ID="btnHelp" Text="Help" Icon="Help" >
                          
                          </ext:Button>
                             <ext:Button runat="server" ID="ButSignOut" Text="LogOut" Icon="Stop" NavigateUrl="~/SignOut.aspx">
                          </ext:Button>
                          
                             <ext:Button runat="server" ID="But_Refresh" Text="Refresh" Icon="PageRefresh" OnClientClick="But_Refresh_Click">
                          
                          </ext:Button>
                             <ext:Button runat="server" ID="Button2" Text="Help" Icon="Help" >
                          
                          </ext:Button>
                       </Items>
                     </ext:StatusBar>

                 </TopBar>
                 </ext:Panel>   
              <ext:Panel ID="Panel1"
                  runat="server"
                  Title="Menu" AutoScroll="true"
                  Region="West"
                  Layout="AccordionLayout"
                  Width="255"
                  MaxWidth="350"
                  Collapsible="true">
                  <Items>
                   
                    <%--  <ext:Toolbar runat="server" Cls="left-header">
                                <Items>
                                   
                          <ext:TriggerField ID="TriggerField2" runat="server"
                               Flex="1"
                              EnableKeyEvents="true"
                                        EmptyText="Filter Menu..."
                                        RemoveClearTrigger="true">
                               <Triggers>
                                            <ext:FieldTrigger Icon="Clear" />
                                        </Triggers>
                              <Listeners>
                                  <KeyUp Fn="keyUp" Buffer="500" />
                                            <TriggerClick Fn="clearFilter" />
                                            <SpecialKey Fn="filterSpecialKey" Delay="1" />
                              </Listeners>
                          </ext:TriggerField>
                      </Items>
                          </ext:Toolbar>--%>

                   </Items>
                  </ext:Panel>
                    
              <%-- <ext:TabPanel 
                 ID="TabPanel1" 
                 runat="server" EnableTabScroll="true" 
                 Region="Center" ActiveTabIndex="-1" />      --%>
               <ext:TabPanel 
				ID="TabPanel1" 
				runat="server" 
				Region="Center" 
				Margins="0 4 4 0" 
				Cls="tabs"
				MinTabWidth="115">
				<Items>
					<ext:Panel 
						ID="tabHome" 
						runat="server" 
						Title="Home"
						HideMode="Offsets"
						Icon="Application">
						<AutoLoad Url="Dashboards.aspx" Mode="IFrame" ShowMask="true" />
					</ext:Panel>
				</Items>
				
			</ext:TabPanel>
           </Items>
        </ext:Viewport>
          
    </div>
    </form>
    <!-- Responsive Bootstrap Toolkit -->
<script type="text/javascript" src="js/bootstrap-toolkit.min.js"></script>
<!-- Your scripts using Responsive Bootstrap Toolkit -->
<script type="text/javascript" src="js/main.js"></script>
</body>
</html>
