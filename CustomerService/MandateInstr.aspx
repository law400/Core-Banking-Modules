<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"    AutoEventWireup="false"   CodeFile="MandateInstr.aspx.vb" Inherits="CustomerService_MandateInstr" title="MandateInstruction Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <script src="template/js/jquery-1.11.1.min.js"></script>

    <%--    <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>--%>
   <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.5;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>--%>

    <div class="panel panel-default">
        <div class="panel-heading">

        </div>

                                <div class="form-group">
                            <tr>
                                <td style="width: 974px">
                                   </td>
                                <td style="width: 100px">
                                        <asp:LinkButton ID="LinkButton1" runat="server" Visible="False">View Mandate 
                                        Detail</asp:LinkButton>
                                    </td>
                                </tr>
                                   </div>
                                 <div class="form-group" >
                                       <tr>
                                <td style="width: 974px">
                                   </td>
                                <td style="width: 100px">
                                        <asp:Label ID="Label33" runat="server" Font-Bold="True" Font-Size="Larger" 
                                            ForeColor="Red" ></asp:Label>
                                    </td>
                                </tr>
                                   </div>
                               <div class="form-group">
                                         <tr>
                                <td style="width: 974px">
                                   </td>
                                <td style="width: 100px">
                                        <asp:Label ID="Label32" runat="server" Font-Bold="True" Font-Size="Larger" 
                                            ForeColor="Red"></asp:Label>
                                     </td>
                                </tr>
                                 </div>
                              <div class="form-group">
                                       <tr>
                                <td style="width: 974px">
                                 </td>
                                <td style="width: 100px">
                                        <asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="True" 
                                            Text="Remove Mandate On Account" Visible="False" />

                                             </td>
                                </tr>
                                   </div>
        <div class="panel-body">
   
         <div class="col-md-6"> 

              <div class="form-group"> 
                            <tr>
                                <td style="width: 974px">
                                    Account Number <span style="color: #FF0000"><strong>*</td></strong></span>
                                <td style="width: 100px">
                                    &nbsp;
                                    <asp:HyperLink ID="hypAccount" runat="server" Height="27px" ImageUrl="~/Images/iconbar_previewtab_on.gif" Visible="True">HyperLink</asp:HyperLink>
                                    <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" TabIndex="1" CssClass="form-control"></asp:TextBox>
                                </td>
                               
                            </tr>
                            </div>


              <div class="form-group"> 
                  <div class="form-group"> 
                  <tr>
                                    <td style="width: 336px">
                                        Number Of Signatory</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtnosign" runat="server" Width="37px" AutoPostBack="True" Font-Size="Small"></asp:TextBox></td>
                                </tr>
               </div>
                         <div class="form-group">        
                   <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label10" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtname1" runat="server" Visible="False"  CssClass="form-control"></asp:TextBox></td>
                                </tr>
                             </div>
                   <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 18px">
                                        <asp:Label ID="Label11" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 18px">
                                        <asp:TextBox ID="txtdesig1" runat="server" Visible="False"  CssClass="form-control"></asp:TextBox></td>
                                </tr>
                       </div>
                  <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 30px;">
                                        <asp:Label ID="Label13" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 30px"><input id="File1" type="file" name="File1" 
                                            runat="server" visible="False"></td>
                                </tr>
                      </div>
                  <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label12" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File2" runat="server" name="File2" type="file" visible="False"></input></td>
                                </tr>
                      </div>
                      <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label30" runat="server" Text="Mandate" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtmandate1" runat="server" TextMode="MultiLine" Height="64px" 
                                           CssClass="form-control"></asp:TextBox></td>
                                </tr>
                          </div>
                  <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label14" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtname2" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                      </div>
                  <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 18px">
                                        <asp:Label ID="Label15" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td style="width: 100px; height: 18px">
                                        <asp:TextBox ID="txtdesig2" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                    <td style="width: 100px; height: 18px">
                                    </td>
                                </tr>
                      </div>
                  <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label17" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2">
                                        <input ID="File3" runat="server" name="File3" type="file" visible="False"></input></td>
                                </tr>
                      </div>
                  <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label16" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File4" runat="server" name="File4" type="file" visible="False"></input></td>
                                </tr>
                      </div>
                  <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label18" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtname3" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                      </div>
                  <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 18px">
                                        <asp:Label ID="Label19" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td style="width: 100px; height: 18px">
                                        <asp:TextBox ID="txtdesig3" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                    <td style="width: 100px; height: 18px">
                                    </td>
                                </tr>
                      </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label21" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2">
                                        <input ID="File5" runat="server" name="File5" type="file" visible="False"></input></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label20" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File6" runat="server" name="File6" type="file" visible="False"></input></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                 <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label22" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtname4" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 18px">
                                        <asp:Label ID="Label23" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td style="width: 100px; height: 18px">
                                        <asp:TextBox ID="txtdesig4" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                    <td style="width: 100px; height: 18px">
                                    </td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label25" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2">
                                        <input ID="File7" runat="server" name="File7" type="file" visible="False"></input></td>
                                </tr>
                       </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label24" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File8" runat="server" name="File8" type="file" visible="False"></input></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                 <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label26" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtname5" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                         </div>

                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 18px">
                                        <asp:Label ID="Label27" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td style="width: 100px; height: 18px">
                                        <asp:TextBox ID="txtdesig5" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                    <td style="width: 100px; height: 18px">
                                    </td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label29" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2">
                                        <input ID="File9" runat="server" name="File9" type="file" visible="False"></input></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label28" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File10" runat="server" name="File10" type="file" visible="False"></input></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label34" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtname6" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label35" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtdesig6" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label36" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File11" runat="server" name="File11" type="file" visible="False"></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label37" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File12" runat="server" name="File12" type="file" visible="False"></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label38" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtname7" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label39" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtdesig7" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label40" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File13" runat="server" name="File13" type="file" visible="False"></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label41" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File14" runat="server" name="File14" type="file" visible="False"></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label42" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtname8" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label43" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtdesig8" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label44" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File15" runat="server" name="File15" type="file" visible="False"></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label45" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File16" runat="server" name="File16" type="file" visible="False"></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label46" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtname9" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label47" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtdesig9" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label48" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File17" runat="server" name="File17" type="file" visible="False"></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label49" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File18" runat="server" name="File18" type="file" visible="False"></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label50" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtname10" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label51" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtdesig10" runat="server" Visible="False" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label52" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File19" runat="server" name="File19" type="file" visible="False"></td>
                                </tr>
                         </div>
                     <div class="form-group"> 
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label53" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File20" runat="server" name="File20" type="file" visible="False"></td>
                                </tr>
                         </div>

                  </div>

             </div>


        <div class="col-md-5">
            <div class="box box-widget widget-user-2">
                <div class="widget-user-header bg-maroon">
                  <h3 class="widget-user-username" align="center">Account Info</h3>
