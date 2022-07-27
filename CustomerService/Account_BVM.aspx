<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Account_BVM.aspx.vb" Inherits="CustomerService_Account_BVM" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BVN REPORT</title>
</head>
<body>
    <form id="form1" runat="server">
  <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
        <ContentTemplate>
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <br />
                <table style="width: 78%">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                            Font-Bold="True" Font-Size="Medium" Height="38px" RepeatDirection="Horizontal" 
                            Width="460px">
                                <asp:ListItem Value="1">Accounts with BVM</asp:ListItem>
                                <asp:ListItem Value="2">Accounts without BVM</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="LblBVM_Captured" runat="server" Font-Bold="True" 
                            Font-Size="Large" ForeColor="#FF3300"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblAccountNumber" runat="server" Text="Account Number"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtAccountNumber" runat="server" Height="19px" Width="147px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblProductCode" runat="server" Text="Product Code"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DrpProductCode" runat="server" Height="21px" 
                            Width="145px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblPhoneNumber" runat="server" Text="Phone Number"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtPhone_number" runat="server" Height="23px" Width="143px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblAccount_teir" runat="server" Text="Account Tier"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DrpAccount_tier" runat="server" CausesValidation="True" 
                            Height="23px" Width="142px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblBVM" runat="server" Text="BVM Detail"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtBVM" runat="server" Height="24px" Width="143px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnSearch" runat="server" style="height: 26px" Text="Search" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ButReturn" runat="server" Text="Return" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Export to:"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="199px" 
            >
                                <asp:ListItem Value="0">--Select an Export Format--</asp:ListItem>
                                <asp:ListItem Value="1">MS-Excel</asp:ListItem>
                                <asp:ListItem Value="2">CSV</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="Button1" runat="server" Text="Export" />
                            </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <br />
                <br />
                <telerik:RadGrid ID="RadGrid1" runat="server"  AutoGenerateColumns="false" 
         AllowFilteringByColumn="True" AllowSorting="True"
          ShowFooter="false"  GridLines="None" AllowPaging="true" 
            GroupingEnabled="True" GroupingSettings-CaseSensitive="False" 
            MasterTableView-Frame="Border" PageSize="50" >
                    <PagerStyle Mode="NextPrevAndNumeric" Position="TopAndBottom"/>
                    <GroupingSettings CaseSensitive="False">
                    </GroupingSettings>
                    <ClientSettings AllowDragToGroup="True" >
                    </ClientSettings>
                    <MasterTableView ShowGroupFooter="true" AllowMultiColumnSorting="true">
                        <CommandItemSettings ExportToPdfText="Export to Pdf">
                        </CommandItemSettings>
                        <Columns>
                            <telerik:GridBoundColumn DataField="accountnumber" HeaderText="Account Number" 
                            UniqueName="column">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="accounttitle" HeaderText="Account Name" 
                            UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ProductName" HeaderText="Product Name" 
                            UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Phone1" HeaderText="Phone Number" 
                            UniqueName="column3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="account_tier" HeaderText="Account Tier" 
                            UniqueName="column4">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="phone2" HeaderText="BVN Deatil" 
                            UniqueName="column5">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Create_dt" 
                            DataFormatString="{0:dd/MM/yyyy}" HeaderText="BVN Maintained Date" 
                            UniqueName="column6">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UserId" HeaderText="User" 
                            UniqueName="column7">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HoldReason" HeaderText="Reason" 
                            UniqueName="column8">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Effective_dt" 
                            DataFormatString="{0:dd/MM/yyyy}" HeaderText="Start Date" 
                            UniqueName="column9">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="End_dt" DataFormatString="{0:dd/MM/yyyy}" 
                            HeaderText="End Date" UniqueName="column10">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Lien Option" HeaderText="Lien Option" 
                            UniqueName="column11">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="status" HeaderText="Lien Status" 
                            UniqueName="column12">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <%--<GroupByExpressions>
                  <telerik:GridGroupByExpression>
                    <GroupByFields>
                      <telerik:GridGroupByField FieldName="ProductName" />
                    </GroupByFields>
                    <SelectFields>
                      <telerik:GridGroupByField FieldName="ProductName" HeaderText="Product Name" />
                    </SelectFields>
                  </telerik:GridGroupByExpression>
                </GroupByExpressions>--%>
                    </MasterTableView>
                    <HeaderContextMenu EnableImageSprites="True" 
                CssClass="GridContextMenu GridContextMenu_Default">
                    </HeaderContextMenu>
                    <ExportSettings
                    ExportOnlyData="true">
                    </ExportSettings>
                </telerik:RadGrid>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                <telerik:RadGrid ID="RadGrid2" runat="server"  AutoGenerateColumns="false" 
         AllowFilteringByColumn="True" AllowSorting="True"
          ShowFooter="false"  GridLines="None" AllowPaging="true" 
            GroupingEnabled="True" GroupingSettings-CaseSensitive="False" 
            MasterTableView-Frame="Border" >
                    <PagerStyle Mode="NextPrevAndNumeric" Position="TopAndBottom"/>
                    <GroupingSettings CaseSensitive="False">
                    </GroupingSettings>
                    <ClientSettings AllowDragToGroup="True" >
                    </ClientSettings>
                    <MasterTableView ShowGroupFooter="true" AllowMultiColumnSorting="true">
                        <CommandItemSettings ExportToPdfText="Export to Pdf">
                        </CommandItemSettings>
                        <Columns>
                            <telerik:GridBoundColumn DataField="accountnumber" HeaderText="Account Number" 
                            UniqueName="column">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="accounttitle" HeaderText="Account Name" 
                            UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ProductName" HeaderText="Product Name" 
                            UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Phone1" HeaderText="Phone Number" 
                            UniqueName="column3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="account_tier" HeaderText="Account Tier" 
                            UniqueName="column4">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UserId" HeaderText="User" 
                            UniqueName="column7">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HoldReason" HeaderText="Reason" 
                            UniqueName="column8">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Effective_dt" 
                            DataFormatString="{0:dd/MM/yyyy}" HeaderText="Start Date" 
                            UniqueName="column9">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="End_dt" DataFormatString="{0:dd/MM/yyyy}" 
                            HeaderText="End Date" UniqueName="column10">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Lien Option" HeaderText="Lien Option" 
                            UniqueName="column11">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="status" HeaderText="Lien Status" 
                            UniqueName="column12">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <%--<GroupByExpressions>
                  <telerik:GridGroupByExpression>
                    <GroupByFields>
                      <telerik:GridGroupByField FieldName="ProductName" />
                    </GroupByFields>
                    <SelectFields>
                      <telerik:GridGroupByField FieldName="ProductName" HeaderText="Product Name" />
                    </SelectFields>
                  </telerik:GridGroupByExpression>
                </GroupByExpressions>--%>
                    </MasterTableView>
                    <HeaderContextMenu EnableImageSprites="True" 
                CssClass="GridContextMenu GridContextMenu_Default">
                    </HeaderContextMenu>
                    <ExportSettings
                    ExportOnlyData="true">
                    </ExportSettings>
                </telerik:RadGrid>
                <br />
                <br />
            </div>
        </ContentTemplate>
   <%-- </asp:UpdatePanel>--%>
        
    </form>
</body>
</html>
