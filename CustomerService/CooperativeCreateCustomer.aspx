<%@ Page Title="" Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="CooperativeCreateCustomer.aspx.vb" Inherits="CustomerService_CooperativeCreateCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
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
                <asp:Label ID="LblEmployeeNo" runat="server" Visible="False"></asp:Label>
            </td>
            <td style="width: 72px; height: 13px;">
            </td>
            <td style="width: 101px; height: 13px;">
            </td>
            <td style="width: 95px; height: 13px;">
            </td>
        </tr>
                <tr>
                    <td colspan="4" style="height: 29px">
                        <table style="width: 581px">
                            <tr>
                                <td colspan="4" style="height: 3px" valign="top">
                                    <asp:MultiView ID="MultiView1" runat="server">
                                        <asp:View ID="View1" runat="server">
                                            <div style="text-align: left">
                                                <table style="width: 583px">
                                                    <tr>
                                                        <td colspan="4" style="height: 27px">
                                                            <div class="box-blue">
                                                                <h2>
                                                                    <span style="color: #ffffff"><strong>Individual Customer</strong></span></h2>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 19px">
                                                            Customer Type</td>
                                                        <td style="width: 136px; height: 19px">
                                                            <asp:DropDownList ID="DrpCustType" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small">
                                                                <asp:ListItem Selected="True" Value="0">--Select Customer Type</asp:ListItem>
                                                                <asp:ListItem Value="1">Individual</asp:ListItem>
                                                                <asp:ListItem Value="2">Corporate</asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;(Choose to Change Customer&nbsp; Type)</td>
                                                        <td style="width: 149px; height: 19px">
                                                        </td>
                                                        <td style="width: 100px; height: 19px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 19px">
                                                Title</td>
                                                        <td style="width: 136px; height: 19px">
                                                            <asp:DropDownList ID="DrpTitle" runat="server" AutoPostBack="True" Font-Size="Small">
                                                            </asp:DropDownList></td>
                                                        <td style="width: 149px; height: 19px">
                                                Surname *</td>
                                                        <td style="width: 100px; height: 19px">
                                                            <asp:TextBox ID="txtSurname" runat="server" Font-Size="Small" Width="146px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSurname"
                                                                Display="Dynamic" ErrorMessage="Enter Customer Surname" ValidationGroup="News1"
                                                                Width="145px">Enter Customer Surname</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 11px">
                                                Firstname *</td>
                                                        <td style="width: 136px; height: 11px">
                                                            <asp:TextBox ID="txtFirstname" runat="server" Font-Size="Small" Width="149px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstname"
                                                                Display="Dynamic" ErrorMessage="Enter Customer FirstName" ValidationGroup="News1"
                                                                Width="145px">Enter Customer FirstName</asp:RequiredFieldValidator></td>
                                                        <td style="width: 149px; height: 11px">
                                                Othername</td>
                                                        <td style="width: 100px; height: 11px">
                                                            <asp:TextBox ID="txtOthername" runat="server" Font-Size="Small" Width="149px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 16px">
                                                Date Of Birth</td>
                                                        <td style="width: 136px; height: 16px">
                                                            <asp:TextBox ID="txtDOB" runat="server" Font-Size="Small" Width="82px"></asp:TextBox><asp:HyperLink
                                                                ID="imgdate1" runat="server" ImageUrl="~/Images/pdate.gif" Width="17px">HyperLink</asp:HyperLink>
                                                            <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="txtDOB"
                                                                Display="Dynamic" ErrorMessage="Date Format Incorrect" Operator="DataTypeCheck"
                                                                Type="Date" ValidationGroup="News1" Width="147px">Date Format Incorrect</asp:CompareValidator></td>
                                                        <td style="width: 149px; height: 16px">
                                                Sex *</td>
                                                        <td style="width: 100px; height: 16px">
                                                            <asp:DropDownList ID="DrpSex" runat="server" AutoPostBack="True" Font-Size="Small">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px">
                                                Nationality *</td>
                                                        <td style="width: 136px">
                                                            <asp:DropDownList ID="DrpNational" runat="server" AutoPostBack="True" Font-Size="Small">
                                                            </asp:DropDownList></td>
                                                        <td style="width: 149px">
                                                Education Level</td>
                                                        <td style="width: 100px">
                                                            <asp:DropDownList ID="DrpEdu" runat="server" AutoPostBack="True" Font-Size="Small">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 17px">
                                                State Of Origin</td>
                                                        <td style="width: 136px; height: 17px">
                                                            <asp:DropDownList ID="DrpState" runat="server" AutoPostBack="True" Font-Size="Small">
                                                            </asp:DropDownList></td>
                                                        <td style="width: 149px; height: 17px">
                                                Ocupation</td>
                                                        <td style="width: 100px; height: 17px">
                                                            <asp:DropDownList ID="DrpOccupation" runat="server" AutoPostBack="True" Font-Size="Small">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 17px;">
                                                            &nbsp;</td>
                                                        <td style="width: 136px; height: 17px">
                                                            &nbsp;</td>
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
                                                            Resident Address</td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtAddress" runat="server" Font-Size="Medium" Height="47px" 
                                                                TextMode="MultiLine" Width="420px"></asp:TextBox>
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
                                                        <td style="width: 179px; height: 18px;">
                                                            Resident State</td>
                                                        <td style="width: 136px; height: 18px;">
                                                            <asp:DropDownList ID="DrpResState" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 149px; height: 18px;">
                                                            Resident City/Town</td>
                                                        <td style="width: 100px; height: 18px;">
                                                            <asp:DropDownList ID="DrpTown" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; ">
                                                            Mobile Phone1 *</td>
                                                        <td style="width: 136px; ">
                                                            <asp:TextBox ID="txtPhone1" runat="server" Font-Size="Small" Width="145px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                                ControlToValidate="txtPhone1" Display="Dynamic" 
                                                                ErrorMessage="Enter Customer PhoneNo" ValidationGroup="News1" Width="145px">Enter 
                                                            Customer PhoneNo</asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                                ControlToValidate="txtPhone1" Display="Dynamic" 
                                                                ErrorMessage="Enter Only Numeric Values" Operator="DataTypeCheck" 
                                                                Type="Integer" ValidationGroup="News1">Enter Only Numeric Values</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 149px; ">
                                                            Mobile Phone2</td>
                                                        <td style="width: 100px; ">
                                                            <asp:TextBox ID="txtPhone2" runat="server" Font-Size="Small" Width="148px"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                                                ControlToValidate="txtPhone2" Display="Dynamic" 
                                                                ErrorMessage="Enter Only Numeric Values" Operator="DataTypeCheck" 
                                                                Type="Integer" ValidationGroup="News1" Width="148px">Enter Only Numeric 
                                                            Values</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; ">
                                                            Office Phone</td>
                                                        <td style="width: 136px; ">
                                                            <asp:TextBox ID="txtphone3" runat="server" Font-Size="Small" Width="145px"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator3" runat="server" 
                                                                ControlToValidate="txtphone3" Display="Dynamic" 
                                                                ErrorMessage="Enter Only Numeric Values" Operator="DataTypeCheck" 
                                                                Type="Integer" ValidationGroup="News1">Enter Only Numeric Values</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 149px; ">
                                                            Home Phone</td>
                                                        <td style="width: 100px; ">
                                                            <asp:TextBox ID="txtPhone4" runat="server" Font-Size="Small" Width="147px"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator4" runat="server" 
                                                                ControlToValidate="txtPhone4" Display="Dynamic" 
                                                                ErrorMessage="Enter Only Numeric Values" Operator="DataTypeCheck" 
                                                                Type="Integer" ValidationGroup="News1" Width="145px">Enter Only Numeric 
                                                            Values</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 33px;">
                                                            email Address</td>
                                                        <td style="width: 136px; height: 33px;">
                                                            <asp:TextBox ID="txtemail" runat="server" Font-Size="Small" Width="145px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                                ControlToValidate="txtemail" Display="Dynamic" 
                                                                ErrorMessage="enter email correctly" 
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                                Width="176px">enter email correctly</asp:RegularExpressionValidator>
                                                        </td>
                                                        <td style="width: 149px; height: 33px;">
                                                            Next Of Kin</td>
                                                        <td style="width: 100px; height: 33px;">
                                                            <asp:TextBox ID="txtnextofKin" runat="server" Font-Size="Small" Width="147px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; ">
                                                            Next Of Kin Phone</td>
                                                        <td style="width: 136px; ">
                                                            <asp:TextBox ID="txtKinphone" runat="server" Font-Size="Small" Width="113px"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 149px; ">
                                                            Next Of Kin Address</td>
                                                        <td style="width: 100px; ">
                                                            <asp:TextBox ID="txtKinAddress" runat="server" Font-Size="Small" Width="146px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 26px">
                                                            ID Type</td>
                                                        <td style="width: 136px; height: 26px">
                                                            <asp:DropDownList ID="DrpIdType" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 149px; height: 26px">
                                                            ID No</td>
                                                        <td style="width: 100px; height: 26px">
                                                            <asp:TextBox ID="txtIdNo" runat="server" Font-Size="Small"
                                                                Width="147px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 16px">
                                                            ID Issue Date</td>
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
                                                            Expiry Date</td>
                                                        <td style="width: 100px; height: 16px">
                                                            <asp:TextBox ID="txtExpirydate" runat="server" 
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
                                                        <td style="width: 149px; height: 16px">
                                                            Introducer ID</td>
                                                        <td style="width: 100px; height: 16px">
                                                            <asp:TextBox ID="txtIntroID" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" Width="71px"></asp:TextBox>
                                                            <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 16px">
                                                            Account Officer</td>
                                                        <td style="width: 136px; height: 16px">
                                                            <asp:TextBox ID="txtOfficer" runat="server" Font-Size="Small" Width="71px" 
                                                                AutoPostBack="True"></asp:TextBox>
                                                            <asp:Label ID="Label2" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                                            <asp:HyperLink ID="HypSearch1" runat="server" 
                                                                ImageUrl="~/Images/iconbar_previewtab.gif"></asp:HyperLink>
                                                        </td>
                                                        <td style="width: 149px; height: 16px">
                                                            <asp:CheckBox ID="chksms" runat="server" AutoPostBack="True" 
                                                                Text="Requires SMS Alert" />
                                                        </td>
                                                        <td style="width: 100px; height: 16px">
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 16px">
                                                            Referrer Name</td>
                                                        <td style="width: 136px; height: 16px">
                                                            <asp:TextBox ID="txtrefname" runat="server" Font-Size="Small" Width="145px"></asp:TextBox>
                                                        </td>
                                                        <td style="height: 16px; width: 149px;">
                                                            Referrer Phone</td>
                                                        <td style="width: 100px; height: 16px">
                                                            <asp:TextBox ID="txtrefphone" runat="server" Font-Size="Small" Width="145px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 179px; height: 17px">
                                                            <asp:CheckBox ID="ChkGroup" runat="server" AutoPostBack="True" 
                                                                Text="Is Customer a Memeber Of a Group?" 
                                                                Width="154px" />
                                                        </td>
                                                        <td style="width: 136px; height: 17px">
                                                            <asp:DropDownList ID="DrpGroup" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" Visible="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="height: 17px; width: 149px;">
                                                        </td>
                                                        <td style="width: 100px; height: 17px">
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
                                                        </td>
                                                        <td style="height: 17px; width: 100px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 17px; width: 179px;">
                                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                                                Text="Does Customer Have a Relation with an Account in the Bank?" 
                                                                Width="154px" />
                                                        </td>
                                                        <td colspan="2" style="height: 17px">
                                                            <asp:Label ID="Label5" runat="server" Text="CustomerID" Visible="False"></asp:Label>
                                                            :
                                                            <asp:TextBox ID="txtcustid" runat="server" AutoPostBack="True" Visible="False" 
                                                                Width="96px"></asp:TextBox>
                                                            <asp:DropDownList ID="DrpRela" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" Visible="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="height: 17px; width: 100px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 16px; width: 179px;">
                                                        </td>
                                                        <td style="width: 136px; height: 16px">
                                                        </td>
                                                        <td colspan="2" style="height: 16px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 16px; width: 179px;">
                                                        </td>
                                                        <td style="width: 136px; height: 16px">
                                                        </td>
                                                        <td colspan="2" style="height: 16px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="height: 16px; text-align: center">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </asp:View>
                                    </asp:MultiView></td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 3px" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 19px; text-align: center">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 29px; text-align: center;">
                        &nbsp;<asp:Button ID="BtnSubmit" runat="server" BackColor="#C0C0FF" Font-Size="Small"
                            ForeColor="Black" Text="Submit" ValidationGroup="News1" Width="58px" /><asp:Button
                                ID="BtnCancel" runat="server" BackColor="#C0C0FF" Font-Size="Small" ForeColor="Black"
                                Text="Return" Width="62px" /></td>
                </tr>
            </table>
        </div>
    </div>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>
