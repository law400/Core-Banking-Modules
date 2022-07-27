<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="ReceivedCheques.aspx.vb" Inherits="CustomerService_ReceivedCheques" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
<script language=javascript>

 function SelectAllCheckboxes(spanChk){

   // Added as ASPX uses SPAN for checkbox
   var oItem = spanChk.children;
   var theBox= (spanChk.type=="checkbox") ? 
        spanChk : spanChk.children.item[0];
   xState=theBox.checked;
   elm=theBox.form.elements;

   for(i=0;i<elm.length;i++)
     if(elm[i].type=="checkbox" && 
              elm[i].id!=theBox.id)
     {
       //elm[i].click();
       if(elm[i].checked!=xState)
         elm[i].click();
       //elm[i].checked=xState;
     }
 }
</script>
    <br />
    <table style="width: 612px">
        <tr>
            <td colspan="5" style="height: 27px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5" style="height: 30px">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="Small"
                        ForeColor="Black" GridLines="Vertical" Height="9px" Visible="False" Width="726px">
                        <FooterStyle BackColor="#CCCC99" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="chkAll" runat="server" onclick="javascript:SelectAllCheckboxes(this);"
                                        type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="Check1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField
                                DataTextField="Accountnumber" HeaderText="Accountnumber" />
                            <asp:BoundField DataField="typedesc" HeaderText="CheckBook Type" SortExpression="typedesc">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="source" DataFormatString="source" HeaderText="Account Branch" />
                            <asp:BoundField DataField="Destin" HeaderText="Destination Branch" SortExpression="Destin" />
                            <asp:BoundField DataField="numberofleaves" DataFormatString="{0:n}" HeaderText="No Of Leaves"
                                SortExpression="numberofleaves" />
                            <asp:BoundField DataField="valuedate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Request Date"
                                SortExpression="valuedate" />
                                <asp:TemplateField Visible="False">
                <ItemTemplate>
                    <asp:Label ID="LblDoc1" runat="server" Text='<%#Eval("Accountnumber") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                            <asp:BoundField DataField="startid" HeaderText="Start No" />
                            <asp:BoundField DataField="endid" HeaderText="End No" />
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
            <td align="center" colspan="5" style="height: 17px">
                <asp:Button ID="Btnsubmit2" runat="server" BackColor="#C0C0FF" Text="Issue" Width="101px" /><asp:Button ID="BtnReturn2" runat="server" BackColor="#C0C0FF"
                        Text="Return" Width="53px" /></td>
        </tr>
    </table>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

