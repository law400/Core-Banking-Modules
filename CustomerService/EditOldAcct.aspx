<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="EditOldAcct.aspx.vb" Inherits="CustomerService_EditOldAcct" title="Edit Old Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel1" runat="server">
<ContentTemplate>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel1">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.5;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>
<div class="box box-info">
<div class="box-body">
    <div class="row">

         <div class="col-md-6">
                           <div class="form-group"> 
                            <tr>
                                <td style="width: 974px">
                                    New Account Number*</td>
                                <td style="width: 100px">
                                    &nbsp;
                                    <asp:HyperLink ID="hypsearch" runat="server" Height="27px" ImageUrl="~/Images/iconbar_previewtab_on.gif" Visible="True">HyperLink</asp:HyperLink>
                                    <asp:TextBox ID="txtaccountnumber" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" TabIndex="1" CssClass="form-control"></asp:TextBox>
                                </td>
                               
                            </tr>
                            </div>


             <div class="form-group"> 
                            <tr>
                                <td style="width: 974px">
                                    Old Account Number</td>
                                <td style="width: 100px">
                                   
                                    <asp:TextBox ID="txtaccountnumber0" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" TabIndex="2" CssClass="form-control"></asp:TextBox>
                                </td>
                               
                            </tr>

                 <tr>
                                <td style="width: 558px; height: 23px;">
                                    <asp:Label ID="Label22" runat="server" Height="22px" Visible="False" 
                                        Width="112px"></asp:Label>
                                </td>

                     </tr>
                            </div>




             </div>



        <div class="col-md-5" style="background-color: #ccccff; font-size:11px; height:100%">
                           <div class="form-group" style="font-size: small"> 
                            <tr>
                                <td colspan="2" style="height: 22px; background-color: #FF9E0D">
                                    <span style="font-weight: bold; font-size: 12pt; color: #000099">Account Info</span></td>
                            </tr>
                            </div>

             <div class="form-group" >
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                    Account Number:&nbsp;</td>
                                <td style="width: 100px; height: 15px">
                                    <asp:Label ID="Label21" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                </td>
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
                               
                                <td style="width: 100px; height: 18px"></td>
                                
                                <asp:Label ID="Label8" runat="server" ForeColor="Black" Width="200px"></asp:Label>
                                <td>
                                </td>
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
                           


                            
                            
                        </div>


        </div>

    <div class="box-footer">
        <tr>
                    <td colspan="2" style="height: 18px; text-align: center">
                        <asp:ObjectDataSource ID="Smartobj1" runat="server" SelectMethod="SqlDs" 
                            TypeName="smartcon">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Select id,a.accountnumber,AccountTitle,Amount,chargedesc charges,case a.status when 0 then 'Newly Created' when 1 then 'Available' else 'Closed' end as Status  from tbl_chargeConc a,tbl_charges b,tbl_casaaccount c where a.chargetype=b.chargecode and a.accountnumber=c.accountnumber" 
                                    Name="SqlString" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>

             <tr>
                                <td colspan="3" style="height: 18px; text-align: center">
                                     <div class="col-md-6"> 
                                    <asp:Button ID="Btnsubmit" runat="server" BackColor="#C0C0FF" Text="Submit" Width="100%" ValidationGroup="News" CssClass="btn bg-purple btn-flat margin" />
                                   </div>
                                     <div class="col-md-6"> 
                                          <asp:Button
                                        ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" Width="100%" CssClass="btn bg-maroon btn-flat margin" />
                                         </div>
                                    </td>
                            </tr>

           </div>


                            
</div>

    <%--<table style="width: 97%; border: 2px solid #0000FF">
        <tr>
            <td>
                <table border="0" bordercolor="#0000cc" style="width: 573px; height: 82px;">
                <tr>
                    <td valign="bottom">
                        <table style="width: 331px; height: 1px;">
                            <tr>
                                <td style="width: 558px; height: 23px;">
                                    New Account Number*</td>
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
                                    Old Account Number</td>
                                <td colspan="2" style="height: 23px;">
                                    <asp:TextBox ID="txtaccountnumber0" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" TabIndex="4" Width="131px"></asp:TextBox>
                                </td>
                                <td style="width: 688px; height: 23px;">
                                    &nbsp;</td>
                                <td style="width: 100px; height: 23px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 558px; height: 23px;">
                                    <asp:Label ID="Label22" runat="server" Height="22px" Visible="False" 
                                        Width="112px"></asp:Label>
                                </td>
                                <td colspan="2" style="height: 23px;">
                                    &nbsp;</td>
                                <td style="width: 688px; height: 23px;">
                                    &nbsp;</td>
                                <td style="width: 100px; height: 23px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 558px; height: 6px;">
                                    &nbsp;</td>
                                <td style="width: 193px; height: 6px;">
                                    &nbsp;</td>
                                <td style="width: 5963px; height: 6px">
                                    &nbsp;</td>
                                <td style="width: 688px; height: 6px;">
                                    &nbsp;</td>
                                <td style="width: 100px; height: 6px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 558px; height: 18px">
                                    &nbsp;</td>
                                <td colspan="4" style="height: 18px">
                                    <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Submit" 
                                        ValidationGroup="News" />
                                    <asp:Button ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" />
                                    <asp:Button ID="btnReturn" runat="server" BackColor="#C0C0FF" Text="Return" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" style="width: 100px;" valign="top">
                        <table style="width: 265px; background-color: #ccccff; font-weight: bold;">
                            <tr>
                                <td colspan="2" style="height: 22px; background-color: #FF9E0D">
                                    <span style="font-weight: bold; font-size: 12pt; color: #000099">Account Info</span></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                    Account Number:</td>
                                <td style="width: 100px; height: 15px">
                                    <asp:Label ID="Label21" runat="server" ForeColor="Black" Width="124px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                    Account Name:&nbsp;</td>
                                <td style="width: 100px; height: 15px">
                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="124px"></asp:Label>
                                </td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 222px">
                                    <span style="color: #000000">Product Name &nbsp;:&nbsp;</span></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="128px"></asp:Label>
                                </td>
                            </tr>
                            <tr style="color: #000000">
                                <td style="width: 222px">
                                    <span style="color: #000000"><strong style="font-weight: bold; color: black">
                                    Branch:&nbsp;</strong></span></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label3" runat="server" ForeColor="Black" Width="126px"></asp:Label>
                                </td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 222px">
                                    Book Balance:&nbsp;</td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label4" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px">
                                    <strong style="font-weight: bold; color: black">Effective Balance:&nbsp;</strong></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label5" runat="server" ForeColor="Black" Width="126px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px">
                                    <strong><span style="font-weight: bold; color: black">Usable Balance:</span></strong></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Source Type:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label7" runat="server" ForeColor="Black" Width="123px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Source:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label8" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                    Account Status:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label9" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 18px; text-align: center">
                        <asp:ObjectDataSource ID="Smartobj1" runat="server" SelectMethod="SqlDs" 
                            TypeName="smartcon">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Select id,a.accountnumber,AccountTitle,Amount,chargedesc charges,case a.status when 0 then 'Newly Created' when 1 then 'Available' else 'Closed' end as Status  from tbl_chargeConc a,tbl_charges b,tbl_casaaccount c where a.chargetype=b.chargecode and a.accountnumber=c.accountnumber" 
                                    Name="SqlString" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table></td>
        </tr>
    </table>--%>
<%--<div class="box-blue">
        <div class="content">
          
            
        </div>
    </div>--%>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>


