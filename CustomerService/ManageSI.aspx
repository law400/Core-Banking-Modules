<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"    AutoEventWireup="false"   CodeFile="ManageSI.aspx.vb" Inherits="CustomerService_ManageSI" title="ManageSI Page" %>

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
          <div class="form-group">
              <br />
         <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal"
                            StaticEnableDefaultPopOutImage="False" Width="30%">
                            <Items>
                                <asp:MenuItem ImageUrl="~/Images/pic2.gif" Text="Add SI" Value="0"></asp:MenuItem>
                                <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="Remove SI" Value="1"></asp:MenuItem>
                            </Items>
                        </asp:Menu>
              
            <br/>
              </div>

<div class="box-body">
   

        <div class="col-md-4">
                                    <div class="form-group"  >
                                        <tr>
                                            <td style="width: 974px">
                                                <span>From Account Number<span style="color: #FF0000"><strong>*</strong></span></span><span style="color: #FF0000"><strong></strong></span></td>
                                            </strong></span>
                                            <td style="width: 100px; color: #ffff00">
                                                &nbsp;
                                                <asp:HyperLink ID="hypAccount" runat="server" Height="25px" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                                                <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" Font-Size="Small"
                                                    TabIndex="1" CssClass="form-control"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px">
                                                </td>
                                        </tr>
                                        </div>

             <div class="form-group"  >
                                        <tr>
                                            <td style="width: 974px">
                                                To Account Number<span style="color: #FF0000"><strong>*</strong></span></td>
                                            </strong></span>
                                            <td style="width: 100px">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:HyperLink ID="HyperLink2" runat="server" Height="25px" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                                                <asp:TextBox ID="txtAccountNo2" runat="server" AutoPostBack="True" Font-Size="Small"
                                                    TabIndex="2" CssClass="form-control"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px">
                                                </td>
                                        </tr>
                                        </div>

            <div class="form-group"  >
                                        <tr>
                                            <td style="width: 974px">
                                                Start Date<span style="color: #FF0000"><strong>*</strong></span></td>
                                            </strong></span>
                                            <td style="width: 100px">
                                                <asp:HyperLink ID="hypValueDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink>
                                                <asp:TextBox ID="txtStartdate" runat="server" Font-Size="Small" TabIndex="3" CssClass="form-control"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px">
                                                </td>
                                        </tr>
                                        </div>


             <div class="form-group"  >
                                        <tr>
                                            <td style="width: 974px">
                                                End Date<span style="color: #FF0000"><strong>*</strong></span></td>
                                            </strong></span>
                                            <td style="width: 100px">
                                                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink>
                                                <asp:TextBox ID="txtEnddate" runat="server" Font-Size="Small" TabIndex="4" CssClass="form-control"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px">
                                                </td>
                                        </tr>
                                        </div>
                            <div class="form-group"  >           
                             <tr>
                                                    <td colspan="3">
                                                        <asp:RadioButtonList ID="RDList" runat="server" AutoPostBack="True" TabIndex="5" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1">Specific Amount</asp:ListItem>
                                                            <asp:ListItem Value="2">Floor Amount</asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>       
                                
                                  </div>  
            
            <div class="form-group"  >
                                        <tr>
                                            <td style="width: 974px">
                                                SI Amount<span style="color: #FF0000"><strong>*</strong></span></td>
                                            </strong></span>
                                            <td style="width: 100px">
                                                &nbsp;
                                                
                                                <asp:TextBox ID="txtPayAmount" runat="server" AutoPostBack="True" TabIndex="6" CssClass="form-control"></asp:TextBox></td>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  > 
                                            <tr>
                                                    <td style="width: 974px">
                                                        Frequency<span style="color: #FF0000"><strong>*</strong></span></td>
                                                    </strong></span>
                                                    <td style="width: 100px">
                                                        <asp:DropDownList ID="DDaccrualfreq" runat="server" TabIndex="7" AutoPostBack="True" CssClass="form-control">
                                                        </asp:DropDownList></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>


                                            </div>
             <div class="form-group"  > 

             <tr>
                                                    <td style="width: 974px">
                        Seq No</td>
                                                    <td style="width: 100px">
                                                        <asp:DropDownList ID="DrpSerial" runat="server" AutoPostBack="True" Visible="False" CssClass="form-control">
                                                        </asp:DropDownList><asp:TextBox ID="txtSeqNo" runat="server" TabIndex="8" Font-Size="Small" ReadOnly="True"
                                                            CssClass="form-control"></asp:TextBox></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>

                  </div>

             <div class="form-group"  > 
             <tr>
                                                    <td style="width: 974px">
                                                        Narration<span style="color: #FF0000"><strong>*</strong></span></td>
                                                    </strong></span>
                                                    <td style="width: 100px">
                                                        <asp:TextBox ID="txtNaration" runat="server" Height="53px" TabIndex="9" TextMode="MultiLine"
                                                             CssClass="form-control"></asp:TextBox></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                  </div>

            </div>

        <div class="col-md-3" style=" color: #000000; background-color: #ccccff; font-size:11px; height: 420px;">
                    <div class="form-group" style="font-size: small"> 
                                        <tr>
                                            <td colspan="2" style="height: 23px; background-color: #FF9E0D;">
                                                <span style="font-weight: bold; font-size: 12pt; color: #000099">From Account Info</span></td>
                                        </tr>
                                </div>
                                <div class="form-group"  >
                                        <tr style="color: #000000">
                                            <td style=" width: 222px; color: black; height: 15px">
                                                <span style="color: #000000">Account Name:&nbsp;</span></td>
                                            <td style="width: 100px; color: #003399; height: 15px">
                                                <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="160px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr style="color: #000000">
                                            <td style="width: 222px">
                                                <span style="color: #000000">Product Name:&nbsp;</span></td>
                                            <td style="width: 100px">
                                                <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="160px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr style="color: #003399">
                                            <td style="width: 222px">
                                                <span style="color: #000000">Branch:&nbsp;</span></td>
                                            <td style="width: 100px; color: #003399">
                                                <asp:Label ID="Label3" runat="server" ForeColor="Black" Width="160px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="width: 222px">
                                                <span style="color: #000000">Book Balance:&nbsp;</span></td>
                                            <td style="width: 100px; color: #000000">
                                                <asp:Label ID="Label4" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="width: 222px; height: 18px">
                                                <span style="color: #000000">Effective Balance:&nbsp;</span></td>
                                            <td style="width: 100px; color: #000000; height: 18px">
                                                <asp:Label ID="Label5" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="width: 222px; height: 18px">
                                                <span>Usable Balance:</span></td>
                                            <td style="width: 100px; color: #ffff00; height: 18px">
                                                <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr style="color: #ffff00">
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                <span>Source Type:</span></td>
                                            <td style="width: 100px; color: #ffffff; height: 18px">
                                                <asp:Label ID="Label7" runat="server" ForeColor="Black" Width="123px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                <span>Source:</span></td>
                                            <td style="width: 100px; color: #ffffff; height: 18px">
                                                <asp:Label ID="Label8" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                <span>Account Status:</span></td>
                                            <td style="width: 100px; color: #ffffff; height: 18px">
                                                <asp:Label ID="Label9" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                Total Charge:</td>
                                            <td style="width: 100px; color: #ffffff; height: 18px">
                                                <asp:Label ID="Label20" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                            </td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                &nbsp;</td>
                                            <td style="width: 100px; color: #ffffff; height: 18px">
                                                <asp:HyperLink ID="LnkCharge" runat="server" Visible="False">View Charge Detail</asp:HyperLink>
                                            </td>
                                        </tr>
                                        </div>
                                    </div>

        <div class="col-md-2" style="background-color: #ccccff; font-size:11px; height: 420px;">
                <div class="form-group" >
                                        <tr>
                                            <td colspan="2" style="height: 23px; background-color: #FF9E0D;">
                                                <span style="font-weight: bold; font-size: 12pt; color: #000099">Payment Info</span></td>
                                        </tr>
                                        </div>
                                        <div class="form-group" >
                                        <tr style="color: #000000">
                                            <td style="width: 79px; height: 15px">
                                                <span style=" color: #000000">Currency</span></td>
                                            <td style="width: 100px; color: #000000; height: 15px">
                                                <asp:DropDownList ID="drpCurrency" runat="server" CssClass="form-control" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                        </tr>
                                        </div>
                                        <div class="form-group" >
                                        <tr>
                                            <td style="width: 79px">
                                                <span style=" color: #000000">Rate</span></td>
                                            <td style="width: 100px; color: #000000">
                                                <asp:TextBox ID="txtRate" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox></td>
                                        </tr>
                                        </div>
                                        <div class="form-group" >
                                        <tr style="color: #000000">
                                            <td style="width: 79px">
                                                <span>Tran Amount</span></td>
                                            <td style="width: 100px; color: #000000">
                                                <asp:TextBox ID="txtTransAmount" runat="server" Font-Size="Small" ReadOnly="True"
                                                     CssClass="form-control"></asp:TextBox></td>
                                        </tr>
                                        </div>
                                        <div class="form-group" >
                                         <tr style="color: #003399">
                                                    <td style="width: 79px">
                                                        SI Default Amount</td>
                                                    <td style="width: 100px; color: #808080">
                                                        <asp:TextBox ID="txtSI" runat="server" Font-Size="Small" ReadOnly="True" 
                                                            Width="97px" CssClass="form-control"></asp:TextBox>
                                                    </td>
                                                </tr>
                                        </div>
        </div>

         <div class="col-md-3" style="background-color: #ccccff; font-size: 11px; top: 0px; left: 0px; height: 420px;">
			                <div class="form-group">
                                        <tr>
                                            <td colspan="2" style="height: 22px; background-color: #FF9E0D;">
                                                <span style="font-weight: bold; font-size: 12pt; color: #000099">To Account Info</span></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr style="color: #000000">
                                            <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                                <span style="color: #000000">Account Name:&nbsp;</span></td>
                                            <td style="width: 100px; color: #003399; height: 15px">
                                                <asp:Label ID="Label10" runat="server" ForeColor="Black" Width="160px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr style="color: #000000">
                                            <td style="width: 222px">
                                                <span style="color: #000000">Product Name &nbsp;:&nbsp;</span></td>
                                            <td style="width: 100px">
                                                <asp:Label ID="Label11" runat="server" ForeColor="Black" Width="160px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr style="color: #000000">
                                            <td style="width: 222px">
                                                <span>Branch:&nbsp;</span></td>
                                            <td style="width: 100px; color: #ffffff">
                                                <asp:Label ID="Label12" runat="server" ForeColor="Black" Width="160px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="width: 222px">
                                                <span style="color: #000000">Book Balance:&nbsp;</span></td>
                                            <td style="width: 100px; color: #000000">
                                                <asp:Label ID="Label13" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="width: 222px; height: 18px">
                                                <span>Effective Balance:&nbsp;</span></td>
                                            <td style="width: 100px; color: #ffffff; height: 18px">
                                                <asp:Label ID="Label14" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="width: 222px; height: 18px">
                                                <span>Usable Balance:</span></td>
                                            <td style="width: 100px; color: #ffff00; height: 18px">
                                                <asp:Label ID="Label15" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                <span>Source Type:</span></td>
                                            <td style="width: 100px; color: #ffff00; height: 18px">
                                                <asp:Label ID="Label16" runat="server" ForeColor="Black" Width="123px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                <span>Source:</span></td>
                                            <td style="width: 100px; color: #ffffff; height: 18px">
                                                <asp:Label ID="Label17" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                <span>Account Status:</span></td>
                                            <td style="width: 100px; color: #ffffff; height: 18px">
                                                <asp:Label ID="Label18" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                        </tr>
                                        </div>
                                        <div class="form-group">
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                Total Charge:</td>
                                            <td style="width: 100px; color: #ffffff; height: 18px">
                                                <asp:Label ID="Label19" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                            </td>
                                        </tr>
                                        </div>
                                        <div class="form-group"  >
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                &nbsp;</td>
                                            <td style="width: 100px; color: #ffffff; height: 18px">
                                                <asp:HyperLink ID="LnkCharge2" runat="server" Visible="False">View Charge Detail</asp:HyperLink>
                                            </td>
                                        </tr>
                                        </div>
                                    </div>
            </div>

    </div>   
              <div class="panel-footer">
                   
          <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Submit" ValidationGroup="News"  CssClass="btn bg-purple btn-flat margin"  />
                                          
                                           <asp:Button
                                        ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset"   CssClass="btn bg-maroon btn-flat margin" />
                                        
         </div>

         </div>
                                      
