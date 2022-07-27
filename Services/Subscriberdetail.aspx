<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Subscriberdetail.aspx.vb" Inherits="Services_Subscriberdetail" %>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Master.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
      <div class="post boxed" align="left" style="height: 894px">
			<h2 class="title">Subscriber Detail</h2>
            <div class="story">
       <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>

			  

             <fieldset class="changePassword"  style="width: 920px">
                    <legend>Create/Edit Subscriber</legend>
                   
      <table style="width: 847px; font-size: small;" border="0">
                <tr>
                    <td style="width: 100px; height: 200px;" align="left" valign="top">
                        <table class="gridtable" style="font-size: small">
                            <tr>
                                <td colspan="4">
                                    <strong>Service Setting</strong></td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
                                        HeaderText="Error Messages" style="color: #FF0000; font-weight: 700" 
                                        ValidationGroup="valrule" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Subscriber Key</td>
                                <td>
                                    <asp:TextBox ID="txtkey" runat="server" ReadOnly="True" 
                                        Width="154px"></asp:TextBox>
                                </td>
                                <td class="style7">
                                    Account No</td>
                                <td class="style7">
                                    <asp:TextBox ID="txtacctno" runat="server" Width="154px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Service Type</td>
                                <td>
                                    <telerik:RadComboBox ID="drpdservicetype" Runat="server" AllowCustomText="True" 
                                        AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="description" 
                                        DataValueField="id" Filter="StartsWith" Height="16px" MarkFirstMatch="True" 
                                        MaxHeight="200px">
                                    </telerik:RadComboBox>
                                </td>
                                <td class="style7">
                                    Frequency</td>
                                <td class="style7">
                                    <asp:TextBox ID="txtperiods" runat="server" AutoPostBack="True" Width="54px"></asp:TextBox>
                                    <asp:DropDownList ID="drpfrequency" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Account Type</td>
                                <td>
                                    <asp:DropDownList ID="drpaccttype" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td class="style7">
                                    Account Title</td>
                                <td class="style7">
                                    <asp:TextBox ID="txtacctname" runat="server" AutoPostBack="True" Width="204px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    &nbsp;</td>
                                <td class="style7">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style7" colspan="4">
                                      <ext:Panel ID="Panel6" runat="server" Title="Receipient Details" AutoHeight="true" 
                            FormGroup="true" Width="500px">
                    <Content>
                                        <table class="gridtable">
                                            <tr>
                                                <td colspan="4">
                                                     <asp:GridView ID="GridView1" runat="server" 
              AutoGenerateColumns="False" 
              DataKeyNames="id"
              DataSourceID="SqlDataSource2" 
              OnRowDeleted="GridView1_RowDeleted" 
              OnRowUpdated="GridView1_RowUpdated" 
              ShowFooter="True" 
              OnRowCommand="GridView1_RowCommand" CellPadding=4 
                    ForeColor="Black" GridLines="Vertical" Width="526px" Font-Size="XX-Small" BackColor="White" 
                                                         BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                    <AlternatingRowStyle BackColor="White" />
<Columns>
    <asp:CommandField ShowDeleteButton="True" 
                      ShowEditButton="True" />
   <asp:TemplateField HeaderText="ID" 
                       SortExpression="id">
    <ItemTemplate>
    <asp:Label ID="lblroomnumber" runat="server" 
               Text='<%#Eval("id") %>'>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
    </asp:Label>
    </ItemTemplate>
    
    <FooterTemplate>
   
    <asp:Button ID="btnInsert" runat="server" 
                Text="Insert" CommandName="Add" />
    </FooterTemplate>
    </asp:TemplateField>
   
    
    <asp:TemplateField HeaderText="Phone" 
                       SortExpression="Phone">
    <ItemTemplate>
    <asp:Label ID="lblitemdesc" runat="server"  
               Text='<%#Eval("Phone") %>'>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
    </asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
    <asp:TextBox ID="txtitemdesc" Font-Size="X-Small"  Width="60" runat="server" 
                 Text='<%#Bind("Phone") %>'>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
    </asp:TextBox>
    </EditItemTemplate>
    <FooterTemplate>
    <asp:TextBox ID="Fitemdesc" Width="80" Font-Size="X-Small" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
    </asp:TextBox>
    </FooterTemplate>
    </asp:TemplateField>
        <asp:TemplateField HeaderText="Email" 
                       SortExpression="Email">
    <ItemTemplate>
    <asp:Label ID="lbldracct" Font-Size="X-Small"  runat="server" 
               Text='<%#Eval("Email") %>'>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
    </asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
    <asp:TextBox ID="txtdracct" Font-Size="X-Small"  Width="160" runat="server" 
                 Text='<%#Bind("Email") %>'>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
    </asp:TextBox>
    </EditItemTemplate>
    <FooterTemplate>
    <asp:TextBox ID="Fdracct"  runat="server" Font-Size="X-Small" Width="160">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
    </asp:TextBox>
    </FooterTemplate>
        <ItemStyle Width="160px" />
    </asp:TemplateField>
    
    
</Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
              <EmptyDataTemplate>
        <table border="0" cellpadding="0" cellspacing="0"> 
    <tr> 
      <td>Phone:</td> 
      <td>Email:</td> 
      <td>Insert</td> 
    </tr> 
    <tr> 
     
       <td><asp:TextBox runat="server" Width="80" Font-Size="X-Small" ID="NoCategories1" /></td> 
         <td><asp:TextBox runat="server" Width="160" Font-Size="X-Small" ID="NoCategories2" /> </td> 
       <td> <asp:Button runat="server" ID="NoDataInsert" CommandName="NoDataInsert" Text="Insert"/></td>  
    </tr> 
  </table> 
           
    
            </EmptyDataTemplate>
</asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" 
         ConnectionString="<%$ ConnectionStrings:AlertZ %>" 
        runat="server"
        DeleteCommand="DELETE FROM [tbl_subscriberreceipient] WHERE [subscriber_key] = @subscriber_key" 
        InsertCommand="INSERT INTO [tbl_subscriberreceipient] ([subscriber_key] ,[Phone],[Email]) 
        VALUES (@subscriber_key,@Phone,@Email)"
        SelectCommand="select id,Phone,Email from tbl_subscriberreceipient where subscriber_key=@subscriber_key  order by id"
        UpdateCommand="UPDATE [tbl_subscriberreceipient] SET [Phone] = @Phone,[Email] = @Email
        WHERE [subscriber_key] = @subscriber_key" OnInserted="SqlDataSource2_Inserted">
<DeleteParameters>
    <asp:Parameter Name="subscriber_key" Type="String" />
</DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="txtkey" Name="subscriber_key" 
                    PropertyName="Text" />
            </SelectParameters>
<UpdateParameters>
 <asp:Parameter Name="Phone" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
      <asp:Parameter Name="subscriber_key" Type="String" />
</UpdateParameters>
<InsertParameters>
   <asp:Parameter Name="subscriber_key" Type="String" />
  <asp:Parameter Name="Phone" Type="String" />
          <asp:Parameter Name="Email" Type="String" />
 </InsertParameters>
    </asp:SqlDataSource>
   </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                  </Content>
                                  </ext:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:TextBox ID="txtconstring" runat="server" Visible="False" Width="204px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <ext:Panel ID="Panel5" runat="server" Title="Procedure Details" AutoHeight="true" 
                            FormGroup="true" Width="500px">
                    <Content>
                                        <table class="gridtable">
                                            <tr>
                                                <td>
                                                    Column Procedure Name:
                                                    <asp:TextBox ID="txt_childprocedure" runat="server" AutoPostBack="True" 
                                                        Width="308px"></asp:TextBox>
                                                    <br />
                                                    Alertz Procedure Name:&nbsp;&nbsp;
                                                    <asp:TextBox ID="txt_parentprocedure" runat="server" AutoPostBack="True" 
                                                        Width="307px"></asp:TextBox>
                                                    <br />
                                                    <table cellpadding="8" style="width: 484px">
                                                        <tr>
                                                            <td style="width:50%; vertical-align: top;">
                                                                <b>Input Parameters:</b>
                                                                <asp:BulletedList ID="blInputParameters" runat="server">
                                                                </asp:BulletedList>
                                                            </td>
                                                            <td style="vertical-align: top;" class="style1">
                                                                <b>Output Parameters:</b>
                                                                <asp:BulletedList ID="blOutputParameters" runat="server">
                                                                </asp:BulletedList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="gvParameters" runat="server" AutoGenerateColumns="False" 
                                                        CssClass="mGrid" DataKeyNames="ParameterName" Width="482px">
                                                        <Columns>
                                                            <asp:BoundField DataField="ParameterName" HeaderText="Parameter" />
                                                            <asp:TemplateField HeaderText="Value">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="ParameterValue" runat="server" Columns="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:Button ID="btnExecSproc" runat="server" Font-Size="Small" 
                                                        Text="Execute Stored Procedure" Width="189px" />
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                      </Content>
                      </ext:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <ext:Panel ID="Panel4" runat="server" Title="Custom Message Details" AutoHeight="true" 
                            FormGroup="true" Width="500px">
                    <Content>
                                        
                                        <table class="gridtable">
                                            <tr>
                                                <td>
                                                    <br />
                                                    <asp:TextBox ID="txtconstring1" runat="server" AutoPostBack="True" 
                                                        Height="39px" TextMode="MultiLine" Width="485px" Font-Size="Small"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                   </Content>
                                   </ext:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Save" 
                                        ValidationGroup="valrule" Width="64px" />
                                    <asp:Button ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" 
                                        Width="101px" />
                                </td>
                                <td>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:AlertZ %>" 
                                        SelectCommand="proc_selservicetype" SelectCommandType="StoredProcedure">
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                                    </td>
                    <td style="width: 100px; height: 200px;" valign="top" align="justify">
        
    
                        <ext:Panel ID="Panel3" runat="server" Title="Grid Column" AutoHeight="true" 
                            FormGroup="true" Width="300px">
                    <Content>
                            <table style="height: 107px; width: 321px;">
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                       <asp:GridView ID="gvFields" runat="server" CssClass="mGrid" Width="314px" 
                                            DataKeyNames="FieldColumn">
                                            <Columns>
                                                                                     
                                                    <asp:TemplateField HeaderText="New Value">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="FieldValue" runat="server" Text='<%#Eval("FieldColumn") %>' Columns="20"></asp:TextBox>
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
                      </Content>
                      </ext:Panel>
                    </td>
                </tr>
            </table>
        </fieldset>
   
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </div> 
    </form>
</body>
</html>
