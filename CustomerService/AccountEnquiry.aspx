<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AccountEnquiry.aspx.vb" Inherits="CustomerService_AccountEnquiry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head id="Head1" runat="server">
    <title>Account Enquiry Page</title>
  

    <style type="text/css">
        .style1
        {
            font-size: xx-small;
        }
        .style2
        {
            font-size: x-small;
        }
        .style3
        {
            font-size: small;
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
    <div id="loading" style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity:0.5 ">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
  <%--<div class="post boxed">--%>
			<%--<h2 class="style3">
                Account Enquiry</h2>--%>
			<div class="story">
            <div class="box box-info">
                <div class="box-header">
                  <h3 class="box-title"> ACCOUNT ENQUIRY</h3>
                </div>
                <div class="box-body">
                <div class="form-group" >
        <tr>
            <td style="text-align: left;" class="style2">
                MAXIMUM 50 MEMBER(S) IN LIST</td>
        </tr>
        </div>
                 <div class="form-group" >
                <tr>
                    <td class="style3" colspan="3" style="text-align: left">
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" style="font-weight: 700; font-size: x-small;" 
                            
                            
                            Text="Note: Enter Any Short Form Of the Member, Then Click Search To Find. Check the Box in Front Of the Name and Click Return to Go Back."></asp:Label>
                    </td>
                </tr>
                </div>
                <div class="form-group" >
                <tr>
                    <td class="style1" colspan="2" style="text-align: left">
                        &nbsp;Member Name</td>
                    <td style="width: 300px; text-align: left; height: 1px;">
                <asp:TextBox ID="txtAccountName" runat="server" Width="255px" Font-Size="Small" CssClass="form-control"></asp:TextBox></td>
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
                        <asp:BoundField DataField="customerid" HeaderText="Cust. ID" />
                        <asp:BoundField DataField="Accountnumber" HeaderText="Accountnumber">
                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fullname" HeaderText="Acct. Title">
                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                            <ItemStyle Width="500px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="officercode" HeaderText="Officer ID" />
                        <asp:BoundField DataField="email" HeaderText="EMAIL" Visible="False">
                            <HeaderStyle HorizontalAlign="Left" Width="200px" />
                            <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Phone1" HeaderText="PHONE NO" Visible="False">
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle Width="40px" />
                        </asp:BoundField>
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
        </div>
 </div>
         
    </div>
    </div> 
    <%--</div>--%>
    </form>
</body>
</html>
