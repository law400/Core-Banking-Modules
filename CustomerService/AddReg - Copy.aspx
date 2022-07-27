<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddReg.aspx.vb" Inherits="WebPortal_AddReg" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
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

    .field {
        width : 100%;
        height: 5%;
        color: #606060;
        padding: 2%;
        margin: 2% 0;
    }
     


</style>
     <script  type="text/javascript" >
         function calendarPicker(strTxtRef) {
             window.open('./Controls/Calendar.aspx?field=' + strTxtRef + '', 'calendarPopup', 'titlebar=no,left=50,top=100,width=300,height=250,resizable=no');
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
      
         
       
      
   <%--<div class="panel panel-default">--%>
       
                     <div class="panel-heading">
                      <h4>Customer Registration Form:</h4>                   
        
                      </div>
           <div class="panel-body">
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" BackgroundPosition="Top" Transparency="10">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
     
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

                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:Prime %>"
                                    SelectCommand="SELECT  Node_id,tenant from Tbl_Tenants ORDER By tenant"></asp:SqlDataSource></div>
						
				
              		<%--<div class="row ">--%>
           <div class="col-md-4">
                <asp:Panel ID="Panel4" runat="server">
                   <div class="form-group">
                        <asp:RadioButtonList ID="RdBCustType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">Individual Member</asp:ListItem>
                            <asp:ListItem Value="2">Corporate Member</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="form-group">
                      
                      Use custom customer/member id
                    
                         <asp:RadioButtonList ID="RadioBut_CustomerType" runat="server" AutoPostBack="True"  RepeatDirection="Horizontal" >
                            <asp:ListItem Value="No" Selected ="True" >No</asp:ListItem>
                             <asp:ListItem Value="Yes">Yes</asp:ListItem>
                        </asp:RadioButtonList>
                     </div>
                    
              <%-- <div class="row">  
                   <div class="col-md-5">--%>
                    <div class="form-group">
                    <telerik:RadNumericTextBox ID="txtCustomerId" Runat="server" AutoPostBack="True" CssClass="form-control" Visible="False" Width="100%" EmptyMessage="Enter Customer/Member ID" >
                            <NumberFormat DecimalDigits="0" GroupSeparator="" />
                        </telerik:RadNumericTextBox>
                        
                    </div>
                     </asp:Panel> 
               <div class="form-group">
                   Member ID
                   <asp:TextBox ID="txtemployeeid" Visible ="false"   runat="server" ></asp:TextBox>
               </div>
                 
                    
              
                
           



					<div class ="form-group ">
                 <asp:Image ID="Image1" runat ="server" Height ="100" Width ="100" visible="false"  />
                        </div>
                  
                                    <div class="form-group">
                                  First Name<span style="color: red"><strong>*</strong></span>
                               
                                    <asp:TextBox runat="server" ID="TxtFirstName" CssClass="form-control field"    placeholder="First name"  />
                                          </div>

                                    <div class="form-group">
                               Last Name <span style="color: red"><strong>*</strong></span>
						
						<asp:TextBox runat="server" ID="TxtLastname" CssClass="form-control field" placeholder="Last name"/>
                                </div>
			          
            <div class="form-group">
                
							Middle Name
						
						<asp:TextBox runat="server" ID="TxtMiddlename" CssClass="form-control field" Font-Size="Small"  placeholder="Middle name"/>
                 	</div>
              <div class="form-group">

                             
                     <asp:UpdatePanel ID="updatepanel3" runat ="server" >
                            <ContentTemplate >
							
                                Sex <span style="color: red"><strong>* </strong></span>
                       &nbsp;<asp:DropDownList ID="DrpSex" runat="server"  AutoPostBack="True" CssClass="form-control field"  placeholder="Gender" >
                                              </asp:DropDownList>
                                 </ContentTemplate>
                            </asp:UpdatePanel>
                 
                    </div>

            <div class ="form-group">
                 <asp:UpdatePanel ID="updatepanel2" runat ="server" >
                            <ContentTemplate >
              Date of Birth <span style="color:red"><strong >*</strong></span>
                <%--<asp:HyperLink ID="imgdate1" runat="server" ImageUrl="~/Images/pdate.gif" Width="17px">HyperLink</asp:HyperLink>

                      
                       <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control field" placeholder="Date of birth" Width="149px"></asp:TextBox>--%>

                 
                        <asp:ImageButton ID="ImageButton1" runat="server" class="btn btn-primary"  Font-Bold="True" ForeColor="white" ImageUrl="~/images/calendar.gif" /><asp:TextBox ID="txtDOB" runat="server" CssClass="form-control field" placeholder="Date of birth" Width="149px"></asp:TextBox>
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" CellPadding="4" DayNameFormat="Shortest">
                            <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
</ContentTemplate> </asp:UpdatePanel> 

            </div>
                <div class ="form-group">
                           
                      <asp:UpdatePanel ID="updatepanel4" runat ="server" >
                            <ContentTemplate >
							   Nationality <span style="color: red"><strong>*</strong></span>
                       &nbsp;<asp:DropDownList ID="DrpNational" runat="server"  AutoPostBack="True" CssClass="form-control field"  placeholder="Gender" >
                                              </asp:DropDownList>
                                 </ContentTemplate>
                            </asp:UpdatePanel>
                      
                    </div>

              <div class="form-group">
               <asp:UpdatePanel ID="updatepanel5" runat ="server" >
                            <ContentTemplate >
                           State Of Origin <span style="color: red"><strong>*</strong></span>
                     
                       <asp:DropDownList ID="DrpState" runat="server"  AutoPostBack="True" CssClass="form-control field ">
                                                </asp:DropDownList>
                    </ContentTemplate>
                            </asp:UpdatePanel>
           </div>
                    
             <div class ="form-group">
                 <asp:UpdatePanel ID="updatepanel6" runat ="server" >
                            <ContentTemplate >
                          Sector <span style="color: red"><strong>*</strong></span>
               
                       <asp:DropDownList ID="Drpsector" runat="server" AutoPostBack="True" CssClass="form-control field">
                                                </asp:DropDownList>  </ContentTemplate>
                            </asp:UpdatePanel>
                    
                 </div>
               	<div class="form-group">
                                            
							<label>Upload Photo  :</label>
						<%--<asp:UpdatePanel ID="updatepanel1" runat ="server" >
                            <ContentTemplate >--%>
							<asp:FileUpload ID="File1" runat="server" viewstatemode="Enabled"   CssClass="form-control field "/>
                       <asp:Label ID="lblregphoto" runat ="server" Text ="Image size can not more than 200k" />
                               <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
					</div>
               <div class="panel-group">
    <div class="panel-heading">
                  <h3> Contact  Details </h3>
        </div>
    </div>
                <div class="form-group">
             <asp:UpdatePanel ID="updatepanel7" runat ="server" >
                            <ContentTemplate >
                                Resident State <span style="color: red"><strong>*</strong></span>
                    
                       <asp:DropDownList ID="DrpResState" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control field "  placeholder="Select Resident State" >
                                                </asp:DropDownList>
                                </ContentTemplate> 
                 </asp:UpdatePanel> 

                    </div>
            <div class ="form-group">
                <asp:UpdatePanel ID="updatepanel8" runat ="server" >
                            <ContentTemplate >
               Town <span style ="color: red"><strong>*</strong></span>
                <asp:DropDownList ID="DrpTown" runat ="server" Font-Size ="Small" AutoPostBack ="true" CssClass ="form-control field"  ></asp:DropDownList>
             </ContentTemplate> </asp:UpdatePanel> 
                                </div>
            <div class="form-group">
          
                     Resident Address <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="txtAddress" runat="server" Font-Size="Medium" Height="47px"  Width="100%"
                                                    TextMode="MultiLine" CssClass="form-control" placeholder="Enter Resident Address "></asp:TextBox>
                </div>
                </div>
            <div class="col-md-4">

              <div class="form-group">
                    Office Address
                   
                        <asp:TextBox ID="txtAddress0" runat="server" Font-Size="Medium" Height="47px"  Width="100%"
                                                    TextMode="MultiLine"  CssClass="form-control" placeholder="Enter Office Address" ></asp:TextBox>
                    </div>
                   
              <div class="form-group">
                   Mobile Phone1 <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="txtphone1" runat="server"  placeholder="Mobile Phone" CssClass="form-control field " onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                     </div>
                               <div class="form-group">
                    Mobile Phone2
                     
                        <asp:TextBox ID="Txtphone2" runat="server"  placeholder="Mobile Phone" CssClass="form-control field" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                     
                    </div>
             
       
             <div class="form-group">
              Office Phone
                     
                        <asp:TextBox ID="txtphone3" runat="server"  placeholder="Office Phone" CssClass="form-control field " onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                    </div> 
                 <div class="form-group">  
                    
                    <label>Email Address</label>
                    
                        <asp:TextBox ID="txtemail" runat="server" placeholder="Email" CssClass="form-control field "></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                    ControlToValidate="txtemail" Display="Dynamic" 
                                                    ErrorMessage="enter email correctly" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                    Width="176px" SetFocusOnError="True">enter email correctly</asp:RegularExpressionValidator>
               
                    </div>
          
                            <div class="form-group">
                          BVN
                        <asp:TextBox ID="Txtphone4" runat="server" placeholder="BVN" CssClass="form-control field " onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                      </div>
               <div class="form-group">
                   <asp:UpdatePanel ID="updatepanel9" runat ="server" >
                            <ContentTemplate >
         ID Type <span style="color: red"><strong>*</strong></span>
                     
                       <asp:DropDownList ID="DrpIdType" runat="server" AutoPostBack="True" CssClass="form-control field ">
                                                </asp:DropDownList>

                            </ContentTemplate> </asp:UpdatePanel> 
                     </div>
                   <div class="form-group">
                               ID No <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="txtIdNo" runat="server" Font-Size="Small" Width="100%" placeholder="ID No" CssClass="form-control" > </asp:TextBox>
                       </div>
                   	<div class="form-group">
                                            
							<label>ID Card Upload :</label>
						<%--<asp:UpdatePanel ID="updatepanel2" runat ="server" >
                            <ContentTemplate >--%>
							<asp:FileUpload ID="FileUpload1" runat="server" viewstatemode="Enabled" CssClass="form-control field "/>
                           <asp:Label ID="Label1" runat ="server" Text ="Image size can not more than 200k" />
                              <%--  </ContentTemplate>
                            </asp:UpdatePanel>--%>
					</div>

                         <div class ="form-group ">
                 <asp:Image ID="Image2" runat ="server" Height ="150" Width ="150" Visible ="false" />
             </div>
                      

           

                <div class="panel-group">
    <div class="panel-heading">
                  <h3> Next of Kin  Details </h3>
        </div>
    </div>
             <div class="form-group">
                Name Of Next Of Kin <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="txtnextofKin" runat="server" placeholder="Name Of Next Of Kin" CssClass="form-control field" > </asp:TextBox>
                         </div>
             <div class="form-group">
                  Next Of Kin Phone <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="Txtkinphone" runat="server"  placeholder="Next Of Kin Phone" CssClass="form-control field" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                        </div>
                   
             <div class="form-group">
                  Next Of Kin Address <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="txtKinAddress" runat="server" Font-Size="Medium" Height="47px"  Width="100%"
                                                    TextMode="MultiLine" CssClass="form-control" placeholder="Enter Next Of Kin Address "></asp:TextBox>
        </div>
				<div class="form-group">
						Relationship with Next of kin 
						
                           <asp:TextBox runat="server" ID="TxtNOKRelationship" CssClass="form-control field "   ForeColor = "Black" placeholder="Relationship with Next of kin"/>
                             
					</div>
				 </div>

                   <div class="col-md-4">
<div class="form-group">   
    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack ="true"  Text ="Enter Login Details" />
</div>
                    <div  class="panel-group ">
                         <asp:Panel ID="Panel3" runat="server">
                        <div class="panel-heading">
<h3>Login Details</h3>
               
        </div>
                          	<div class="form-group">
					 UserName <span style="color: red"><strong>*</strong></span>
						
						<asp:textbox ID="txtusername" runat="server"  CssClass="form-control field" placeholder="Username"></asp:textbox>                                          
                             </div>
                                               	<div class="form-group">
							Password<span style="color: red"><strong>*</strong></span>
						<asp:textbox ID="txtpassword" runat="server"  CssClass="form-control field" placeholder="Password" TextMode="Password"></asp:textbox>       
								</div>
                        	<div class="form-group">
							Confirm Password<span style="color: red"><strong>*</strong></span>
						<asp:textbox ID="txtconfirmpassword" runat="server"  CssClass="form-control field" placeholder="Confirm Password" TextMode="Password"></asp:textbox>       
								</div>
                             <div class="form-group ">
                                 <asp:Button ID="BtnLogin" runat="server" visible="false" Text="Modify Login" class="btn btn-primary"   Font-Bold="True" ForeColor="white"/>
</div>
                        </asp:Panel>
                    </div> 
					   
<div class="panel-group">
    <div class="panel-heading">
<h3>Account Creation Section</h3> 
    </div>
                                               	<div class="form-group">
					 Select Account Branch <span style="color: red"><strong>*</strong></span>
						<asp:UpdatePanel ID="updatepanel10" runat ="server" >
                            <ContentTemplate >
						<asp:DropDownList ID="DrpBranch" runat="server" AutoPostBack="True" 
                                                                 CssClass="form-control field ">
                                            </asp:DropDownList>       
                                </ContentTemplate> </asp:UpdatePanel> 
                             </div>
                                               	<div class="form-group">
                                                       <asp:UpdatePanel ID="updatepanel11" runat ="server" >
                            <ContentTemplate >
							<label>Account Product<span style="color: red"><strong>*</strong></span></label>
						
							<asp:DropDownList ID="DrpProduct" runat="server" AutoPostBack="True" 
                                                                 CssClass="form-control field">
                                                            </asp:DropDownList>		
                                </ContentTemplate> </asp:UpdatePanel> 
					</div>

					</div>



               <div class="row">
                                                        <div class="form-group" >                                       
          Account Description<span style="color: red"><strong>*</strong></span>
                                                     
                                                            <asp:TextBox ID="txtacctdesc" runat="server"  Height="47px"  Width="100%"
                                                    
                                                                TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                        </div>  

                                                        <div class="form-group" > 
                                                        <asp:UpdatePanel ID="updatepanel12" runat ="server" >
                            <ContentTemplate > Select SubBranch
                                                            <asp:DropDownList ID="DrpSubBranch" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" CssClass="form-control">
                                                            </asp:DropDownList></ContentTemplate> </asp:UpdatePanel> 
                                                          
							</div>
                     	<div class="form-group">
                      Monthly Contribution <span style="color: red"><strong>*</strong></span>
						
						
						
						<asp:TextBox runat="server" ID="TxtContribution" CssClass="form-control field " placeholder="0.00"></asp:TextBox>    
                               </div>
                             
						
				
<div class="panel-group">
    <div class="panel-heading">
                  <h3> Registration Fee Details </h3>
        </div>
    </div>
                                               	<div class="form-group">
					Account number
						
						<asp:TextBox	runat="server" ID="TxtyourAcctnumber" CssClass="form-control" BackColor="Transparent"  ForeColor = "Black" />
	</div>
                                                    
                   <div class="form-group">
                          <asp:UpdatePanel ID="updatepanel1" runat ="server" >
                            <ContentTemplate >
						 Payment Bank
					
					<asp:DropDownList runat="server" ID="DropDownfee" CssClass="form-control field" >
                                                
                                                    <asp:ListItem Text="-Select Payment bank-" Value="0" />
                                                <asp:ListItem Text="Access Bank" Value="Access Bank"/>
                                                <asp:ListItem Text="CitiBank" Value="CitiBank"/>
                                                <asp:ListItem Text="Diamond Bank" Value="Diamond Bank"/>
                                                <asp:ListItem Text="Ecobank Nigeria" Value="Ecobank Nigeria"/>
                                                <asp:ListItem Text="Enterprise Bank Limited" Value="Enterprise Bank Limited"/>
                                                <asp:ListItem Text="Fidelity Bank Nigeria" Value="Fidelity Bank Nigeria"/>
                                                <asp:ListItem Text="Ecobank Nigeria" Value="Ecobank Nigeria"/>
                                                <asp:ListItem Text="Enterprise Bank Limited" Value="Enterprise Bank Limited"/>
                                                <asp:ListItem Text="Fidelity Bank Nigeria" Value="Fidelity Bank Nigeria"/>
                                                <asp:ListItem Text="First Bank of Nigeria" Value="First Bank of Nigeria"/>
                                                <asp:ListItem Text="First City Monument Bank" Value="First City Monument Bank"/>
                                                <asp:ListItem Text="FSDH Merchant Bank" Value="FSDH Merchant Bank"/>
                                                <asp:ListItem Text="Guaranty Trust Bank" Value="Guaranty Trust Bank"/>
                                                <asp:ListItem Text="Heritage Bank Plc" Value="Heritage Bank Plc"/>
                                                <asp:ListItem Text="Keystone Bank Limited" Value="Keystone Bank Limited"/>
                                                <asp:ListItem Text="Mainstreet Bank Limited" Value="Mainstreet Bank Limited"/>
                                                <asp:ListItem Text="Rand Merchant Bank" Value="Rand Merchant Bank"/>
                                                <asp:ListItem Text="Savannah Bank" Value="Savannah Bank"/>
                                                <asp:ListItem Text="Skye Bank" Value="Skye Bank"/>
                                                <asp:ListItem Text="Stanbic IBTC Bank Nigeria Limited" Value="Stanbic IBTC Bank Nigeria Limited"/>
                                                <asp:ListItem Text="Standard Chartered Bank" Value="Standard Chartered Bank"/>
                                                <asp:ListItem Text="Sterling Bank" Value="Sterling Bank"/>
                                                <asp:ListItem Text="Union Bank of Nigeria" Value="Union Bank of Nigeria"/>
                                                <asp:ListItem Text="United Bank for Africa" Value="United Bank for Africa"/>
                                                <asp:ListItem Text="Unity Bank Plc." Value="Unity Bank Plc."/>
                                                <asp:ListItem Text="Wema Bank" Value="Wema Bank"/>
                                                <asp:ListItem Text="Zenith Bank" Value="Zenith Bank"/>
                                            </asp:DropDownList>
       </ContentTemplate> </asp:UpdatePanel> 
					        
						</div>
				
                                               	<div class="form-group">
                    	Amount
						
					<asp:TextBox runat="server" ID="Txtamount" CssClass="form-control field" Text ="0.00"  placeholder="0.00"/>
                                                       </div>

							     	<div class="form-group">
                                         Teller no
						
						<asp:TextBox runat="server" ID="TxtTellerNumber" CssClass="form-control field " placeholder="Teller number"/>
                              
						
					</div>
               


                    </div>
               </div>
              </telerik:RadAjaxPanel>
              </div>
        <%-- </div>--%>
              <div class="panel-footer">
                     <asp:Button ID="BtnSubmit" runat="server" Text="Submit" class="btn btn-primary"  Font-Bold="True" ForeColor="white"/>
						 <asp:Button ID="BtnEdit" runat="server" Text="Modify" class="btn btn-primary" visible="false"  Font-Bold="True" ForeColor="white"/>
				</div>
 
        
    </form>
</body>
     <script type="text/javascript">
         function ValidateText(obj) {
             if (obj.value.length > 0) {
                 obj.value = obj.value.replace(/[^\d]+/g, '');
             }
         }
   </script>
</html>
