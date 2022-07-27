<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Statement.aspx.vb" Inherits="Reports_Statement" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Statement Page</title>
    <style type="text/css">
        .style1
        {
            width: 75%;
        }
        .style2
        {
            width: 171px;
        }
        .style3
        {
            width: 124px;
        }
    </style>
    <link href="../Style.css" rel="stylesheet" type="text/css" />
    <script language=javascript>
    function popWin(llInp){window.open("GlCustEnquiry.aspx","aa","width=650,height=600");
    return false;
    } </script>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: medium">
    
        <h1>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Statement Of Account</h1>
    <table class="style1">
        <tr>
            <td class="style2">
                Account Number</td>
            <td>
                <asp:TextBox ID="txtacctno" runat="server" AutoPostBack="True" Width="211px"></asp:TextBox>
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    ImageUrl="~/Images/iconbar_previewtab.gif"></asp:HyperLink>
            </td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Start Date</td>
            <td>
                                 <asp:TextBox runat="server" ID="txtstartdate" autocomplete="off" MaxLength="14" /><br />
        <ajaxToolkit:CalendarExtender ID="defaultCalendarExtender" runat="server" TargetControlID="txtstartdate" Format="dd-MM-yyyy" />

            </td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                End Date</td>
            <td>
                 <asp:TextBox runat="server" ID="txtenddate" autocomplete="off" MaxLength="14" /><br />
        <ajaxToolkit:CalendarExtender ID="defaultCalendarExtender2" runat="server" TargetControlID="txtenddate" Format="dd-MM-yyyy" />
            </td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Choose a Report Option</td>
            <td>
                    <asp:RadioButtonList ID="rdbutton1" runat="server" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="1">By Transaction Date</asp:ListItem>
                        <asp:ListItem Value="2">By Value Date</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                    <asp:Button ID="Button1" runat="server" Text="Display" />
                    </td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                    <asp:Button ID="BtnReturn" runat="server" Text="Return" />
                </td>
            <td>
                &nbsp;</td>
            <td class="style3">
                <asp:TextBox ID="txtuserid" runat="server" AutoPostBack="True" Width="211px" 
                    Visible="False"></asp:TextBox>
                    </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <br />
        <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="400px" Width="907px">
            <LocalReport ReportPath="Reports\Statement2.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" 
                        Name="Prime_Proc_RptStatement" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    </form>
</body>
</html>

