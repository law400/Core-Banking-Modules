<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"    AutoEventWireup="false"   CodeFile="CashDeposit.aspx.vb" Inherits="BankingOperations_TransfersDeposit" title="Member Deposit Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .loader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url('~/images/loading.gif') 50% 50% no-repeat rgb(249,249,249);
        }
    </style>
          <link href="template/css/dropzone.css" rel="stylesheet"/>

                <script src="template/js/jquery-1.11.1.min.js"></script>
<%--            <script src="template/js/dropzone.min.js"></script>--%>
       <script src="../DropzoneJs_scripts/jquery.min.js"></script>
    <script src="../DropzoneJs_scripts/dropzone.js"></script>
<%--    <link href="../DropzoneJs_scripts/dropzone.css" rel="stylesheet" />--%>

     <script type="text/javascript">
        
             $(document).ready(function () {
                 console.log("Hello");
                 Dropzone.autoDiscover = false;
                 var username = new Date().valueOf();
                 // var username = 67;
                 $('#<%= RecordID.ClientID %>').val(username)
                 $("#dZUpload").dropzone({
                     url: "Uploader.ashx?recordid=" + username.toString(),
                     maxFiles: 5,
                     addRemoveLinks: true,
                     success: function (file, response) {
                         var imgName = response;
                         file.previewElement.classList.add("dz-success");
                         console.log("Successfully uploaded :" + imgName);
                     },
                     error: function (file, response) {
                         file.previewElement.classList.add("dz-error");
                     }
                 });
             });

         

             function popWin(llInp) {
                 window.open("GlCustEnquiry.aspx", "aa", "width=650,height=600");
                 return false;
             }

             $(window).load(function () {
                 $(".loader").fadeOut("slow");
             })
        </script>
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <%-- <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
  
 <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>--%>
    <div class="panel panel-default">
         <div style="background-color: Transparent; color: Black">
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2"
                DisplayAfter="0">
                <ProgressTemplate>
                    <div style="top: 0px; height: 100%; background-color: White; opacity: 2.75; filter: alpha(opacity=75);
                        vertical-align: middle; left: 0px; z-index: 999999; width: 100%; position: absolute;
                        text-align: center; vertical-align: middle">
                        <table width="100%" height="100%">
                            <tr>
                                <td align="center" valign="middle">
                                    <img id="Img1" src="~/images/loading.gif" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
        <div class="panel-header">

        </div>
           
                            <tr>
                                <td colspan="3" valign="top">
                                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Width="100%">
                                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" Font-Size="XX-Small" Height="86px" PageSize="1" 
                                        Width="100%" CssClass="table table-bordered table-hover dataTable">
                                        <Columns>
                                            <asp:BoundField DataField="Acctnumber" HeaderText="GL Acctnumber" />
                                            <asp:BoundField DataField="acctname" HeaderText="GL Name" />
                                            <asp:BoundField DataField="valuedate" DataFormatString="{0:dd/MM/yyyy}" 
                                                HeaderText="valuedate" HtmlEncode="False" />
                                            <asp:BoundField DataField="Tranamount" DataFormatString="{0:n}" 
                                                HeaderText=" Initial Amount" HtmlEncode="False">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BalanceAmount" DataFormatString="{0:n}" 
                                                HeaderText="BalanceAmount" />
                                            <asp:BoundField DataField="Narration" HeaderText="Narration" />
                                        </Columns>
                                        <RowStyle BackColor="White" Font-Size="8pt" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    </asp:GridView>
                                            </asp:Panel> 
                                </td>
                            </tr>
                 
  
