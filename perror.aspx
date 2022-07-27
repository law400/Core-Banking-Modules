<%@ Page Language="VB" AutoEventWireup="false" CodeFile="perror.aspx.vb" Inherits="PrimeError" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
     <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="initial-scale=1.0, width=device-width"/>
     <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="../bootstrap/css/bootstrap.min.css"/>
    <!-- Font Awesome -->
   
    <!-- Theme style -->
     <link rel="stylesheet" href="../dist/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="../dist/ionicons.min.css"/>
    <link rel="stylesheet" href="../dist/css/AdminLTE.min.css"/>
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../dist/css/skins/_all-skins.min.css"/>
      <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 294px;
        }
        .style3
        {
            width: 274px;
        }
        .style4
        {
            width: 274px;
            font-weight: bold;
        }
        .auto-style1 {
            width: 470px;
        }
        .auto-style2 {
            width: 470px;
            font-weight: bold;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div class="box box-info">
                <div class="box-header">
                  <h3 class="box-title"> &nbsp;</h3>
                </div>
                <div class="box-body">
        
      
         
                  <!-- Color Picker -->
         <div class="form-group">         
        <table align="center" class="style1">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="auto-style2" style="color: #0000FF">
                                      <h3> Error 500 An Internal Error has Occurred!</h3> </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Button ID="Button1" runat="server" Text="Return" Visible="False" />
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
                    </div>
    </div>
    </form>
</body>
</html>