<%--                  <h5 class="widget-user-desc">Lead Developer</h5>--%>
                </div>
                <div class="box-footer no-padding"> 
                     <div class="col-md-12">
                  <ul class="nav nav-stacked">
                    <li><a style="font-size: small">Account Name
                        <span class="pull-right badge bg-teal"><asp:Label ID="Label1" runat="server"></asp:Label></span></a></li>
                      <li><a style="font-size: small">Product Name
                          <span class="pull-right badge bg-teal"><asp:Label ID="Label2" runat="server"></asp:Label></span></a></li>
                    <li><a style="font-size: small">Branch
                        <span id="Branch" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label3" runat="server"></asp:Label></span></a></li>

                     <li><a style="font-size: small">Book Balance
                        <span id="BookBalance" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label4" runat="server"></asp:Label></span></a></li>

                      <li><a style="font-size: small">Effective Balance
                        <span id="EffectiveBal" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label5" runat="server"></asp:Label></span></a></li>

                       <li><a style="font-size: small">Usable Balance
                        <span id="UsableBal" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label6" runat="server"></asp:Label></span></a></li>

                    <li><a style="font-size: small">Source Type
                        <span id="SourceType" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label7" runat="server"></asp:Label></span></a></li>

                      <li><a style="font-size: small">Source
                          <span class="pull-right badge bg-teal"><asp:Label ID="Label8" runat="server"></asp:Label></span></a></li>
                    
                        <li><a style="font-size: small">Account Status
                        <span id="AcctStatus" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label9" runat="server"></asp:Label></span></a></li>
                  </ul>
                         </div>
                </div>
              </div>
                         
                            
                        </div>


      </div>

    <div class="panel-footer">
         <asp:TextBox ID="txtcustomerid" runat="server" Width="37px" 
                                AutoPostBack="True" Font-Size="Small" Visible="False"></asp:TextBox>
       
                                     
                                    <asp:Button ID="Btnsubmit" runat="server" BackColor="#C0C0FF" Text="Submit" ValidationGroup="News" CssClass="btn bg-purple btn-flat margin" />
                                  
                                    
                                          <asp:Button
                                        ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" CssClass="btn bg-maroon btn-flat margin" />
                                      
                                  

       


    </div>


        </div>


  <%--  <div class="box-blue">
        <div class="content">
            <br />
            &nbsp;</div>
    </div>
    <table border="2" bordercolor="#330099" style="width: 353px; height: 376px">
        <tr>
            <td style="width: 100px">
                <table border="0" bordercolor="#0000cc" style="width: 704px; height: 1px">
                    <tr>
                        <td colspan="4" valign="top">
                            <table style="width: 401px; height: 72px">
                                <tr>
                                    <td colspan="3">
                            <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Submit" 
                                ValidationGroup="News" Height="26px" />
                            <asp:Button ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" />
                            <asp:Button ID="btnReturn" runat="server" BackColor="#C0C0FF" Text="Return" />
                                        <asp:LinkButton ID="LinkButton1" runat="server" Visible="False">View Mandate 
                                        Detail</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="Label33" runat="server" Font-Bold="True" Font-Size="Larger" 
                                            ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="Label32" runat="server" Font-Bold="True" Font-Size="Larger" 
                                            ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="True" 
                                            Text="Remove Mandate On Account" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 336px">
                            Account Number*</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" Font-Size="Small"
                                            TabIndex="1" Width="175px" Height="22px"></asp:TextBox>
                                        <asp:HyperLink ID="hypAccount" runat="server"
                                                Height="20px" ImageUrl="~/Images/iconbar_previewtab_on.gif" 
                                            Width="27px">HyperLink</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px">
                                        Number Of Signatory</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtnosign" runat="server" Width="37px" AutoPostBack="True" Font-Size="Small"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label10" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtname1" runat="server" Visible="False" Width="212px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 18px">
                                        <asp:Label ID="Label11" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 18px">
                                        <asp:TextBox ID="txtdesig1" runat="server" Visible="False" Width="211px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 30px;">
                                        <asp:Label ID="Label13" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 30px"><input id="File1" type="file" name="File1" 
                                            runat="server" visible="False"></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label12" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File2" runat="server" name="File2" type="file" visible="False"></input></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label30" runat="server" Text="Mandate" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtmandate1" runat="server" TextMode="MultiLine" Height="64px" 
                                            Width="210px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label14" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtname2" runat="server" Visible="False"></asp:TextBox></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 18px">
                                        <asp:Label ID="Label15" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td style="width: 100px; height: 18px">
                                        <asp:TextBox ID="txtdesig2" runat="server" Visible="False"></asp:TextBox></td>
                                    <td style="width: 100px; height: 18px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label17" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2">
                                        <input ID="File3" runat="server" name="File3" type="file" visible="False"></input></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label16" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File4" runat="server" name="File4" type="file" visible="False"></input></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label18" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtname3" runat="server" Visible="False"></asp:TextBox></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 18px">
                                        <asp:Label ID="Label19" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td style="width: 100px; height: 18px">
                                        <asp:TextBox ID="txtdesig3" runat="server" Visible="False"></asp:TextBox></td>
                                    <td style="width: 100px; height: 18px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label21" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2">
                                        <input ID="File5" runat="server" name="File5" type="file" visible="False"></input></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label20" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File6" runat="server" name="File6" type="file" visible="False"></input></td>
                                </tr>
                                 <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label22" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtname4" runat="server" Visible="False"></asp:TextBox></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 18px">
                                        <asp:Label ID="Label23" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td style="width: 100px; height: 18px">
                                        <asp:TextBox ID="txtdesig4" runat="server" Visible="False"></asp:TextBox></td>
                                    <td style="width: 100px; height: 18px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label25" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2">
                                        <input ID="File7" runat="server" name="File7" type="file" visible="False"></input></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label24" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File8" runat="server" name="File8" type="file" visible="False"></input></td>
                                </tr>
                                 <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label26" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtname5" runat="server" Visible="False"></asp:TextBox></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 18px">
                                        <asp:Label ID="Label27" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td style="width: 100px; height: 18px">
                                        <asp:TextBox ID="txtdesig5" runat="server" Visible="False"></asp:TextBox></td>
                                    <td style="width: 100px; height: 18px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 336px">
                                        <asp:Label ID="Label29" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2">
                                        <input ID="File9" runat="server" name="File9" type="file" visible="False"></input></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label28" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File10" runat="server" name="File10" type="file" visible="False"></input></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label34" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtname6" runat="server" Visible="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label35" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtdesig6" runat="server" Visible="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label36" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File11" runat="server" name="File11" type="file" visible="False"></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label37" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File12" runat="server" name="File12" type="file" visible="False"></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label38" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtname7" runat="server" Visible="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label39" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtdesig7" runat="server" Visible="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label40" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File13" runat="server" name="File13" type="file" visible="False"></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label41" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File14" runat="server" name="File14" type="file" visible="False"></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label42" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtname8" runat="server" Visible="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label43" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtdesig8" runat="server" Visible="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label44" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File15" runat="server" name="File15" type="file" visible="False"></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label45" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File16" runat="server" name="File16" type="file" visible="False"></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label46" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtname9" runat="server" Visible="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label47" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtdesig9" runat="server" Visible="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label48" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File17" runat="server" name="File17" type="file" visible="False"></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label49" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File18" runat="server" name="File18" type="file" visible="False"></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label50" runat="server" Text="Name" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtname10" runat="server" Visible="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label51" runat="server" Text="Designation" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <asp:TextBox ID="txtdesig10" runat="server" Visible="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label52" runat="server" Text="Photo" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File19" runat="server" name="File19" type="file" visible="False"></td>
                                </tr>
                                <tr>
                                    <td style="width: 336px; height: 17px">
                                        <asp:Label ID="Label53" runat="server" Text="Signature" Visible="False"></asp:Label></td>
                                    <td colspan="2" style="height: 17px">
                                        <input ID="File20" runat="server" name="File20" type="file" visible="False"></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="1" style="width: 9px; text-align: left" valign="top">
                            <table style="font-weight: bold; width: 330px; background-color: #ccccff; height: 139px;">
                                <tr>
                                    <td colspan="2" style="height: 22px; background-color: #FF9E0D">
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
                                        <span>Product Name &nbsp;:&nbsp;</span></td>
                                    <td style="width: 100px; color: #808080">
                                        <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="128px"></asp:Label></td>
                                </tr>
                                <tr style="color: #000000">
                                    <td style="width: 222px">
                                        <span>Branch:&nbsp;</span></td>
                                    <td style="width: 100px; color: #000000">
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
                                        <strong><span style="font-weight: bold; color: black">Usable Balance:</span></strong></td>
                                    <td style="width: 100px; height: 18px">
                                        <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                        Source Type:</td>
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
                            </table>
                            &nbsp;
                                        <asp:TextBox ID="txtcustomerid" runat="server" Width="37px" 
                                AutoPostBack="True" Font-Size="Small" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>--%>
   <%--</ContentTemplate> 
    </asp:UpdatePanel>--%>
</asp:Content>

