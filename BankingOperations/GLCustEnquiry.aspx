<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GLCustEnquiry.aspx.vb" Inherits="BankingOperations_GLCustEnquiry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head id="Head1" runat="server">
    <title>GL And Customer Enquiry Page</title>

       <style type="text/css">
           .style1
           {
               height: 25px;
               width: 150px;
           }
           .style2
           {
               height: 25px;
           }
           .style3
           {
               width: 521px;
           }
       </style>
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
       <script type="text/javascript">
           function DisplayLoadingDiv() {


               document.getElementById("loading").style.display = ''; //displays the div



               /*Inside this div place a loading.gif image*/

           }

           function HideLoadingDiv() {

               document.getElementById("loading").style.display = 'none';

               //Hide the div

           }


       </script>
</head>
<body onload='HideLoadingDiv()'>
    <form id="CustEnquiry" runat="server">

  <div class="post boxed">
	<div class="box box-info">
                <div class="box-header">
                  <h3 class="box-title"> GL/ CUSTOMER ENQUIRY </h3>
                </div>
                <div class="box-body">
     <table style="width: 392px; height: 383px;">
        <tr>
            <td colspan="4" style="height: 25px; text-align: left;">
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" style="font-weight: 700" 
                            
                            Text="Note: Choose a Search Option. (GL or Customer).Enter Any Short Form Of the Customer or GL Account, Then Click Search To Find. Check the Box in Front Of the Name and Click Return to Go Back."></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="text-align: left;" class="style2">
                </td>
            <td colspan="1" style="width: 104px; height: 25px; text-align: center">
                </td>
            <td colspan="1" style="width: 47px; height: 25px; text-align: left">
                </td>
            <td colspan="1" style="height: 25px; width: 82px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: left;" class="style2" colspan="2">
                Search Option<asp:RadioButtonList ID="RDOption" runat="server" AutoPostBack="True" 
                    RepeatDirection="Horizontal" Width="100%">
                    <asp:ListItem Selected="True" Value="1">GL</asp:ListItem>
                    <asp:ListItem Value="2">MEMBER ACCOUNT</asp:ListItem>
                    <asp:ListItem Value="3">LOAN</asp:ListItem>
                    <asp:ListItem Value="4">FIXED DEPOSIT</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            <td colspan="1" style="width: 47px; height: 25px; text-align: left">
                &nbsp;</td>
            <td colspan="1" style="height: 25px; width: 82px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="height: 25px; text-align: left"><table style="width: 523px; height: 1px;">
                <tr>
                    <td class="style1" colspan="2" style="text-align: left">
                        Enter Search Description</td>
                    <td style="width: 300px; text-align: left; height: 1px;">
                <asp:TextBox ID="txtAccountName" runat="server" CssClass="form-control" Font-Size="Small" 
                            AutoPostBack="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 1px; height: 1px; text-align: left">
                    </td>
                    <td style="text-align: left; width: 83px;" class="style1">
                        </td>
                    <td style="width: 300px; height: 1px; text-align: left">
                        <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn bg-purple btn-flat margin" OnClientClick="DisplayLoadingDiv()" />
                        <asp:Button ID="Button2" runat="server" Text="Return" CssClass="btn bg-orange btn-flat margin" />
                    </td>
                </tr>
            </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style3"><div style="overflow-y: scroll; height: 300px; width: 599px;">
                 <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False" Font-Size="Small" Height="54px" Visible="False" 
                    Width="100%">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" />
                        <asp:BoundField DataField="Accountnumber" HeaderText="Acct #">
                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="acctname" HeaderText="Acct. Title">
                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                            <ItemStyle Width="500px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="class" HeaderText="Class/Address" />
                        <asp:TemplateField HeaderText="SELECT">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="Searchid" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="Searchid" runat="server" />
                            </EditItemTemplate>
                            <ItemStyle Width="10px" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="False">
                                       <ItemTemplate>
                        <asp:Label  runat="server" ID="Accountnumber" Text='<%#Eval("Accountnumber") %>' />
                                       </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView></div> 
                &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;
                &nbsp;&nbsp;
            </td>
        </tr>
    </table>
                     
    </div>
    </div> 
    </div>
    </form>
</body>
</html>