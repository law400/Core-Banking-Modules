<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"    AutoEventWireup="false"   CodeFile="CreateCustomer.aspx.vb" Inherits="CustomerService_CreateCustomer" title="CustomerCreation Page" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
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
  <div class="box-blue">
        <div class="content">
            <table style="width: 581px">
                <tr>
                    <td style="width: 182px; height: 3px" valign="top">
                        &nbsp;</td>
                    <td style="height: 3px" valign="top">
                        <asp:RadioButtonList ID="RdBCustType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">Individual Customer</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td style="height: 3px; width: 182px;" valign="top">
                        Search Customer
                        <asp:HyperLink ID="hypsearch" runat="server" Height="20px" 
                            ImageUrl="~/Images/iconbar_previewtab_on.gif" Width="27px">HyperLink</asp:HyperLink>
                    </td>
                    <td style="height: 3px" valign="top">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 3px" valign="top">
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <div style="text-align: left">
                                    <table style="width: 583px">
                                        <tr>
                                            <td colspan="4" style="height: 27px">
                                            <div class="box-blue">
                            <h2>
                                <span style="color: #ffffff"><strong>Create New Customer</strong></span></h2>
                        </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 19px">
                                            </td>
                                            <td style="width: 136px; height: 19px">
                                            </td>
                                            <td style="width: 149px; height: 19px">
                                            </td>
                                            <td style="width: 100px; height: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 19px;">
                                                Title</td>
                                            <td style="width: 136px; height: 19px;">
                                                <asp:DropDownList ID="DrpTitle" runat="server" Font-Size="Small" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                            <td style="width: 149px; height: 19px;">
                                                Surname *</td>
                                            <td style="width: 100px; height: 19px;">
                                                <asp:TextBox ID="txtSurname" runat="server" Font-Size="Small" Width="146px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 11px;">
                                                Firstname *</td>
                                            <td style="width: 136px; height: 11px;">
                                                <asp:TextBox ID="txtFirstname" runat="server" Font-Size="Small" Width="149px"></asp:TextBox>
                                                </td>
                                            <td style="width: 149px; height: 11px;">
                                                Middle Name</td>
                                            <td style="width: 100px; height: 11px;">
                                                <asp:TextBox ID="txtOthername" runat="server" Font-Size="Small" Width="149px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 16px">
                                                Date Of Birth*</td>
                                            <td style="width: 136px; height: 16px">
                                                <asp:TextBox ID="txtDOB" runat="server" Font-Size="Small" Width="82px"></asp:TextBox><asp:HyperLink ID="imgdate1" runat="server" ImageUrl="~/Images/pdate.gif" Width="17px">HyperLink</asp:HyperLink>
                                                </td>
                                            <td style="width: 149px; height: 16px">
                                                Sex *</td>
                                            <td style="width: 100px; height: 16px">
                                                <asp:DropDownList ID="DrpSex" runat="server" Font-Size="Small" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px">
                                                Nationality *</td>
                                            <td style="width: 136px">
                                                <asp:DropDownList ID="DrpNational" runat="server" Font-Size="Small" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                            <td style="width: 149px">
                                                Education Level</td>
                                            <td style="width: 100px">
                                                <asp:DropDownList ID="DrpEdu" runat="server" Font-Size="Small" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 17px">
                                                State Of Origin*</td>
                                            <td style="width: 136px; height: 17px">
                                                &nbsp;</td>
                                            <td style="width: 149px; height: 17px">
                                                Business/Ocupation</td>
                                            <td style="width: 100px; height: 17px">
                                                <asp:DropDownList ID="DrpOccupation" runat="server" Font-Size="Small" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 17px;">
                                                &nbsp;</td>
                                            <td style="width: 136px; height: 17px">
                                                <asp:DropDownList ID="DrpState" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 149px; height: 17px">
                                                Sector</td>
                                            <td style="width: 100px; height: 17px">
                                                <asp:DropDownList ID="Drpsector" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; ">
                                                Resident Address*</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtAddress" runat="server" Font-Size="Medium" Height="47px" 
                                                    TextMode="MultiLine" Width="420px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 18px;">
                                                Resident State*</td>
                                            <td style="width: 136px; height: 18px;">
                                                <asp:DropDownList ID="DrpResState" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 149px; height: 18px;">
                                                Resident City/Town*</td>
                                            <td style="width: 100px; height: 18px;">
                                                <asp:DropDownList ID="DrpTown" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px">
                                                Office Phone</td>
                                            <td style="width: 136px">
                                                                                                            <asp:TextBox ID="txtphone3" runat="server" Font-Size="Small" Width="122px" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>

                                            </td>
                                            <td style="width: 149px">
                                                Home Phone</td>
                                            <td style="width: 100px">
                                                                                                           <asp:TextBox ID="Txtphone4" runat="server" Font-Size="Small" Width="122px" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; ">
                                                Office Address</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtAddress0" runat="server" Font-Size="Medium" Height="47px" 
                                                    TextMode="MultiLine" Width="420px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; ">
                                                Next Of Kin Phone</td>
                                            <td style="width: 136px; ">
                                                            <asp:TextBox ID="Txtkinphone" runat="server" Font-Size="Small" Width="122px" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                                            </td>
                                            <td style="width: 149px; ">
                                                Next Of Kin Address</td>
                                            <td style="width: 100px; ">
                                                <asp:TextBox ID="txtKinAddress" runat="server" Font-Size="Small" Width="146px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; ">
                                                Mobile Phone1 *</td>
                                            <td style="width: 136px; ">
                                                            <asp:TextBox ID="txtphone1" runat="server" Font-Size="Small" Width="122px" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                                            </td>
                                            <td style="width: 149px; ">
                                                Mobile Phone2</td>
                                            <td style="width: 100px; ">
                                                            <asp:TextBox ID="Txtphone2" runat="server" Font-Size="Small" Width="122px" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 16px">
                                                ID Type*</td>
                                            <td style="width: 136px; height: 16px">
                                                <asp:DropDownList ID="DrpIdType" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 149px; height: 16px">
                                                ID No*</td>
                                            <td style="width: 100px; height: 16px">
                                                <asp:TextBox ID="txtIdNo" runat="server" Font-Size="Small" Width="147px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 16px">
                                                ID Issue Date*</td>
                                            <td style="width: 136px; height: 16px">
                                                <asp:TextBox ID="txtIssue" runat="server" Font-Size="Small" Width="89px"></asp:TextBox>
                                                <asp:HyperLink ID="imgdate2" runat="server" ImageUrl="~/Images/pdate.gif" 
                                                    Width="17px">HyperLink</asp:HyperLink>
                                                <asp:CompareValidator ID="CompareValidator11" runat="server" 
                                                    ControlToValidate="txtIssue" Display="Dynamic" 
                                                    ErrorMessage="Date Format Incorrect" Operator="DataTypeCheck" Type="Date" 
                                                    ValidationGroup="News1" Width="147px">Date Format Incorrect</asp:CompareValidator>
                                            </td>
                                            <td style="width: 149px; height: 16px">
                                                ID Expiry Date*</td>
                                            <td style="width: 100px; height: 16px">
                                                <asp:TextBox ID="txtExpirydate" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" Width="72px"></asp:TextBox>
                                                <asp:HyperLink ID="imgdate3" runat="server" ImageUrl="~/Images/pdate.gif" 
                                                    Width="17px">HyperLink</asp:HyperLink>
                                                <asp:CompareValidator ID="CompareValidator10" runat="server" 
                                                    ControlToValidate="txtExpirydate" Display="Dynamic" 
                                                    ErrorMessage="Date Format Incorrect" Operator="DataTypeCheck" Type="Date" 
                                                    ValidationGroup="News1" Width="147px">Date Format Incorrect</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 33px">
                                                Email Address</td>
                                            <td style="width: 136px; height: 33px">
                                                <asp:TextBox ID="txtemail" runat="server" Font-Size="Small" Width="145px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                    ControlToValidate="txtemail" Display="Dynamic" 
                                                    ErrorMessage="enter email correctly" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                    Width="176px">enter email correctly</asp:RegularExpressionValidator>
                                            </td>
                                            <td style="width: 149px; height: 33px">
                                                Name Of Next Of Kin</td>
                                            <td style="width: 100px; height: 33px">
                                                <asp:TextBox ID="txtnextofKin" runat="server" Font-Size="Small"
                                                    Width="147px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 16px">
                                                Referrer Name</td>
                                            <td style="width: 136px; height: 16px">
                                                <asp:TextBox ID="txtrefname" runat="server" Font-Size="Small" Width="145px"></asp:TextBox>
                                            </td>
                                            <td style="width: 149px; height: 16px">
                                                Referrer Phone</td>
                                            <td style="width: 100px; height: 16px">
                                                <asp:TextBox ID="txtRefphone" runat="server" Font-Size="Small" 
                                                    onkeyup="ValidateText(this);" onpaste="return false;" Width="122px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 17px">
                                                <asp:CheckBox ID="ChkGroup" runat="server" AutoPostBack="True" 
                                                    Text="Is Customer a Member Of a Group?" Width="154px" />
                                            </td>
                                            <td style="width: 136px; height: 17px">
                                                <asp:DropDownList ID="DrpGroup" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" Visible="False">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 149px; height: 17px">
                                                <asp:CheckBox ID="chksms2" runat="server" AutoPostBack="True" 
                                                    Text="Requires EMail Alert" />
                                            </td>
                                            <td style="width: 100px; height: 17px">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 179px; height: 16px">
                                                Introducer</td>
                                            <td style="width: 136px; height: 16px">
                                                <asp:DropDownList ID="DrpIntro" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small">
                                                    <asp:ListItem Selected="True" Value="0">--Select Introducer--</asp:ListItem>
                                                    <asp:ListItem Value="1">Staff</asp:ListItem>
                                                    <asp:ListItem Value="2">Customer</asp:ListItem>
                                                    <asp:ListItem Value="3">Others</asp:ListItem>
                                                </asp:DropDownList>
                                                </td>
                                            <td style="height: 16px; width: 149px;">
                                                Introducer ID</td>
                                            <td style="width: 100px; height: 16px">
                                                <asp:TextBox ID="txtIntroID" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" Width="71px" MaxLength="10"></asp:TextBox>
                                                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 17px; width: 179px;">
                                                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
                                                    Text="Is Customer a Signatory to Another Account?" Width="154px" />
                                            </td>
                                            <td style="height: 17px" colspan="2">
                                                <asp:Label ID="Label7" runat="server" Text="Account Number" Visible="False"></asp:Label>
                                                :
                                                <asp:TextBox ID="txtsignacct" runat="server" AutoPostBack="True" 
                                                    Visible="False" Width="175px"></asp:TextBox>
                                                <asp:Label ID="Label8" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td style="width: 100px; height: 17px">
                                                <asp:CheckBox ID="chkStaffType" runat="server" AutoPostBack="True" 
                                                    Text="Is Customer a Staff?" TextAlign="Left" Width="160px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 16px; width: 179px;">
                                                Account Officer</td>
                                            <td style="width: 136px; height: 16px">
                                                <asp:TextBox ID="txtOfficer" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" Width="71px"></asp:TextBox>
                                                <asp:Label ID="Label2" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                                <asp:HyperLink ID="HypSearch0" runat="server" 
                                                    ImageUrl="~/Images/iconbar_previewtab.gif"></asp:HyperLink>
                                            </td>
                                            <td style="height: 16px; width: 149px;">
                                                <asp:CheckBox ID="chksms" runat="server" AutoPostBack="True" 
                                                    Text="Requires SMS Alert" />
                                                </td>
                                            <td style="width: 100px; height: 16px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 17px; width: 179px;">
                                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                                    Text="Is Customer Related to another Customer in the Bank?" Width="154px" />
                                            </td>
                                            <td colspan="2" style="height: 17px">
                                            </td>
                                            <td style="width: 100px; height: 17px">
                                                &nbsp;</td>
                                            <td style="height: 16px; width: 179px;">
                                            </td>
                                            <td style="width: 136px; height: 16px">
                                            </td>
                                            <td style="height: 16px">
                                                <asp:Label ID="Label5" runat="server" Text="CustomerID" Visible="False"></asp:Label>
                                                &nbsp;:<asp:TextBox ID="txtcustid" runat="server" AutoPostBack="True" MaxLength="10" 
                                                    Visible="False" Width="96px"></asp:TextBox><asp:Label ID="Label6" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><asp:DropDownList ID="DrpRela" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" Visible="False">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 16px; text-align: center;" colspan="4">
                                                <asp:TextBox ID="txtnone" runat="server" Visible="False"></asp:TextBox>
                                                <asp:Button ID="Btnsubmit" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                                    ForeColor="Black" Text="Submit" ValidationGroup="News1" Width="58px" />
                                                <asp:Button ID="Button1" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                                    ForeColor="Black" Text="Reset" Width="62px" />
                                                <asp:Button ID="Btncancel" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                                    ForeColor="Black" Text="Return" Width="62px" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div style="text-align: left">
                                    <table style="width: 583px">
                                        <tr>
                                            <td colspan="4" style="height: 27px">
                                                <div class="box-blue">
                                                    <h2>
                                                        <span style="color: #ffffff"><strong>Corporate Customer</strong></span></h2>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px; height: 16px;">
                                                Company RegNo *</td>
                                            <td style="width: 119px; height: 16px;">
                                                <asp:TextBox ID="txtcompRegno" runat="server" Font-Size="Small" Width="84px"></asp:TextBox>
                                                </td>
                                            <td style="width: 335px; height: 16px;">
                                                Company Name *</td>
                                            <td style="width: 100px; height: 16px;">
                                                <asp:TextBox ID="txtCompname" runat="server" Font-Size="Small" Width="149px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px; height: 16px">
                                                Date Of Registration*</td>
                                            <td style="width: 119px; height: 16px">
                                                <asp:TextBox ID="txtcompDateReg" runat="server" Font-Size="Small" Width="82px"></asp:TextBox><asp:HyperLink
                                                    ID="HyperLink1" runat="server" ImageUrl="~/Images/pdate.gif" Width="17px">HyperLink</asp:HyperLink>
                                                <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="txtcompDateReg"
                                                    Display="Dynamic" ErrorMessage="Date Format Incorrect" Operator="DataTypeCheck"
                                                    Type="Date" ValidationGroup="News1" Width="147px">Date Format Incorrect</asp:CompareValidator></td>
                                            <td style="width: 335px; height: 16px">
                                                Company Sector</td>
                                            <td style="width: 100px; height: 16px">
                                                <asp:DropDownList ID="DrpcompSector" runat="server" Font-Size="Small" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px">
                                                Country Of Incorporation</td>
                                            <td style="width: 119px">
                                                <asp:DropDownList ID="DrpcompCountry" runat="server" Font-Size="Small" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                            <td style="width: 335px">
                                                State Of Incorporation</td>
                                            <td style="width: 100px">
                                                <asp:DropDownList ID="DrpcompStateInc" runat="server" Font-Size="Small" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px">
                                                Company Town</td>
                                            <td style="width: 119px">
                                                <asp:DropDownList ID="DrpCompTown" runat="server" Font-Size="Small" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                            <td style="width: 335px">
                                            </td>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px">
                                                Company Address *</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtCompaddr" runat="server" Font-Size="Medium" Height="45px" TextMode="MultiLine"
                                                    Width="420px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px">
                                                Contact Person</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtcontactperson" runat="server" Font-Size="Small" 
                                                    Width="417px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px; ">
                                                Office Phone1 *</td>
                                            <td style="width: 119px; ">
                                                            <asp:TextBox ID="Txtcomephone1" runat="server" Font-Size="Small" Width="122px" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                                                <br />
                                                </td>
                                            <td style="width: 335px; ">
                                                Office Phone2</td>
                                            <td style="width: 100px; ">
                                                            <asp:TextBox ID="Txtcomephone2" runat="server" Font-Size="Small" Width="122px" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px; height: 26px;">
                                                Office Phone3</td>
                                            <td style="width: 119px; height: 26px;">
                                                            <asp:TextBox ID="Txtcomephone3" runat="server" Font-Size="Small" Width="122px" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                                            </td>
                                            <td style="width: 335px; height: 26px;">
                                                Office Phone4</td>
                                            <td style="width: 100px; height: 26px;">
                                                            <asp:TextBox ID="Txtcomephone4" runat="server" Font-Size="Small" Width="122px" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px; height: 35px">
                                                Email Address</td>
                                            <td style="width: 119px; height: 35px">
                                                <asp:TextBox ID="txtcompemail" runat="server" Font-Size="Small" Width="145px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                    ControlToValidate="txtcompemail" Display="Dynamic" 
                                                    ErrorMessage="enter email correctly" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                    ValidationGroup="News2" Width="176px">enter email correctly</asp:RegularExpressionValidator>
                                            </td>
                                            <td style="width: 335px; height: 35px">
                                                Introducer</td>
                                            <td style="width: 100px; height: 35px">
                                                <asp:DropDownList ID="drpintro2" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small">
                                                    <asp:ListItem Selected="True" Value="0">--Select Introducer--</asp:ListItem>
                                                    <asp:ListItem Value="1">Staff</asp:ListItem>
                                                    <asp:ListItem Value="2">Customer</asp:ListItem>
                                                    <asp:ListItem Value="3">Others</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px; height: 16px">
                                                Account Officer</td>
                                            <td style="width: 119px; height: 16px">
                                                <asp:TextBox ID="txtCompOffc" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" Width="71px" MaxLength="10"></asp:TextBox>
                                                <asp:Label ID="Label4" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                                <asp:HyperLink ID="HypSearch1" runat="server" 
                                                    ImageUrl="~/Images/iconbar_previewtab.gif"></asp:HyperLink>
                                            </td>
                                            <td style="width: 335px; height: 16px">
                                                Introducer ID</td>
                                            <td style="width: 100px; height: 16px">
                                                <asp:TextBox ID="txtCompintro" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" Width="71px" MaxLength="10"></asp:TextBox>
                                                <asp:Label ID="Label3" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px; height: 16px">
                                                <asp:CheckBox ID="ChkGroup0" runat="server" AutoPostBack="True" 
                                                    Text="Is Customer a Member Of a Group?" Width="154px" />
                                            </td>
                                            <td style="width: 119px; height: 16px">
                                                <asp:DropDownList ID="DrpGroup0" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" Visible="False">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 335px; height: 16px">
                                                <asp:CheckBox ID="chksms0" runat="server" AutoPostBack="True" 
                                                    Text="Requires SMS Alert" />
                                            </td>
                                            <td style="width: 100px; height: 16px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="height: 16px; width: 350px;">
                                                &nbsp;</td>
                                            <td style="width: 119px; height: 16px">
                                                &nbsp;</td>
                                            <td style="width: 335px; height: 16px">
                                                <asp:CheckBox ID="chksms1" runat="server" AutoPostBack="True" 
                                                    Text="Requires EMail Alert" />
                                            </td>
                                            <td style="width: 100px; height: 16px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="height: 16px; width: 350px;">
                                            </td>
                                            <td style="width: 119px; height: 16px">
                                            </td>
                                            <td style="width: 335px; height: 16px">
                                            </td>
                                            <td style="width: 100px; height: 16px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="height: 16px; text-align: center">
                                                <asp:Button ID="BtnSubmit2" runat="server" BackColor="#C0C0FF" 
                                                    Font-Size="Small" ForeColor="Black" Text="Submit" ValidationGroup="News2" 
                                                    Width="58px" />
                                                <asp:Button ID="Button2" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                                    ForeColor="Black" Text="Reset" Width="62px" />
                                                <asp:Button ID="BtnClose" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                                    ForeColor="Black" Text="Return" Width="62px" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:View>
                        </asp:MultiView></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 3px" valign="top">
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 19px; text-align: center;">
                        </td>
                </tr>
            </table>
        </div>
    </div> 
    </ContentTemplate> 
    </asp:UpdatePanel>  
     <script type="text/javascript">
    function ValidateText(obj)
    {
        if(obj.value.length>0)
        {
             obj.value = obj.value.replace(/[^\d]+/g, '');
        }
    }
   </script>
</asp:Content>

