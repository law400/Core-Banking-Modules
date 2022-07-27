<%@ Page Language="VB" AutoEventWireup="false"   CodeFile="CustEnquiry.aspx.vb" Inherits="CustEnquiry" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head id="Head1" runat="server">
    <title>Customer Enquiry Page</title>
        <link href="../style.css" rel="stylesheet" type="text/css" />

       <style type="text/css">
           .style1
           {
               height: 21px;
           }
           .style2
           {
               height: 10px;
           }
       </style>

</head>
<body>
    <form id="CustEnquiry" runat="server">

  <div class="post boxed">
			<h2 class="title">
                Customer Enquiry</h2>
			<div class="story">

     <table style="width: 392px">
        <tr>
            <td style="height: 25px; text-align: left;">
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" style="font-weight: 700" 
                            Text="Note: Enter Any Short Form Of the Customer, Then Click Search To Find. Check the Box in Front Of the Name and Click Return to Go Back."></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="text-align: left; color: #FF3300; font-size: medium;" class="style2">
                </td>
        </tr>
        <tr>
            <td style="height: 25px; text-align: left; color: #000066; font-size: medium;">
                MAXIMUM 50 CUSTOMERS IN LIST</td>
        </tr>
        <tr>
            <td style="height: 25px; text-align: left"><table style="width: 523px; height: 1px;">
                <tr>
                    <td class="style1" colspan="2" style="text-align: left">
                        &nbsp;Customer Name</td>
                    <td style="width: 300px; text-align: left; height: 1px;">
                <asp:TextBox ID="txtAccountName" runat="server" Width="255px" Font-Size="Small" 
                            AutoPostBack="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 1px; height: 1px; text-align: left">
                    </td>
                    <td style="text-align: left; width: 83px;" class="style1">
                        </td>
                    <td style="width: 300px; height: 1px; text-align: left">
                        <asp:Button ID="Button1" runat="server" Text="Search" />
                        <asp:Button ID="Button2" runat="server" Text="Return" />
                    </td>
                </tr>
            </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 590px">
 <div style="overflow-y: scroll; height: 200px">
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    Font-Size="Small" Height="74px" Visible="False" Width="565px">
                    <Columns>
                    
                                           <asp:BoundField DataField="CustomerID" HeaderText="CustomerID">
                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                               <ItemStyle Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="accountnumber" HeaderText="Account #">
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fullname" HeaderText="Customer Name">
                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Address" HeaderText="Address">
                            <HeaderStyle HorizontalAlign="Left" Width="200px" />
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                                           <asp:BoundField DataField="Officercode" HeaderText="Officer Code" />
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
                        <asp:Label  runat="server" ID="Customerid" Text='<%#Eval("Customerid") %>' />
                                       </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
 
           </div> 
            </td>
        </tr>
    </table>
                     
    </div>
    </div> 
    </form>
</body>
</html>
