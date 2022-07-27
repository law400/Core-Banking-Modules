<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddCoopReg.aspx.vb" Inherits="CustomerService_AddCoopReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   	<title>UCP Web Portal</title>

<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<%--<meta name="keywords" content="Novus Admin Panel Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
SmartPhone Compatible web template, free WebDesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>--%>
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
<%--<script src="js/wow.min.js"></script>
	<script>
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
         <div class="panel-heading">
                      <h4>Customer Registration Form:</h4>                   
        
                      </div>
          <div class="panel-body">
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
					
        <div>
        </div>
<div class="sign-up2">
                           
                                                       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:Prime %>"
                                    SelectCommand="SELECT  Node_id,tenant from Tbl_Tenants ORDER By tenant"></asp:SqlDataSource>
                            
		 


                          
						</div>
        
         <div class="col-md-4">
               <asp:Panel ID="Panel8" runat="server">
             <div class="form-group">
               
                        <asp:RadioButtonList ID="RdBCustType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" >Individual Member</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">Corporate Member</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
             </asp:Panel>
               <div class="panel-group">
    <div class="panel-heading">
                  <h3> Corporate Details </h3>
        </div>
    </div>
           <div class="form-group">
                                  Corporate Name<span style="color: red"><strong>*</strong></span>
                               
                                    <asp:TextBox runat="server" ID="TxtFullname" CssClass="form-control field"    placeholder="Corporate Name"  />
                                          </div>
         <div class="form-group">
                                  Registration Number<span style="color: red"><strong>*</strong></span>
                               
                                    <asp:TextBox runat="server" ID="txtregno" CssClass="form-control field"    placeholder="Registration Number"  />
                                          </div>

          <div class ="form-group">
               <asp:UpdatePanel ID="updatepanel9" runat ="server" >
                            <ContentTemplate >
             Date of Registration <span style="color:red"><strong >*</strong></span>
             
                        <asp:ImageButton ID="ImageButton1" runat="server" class="btn btn-primary"  Font-Bold="True" ForeColor="white" ImageUrl="~/images/calendar.gif" /><asp:TextBox ID="txtDOB" runat="server" CssClass="form-control field" placeholder="Date of Registration" Width="149px"></asp:TextBox>
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

        <div class="form-group">
                <asp:UpdatePanel ID="updatepanel4" runat ="server" >
                            <ContentTemplate >
                           State  <span style="color: red"><strong>*</strong></span>
                     
                       <asp:DropDownList ID="DrpState" runat="server"  AutoPostBack="True" CssClass="form-control field ">
                                                </asp:DropDownList>
                                </ContentTemplate> 
                    </asp:UpdatePanel> 
           </div>

          <div class ="form-group">
               <asp:UpdatePanel ID="updatepanel1" runat ="server" >
                            <ContentTemplate >
               Town <span style ="color: red"><strong>*</strong></span>
                <asp:DropDownList ID="DrpTown" runat ="server" Font-Size ="Small" AutoPostBack ="true" CssClass ="form-control field"  ></asp:DropDownList>
                          </ContentTemplate>       </asp:UpdatePanel> 
             </div>
        <div class="form-group">
          
                     Contact Address <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="txtAddress" runat="server" Font-Size="Medium" Height="47px"  Width="100%"
                                                    TextMode="MultiLine" CssClass="form-control" placeholder="Contact Address"></asp:TextBox>
                </div>
         <div class ="form-group">
              <asp:UpdatePanel ID="updatepanel2" runat ="server" >
                            <ContentTemplate >
                          Sector <span style="color: red"><strong>*</strong></span>
               
                       <asp:DropDownList ID="Drpsector" runat="server" AutoPostBack="True" CssClass="form-control field">
                                                </asp:DropDownList> 
                                </ContentTemplate> </asp:UpdatePanel> 
                    
                 </div>
         <div class="form-group">
          
                    Business Objective
                     
                        <asp:TextBox ID="Txtbusinessobjective" runat="server" Font-Size="Medium" Height="47px"  Width="100%"
                                                    TextMode="MultiLine" CssClass="form-control" placeholder="Business Objective"></asp:TextBox>
                </div>
          <div class="form-group">
                                 Source of funding
                               
                                    <asp:TextBox runat="server" ID="txtsourcefunding" CssClass="form-control field"    placeholder="Source of funding"  />
                                          </div>

          <div class="form-group">
                                Member strength 
                               
                                    <asp:TextBox runat="server" ID="txtMemberstrength" CssClass="form-control field"  text="0.00"  placeholder="Member strength "  />
                                          </div>
          
         <div class="form-group">
                          BVN
                        <asp:TextBox ID="TxtBVN" runat="server" placeholder="BVN" CssClass="form-control field " onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                      </div>
                      <div class="form-group">
                  Phone Number <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="txtphone" runat="server"  placeholder="Mobile Phone" CssClass="form-control field " onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                     </div>
            <div class="form-group">
                               <asp:TextBox runat="server" ID="TxtGuid" CssClass="form-control field"    visible="false"  />
                  <asp:TextBox runat="server" ID="txtid" CssClass="form-control field"    visible="False"  />
                                          </div>

        <div>
         <label>Email Address</label>
                    
                        <asp:TextBox ID="txtemail" runat="server" placeholder="Email" CssClass="form-control field "></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                    ControlToValidate="txtemail" Display="Dynamic" 
                                                    ErrorMessage="enter email correctly" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                    Width="176px" SetFocusOnError="True">enter email correctly</asp:RegularExpressionValidator>
               
                    </div>
               </div> 
         <div class="col-md-4">
        <div class="panel-group">
              <asp:Panel ID="Panel5" runat="server">  
    <div class="panel-heading">
      
