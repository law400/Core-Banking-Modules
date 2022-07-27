<%@ Control Language="VB" AutoEventWireup="false" CodeFile="EditDispatch.ascx.vb" Inherits="Services_EditDispatch" %>
<style type="text/css">

    .style1
    {
        height: 24px;
    }
    .style2
    {
        width: 118px;
    }
</style>

<p>
    &nbsp;</p>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="200px" 
    width="1080px" HorizontalAlign="NotSet" 
    LoadingPanelID="RadAjaxLoadingPanel1">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        BackgroundPosition="Top" Skin="Office2007">
    </telerik:RadAjaxLoadingPanel>
    <br />
    <fieldset class="row2">
        <legend style="color: #000080">Dispatch Information </legend>
        <table style="width: 480px">
            <tr>
                <td class="style7" colspan="4">
                    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" GridLines="None" Skin="Office2007">
                        <MasterTableView DataKeyNames="id" PageSize="20">
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Select" 
                                    ImageUrl="~/Images/Edit.gif" Text="Edit Record" UniqueName="column1">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="description" 
                                    HeaderText="Dispatch Description" UniqueName="column2">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                            EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </fieldset><br />
    <br />
    <br />
    <asp:Panel ID="Panel3" runat="server" Visible="False">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#990099" 
            Text="EDIT DISPATCH INFORMATION"></asp:Label>
        <br />
        <fieldset class="changePassword" 
            style="width: 800px; font-family: 'Times New Roman', Times, serif; font-size: small;">
            <legend style="color: #000080; font-family: Georgia">Edit Dispatch</legend>
            <table>
                <tr valign="top">
                    <td>
                        <table>
                            <tr>
                                <td>
                                    Description</td>
                                <td class="style1">
                                    <telerik:RadComboBox ID="drpdesc" Runat="server" AutoPostBack="True" 
                                        DataTextField="description" DataValueField="id" 
                                        EmptyMessage="Choose Dispatch Type" Filter="StartsWith" MarkFirstMatch="True" 
                                        MaxHeight="200px">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Message Type</td>
                                <td class="style1">
                                    <asp:RadioButtonList ID="RDmessage" runat="server" AutoPostBack="True" 
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SMS</asp:ListItem>
                                        <asp:ListItem Value="2">Email</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Reorder Level</td>
                                <td class="style1">
                                    <asp:TextBox ID="txtreorder" runat="server" CssClass="textEntry" Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Phone</td>
                                <td class="style1">
                                    <asp:TextBox ID="txtphone" runat="server" CssClass="textEntry" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email</td>
                                <td class="style1">
                                    <asp:TextBox ID="txtemail" runat="server" CssClass="textEntry" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Website</td>
                                <td class="style1">
                                    <asp:TextBox ID="txtwebsite" runat="server" CssClass="textEntry" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Usage</td>
                                <td class="style1">
                                    <asp:RadioButtonList ID="RDUsage" runat="server" AutoPostBack="True" 
                                        RepeatDirection="Horizontal" Width="226px">
                                        <asp:ListItem Value="1">Customer</asp:ListItem>
                                        <asp:ListItem Value="2">Official</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
                                        HeaderText="Error Messages" style="color: #FF0000; font-weight: 700" 
                                        ValidationGroup="valrule" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Save" 
                                        ValidationGroup="valrule" />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" Width="79px" />
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:AlertZ %>" 
                                        SelectCommand="proc_selDispatchtype" SelectCommandType="StoredProcedure">
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="justify" style="width: 100px; height: 200px;" valign="top">
                        <asp:Panel ID="Panel1" runat="server" autoheight="true" formgroup="true" 
                            title="SMS Details" width="400px">
                            <content>
                            <table style="font-size: small">
                                <tr>
                                    <td colspan="2">
                                        <span class="style3"><strong>Note</strong></span>:Put a Placeholer {{ }} for the 
                                        phone no and the message region of the Gateway Content. i.e {{phone}},{{msg}}</td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        Gateway:</td>
                                    <td>
                                        <asp:TextBox ID="txtgateway" runat="server" CssClass="textEntry" Height="77px" 
                                            TextMode="MultiLine" Width="310px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        Response&nbsp; Code:</td>
                                    <td>
                                        <asp:TextBox ID="txtrescode" runat="server" CssClass="textEntry" Width="157px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        Test:</td>
                                    <td>
                                        Phone No:&nbsp;
                                        <asp:TextBox ID="txttestPhone" runat="server" CssClass="textEntry" 
                                            Width="157px"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <br />
                                        <br />
                                        Message:&nbsp;&nbsp;
                                        <asp:TextBox ID="txttestmessage" runat="server" CssClass="textEntry" 
                                            Width="158px"></asp:TextBox>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="Button1" runat="server" Text="Test Gateway" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        If DLL is available, pls provide detail below.</td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        DLL File Name:</td>
                                    <td>
                                        <asp:TextBox ID="txtdllfile" runat="server" CssClass="textEntry" Width="236px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        Function Name:</td>
                                    <td>
                                        <asp:TextBox ID="txtfunction" runat="server" CssClass="textEntry" Width="236px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            </content>
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server" autoheight="true" formgroup="true" 
                            title="Email Details" width="400px">
                            <content>
                            <table style="font-size: small; width: 362px;">
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Smtp Server</td>
                                    <td>
                                        <asp:TextBox ID="txtsmstpserver" runat="server" CssClass="textEntry" 
                                            Width="157px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Port No</td>
                                    <td>
                                        <asp:TextBox ID="txtportno" runat="server" CssClass="textEntry" Width="157px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        SSL Required?</td>
                                    <td class="style1">
                                        <asp:CheckBox ID="chk1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        UserName</td>
                                    <td>
                                        <asp:TextBox ID="txtusername" runat="server" CssClass="textEntry" Width="157px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Password</td>
                                    <td>
                                        <asp:TextBox ID="txtpassword" runat="server" CssClass="textEntry" Width="157px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        From Email</td>
                                    <td>
                                        <asp:TextBox ID="txtfromemail" runat="server" CssClass="textEntry" 
                                            Width="157px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            </content>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </fieldset></asp:Panel>
</telerik:RadAjaxPanel>


