<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="PostBulk_MemberContribution.aspx.vb" Inherits="CustomerService_PostBulk_MemberContribution" title="Post Member Contribution" %>

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
     <div class="form-group" style="font-size: small"> 
       
                <asp:Label ID="Label7" runat="server" Font-Size="Large" ForeColor="#FF6699" Text="POST BULK MEMBER CONTRIBUTIONS"></asp:Label>
                <br />
                <br />
       
                <asp:Label ID="Label1" runat="server" 
                    style="font-size: large; font-weight: 700; color: #FF0000"></asp:Label>
        </div>
<div class="box-body">
    <div class="row">

       
<div class="col-md-6">
       <div class="form-group" >
        <tr>
            <td style="width: 6587px; height: 25px;">
                Batch No
                <asp:TextBox ID="txtBatch" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
            </td>
            <td colspan="2" style="height: 25px">
                &nbsp;</td>
        </tr>
        </div>
        <div class="form-group" >
        <tr>
            <td style="height: 22px;" colspan="3">
                Select Ms Office Excel Type
                <asp:DropDownList ID="DrpExcelType" runat="server" CssClass="form-control" AutoPostBack="True">
                    <asp:ListItem Value="0">--Choose Office Type--</asp:ListItem>
                   <%-- <asp:ListItem Value="1">MS- Office Excel 2003</asp:ListItem>--%>
                    <asp:ListItem Value="2">MS- Office Excel 2007</asp:ListItem>
                    <asp:ListItem Value="3">MS- Office Excel 2010 upward</asp:ListItem>
                </asp:DropDownList>
                                                                                </td>
        </tr>
        </div>
        <div class="form-group" >
        <tr>
            <td style="height: 22px;" colspan="3">
                Locate File to Upload
                <asp:FileUpload ID="Myfile" CssClass="form-control" runat="server" />
                <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                                </td>
        </tr>
        </div>
        <div class="form-group" >
        <tr>
            <td style="width: 6587px; height: 25px;">
                <asp:Button ID="upload" runat="server" Text="upload" CssClass="btn bg-maroon btn-flat margin" />
                <asp:Button ID="Button1" runat="server" Text="Post" 
                     CssClass="btn bg-purple btn-flat margin" Enabled="False" /></td>
            <td colspan="2" style="height: 25px">
                <asp:ListBox ID="ListBox1" runat="server" Visible="False" CssClass="form-control">
                </asp:ListBox>
            </td>
        </tr>
        </div>
    
      
</div>

        <div class="col-md-6">

            <div class="form-group" >
        <tr>
            <td style="height: 22px;" colspan="3">
                Organization <em><strong>(Corporate Contribution GL:</strong></em> <asp:Label ID="LblGL" runat="server" Font-Bold="True" ForeColor="#3366FF" style="font-style: italic"></asp:Label>
                <strong><em>)</em></strong><asp:DropDownList ID="DropCorporation" runat="server" CssClass="form-control" AutoPostBack="True">
                    
                </asp:DropDownList>
               
                                                                                </td>
        </tr>
        </div>
             <div class="form-group" >
        <tr>
            <td style="width: 6587px; height: 25px;">
                Amount Received - Receipt
              
                 <telerik:RadNumericTextBox ID="RadReceivedAmt" Runat="server" CssClass="form-control" AutoPostBack="True" EmptyMessage="0">
                                                    </telerik:RadNumericTextBox>
            </td>
            <td colspan="2" style="height: 25px">
                &nbsp;</td>
        </tr>
        </div>
              <div class="form-group" >
        <tr>
            <td style="width: 6587px; height: 25px;">
                Total Transaction Amount by Schedule
                <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
            </td>
            <td colspan="2" style="height: 25px">
                &nbsp;</td>
        </tr>
        </div>
         <div class="form-group" >
         <tr>
            <td style="width: 6587px; height: 25px;">
                Amount Difference:
             <asp:Label ID="Lbl_Diff" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                 </td>
            <td colspan="2" style="height: 25px">
                &nbsp;</td>
        </tr>
       </div>
        </div>
</div>
    <div class="box-footer">
    <tr>
            <td colspan="3">
                        <asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" BackColor="White"
                           BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
            ShowFooter="True" CellPadding="4" Font-Size="Small"
                            Width="100%">
                             <Columns>
                               
                                <asp:BoundField DataField="Employer_No" HeaderText="Employer_No">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Employee_ID" HeaderText="Employee_ID">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ContributionAmount" DataFormatString="{0:n}" HeaderText="ContributionAmount"
                                    HtmlEncode="False">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProductCode" HeaderText="ProductCode">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                               
                                <asp:BoundField DataField="Period"  HeaderText="Period"
                                    HtmlEncode="False">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Narration" HeaderText="Narration">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                              
                                
                            </Columns>
                            <RowStyle BackColor="White" Font-Size="8pt" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        </asp:GridView>
            </td>
        </tr>
    </div>

</div>
</div>
	</ContentTemplate> 
	 <Triggers>
         <asp:PostBackTrigger ControlID="upload" />
                  <asp:PostBackTrigger ControlID="button1" />

     </Triggers>
	</asp:UpdatePanel> 
</asp:Content>

