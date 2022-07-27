Imports System.Web.UI.WebControls
Imports log4net
Imports log4net.Config
Partial Class BankingOperations_Amortise
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(BankingOperations_Amortise))

    Sub showadd()
        Me.btnSubmit.Text = "Submit"
        smartobj.ClearWebPage(Me.Page)
        btnSubmit.Enabled = True
    End Sub
    Sub showedit()
        Me.btnSubmit.Text = "Update"
        smartobj.ClearWebPage(Me.Page)
        btnSubmit.Enabled = True
    
    End Sub

    Protected Sub Btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            If Me.txtAcNumber.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
                Exit Sub
            End If

            If Me.txtAccountNo2.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
                Exit Sub
            End If
            If Me.txtStartdate.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter a Value Date", "Prime")
                Exit Sub
            End If

            If Me.txtAccountNo2.Text.Trim = Me.txtAcNumber.Text.Trim Then
                smartobj.alertwindow(Me.Page, "Can Not Amortise on the same Account", "Prime")
                Exit Sub
            End If
            If Me.txtNaration.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Posting Narration", "Prime")
                Exit Sub
            End If

            If Me.txtPayAmount.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Posting amount", "Prime")
                Exit Sub
            End If

            Dim ans1, ans2 As String
            ' Dim userid As String = Session("Userid").ToString

            If txtStartdate.Text <> "" Then
                Try
                    ans1 = CDate(txtStartdate.Text.Trim)

                Catch ex As Exception
                    smartobj.alertwindow(Me.Page, "Date Format Not supported", "Prime")
                    Exit Sub
                End Try

            Else
                smartobj.alertwindow(Me.Page, "Enter Start Date", "Prime")
                Exit Sub
            End If

            If txtEnddate.Text <> "" Then
                Try
                    ans2 = CDate(txtEnddate.Text.Trim)
                Catch ex As Exception
                    smartobj.alertwindow(Me.Page, "Date Format Not supported", "Prime")
                    Exit Sub
                End Try

            Else
                smartobj.alertwindow(Me.Page, "Enter End Date", "Prime")
                Exit Sub
            End If

            ''If Format(CDate(ans1), "MM-dd-yyyy") > Format(CDate(ans2), "MM-dd-yyyy") Then
            ''    smartobj.alertwindow(Me.Page, "Start Date Must be Less than End Date", "Prime")
            ''    Exit Sub
            ''End If

            If Not IsNumeric(txtPayAmount.Text) Or Val(txtPayAmount.Text) < 0 Then
                smartobj.alertwindow(Me.Page, "Hold Amount Amount must be numeric", "Prime")
                Exit Sub
            End If

            If Me.btnSubmit.Text = "Submit" Then
                qry = "declare @retVal int,@retMsg varchar(100) execute Proc_InsAmortise '" & Me.txtAcNumber.Text & "','" & Me.txtAccountNo2.Text & "'," & CDec(Me.txtPayAmount.Text.Trim) & ",'" & Format(CDate(ans1), "MM-dd-yyyy") & "','" & Format(CDate(ans2), "MM-dd-yyyy") & "','" & Me.txtNaration.Text.Trim & "','" & Me.DDaccrualfreq.SelectedValue.Trim & "','" & Session("Userid").ToString & "',NULL,@retVal OUTPUT,@retMsg OUTPUT select @retVal,@retMsg"

            Else
                qry = "declare @retVal int,@retMsg varchar(100) execute Proc_UpdAmortise '" & Me.txtAcNumber.Text & "','" & Me.txtAccountNo2.Text & "'," & CDec(Me.txtPayAmount.Text.Trim) & ",'" & Format(CDate(ans1), "MM-dd-yyyy") & "','" & Format(CDate(ans2), "MM-dd-yyyy") & "','" & Me.txtNaration.Text.Trim & "','" & Me.DDaccrualfreq.SelectedValue.Trim & "','" & Me.DDaccrualfreq0.SelectedValue.Trim & "','" & Session("Userid").ToString & "',@retVal OUTPUT,@retMsg OUTPUT select @retVal,@retMsg"

            End If

            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            Me.btnSubmit.Enabled = False
            clear()
            smartobj.alertwindow(Me.Page, retmsg, "Prime")
            smartobj.ClearWebPage(Me.Page)

        Catch ex As Exception
            logger.Info("BANKING OPERATION: AMORTISE SUBMIT'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")


        End Try
    End Sub
    Sub clear()
        Me.txtAccountNo2.Text = ""
        Me.txtAcNumber.Text = ""
        Me.txtEnddate.Text = ""
        Me.txtNaration.Text = ""
        Me.txtPayAmount.Text = ""
        Me.txtRate.Text = ""
        Me.txtStartdate.Text = ""
        Me.txtTransAmount.Text = ""
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
        Label21.Text = String.Empty
        Label22.Text = String.Empty
        txtAcNumber.Focus()
    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        Me.HyperLink2.NavigateUrl = "javascript:accountGLPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"
        Me.HyperLink3.NavigateUrl = "javascript:accountGLPicker('document.aspnetForm." + Me.txtAccountNo2.ClientID.ToString() + "');"
        hypValueDate.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtStartdate.ClientID.ToString() + "');"
        Me.HyperLink1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtEnddate.ClientID.ToString() + "');"

        If Page.IsPostBack = False Then


            Dim Dstring As String = "SELECT cast(ltrim(rtrim(freqcode)) as varchar) freqcode,freqname FROM tbl_frequency"
            smartobj.loadComboValues("--Choose a Frequency--- ", Me.DDaccrualfreq, Dstring)

            selcurrency()
            txtStartdate.Text = Format(CDate(Session("sysdate")), "dd/MM/yyyy")

            Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(countrycode)) as varchar) countrycode,currencymne FROM tbl_country where status=1"
            smartobj.loadComboValues("--Select a Currecy--- ", Me.drpCurrency, Dstring7)
        End If
    End Sub
    Protected Sub txtPayAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPayAmount.TextChanged
        Try
            txtPayAmount.Text = smartobj.FormatMoney(txtPayAmount.Text)
            txtTransAmount.Text = CInt(txtRate.Text.Trim) * CDec(txtPayAmount.Text.Trim)
            txtTransAmount.Text = smartobj.FormatMoney(txtTransAmount.Text)
        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "Invalid Amount Specified", "Halt")
        End Try
    End Sub
    Sub selcurrency()
        Try
            Dim Lock As Integer
            qry = "Select lockcurrency,country from tbl_bank"
            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                Lock = dr!lockcurrency
                Me.drpCurrency.SelectedValue = dr!country.ToString.Trim
            Next
            If Lock = 1 Then
                drpCurrency.Enabled = False
                Me.txtRate.Text = 1
            Else
                drpCurrency.Enabled = True

            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub BtnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            smartobj.ClearWebPage(Me.Page)
            Me.btnSubmit.Enabled = True
            clear()
        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    Try
    '        Response.Redirect("Default.aspx")
    '    Catch ex As Exception

    '    End Try
    'End Sub


    

    Protected Sub txtAcNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcNumber.TextChanged
        Try

            Dim selex As String = "Delete from tbl_postlog where ltrim(rtrim(accountno))='" & Me.txtAcNumber.Text.Trim & "'"
            con.SqlDs(selex)



            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAcNumber.Text = retmsg
            End If

            Dim selacct As String = "select substring(accountnumber,1,3) from tbl_casaaccount where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and status=1"
            If con.SqlDs(selacct).Tables(0).Rows.Count > 0 Then
                accdetail1(Me.txtAcNumber.Text.Trim, 0)




               
            Else
                selfind = "declare @retval int,@retmsg varchar(100) exec [proc_ValidOldGL] '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
                For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next

                If retval = "0" Then
                    If retmsg <> "ok" Then
                        smartobj.alertwindow(Me.Page, retmsg, "Prime")

                    Else
                        Me.txtAcNumber.Text = retmsg

                    End If
                End If

                Dim selacct2 As String = "select substring(glnumber,1,3),pointing from tbl_bankgl where glnumber='" & Me.txtAcNumber.Text.Trim & "' and isnull(Blocked,0)<>1"
                If con.SqlDs(selacct2).Tables(0).Rows.Count > 0 Then
                    accdetail1(Me.txtAcNumber.Text.Trim, 1)
                    Session("idcnt") = 1
                    Dim strv As String = con.SqlDs(selacct2).Tables(0).Rows(0).Item(0)
                    Dim point As String = con.SqlDs(selacct2).Tables(0).Rows(0).Item(1)


                   
                    Me.btnSubmit.Enabled = True
                   


                    

                Else
                    smartobj.alertwindow(Me.Page, "Error: Either GL OR Customer Account Does Not Exist OR Posting Not Allowed On Account", "Prime")

                  
                    Exit Sub
            End If

            End If

            '' selexist()
            Me.txtAccountNo2.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtAccountNo2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountNo2.TextChanged
        Try

            Dim selex2 As String = "Delete from tbl_postlog where ltrim(rtrim(accountno))='" & Me.txtAccountNo2.Text.Trim & "'"
            con.SqlDs(selex2)

           

            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAccountNo2.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAccountNo2.Text = retmsg
            End If

            Dim selacct As String = "select substring(accountnumber,1,3) from tbl_casaaccount where accountnumber='" & Me.txtAccountNo2.Text.Trim & "' and status=1"
            If con.SqlDs(selacct).Tables(0).Rows.Count > 0 Then
                accdetail2(Me.txtAccountNo2.Text.Trim, 0)
              
            Else

                selfind = "declare @retval int,@retmsg varchar(100) exec [proc_ValidOldGL] '" & Me.txtAccountNo2.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
                For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next

                If retval = "0" Then
                    If retmsg <> "ok" Then
                        smartobj.alertwindow(Me.Page, retmsg, "Prime")

                    Else
                        Me.txtAcNumber.Text = retmsg

                    End If
                End If

                Dim selacct2 As String = "select substring(glnumber,1,3),pointing from tbl_bankgl where glnumber='" & Me.txtAccountNo2.Text.Trim & "' and isnull(Blocked,0)<>1"
                If con.SqlDs(selacct2).Tables(0).Rows.Count > 0 Then
                    accdetail2(Me.txtAccountNo2.Text.Trim, 1)
                    Dim strv As String = con.SqlDs(selacct2).Tables(0).Rows(0).Item(0)
                    Dim point As String = con.SqlDs(selacct2).Tables(0).Rows(0).Item(1)



                    Me.btnSubmit.Enabled = True





                Else
                    smartobj.alertwindow(Me.Page, "Error: Either GL OR Customer Account Does Not Exist OR Posting Not Allowed On Account", "Prime")


                    Exit Sub
                End If

            End If

            '' selexist()
            Me.txtAcNumber.Focus()
            Me.txtPayAmount.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Sub selexist()
        Try
            Dim selexist As String = "Exec proc_acctselexist '" & Me.txtAcNumber.Text.Trim & "','" & Me.txtAccountNo2.Text.Trim & "'"
            If con.SqlDs(selexist).Tables(0).Rows.Count > 0 Then
                Me.btnSubmit.Text = "Update"
                'Me.txtEnddate .Text =
                drx = con.SqlDs(selexist).Tables(0).Rows(0)
                Me.txtEnddate.Text = Format(CDate(drx.Item("end_dt").ToString), "dd/MM/yyyy")
                Me.txtStartdate.Text = Format(CDate(drx.Item("effective_dt").ToString), "dd/MM/yyyy")
                Me.txtNaration.Text = drx.Item("narration").ToString
                Me.DDaccrualfreq0.SelectedValue = drx.Item("status").ToString
                Me.txtPayAmount.Text = drx.Item("amount").ToString
                txtPayAmount.Text = smartobj.FormatMoney(txtPayAmount.Text)
            Else
                Me.btnSubmit.Text = "Submit"

            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub accdetail1(ByVal acctno As String, ByVal type As Integer)
        Try
            Dim selExist As String = "Exec Proc_CustAcctDetail2 '" & acctno & "'," & type & ""
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
                Session("Custchg1") = Me.txtAcNumber.Text.Trim
                'Dim seltyp As String = "Select apptype from tbl_bankproduct a,tbl_casaaccount b where a.productcode=b.productcode and b.accountnumber='" & Me.txtAcNumber.Text.Trim & "'"
                'For Each dr As Data.DataRow In con.SqlDs(seltyp).Tables(0).Rows
                '    app = dr!apptype.ToString.Trim
                'Next
                'If app = "CK" Then
                '    smartobj.alertwindow(Me.Page, "Transaction is Not Allowed On Checking Account.", "Prime")
                '    Exit Sub
                'End If
                drx = con.SqlDs(selExist).Tables(0).Rows(0)
                Me.Label1.Text = drx.Item("accounttitle").ToString
                Me.Label2.Text = drx.Item("prodname").ToString
                Me.Label3.Text = drx.Item("branch").ToString

                Me.Label4.Text = smartobj.FormatMoney(Format(drx.Item("bkbal"), "###0.00"))
                Me.Label5.Text = smartobj.FormatMoney(Format(drx.Item("effbal"), "###0.00"))
                Me.Label6.Text = smartobj.FormatMoney(Format(drx.Item("usebal"), "###0.00"))

                Me.Label7.Text = drx.Item("acctty").ToString
                Me.Label8.Text = drx.Item("source").ToString
                Me.Label9.Text = drx.Item("acctstatus").ToString
                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString

                Me.Label22.Text = drx.Item("TotalCharge").ToString

                If Me.Label9.Text <> "Active" Then
                    Me.Label9.BackColor = Drawing.Color.Red
                Else
                    Me.Label9.BackColor = Drawing.Color.Orange
                    Me.Label9.ForeColor = Drawing.Color.Blue

                End If


                If Me.Label22.Text.Trim <> "" Then
                    If CDec(Me.Label22.Text.Trim) > 0 Then
                        Me.LnkCharge.Visible = True
                    Else
                        Me.LnkCharge.Visible = False

                    End If
                End If
                Dim idimg As String = drx.Item("customerid").ToString.Trim

               
            Else
                Me.Label1.Text = ""
                Me.Label2.Text = ""
                Me.Label3.Text = ""
                Me.Label4.Text = ""
                Me.Label5.Text = ""
                Me.Label6.Text = ""
                Me.Label7.Text = ""
                Me.Label8.Text = ""
                'Image1.Visible = False
                smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub accdetail2(ByVal acctno As String, ByVal type As Integer)

        Try
            Dim selExist As String = "Exec Proc_CustAcctDetail2 '" & acctno & "'," & type & ""
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
                Session("Custchg2") = Me.txtAccountNo2.Text.Trim
                'Dim seltyp As String = "Select apptype from tbl_bankproduct a,tbl_casaaccount b where a.productcode=b.productcode and b.accountnumber='" & Me.txtAcNumber.Text.Trim & "'"
                'For Each dr As Data.DataRow In con.SqlDs(seltyp).Tables(0).Rows
                '    app = dr!apptype.ToString.Trim
                'Next
                'If app = "CK" Then
                '    smartobj.alertwindow(Me.Page, "Transaction is Not Allowed On Checking Account.", "Prime")
                '    Exit Sub
                'End If
                drx = con.SqlDs(selExist).Tables(0).Rows(0)
                Me.Label10.Text = drx.Item("accounttitle").ToString
                Me.Label11.Text = drx.Item("prodname").ToString
                Me.Label12.Text = drx.Item("branch").ToString

                Me.Label13.Text = smartobj.FormatMoney(Format(drx.Item("bkbal"), "###0.00"))
                Me.Label14.Text = smartobj.FormatMoney(Format(drx.Item("effbal"), "###0.00"))
                Me.Label15.Text = smartobj.FormatMoney(Format(drx.Item("usebal"), "###0.00"))


                Me.Label16.Text = drx.Item("acctty").ToString
                Me.Label17.Text = drx.Item("source").ToString
                Me.Label18.Text = drx.Item("acctstatus").ToString
                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString

                Me.Label21.Text = drx.Item("TotalCharge").ToString

                If Me.Label18.Text <> "Active" Then
                    Me.Label18.BackColor = Drawing.Color.Red
                Else
                    Me.Label18.BackColor = Drawing.Color.Orange
                    Me.Label18.ForeColor = Drawing.Color.Blue

                End If


                If Me.Label21.Text.Trim <> "" Then
                    If CDec(Me.Label21.Text.Trim) > 0 Then
                        Me.LnkCharge.Visible = True
                    Else
                        Me.LnkCharge.Visible = False

                    End If
                End If
                Dim idimg As String = drx.Item("customerid").ToString.Trim

                'Image1.Visible = True
                'Image1.ImageUrl = FormatURL(idimg)

               
                selcurrency()
            Else
                Me.Label10.Text = ""
                Me.Label11.Text = ""
                Me.Label12.Text = ""
                Me.Label13.Text = ""
                Me.Label14.Text = ""
                Me.Label15.Text = ""
                Me.Label16.Text = ""
                Me.Label17.Text = ""
                Me.Label18.Text = ""
                'Image1.Visible = False
                smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