<%--<div class="box-blue">
        <div class="content">
            <div class="box-blue">
                <p>
                    <span style="color: yellow"><strong>
                        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal"
                            StaticEnableDefaultPopOutImage="False" Width="162px">
                            <Items>
                                <asp:MenuItem ImageUrl="~/Images/pic2.gif" Text="Add SI" Value="0"></asp:MenuItem>
                                <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="Remove SI" Value="1"></asp:MenuItem>
                            </Items>
                        </asp:Menu>
                    </strong></span>&nbsp;</p>
                <div class="content">
                    <table border="2" bordercolor="#330099">
                        <tr>
                            <td style="width: 100px">
                                <table border="0" bordercolor="#0000cc" style="width: 573px; height: 422px">
                                    <tr>
                                        <td colspan="1" valign="top">
                                            &nbsp;<table style="font-weight: bold; width: 241px; color: #000000; background-color: #ccccff">
                                                <tr>
                                                    <td colspan="2" style="height: 23px; background-color: #FF9E0D">
                                                        <span style="font-weight: bold; font-size: 12pt; color: #000099">From Account Info</span></td>
                                                </tr>
                                                <tr style="color: #000000">
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                                        <span style="color: #000000">Account Name:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #003399; height: 15px">
                                                        <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="124px"></asp:Label></td>
                                                </tr>
                                                <tr style="color: #000000">
                                                    <td style="width: 222px">
                                                        <span style="color: #000000">Product Name &nbsp;:&nbsp;</span></td>
                                                    <td style="width: 100px">
                                                        <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="124px"></asp:Label></td>
                                                </tr>
                                                <tr style="color: #003399">
                                                    <td style="width: 222px">
                                                        <span style="color: #000000">Branch:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #003399">
                                                        <asp:Label ID="Label3" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 222px">
                                                        <span style="color: #000000">Book Balance:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #003399">
                                                        <asp:Label ID="Label4" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 222px; height: 18px">
                                                        <span style="color: #000000">Effective Balance:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #000000; height: 18px">
                                                        <asp:Label ID="Label5" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 222px; height: 18px">
                                                        <span>Usable Balance:</span></td>
                                                    <td style="width: 100px; color: #ffff00; height: 18px">
                                                        <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                                </tr>
                                                <tr style="color: #ffff00">
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        <span style="color: #000000">Source Type:</span></td>
                                                    <td style="width: 100px; color: #003399; height: 18px">
                                                        <asp:Label ID="Label7" runat="server" ForeColor="Black" Width="123px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        <span>Source:</span></td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:Label ID="Label8" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        <span>Account Status:</span></td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:Label ID="Label9" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td colspan="2" valign="top">
                                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<table style="width: 330px; background-color: #ccccff">
                                                <tr>
                                                    <td colspan="2" style="color: #000099; height: 23px; background-color: #FF9E0D">
                                                        <span style="font-weight: bold; font-size: 12pt; color: #000099">Payment Info</span></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 79px; height: 15px">
                                                        <span style="font-weight: bold; color: #003399">Currency</span></td>
                                                    <td style="width: 100px; color: #003399; height: 15px">
                                                        <asp:DropDownList ID="drpCurrency" runat="server" AutoPostBack="True">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 79px">
                                                        <span style="font-weight: bold; color: #003399">Rate</span></td>
                                                    <td style="width: 100px; color: #003399">
                                                        <asp:TextBox ID="txtRate" runat="server" ReadOnly="True" Width="96px"></asp:TextBox></td>
                                                </tr>
                                                <tr style="color: #003399">
                                                    <td style="width: 79px">
                                                        <span style="font-weight: bold; color: #808080">Tran
                        Amount</span></td>
                                                    <td style="width: 100px; color: #808080">
                                                        <asp:TextBox ID="txtTransAmount" runat="server" Font-Size="Small" ReadOnly="True"
                                                            Width="97px"></asp:TextBox></td>
                                                </tr>
                                                <tr style="color: #003399">
                                                    <td style="width: 79px">
                                                        SI Default Amount</td>
                                                    <td style="width: 100px; color: #808080">
                                                        <asp:TextBox ID="txtSI" runat="server" Font-Size="Small" ReadOnly="True" 
                                                            Width="97px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table style="width: 329px; color: #808080">
                                                <tr>
                                                    <td style="width: 974px">
                                                        <span>From Account Number*</span></td>
                                                    <td style="width: 100px; color: #ffff00">
                                                        <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" Font-Size="Small"
                                                            TabIndex="1" Width="145px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 100px">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 974px">
                                                        To Account Number*</td>
                                                    <td style="width: 100px">
                                                        <asp:TextBox ID="txtAccountNo2" runat="server" AutoPostBack="True" Font-Size="Small"
                                                            TabIndex="1" Width="144px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 100px">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 974px; height: 23px">
                        Start Date*</td>
                                                    <td style="width: 100px; height: 23px">
                                                        <asp:TextBox ID="txtStartdate" runat="server" Font-Size="Small" TabIndex="2" Width="144px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 100px; height: 23px">
                                                        <asp:HyperLink ID="hypValueDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 974px; height: 17px">
                        End Date*</td>
                                                    <td style="width: 100px; height: 17px">
                                                        <asp:TextBox ID="txtEnddate" runat="server" Font-Size="Small" TabIndex="2" Width="144px"></asp:TextBox></td>
                                                    <td style="width: 100px; height: 17px">
                                                        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:RadioButtonList ID="RDList" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1">Specific Amount</asp:ListItem>
                                                            <asp:ListItem Value="2">Floor Amount</asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 974px">
                                                        SI Amount*</td>
                                                    <td style="width: 100px">
                                                        <asp:TextBox ID="txtPayAmount" runat="server" AutoPostBack="True" TabIndex="3" Width="145px"></asp:TextBox></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 974px">
                                                        Frequency*</td>
                                                    <td style="width: 100px">
                                                        <asp:DropDownList ID="DDaccrualfreq" runat="server" AutoPostBack="True">
                                                        </asp:DropDownList></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 974px">
                        Seq No</td>
                                                    <td style="width: 100px">
                                                        <asp:DropDownList ID="DrpSerial" runat="server" AutoPostBack="True" Visible="False">
                                                        </asp:DropDownList><asp:TextBox ID="txtSeqNo" runat="server" Font-Size="Small" ReadOnly="True"
                                                            Width="90px"></asp:TextBox></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 974px">
                                                        Narration1*</td>
                                                    <td style="width: 100px">
                                                        <asp:TextBox ID="txtNaration" runat="server" Height="53px" TabIndex="5" TextMode="MultiLine"
                                                            Width="143px"></asp:TextBox></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 974px">
                                                    </td>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 100px" valign="top">
                                            <span style="color: #000000"><strong>&nbsp;</strong></span><table style="font-weight: bold;
                                                width: 241px; color: #000000; background-color: #ccccff">
                                                <tr>
                                                    <td colspan="2" style="height: 23px; background-color: #FF9E0D">
                                                        <span style="font-weight: bold; font-size: 12pt; color:#000099">To Account Info</span></td>
                                                </tr>
                                                <tr style="color: #000000">
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                                        <span style="color: #000000">Account Name:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #003399; height: 15px">
                                                        <asp:Label ID="Label10" runat="server" ForeColor="Black" Width="124px"></asp:Label></td>
                                                </tr>
                                                <tr style="color: #000000">
                                                    <td style="width: 222px">
                                                        <span style="color: #000000">Product Name &nbsp;:&nbsp;</span></td>
                                                    <td style="width: 100px">
                                                        <asp:Label ID="Label11" runat="server" ForeColor="Black" Width="128px"></asp:Label></td>
                                                </tr>
                                                <tr style="color: #000000">
                                                    <td style="width: 222px">
                                                        <span>Branch:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #ffffff">
                                                        <asp:Label ID="Label12" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 222px">
                                                        <span style="color: #000000">Book Balance:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #000000">
                                                        <asp:Label ID="Label13" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 222px; height: 18px">
                                                        <span>Effective Balance:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:Label ID="Label14" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 222px; height: 18px">
                                                        <span>Usable Balance:</span></td>
                                                    <td style="width: 100px; color: #ffff00; height: 18px">
                                                        <asp:Label ID="Label15" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        <span>Source Type:</span></td>
                                                    <td style="width: 100px; color: #ffff00; height: 18px">
                                                        <asp:Label ID="Label16" runat="server" ForeColor="Black" Width="123px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        <span>Source:</span></td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:Label ID="Label17" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        <span>Account Status:</span></td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:Label ID="Label18" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="1" style="height: 18px" valign="top">
                                        </td>
                                        <td colspan="3" style="height: 18px" valign="top">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="height: 18px; text-align: center">
                                            <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Submit" ValidationGroup="News" /><asp:Button
                                                ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" /><asp:Button ID="btnReturn"
                                                    runat="server" BackColor="#C0C0FF" Text="Return" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>--%>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

