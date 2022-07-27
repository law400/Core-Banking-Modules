<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="CustAccountInfo.aspx.vb" Inherits="CustomerService_CustAccountInfo" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel1" runat="server">
<ContentTemplate>
    <table style="width: 97%; border: 2px solid #0000FF">
        <tr>
            <td>
                <table style="width: 501px; height: 1px;">
                    <tr>
                        <td style="width: 558px; height: 23px;">
                            Account Number*</td>
                        <td colspan="2" style="height: 23px;">
                            <asp:TextBox ID="txtaccountnumber" runat="server" AutoPostBack="True" 
                                Font-Size="Small" TabIndex="4" Width="131px"></asp:TextBox>
                            <asp:HyperLink ID="hypsearch" runat="server" Height="25px" 
                                ImageUrl="~/Images/iconbar_previewtab_on.gif" Width="25px">HyperLink</asp:HyperLink>
                        </td>
                        <td style="width: 688px; height: 23px;">
                            &nbsp;</td>
                        <td style="width: 100px; height: 23px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 558px; height: 23px;">
                            Account Title</td>
                        <td colspan="2" style="height: 23px;">
                            <asp:TextBox ID="txttitle" runat="server" Font-Size="Small" ReadOnly="True" 
                                TabIndex="4" Width="263px"></asp:TextBox>
                        </td>
                        <td style="width: 688px; height: 23px;">
                            &nbsp;</td>
                        <td style="width: 100px; height: 23px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 558px; height: 23px;">
                            Address</td>
                        <td colspan="2" style="height: 23px;">
                            <asp:TextBox ID="txtaddress" runat="server" Font-Size="Small" Height="52px" 
                                ReadOnly="True" TabIndex="4" TextMode="MultiLine" Width="263px"></asp:TextBox>
                        </td>
                        <td style="width: 688px; height: 23px;">
                            &nbsp;</td>
                        <td style="width: 100px; height: 23px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 558px; height: 23px;">
                            Phone No</td>
                        <td colspan="2" style="height: 23px;">
                            <asp:TextBox ID="txtphone" runat="server" Font-Size="Small" ReadOnly="True" 
                                TabIndex="4" Width="263px"></asp:TextBox>
                        </td>
                        <td style="width: 688px; height: 23px;">
                            &nbsp;</td>
                        <td style="width: 100px; height: 23px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 558px; height: 23px;">
                            &nbsp;</td>
                        <td colspan="2" style="height: 23px;">
                            &nbsp;</td>
                        <td style="width: 688px; height: 23px;">
                            &nbsp;</td>
                        <td style="width: 100px; height: 23px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 558px; height: 18px">
                            &nbsp;</td>
                        <td style="width: 193px; height: 18px">
                            &nbsp;</td>
                        <td style="width: 5963px; height: 18px">
                            &nbsp;</td>
                        <td style="width: 688px; height: 18px">
                            &nbsp;</td>
                        <td style="height: 18px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 558px; height: 18px">
                            &nbsp;</td>
                        <td colspan="4" style="height: 18px">
                            <asp:Button ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" />
                            <asp:Button ID="btnReturn" runat="server" BackColor="#C0C0FF" Text="Return" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="4" Font-Size="XX-Small" Height="147px" ShowFooter="True" 
                    Width="810px">
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="Accountnumber" 
                            DataNavigateUrlFormatString="~/Reports/AccountInfo.aspx?id={0}" 
                            DataTextField="Accountnumber" HeaderText="Account Number" />
                        <asp:BoundField DataField="accounttitle" HeaderText="Account Name">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="prodname" HeaderText="Product Name">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="bkbal" HeaderText="Book Balance">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="effbal" HeaderText="Effective Balance" 
                            ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="usebal" HeaderText="Usable Balance">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="acctstatus" HeaderText="Account Status" />
                    </Columns>
                    <RowStyle BackColor="White" Font-Size="8pt" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                </asp:GridView>
                <br />
            </td>
        </tr>
    </table>
<div class="box-blue">
        <div class="content">
          
            
        </div>
    </div>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>



