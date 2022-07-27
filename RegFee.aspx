<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RegFee.aspx.vb" EnableEventValidation ="false" Inherits="RegFee" %>

<!DOCTYPE html>  
<html lang="en">
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta name="description" content="">
<meta name="author" content="">
<link rel="icon" type="image/png" sizes="16x16" href="plugins/images/favicon.png">
<title>UCP</title>
<!-- Bootstrap Core CSS -->
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
</head>
<body>

    <form runat="server" style="background-image:url(ucpbg.jpg); height: 100%; background-size: contain;">
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
         <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>


 <section>
            
            <div class="panel panel-signin">
                <div class="panel-body">
                    <div class="logo text-center">
                        <img src="ucpweb.png" alt="" >
                    </div>
                    <br />
                    <h4 class="text-center mb5">Payment Form</h4>
                    
                    <div class="mb30">Transaction Id:
                        <asp:Label ID="LblTransactionId" runat="server" Text="Label"></asp:Label>
                    </div>

        <asp:Panel ID="Panel1" runat="server" Visible="false">
                      <div class="alert alert-success alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                          <asp:Label ID="Label_success" runat="server" Text=""></asp:Label>
                  </div>
                </asp:Panel>

          <asp:Panel ID="Panel2" runat="server" Visible="false">
                    <div class="alert alert-danger alert-dismissable">
                        <button aria-hidden="true" class="close" data-dismiss="alert" type="button">
                            ×
                        </button>
                      
                        <asp:Label ID="Label_error" runat="server" Text=""></asp:Label>
                    </div>
                </asp:Panel>
           
           <asp:Panel ID="PanelCoop" runat="server" Visible="False" >
                    <div class="alert alert-warning" >
                       
                        <asp:Label ID="LblCooperative" runat="server" Font-Bold="True"></asp:Label>
                    </div>
                </asp:Panel>

          
          <div class="form-group">
                                    <label for="exampleInputEmail1">Name :</label>
                                   
                                   <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Enter your name" ReadOnly="True"></asp:TextBox>
                              
                                   
                                </div>
           <div class="form-group">
                                    <label for="exampleInputEmail1">Email :</label>
                                   
                                   <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Enter your name" ReadOnly="True"></asp:TextBox>
                              
                                   
                                </div>

           <div class="form-group">
                                    <label for="exampleInputEmail1">Phone :</label>
                                   
                                   <asp:TextBox ID="TxtPhone" runat="server" class="form-control" placeholder="Enter your name" ReadOnly="True" ></asp:TextBox>
                              
                                   
                                </div>




          <div class="form-group">
                                    <label for="exampleInputEmail1">Amount :</label>
                                   
                                   <asp:TextBox ID="TxtAmount" runat="server" class="form-control" ReadOnly="True" ></asp:TextBox>
                              
                                   
                                </div>

          <div class="form-group">
                                    <label for="exampleInputEmail1">Convenience Fee:</label>
                                   
                                   <asp:TextBox ID="TxtProcessingFee" runat="server" class="form-control" ReadOnly="True" ></asp:TextBox>
                              
                                   
                                </div>

           <div class="form-group">
                                    <label for="exampleInputEmail1">Grand total :</label>
                                   
                                   <asp:TextBox ID="Txt_TotalPay" runat="server" class="form-control" ReadOnly="True" ></asp:TextBox>
                              
                                   
                                </div>

          <div class="form-group">
                                    <label for="exampleInputEmail1">Payment Type :</label>
                                   
                                   <asp:DropDownList ID="Drp_Paymenttype" runat="server" class="form-control">
                                             <asp:ListItem Value="0 ">-- Select Payment Type </asp:ListItem>
                                             <asp:ListItem>Verve Card</asp:ListItem>
                                             <asp:ListItem Value="VISA">Visa</asp:ListItem>
                                             <asp:ListItem>MasterCard</asp:ListItem>
                                             <asp:ListItem>PocketMoni</asp:ListItem>
                                             <asp:ListItem>POS</asp:ListItem>
                                             <asp:ListItem>BANK BRANCH</asp:ListItem>
                                             <asp:ListItem>BANK INTERNET</asp:ListItem>
                                             <asp:ListItem>Remita Account Transfer</asp:ListItem>
                                     </asp:DropDownList>
                                   
                                </div>

               
       
      
        <div class="panel-footer">
          <div class="col-xs-12">
            <%--<button class="btn btn-info btn-lg btn-block text-uppercase waves-effect waves-light" type="submit">Log In</button>--%>
             
                <asp:Button ID="BtnSubmit" runat="server" Text="Pay" class="btn btn-success" tabindex="7" Enabled="true" Width ="100%"/>

          </div>
        </div>

          
     
        

        
           <script src="Scripts/jquery-1.10.2.min.js"></script>
    <%--<script src="Scripts/bootstrap.min.js"></script>--%>


     <script type="text/javascript">
         $(document).ready(function () {

             //Close the bootstrap alert
             $('#linkClose').click(function () {
                 $('#divError').hide('fade');
             });

             // Save the new user details
             $('#btnRegister1').click(function () {
                 $.ajax(
                     {
                         success: function () {
                             $('#successModal').modal('show');
                         }

                     });
             });
             $('#btnRegister2').click(function () {
                 $.ajax(
                     {

                         success: function () {
                             $('#guarantor2Modal').modal('show');
                         }

                     });
             });
             $('#btnRegister3').click(function () {
                 $.ajax(
                     {

                         success: function () {
                             $('#guarantor3Modal').modal('show');
                         }

                     });
             });
             $('#btnRegister4').click(function () {
                 $.ajax(
                     {

                         success: function () {
                             $('#guarantor4Modal').modal('show');
                         }

                     });
             });
             $('#btnRegister5').click(function () {
                 $.ajax(
                     {

                         success: function () {
                             $('#guarantor5Modal').modal('show');
                         }

                     });
             });
         });
    </script>

        
                </div>
            </div>

  

    
  </section>


</form>
</body>
</html>

