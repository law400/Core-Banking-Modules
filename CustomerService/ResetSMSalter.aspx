<%@ Page Title="" Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="ResetSMSalter.aspx.vb" Inherits="CustomerService_ResetSMSalter" %>

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

           <div class="box-body">
    <div class="row">

        <div class="form-group">
             <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover dataTable" Font-Size="Small" PageSize="1" Width="100%">
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                <Columns>
                    <asp:TemplateField HeaderText="Account Mandate">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl='<%# "Handler.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber") %>' Width="200px" />
                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# "Handler2.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber")  %>' />
                        </ItemTemplate>
                        <HeaderStyle ForeColor="#0000CC" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Account Signatory">
                        <ItemTemplate>
                            <asp:Literal ID="Literal1" runat="server" Text='<%# "Signatory :" + Eval("signatoryname") %>'></asp:Literal>
                            <br />
                            <asp:Literal ID="Literal2" runat="server" Text='<%# "Designatiton :" + Eval("designation") %>'></asp:Literal>
                            <br />
                            <asp:Literal ID="Literal3" runat="server" Text='<%# "Mandate Instruction :" + Eval("mandatedesc1") %>'></asp:Literal>
                            <br />
                        </ItemTemplate>
                        <HeaderStyle ForeColor="#0000CC" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                 </asp:Panel> 
            </div>
        
        <div class="col-md-6">
                           <div class="form-group" style="font-size: small"> 
                            <tr>
                                <td style="width: 974px">
                                    Account Number*</td>
                                <td style="width: 100px">
                                    &nbsp;
                                    <asp:HyperLink ID="hypAccount" runat="server" Height="27px" ImageUrl="~/Images/iconbar_previewtab_on.gif" Visible="True">HyperLink</asp:HyperLink>
                                    <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" TabIndex="1" CssClass="form-control"></asp:TextBox>
                                </td>
                               
                            </tr>
                            </div>
                            
                            <div class="form-group" >
                            <tr>
                                <td style="width: 974px">
                                    Value Date*</td>
                                <td style="width: 100px">
                                    <asp:HyperLink ID="hypValueDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink>
                                    <asp:TextBox ID="txtValueDate" runat="server" Font-Size="Small" TabIndex="2" 
                                         CssClass="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 974px">
                                    Alert Option</td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="form-control">
                                                    <asp:ListItem Selected="True" Value="0">Choose an Option</asp:ListItem>
                                                    <asp:ListItem Value="S">Suspend SMS Alert</asp:ListItem>
                                                    <asp:ListItem Value="R">Reactivate SMS Alert</asp:ListItem>
                                                </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>
                            
                            
                        </div>


         <div class="col-md-5" style="background-color: #ccccff; font-size:11px; height:100%;">
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
                                    <span style="color: #000000">Product Name &nbsp;:&nbsp;</span></td>
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
                                </strong><strong>
                                <td style="width: 100px; height: 18px"></td>
                                </strong>
                                <asp:Label ID="Label7" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                <td>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group">
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Source:</td>
                                </strong><strong>
                                <td style="width: 100px; height: 18px"></td>
                                </strong>
                                <asp:Label ID="Label8" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                <td>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Account Status:</td>
                                </strong>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label9" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Dr Interest:</td>
                                </strong>:
                                <td style="width: 100px; height: 18px">
                                    <span style="color: #000000">
                                    <asp:Label ID="Label10" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            </div>

             <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Cr Interest:</td>
                                </strong>:
                                <td style="width: 100px; height: 18px">
                                    <span style="color: #000000">
                                    <asp:Label ID="Label11" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            </div>

             <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Pending Charges:</td>
                                </strong>:                                <td style="width: 100px; height: 18px">
                                    <span style="color: #000000">
                                    <asp:Label ID="Label12" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            </div>

             


                            
                            
                        </div>


        </div>

    </div>

           <div class="box-footer">


           
                               
                                     <div class="col-md-6"> 
                                    <asp:Button ID="Btnsubmit" runat="server" BackColor="#C0C0FF" Width="100%" Text="Submit" ValidationGroup="News" CssClass="btn bg-purple btn-flat margin" />
                                   </div>
                                     <div class="col-md-6"> 
                                          <asp:Button
                                        ID="btnReset" runat="server" BackColor="#C0C0FF" Width="100%" Text="Reset" CssClass="btn bg-maroon btn-flat margin" />
                                         </div>
                                   
           </div>
           </div>

