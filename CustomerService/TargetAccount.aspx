<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="TargetAccount.aspx.vb" Inherits="CustomerService_TargetAccount" title="Untitled Page" %>

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
               <div class="form-group">
                   <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" 
                            Orientation="Horizontal" StaticEnableDefaultPopOutImage="False" Width="30%">
                            <Items>
                                <asp:MenuItem ImageUrl="~/Images/pic2.gif" Text="Add New" Value="0">
                                </asp:MenuItem>
                                <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="Edit" Value="1"></asp:MenuItem>
                                <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="List" Value="2"></asp:MenuItem>
                            </Items>
                        </asp:Menu>
                     <br />

                   </div>

<div class="box-body">
    <div class="row">

          <div class="col-md-5">


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
                                        Font-Size="Small" TabIndex="2" Height="41px" ReadOnly="True" TextMode="MultiLine"  CssClass="form-control"
                                        ></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>


               <div class="form-group" >
              <tr>
                                <td style="width: 100px">
                                    First Charge Day (i.e 1,2,3 -31)</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtFirstpay" runat="server" AutoPostBack="True" Font-Size="Small"
                                        TabIndex="4"  CssClass="form-control"></asp:TextBox></td>
                            </tr>
                    </div>

               <div class="form-group" >

                   <tr>
                                <td style="width: 100px">
                                    Charge Amount</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtChg" runat="server" AutoPostBack="True" Font-Size="Small"
                                        TabIndex="5" CssClass="form-control"></asp:TextBox>
                                    <br />
                                    -(Monthly Deductions)</td>
                            </tr>

                   </div>

              <div class="form-group" >

                   <tr>
                                <td style="width: 100px">
                                    Accumulated Target Balance(customer Balance)</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtbalance" runat="server" AutoPostBack="True" 
                                        TabIndex="6" Font-Size="Small"  CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                  </div>

                 <div class="form-group" >
                      <tr>
                                <td style="width: 100px">
                                    Status</td>
                                <td colspan="2">
                                    <asp:DropDownList ID="DrpStatus" runat="server" AutoPostBack="True" CssClass="form-control" >
                                        <asp:ListItem Selected="True" Value="0">--Choose a Status--</asp:ListItem>
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="3">Close</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>

                     </div>

              </div>

        <div class="col-md-5" style="background-color: #ccccff; font-size:11px; height: 100%;">
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

        </div>


       <div class="box-footer">

           <div class="col-md-6"> 
                            <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Submit" 
                                ValidationGroup="News" Width="100%" CssClass="btn bg-purple btn-flat margin"  />
                                  </div>
                              <div class="col-md-6"> 
                            <asp:Button ID="btnReset" runat="server" BackColor="#C0C0FF" Width="100%" Text="Reset" CssClass="btn bg-maroon btn-flat margin" />
                                  </div>
                            <%-- <div class="col-md-1"> 
                                 <asp:Button ID="btnReturn" runat="server" Text="Return" BackColor="#C0C0FF" CssClass="btn bg-maroon btn-flat margin"/> 
                                 </div>  --%>
           </div>

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
                        &nbsp;<asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" 
                            Orientation="Horizontal" StaticEnableDefaultPopOutImage="False" Width="183px">
                            <Items>
                                <asp:MenuItem ImageUrl="~/Images/pic2.gif" Text="Add New" Value="0">
                                </asp:MenuItem>
                                <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="Edit" Value="1"></asp:MenuItem>
                                <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="List" Value="2"></asp:MenuItem>
                            </Items>
                        </asp:Menu>
                        <table style="width: 358px; height: 72px">
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
                                    First Charge Day (i.e 1,2,3 -31)</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtFirstpay" runat="server" AutoPostBack="True" Font-Size="Small"
                                        TabIndex="1" Width="171px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Charge Amount</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtChg" runat="server" AutoPostBack="True" Font-Size="Small"
                                        TabIndex="1" Width="170px" Height="22px"></asp:TextBox>
                                    <br />
                                    -(Monthly Deductions)</td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Accumulated Target Balance(customer Balance)</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtbalance" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" Width="169px" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Status</td>
                                <td colspan="2">
                                    <asp:DropDownList ID="DrpStatus" runat="server" AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="0">--Choose a Status--</asp:ListItem>
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="3">Close</asp:ListItem>
                                    </asp:DropDownList>
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
                        &nbsp;</td>
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


