<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Addservice.ascx.vb" Inherits="Services_Addservice" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 146px;
    }
    .style4
    {
        width: 192px;
    }
    .style7
    {
        width: 189px;
    }
    .style8
    {
        width: 83px;
    }
    .style9
    {
        width: 148px;
    }
    .style10
    {
        width: 58px;
    }
    .style11
    {
        width: 186px;
    }
    .style12
    {
        width: 156px;
    }
</style>
<asp:UpdatePanel id="updatePanel" runat="server">
</asp:UpdatePanel>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="200px" 
    HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" width="1084px">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        Font-Names="Georgia" Font-Size="Medium" ForeColor="#FF6600" 
        GroupingText="Please Wait..." Skin="Office2007">
    </telerik:RadAjaxLoadingPanel>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#990099" 
        Text="ADD SERVICE INFORMATION"></asp:Label>
    <br />
    <table class="style1" style="font-family: Georgia; font-size: small;">
        <tr>
            <td>
                <fieldset class="row2" 
                    style="font-family: 'Times New Roman', Times, serif; font-size: small">
                    <legend style="color: #000080">Basic Information </legend>
                    <table style="width: 628px">
                        <tr>
                            <td class="style8">
                                Description&nbsp;&nbsp; -</td>
                            <td class="style9">
                                <asp:TextBox ID="txtdesc" runat="server" Width="153px"></asp:TextBox>
                            </td>
                            <td class="style10">
                                &nbsp;</td>
                            <td class="style7">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Default SMS Dispatch&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - Type</td>
                            <td class="style9">
                                <telerik:RadComboBox ID="drpdispatch" Runat="server" AllowCustomText="True" 
                                    AutoPostBack="True" EmptyMessage="Choose a SMS Dispatch Type" 
                                    Filter="StartsWith" MarkFirstMatch="True" MaxHeight="200px" Width="180px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style10">
                                Frequency</td>
                            <td>
                                <asp:TextBox ID="txtperiods" runat="server" AutoPostBack="True" Width="54px"></asp:TextBox>
                                <asp:DropDownList ID="drpfrequency" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Default Email Dispatch&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - Type</td>
                            <td class="style9">
                                <telerik:RadComboBox ID="drpdispatch0" Runat="server" AllowCustomText="True" 
                                    AutoPostBack="True" EmptyMessage="Choose an Email Dispatch Type" 
                                    Filter="StartsWith" MarkFirstMatch="True" MaxHeight="200px" Width="182px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style10">
                                Frequency</td>
                            <td>
                                <asp:TextBox ID="txtperiods0" runat="server" AutoPostBack="True" Width="54px"></asp:TextBox>
                                <asp:DropDownList ID="drpfrequency0" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Connection Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -</td>
                            <td class="style9">
                                <asp:RadioButtonList ID="RdConnect" runat="server" AutoPostBack="True" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="1">Database</asp:ListItem>
                                    <asp:ListItem Value="2">Webservice</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="style10">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Panel ID="Panel1" runat="server">
                                    <table>
                                        <tr>
                                            <td class="style2">
                                                Database&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -</td>
                                            <td>
                                                <asp:DropDownList ID="drpdatabase" runat="server" AutoPostBack="True" 
                                                    Font-Size="XX-Small" Height="18px" Width="230px">
                                                    <asp:ListItem Selected="True" Value="0">--Database Type--</asp:ListItem>
                                                    <asp:ListItem Value="1">MS SQL </asp:ListItem>
                                                    <asp:ListItem Value="2">Sybase</asp:ListItem>
                                                    <asp:ListItem Value="3">Oracle</asp:ListItem>
                                                    <asp:ListItem Value="4">MySql</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style12">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                Server Name/IP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -</td>
                                            <td>
                                                <asp:TextBox ID="txtserver" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                                            </td>
                                            <td class="style12">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                Username&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -</td>
                                            <td>
                                                <asp:TextBox ID="txtusername" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                                            </td>
                                            <td class="style12">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -</td>
                                            <td>
                                                <asp:TextBox ID="txtpassword" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                                            </td>
                                            <td class="style12">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                Database&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -</td>
                                            <td>
                                                <asp:TextBox ID="txtdatase" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                                            </td>
                                            <td class="style12">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                &nbsp;</td>
                                            <td>
                                                <asp:Button ID="btntest" runat="server" Text="Test Connection" />
                                            </td>
                                            <td class="style12">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </fieldset><fieldset 
                    style="font-family: 'Times New Roman', Times, serif; font-size: small">
                    <legend style="color: #000080">Procedure Information </legend>
                    <table>
                        <tr>
                            <td class="style4">
                                Column Procedure&nbsp;&nbsp; -</td>
                            <td>
                                <asp:TextBox ID="txt_childprocedure" runat="server" AutoPostBack="True" 
                                    Width="219px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Service Procedure&nbsp;&nbsp;&nbsp; -</td>
                            <td>
                                <asp:TextBox ID="txt_parentprocedure" runat="server" AutoPostBack="True" 
                                    Width="221px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Input</td>
                            <td>
                                Output</td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:BulletedList ID="blInputParameters" runat="server">
                                </asp:BulletedList>
                            </td>
                            <td>
                                <asp:BulletedList ID="blOutputParameters" runat="server">
                                </asp:BulletedList>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel4" runat="server" Visible="False">
                        <asp:GridView ID="gvParameters" runat="server" AutoGenerateColumns="False" 
                            CssClass="mGrid" DataKeyNames="ParameterName" Width="304px">
                            <Columns>
                                <asp:BoundField DataField="ParameterName" HeaderText="Parameter" />
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:TextBox ID="ParameterValue" runat="server" Columns="40"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <table class="style1">
                        <tr>
                            <td class="style11">
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="btnExecSproc" runat="server" Font-Size="Small" 
                                    Text="Execute Stored Procedure" Width="189px" />
                            </td>
                        </tr>
                    </table>
                </fieldset></td>
            <td valign="top">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td valign="top">
                <fieldset class="row2" 
                    style="font-family: 'Times New Roman', Times, serif; font-size: small">
                    <legend style="color: #000080">Message Detail Information </legend>
                    <table style="width: 347px">
                        <tr>
                            <td class="style7">
                                Custom SMS Message&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -</td>
                            <td>
                                <asp:TextBox ID="txtconstring1" runat="server" AutoPostBack="True" 
                                    Font-Size="Small" Height="39px" TextMode="MultiLine" Width="232px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style7" valign="top">
                                Custom Email Message&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -</td>
                            <td>
                                <asp:TextBox ID="txtconstring2" runat="server" AutoPostBack="True" 
                                    Font-Size="Small" Height="214px" TextMode="MultiLine" Width="232px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                Attachment File Format&nbsp;&nbsp;&nbsp;&nbsp; -</td>
                            <td>
                                <asp:DropDownList ID="drpdatabase0" runat="server" AutoPostBack="True" 
                                    Font-Size="XX-Small" Height="18px" Width="230px">
                                    <asp:ListItem Selected="True" Value="0">--File Format--</asp:ListItem>
                                    <asp:ListItem Value="1">Excel csv</asp:ListItem>
                                    <asp:ListItem Value="2">PDF</asp:ListItem>
                                    <asp:ListItem Value="3">XML</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                File Name Format&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -</td>
                            <td>
                                <asp:TextBox ID="txtfilename" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset><fieldset class="row3" 
                    style="font-family: 'Times New Roman', Times, serif; font-size: small">
                    <legend style="color: #000080">Report Column </legend>
                    <table style="height: 107px; width: 321px;">
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvFields" runat="server" CssClass="mGrid" 
                                    DataKeyNames="FieldColumn" Width="314px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="New Value">
                                            <ItemTemplate>
                                                <asp:TextBox ID="FieldValue" runat="server" Columns="10" 
                                                    Text='<%#Eval("FieldColumn") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset></td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server" Font-Names="Georgia" Visible="False" 
                    Width="503px">
                    <fieldset style="font-family: 'Times New Roman', Times, serif; font-size: small">
                        <legend style="color: #000080">Webservice Information </legend>
                        <table>
                            <tr>
                                <td>
                                    Webservice URL&nbsp; -</td>
                                <td class="style7">
                                    <asp:TextBox ID="txturl0" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Function Name&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfunction" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Save" 
                    ValidationGroup="valrule" Width="101px" />
                <asp:Button ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" 
                    Width="104px" />
                <asp:TextBox ID="txthidden" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</telerik:RadAjaxPanel>

