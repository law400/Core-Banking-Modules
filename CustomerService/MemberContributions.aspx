<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false"   CodeFile="MemberContributions.aspx.vb" Inherits="CustomerService_MemberContributions" title="ManageCustomer Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- To handle export to excel, csv, pdf-->
<script src="../Scripts/jquery.min.js"></script>
<script type="text/javascript" src="../Scripts/tableExport.js"></script>
<script type="text/javascript" src="../Scripts/jquery.base64.js"></script>
<!---end of the export library----------->

    <%--<asp:UpdatePanel id="updatePanel" runat="server">--%>
<%--<ContentTemplate>--%>
 <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>--%>
<div class="box-blue">
        <div class="content">
            <table border="0" style="width: 298px; height: 187px; font-size: 8pt;">
        
        <caption style="text-align: left;" >
            <span style="color: #000099"><span style="font-size: 12pt">
        <strong><span></span></strong>
            </span></span>
        </caption>
        <tr>
            <td style="width: 113px; height: 13px;">
            </td>
            <td style="width: 72px; height: 13px;">
            </td>
            <td style="width: 101px; height: 13px;">
                <asp:LinkButton ID="LinkButton2" runat="server">New Member Contribution</asp:LinkButton>
            </td>
            <td style="width: 95px; height: 13px;">
                <asp:LinkButton ID="LinkButton1" runat="server">Update Member Contribution</asp:LinkButton>
            </td>
            <td style="width: 95px; height: 13px;">
                &nbsp;</td>
            <td style="width: 95px; height: 13px;">
                &nbsp;</td>
            <td style="width: 95px; height: 13px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 95px; height: 29px;" valign="top">
                CustomerID </td>
            <td colspan="2" style="height: 29px">
                <asp:TextBox ID="txtCustomerid" runat="server" AutoPostBack="True" Font-Size="Small" Width="93px"></asp:TextBox>
                <asp:HyperLink ID="Hypsearch" runat="server" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></td>
            <td style="width: 95px; height: 29px;">
                Status</td>
            <td style="width: 95px; height: 29px;">
                &nbsp;</td>
            <td style="width: 95px; height: 29px;">
                &nbsp;</td>
            <td style="width: 95px; height: 29px;">
                &nbsp;</td>
        </tr>
                <tr>
                    <td style="width: 113px; height: 29px;" valign="top">
                        Emp ID</td>
                    <td colspan="2" style="height: 29px">
                        <asp:TextBox ID="txtEmpID" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 95px; height: 29px;">
                        <asp:DropDownList ID="drpStatus" runat="server">
                            <asp:ListItem Text="Change Status" Value="1"></asp:ListItem>
                            <asp:ListItem Value="1">Activate</asp:ListItem>
                            <asp:ListItem Value="0">Deactivate</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 95px; height: 29px;">
                        &nbsp;</td>
                    <td style="width: 95px; height: 29px;">
                        &nbsp;</td>
                    <td style="width: 95px; height: 29px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 113px; height: 29px;" valign="top">
                        Amount</td>
                    <td colspan="2" style="height: 29px">
                        <asp:TextBox ID="txtContAmount" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 95px; height: 29px;">
                        &nbsp;</td>
                    <td style="width: 95px; height: 29px;">
                        &nbsp;</td>
                    <td style="width: 95px; height: 29px;">
                        &nbsp;</td>
                    <td style="width: 95px; height: 29px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 113px; height: 29px;" valign="top">
                        &nbsp;</td>
                    <td colspan="2" style="height: 29px">
                        &nbsp;</td>
                    <td style="width: 95px; height: 29px;">
                        &nbsp;</td>
                    <td style="width: 95px; height: 29px;">
                        &nbsp;</td>
                    <td style="width: 95px; height: 29px;">
                        &nbsp;</td>
                    <td style="width: 95px; height: 29px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 29px; text-align: center;">
                        &nbsp;<asp:Button ID="BtnSubmit" runat="server" BackColor="#C0C0FF" Font-Size="Small"
                            ForeColor="Black" Text="Submit" ValidationGroup="News1" Width="68px" Visible="false" />
                            <asp:Button ID="BtnUpdate" runat="server" BackColor="#C0C0FF" Font-Size="Small"
                            ForeColor="Black" Text="Update" ValidationGroup="News1" Width="68px" Visible="false" />
                        <asp:Button ID="BtnSearch" runat="server" style="margin-bottom: 0px" 
                            Text="Search" Width="68px" />
                        <asp:Button
                                ID="BtnCancel" runat="server" BackColor="#C0C0FF" Font-Size="Small" ForeColor="Black"
                                Text="Return" Width="68px" /></td>
                    <td style="height: 29px; text-align: center;">
                        &nbsp;</td>
                    <td style="height: 29px; text-align: center;">
                        &nbsp;</td>
                    <td style="height: 29px; text-align: center;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 29px; text-align: center;">
                        &nbsp;</td>
                    <td style="height: 29px; text-align: center;">
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem Text="ExportToExcel" Value="1"></asp:ListItem>
                            <%--<asp:ListItem Value="2">Export to Pdf</asp:ListItem>--%>
                            <asp:ListItem Text="ExportToCSV" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                        <%--<script type="text/javascript" src="../Scripts/excellentexport.js"></script>--%>
                    </td>
                    <td style="height: 29px; text-align: center;">
                        <asp:Button ID="BtnReturn1" runat="server" Text="Export" Width="68px" />
                        <%--<a download="somedata.xls" href="#" onclick="return ExcellentExport.excel(this, 'GridView1', 'Agent Commissions');">Export to Excel</a>--%>
                    </td>
                    <td style="height: 29px; text-align: center;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="10" style="height: 29px; text-align: center;">
                        
                        <div style="overflow:scroll ; height:300px; width:650px">

                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="200" 
                                PagerSettings-Position="TopAndBottom" AutoGenerateColumns="False" OnRowDataBound="GV_RowDataBound" Font-Size="X-Small"
                            >
                            <Columns>
                                <asp:BoundField DataField="customerid" HeaderText="CUSTID">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="empID" HeaderText="EMP ID">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="contrib_Amount" DataFormatString="{0:n}" HeaderText="CONTRIB AMT"
                                HtmlEncode="False">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>  
                                <asp:BoundField DataField="Total_Deductable" DataFormatString="{0:n}" HeaderText="REPAY AMT"
                                HtmlEncode="False">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>  
                                <asp:BoundField DataField="HRapproved_Amount" DataFormatString="{0:n}" HeaderText="HR APPRVD AMT"
                                HtmlEncode="False">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="status" HeaderText="STATUS">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>  
                            </Columns>
                            <RowStyle BackColor="White" Font-Size="8pt" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            </asp:GridView>

                            <!-- SECOND GRID TO SHOW ONLY EXCEL UPLOADED DATA -->
                            <asp:GridView ID="GridView2" runat="server"  OnRowDataBound="GV_RowDataBound">
                            </asp:GridView>
                           <!-- END OF SECOND GRIDVIEW -->

                            </div>                   
                        
                        </td>
                </tr>
                <%--<tr>
                <td colspan="10">
                Select Ms Office Excel Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DrpExcelType" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="0" Text="Choose Office Type"></asp:ListItem>
                    <asp:ListItem Value="1">MS- Office Excel 2003</asp:ListItem>
                    <asp:ListItem Value="2">MS- Office Excel 2007</asp:ListItem>
                    <asp:ListItem Value="3">MS- Office Excel 2010</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>--%>
                <tr style="background-color:ButtonFace">
                <td colspan="2">
                UPLOAD EXCEL DATA: 
                </td>
                <td colspan="8">
                <asp:FileUpload ID="Myfile" runat="server" Width="219px" />
                <asp:Button ID="upload" runat="server" Text="Upload" Width="74px" />
                <asp:Button ID="Button1" runat="server" Text="Post" Width="65px" />
                </td>
                </tr>
                <tr>
                <td colspan="10">
                <asp:Label ID="Label1" runat="server" 
                    style="font-size: large; font-weight: 500; color: #FF0000"></asp:Label>
                </td>
                </tr>
            </table>
        </div>
    </div>
    
    <%--</ContentTemplate> --%>
    <%--</asp:UpdatePanel> --%>
     <script type="text/javascript">
         function ValidateText(obj) {
             if (obj.value.length > 0) {
                 obj.value = obj.value.replace(/[^\d]+/g, '');
             }
         }
   </script>
</asp:Content>

