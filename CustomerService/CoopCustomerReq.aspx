<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CoopCustomerReq.aspx.vb" Inherits="CustomerService_CoopCustomerReq" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Customer Request</title>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="post boxed">
        <h2 class="title" style="color: #FFFFCC">
            cooperative Customer Request</h2>
        <div class="story">
            <table style="width: 975px">
                <tr>
                    <td style="width: 100px">
                        <asp:Button ID="BtnReturn0" runat="server" Text="Return" Width="63px" />
                    </td>
                    <td style="width: 133px">
                    </td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                            GridLines="Vertical" Width="952px">
                            <FooterStyle BackColor="#CCCC99" />
                            <Columns>
                                <asp:BoundField DataField="Employee_Number" HeaderText="Employee No" 
                                    SortExpression="Employee_Number" />
                                <asp:BoundField DataField="Surname" HeaderText="Surname" 
                                    SortExpression="Surname" />
                                <asp:BoundField DataField="First_Name"
                                    HeaderText="First Name" HtmlEncode="False" SortExpression="First_Name" />
                                <asp:BoundField DataField="Othername" HeaderText="Othername" 
                                    SortExpression="Othername" />
                                <asp:BoundField DataField="Sexname"
                                    HeaderText="Sex" SortExpression="Sexname" />
                                <asp:HyperLinkField DataNavigateUrlFields="Employee_Number" 
                                    DataNavigateUrlFormatString="CooperativeCreateCustomer.aspx?ID={0}" 
                                    Text="View to Create Customer" />
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelAuthDetail" runat="server" 
                                            Text='<%# Eval("Employee_Number") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="BtnReturn" runat="server" Text="Return" Width="63px" /></td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </div>
    </form>
</body>
</html>