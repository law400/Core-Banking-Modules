<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false"   CodeFile="ManageAcct.aspx.vb" Inherits="CustomerService_ManageAcct" title="Manage Account Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <script src="template/js/jquery-1.11.1.min.js"></script>

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

    <div class="panel panel-default">
        <div class="panel-heading">

        </div>
<div class="panel-body">
    <div class="row">

          <div class="col-md-4">


               <div class="form-group" > 
                            <tr>
                                <td style="width: 974px">
                                    Account Number</td>
                                <td style="width: 100px">
                                    &nbsp;<asp:HyperLink ID="hypAccount" runat="server" Height="27px" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                                    <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" TabIndex="1" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>


               <div class="form-group" >
                            <tr>
                                <td style="width: 974px">
                                    Full Name</td>
                                <td style="width: 100px">
                                     <asp:TextBox ID="txtfullname" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" Height="41px" ReadOnly="True" TextMode="MultiLine"  CssClass="form-control"
                                        ></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>

               <div class="form-group" >
                            <tr>
                                <td style="width: 974px">
                                    Account Description</td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtacctdesc" runat="server" Font-Size="Small" Height="41px" 
                                        ReadOnly="True" TextMode="MultiLine" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>


               <div class="form-group" >
                            <tr>
                                <td >
                                    <asp:DropDownList ID="DrpAccountTier" runat="server" AutoPostBack="True" CssClass="form-control" Font-Size="Small" Visible="False">
                                    </asp:DropDownList>
                                </td>
                                
                            </tr>
                   <tr>
                                <td >
                       <asp:Label ID="LabelDepAmt" runat="server" ForeColor="#0000CC" 
                                        Text="Max Deposit Amt:" Visible="False"></asp:Label>
                                    &nbsp;<asp:Label ID="lblMaxDepAmt" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                   </td>
                                
                            </tr>
                    <tr>
                                <td >
                                    <br />
                                    <asp:Label ID="LabelMaxCum" runat="server" ForeColor="#0000CC" 
                                        Text="Max Cum Bal:" Visible="False"></asp:Label>
                                    &nbsp;<asp:Label ID="lblMaxCumBal" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                   </td>
                                
                            </tr>
                            </div>


                 <div class="form-group" >
                            <tr>
                                <td style="width: 974px">
                                    CR Interest Rate</td>
                                <td style="width: 100px">
                                    <telerik:RadNumericTextBox ID="txtCRInt" Runat="server" AutoPostBack="True" CssClass="form-control" EmptyMessage="0.00" Width="100%">
                            <NumberFormat DecimalDigits="2" GroupSeparator="" />
                        </telerik:RadNumericTextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>

                 <div class="form-group" >
                            <tr>
                            <td style="width: 974px">
                                    DR Interest Rate</td>
                                <td style="width: 100px">
                                      <telerik:RadNumericTextBox ID="txtDRint" Runat="server" AutoPostBack="True" CssClass="form-control" EmptyMessage="0.00" Width="100%">
                            <NumberFormat DecimalDigits="2" GroupSeparator="" />
                        </telerik:RadNumericTextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>



                <div class="form-group" >
                            <tr>
                            <td style="width: 974px">
                                    &nbsp;<td style="width: 100px">
                                        <asp:TextBox ID="txtOfficer" runat="server" AutoPostBack="True" CssClass="form-control" Font-Size="Small" TabIndex="1" Visible="False"></asp:TextBox>
                                        <asp:Label ID="Label21" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                    </td>
                                    <td style="width: 100px"></td>
                                </td>
                            </tr>
                            </div>

                <div class="form-group" >
                            <tr>
               <tr>
                                <td style="width: 100px">
                                    <asp:Label ID="Label23" runat="server" Text="Sweep To Account" Visible="False"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtsweep" runat="server" AutoPostBack="True" Font-Size="Small" 
                                        Visible="False" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
 </div>


              <tr>
                                <td style="width: 100px">
                                    Block View On Account?</td>
                                <td colspan="2">
                                    <asp:CheckBox ID="chkyesno" runat="server" Text="Yes" /></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Label ID="Label24" runat="server" Text="Staff ID" Visible="False"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtstaffID" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" Visible="False" Width="80px"></asp:TextBox>
                                    <asp:Label ID="Label25" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>






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


       <%--  <div class="col-md-3">
             
             </div>--%>


        <div class="col-md-3" style="background-color: #ccccff; font-size:11px; height: 100%;">
                           <div class="form-group" style="font-size: small"> 
                            <tr>
                                <td colspan="2" style="height: 22px; background-color: #FF9E0D">
                                    <span style="font-weight: bold; font-size: 12pt; color: #000099">Account Info</span></td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                    Account Name:&nbsp;</td>
                                <td style="width: 100px; height: 15px">
                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px">
                                    <span style="color: #000000">Product Name&nbsp;:&nbsp;</span></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px">
                                    <span style="color: #000000">Branch:<strong>&nbsp;</strong></span></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label3" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px">
                                    <span style="color: black">Book Balance:</span><strong style="font-weight: bold; color: black">&nbsp;</strong></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label4" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px; height: 18px">
                                    <span style="color: black">Effective Balance:&nbsp;</span></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label5" runat="server" ForeColor="Black" Width="126px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr style="color: #ffff00">
                                <td style="width: 222px; height: 18px">
                                    <span style="color: black">Usable Balance:</span><b style="font-weight: normal"></b></td>
                                <td style="width: 100px; height: 18px">
                                    </b>
                                    <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Source Type:</td>
                              
                                <td style="width: 100px; height: 18px"></td>
                               
                                <asp:Label ID="Label7" runat="server" ForeColor="Black" Width="240px"></asp:Label>
                              
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Source:</td>
                            
                                <td style="width: 100px; height: 18px"></td>
                              
                                <asp:Label ID="Label8" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                           
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Account Status:</td>
                              
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label9" runat="server" ForeColor="Black" Width="122px"></asp:Label>
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
                                    <asp:Label ID="Label10" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                </td>
                            </tr>
                            </div>
             <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                    Product Start Date:&nbsp;</td>
                                <td style="width: 100px; height: 15px">
                                    <asp:Label ID="Label11" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px">
                                    <span style="color: #000000">Product Expiry Date:</span></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label12" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                          
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px">
                                    <span style="color: black">Product Currency:</span><strong style="font-weight: bold; color: black">&nbsp;</strong></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label13" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 222px; height: 18px">
                                    <span style="color: black">Minimum Account Bal:&nbsp;</span></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label14" runat="server" ForeColor="Black" Width="126px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr style="color: #ffff00">
                                <td style="width: 222px; height: 18px">
                                    <span style="color: black">Product Type:</span><b style="font-weight: normal"></b></td>
                                <td style="width: 100px; height: 18px">
                                    </b>
                                    <asp:Label ID="Label15" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Opening Balance:</td>
                              
                                <td style="width: 100px; height: 18px"></td>
                               
                                <asp:Label ID="Label16" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                              
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Closing Balance:</td>
                            
                                <td style="width: 100px; height: 18px"></td>
                              
                                <asp:Label ID="Label17" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                           
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                   Minimum Interest:</td>
                              
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label18" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                </td>
                            </tr>
                            </div>
              <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Debit Interest:</td>
                              
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label19" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                </td>
                            </tr>
                            </div>

              <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Credit Interest:</td>
                              
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label20" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            
              <tr>
                    <td colspan="5" style="text-align: center">
                        <asp:Label ID="Label22" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                            
                        </div>

       <%-- <div class="col-md-3" style="background-color: #ccccff; font-size:11px; height: 407px;">
          
            </div>--%>
        </div>

    </div>
        <div class="panel-footer">
                    
                    <tr>
                        <td colspan="3" style="height: 18px; text-align: center">
                          
                             
                            <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Submit" 
                                ValidationGroup="News"  CssClass="btn bg-purple btn-flat margin"  />
                                
                            <asp:Button ID="btnReset" runat="server" BackColor="#C0C0FF"  Text="Reset" CssClass="btn bg-maroon btn-flat margin" />
                                
                           
                         
                            <br />
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                   
                </div>
    </div>
        </div>
