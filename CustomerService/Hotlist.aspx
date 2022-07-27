<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="Hotlist.aspx.vb" Inherits="CustomerService_Hotlist" title="HotList Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.5;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>
   <div class="box box-info">
                <div class="box-header">
                   <asp:RadioButtonList ID="RDBHotList" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="2">HotListed</asp:ListItem>
                    <asp:ListItem Value="1">De-HotListed</asp:ListItem>
                </asp:RadioButtonList></td>
           
                    <div class="form-group">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                    Text="Enter a Range of Cheque number to be hotlisted Or Dehotlisted. If you have 1 Cheque, Pls enter the same Cheque Number as the SatrtNo and EndNo." 
                    ></asp:Label>
           </div>
        <div class="box-body">
             <div class="col-md-4">
                           
                    <div class="form-group">
                      <label>Account Number&nbsp;
                        <asp:HyperLink ID="hypAccount" runat="server" Height="23px" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                        </label>
                    
                         &nbsp;<asp:TextBox ID="txtAcctNo3" runat="server" AutoPostBack="True" Font-Size="Small" placeholder="Account Number" CssClass="form-control"></asp:TextBox>

            </div>
                  <div class="form-group">
                      <label>Start No</label>
                    
                         <asp:TextBox ID="txtStart2" runat="server" AutoPostBack="True" Font-Size="Small" placeholder="Start No" CssClass="form-control"></asp:TextBox>

            </div>

                   <div class="form-group">
                      <label>Reason</label>
                    
                       <asp:TextBox ID="txtReason" runat="server" AutoPostBack="True" Height="56px" TextMode="MultiLine"  Font-Size="Small" placeholder="Reason" CssClass="form-control"></asp:TextBox>

            </div>


                 </div>

                 <div class="col-md-4">

                     <div class="form-group">
                      <label>Account Name</label>
                    
                         <asp:TextBox ID="txtAcctName" runat="server" AutoPostBack="True" Height="56px" TextMode="MultiLine" ReadOnly="True" Font-Size="Small" placeholder="Account Name" CssClass="form-control"></asp:TextBox>

            </div>

                      <div class="form-group">
                      <label>End No</label>
                    
                         <asp:TextBox ID="txtEnd2" runat="server" AutoPostBack="True" Font-Size="Small" placeholder="End No" CssClass="form-control"></asp:TextBox>

            </div>

                       <div class="form-group">
                      <label>Value Date <asp:HyperLink ID="imgdate3" runat="server" ImageUrl="~/Images/pdate.gif"
                        Width="17px">HyperLink</asp:HyperLink></label>
                    
                         <asp:TextBox ID="txtValueDate" runat="server" AutoPostBack="True" Font-Size="Small" placeholder="Value Date" CssClass="form-control"></asp:TextBox>

            </div>


                       </div>
                    
                    </div>  <!-- end box-body -->


                    <div class="box-footer">
                           
                          <asp:Button ID="Btnsubmit" runat="server" CssClass="btn bg-purple btn-flat margin" 
                                                    Text="Submit" Width="31%"/>
                          
                          
                                                <asp:Button ID="Btncancel" runat="server" CssClass="btn bg-maroon btn-flat margin" 
                                                    Text="Reset" Width="31%"/>
                           

                          </div>

                      </div>
                 </div>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

