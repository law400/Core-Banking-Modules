Imports System.Web.UI.WebControls
Imports log4net
Imports log4net.Config

Partial Class CustomerService_ProvosionAccount
    Inherits SessionCheck
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CustomerService_ProvosionAccount))
    Protected Sub txtAcNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcNumber.TextChanged
        Try
            Profile.Custchg1 = ""
            'post = Guid.NewGuid.ToString
            'Dim xItem As New ListItem
            'xItem.Text = post
            Dim retval As Integer
            Dim retmsg As String = ""
            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAcNumber.Text = retmsg
            End If

            Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtAcNumber.Text.Trim & "'"
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
               

                drx = con.SqlDs(selExist).Tables(0).Rows(0)
                Me.Label7.Text = drx.Item("accounttitle").ToString
                
            Else
                Me.Label7.Text = ""
               
                smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                Exit Sub
            End If
           

        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: PROVOSIONACCOUNT txtAcNumber_TextChanged" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"
        If Page.IsPostBack = False Then
            Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(provisionid)) as varchar) provisionid,provisionname FROM tbl_provision where status=1"
            smartobj.loadComboValues("--Select Provision Type--- ", Me.drpprovision, Dstring7)
        End If
    End Sub

    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        Try
            Dim qry As String = ""

            qry = "Update tbl_casaaccount set Classified=" & drpprovision.SelectedValue.Trim & " where accountnumber='" & Me.txtAcNumber.Text.Trim & "'"
            con.SqlDs(qry)

            smartobj.alertwindow(Me.Page, "Account Provision Updated Successfully", "CSO")

        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: PROVOSIONACCOUNT BtnSubmit_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try
    End Sub
End Class
