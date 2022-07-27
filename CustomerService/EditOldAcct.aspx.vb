Imports System.Web.UI.WebControls
Imports log4net
Imports log4net.Config

Partial Class CustomerService_EditOldAcct
    Inherits SessionCheck
    Dim retval As String = ""
    Dim retmsg As String = ""
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CustomerService_EditOldAcct))
    Protected Sub txtaccountnumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtaccountnumber.TextChanged
        Try
            Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtaccountnumber.Text.Trim & "'"
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then

                drx = con.SqlDs(selExist).Tables(0).Rows(0)
                Me.Label1.Text = drx.Item("accounttitle").ToString
                Me.Label2.Text = drx.Item("prodname").ToString
                Me.Label3.Text = drx.Item("branch").ToString
                Me.Label4.Text = drx.Item("bkbal").ToString
                Me.Label5.Text = drx.Item("effbal").ToString
                Me.Label6.Text = drx.Item("usebal").ToString
                Me.Label7.Text = drx.Item("acctty").ToString
                Me.Label8.Text = drx.Item("source").ToString
                Me.Label9.Text = drx.Item("acctstatus").ToString
                Me.Label21.Text = drx.Item("accountnumber").ToString

                Me.txtaccountnumber0.Text = drx.Item("oldacctno").ToString

                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString

                Dim idimg As String = drx.Item("customerid").ToString.Trim


                If Me.Label9.Text <> "Active" Then
                    Me.Label9.BackColor = Drawing.Color.Red
                Else
                    Me.Label9.BackColor = Drawing.Color.Orange
                    Me.Label9.ForeColor = Drawing.Color.Blue

                End If
                ''Dim od As Integer = drx.Item("ODProd")
                ''If od = 0 Then
                ''    smartobj.alertwindow(Me.Page, "Overdraft Not Permited On Account Product", "Prime")
                ''    Me.btnSubmit.Enabled = False
                ''    Exit Sub
                ''Else
                ''    Me.btnSubmit.Enabled = True

                ''End If


                ''Me.DrpAcctno.Items.Clear()
                ''Me.DrpAcctno.Items.Add("")

                ''Dim selacct As String = "select accountnumber from tbl_casaaccount where customerid='" & Me.txtaccountnumber.Text.Trim & "' and status=1"
                ''For Each dr As Data.DataRow In con.SqlDs(selacct).Tables(0).Rows
                ''    DrpAcctno.Items.Add(dr("accountnumber").ToString)

                ''Next



                'Image1.Visible = True
                'Image1.ImageUrl = FormatURL(idimg)

                'If prostatus = "1" Then
                '    smartobj.alertwindow(Me.Page, prodesc, "Prime")
                '    Me.btnSubmit.Enabled = False
                'Else
                '    Me.btnSubmit.Enabled = True
                'End If
            Else
                Me.Label1.Text = ""
                Me.Label2.Text = ""
                Me.Label3.Text = ""
                Me.Label4.Text = ""
                Me.Label5.Text = ""
                Me.Label6.Text = ""
                Me.Label7.Text = ""
                Me.Label8.Text = ""
                Me.Label9.Text = ""
                Me.Label21.Text = ""
                'Image1.Visible = False
                smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                Exit Sub
            End If
        Catch ex As Exception


            logger.Info("CUSTOMER SERVICE: EDITOLDACCOUNT txtaccountnumber_TextChanged" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try

    End Sub

    

    Protected Sub Btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            Dim qry As String = ""
            
            qry = "Update tbl_casaaccount set oldacctno='" & Me.txtaccountnumber0.Text.Trim & "' where accountnumber='" & Me.txtaccountnumber.Text.Trim & "'"
            con.SqlDs(qry)
            clearer()

            smartobj.alertwindow(Me.Page, "Old Account Number Updated Correctly", "Prime")

            Me.btnSubmit.Enabled = False


        Catch ex As Exception

            logger.Info("CUSTOMER SERVICE: EDIT OLD ACCOUNT Btnsubmit_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")
        End Try
    End Sub
    Sub clearer()
        Me.txtaccountnumber.Text = ""
        Me.txtaccountnumber0.Text = ""
        Label1.Text = String.Empty
        Label2.Text = String.Empty
        Label3.Text = String.Empty
        Label4.Text = String.Empty
        Label5.Text = String.Empty
        Label6.Text = String.Empty
        Label7.Text = String.Empty
        Label8.Text = String.Empty
        Label9.Text = String.Empty
       
        txtaccountnumber.Focus()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        Me.hypsearch.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtaccountnumber.ClientID.ToString() + "');"

    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        clearer()
        Me.btnSubmit.Enabled = True
    End Sub
End Class
