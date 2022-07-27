<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrintCustInfo.aspx.vb" Inherits="CustomerService_trying" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
    function Button1_onclick() {
        //var a = window.open ('','','left =' + screen.width + ',top=' + screen.height + ',width=0,height=0,toolbar=0,scrollbars=0,status=0');
        var a = window.open('', '', 'left =100,top=100,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
        a.document.write(document.getElementById('<%= panel3.ClientID %>').innerHTML);
        a.document.close();
        a.focus();
        a.print();
        a.close();
        return false;
    }
    function Button2_onclick() {
        //var a = window.open ('','','left =' + screen.width + ',top=' + screen.height + ',width=0,height=0,toolbar=0,scrollbars=0,status=0');
        var a = window.open('', '', 'left =100,top=100,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
        a.document.write(document.getElementById('<%= panel8.ClientID %>').innerHTML);
        a.document.close();
        a.focus();
        a.print();
        a.close();
        return false;
    }
    function calendarPicker(strTxtRef) {
        window.open('./Controls/Calendar.aspx?field=' + strTxtRef + '', 'calendarPopup', 'titlebar=no,left=50,top=100,width=300,height=250,resizable=no');
    }
    function calculator(strTxtRef) {
        window.open('./Controls/calculator.aspx?field=' + strTxtRef + '', 'calendarPopup', 'titlebar=yes,left=50,top=100,width=400,height=550,resizable=no');
    }

    function accountPicker(strTxtRef) {
        window.open('./AccountEnquiry.aspx?field=' + strTxtRef + '', 'accountPopup', 'titlebar=no,left=50,top=100,width=650,height=500,resizable=no');
    }

    function accountGLPicker(strTxtRef) {
        window.open('./GLCustEnquiry.aspx?field=' + strTxtRef + '', 'accountPopup', 'titlebar=no,left=50,top=100,width=650,height=600,resizable=no');
    }
    function glaccountPicker(strTxtRef) {
        window.open('./glEnquiry.aspx?field=' + strTxtRef + '', 'accountPopup', 'titlebar=no,left=50,top=100,width=550,height=600,resizable=no');
    }
    function loandetail(strTxtRef) {
        window.open('./loandetail.aspx?field=' + strTxtRef + '', 'accountPopup', 'titlebar=no,left=800,top=100,width=500,height=700,resizable=no');
    }
    function TDdetail(strTxtRef) {
        window.open('./TDdetail.aspx?field=' + strTxtRef + '', 'accountPopup', 'titlebar=no,left=800,top=100,width=500,height=700,resizable=no');
    }



    function Chgdetail(strTxtRef) {
        window.open('./Chargedet1.aspx?field=' + strTxtRef + '', 'accountPopup', 'titlebar=no,left=-10,top=50,width=400,height=500,resizable=no');
    }

    function acctdetail(strTxtRef) {
        window.open('./AccountHist.aspx?field=' + strTxtRef + '', 'accountPopup', 'titlebar=no,left=50,top=100,width=650,height=500,resizable=no');
    }

    function Chgdetail2(strTxtRef) {
        window.open('./Chargedet1.aspx?field=' + strTxtRef + '', 'accountPopup', 'titlebar=no,left=900,top=50,width=400,height=300,resizable=no');
    }

    function staff(strTxtRef) {
        window.open('./staffenqry.aspx?field=' + strTxtRef + '', 'staffPopup', 'titlebar=no,left=50,top=100,width=700,height=400,resizable=no');
    }


    function customer(strTxtRef) {
        window.open('./custenquiry.aspx?field=' + strTxtRef + '', 'staffPopup', 'titlebar=no,scroll=true,left=50,top=100,width=700,height=600,resizable=no');
    }
    function authPicker2(strTxtRef) {
        window.open('./Authorise.aspx?field=' + strTxtRef + '', 'authorisePopup', 'titlebar=no,left=50,top=100,width=650,height=450,resizable=no');
    }

    function interestPicker(strTxtRef) {
        window.open('./interesthist.aspx?id=' + strTxtRef + '', 'interestPopup', 'titlebar=no,left=50,top=100,width=650,height=450,resizable=no');
    }

    function authPicker(strTxtRef) {
        window.open('./Override.aspx?field=' + strTxtRef + '', 'authorisePopup', 'titlebar=no,left=50,top=100,width=250,height=250,resizable=no');
    }


    function payPicker(strTxtRef) {
        window.open('./pointing.aspx?field=' + strTxtRef + '', 'authorisePopup', 'titlebar=no,left=50,top=100,width=250,height=250,resizable=no');
    }	

    
</script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style6
        {
            font-family: "Courier New", Courier, monospace;
            font-size: small;
        }
        .style8
        {
            font-family: "Courier New", Courier, monospace;
            font-size: small;
        }
        .style23
        {
            font-family: "Courier New", Courier, monospace;
            font-size: small;
        }
        .style27
        {
            font-family: "Courier New", Courier, monospace;
            font-size: small;
        }
        .style28
        {
            width: 390px;
        }
        .style30
        {
            font-family: "Courier New", Courier, monospace;
            font-size: small;
            width: 290px;
        }
        .style32
        {
        }
        .style33
        {
            width: 192px;
        }
        .style34
        {
            width: 523px;
        }
        .style35
        {
            width: 248px;
        }
        .style36
        {
            width: 243px;
            font-family: "Courier New", Courier, monospace;
            font-size: small;
        }
        .style37
        {
            width: 203px;
            font-family: "Courier New", Courier, monospace;
            font-size: small;
        }
        .style43
        {
        }
        .style44
        {
            width: 531px;
        }
        .style47
        {
            width: 214px;
        }
        .style48
        {
            width: 258px;
        }
th {
	background: #e7e6e6 url('../button.jpg') repeat-x;
	height: 29px;
	padding-left: 12px;
	padding-right: 12px;	
	text-align: left;
	border-left: 1px solid #f4f4f4;
	border-bottom: solid 2px #fff;
	color: #333;
}

a
{
	color: #000000;
	margin-left: 0px;
}

        .style50
        {
            width: 215px;
        }
        .style54
        {
            width: 272px;
        }
        .style55
        {
            width: 216px;
            font-family: "Courier New", Courier, monospace;
            font-size: small;
        }
        #Button1
        {
            width: 98px;
        }
        .style56
        {
            font-family: "Courier New", Courier, monospace;
            font-size: small;
            width: 258px;
        }
        .style57
        {
            width: 273px;
        }
        #Button2
        {
            width: 98px;
        }
        .style58
        {
            width: 265px;
        }
        .style51
        {
            width: 427px;
        }
        .style52
        {
            font-family: "Courier New", Courier, monospace;
            color: #000066;
        }
        .style59
        {
            width: 81px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <table class="style1">
                <tr>
                    <td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label89" runat="server" Font-Bold="True" Font-Size="Large" 
                            Text="PRINT CUSTOMER INFORMATION"></asp:Label>
                    </td>
                </tr>
            </table>
    
            <table class="style1">
                <tr>
                    <td class="style51">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button
                                ID="BtnCancel" runat="server" BackColor="#C0C0FF" Font-Size="Small" ForeColor="Black"
                                Text="Return" Width="62px" />&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style51">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        <span class="style52">
                        <b>Account Number</b>&nbsp;</span></td>
                    <td>
                        <asp:TextBox ID="txtAcctNo" runat="server" AutoPostBack="True" 
                            Font-Size="Small" Width="93px"></asp:TextBox>
                        &nbsp;
                        <asp:HyperLink ID="Hypsearch" runat="server" 
                            ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Panel6" runat="server" Visible="False">
                <asp:Panel ID="Panel3" runat="server" BorderColor="#333333" 
            BorderStyle="Double">
                    <br />
                    <table class="style1">
                        <tr>
                            <td class="style59" rowspan="2">
                                <asp:Image ID="Image5" runat="server" Height="87px" 
                                    ImageUrl="~/Images/LogochevronNew.jpg" Width="73px" />
                            </td>
                            <td>
                                <asp:Label ID="Label90" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                    Font-Size="Large" ForeColor="#000042" style="font-family: Tahoma" 
                                    Text="CEMCS MICROFINANCE BANK LIMITED"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <div style="background-color: #DDDDFF">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label91" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                            Font-Size="Medium" ForeColor="#000042" style="font-family: Tahoma" 
                            Text="INDIVIDUAL ACCOUNT OPENING FORM"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" Font-Size="Small" Height="42px" PageSize="1" 
                        style="margin-left: 564px" Width="176px">
                        <PagerSettings FirstPageText="First" LastPageText="Last" 
                            Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Height="139px" 
                                        ImageUrl='<%# "Handler.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber") %>' 
                                        Width="139px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    &nbsp;&nbsp;&nbsp;<asp:Panel ID="Panel4" runat="server" BackColor="#DDDDFF">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                            ForeColor="#000066" style="font-family: Tahoma" Text="CUSTOMER INFORMATION"></asp:Label>
                    </asp:Panel>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label56" runat="server" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Small" ForeColor="#000066" 
                        Text="ACCOUNT NUMBER:"></asp:Label>
                    <asp:Label ID="Lbl_AcctNo" runat="server" Font-Bold="True" 
                        Font-Names="Courier New" Font-Size="Small"></asp:Label>
                    &nbsp;<table cellpadding="4" class="style1">
                        <tr>
                            <td class="style2" colspan="2" style="border-style: solid; border-width: thin">
                                &nbsp;<asp:Label ID="Label3" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Customer Type:" 
                                    Font-Bold="True"></asp:Label><asp:Label 
                                    ID="Lbl_Type" runat="server" Font-Names="Courier New" Font-Size="Small"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td class="style2" colspan="2" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label55" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Type of Account:" 
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_Product" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border-style: solid; border-width: thin">
                            <td class="style32" colspan="4" style="border-style: solid; border-width: thin">
                                &nbsp;<asp:Label ID="Label4" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Title:" Font-Bold="True"></asp:Label><asp:Label 
                                    ID="Lbl_Title" runat="server" Font-Names="Courier New" Font-Size="Small"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label35" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Surname:" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_Surname" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label6" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="First Name:" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_first" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label32" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Other Names:" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_other" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style33" style="border-style: solid; border-width: thin">
                                &nbsp;
                                <asp:Label ID="Label33" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Sex:" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_sex" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td class="style55" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label36" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Date of Birth:" 
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_DOB" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td class="style23" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label37" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Nationality:" Font-Bold="True"></asp:Label>
                                &nbsp;<asp:Label ID="Lbl_Nat" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label></td>
                            <td class="style27" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label34" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="State of Origin:" 
                                    Font-Bold="True"></asp:Label>
                                &nbsp;<asp:Label ID="Lbl_Sta" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label></td>
                        </tr>
                    </table>
                    <table cellpadding="2" class="style1">
                        <tr>
                            <td class="style28" style="border-style: solid; border-width: thin">
                                &nbsp;&nbsp;<asp:Label ID="Label38" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Education Level:" 
                                    Font-Bold="True"></asp:Label>&nbsp;<asp:Label 
                                    ID="Lbl_Edu" runat="server" Font-Names="Courier New" Font-Size="Small"></asp:Label></td>
                            <td class="style30" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label39" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Occupation:" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_Occ" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td class="style8" style="border-style: solid; border-width: thin">
                                <span class="style8">
                                <asp:Label ID="Label14" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Sector:" Font-Bold="True"></asp:Label>
                                </span>
                                <asp:Label ID="Lbl_Sec" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="2" class="style1">
                        <tr>
                            <td style="border-style: solid; border-width: thin">
                                &nbsp;<asp:Label ID="Label40" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Resident Address:" 
                                    Font-Bold="True"></asp:Label>&nbsp;
                                <asp:Label ID="Lbl_ResidentAddy" runat="server" Font-Names="Courier New" 
                                    Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="2" class="style1">
                        <tr>
                            <td class="style34" style="border-style: solid; border-width: thin">
                                &nbsp;&nbsp;<asp:Label ID="Label41" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Resident State:" 
                                    Font-Bold="True"></asp:Label>&nbsp;
                                <asp:Label ID="Lbl_Resstate" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td class="style6" style="border-style: solid; border-width: thin">
                                &nbsp;<span class="style6"><asp:Label ID="Label42" runat="server" 
                                    Font-Names="Tahoma" Font-Size="Small" ForeColor="#000066" 
                                    Text="Resident City/Town:" Font-Bold="True"></asp:Label><asp:Label ID="Lbl_ResTown" 
                                    runat="server" Font-Names="Courier New" Font-Size="Small"></asp:Label></span></td>
                        </tr>
                    </table>
                    <table cellpadding="2" class="style1">
                        <tr>
                            <td style="border-style: solid; border-width: thin">
                                &nbsp;&nbsp;<asp:Label ID="Label43" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Office Address:" 
                                    Font-Bold="True"></asp:Label>&nbsp;
                                <asp:Label ID="Lbl_OfficeAddy" runat="server" Font-Names="Courier New" 
                                    Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table class="style1">
                        <tr>
                            <td class="style35" style="border-style: solid; border-width: thin">
                                &nbsp;&nbsp;
                                <asp:Label ID="Label44" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Mobile No:" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_Mob" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td class="style36" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label45" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Office Phone:" 
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_OfficePho" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td class="style37" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label46" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Home Phone:" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_HomePho" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td class="style6" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label47" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Email Address:" 
                                    Font-Bold="True"></asp:Label>
                                <span class="style6"><span class="style6">
                                <asp:Label ID="Lbl_Email" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                                </span></span>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="2" class="style1">
                        <tr>
                            <td class="style54" style="border-style: solid; border-width: thin">
                                &nbsp;
                                <asp:Label ID="Label31" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="ID Type:" Font-Bold="True"></asp:Label>
                                &nbsp;<asp:Label ID="Lbl_IDType" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>&nbsp;</td>
                            <td class="style47" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label48" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="ID No:" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_IDNo" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td class="style48" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label49" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="ID Issue Date:" 
                                    Font-Bold="True"></asp:Label>
                                &nbsp;<asp:Label ID="Lbl_IDDate" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label></td>
                            <td style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label50" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="ID Expiry Date:" 
                                    Font-Bold="True"></asp:Label>
                                &nbsp;<asp:Label ID="Lbl_IDExp" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label></td>
                        </tr>
                    </table>
                    <table cellpadding="2" class="style1">
                        <tr>
                            <td class="style50">
                                &nbsp;&nbsp;
                                <asp:Label ID="Label51" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Signature:" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" Font-Size="Small" PageSize="1" Width="357px">
                                    <PagerSettings FirstPageText="First" LastPageText="Last" 
                                        Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="Image2" runat="server" Height="83px" 
                                                    ImageUrl='<%# "Handler2.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber")  %>' 
                                                    Width="244px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel 
                ID="Panel5" runat="server" BackColor="#DDDDFF">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                    ForeColor="#000066" 
                    Text="DETAILS OF NEXT OF KIN"></asp:Label>
                    </asp:Panel>
                    <table cellpadding="2" class="style1">
                        <tr>
                            <td class="style44" style="border-style: solid; border-width: thin">
                                &nbsp;&nbsp;
                                <asp:Label ID="Label54" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Next of Kin:" Font-Bold="True"></asp:Label>
                                &nbsp;<asp:Label ID="Lbl_NextofKin" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label></td>
                            <td class="style43" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label52" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Next of Kin's Phone:" 
                                    Font-Bold="True"></asp:Label>
                                &nbsp;<asp:Label ID="Lbl_NKinPho" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label></td>
                        </tr>
                    </table>
                    <table cellpadding="2" class="style1">
                        <tr>
                            <td style="border-style: solid; border-width: thin">
                                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label53" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Next of Kin's Address:" 
                                    Font-Bold="True"></asp:Label>&nbsp;<asp:Label 
                                    ID="Lbl_NextofKinAddy" runat="server" Font-Names="Courier New" 
                                    Font-Size="Medium"></asp:Label></td>
                        </tr>
                    </table>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                </asp:Panel>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input ID="Button1" language="javascript" onclick="return Button1_onclick()" 
                    type="button" value="Print" /><br />
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel7" runat="server" Visible="False">
                <asp:Panel ID="Panel8" runat="server" BorderColor="#333333" 
                    BorderStyle="Double">
                    <table class="style1">
                        <tr>
                            <td class="style59" rowspan="2">
                                <asp:Image ID="Image6" runat="server" Height="87px" 
                                    ImageUrl="~/Images/LogochevronNew.jpg" Width="73px" />
                            </td>
                            <td>
                                <asp:Label ID="Label92" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                    Font-Size="Large" ForeColor="#000042" style="font-family: Tahoma" 
                                    Text="CEMCS MICROFINANCE BANK LIMITED"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <div style="background-color: #DDDDFF">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label93" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                            Font-Size="Medium" ForeColor="#000042" style="font-family: Tahoma" 
                            Text="CORPORATE ACCOUNT OPENING FORM"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <br />
                    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" Font-Size="Small" Height="42px" PageSize="1" 
                        style="margin-left: 564px" Width="176px">
                        <PagerSettings FirstPageText="First" LastPageText="Last" 
                            Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="Image3" runat="server" Height="139px" 
                                        ImageUrl='<%# "Handler.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber") %>' 
                                        Width="139px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    &nbsp;&nbsp;&nbsp;<asp:Panel ID="Panel9" runat="server" BackColor="#DDDDFF">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label57" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                            ForeColor="#000066" style="font-family: Tahoma" Text="CUSTOMER INFORMATION"></asp:Label>
                    </asp:Panel>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label58" runat="server" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Small" ForeColor="#000066" 
                        Text="ACCOUNT NUMBER:"></asp:Label>
                    <asp:Label ID="Lbl_AcctNo0" runat="server" Font-Bold="True" 
                        Font-Names="Courier New" Font-Size="Small"></asp:Label>
                    &nbsp;<table cellpadding="4" class="style1">
                        <tr>
                            <td class="style2" colspan="2" style="border-style: solid; border-width: thin">
                                &nbsp;<asp:Label ID="Label59" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Customer Type:" 
                                    Font-Bold="True"></asp:Label><asp:Label 
                                    ID="Lbl_Type0" runat="server" Font-Names="Courier New" Font-Size="Small"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td class="style2" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label60" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Type of Account:" 
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_Product0" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border-style: solid; border-width: thin">
                            <td class="style32" colspan="3" style="border-style: solid; border-width: thin">
                                &nbsp;<asp:Label ID="Label61" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Company Reg No:" 
                                    Font-Bold="True"></asp:Label><asp:Label 
                                    ID="Lbl_RegNo" runat="server" Font-Names="Courier New" Font-Size="Small"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label62" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Company Name:" 
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_CompName" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style57" style="border-style: solid; border-width: thin">
                                &nbsp;
                                <asp:Label ID="Label65" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Company Sector:" 
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_sex0" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td class="style56" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label66" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Date of Registration:" 
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_DOB0" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td class="style23" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label67" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Country of Incorporation:" 
                                    Font-Bold="True"></asp:Label>
                                &nbsp;<asp:Label ID="Lbl_Nat0" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label></td>
                        </tr>
                    </table>
                    <table cellpadding="2" class="style1">
                        <tr>
                            <td class="style34" style="border-style: solid; border-width: thin">
                                &nbsp;&nbsp;<asp:Label ID="Label73" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="State of Incorporation:" 
                                    Font-Bold="True"></asp:Label>&nbsp;
                                <asp:Label ID="Lbl_Sta0" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td class="style6" style="border-style: solid; border-width: thin">
                                &nbsp;<span class="style6"><asp:Label ID="Label74" runat="server" 
                                    Font-Names="Tahoma" Font-Size="Small" ForeColor="#000066" 
                                    Text="Company Town:" Font-Bold="True"></asp:Label><asp:Label ID="Lbl_ResTown0" 
                                    runat="server" Font-Names="Courier New" Font-Size="Small"></asp:Label></span></td>
                        </tr>
                    </table>
                    <table cellpadding="2" class="style1">
                        <tr>
                            <td style="border-style: solid; border-width: thin">
                                &nbsp;&nbsp;<asp:Label ID="Label75" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Company Address:" 
                                    Font-Bold="True"></asp:Label>&nbsp;
                                <asp:Label ID="Lbl_OfficeAddy0" runat="server" Font-Names="Courier New" 
                                    Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table class="style1">
                        <tr>
                            <td class="style58" style="border-style: solid; border-width: thin">
                                &nbsp;&nbsp;
                                <asp:Label ID="Label76" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Office Phone1:" 
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_Mob0" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td class="style36" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label77" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Office Phone2:" 
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_OfficePho0" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td class="style37" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label78" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Office Phone3:" 
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="Lbl_HomePho0" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td class="style6" style="border-style: solid; border-width: thin">
                                <asp:Label ID="Label79" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Email Address:" 
                                    Font-Bold="True"></asp:Label>
                                <span class="style6"><span class="style6">
                                <asp:Label ID="Lbl_Email0" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label>
                                </span></span>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="2" class="style1">
                        <tr>
                            <td class="style50">
                                &nbsp;&nbsp;
                                <asp:Label ID="Label84" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Signature:" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:GridView ID="GridView4" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" Font-Size="Small" PageSize="1" Width="357px">
                                    <PagerSettings FirstPageText="First" LastPageText="Last" 
                                        Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="Image4" runat="server" Height="83px" 
                                                    ImageUrl='<%# "Handler2.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber")  %>' 
                                                    Width="244px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table cellpadding="2" class="style1">
                        <tr>
                            <td style="border-style: solid; border-width: thin">
                                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label88" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#000066" Text="Contact Person:" 
                                    Font-Bold="True"></asp:Label>&nbsp;<asp:Label 
                                    ID="Lbl_ContactPerson" runat="server" Font-Names="Courier New" 
                                    Font-Size="Small"></asp:Label></td>
                        </tr>
                    </table>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                </asp:Panel>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input ID="Button2" language="javascript" onclick="return Button2_onclick()" 
                    type="button" value="Print" /><br />
            </asp:Panel>
            <br />
    
    </div>
    </form>
    <p>
                                &nbsp;</p>
</body>
</html>
