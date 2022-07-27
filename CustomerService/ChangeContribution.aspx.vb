Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
'Imports System.Web.Mail
Imports System.Net.Mail.MailMessage
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Configuration
Imports System.Net.Configuration
Imports System.IO
Imports Toastr
Imports log4net
Imports log4net.Config

Partial Class CustomerService_ChangeContribution
    '  Inherits System.Web.UI.Page
    Inherits SessionCheck2
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CustomerService_ChangeContribution))
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim cnt As Integer = 0
    Dim userNAME As String
    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)
    Private qry As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Page.IsPostBack = False Then
                Dim qry As String = "select a.surname,a.firstname,a.othername,a.customerid,b.MonthlyContri,b.accountnumber   from tbl_customer a inner join  Memcos_Reg_table b on a.Customerid= b.Customerid and a.node_id=b.node_id   where a.UniqueID = '" _
           & Request.QueryString("UniqueID") & "' and a.node_id = '" & Session("node_ID") & "' and b.node_id ='" & Session("node_ID") & "'"

                If Request.QueryString("UniqueID") <> "" Then
                    Me.txtemployeeid.Enabled = False
                    Me.TxtFirstName.Enabled = False
                    Me.TxtLastname.Enabled = False
                    Me.TxtMiddlename.Enabled = False
                    Me.txtaccountnumber.Enabled = False


                    For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                        Me.TxtLastname.Text = dr(0).ToString
                        Me.TxtFirstName.Text = dr(1).ToString
                        Me.TxtMiddlename.Text = dr(2).ToString
                        Me.txtemployeeid.Text = dr(3).ToString
                        Me.txtcontribution.Text = dr(4).ToString
                        Me.txtaccountnumber.Text = dr(5).ToString
                    Next

                End If
            End If
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: CHANGE CONTRIBUTION  Page_Load" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

        End Try

    End Sub
    Protected Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        Try
            'If Me.txtcontribution.Text = 0.00 Then
            '    '  smartobj.alertwindow(Me.Page, "Please Enter Surname", "Prime")
            '    Me.Panel2.Visible = True
            '    Me.Panel1.Visible = False
            '    Me.Label_error.Visible = True
            '    Me.Label_success.Visible = False
            '    Me.Label_error.Text = "Oops! Please Enter your contribution amount"
            '    ' MsgBox("Please Enter your First Name")
            '    'Me.TxtFirstName.Focus()
            '    Exit Sub
            'Else

            '    Me.Panel2.Visible = False
            '    Me.Panel1.Visible = False
            'End If
            If Me.txtcontribution.Text = "" Then
                '  smartobj.alertwindow(Me.Page, "Please Enter Surname", "Prime")
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Oops! Please update contribution amount"
                ' MsgBox("Please Enter your First Name")
                'Me.TxtFirstName.Focus()
                txtcontribution.Focus()
                Exit Sub
            Else

                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If

            logger.Info("CUSTOMER SERVICE: MEMBER CREATION '" & "MEMBER REGISTRATION" & " : '" & "BtnSubmit_Click" & "'' " _
  & vbNewLine & "   <<<<Direction: INPUT" _
  & vbNewLine & "      INPUT PARAMETERS LIST & " _
  & vbNewLine & "           First Name: '" & TxtFirstName.Text & "'" _
  & vbNewLine & "           Last Name: '" & TxtLastname.Text & "'" _
  & vbNewLine & "          Middle Name: '" & TxtMiddlename.Text & "'" _
  & vbNewLine & "          custom customer/member id: '" & txtemployeeid.Text & "'" _
  & vbNewLine & "          Account No: '" & Me.txtaccountnumber.Text & "'" _
  & vbNewLine & "         CONTRIBUTION: '" & txtcontribution.Text & "'" _
   & vbNewLine & "       INPUT PARAMETERS LIST END----------'" _
  & vbNewLine & "************************************************************************************************************************************************************************************")



            qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
            qry = qry & "execute Proc_Service_Contribution_Update "
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtemployeeid.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtaccountnumber.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtcontribution.Text) & "," & Session("node_ID") & ",@retVal OUTPUT,@retmsg OUTPUT" & " "
            qry = qry & " select @retVal,@retmsg"


            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString

            Next
            logger.Info("CUSTOMER SERVICE:CHANGE CONTRIBUTION  '" & "CHANGE CONTRIBUTION  RESPONSE" & " : '" & "BtnSubmit_Click" & "'' " _
  & vbNewLine & "   <<<<Direction: OUTPUT" _
  & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
  & vbNewLine & "          RetVal: '" & retval & "'" _
  & vbNewLine & "          RetMsg: '" & retmsg & "'" _
  & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" & "" & "'" & " " _
  & vbNewLine & "************************************************************************************************************************************************************************************")


            If retval = "0" Then
                '  smartobj.alertwindow(Me.Page, retmsg, "Prime")

                Panel1.Focus()
                Me.Panel1.Visible = True
                Me.Panel2.Visible = False
                Me.Label_error.Visible = False
                Me.Label_success.Visible = True
                Me.Label_error.Visible = False
                Me.Label_success.Text = "Monthly contribution updated successfully"


                Session("RadWindowCode") = "0"
                Session("RadWindowMsg") = "Monthly Contribution updated successfully: " + retmsg
                ' uploadimage()
            Else
                ' Me.Btnsubmit.Enabled = True
                '  smartobj.alertwindow(Me.Page, retmsg, "Prime")


                smartobj.ShowToast(Me.Page, ToastType.Error, retmsg, "Error!", ToastPosition.TopRight, True)

                Panel2.Focus()
                Me.Panel1.Visible = False
                Me.Panel2.Visible = True
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = retmsg

                Session("RadWindowCode") = 998
                Session("RadWindowMsg") = "Unable to update monthly contribution: " + retmsg

            End If
            Me.BtnSubmit.Enabled = False







        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: CHANGE CONTRIBUTION  BtnSubmit_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)

            Me.Panel2.Visible = True
            Me.Panel1.Visible = False
            Me.Label_error.Visible = True
            Me.Label_success.Visible = False
            Me.Label_error.Text = "Error Occurred!!!"

        End Try


    End Sub

    'Sub CLEAR()
    '    txtcontribution.Text = 0
    'End Sub

End Class
