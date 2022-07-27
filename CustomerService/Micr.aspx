<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="Micr.aspx.vb" Inherits="CustomerService_Micr" title="Micr Cheques Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>

    <table style="width: 678px">
        <tr>
            <th class="first" style="width: 206px; height: 29px">
                Cheques 
                Available in Store</th>
            <th style="height: 29px">
            </th>
            <th style="height: 29px">
                Customer Request Statistic</th>
        </tr>
        <tr class="row-a">
            <td class="first" style="width: 206px; height: 28px;" valign="top">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        Font-Size="XX-Small" Width="387px">
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
            NextPageText="Next" PreviousPageText="Previous" />
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
            <asp:HyperLinkField DataTextField="ReceiptID" HeaderText="ReceiptID" /><asp:BoundField DataField="Qty" DataFormatString="{0:n}" HeaderText="Quantity" />
            <asp:BoundField DataField="startno" HeaderText="Start No" />
            <asp:BoundField DataField="endno" HeaderText="End no" />
            <asp:TemplateField Visible="False">
                <ItemTemplate>
                    <asp:Label ID="LblDoc1" runat="server" Text='<%#Eval("Receiptid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Font-Size="XX-Small" />
        <AlternatingRowStyle BackColor="White" /><RowStyle BackColor="#F7F7DE" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
            </td>
            <td style="color: #0000ff; height: 28px;">
            </td>
            <td style="color: #0000ff; height: 28px;" valign="top"><asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        Font-Size="XX-Small" Width="400px">
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
            NextPageText="Next" PreviousPageText="Previous" />
                <RowStyle BackColor="#F7F7DE" />
                <Columns>
                    <asp:BoundField DataField="typedesc" DataFormatString="{0:n}" HeaderText="Cheque Types" />
                    <asp:BoundField DataField="No Of Request" HeaderText="No Of Request" />
                    <asp:BoundField DataField="Unit Leaves" HeaderText="Unit Leaves" />
                    <asp:BoundField DataField="Total Request Leaves" HeaderText="Total Request Leaves" />
                </Columns>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Font-Size="XX-Small" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            </td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first" style="width: 206px">
                <asp:Button ID="BtnSubmit" runat="server" BackColor="#C0C0FF" Font-Size="Small" Text="Submit"
                    ValidationGroup="News" Width="63px" />
                <asp:Button ID="BtnReset" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                    Text="Reset" Width="63px" />
                <asp:Button ID="Btncancel" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                    Text="Return" Width="63px" />
            </td>
            <td colspan="1">
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table style="width: 301px">
        <tr>
            <th class="first" colspan="2" style="height: 29px">
                Discarded Cheque Range</th>
            <th class="first" colspan="1" style="height: 29px">
                <asp:CheckBox ID="Chkundo" runat="server" AutoPostBack="True" Text="Undo Discarded"
                    Width="136px" /></th>
        </tr>
        <tr>
            <th class="first" style="width: 256px; height: 29px">
                <asp:Label ID="Label1" runat="server" Text="Receipt ID" Width="84px"></asp:Label></th>
            <th style="width: 152px; height: 29px">
                <asp:TextBox ID="txtreceipt" runat="server" Font-Size="Small" Width="171px" 
                    AutoPostBack="True"></asp:TextBox></th>
            <th style="width: 152px; height: 29px">
            </th>
        </tr>
        <tr class="row-a">
            <td class="first" style="width: 256px">
                Cheque Book Type</td>
            <td style="width: 152px">
                <asp:TextBox ID="txtChktype" runat="server" Font-Size="Small" ReadOnly="True"
                    Width="171px"></asp:TextBox></td>
            <td style="width: 152px">
            </td>
        </tr>
        <tr class="row-b">
            <td class="first" style="width: 256px">
                Start No</td>
            <td style="width: 152px">
                <asp:TextBox ID="txtstart" runat="server" Font-Size="Small" ReadOnly="True" Width="171px"></asp:TextBox></td>
            <td style="width: 152px">
            </td>
        </tr>
        <tr class="row-a">
            <td class="first" style="width: 256px">
                End No</td>
            <td style="width: 152px">
                <asp:TextBox ID="txtEndno" runat="server" Font-Size="Small" ReadOnly="True" Width="171px"></asp:TextBox></td>
            <td style="width: 152px">
            </td>
        </tr>
        <tr class="row-b">
            <td class="first" style="width: 256px">
                Discard
                SerialNo</td>
            <td style="width: 152px">
                <asp:TextBox ID="txtserialno" runat="server" AutoPostBack="True" Font-Size="Small"
                    Width="169px" TextMode="MultiLine"></asp:TextBox></td>
            <td style="width: 152px">
            </td>
        </tr>
        <tr class="row-b">
            <td class="first" colspan="3">
                <asp:Label ID="Label2" runat="server" style="color: #FF0000; font-weight: 700" 
                    Text="Please Ensure that you place a comma (,) after every Serial Number." 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr class="row-a" style="color: #0000ff">
            <td class="first" style="width: 256px">
            </td>
            <td colspan="1">
                &nbsp;<asp:Button ID="BtnDiscard" runat="server" BackColor="#C0C0FF" 
                    Font-Size="Small" Text="Discard"
                    ValidationGroup="News" Width="63px" />
                </td>
            <td colspan="1">
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        Font-Size="Small" PageSize="20" Width="542px" Visible="False">
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
            NextPageText="Next" PreviousPageText="Previous" />
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
            <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" SortExpression="SerialNo">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="ReceiptID" HeaderText="ReceiptID" SortExpression="ReceiptID" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Createdate" HeaderText="Createdate" SortExpression="Createdate" />
        </Columns>
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