<div class="panel-body">
  

        <div class="col-md-6">
               <!-- the White Background --->
                                <div class="form-group" >
                                        <tr>
                                            <td style="width: 974px">
                                                <asp:DropDownList ID="DrpTransfer" runat="server" AutoPostBack="True" CssClass="form-control" Visible="False">
                                                    <asp:ListItem Selected="True" Value="TRF">Transfer With No COT</asp:ListItem>
                                                    <asp:ListItem Value="TRFC">Transfer With COT</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </div>
                                    <div class="form-group" >
                                        <tr>
                                            <td style="width: 974px">
                                                <asp:CheckBox ID="CKBLien" runat="server" AutoPostBack="True" Font-Size="8pt" Text="Is a Reversal" Visible="False" />
                                            </td>
                                        </tr>
                                    </div>
             <div class="form-group" >
                                        <tr>
                                            <td style="width: 974px">
                                                Mode of Deposit <span style="color: #FF0000"><strong>*</strong></span></td>
                                            </strong></span>
                                            <td colspan="2">
                                               
                                                <asp:DropDownList ID="DropMode" runat="server" CssClass="form-control" AutoPostBack="True" 
                                                     Visible="True">
                                                    <asp:ListItem Value="0">&lt;--Select Mode of Payment--&gt;</asp:ListItem>
                                                    <asp:ListItem Value="1">Cash</asp:ListItem>
                                                    <asp:ListItem Value="2">Bank Deposit</asp:ListItem>
                                                    <asp:ListItem Value="3">Cheque Deposit</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </div>
                                    <div class="form-group" >
                                        <tr>
                                            <td style="width: 974px">
                                                Debit&nbsp; Account Number <span style="color: #FF0000"><strong>*</strong></span></td>
                                            </strong></span>
                                            <td colspan="2">
                                                &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" Height="21px" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                                                <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" TabIndex="1"  CssClass="form-control"></asp:TextBox>
                                                <asp:DropDownList ID="DrpSubBr1" runat="server" CssClass="form-control" AutoPostBack="True" 
                                                    Font-Size="XX-Small" Visible="False" Enabled="False" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </div>
                                    <div class="form-group" >
                                        <tr>
                                            <td style="width: 974px">
                                                Credit Account Number <span style="color: #FF0000"><strong>*</strong></span></td>
                                            </strong></span>
                                            <td colspan="2">
                                                &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" Height="25px" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                                                <asp:TextBox ID="txtAccountNo2" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" TabIndex="1" CssClass="form-control" ></asp:TextBox>
                                                <asp:DropDownList ID="DrpSubBr2" runat="server" AutoPostBack="True" 
                                                    Font-Size="XX-Small" Visible="False" CssClass="form-control" Enabled="False" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        </div>
                                        <div class="form-group" >
                                        <tr>
                                            <td style="width: 974px">
                                                Value Date <span style="color: #FF0000"><strong>*</strong></span></td>
                                            </strong></span>
                                            <td colspan="2">
                                                &nbsp;<asp:HyperLink ID="hypValueDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink>
                                                <asp:TextBox ID="txtValueDate" runat="server" Font-Size="Small" TabIndex="2" 
                                                    CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </div>
                                    <div class="form-group" >
                                        <tr>
                                            <td style="width: 974px">
                                                <asp:Label ID="Label20" runat="server" Text="Pay Code" Visible="False"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtPaycode" runat="server" CssClass="form-control" Visible="False"  
                                                    AutoPostBack="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </div>
                                    <div class="form-group" >
                                        <tr>
                                            <td style="width: 974px">
                                                <asp:Label ID="Label19" runat="server" Text="Balance" Visible="False"></asp:Label>
                                            </td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtPayAmount0" runat="server" ReadOnly="True" TabIndex="3" 
                                                    Visible="False" CssClass="form-control" ></asp:TextBox>
                                            </td>
                                            <td style="width: 100px">
                                                &nbsp;</td>
                                        </tr>
                                    </div>
                                    <div class="form-group" >
                                        <tr>
                                            <td style="width: 974px">
                                                Pay Amount <span style="color: #FF0000"><strong>*</strong></span></td>
                                            </strong></span>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtPayAmount" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="3" 
                                                  ></asp:TextBox>
                                            </td>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                    </div>
                                    <div class="form-group" >
                                        <tr>
                                            <td style="width: 974px">
                                                Voucher / Instrument No</td>
                                            <td style="width: 100px">
                                                <span style="color: #FF0000"><strong>*</strong></span><asp:TextBox ID="txttellerno" runat="server" 
                                                    Font-Size="Small" TabIndex="4" CssClass="form-control" ></asp:TextBox>
                                            </td>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                    </div>
           <div class="form-group" id="UploadEvidence" runat="server" visible="false" >
                           <label style="text-align:left; width:200px">Upload Payment Evidence</label>
                          <asp:HiddenField ID="RecordID" runat="server" />
                      <asp:LinkButton ID="lbtUsername" runat="server" Visible="false"  Font-Names="Verdana" Text="1" Font-Size="Large" Font-Underline="True" ForeColor="#FF0066"></asp:LinkButton>
                     <div id="dZUpload" class="dropzone" >
                                   <div  class="dz-default dz-message">
         
        </div>
                                </div>
                          </div>
                                    <div class="form-group"  runat="server"   >
                                        <tr>
                                            <td style="width: 974px">
                                                &nbsp;Description of Payment
                                                <td style="width: 100px"><span style="color: #FF0000"><strong>*</strong></span><asp:TextBox ID="txtNaration" runat="server" CssClass="form-control" Height="53px" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td style="width: 100px"></td>
                                            </td>
                                        </tr>
                                    </div>
        </div>

        <div class="box-body">

