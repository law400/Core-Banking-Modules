<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ChangeContribution.aspx.vb" Inherits="CustomerService_ChangeContribution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>
	<title>UCP Web Portal</title>

<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<%--<meta name="keywords" content="Novus Admin Panel Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
SmartPhone Compatible web template, free WebDesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />--%>
<%--<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>--%>
<!-- Bootstrap Core CSS -->
<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
<!-- Custom CSS -->
<link href="css/style.css" rel='stylesheet' type='text/css' />
<!-- font CSS -->
<!-- font-awesome icons -->
<link href="css/font-awesome.css" rel="stylesheet"> 
<!-- //font-awesome icons -->
 <!-- js-->
<script src="js/jquery-1.11.1.min.js"></script>
<script src="js/modernizr.custom.js"></script>
<!--webfonts-->
<%--<link href='//fonts.googleapis.com/css?family=Roboto+Condensed:400,300,300italic,400italic,700,700italic' rel='stylesheet' type='text/css'/>--%>
<!--//webfonts--> 
<!--animate-->
<link href="css/animate.css" rel="stylesheet" type="text/css" media="all"/>
    <link rel="shortcut icon" href="Homepage/_images/uploads/fav.png"/>
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
<style>
    .divModalBackground

{

filter: alpha(opacity=50); -moz-opacity:0.5; opacity: 0.5;

width:100%;

height:100%;
background-color: #CCCCFF;

position: absolute;

top: 0px; 

left: 0px;

z-index: 800;


}
    .centerBlock {
    position: fixed;
    top: 50%;
    left: 50%;
    width: 50%;
    height: 200px;
    margin: -100px 0 0 -1%;
}
    .field {
        width : 100%;
        height: 5%;
        color: #606060;
        padding: 2%;
        margin: 2% 0;
    }
     
 #dvLoading
{
   background:#000 url(./images/loading.gif) no-repeat center center;
   height: 100px;
   width: 100px;
   position: fixed;
   z-index: 1000;
   left: 50%;
   top: 50%;
   margin: -25px 0 0 -25px;

}

</style>
     <script  type="text/javascript" >
         function calendarPicker(strTxtRef) {
             window.open('./Controls/Calendar.aspx?field=' + strTxtRef + '', 'calendarPopup', 'titlebar=no,left=50,top=100,width=300,height=250,resizable=no');
         }

      
         $(window).load(function () {
             $('#dvLoading').fadeOut(2000);
         });
 


         function ShowProgressBar() {
             if (Page_ClientValidate())
             document.getElementById('dvProgressBar').style.visibility = 'visible';
         }

         function HideProgressBar() {
             document.getElementById('dvProgressBar').style.visibility = "hidden";
         }
    </script>
<%--<script src="js/wow.min.js"></script>--%>
	<%--<script>
	    new WOW().init();
	</script>--%>
<!--//end-animate-->
<!-- Metis Menu -->
<script src="js/metisMenu.min.js"></script>
<script src="js/custom.js"></script>
<link href="css/custom.css" rel="stylesheet"/>
<!--//Metis Menu -->

   
</head> 
    <body>
    <form id="form1" runat="server">
        
         <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
    <link href="../Styles.css" rel="stylesheet" />
 <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.5;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>
        <div class="panel panel-default">
              <div class="panel-heading">
                      <h4>Edit Monthly Contribution Form:</h4>                   
        
                      </div>
              <div class="panel-body" >
            
                                             <asp:Panel ID="Panel1" runat="server" Visible="False">
                              <div class="alert alert-success alert-dismissable">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            <h4>	<i class="icon fa fa-check"></i> Alert!</h4>
                                  <asp:Label ID="Label_success" runat="server" Text=""></asp:Label>
                          </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
                          <div class="alert alert-danger alert-dismissable">
                             <button aria-hidden="true" class="close" data-dismiss="alert" type="button">
                                    ×
                             </button>
                             <h4><i class="icon fa fa-ban"></i>Alert!</h4>
                                <asp:Label ID="Label_error" runat="server"></asp:Label>
                          </div>
                    </asp:Panel>
					
					
						<div class="sign-up2">
                           
                                                       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                            <div class="col-md-12">

                                  <div class="form-group">
                   
                   <asp:TextBox ID="txtemployeeid" Visible ="false"   runat="server" ></asp:TextBox>
               </div>
                                 <div class="form-group">
                                  First Name<span style="color: red"><strong>*</strong></span>
                               
                                    <asp:TextBox runat="server" ID="TxtFirstName" CssClass="form-control field"    placeholder="First name"  />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter first name" SetFocusOnError="True" ControlToValidate="TxtFirstName"></asp:RequiredFieldValidator>
                                         </div>

                                    <div class="form-group">
                               Last Name <span style="color: red"><strong>*</strong></span>
						
						<asp:TextBox runat="server" ID="TxtLastname" CssClass="form-control field" placeholder="Last name"/>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter last name" SetFocusOnError="True" ControlToValidate="TxtLastName"></asp:RequiredFieldValidator>
                                         </div>
			          
            <div class="form-group">
                
							Middle Name
						
						<asp:TextBox runat="server" ID="TxtMiddlename" CssClass="form-control field" Font-Size="Small"  placeholder="Middle name"/>
                 	</div>

                                <div class="form-group">
                
						Monthly	Contribution Account Number
						
						<asp:TextBox runat="server" ID="txtaccountnumber" CssClass="form-control field" Font-Size="Small"  placeholder="Account Number"/>
                 	</div>
                                <div class="form-group">
                                    </div>
                                 <div class="form-group">
                
						Monthly	Contribution 
						 <telerik:RadNumericTextBox ID="txtcontribution" CssClass="form-control" Height="35px"   Width="100%" Runat="server">
                              <NumberFormat DecimalDigits="2" GroupSeparator="" KeepNotRoundedValue="false"  />
                      </telerik:RadNumericTextBox>
                 	</div>
             
                                </div> 
                            </div>                               </div>
             <div class="panel-footer">
                     <asp:Button ID="BtnSubmit" runat="server" Text="Update" class="btn btn-primary"  Font-Bold="True" ForeColor="white"/>
				</div>
        </div>
      </ContentTemplate> 
    </asp:UpdatePanel> 
    </form>
</body>
</html>
