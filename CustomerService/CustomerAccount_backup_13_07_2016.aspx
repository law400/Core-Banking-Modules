<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"    AutoEventWireup="false"   CodeFile="CustomerAccount.aspx.vb" Inherits="CustomerService_CustomerAccount" title="Customer Account Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
 <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>

     <div class="box box-info">
              <div class="box-header">
<%--<div class="col-md-4">--%>
                    <tr>
            <td style="width: 113px; height: 29px;">
                Customer ID</td>
            <td colspan="2" style="height: 29px">
                &nbsp;<asp:HyperLink ID="Hypsearch" runat="server" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                <asp:TextBox ID="txtCustomerid" runat="server" AutoPostBack="True" Font-Size="Small"  CssClass="form-control"></asp:TextBox>
                        <br />
                        </td>
            <td style="width: 95px; height: 29px;">
            </td>
        </tr>
    <%--</div>--%>
                   <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
<div class="box-body">
  <%--  <div class="row">--%>

       
          <div class="col-md-4">


               <div class="form-group" > 
                    <tr>
                                                        <td style="width: 179px; height: 19px">
                                                            Select Account Branch</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:DropDownList ID="DrpBranch" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
               </div>


             <tr>
                                                        <td colspan="2" style="height: 27px">
                                                            <div class="box-blue">
                                                                <h2>
                                                                    <span style="color: #ffffff"><strong>Account Opening Info</strong></span></h2>
                                                            </div>
                                                        </td>
                                                    </tr>
               <div class="form-group" > 
                                                    <tr>
                                                        <td style="width: 179px; height: 19px">
                                                            Select Account Product</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:DropDownList ID="DrpProduct" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                   </div>
                <div class="form-group" > 
                                                    <tr>
                                                        <td style="width: 179px; height: 19px">
                                                            Select SubBranch</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:DropDownList ID="DrpSubBranch" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                    </div>
                <div class="form-group" > 
                                                    <tr>
                                                        <td style="width: 179px; height: 19px">
                                                            Select Account Tier</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:DropDownList ID="DrpAccountTier" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" CssClass="form-control">
                                                            </asp:DropDownList>
                                                            <br />
                                                            <asp:Label ID="LabelDepAmt" runat="server" ForeColor="#0000CC" 
                                                                Text="Max Deposit Amt:" Visible="False"></asp:Label>
                                                            &nbsp;<asp:Label ID="lblMaxDepAmt" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="LabelMaxCum" runat="server" ForeColor="#0000CC" 
                                                                Text="Max Cum Bal:" Visible="False"></asp:Label>
                                                            &nbsp;<asp:Label ID="lblMaxCumBal" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                    </div>
                <div class="form-group" >                                       
              <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            Account Description</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtacctdesc" runat="server" Font-Size="Small" Height="41px" 
                                                                TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                        </td>
                                                    </tr>
                    </div>

                <div class="form-group" > 
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            Block View On Account?</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:CheckBox ID="chkview" runat="server" AutoPostBack="True" Text="Yes" />
                                                        </td>
                                                    </tr>

                    </div>
                <div class="form-group" > 
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            Debit Interest (per annum)</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtdrint" runat="server" Font-Size="Small"  CssClass="form-control"></asp:TextBox>
                                                        </td>
                                                    </tr>
                    </div>
                <div class="form-group" > 
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            <asp:Label ID="Label15" runat="server" Text="Old Account Number" 
                                                                Visible="False"></asp:Label>
                                                        </td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtold" runat="server" Font-Size="Small"  
                                                                AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                                                        </td>
                                                    </tr>
                    </div>
                <div class="form-group" > 
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            <asp:Label ID="Label13" runat="server" Text="Staff ID" Visible="False"></asp:Label>
                                                        </td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtstaffID" runat="server" Font-Size="Small"  
                                                                AutoPostBack="True" Visible="False" CssClass="form-control"></asp:TextBox>
                                                            <asp:Label ID="Label14" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                    </div>
                <div class="form-group" > 
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            Credit Interest (per annum)</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtcrint" runat="server" Font-Size="Small" 
                                                                CssClass="form-control"></asp:TextBox>
                                                        </td>
                                                    </tr>
                    </div>
                <div class="form-group" > 
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            <asp:Label ID="Label12" runat="server" Text="Sweep To Account" Visible="False"></asp:Label>
                                                        </td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtsweep" runat="server" AutoPostBack="True" Font-Size="Small" 
                                                                Visible="False" CssClass="form-control"></asp:TextBox>
                                                        </td>
                                                    </tr>
                    </div>
                <div class="form-group" > 
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            OD&nbsp; Rate</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtodamt" runat="server" AutoPostBack="True" Font-Size="Small" 
                                                                CssClass="form-control"></asp:TextBox>
                                                        </td>
                                                    </tr>
                    </div>

              </div>

    <div class="col-md-4">
            <div class="form-group">
                 <tr>
                                                        <td colspan="2" style="height: 5px;">
                                                            <h3>
                                                                Document&nbsp; Detail</h3>
                                                        </td>
                                                    </tr>
             <tr>
                                <th class="first" colspan="2" style="height: 29px">
                                    Account Opening Document Submitted</th>
                            </tr>
            <tr class="row-a">
                                <td class="first" colspan="2">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="Small"
                                        ForeColor="Black" GridLines="Vertical" SkinID="booksSkin" Width="313px">
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <input id="chkAll" runat="server" onclick="javascript: SelectAllCheckboxes(this);"
                                                        type="checkbox" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="Check1" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="docname" HeaderText="Document Description" 
                                                SortExpression="docname">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDoc1" runat="server" Text='<%#Eval("reqid") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="docid" Visible="False" />
                                        </Columns>
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr class="row-a" style="color: #0000ff">
                                <td class="first" colspan="2" style="text-align: center">
                                    &nbsp;<asp:Button ID="Btnsave1" runat="server" BackColor="#C0C0FF" Font-Size="Small"
                                        Text="Remove" ValidationGroup="News" Width="68px" />
                                    </td>
                            </tr>

                <br />
                <br />
                <br />
                <br />

                </div>
            <div class="form-group">
            <tr>
                                <th class="first" colspan="2" style="height: 29px">
                                    Account Opening Document Not Submitted</th>
                            </tr>
                            <tr class="row-a">
                                <td class="first" colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical" SkinID="booksSkin" Width="315px" Font-Size="Small">
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <input id="chkAll" runat="server" onclick="javascript: SelectAllCheckboxes(this);"
                                                        type="checkbox" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="Check2" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="docname" HeaderText="Document Description" 
                                                SortExpression="docname">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDoc2" runat="server" Text='<%#Eval("reqid") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="docid" Visible="False" />
                                        </Columns>
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr class="row-a" style="color: #0000ff">
                                <td class="first" colspan="2" style="text-align: center">
                                    &nbsp;<asp:Button ID="Btnsave2" runat="server" BackColor="#C0C0FF" Font-Size="Small"
                                        Text="Add" ValidationGroup="News" Width="63px" />
                                    </td>
                            </tr>

                </div>

        </div>

    <div class="col-md-3" style="background-color: #ccccff; font-size:11px; height: 100%;">
                           <div class="form-group" style="font-size: small"> 
                            <tr>
                                <td colspan="2" style="height: 22px; background-color: #FF9E0D">
                                    <span style="font-weight: bold; font-size: 12pt; color: #000099">Customer Info</span></td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                    Account Title:&nbsp;</td>
                                <td style="width: 100px; height: 15px">
                                   <asp:DropDownList ID="DrpTitle" runat="server" AutoPostBack="True" 
                                                                Enabled="False" Font-Size="Small" CssClass="form-control">
                                                            </asp:DropDownList>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px">
                                    <span style="color: #000000">Full Name&nbsp;:&nbsp;</span></td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtFullname" runat="server" Font-Size="Small" Height="41px" 
                                                                ReadOnly="True" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px">
                                    <span style="color: #000000">Other Name:<strong>&nbsp;</strong></span></td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtOthername" runat="server" Font-Size="Small" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px">
                                    <span style="color: black">Sex:</span><strong style="font-weight: bold; color: black">&nbsp;</strong></td>
                                <td style="width: 100px">
                                  <asp:DropDownList ID="DrpSex" runat="server" AutoPostBack="True" 
                                                                Enabled="False" Font-Size="Small" CssClass="form-control">  </asp:DropDownList> 
                                </td>
                            </tr>
                            </div>
                            
                            
                            
                            
                            
                            
                              <div class="form-group" style="font-size: small"> 
                            <tr>
                                <td colspan="2" style="height: 22px; background-color: #FF9E0D">
                                    <span style="font-weight: bold; font-size: 12pt; color: #000099">Product Info</span></td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                    Product Name:&nbsp;</td>
                                <td style="width: 100px; height: 15px">
                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                </td>
                            </tr>
                            </div>
             <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                    Product Start Date:&nbsp;</td>
                                <td style="width: 100px; height: 15px">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px">
                                    <span style="color: #000000">Product Expiry Date:</span></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label3" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                          
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px">
                                    <span style="color: black">Product Currency:</span><strong style="font-weight: bold; color: black">&nbsp;</strong></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label4" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px; height: 18px">
                                    <span style="color: black">Minimum Account Bal:&nbsp;</span></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label5" runat="server" ForeColor="Black" Width="126px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr style="color: #ffff00">
                                <td style="width: 222px; height: 18px">
                                    <span style="color: black">Product Type:</span><b style="font-weight: normal"></b></td>
                                <td style="width: 100px; height: 18px">
                                    </b>
                                    <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Opening Balance:</td>
                              
                                <td style="width: 100px; height: 18px"></td>
                               
                                <asp:Label ID="Label7" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                              
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Closing Balance:</td>
                            
                                <td style="width: 100px; height: 18px"></td>
                              
                                <asp:Label ID="Label8" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                           
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                   Minimum Interest:</td>
                              
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label9" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                </td>
                            </tr>
                            </div>
              <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Debit Interest:</td>
                              
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label10" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                </td>
                            </tr>
                            </div>

              <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Credit Interest:</td>
                              
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label11" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            
              <tr>
                    <td colspan="5" style="text-align: center">
                        <asp:Label ID="Label25" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                            
                        </div>

    </div>

                                <div class="box-footer">
                   
            
    <asp:TextBox ID="txtnone" runat="server" Visible="False"></asp:TextBox>
                                     <div class="col-md-4"> 
                                                <asp:Button ID="Btnsubmit" runat="server" CssClass="btn bg-purple btn-flat margin" 
                                                    Text="Submit" ValidationGroup="News1"  Width="100%"/>
                                         </div>
                                     <div class="col-md-4"> 
                                                <asp:Button ID="BtnReset" runat="server" CssClass="btn bg-maroon btn-flat margin" 
                                                    Text="Reset"  Width="100%"/>
                                         </div>
                                         
                                     <div class="col-md-4"> 
                                    <asp:Button ID="BtnTarget" runat="server" BackColor="#C0C0FF" Font-Size="Small"  Width="100%"
                                                                Height="21px" Text="Modify Target Account" Visible="False"  CssClass="btn bg-orange btn-flat margin" />

                                         </div>
    </div>