<h3>Account Creation Section</h3> 
           </div>    
    
                                               	<div class="form-group">
					 Select Account Branch <span style="color: red"><strong>*</strong></span>
						 <asp:UpdatePanel ID="updatepanel3" runat ="server" >
                            <ContentTemplate >
						<asp:DropDownList ID="DrpBranch" runat="server" AutoPostBack="True" 
                                                                 CssClass="form-control field ">
                                            </asp:DropDownList>       

                            </ContentTemplate> 

						 </asp:UpdatePanel>                                   
                             </div>
                                               	<div class="form-group">
                                                        <asp:UpdatePanel ID="updatepanel5" runat ="server" >
                            <ContentTemplate >
							<label>Account Product<span style="color: red"><strong>*</strong></span></label>
						
							<asp:DropDownList ID="DrpProduct" runat="server" AutoPostBack="True" 
                                                                 CssClass="form-control field">
                                                            </asp:DropDownList>		
                                </ContentTemplate> </asp:UpdatePanel> 

					</div>

                                                        <div class="form-group" >                                       
          Account Description<span style="color: red"><strong>*</strong></span>
                                                     
                                                            <asp:TextBox ID="txtacctdesc" runat="server"  Height="47px"  Width="100%"
                                                    
                                                                TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                        </div>  

                                                        <div class="form-group" > 
                                                         <asp:UpdatePanel ID="updatepanel6" runat ="server" >
                            <ContentTemplate >
                                                        Select SubBranch
                                                        
                                                            <asp:DropDownList ID="DrpSubBranch" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" CssClass="form-control">
                                                            </asp:DropDownList></ContentTemplate> </asp:UpdatePanel> 
                                                          
							</div>
                     	<div class="form-group">
                      Monthly Contribution <span style="color: red"><strong>*</strong></span>
						
						
						
						<asp:TextBox runat="server" ID="TxtContribution" CssClass="form-control field " placeholder="0.00"></asp:TextBox>    
                               </div>
                  </asp:Panel> 
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
						 Payment Bank
					
					<asp:DropDownList runat="server" ID="DrpBank" CssClass="form-control field" >
                                                
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
       
							
                             
						</div>
				
                                               	<div class="form-group">
                    	Amount
						
					<asp:TextBox runat="server" ID="Txtamount" CssClass="form-control field" Text="0.00"  placeholder="0.00"/>
                                                       </div>

							     	<div class="form-group">
                                         Teller no
						
						<asp:TextBox runat="server" ID="TxtTellerNumber" CssClass="form-control field " placeholder="Teller number"/>
                              
						
					</div>
          <div class="form-control">
                           <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack ="true"  Text ="Enter Login Details"/>

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
                        </asp:Panel>
                    </div> 
                </div> 
         <div class="col-md-4">
        <div class="panel-group">
            <asp:Panel ID="panel4" runat="server" >
                  <div class="panel-heading">

                <h3>Personal Info of signatories</h3>
                      </div> 
                <div class="form-group">
                                   Name<span style="color: red"><strong>*</strong></span>
                               
                                    <asp:TextBox runat="server" ID="txtname" CssClass="form-control field"    placeholder="Corporate Name"  />
                                          </div>
     
                  <div class ="form-group">
                         <asp:UpdatePanel ID="updatepanel8" runat ="server" >
                            <ContentTemplate >
               Position <span style ="color: red"><strong>*</strong></span>
                <asp:DropDownList ID="Drpposition" runat ="server" Font-Size ="Small" AutoPostBack ="true" CssClass ="form-control field"  >
                    <asp:ListItem Value="null">-Select-</asp:ListItem>
                    <asp:ListItem>President</asp:ListItem>
                    <asp:ListItem>Treasurer</asp:ListItem>
                    <asp:ListItem>Secretary</asp:ListItem>
                    <asp:ListItem>Vice president</asp:ListItem>
                    <asp:ListItem Value="Other ">Other </asp:ListItem>
                      </asp:DropDownList>
                                </ContentTemplate></asp:UpdatePanel> 
             </div>

                <div class="form-group">
          
                      Address <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="Txtperaddress" runat="server" Font-Size="Medium" Height="47px"  Width="100%"
                                                    TextMode="MultiLine" CssClass="form-control" placeholder=" Address"></asp:TextBox>
                </div>
                 <div class="form-group">
                          BVN
                        <asp:TextBox ID="Textperbvn" runat="server" placeholder="BVN" CssClass="form-control field " onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                      </div>
                      <div class="form-group">
                  Phone number <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="Txtperphone" runat="server"  placeholder="Mobile Phone" CssClass="form-control field " onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                     </div>
        <div>
         <label>Email </label>
                    
                        <asp:TextBox ID="txtperemail" runat="server" placeholder="Email" CssClass="form-control field "></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                    ControlToValidate="txtemail" Display="Dynamic" 
                                                    ErrorMessage="enter email correctly" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                    Width="176px" SetFocusOnError="True">enter email correctly</asp:RegularExpressionValidator>
               
                    </div>
                 <asp:Panel ID="panel7" runat="server" Visible ="false"  >
                <div class="form-group">
                      
                    <img src="<%= ProfileImage %>" width="80" height="85" style="border-radius: 100%"/>
                     
                    </div>
                      </asp:Panel>
                	<div class="form-group">
                                            
							<label>Passport Photograph Upload :</label>
						
							<asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control field "/>
                        <asp:Label ID="lblregphoto" runat ="server" Text ="Image size should not be more than 200kb" />
					</div>

                    <div class="form-group">
                         <asp:UpdatePanel ID="updatepanel7" runat ="server" >
                            <ContentTemplate >
         ID Type 
                     
                       <asp:DropDownList ID="DrpIdType" runat="server" AutoPostBack="True" CssClass="form-control field ">
                                                </asp:DropDownList></ContentTemplate> </asp:UpdatePanel> 
                     </div>
                   <div class="form-group">
                               ID No 
                     
                        <asp:TextBox ID="txtIdNo" runat="server" Font-Size="Small" Width="100%" placeholder="ID No" CssClass="form-control" > </asp:TextBox>
                       </div>
                 <asp:Panel ID="panel6" runat="server" Visible ="false"  >
                <div class="form-group">
                      
                                        <img src="<%= IDcardImage  %>" width="80" height="85" style="border-radius: 100%"/>
                    </div>
                      </asp:Panel>
                	<div class="form-group">
                                            
							<label>ID Card Upload :</label>
						
							<asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control field "/>
                        <asp:Label ID="Label1" runat ="server" Text ="Image size can not more than 200k" />
					</div>

                <div class="form-group">
                     <asp:Button ID="BtnAdd" runat="server" Text="Add" class="btn btn-primary"   Font-Bold="True" ForeColor="White"/>
                     <asp:Button ID="BtnSignatoryEdit" runat="server" Text="Edit" class="btn btn-primary"  visible="false"  Font-Bold="True" ForeColor="White"/>
                </div>
              
            </asp:Panel>
            </div> 
             </div> 
            </div>
              <div >

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"  onrowdeleting="gridView_RowDeleting" OnSelectedIndexChanged = "OnSelectedIndexChanged" DataKeyNames="id" Width="100%" CssClass="gvdatatable" CellPadding="3" 
               onitemcreated="Grid1_ItemCreated" Font-Size="Small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <RowStyle ForeColor="#000066" HorizontalAlign="Left" />
 

                        <Columns>
                      <asp:BoundField HeaderText="ID"  Visible="false" 
                 DataField="ID" 
                 SortExpression="ID" ></asp:BoundField>
                         <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" > </asp:BoundField>

                <asp:BoundField  DataField="Fullname" HeaderText="Name" SortExpression="FullName" > </asp:BoundField>
                             
                        <asp:BoundField DataField ="Position" HeaderText ="Position" SortExpression ="Position" ></asp:BoundField>

                <asp:BoundField  DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" > </asp:BoundField>

                           
                 <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" > </asp:BoundField>

                         <asp:TemplateField Visible="True" HeaderText="Delete">
            <ItemTemplate>
                           

                
                <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete"  Text="Delete"  />
                </ItemTemplate>


        </asp:TemplateField  >
<asp:TemplateField Visible="True" HeaderText="Select" >
    <ItemTemplate >
    <asp:LinkButton ID="lnkselect" CommandName ="Select"  runat="server">select</asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
                         
                        
                    </Columns>

                         
                    </asp:GridView>

                </div>
  
        
              <div class="panel-footer">
                     <asp:Button ID="BtnSubmit" runat="server" Text="Submit" class="btn btn-primary"  Font-Bold="True" ForeColor="white"/>
						 <asp:Button ID="BtnEdit" runat="server" Text="Submit Edit" class="btn btn-primary" visible="false"  Font-Bold="True" ForeColor="white"/>
				</div>
     
    </form>
</body>
</html>