<%--<div class="box-blue">
        <div class="content">
            <table border="2" bordercolor="#330099">
                <tr>
                    <td style="width: 100px">
                        <table border="0" bordercolor="#0000cc" style="width: 573px; height: 422px">
                            <tr>
                                <td colspan="2" valign="bottom">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" Font-Size="Small" PageSize="1" Width="357px">
                                        <PagerSettings FirstPageText="First" LastPageText="Last" 
                                            Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" 
                                                        ImageUrl='<%# "Handler.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber") %>' />
                                                    <asp:Image ID="Image2" runat="server" 
                                                        ImageUrl='<%# "Handler2.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber")  %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Literal ID="Literal1" runat="server" 
                                                        Text='<%# "Signatory :" + Eval("signatoryname") %>'></asp:Literal>
                                                    <br />
                                                    <asp:Literal ID="Literal2" runat="server" 
                                                        Text='<%# "Designatiton :" + Eval("designation") %>'></asp:Literal>
                                                    <br />
                                                    <asp:Literal ID="Literal3" runat="server" 
                                                        Text='<%# "Mandate Instruction :" + Eval("mandatedesc1") %>'></asp:Literal>
                                                    <br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    &nbsp;
                                    <table style="width: 371px">
                                        <tr>
                                            <th class="first" style="width: 136px; height: 29px">
                                                Account Number*</th>
                                            <th style="width: 274px; height: 29px">
                                                <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" Font-Size="X-Small"
                                                    TabIndex="1" Width="154px"></asp:TextBox>
                                                <asp:HyperLink ID="hypAccount" runat="server" Height="16px" 
                                                    ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></th>
                                        </tr>
                                        <tr class="row-a">
                                            <td class="first" style="width: 136px">
                                                Value Date*</td>
                                            <td style="width: 274px">
                                                <asp:TextBox ID="txtValueDate" runat="server" Font-Size="X-Small" TabIndex="2" 
                                                    Width="151px"></asp:TextBox>
                                                <asp:HyperLink ID="hypValueDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink></td>
                                        </tr>
                                        <tr class="row-a">
                                            <td class="first" style="width: 136px">
                                                Alert option</td>
                                            <td style="width: 274px">
                                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                                                    <asp:ListItem Selected="True" Value="0">Choose an Option</asp:ListItem>
                                                    <asp:ListItem Value="S">Suspend SMS Alert</asp:ListItem>
                                                    <asp:ListItem Value="R">Reactivate SMS Alert</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left" style="width: 100px" valign="bottom">
                                    &nbsp;<table style="width: 284px; background-color: #ccccff">
                                        <tr>
                                            <td colspan="2" style="height: 22px; background-color: #FF9E0D;">
                                                <span style="font-weight: bold; font-size: 12pt; color: #000099">Account Info</span></td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                                Account Name:&nbsp;</td>
                                            <td style="width: 100px; height: 15px">
                                                <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="124px"></asp:Label></td>
                                        </tr>
                                        <tr style="font-weight: bold; color: #000000">
                                            <td style="width: 222px">
                                                <span style="color: #000000">Product Name &nbsp;:&nbsp;</span></td>
                                            <td style="width: 100px">
                                                <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="128px"></asp:Label></td>
                                        </tr>
                                        <tr style="color: #000000">
                                            <td style="width: 222px">
                                                <span style="color: #000000"><strong style="font-weight: bold; color: black">Branch:&nbsp;</strong></span></td>
                                            <td style="width: 100px">
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
                                        <tr style="font-weight: bold; color: #ffff00">
                                            <td style="width: 222px; height: 18px">
                                                <span style="font-weight: bold; color: black">Usable Balance:</span></td>
                                            <td style="width: 100px; color: #ffffff; height: 18px">
                                                <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                <span>Source Type:</span></td>
                                            <td style="width: 100px; height: 18px">
                                                <asp:Label ID="Label7" runat="server" ForeColor="Black" Width="123px"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
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
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                        Dr Interest:</td>
                                            <td style="width: 100px; height: 18px">
                                                <asp:Label ID="Label10" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                        Cr Interest:</td>
                                            <td style="width: 100px; height: 18px">
                                                <asp:Label ID="Label11" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                        Pending Charges:</td>
                                            <td style="width: 100px; height: 18px">
                                                <asp:Label ID="Label12" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 18px" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 18px; text-align: center">
                                    <asp:Button ID="Btnsubmit" runat="server" BackColor="#C0C0FF" Text="Submit" ValidationGroup="News" /><asp:Button
                                        ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" /><asp:Button ID="btnReturn"
                                            runat="server" BackColor="#C0C0FF" Text="Return" /></td>
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