</asp:View>


                     </asp:MultiView>

     </div>

    <%--<div class="box-blue">
        <div class="content">
            <table border="0" style="width: 298px; height: 187px; font-size: 8pt;" id="TABLE1" >
        
        <caption style="text-align: left;" >
            <span style="color: #000099"><span style="font-size: 12pt">
        <strong><span></span></strong>
            </span></span>
        </caption>
        <tr>
            <td style="width: 113px; height: 13px;">
            </td>
            <td style="width: 72px; height: 13px;">
            </td>
            <td style="width: 101px; height: 13px;">
            </td>
            <td style="width: 95px; height: 13px;">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; height: 29px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Customer ID</td>
            <td colspan="2" style="height: 29px">
                <asp:TextBox ID="txtCustomerid" runat="server" AutoPostBack="True" Font-Size="Small" Width="93px"></asp:TextBox>
                <asp:HyperLink ID="Hypsearch" runat="server" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></td>
            <td style="width: 95px; height: 29px;">
            </td>
        </tr>
                <tr>
                    <td colspan="4" style="height: 29px">
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <div style="text-align: left">
                                    <table style="width: 658px">
                                        <tr>
                                            <td colspan="1" style="width: 21px" valign="top">
                                                &nbsp;</td>
                                            <td rowspan="2" valign="top">
                                                <table style="width: 271px; background-color: #ccccff">
                                                    <tr>
                                                        <td style="font-weight: bold; width: 307px; color: black; height: 15px">
                                                            Product &nbsp;Name:&nbsp;</td>
                                                        <td style="width: 100px; height: 15px">
                                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                                                                Width="124px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 23px; background-color: #FF9E0D;">
                                                            <span style="font-weight: bold; font-size: 12pt; color: #000099">Product Info</span></td>
                                                    </tr>
                                                    <tr style="font-weight: bold; color: #000000">
                                                        <td style="width: 307px">
                                                            Product Expiry Date:&nbsp;</td>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                                                                Width="126px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="font-weight: bold; color: #000000">
                                                        <td style="width: 307px; height: 18px">
                                                            <span style="color: #000000">Product Start Date:</span></td>
                                                        <td style="width: 100px; height: 18px">
                                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                                                                Width="128px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 307px; height: 18px">
                                                            <strong><span style="font-weight: bold; color: black">Minimum Account Bal:</span></strong></td>
                                                        <td style="width: 100px; height: 18px">
                                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                                                                Width="126px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 307px; height: 18px">
                                                            <strong style="font-weight: bold; color: black">Product Currency:&nbsp;</strong></td>
                                                        <td style="width: 100px; height: 18px">
                                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                                                                Width="125px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold; width: 307px; color: black; height: 18px">
                                                            Opening Balance:</td>
                                                        <td style="width: 100px; height: 18px">
                                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                                                                Width="123px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold; width: 307px; color: black; height: 18px">
                                                            Product Type:</td>
                                                        <td style="width: 100px; height: 18px">
                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                                                                Width="125px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold; width: 307px; color: black; height: 18px">
                                                            Minimum Interest:</td>
                                                        <td style="width: 100px; height: 18px">
                                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                                                                Width="122px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold; width: 307px; color: black; height: 18px">
                                                            Closing Balance:</td>
                                                        <td style="width: 100px; height: 18px">
                                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                                                                Width="122px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold; width: 307px; color: black; height: 18px">
                                                            Credit Interest:</td>
                                                        <td style="width: 100px; height: 18px">
                                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                                                                Width="122px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold; width: 307px; color: black; height: 18px">
                                                            Debit Interest:</td>
                                                        <td style="width: 100px; height: 18px">
                                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                                                                Width="122px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td colspan="1" valign="top">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="width: 21px" valign="top">
                                                <table style="width: 279px; background-color: #ccccff">
                                                    <tr>
                                                        <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                                            Account Title:</td>
                                                        <td style="width: 100px; height: 15px">
                                                            <asp:DropDownList ID="DrpTitle" runat="server" AutoPostBack="True" 
                                                                Enabled="False" Font-Size="Small">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                         <td colspan="2" style="height: 22px; background-color: #FF9E0D">
                                                            <span style="font-weight: bold; font-size: 12pt; color: #000099">Customer Info</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                                            Fullname:&nbsp;</td>
                                                        <td style="width: 100px; height: 15px">
                                                            <asp:TextBox ID="txtFullname" runat="server" Font-Size="Small" Height="41px" 
                                                                ReadOnly="True" TextMode="MultiLine" Width="149px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="font-weight: bold; color: #000000">
                                                        <td style="width: 222px">
                                                            <span style="color: #000000">Other Name &nbsp;:&nbsp;</span></td>
                                                        <td style="width: 100px">
                                                            <asp:TextBox ID="txtOthername" runat="server" Font-Size="Small" ReadOnly="True" 
                                                                Width="149px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="color: #000000">
                                                        <td style="width: 222px; height: 18px">
                                                            <span style="color: #000000"><strong style="font-weight: bold; color: black">
                                                            Sex:&nbsp;</strong></span></td>
                                                        <td style="width: 100px; height: 18px">
                                                            <asp:DropDownList ID="DrpSex" runat="server" AutoPostBack="True" 
                                                                Enabled="False" Font-Size="Small">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td valign="top">
                                                &nbsp;</td>
                                            <td colspan="1" valign="top">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="width: 21px" valign="top">
                                                <table style="width: 308px">
                                                    <tr>
                                                        <td style="width: 179px; height: 19px">
                                                            Select Account Branch</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:DropDownList ID="DrpBranch" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 27px">
                                                            <div class="box-blue">
                                                                <h2>
                                                                    <span style="color: #ffffff"><strong>Account Opening Info</strong></span></h2>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 19px">
                                                            Select Account Product</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:DropDownList ID="DrpProduct" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 19px">
                                                            Select SubBranch</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:DropDownList ID="DrpSubBranch" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 19px">
                                                            Select Account Tier</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:DropDownList ID="DrpAccountTier" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small">
                                                            </asp:DropDownList>
                                                            <br />
                                                            <asp:Label ID="LabelDepAmt" runat="server" ForeColor="#0000CC" 
                                                                Text="Max Deposit Amt:" Visible="False"></asp:Label>
                                                            &nbsp;<asp:Label ID="lblMaxDepAmt" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="LabelMaxCum" runat="server" ForeColor="#0000CC" 
                                                                Text="Max Cum Bal:" Visible="False"></asp:Label>
                                                            &nbsp;<asp:Label ID="lblMaxCumBal" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            Account Description</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtacctdesc" runat="server" Font-Size="Small" Height="41px" 
                                                                TextMode="MultiLine" Width="132px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            Block View On Account?</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:CheckBox ID="chkview" runat="server" AutoPostBack="True" Text="Yes" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            Debit Interest (per annum)</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtdrint" runat="server" Font-Size="Small" Width="132px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            <asp:Label ID="Label15" runat="server" Text="Old Account Number" 
                                                                Visible="False"></asp:Label>
                                                        </td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtold" runat="server" Font-Size="Small" Width="132px" 
                                                                AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            <asp:Label ID="Label13" runat="server" Text="Staff ID" Visible="False"></asp:Label>
                                                        </td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtstaffID" runat="server" Font-Size="Small" Width="80px" 
                                                                AutoPostBack="True" Visible="False"></asp:TextBox>
                                                            <asp:Label ID="Label14" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            Credit Interest (per annum)</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtcrint" runat="server" Font-Size="Small" 
                                                                Width="132px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            <asp:Label ID="Label12" runat="server" Text="Sweep To Account" Visible="False"></asp:Label>
                                                        </td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtsweep" runat="server" AutoPostBack="True" Font-Size="Small" 
                                                                Width="132px" Visible="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 19px; width: 179px;">
                                                            OD&nbsp; Rate</td>
                                                        <td style="width: 119px; height: 19px">
                                                            <asp:TextBox ID="txtodamt" runat="server" AutoPostBack="True" Font-Size="Small" 
                                                                Width="132px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center;">
                                                            <asp:Button ID="Btnsubmit" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                                                Height="21px" Text="Submit" ValidationGroup="submit" Width="78px" />
                                                            <asp:Button ID="BtnReset" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                                                Height="21px" Text="Reset" Width="70px" />
                                                            <asp:Button ID="Btncancel" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                                                Height="21px" Text="Return" Width="66px" />
                                                            <asp:Button ID="BtnTarget" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                                                Height="21px" Text="Modify Target Account" Visible="False" Width="138px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 19px; text-align: center;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 5px;">
                                                            <h3>
                                                                Document&nbsp; Detail</h3>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 5px;">
                                                            <table style="width: 206px">
                                                                <tr>
                                                                    <th class="first" style="height: 29px">
                                                                        Account Openning Document Submitted</th>
                                                                </tr>
                                                                <tr class="row-a">
                                                                    <td class="first">
                                                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                                                            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                                                            CellPadding="4" Font-Size="XX-Small" ForeColor="Black" GridLines="Vertical" 
                                                                            SkinID="booksSkin" Width="313px">
                                                                            <FooterStyle BackColor="#CCCC99" />
                                                                            <RowStyle BackColor="#F7F7DE" />
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <HeaderTemplate>
                                                                                        <input ID="chkAll" runat="server" 
                                                                                            onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="Check1" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="docname" HeaderText="Document Description" 
                                                                                    SortExpression="docname">
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="LblDoc1" runat="server" Text='<%#Eval("reqid") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="docid" Visible="False" />
                                                                            </Columns>
                                                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                                            <AlternatingRowStyle BackColor="White" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr class="row-a" style="color: #0000ff">
                                                                    <td class="first" style="text-align: center">
                                                                        &nbsp;<asp:Button ID="Btnsave1" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                                                            Text="Remove" ValidationGroup="News" Width="68px" />
                                                                        <asp:Button ID="Btnreturn1" runat="server" BackColor="#C0C0FF" 
                                                                            Font-Size="Small" Text="Return" Width="63px" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 5px;">
                                                            <table style="width: 301px">
                                                                <tr>
                                                                    <th class="first" style="height: 29px">
                                                                        Account Openning Document Not Submitted</th>
                                                                </tr>
                                                                <tr class="row-a">
                                                                    <td class="first">
                                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                                                            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                                                            CellPadding="4" Font-Size="XX-Small" ForeColor="Black" GridLines="Vertical" 
                                                                            SkinID="booksSkin" Width="315px">
                                                                            <FooterStyle BackColor="#CCCC99" />
                                                                            <RowStyle BackColor="#F7F7DE" />
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <HeaderTemplate>
                                                                                        <input ID="chkAll0" runat="server" 
                                                                                            onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="Check2" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="docname" HeaderText="Document Description" 
                                                                                    SortExpression="docname">
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="LblDoc2" runat="server" Text='<%#Eval("reqid") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="docid" Visible="False" />
                                                                            </Columns>
                                                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                                            <AlternatingRowStyle BackColor="White" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr class="row-a" style="color: #0000ff">
                                                                    <td class="first" style="text-align: center">
                                                                        &nbsp;<asp:Button ID="Btnsave2" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                                                            Text="Add" ValidationGroup="News" Width="63px" />
                                                                        <asp:Button ID="btnreturn2" runat="server" BackColor="#C0C0FF" 
                                                                            Font-Size="Small" Text="Return" Width="63px" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td colspan="1" valign="top">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                &nbsp;&nbsp;
                                <br />
                                <br />
                            </asp:View>
                            &nbsp;
                        </asp:MultiView></td>
                </tr>
            </table>
        </div>
    </div>--%>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

