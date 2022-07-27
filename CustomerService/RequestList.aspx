<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false"   CodeFile="RequestList.aspx.vb" Inherits="CustomerService_RequestList" title="RequestList Page" %>
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
<div class="box-blue">
        <div class="content">
            <table style="width: 562px">
                            <tr>
                                <td colspan="2" style="height: 4px">
                                    <span style="font-size: 12pt; color: #000099"><strong></strong></span>
                                </td>
                                <td colspan="1" style="width: 177px; height: 4px">
                                </td>
                                <td colspan="1" style="height: 4px">
                                </td>
                            </tr>
                <tr>
                    <td colspan="2" style="height: 13px">
                        Select a Request Type</td>
                    <td style="width: 177px; height: 13px">
                        <asp:DropDownList ID="DrpReqType" runat="server" AutoPostBack="True">
                        </asp:DropDownList></td>
                    <td style="width: 100px; height: 13px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 130px; height: 13px">
                    </td>
                    <td style="height: 13px">
                    </td>
                    <td style="width: 177px; height: 13px">
                    </td>
                    <td style="width: 100px; height: 13px">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 13px">
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table style="width: 562px">
                                    <tr>
                                        <td colspan="4" style="height: 13px">
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        Font-Size="Small" PageSize="20" Width="599px">
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
                                                    <asp:HyperLinkField
                                                        DataTextField="ReceiptID" HeaderText="ReceiptID" />
                                                    <asp:BoundField DataField="SupplyID" HeaderText="SupplyID" SortExpression="SupplyID">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OrderNo" DataFormatString="OrderNo" HeaderText="Order No" />
                                                    <asp:BoundField DataField="WayBill" HeaderText="Way Bill" SortExpression="WayBill" />
                                                    <asp:BoundField DataField="Qty" DataFormatString="{0:n}" HeaderText="Quantity" />
                                                    <asp:BoundField DataField="valuedate" HeaderText="Placement Date" SortExpression="valuedate" DataFormatString="{0:dd/MM/yyyy}" />
                                                     <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="LblDoc1" runat="server" Text='<%#Eval("Receiptid") %>'></asp:Label>
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
                                        <td style="width: 130px; height: 13px">
                                        </td>
                                        <td style="width: 100px; height: 13px">
                                        </td>
                                        <td style="width: 177px; height: 13px">
                                        </td>
                                        <td style="width: 100px; height: 13px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="height: 13px; text-align: center">
                                            <asp:Button ID="BtnSubmit" runat="server" Text="Authorise" Width="76px" BackColor="#C0C0FF" /><asp:Button
                                                ID="BtnReturn" runat="server" Text="Reject" Width="53px" BackColor="#C0C0FF" /></td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table style="width: 562px">
                                    <tr>
                                        <td colspan="4" style="height: 14px">
                                            <span style="font-size: 12pt; color: #000099"><strong><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="Small"
                                                ForeColor="Black" GridLines="Vertical" Height="9px"  Visible="False"
                                                Width="726px">
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
                                                    <asp:HyperLinkField DataNavigateUrlFields="Accountnumber" DataNavigateUrlFormatString="ManageCheckBook.aspx?Chk={0}"
                                                        DataTextField="Accountnumber" HeaderText="Accountnumber" />
                                                    <asp:BoundField DataField="typedesc" HeaderText="CheckBook Type" SortExpression="typedesc">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="source" DataFormatString="source" HeaderText="Account Branch" />
                                                    <asp:BoundField DataField="Destin" HeaderText="Destination Branch" SortExpression="Destin" />
                                                    <asp:BoundField DataField="numberofleaves" DataFormatString="{0:n}" HeaderText="No Of Leaves" SortExpression="numberofleaves" />
                                                    <asp:BoundField DataField="valuedate" HeaderText="Request Date" SortExpression="valuedate" DataFormatString="{0:dd/MM/yyyy}" />
                                                    
                                                </Columns>
                                                <RowStyle BackColor="#F7F7DE" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                            </strong></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 130px; height: 13px">
                                        </td>
                                        <td style="width: 100px; height: 13px">
                                        </td>
                                        <td style="width: 177px; height: 13px">
                                        </td>
                                        <td style="width: 100px; height: 13px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="height: 13px; text-align: center">
                                            <asp:Button ID="Btnsubmit2" runat="server" Text="Range Check" Width="101px" Visible="False" BackColor="#C0C0FF" /><asp:Button
                                                ID="BtnReturn2" runat="server" Text="Return" Width="53px" BackColor="#C0C0FF" /></td>
                                    </tr>
                                </table>
                            </asp:View><asp:View ID="View3" runat="server">
                                <table style="width: 562px">
                                    <tr>
                                        <td colspan="4" style="height: 13px">
                                            <table style="width: 612px">
                                                <tr>
                                                    <td colspan="5" style="height: 27px">
                                                        <div class="box-blue">
                                                            <h2>
                                                                <span style="color: #ffffff"><strong>Receipt</strong></span></h2>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 18px">
                                                    </td>
                                                    <td style="width: 23px; height: 18px">
                                                    </td>
                                                    <td style="width: 92px; height: 18px">
                                                    </td>
                                                    <td style="width: 97px; height: 18px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 141px; height: 18px">
                                                        <asp:Label ID="Label1" runat="server" Text="Receipt ID"></asp:Label></td>
                                                    <td style="width: 96px; height: 18px">
                                                        <asp:TextBox ID="txtReceiptid" runat="server" AutoPostBack="True" Font-Size="Small"
                                                            Width="78px"></asp:TextBox></td>
                                                    <td style="width: 23px; height: 18px">
                                                    </td>
                                                    <td style="width: 92px; height: 18px">
                                                    </td>
                                                    <td style="width: 97px; height: 18px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 141px; height: 18px">
                                                        Supplier</td>
                                                    <td style="width: 96px; height: 18px">
                                                        <asp:DropDownList ID="DrpSupplier" runat="server">
                                                        </asp:DropDownList></td>
                                                    <td style="width: 23px; height: 18px">
                                                    </td>
                                                    <td style="width: 92px; height: 18px">
                                                        Order No</td>
                                                    <td style="width: 97px; height: 18px">
                                                        <asp:TextBox ID="txtOrder" runat="server" AutoPostBack="True" Font-Size="Small" ReadOnly="True"
                                                            Width="87px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOrder"
                                                            Display="Dynamic" ErrorMessage="Enter Order No" ValidationGroup="News" Width="122px">Enter Order No</asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 141px; height: 18px">
                                                        Quantity</td>
                                                    <td style="width: 96px; height: 18px">
                                                        <asp:TextBox ID="txtQty" runat="server" AutoPostBack="True" Font-Size="Small" ReadOnly="True"
                                                            Width="87px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQty"
                                                            Display="Dynamic" ErrorMessage="Enter Item Quantity" ValidationGroup="News" Width="108px">Enter Item Quantity</asp:RequiredFieldValidator></td>
                                                    <td style="width: 23px; height: 18px">
                                                    </td>
                                                    <td style="width: 92px; height: 18px">
                                                        Way Bill No</td>
                                                    <td style="width: 97px; height: 18px">
                                                        <asp:TextBox ID="txtWayBill" runat="server" AutoPostBack="True" Font-Size="Small"
                                                            ReadOnly="True" Width="87px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtWayBill"
                                                            Display="Dynamic" ErrorMessage="Enter WayBill ID" ValidationGroup="News" Width="122px">Enter WayBill ID</asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 141px; height: 18px">
                                                        Cost</td>
                                                    <td style="width: 96px; height: 18px">
                                                        <asp:TextBox ID="txtCost" runat="server" AutoPostBack="True" Font-Size="Small" ReadOnly="True"
                                                            Width="87px"></asp:TextBox>
                                                        </td>
                                                    <td style="width: 23px; height: 18px">
                                                    </td>
                                                    <td style="width: 92px; height: 18px">
                                                        Date Received</td>
                                                    <td style="width: 97px; height: 18px">
                                                        <asp:TextBox ID="txtDateReceived" runat="server" AutoPostBack="True" Font-Size="Small"
                                                            ReadOnly="True" Width="73px"></asp:TextBox><asp:HyperLink ID="HyperLink2" runat="server"
                                                                ImageUrl="~/Images/pdate.gif" Width="17px">HyperLink</asp:HyperLink></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 141px; height: 18px">
                                                        Start SerialNo</td>
                                                    <td style="width: 96px; height: 18px">
                                                        <asp:TextBox ID="txtStartNo" runat="server" AutoPostBack="True" Font-Size="Small"
                                                            ReadOnly="True" Width="87px"></asp:TextBox></td>
                                                    <td style="width: 23px; height: 18px">
                                                    </td>
                                                    <td style="width: 92px; height: 18px">
                                                        End SerialNo</td>
                                                    <td style="width: 97px; height: 18px">
                                                        <asp:TextBox ID="txtEndNo" runat="server" AutoPostBack="True" Font-Size="Small" ReadOnly="True"
                                                            Width="87px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 141px; height: 18px">
                                                        Select Range CheckType</td>
                                                    <td style="width: 96px; height: 18px">
                                                        <asp:DropDownList ID="DrpChecktype" runat="server" AutoPostBack="True">
                                                        </asp:DropDownList></td>
                                                    <td style="width: 23px; height: 18px">
                                                    </td>
                                                    <td style="width: 92px; height: 18px">
                                                    </td>
                                                    <td style="width: 97px; height: 18px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 141px; height: 18px">
                                                    </td>
                                                    <td style="width: 96px; height: 18px">
                                                    </td>
                                                    <td style="width: 23px; height: 18px">
                                                    </td>
                                                    <td style="width: 92px; height: 18px">
                                                    </td>
                                                    <td style="width: 97px; height: 18px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" style="height: 18px" align="center">
                                                        <asp:Button ID="Btnsubmit1" runat="server" Text="Range Supply Cheques" Width="153px" ValidationGroup="News" BackColor="#C0C0FF" /><asp:Button
                                                ID="Button1" runat="server" Text="Return" Width="86px" BackColor="#C0C0FF" />
                                                        <asp:Button
                                                ID="Button2" runat="server" Text="Reset" Width="86px" BackColor="#C0C0FF" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 130px; height: 13px">
                                        </td>
                                        <td style="width: 100px; height: 13px">
                                        </td>
                                        <td style="width: 177px; height: 13px">
                                        </td>
                                        <td style="width: 100px; height: 13px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 13px" colspan="4">
                                             <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        Font-Size="Small" PageSize="20" Width="542px">
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 13px">
                                        </td>
                                        <td style="width: 177px; height: 13px">
                                        </td>
                                        <td style="width: 100px; height: 13px">
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 13px">
                        </td>
                    <td style="width: 177px; height: 13px">
                    </td>
                    <td style="width: 100px; height: 13px">
                    </td>
                </tr>
                        </table>
        </div>
    </div>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

