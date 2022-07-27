<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CreatePortalAccess.aspx.vb" Inherits="CustomerService_CreatePortalAccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Portal Access</title>
     <link href="template/css/style.default.css" rel="stylesheet"/>
        <link href="template/css/morris.css" rel="stylesheet"/>
        <link href="template/css/select2.css" rel="stylesheet" />
        <!-- Theme style -->
     <link rel="stylesheet" href="dist/font-awesome.min.css"/>
        <link rel="stylesheet" href="dist/font-awesome.css"/>

    <!-- Ionicons -->
    <link rel="stylesheet" href="dist/ionicons.min.css"/>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>
     <link rel="stylesheet" href="dist/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="dist/ionicons.min.css"/>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>
     <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="plugins/jvectormap/jquery-jvectormap-1.2.2.css"/>
   
    <!-- Theme style -->
     <link rel="stylesheet" href="dist/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="dist/ionicons.min.css"/>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>

   <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="plugins/jvectormap/jquery-jvectormap-1.2.2.css"/>
   
    <!-- Theme style -->
     <link rel="stylesheet" href="dist/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="dist/ionicons.min.css"/>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>
     <link  href="css/css/bootstrap-cerulean.css" rel="stylesheet"/>
 

   



    <link rel="stylesheet" href="dist/font-awesome.css"/>
    <link href="css/bootstrap-responsive.css" rel="stylesheet"/>
    <link href="css/charisma-app.css" rel="stylesheet"/>
    <link href="css/jquery-ui-1.8.21.custom.css" rel="stylesheet"/>
    
    <link href="css/uniform.default.css" rel="stylesheet"/>
    <link href="css/colorbox.css" rel="stylesheet"/>
    <link href="css/jquery.cleditor.css" rel="stylesheet"/>
    <link href="css/jquery.noty.css" rel="stylesheet"/>
    <link href="css/noty_theme_default.css" rel="stylesheet"/>
    <link href="css/elfinder.min.css" rel="stylesheet"/>
    
    <link href="css/opa-icons.css" rel="stylesheet"/>
    <link href="css/uploadify.css" rel="stylesheet"/>
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css"/>
    <%--      <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>

    <link rel="stylesheet" type="text/css" href="css/jquery.dataTables.min.css"  />


        <link rel="stylesheet" type="text/css" href="css/buttons.jqueryui.min.css"  />
            <link rel="stylesheet" type="text/css" href="css/buttons.jqueryui.css"  />


    
        <link rel="stylesheet" type="text/css" href="css/buttons.semanticui.css"  />
            <link rel="stylesheet" type="text/css" href="css/buttons.semanticui.min.css"  />

    
        <link rel="stylesheet" type="text/css" href="css/buttons.foundation.css"  />
            <link rel="stylesheet" type="text/css" href="css/buttons.foundation.min.css"  />

    
        <link rel="stylesheet" type="text/css" href="css/buttons.dataTables.css"  />
            <link rel="stylesheet" type="text/css" href="css/buttons.dataTables.min.css"  />

    
        <link rel="stylesheet" type="text/css" href="css/buttons.bootstrap.css"  />
            <link rel="stylesheet" type="text/css" href="css/buttons.bootstrap.min.css"  />

    
        <link rel="stylesheet" type="text/css" href="css/buttons.bootstrap4.css"  />
            <link rel="stylesheet" type="text/css" href="css/buttons.bootstrap4.min.css"  />



   
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css"/>

 <script src="Assets/toastr.min.js"></script>
        <script src="Assets/script.js"></script>
        <link href="Assets/toastr.min.css" rel="stylesheet" />


     <script src="template/js/jquery-1.11.1.min.js"></script>

    <script type="text/javascript">
            function CloseAndRebind(args)
            {
                GetRadWindow().BrowserWindow.refreshGrid(args);
                GetRadWindow().close();
            }
  
            function GetRadWindow()
            {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)
  
                return oWindow;
            }
  
            function CancelEdit()
            {
                GetRadWindow().close();
            }

            function extendedValidatorUpdateDisplay(obj) {
                // Appelle la méthode originale
                if (typeof originalValidatorUpdateDisplay === "function") {
                    originalValidatorUpdateDisplay(obj);
                }

                // Récupère l'état du control (valide ou invalide) 
                // et ajoute ou enlève la classe has-error
                var control = document.getElementById(obj.controltovalidate);
                if (control) {
                    var isValid = true;
                    for (var i = 0; i < control.Validators.length; i += 1) {
                        if (!control.Validators[i].isvalid) {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid) {
                        $(control).closest(".form-group").removeClass("has-error");
                    } else {
                        $(control).closest(".form-group").addClass("has-error");
                    }
                }
            }

            // Remplace la méthode ValidatorUpdateDisplay
            var originalValidatorUpdateDisplay = window.ValidatorUpdateDisplay;
            window.ValidatorUpdateDisplay = extendedValidatorUpdateDisplay;

            function ShowProgressBar() {
                if (Page_ClientValidate())
                    document.getElementById('dvProgressBar').style.visibility = 'visible';
            }

            function HideProgressBar() {
                document.getElementById('dvProgressBar').style.visibility = "hidden";
            }
        </script>
</head>
<body onload="javascript:HideProgressBar()" >
    <form id="form1" runat="server">
         <div id="dvProgressBar" style="float:left;visibility: hidden; filter: alpha(opacity=50); -moz-opacity:0.5; opacity: 0.5;

width:100%;

height:5000px;
background-color: #CCCCFF;

position: absolute;

top: 0px; 

left: 0px;

z-index: 800;" >
<%--       <asp:Panel ID="Panel5" runat="server" Height="5000px" Width="100%" CssClass="divModalBackground" Visible="True" >--%>
<div class="centerBlock">
   
<%--<asp:Image runat="Server" ID="ImageLoader" CssClass="LoadingProgress" ImageUrl="~/images/loading.gif"  />--%>
 <h4 style="color: #000000; font-weight: bold; margin-left: -30px;">Processing</h4> 
    <br/>    
</div>
<%--</asp:Panel>--%>
 </div>
     <asp:ScriptManager runat="server" ID="ScriptManager1">

    </asp:ScriptManager>
     <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
  
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <%--<div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.7;">--%>
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        <%--</div>--%>
		 
    </ProgressTemplate>
        </asp:UpdateProgress>
    
	<asp:Panel ID="Panel1" runat="server" Visible="False">
                      <div class="alert alert-success alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <h4>	<i class="icon fa fa-check"></i> Alert!</h4>
                          <asp:Label ID="Label_success" runat="server" Text=""></asp:Label>
                  </div>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" Visible="False">
                    <div class="alert alert-danger alert-dismissable">
                        <button aria-hidden="true" class="close" data-dismiss="alert" type="button">
                            ×
                        </button>
                        <h4><i class="icon fa fa-ban"></i>Alert!</h4>
                        <asp:Label ID="Label_error" runat="server" Text=""></asp:Label>
                    </div>
                </asp:Panel>
    <div class="panel panel-default">
            <div class="panel-heading">
<h3>Create Login Details</h3>
               
        </div>
               <div class="panel-body">
                   
                          	<div class="form-group">
					            User Name <span style="color: red"><strong>*</strong></span>
						
						<asp:textbox ID="txtusername" runat="server"  CssClass="form-control field" placeholder="Username"></asp:textbox>                                          
                                <br />
                                <asp:Label ID="someLabelBelowTheTextBox" runat="server" ForeColor="Red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="help-block" ControlToValidate="txtusername" Display="Dynamic" ErrorMessage="Please enter user name"></asp:RequiredFieldValidator>
                             </div>
                                               	<div class="form-group">
							Password<span style="color: red"><strong>*</strong></span>
						<asp:textbox ID="txtpassword" runat="server"  CssClass="form-control field" placeholder="Password" TextMode="Password"></asp:textbox>       
								                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="help-block" ControlToValidate="txtpassword" Display="Dynamic" ErrorMessage="Please enter password"></asp:RequiredFieldValidator>
								</div>
                        	<div class="form-group">
							Confirm Password<span style="color: red"><strong>*</strong></span>
						<asp:textbox ID="txtconfirmpassword" runat="server"  CssClass="form-control field" placeholder="Confirm Password" TextMode="Password"></asp:textbox>       
								<br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="help-block" ControlToValidate="txtconfirmpassword" Display="Dynamic" ErrorMessage="Please enter confirm password"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="help-block" ControlToCompare="txtpassword" ControlToValidate="txtconfirmpassword" ErrorMessage="Password mis-match; password confirmation not correct"></asp:CompareValidator>
								</div>
                             <div class="form-group ">
</div>
                    </div>

                <div class="panel-footer">

                    <asp:Button ID="BtnSubmit" runat="server" Font-Size="Small" Text="Submit" 
                         ValidationGroup="News" CssClass="btn btn-primary" OnClientClick="javascript:ShowProgressBar()" />
                     
                   <asp:Button ID="BtnReset" runat="server" Font-Size="Small" Text="Reset"  CssClass="btn btn-danger" OnClientClick="javascript:ShowProgressBar()" />

               </div>


             </div>
</ContentTemplate> 
</asp:UpdatePanel> 
    </form>
</body>
</html>
