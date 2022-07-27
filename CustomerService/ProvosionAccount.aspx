<%@ Page Title="" Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="ProvosionAccount.aspx.vb" Inherits="CustomerService_ProvosionAccount" %>

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

 <div class="box-body">
             <div class="col-md-4">
                            <div class="form-group">
                      <label>Account Number  <asp:HyperLink
                                        ID="hypAccount" runat="server" Height="23px" 
                                        ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></label>
                    
                         <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" TabIndex="1"  Font-Size="Small" placeholder="Account Number" CssClass="form-control"></asp:TextBox>
 <asp:Label ID="Label7" runat="server" ForeColor="Red"></asp:Label>
            </div>


                 <div class="form-group">
                      <label>Provision Type</label>
                    
                        <asp:DropDownList ID="drpprovision" runat="server" AutoPostBack="True" CssClass="form-control">
                        </asp:DropDownList>
            </div>


                 </div>

     </div>


                     <div class="box-footer">
                          <asp:Button ID="Btnsubmit" runat="server" CssClass="btn bg-purple btn-flat margin" 
                                                    Text="Submit"  Width="31%"/>
                                               
                                                <asp:Button ID="Btncancel" runat="server" CssClass="btn bg-orange btn-flat margin" 
                                                    Text="Return" Width="31%" />


                          </div>

        </div>
                 </div>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>