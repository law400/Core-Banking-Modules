<%@ Page Title="" Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="ProvosionAccount.aspx.vb" Inherits="CustomerService_ProvosionAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
<div class="box-blue">
        <div class="content">
            <table border="0" style="width: 298px; height: 187px; font-size: 8pt;">
        
        <caption style="text-align: left;" >
            <span style="color: #000099"><span style="font-size: 12pt">
        <strong><span></span></strong>
            </span></span>
        </caption>
        <tr>
            <td style="width: 113px; height: 20px;">
                Account Number<td style="width: 100px">
                        <asp:TextBox ID="txtAcNumber" runat="server" Width="188px" AutoPostBack="True" TabIndex="1" Font-Size="Small"></asp:TextBox>
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                </td>
                                <td style="width: 100px">
                                    <asp:HyperLink
                                        ID="hypAccount" runat="server" Height="23px" 
                                        ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></td>
            <td style="width: 95px; height: 20px;">
            </td>
        </tr>
                <tr>
                    <td style="width: 113px;">
                        Provision Type&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="drpprovision" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 95px; ">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 113px">
                    </td>
                    <td>
                        <asp:Button ID="BtnSubmit" runat="server" Font-Size="Small" Text="Submit" 
                            Width="62px" />
                        <asp:Button ID="Btncancel" runat="server" Font-Size="Small" Text="Return" 
                            Width="62px" />
                    </td>
                    <td style="width: 95px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 113px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td style="width: 95px">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>