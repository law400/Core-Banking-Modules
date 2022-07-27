<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserAccount.aspx.vb" Inherits="UserAccount"  %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">


    <title>UCP Sign UP</title>
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

      <link href="template/css/style.default.css" rel="stylesheet">

    <script src='https://www.google.com/recaptcha/api.js'></script>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <!-- Bootstrap Core CSS -->
   
 <%--   <!-- Custom CSS -->
    <link href="one-page-wonder.css" rel="stylesheet">--%>
    <style>
        .colorgraph {
            height: 5px;
            border-top: 0;
            background: #c4e17f;
            border-radius: 5px;
            background-image: -webkit-linear-gradient(left, #c4e17f, #c4e17f 12.5%, #f7fdca 12.5%, #f7fdca 25%, #fecf71 25%, #fecf71 37.5%, #f0776c 37.5%, #f0776c 50%, #db9dbe 50%, #db9dbe 62.5%, #c49cde 62.5%, #c49cde 75%, #669ae1 75%, #669ae1 87.5%, #62c2e4 87.5%, #62c2e4);
            background-image: -moz-linear-gradient(left, #c4e17f, #c4e17f 12.5%, #f7fdca 12.5%, #f7fdca 25%, #fecf71 25%, #fecf71 37.5%, #f0776c 37.5%, #f0776c 50%, #db9dbe 50%, #db9dbe 62.5%, #c49cde 62.5%, #c49cde 75%, #669ae1 75%, #669ae1 87.5%, #62c2e4 87.5%, #62c2e4);
            background-image: -o-linear-gradient(left, #c4e17f, #c4e17f 12.5%, #f7fdca 12.5%, #f7fdca 25%, #fecf71 25%, #fecf71 37.5%, #f0776c 37.5%, #f0776c 50%, #db9dbe 50%, #db9dbe 62.5%, #c49cde 62.5%, #c49cde 75%, #669ae1 75%, #669ae1 87.5%, #62c2e4 87.5%, #62c2e4);
            background-image: linear-gradient(to right, #c4e17f, #c4e17f 12.5%, #f7fdca 12.5%, #f7fdca 25%, #fecf71 25%, #fecf71 37.5%, #f0776c 37.5%, #f0776c 50%, #db9dbe 50%, #db9dbe 62.5%, #c49cde 62.5%, #c49cde 75%, #669ae1 75%, #669ae1 87.5%, #62c2e4 87.5%, #62c2e4);
        }
    </style>

    
     
        <link  href="toastr.min.css" rel="stylesheet" />
    <script type="text/javascript">
         function ValidateText(obj) {
             if (obj.value.length > 0) {
                 obj.value = obj.value.replace(/[^\d]+/g, '');
             }
         }
   </script>
</head>

<body>
    
 <form id="form1" runat="server">
    

    <!-- Navigation -->
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
                        <li><a runat="server" href="~/#" style=" color: white;">Cooperative Sign Up Form </a></li>
                    </ul>
                </div>
                </div>
    </div>
     <br />
       <br />
     
       <div class="container" style="margin-top: 30px;">
           <asp:Panel runat="server" BackColor="LightGray" GroupingText=""></asp:Panel>
        <!-- First Featurette -->
        
            <!------------------------code---------------start---------------->
            <div class="container" <%--style="background-color: lightgray;"--%>>

                <div class="row">
                    <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3" style="background-color: white; border-radius: 6px;">
                      

               <asp:Panel ID="Panel3" runat="server" Height="74px" Visible="False" Width="571px" BackColor="#33CC33">
            <div class="bg-green">
            <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>   
        </div>
        </asp:Panel>
                            <asp:Panel ID="Panel2" runat="server" Height="66px" Visible="false" Width="577px">
                            <div class="alert alert-danger alert-dismissable">
                           <h4><i class="alert-success"></i> Alert!</h4>
                            <asp:Label ID="Label2" runat="server"></asp:Label>   
                             </div>
                                </asp:Panel>
                            <h2>&nbsp;</h2>
                            <hr class="colorgraph">
                            <div class="row">
                                <div class="col-xs-12 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtUsername" runat="server" class="form-control input-md" placeholder="Name of Cooperative * " tabindex="1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" SetFocusOnError="True" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                                    </div>
                                    </div>
                                     <div class="col-xs-12 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCoopID" runat="server" class="form-control input-md" placeholder="Registration Number * " tabindex="1"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" SetFocusOnError="True" ControlToValidate="txtCoopID"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                                </div>
                                <div class="row">
                                      <div class="col-xs-12 col-sm-6 col-md-6">
                      
                            <div class="form-group">
                                <asp:TextBox ID="txtOrdAdd" runat="server" class="form-control input-md" placeholder="Contact Address *" tabindex="1"  ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" SetFocusOnError="True" ControlToValidate="txtOrdAdd"></asp:RequiredFieldValidator>
 
                            </div>  
                                </div>
                                 <div class="col-xs-12 col-sm-6 col-md-6">
                                    <div class="form-group">
              
                                        <asp:DropDownList ID="DrpState" runat="server" class="form-control input-md" ></asp:DropDownList>
                                    </div>
                                </div>
                                 
                            </div>
                              

                            <div class="row">
                                 <div class="col-xs-12 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPhone" runat="server" class="form-control input-md" placeholder="Contact Phone No.  *" tabindex="1"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" SetFocusOnError="True" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
     
                                    </div>
                                </div>

                                 <div class="col-xs-12 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control input-md" placeholder="Contact Email *" tabindex="1"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" SetFocusOnError="True" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                    ControlToValidate="txtemail" Display="Dynamic" 
                                                    ErrorMessage="* Invalid Email" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                    Width="176px" SetFocusOnError="True">Please Enter Email Correctly</asp:RegularExpressionValidator>
                                    </div>    
                                </div>
                                

                             
                              
                            </div>

                            <div class="row">
                                   <div class="col-xs-12 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtContactPerson" runat="server" class="form-control input-md" placeholder="Name of Contact Person * " tabindex="1"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required" SetFocusOnError="True" ControlToValidate="txtContactPerson"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                   <div class="col-xs-12 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtDesignation" runat="server" class="form-control input-md" placeholder="Contact Person's Designation *" tabindex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required" SetFocusOnError="True" ControlToValidate="txtDesignation"></asp:RequiredFieldValidator>
          
                                    </div>

                                    
                                </div>

                                   </div>
                               
                               

                            
                            
                               


                           <div class="row">
                                <div class="col-xs-12 col-sm-6 col-md-6">
                      
                            <div class="form-group">
                                <asp:TextBox ID="txtAlterEmail1" runat="server" class="form-control input-md" placeholder="Alternative Email " tabindex="1"  >

                                </asp:TextBox>
                            </div>  
                                </div>
                                <div class="col-xs-12 col-sm-6 col-md-6">
                                    <div class="form-group">   <asp:TextBox ID="TxtAlterEmail2" runat="server" class="form-control input-md" placeholder="Alternative Email " tabindex="1" 

                          ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            
                         <div class="row">
                                <div class="col-xs-12 col-sm-6 col-md-6">
                      
                            <div class="form-group">
                               <asp:DropDownList ID="DropCoopType" runat="server" class="form-control input-md" ></asp:DropDownList>
                               
                            </div>  
                                </div>
                                <div class="col-xs-12 col-sm-6 col-md-6">
                                    <div class="form-group">   
                                        <asp:TextBox ID="TxtMemberStrength" runat="server" class="form-control input-md" placeholder="Number of Member(s) *" tabindex="12" onkeyup="ValidateText(this);"  onpaste = "return false;" 

                          ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required" SetFocusOnError="True" ControlToValidate="TxtMemberStrength"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>
                            

                            <div class="row">

                                <div class="col-md-12"">
                                    <div class="form-group">  
                                         <asp:TextBox ID="TxtReferrer" runat="server" class="form-control input-md" placeholder="Introducer’s/Agent’s Name " tabindex="1" >

                          </asp:TextBox>
                            </div>
                           
                            </div>

                                
                          </div>
                            <div class="row">
                              
                             
                                 <div class="col-md-12">
                               <div class="ckbox ckbox-primary mt5">
                                    
                                    <input type="checkbox" id="agree" value="1" runat="server"/>
                                    <label for="agree">I agree with  &nbsp;<a href="EULA.aspx"  target="_blank">Terms and Conditions</a></label>
                                </div>
                                   
</div>
     
                                 <div class="col-md-12">
                                  <div class="g-recaptcha" data-sitekey="6Ldl0kwUAAAAABsHZ9LcH56JaOkkHsn0aSPpt6yR"></div>
                              </div>
                            </div>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
       <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>


                           <hr class="colorgraph">
                            <div class="row">
                                <div class="col-xs-12">
                                    <%--   <input type="submit" value="Register" class="btn btn-primary btn-block btn-lg" tabindex="7">--%>
                                    <asp:Button ID="Button1" runat="server" Text="Register" class="btn btn-primary btn-block btn-lg" tabindex="7" Enabled="true"/>

                               </div>
                               <%--  <div class="col-xs-12 col-md-6">
                                <%--  <a href="~/signIn.aspx" class="btn btn-primary btn-block btn-lg">Sign In</a>--%>
                                  <%--   <asp:Button ID="Button2" runat="server" Text="Admin Login" class="btn btn-primary btn-block btn-lg" tabindex="7"/>
                                </div>--%>
                                
                                <%--<asp:Button ID="Button2" runat="server" Text="Sign In" class="btn btn-primary btn-block btn-lg" tabindex="7" />--%>
                            </div>

                    
                                      </ContentTemplate> 
    </asp:UpdatePanel> 


 <asp:Panel ID="Panel1" runat="server" Width="800px">
        <div class="bg-green">
           <%-- <h4><i class="icon fa fa-ban"></i> Alert!</h4>--%>
             <asp:Label ID="LblEmailMessage" runat="server" Text=" " Font-Bold="True" ForeColor="Black"></asp:Label>   
        </div>
        </asp:Panel>

                   
                </div>
            
            
            </div>

            <!----Code------end----------------------------------->
        </div>

</div>
 
   </form>      
      
    <div  class="row">
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         
      <footer class="main-footer" style="margin-top: -25px; background-color: white; height: 45px;">     
        
        Copyright &copy; <%= DateTime.Now.Year %>  <a href= "http://www.cwg-plc.com" target= "_blank" > CWG PLC</a>. All rights reserved.
            <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
      </footer>
        </div>
        <script src="https://www.tutorialspoint.com/bootstrap/scripts/jquery.min.js">
        </script>

        <!-- Bootstrap Core JavaScript -->
        <script src="https://www.tutorialspoint.com/bootstrap/js/bootstrap.min.js">
        </script>

     <script src="toastr.min.js"></script>
        <script src="script.js"></script>
       
</body>

</html>