<div class="col-md-3" runat="server" id="Debit_Details">
                           <div class="box box-widget widget-user-2">
                <div class="widget-user-header bg-maroon">
                  <h8 class="widget-user-username" align="left" style="font-size: small">Debit Account Info</h8>
<%--                  <h5 class="widget-user-desc">Lead Developer</h5>--%>
                </div>
                <div class="box-footer no-padding"> 
                     <div class="col-md-12">
                  <ul class="nav nav-stacked">
                    <li><a style="font-size: small"><span style="font-size: xx-small">Account Name</span>
                        <span class="pull-right badge bg-teal"><asp:Label ID="Label1" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>
                      <li><a style="font-size: small"><span style="font-size: xx-small">Product Name</span>
                          <span class="pull-right badge bg-teal"><asp:Label ID="Label2" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>
                    <li><a style="font-size: small"><span style="font-size: xx-small">Branch </span>
                        <span id="Branch" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label3" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                     <li><a style="font-size: small"><span style="font-size: xx-small">Book Balance</span>
                        <span id="BookBalance" class="pull-right badge bg-teal" runat="server" ><asp:Label ID="Label4" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                      <li><a style="font-size: small"><span style="font-size: xx-small">Effective Balance </span>
                        <span id="EffectiveBal" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label5" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                       <li><a style="font-size: small"><span style="font-size: xx-small">Usable Balance</span>
                        <span id="UsableBal" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label6" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                    <li><a style="font-size: small"><span style="font-size: xx-small">Source Type</span>
                        <span id="SourceType" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label7" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                      <li><a style="font-size: small"><span style="font-size: xx-small">Source</span>
                          <span class="pull-right badge bg-teal"><asp:Label ID="Label8" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>
                    
                        <li><a style="font-size: small"><span style="font-size: xx-small">Account Status</span>
                        <span id="AcctStatus" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label9" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                       <li><a style="font-size: small"><span style="font-size: xx-small">Total Charge</span>
                        <span id="Span1" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label22" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                      <li><a style="font-size: small">
                        <span id="Span2" class="pull-right badge bg-teal" runat="server"><asp:HyperLink ID="LnkCharge0" runat="server">HISTORY</asp:HyperLink></span></a></li>
                       <li><a style="font-size: small">
                       <span id="Span3" class="pull-right badge bg-teal" runat="server"><asp:HyperLink ID="LnkCharge" runat="server" Visible="False">View Charge Detail</asp:HyperLink></span></a></li>
                  </ul>
                         </div>
                </div>
              </div>
                                </div>
                                
   
	
                       
<div class="col-md-3">
    <div class="box box-widget widget-user-2">
                <div class="widget-user-header bg-teal" style="font-size: small">
                  <h8 class="widget-user-username" align="left" style="font-size: small"><span style="font-size: small">Credit Account Info</span></h8>