<%--<div class="box-blue">
        <div class="content">
            &nbsp;
            <table border="2" bordercolor="#330099" style="width: 510px; height: 376px">
                <tr>
                    <td style="width: 100px">
            <table border="0" bordercolor="#0000cc" style="width: 332px; height: 102px;">
                <tr>
                    <td colspan="4" style="height: 236px; width: 346px;" valign="top">
                        &nbsp;<table style="width: 358px; height: 72px">
                            <tr>
                                <td style="width: 100px">
                        Account Number*</td>
                                <td colspan="2">
                        <asp:TextBox ID="txtAcNumber" runat="server" Width="169px" AutoPostBack="True" TabIndex="1" 
                                        Font-Size="Small" Height="20px"></asp:TextBox><asp:HyperLink
                                        ID="hypAccount" runat="server" Height="22px" 
                                        ImageUrl="~/Images/iconbar_previewtab_on.gif" Width="25px">HyperLink</asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Fullname</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtfullname" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" Height="41px" ReadOnly="True" TextMode="MultiLine" 
                                        Width="171px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Account Description</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtacctdesc" runat="server" Font-Size="Small" Height="41px" 
                                        ReadOnly="True" TextMode="MultiLine" Width="171px" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Select Account Tier</td>
                                <td colspan="2">
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
                                <td style="width: 100px">
                                    CR Interest Rate</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtCRInt" runat="server" AutoPostBack="True" Font-Size="Small"
                                        TabIndex="1" Width="171px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    DR Interest Rate</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtDRint" runat="server" AutoPostBack="True" Font-Size="Small"
                                        TabIndex="1" Width="170px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Account Officer Code</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtOfficer" runat="server" AutoPostBack="True" Font-Size="Small"
                                        TabIndex="1" Width="170px"></asp:TextBox>
                                    <asp:Label ID="Label21" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Label ID="Label23" runat="server" Text="Sweep To Account" Visible="False"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtsweep" runat="server" AutoPostBack="True" Font-Size="Small" 
                                        Visible="False" Width="132px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Block View On Account?</td>
                                <td colspan="2">
                                    <asp:CheckBox ID="chkyesno" runat="server" Text="Yes" /></td>d
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Label ID="Label24" runat="server" Text="Staff ID" Visible="False"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtstaffID" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" Visible="False" Width="80px"></asp:TextBox>
                                    <asp:Label ID="Label25" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="News" BackColor="#C0C0FF" /><asp:Button ID="btnReset" runat="server" Text="Reset" BackColor="#C0C0FF" /><asp:Button ID="btnReturn" runat="server" Text="Return" BackColor="#C0C0FF" /></td>
                            </tr>
                        </table>
                        &nbsp;
                        <table style="width: 206px">
                            <tr>
                                <th class="first" colspan="2" style="height: 29px">
                                    Account Openning Document Submitted</th>
                            </tr>
                            <tr class="row-a">
                                <td class="first" colspan="2">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="XX-Small"
                                        ForeColor="Black" GridLines="Vertical" SkinID="booksSkin" Width="313px">
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
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
                                    <asp:Button ID="Btnreturn1" runat="server" BackColor="#C0C0FF" Font-Size="Small"
                                        Text="Return" Width="63px" /></td>
                            </tr>
                        </table>
                        <table style="width: 301px">
                            <tr>
                                <th class="first" colspan="2" style="height: 29px">
                                    Account Openning Document Not Submitted</th>
                            </tr>
                            <tr class="row-a">
                                <td class="first" colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical" SkinID="booksSkin" Width="315px" Font-Size="XX-Small">
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <input id="chkAll" runat="server" onclick="javascript:SelectAllCheckboxes(this);"
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
                                    <asp:Button ID="btnreturn2" runat="server" BackColor="#C0C0FF" Font-Size="Small"
                                        Text="Return" Width="63px" /></td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="1" style="width: 9px; height: 236px; text-align: left" 
                        valign="top">
                    <table style="width: 330px; background-color: #ccccff; font-weight: bold;">
                            <tr>
                                <td colspan="2" style="height: 22px; background-color: #FF9E0D;">
                                    <span style="font-weight: bold; font-size: 12pt; color: #000099">Account Info</span></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 15px; font-weight: bold; color: black;">
                                    Account Name:&nbsp;</td>
                                <td style="width: 100px; height: 15px">
                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="124px"></asp:Label></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 222px">
                                    <span>Product Name &nbsp;:&nbsp;</span></td>
                                <td style="width: 100px; color: #808080;">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="128px"></asp:Label></td>
                            </tr>
                            <tr style="color: #000000">
                                <td style="width: 222px">
                                    <span>Branch:&nbsp;</span></td>
                                <td style="width: 100px; color: #000000;">
                                    <asp:Label ID="Label3" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 222px">
                                    Book Balance:&nbsp;</td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label4" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px">
                                    <strong style="font-weight: bold; color: black">Effective Balance:&nbsp;</strong></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label5" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px">
                                    <strong><span style="color: black; font-weight: bold;">Usable Balance:</span></strong></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px; font-weight: bold; color: black;">
                                    Source Type:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label7" runat="server" ForeColor="Black" Width="123px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px; font-weight: bold; color: black;">
                                    Source:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label8" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Account Status:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label9" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                            </tr>
                        </table>
                        <table style="width: 328px; background-color: #ccccff">
                            <tr>
                                <td colspan="2" style="height: 23px; background-color: #FF9E0D">
                                    <span style="font-weight: bold; font-size: 12pt; color: #000099">Product Info</span></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 307px; color: black; height: 15px">
                                    Product &nbsp;Name:&nbsp;</td>
                                <td style="width: 100px; height: 15px">
                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="#0000C0" Width="124px"></asp:Label></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 307px; height: 18px">
                                    <span style="color: #000000">Prodcut Start Date:</span></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="#0000C0" Width="128px"></asp:Label></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 307px">
                                    Product Expiry Date:&nbsp;</td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="#0000C0" Width="126px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 307px; height: 18px">
                                    <strong style="font-weight: bold; color: black">Product Currency:&nbsp;</strong></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="#0000C0" Width="125px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 307px; height: 18px">
                                    <strong><span style="font-weight: bold; color: black">Minimum Account Bal:</span></strong></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label14" runat="server" Font-Bold="True" ForeColor="#0000C0" Width="126px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 307px; color: black; height: 18px">
                                    Product Type:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label15" runat="server" Font-Bold="True" ForeColor="#0000C0" Width="125px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 307px; color: black; height: 18px">
                                    Opening Balance:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" ForeColor="#0000C0" Width="123px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 307px; color: black; height: 18px">
                                    Closing Balance:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="#0000C0" Width="122px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 307px; color: black; height: 18px">
                                    Minimum Interest:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label18" runat="server" Font-Bold="True" ForeColor="#0000C0" Width="122px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 307px; color: black; height: 18px">
                                    Debit Interest:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label19" runat="server" Font-Bold="True" ForeColor="#0000C0" Width="122px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 307px; color: black; height: 18px">
                                    Credit Interest:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label20" runat="server" Font-Bold="True" ForeColor="#0000C0" Width="122px"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align: center">
                        <asp:Label ID="Label22" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>--%>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

