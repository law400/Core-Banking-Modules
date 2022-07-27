<%@ Page Title="" Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="Coop_Reg_Auth.aspx.vb" Inherits="Coop_Reg_Auth" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
                                               <script src="template/js/jquery-1.11.1.min.js"></script>

    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header" style="background-color: #FFFFFF">
    <div class="header-section">
        <h1>
            <i class="bg-gray-light"></i>Co-operative Registration Authorization  <br/></h1>
     
    </div>
</div>

    <asp:Panel runat="server" BackColor="#fbfbfb" Height="700px" > 


        <div class="row" style="margin-left: 10px; margin-right: 10px; overflow:auto;">
         
            <div class="col-md-8 pull-Left" style="border-radius: 6px; background-color: white; height: 550px; top: 0px; left: 0px;width: 670px;">
                
                <br /> 

<table style="width: 462px; height: 1px;">
               
                <tr>
                    <td style="width: 1px; height: 1px; text-align: left">
                        &nbsp;</td>
                    <td style="text-align: left; width: 83px;" class="style1">
                        <asp:Label ID="LblCoopName3" runat="server" Visible="False">State</asp:Label>
                    </td>
                    <td style="width: 300px; height: 1px; text-align: left">
                        <asp:DropDownList ID="DrpState" runat="server" AutoPostBack="True" class="form-control input-lg" Width="221px">
                        </asp:DropDownList>
                    </td>
                </tr>
                    <tr>
                        <td style="width: 1px; height: 1px; text-align: left">&nbsp;</td>
                        <td class="style1" style="text-align: left; width: 83px;">
                            <asp:Label ID="LblCoopName2" runat="server" Visible="False">Status</asp:Label>
                        </td>
                        <td style="width: 300px; height: 1px; text-align: left">
                            <asp:DropDownList ID="DrpStatus" runat="server" class="form-control input-lg">
                                <asp:ListItem Value="0">==Select Email Status==</asp:ListItem>
                                <asp:ListItem>Mail Sent</asp:ListItem>
                                <asp:ListItem>Activated</asp:ListItem>
                                <asp:ListItem>Approved</asp:ListItem>
                               <asp:ListItem>Data Migrated</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td style="width: 1px; height: 1px; text-align: left">&nbsp;</td>
                    <td class="style1" style="text-align: left; width: 83px;">
                        <asp:Label ID="LblCoopName1" runat="server" Visible="False">Date</asp:Label>
                    </td>
                    <td style="width: 300px; height: 1px; text-align: left"> 
                        
                        <asp:TextBox ID="txtstartdate" runat="server" autocomplete="off" 
                    MaxLength="14" class="form-control" Height="16px" Width="200px" Wrap="False"  Visible="False" />
               <%-- <ajaxToolkit:CalendarExtender ID="defaultCalendarExtender" runat="server" 
                    Format="dd-MM-yyyy" TargetControlID="txtstartdate" />--%>

                    </td>
                </tr>
                <tr>
                    <td style="width: 1px; height: 1px; text-align: left">&nbsp;</td>
                    <td class="style1" style="text-align: left; width: 83px;">&nbsp;</td>
                    <td style="width: 300px; height: 1px; text-align: left">
                        
 <asp:Button ID="ButSearch" runat="server" CssClass="btn btn-primary" Text="Search" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 1px; height: 1px; text-align: left">&nbsp;</td>
                    <td class="style1" style="text-align: left; width: 83px;">
                        <asp:Label ID="LblCoopName" runat="server" Visible="False">Name</asp:Label>
                    </td>
                    <td style="width: 300px; height: 1px; text-align: left">
                        <asp:Label ID="LblCoopName0" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr>
                        <td style="width: 1px; height: 1px; text-align: left">&nbsp;</td>
                        <td class="style1" style="text-align: left; width: 83px;">
                            <asp:Label ID="LblCoopId" runat="server" Visible="False">Reg Name</asp:Label>
                        </td>
                        <td style="width: 300px; height: 1px; text-align: left">
                            <asp:Label ID="LblCoopId0" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 1px; height: 1px; text-align: left">&nbsp;</td>
                        <td class="style1" style="text-align: left; width: 83px;">
                            <asp:Label ID="LblPhone" runat="server" Visible="False">Contact Person</asp:Label>
                        </td>
                        <td style="width: 300px; height: 1px; text-align: left">
                            <asp:Label ID="LblPhone0" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 1px; height: 1px; text-align: left">&nbsp;</td>
                        <td class="style1" style="text-align: left; width: 83px;">&nbsp;</td>
                        <td style="width: 300px; height: 1px; text-align: left">&nbsp;</td>
                </tr>
                    <tr>
                        <td style="width: 1px; height: 1px; text-align: left">&nbsp;</td>
                        <td class="style1" style="text-align: left; width: 83px;">&nbsp;</td>
                        <td style="width: 300px; height: 1px; text-align: left">
                            <asp:TextBox ID="TxtDataKey" runat="server" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                <tr>
                    <td style="width: 1px; height: 1px; text-align: left">
                    </td>
                    <td style="text-align: left; width: 83px;" class="style1">
                        </td>
                    <td style="width: 300px; height: 1px; text-align: left">
                        <%--<asp:Button ID="Button1" runat="server" Text="Calculate" Cssclass="form-control" />--%>
                   <%--<asp:Button runat="server" ID="BtnCalculate" Text="Calculate" CssClass="btn btn-primary" BackColor="#FDC323" ForeColor = "White" CausesValidation="False" ToolTip="Loan Calculation"/>--%>
                
                 <asp:Button ID="ButAccept" runat="server" Text="Accept"  CssClass="btn btn-primary" Visible="False"  />
                 <asp:Button ID="ButCancel" runat="server" Text="Reject"  CssClass="btn btn-primary" Visible="False"/>
                        <asp:Label ID="lbl_id" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
                <br />


            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" DataKeyNames="Email" BorderColor="#E7E7FF" BorderStyle="Inset" BorderWidth="2px" CellPadding="3" Width="651px">
                     <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                     <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                     <HeaderStyle BackColor="#4A3C8C" ForeColor="#F7F7F7" />
                     <AlternatingRowStyle BackColor="#F7F7F7" />
                     <Columns>
                          <asp:BoundField DataField="Org_name" HeaderText="Cooperative" />
 
                          <asp:BoundField DataField="Statename" HeaderText="State" />
                                       <asp:BoundField DataField="Email" HeaderText="Email" />
                      <asp:BoundField DataField="CoopId" HeaderText="Reg No" />
                          <asp:BoundField DataField="Contact_person" HeaderText="Contact Person" />
                          <asp:BoundField DataField="Phone" HeaderText="Phone" />
                    <asp:BoundField DataField="Createdate" HeaderText="Date Applied" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:CommandField SelectText="View Request" ShowSelectButton="True">
                <ItemStyle Width="100px" />
                </asp:CommandField>
                       </Columns>
                 </asp:GridView>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