<%--                  <h5 class="widget-user-desc">Lead Developer</h5>--%>
                </div>
                <div class="box-footer no-padding"> 
                     <div class="col-md-12">
                  <ul class="nav nav-stacked">
                    <li><a style="font-size: small"><span style="font-size: xx-small">Account Name</span>
                        <span class="pull-right badge bg-teal"><asp:Label ID="Label10" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>
                      <li><a style="font-size: small"><span style="font-size: xx-small">Product Name</span>
                          <span class="pull-right badge bg-teal"><asp:Label ID="Label11" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>
                    <li><a style="font-size: small"><span style="font-size: xx-small">Branch </span>
                        <span id="Span4" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label12" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                     <li><a style="font-size: small"><span style="font-size: xx-small">Book Balance</span>
                        <span id="BookBalance2" class="pull-right badge bg-teal" runat="server" ><asp:Label ID="Label13" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                      <li><a style="font-size: small"><span style="font-size: xx-small">Effective Balance </span>
                        <span id="EffectiveBal2" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label14" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                       <li><a style="font-size: small"><span style="font-size: xx-small">Usable Balance</span>
                        <span id="UsableBal2" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label15" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                    <li><a style="font-size: small"><span style="font-size: xx-small">Source Type</span>
                        <span id="Span8" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label16" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                      <li><a style="font-size: small"><span style="font-size: xx-small">Source</span>
                          <span class="pull-right badge bg-teal"><asp:Label ID="Label17" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>
                    
                        <li><a style="font-size: small"><span style="font-size: xx-small">Account Status</span>
                        <span id="AccountStatus2" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label18" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                       <li><a style="font-size: small"><span style="font-size: xx-small">Total Charge</span>
                        <span id="Span10" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label21" runat="server" Font-Size="XX-Small"></asp:Label></span></a></li>

                      <li><a style="font-size: small">
                        <span id="Span11" class="pull-right badge bg-teal" runat="server"><asp:HyperLink ID="HyperLink4" runat="server">HISTORY</asp:HyperLink></span></a></li>
                       <li><a style="font-size: small">
                       <span id="Span12" class="pull-right badge bg-teal" runat="server"><asp:HyperLink ID="LnkCharge2" runat="server" Visible="False">View Charge Detail</asp:HyperLink></span></a></li>
                  </ul>
                         </div>
                </div>
              </div>
			
                                
                                    
                                 
                                    
                                   
                                    
                                  
                                  
            </div>
            
          </div>
          
</div>
   
                    <div class="panel-footer">
                        <asp:DropDownList ID="drpCurrency" runat="server" AutoPostBack="True" Visible="false"  CssClass="form-control" Font-Size="Small">
                                    </asp:DropDownList>
                    
                        
                       <asp:TextBox ID="txtRate" runat="server" ReadOnly="True" Visible="false"  CssClass="form-control"></asp:TextBox>

                      
                        <asp:TextBox ID="txtTransAmount" runat="server" Font-Size="xx-small" ReadOnly="True" Visible="false" 
                                        CssClass="form-control"></asp:TextBox>
                            <tr>
                                <td colspan="1" style="height: 18px" valign="top">
                                </td>
                                <td colspan="2" style="height: 18px" valign="top">
                                    <asp:TextBox ID="txtNoRow" runat="server" AutoPostBack="True" Font-Size="Small" 
                                        TabIndex="4" Visible="False" Width="94px"></asp:TextBox>
                                </td>
                            </tr>
                          
                                    <asp:HyperLink ID="HypAuth" runat="server" Visible="False">Override</asp:HyperLink>
                                    <div class="col-md-1">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                    <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Submit" 
                                        ValidationGroup="News"  CssClass="btn bg-purple btn-flat margin"  />
                                        
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel> 
                                    </div>
                           <div class="col-md-1">
                                    <asp:Button ID="btnReset" runat="server" BackColor="#C0C0FF"  Text="Reset" CssClass="btn bg-maroon btn-flat margin" />
                                     </div>
                           <div class="col-md-1">
                                    <asp:Button ID="btnAppoff" runat="server" BackColor="#C0C0FF" Enabled="False" Visible="False" 
                                        Text="Forward to Approving Officer" ValidationGroup="News"  CssClass="btn bg-green btn-flat margin"  />
                                       </div>  
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                               
                            <tr>
                                <td colspan="3" style="height: 18px; text-align: center">
                                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%" Visible ="false" >
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" Font-Size="Small" Height="86px" PageSize="1" 
                                        Width="100%" CssClass="table table-bordered table-hover dataTable">
                                        <Columns>
                                            <asp:BoundField DataField="Tillaccountno" HeaderText="Till Account" />
                                            <asp:BoundField DataField="TranDate" DataFormatString="{0:dd/MM/yyyy}" 
                                                HeaderText="TranDate" HtmlEncode="False">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DRtotal" DataFormatString="{0:n}" HeaderText="Debit" 
                                                HtmlEncode="False">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DRcount" HeaderText="Total DR" />
                                            <asp:BoundField DataField="CRtotal" DataFormatString="{0:n}" 
                                                HeaderText="Credit" />
                                            <asp:BoundField DataField="CRcount" HeaderText="Total CR" />
                                            <asp:BoundField DataField="total" DataFormatString="{0:n}" HeaderText="Balance">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <RowStyle BackColor="White" Font-Size="8pt" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    </asp:GridView>
                                            </asp:Panel> 
                                </td>
                            </tr>
                    </div>
      
</div>

 <%--   </ContentTemplate> 
    </asp:UpdatePanel> --%>
</asp:Content>

