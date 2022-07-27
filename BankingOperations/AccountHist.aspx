<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AccountHist.aspx.vb" Inherits="BankingOperations_AccountHist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head id="Head1" runat="server">
    <title>Account History</title>
  

    <style type="text/css">
        .style1
        {
            font-size: xx-small;
        }
        .style2
        {
            font-size: medium;
        }
        .style3
        {
            font-size: small;
        }
        .style4
        {
            font-size: small;
            height: 25px;
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
    <form id="AccountEnquiry" runat="server">
   
  <div class="post boxed">
			<%--<h2 class="style3">
                ACCOUNT HISTORY</h2>--%>
			<div class="story">
            <div class="box box-info">
                <div class="box-header">
                  <h3 class="box-title"> ACCOUNT HISTORY</h3>
                </div>
                <div class="box-body">
        <div class="form-group" >
        <tr>
            <td style="text-align: left;" class="style2">
                1 MONTH TRANSACTION HISTORY OF ACCOUNT TO DATE </td>
        </tr>
        </div>
                <div class="form-group" >
                <tr>
                    <td class="style3" colspan="2" style="text-align: left">
                        ACCOUNT NUMBER</td>
                    <td style="width: 300px; text-align: left; height: 1px;">
                <asp:TextBox ID="txtAccountName" runat="server" Width="255px" Font-Size="Small"></asp:TextBox></td>
                </tr>
                </div>
                &nbsp;
        <div class="box-footer">
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
        <tr>
            <td style="width: 650px"><div style="overflow-y: scroll; height: 300px">
                 <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False" Font-Size="Small" Height="54px" Visible="False" 
                    Width="100%">
                    <Columns>
                        <asp:BoundField DataField="accountnumber" HeaderText="Accountnumber" >
                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="trandate" HeaderText="Tran Date" 
                            DataFormatString="{0:dd-MM-yyyy}">
                        </asp:BoundField>
                        <asp:BoundField DataField="valuedate" HeaderText="Value Date" 
                            DataFormatString="{0:dd-MM-yyyy}">
                        </asp:BoundField>
                        <asp:BoundField DataField="tranamount" HeaderText="Amount" 
                            DataFormatString="{0:n}">
                        </asp:BoundField>
                        <asp:BoundField DataField="tellerno" HeaderText="Teller No" />
                        <asp:BoundField DataField="tranname" HeaderText="Tran Desc" />
                        <asp:BoundField DataField="userid" HeaderText="Posted By" />
                        <asp:BoundField DataField="postseq" HeaderText="Posting Seq." />
                    </Columns>
                </asp:GridView></div> 
                &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;
                &nbsp;&nbsp;
            </td>
        </tr>
        </div>
   </div>
    </div>
    </div> 
    </div>
    </form>
</body>
</html>
