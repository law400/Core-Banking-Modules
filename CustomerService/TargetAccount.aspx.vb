Imports System.Web.UI.WebControls
Imports log4net
Imports log4net.Config
Partial Class CustomerService_TargetAccount
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CustomerService_TargetAccount))
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"
        If Page.IsPostBack = False Then

            Try
                If Request.QueryString("id") <> Nothing Then
                    Dim selqry As String = "Select accountnumber from tbl_casaaccount where customerid='" & Request.QueryString("id") & "'"
                    Me.txtAcNumber.Text = con.SqlDs(selqry).Tables(0).Rows(0).Item(0).ToString
                    search()
                Else
                    Me.txtAcNumber.Text = ""
                End If

            Catch ex As Exception

                logger.Info("CUSTOMER SERVICE: TargetAccount Page_Load" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

                smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
            End Try
           
        End If
    End Sub
    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, _
                  ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick
        Try
            Dim i As Integer
            For i = 0 To Menu1.Items.Count - 1
                If i = e.Item.Value Then
                    Menu1.Items(i).ImageUrl = "~/Images/pic2.gif"
                Else
                    Menu1.Items(i).ImageUrl = "~/Images/pic1.gif"
                End If
            Next

            If e.Item.Text = "Add New" Then
                showadd()
            ElseIf e.Item.Text = "Edit" Then
                clear()
                showedit()
            Else
                showlist()
            End If
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: TargetAccount Menu1_MenuItemClick" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")


            smartobj.alertwindow(Me.Page, "Data Server Error....", "Good News")
        End Try
    End Sub
   
    Sub showadd()
        Me.BtnSubmit.Text = "Submit"
        clear()
        btnSubmit.Enabled = True
    End Sub
    Sub showedit()
        Me.BtnSubmit.Text = "Update"
        clear()
        btnSubmit.Enabled = True


    End Sub
    Sub showlist()
        btnSubmit.Enabled = False
    End Sub

    Sub search()
        Try
            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAcNumber.Text = retmsg
            End If
            Dim selExist As String = "Exec Proc_CustAcctDetail4 '" & Me.txtAcNumber.Text.Trim & "'"
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then

                drx = con.SqlDs(selExist).Tables(0).Rows(0)
                Me.Label1.Text = drx.Item("accounttitle").ToString
                Me.txtfullname.Text = drx.Item("accounttitle").ToString

                Me.Label2.Text = drx.Item("prodname").ToString
                Me.Label3.Text = drx.Item("branch").ToString
                Me.Label4.Text = smartobj.FormatMoney(Format(drx.Item("bkbal"), "###.00"))
                Me.Label5.Text = smartobj.FormatMoney(Format(drx.Item("effbal"), "###.00"))
                Me.Label6.Text = smartobj.FormatMoney(Format(drx.Item("usebal"), "###.00"))
                Me.Label7.Text = drx.Item("acctty").ToString
                Me.Label8.Text = drx.Item("source").ToString
                Me.Label9.Text = drx.Item("acctstatus").ToString
                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString
                Dim prodcode As String = drx.Item("Product Code").ToString
                Dim idimg As String = drx.Item("customerid").ToString.Trim
                If Me.Label9.Text <> "Active" Then
                    Me.Label9.BackColor = Drawing.Color.Red
                Else
                    Me.Label9.BackColor = Drawing.Color.Orange
                    Me.Label9.ForeColor = Drawing.Color.Blue

                End If

                Dim selExist2 As String = "Exec Proc_ProdDetail '" & prodcode.Trim & "'"
                If con.SqlDs(selExist2).Tables(0).Rows.Count > 0 Then
                    drx = con.SqlDs(selExist2).Tables(0).Rows(0)

                    Dim prod As String = drx.Item("producttype").ToString
                    If prod <> "13" Then
                        Me.btnSubmit.Enabled = False
                        smartobj.alertwindow(Me.Page, "Account Number Is Not A Revolving Deposit Product", "Prime")

                    End If

                    Me.Label10.Text = drx.Item("productname").ToString
                    Me.Label12.Text = drx.Item("productexpire").ToString
                    Me.Label11.Text = drx.Item("productstart").ToString
                    Me.Label13.Text = drx.Item("currencymne").ToString
                    Me.Label14.Text = drx.Item("minbalance").ToString
                    Me.Label15.Text = drx.Item("apptype").ToString
                    Me.Label20.Text = drx.Item("crrate").ToString
                    Me.Label19.Text = drx.Item("drrate").ToString
                    Dim frt As String = drx.Item("sweepin").ToString

                    Me.Label17.Text = drx.Item("closecharge").ToString
                    Me.Label16.Text = drx.Item("openbalance").ToString
                    Me.Label18.Text = drx.Item("mininterest").ToString

                    Dim xc As String = "Exec [Proc_TargetList] '" & Me.txtAcNumber.Text.Trim & "'"
                    If con.SqlDs(xc).Tables(0).Rows.Count > 0 Then
                        Me.txtbalance.Text = con.SqlDs(xc).Tables(0).Rows(0).Item("currentbalance")
                        txtbalance.Text = smartobj.FormatMoney(txtbalance.Text)

                        Me.txtFirstpay.Text = con.SqlDs(xc).Tables(0).Rows(0).Item("firstchgday")
                        Me.txtChg.Text = con.SqlDs(xc).Tables(0).Rows(0).Item("chargeamt")
                        Me.DrpStatus.SelectedValue = con.SqlDs(xc).Tables(0).Rows(0).Item("status")

                    Else
                        Me.txtbalance.Text = Me.Label4.Text.Trim

                    End If
                    
                    Me.btnSubmit.Enabled = True


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
                    Me.Label10.Text = ""
                    Me.Label11.Text = ""

                    'Image1.Visible = False
                    smartobj.alertwindow(Me.Page, "Product Type Does Not Exist", "Prime")
                    Me.btnSubmit.Enabled = False
                    Exit Sub
                End If


                If prostatus = "1" Then
                    smartobj.alertwindow(Me.Page, prodesc, "Prime")
                    Me.btnSubmit.Enabled = False
                Else
                    Me.btnSubmit.Enabled = True
                End If
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
                Me.Label10.Text = ""
                Me.Label11.Text = ""

                'Image1.Visible = False
                smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                Exit Sub
            End If

        Catch ex As Exception

            logger.Info("CUSTOMER SERVICE: TargetAccount  Sub search" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try
    End Sub
    Protected Sub txtAcNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcNumber.TextChanged
        search()
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        smartobj.ClearWebPage(Me.Page)
        clear()
        Me.btnSubmit.Enabled = True
    End Sub
    Sub clear()
        Me.txtAcNumber.Text = ""
        Me.txtFirstpay.Text = "1"
        Me.txtChg.Text = 0
        Me.txtbalance.Text = "0"
        Me.txtfullname.Text = ""
        Label1.Text = String.Empty
        Label2.Text = String.Empty
        Label3.Text = String.Empty
        Label4.Text = String.Empty
        Label5.Text = String.Empty
        Label6.Text = String.Empty
        Label7.Text = String.Empty
        Label8.Text = String.Empty
        Label9.Text = String.Empty
        Label10.Text = String.Empty
        Label11.Text = String.Empty
        Label12.Text = String.Empty
        Label13.Text = String.Empty
        Label14.Text = String.Empty
        Label15.Text = String.Empty
        Label16.Text = String.Empty
        Label17.Text = String.Empty
        Label18.Text = String.Empty
        Label19.Text = String.Empty
        Label20.Text = String.Empty

        DrpStatus.SelectedIndex = 0
        txtAcNumber.Focus()

    End Sub
    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    Response.Redirect("default.aspx")
    'End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try

            Dim insacc As String = "Declare @retval int,@retmsg varchar(100) exec Proc_updTrgAccount '" & Me.txtAcNumber.Text.Trim & "'," & _
              "" & CDec(Me.txtChg.Text.Trim) & "," & _
              "" & CInt(Me.txtFirstpay.Text.Trim) & ",'" & CDec(Me.txtbalance.Text.Trim) & "'," & CInt(Me.DrpStatus.SelectedValue.Trim) & "," & _
              "'" & Profile.Userid.Trim & "',@retval Output,@retmsg Output select @retval,@retmsg"

            retval = 0
            retmsg = ""

            For Each dr As Data.DataRow In con.SqlDs(insacc).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next
            clear()
            Me.btnSubmit.Enabled = False
          
            smartobj.alertwindow(Me.Page, retmsg, "Prime")

        Catch ex As Exception

            logger.Info("CUSTOMER SERVICE: TargetAccount  btnSubmit_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try
    End Sub

  
    Protected Sub txtChg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChg.TextChanged
        txtChg.Text = smartobj.FormatMoney(txtChg.Text)

    End Sub

    Protected Sub txtbalance_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbalance.TextChanged
        txtbalance.Text = smartobj.FormatMoney(txtbalance.Text)

    End Sub
End Class
