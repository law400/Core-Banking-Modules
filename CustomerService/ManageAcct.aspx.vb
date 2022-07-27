Imports System.Web.UI.WebControls
Partial Class CustomerService_ManageAcct
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = ""
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "EDIT ACCOUNT" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"
        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)

        menuname.Text = Request.QueryString("XXX")
        If menuname.Text = "" Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Validate_Access(menuname.Text) = 0 Then
            Response.Redirect("~/Unauthorize.aspx")
        End If
        If Page.IsPostBack = False Then
            'Try

            '    Dim qry As String = "select cast(sys_date as datetime)sys_date,sys_phase from tbl_system"
            '    For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
            '        latesttime = Format(CDate(dr!sys_date), "dd/MM/yyyy")
            '    Next

            'Catch
            '    smartobj.alertwindow(Me.Page, "Data Warnning error...", "Prime")
            '    Exit Sub
            'End Try
            'If IsDate(latesttime) Then
            '    'latesttime = latesttime.AddHours(Now.Hour)
            '    'latesttime = latesttime.AddMinutes(Now.Minute)
            '    'latesttime = latesttime.AddSeconds(Now.Second)
            '    latesttime = Format(CDate(latesttime.Date), "dd/MM/yyyy")
            'End If

            Dim Daccounttier As String = "SELECT cast(ltrim(rtrim(Tier_id)) as varchar) Tier_id,Tier_name FROM tbl_Account_Tier where status=1"
            smartobj.loadComboValues("--Select an Account Tier--- ", Me.DrpAccountTier, Daccounttier)
        End If
    End Sub
    Function Validate_Access(ByVal MenuName As String) As Integer

        qry = " declare @retVal int " & vbNewLine
        qry = qry & "execute Proc_RM_Validate "
        qry = qry & smartobj.EncoteWithSingleQuote(Session("Roleid")) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(MenuName) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Session("Userid")) & ",@retVal OUTPUT," & Session("node_ID") & " "
        qry = qry & " select @retVal"

        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
            retval = dr(0).ToString
        Next
        Return retval
    End Function

    Protected Sub txtAcNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcNumber.TextChanged
        Try
            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAcNumber.Text = retmsg
            End If
            Dim selExist As String = "Exec Proc_CustAcctDetail4 '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
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
                Me.chkyesno.Checked = smartobj.encodeCkeckBox(drx.Item("disableview").ToString)
                Dim idimg As String = drx.Item("customerid").ToString.Trim
                Me.txtCRInt.Text = drx.Item("cintrate").ToString.Trim
                Me.txtDRint.Text = drx.Item("dintrate").ToString.Trim
                Me.txtOfficer.Text = drx.Item("officercode").ToString.Trim
                Me.txtacctdesc.Text = drx.Item("accountdesc").ToString.Trim

                If Me.Label9.Text <> "Active" Then
                    Me.Label9.BackColor = Drawing.Color.Red
                Else
                    Me.Label9.BackColor = Drawing.Color.Orange
                    Me.Label9.ForeColor = Drawing.Color.Blue

                End If

                'Dim Daccounttier As String = "SELECT cast(ltrim(rtrim(Tier_id)) as varchar) Tier_id,Tier_name FROM tbl_Account_Tier where status=1"
                'smartobj.loadComboValues("--Select an Account Tier--- ", Me.DrpAccountTier, Daccounttier)
                'Me.DrpAccountTier.SelectedValue = drx.Item("AccountTier").ToString.Trim
                searchoffc()


                'If Me.DrpAccountTier.SelectedIndex <> 0 Then
                '    Dim QryString As String = "Select isnull(MaxDepositAmt,0)'MaxDepositAmt',isnull(MaxCummulativeBal,0)'MaxCummulativeBal' from tbl_Account_Tier where Tier_id = '" & Me.DrpAccountTier.SelectedValue & "'"
                '    If con.SqlDs(QryString).Tables(0).Rows.Count > 0 Then
                '        For Each dr As Data.DataRow In con.SqlDs(QryString).Tables(0).Rows
                '            Me.LabelDepAmt.Visible = True
                '            Me.LabelMaxCum.Visible = True
                '            Me.lblMaxDepAmt.Visible = True
                '            Me.lblMaxCumBal.Visible = True
                '            Me.lblMaxDepAmt.Text = dr("MaxDepositAmt")
                '            Me.lblMaxCumBal.Text = dr("MaxCummulativeBal")

                '        Next

                '    Else
                '        Me.LabelDepAmt.Visible = False
                '        Me.LabelMaxCum.Visible = False
                '        Me.lblMaxDepAmt.Visible = False
                '        Me.lblMaxCumBal.Visible = False
                '    End If
                'Else
                '    Me.LabelDepAmt.Visible = False
                '    Me.LabelMaxCum.Visible = False
                '    Me.lblMaxDepAmt.Visible = False
                '    Me.lblMaxCumBal.Visible = False
                'End If

                Dim selExist2 As String = "Exec Proc_ProdDetail '" & prodcode.Trim & "', " & Session("node_ID") & ""
                If con.SqlDs(selExist2).Tables(0).Rows.Count > 0 Then
                    drx = con.SqlDs(selExist2).Tables(0).Rows(0)
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
                    Me.Label22.Text = drx.Item("productcode").ToString

                    If frt = "1" Then
                        Me.txtsweep.Visible = True
                        Me.Label23.Visible = True
                    Else
                        Me.Label23.Visible = False

                        Me.txtsweep.Visible = False

                    End If

                    Dim fetchstaff As String = "exec proc_validStaffAcct '" & prodcode & "', " & Session("node_ID") & ""

                    If con.SqlDs(fetchstaff).Tables(0).Rows.Count > 0 Then
                        Me.Label24.Visible = True
                        Me.txtstaffID.Visible = True
                    Else
                        Me.Label24.Visible = False
                        Me.txtstaffID.Visible = False
                    End If
                    rebind1()
                    rebind2()


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
                    Me.Label22.Text = ""

                    'Image1.Visible = False
                    smartobj.alertwindow(Me.Page, "Product Type Does Not Exist", "Prime")

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
                Me.Label22.Text = ""

                'Image1.Visible = False
                smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                Exit Sub
            End If

        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "Data Warning Error...", "Prime")

        End Try
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        smartobj.ClearWebPage(Me.Page)
        clear()
        Me.btnSubmit.Enabled = True
    End Sub
    Sub clear()
        Me.txtAcNumber.Text = ""
        Me.txtCRInt.Text = 0
        Me.txtDRint.Text = 0
        Me.txtacctdesc.Text = ""
        Me.txtOfficer.Text = ""
        Me.txtfullname.Text = ""
        Me.txtacctdesc.Text = ""
        Me.DrpAccountTier.SelectedIndex = 0
        Me.lblMaxCumBal.Visible = False
        lblMaxDepAmt.Visible = False
        LabelDepAmt.Visible = False
        LabelMaxCum.Visible = False
        chkyesno.Checked = False
        Label21.Visible = False
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
        Label16.Text = String.Empty
        Label17.Text = String.Empty
        Label18.Text = String.Empty
        Label19.Text = String.Empty
        Label20.Text = String.Empty

        txtAcNumber.Focus()


    End Sub
    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    Response.Redirect("default.aspx")
    'End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try

            If Me.txtDRint.Text = String.Empty Then
                Me.txtDRint.Text = "0.0"
            End If
            If Me.txtCRInt.Text = String.Empty Then
                Me.txtCRInt.Text = "0.0"
            End If
            'Dim updt As String = "Update tbl_casaaccount set Disableview='" & smartobj.DecodeCkeckBox(Me.chkyesno) & "'," & _
            '"officercode='" & Me.txtOfficer.Text.Trim & "'," & _
            '"Cintrate='" & Me.txtCRInt.Text.Trim & "',accountdesc='" & Me.txtacctdesc.Text.Trim & "',Dintrate='" & Me.txtDRint.Text.Trim & "' where accountnumber='" & Me.txtAcNumber.Text.Trim & "'"
            'con.SqlDs(updt)
            Dim insacc As String = "Declare @retval int,@retmsg varchar(100) exec Proc_updCASAAccount '" & Me.txtAcNumber.Text.Trim & "'," &
              "'" & Me.txtfullname.Text.Trim & "','" & Me.txtacctdesc.Text.Trim & "','" & Me.txtDRint.Text.Trim & "'," &
              "'" & Me.txtCRInt.Text.Trim & "','" & Me.txtOfficer.Text.Trim & "','" & Me.txtsweep.Text.Trim & "','" & Me.txtstaffID.Text.Trim & "'," &
              "" & smartobj.DecodeCkeckBox(Me.chkyesno) & "," & Session("EventLogID") & ", '" & Session("Userid").Trim & "','" & Me.DrpAccountTier.SelectedValue & "',@retval Output,@retmsg Output, " & Session("node_ID") & " select @retval 'retval' ,@retmsg 'retmsg'"

            retval = 0
            retmsg = ""

            For Each dr As Data.DataRow In con.SqlDs(insacc).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next
            clear()
            Me.btnSubmit.Enabled = False
            smartobj.ClearWebPage(Me.Page) : clear()

            smartobj.alertwindow(Me.Page, retmsg, "Prime")

        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "Error Occurred...", "Prime")
        End Try
    End Sub
    Sub searchoffc()
        Label21.Text = ""
        Dim selcust As String = "exec proc_Officers '" & Me.txtOfficer.Text & "', " & Session("node_ID") & ""
        If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                Me.Label21.Text = dr!fullname.ToString
            Next
        Else
            Me.Label21.Text = "INVALID STAFF ID"
            Exit Sub
        End If
    End Sub
    Protected Sub txtOfficer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOfficer.TextChanged
        searchoffc()
    End Sub

#Region "acctdoc"
    Sub rebind2()
        qry = "Exec proc_docAcctreq1 '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Me.GridView2.DataSource = con.SqlDs(qry).Tables(0)
        Me.GridView2.DataBind()
        If GridView2.Rows.Count > 0 Then
            Me.Btnsave1.Enabled = True
        Else
            smartobj.alertwindow(Me.Page, "No Document Attached to customer's Account", "Prime")

            Me.Btnsave1.Enabled = False

        End If
    End Sub
    Sub rebind1()

        qry = "Exec proc_docAcctreq2 '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Me.GridView1.DataSource = con.SqlDs(qry).Tables(0)
        Me.GridView1.DataBind()
        If GridView1.Rows.Count > 0 Then
            Me.Btnsave1.Enabled = True
        Else
            smartobj.alertwindow(Me.Page, "No Document Attached to customer's Account", "Prime")

            Me.Btnsave1.Enabled = False

        End If
    End Sub
#Region "Declaration"
    Dim chkrel As Integer
    Dim gvIDs As String = ""
    Dim chkBox As Boolean = False

#End Region
    Protected Sub Btnsave2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave2.Click
        Try
            For Each gv As GridViewRow In GridView1.Rows
                Dim selectedChkBxItem As CheckBox = CType(gv.FindControl("Check2"), CheckBox)
                If selectedChkBxItem.Checked Then
                    chkBox = True
                    gvIDs += CType(gv.FindControl("LblDoc2"), Label).Text.ToString
                    Dim insval As String = "Insert into tbl_accountreq(accountnumber,reqid,node_id) Values ('" & Me.txtAcNumber.Text.Trim & "','" & gvIDs & "'," & Session("node_ID") & ")"
                    con.SqlDs(insval)

                End If
            Next

            smartobj.alertwindow(Me.Page, "Record Added", "Prime")
            rebind1()
            rebind2()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Btnsave1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave1.Click
        Try
            For Each gv As GridViewRow In GridView2.Rows
                Dim selectedChkBxItem As CheckBox = CType(gv.FindControl("Check1"), CheckBox)
                If selectedChkBxItem.Checked Then
                    chkBox = True
                    gvIDs += CType(gv.FindControl("LblDoc1"), Label).Text.ToString
                    Dim insval As String = "Delete from tbl_accountreq where reqid='" & gvIDs & "' and accountnumber='" & Me.txtAcNumber.Text.Trim & "' and node_id = " & Session("node_ID") & ""
                    con.SqlDs(insval)

                End If
            Next

            smartobj.alertwindow(Me.Page, "Record Removed", "Prime")
            rebind1()
            rebind2()
        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub btnreturn2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreturn2.Click
    '    Response.Redirect("Default.aspx")
    'End Sub

    'Protected Sub Btnreturn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreturn1.Click
    '    Response.Redirect("Default.aspx")

    'End Sub
#End Region

    Protected Sub txtstaffID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstaffID.TextChanged
        Try
            qry = "Select fullname from tbl_userprofile where userid='" & Me.txtstaffID.Text.Trim & "' and node_id = " & Session("node_ID") & ""
            Dim drprept As String = ""
            Dim hh As String = ""
            If con.SqlDs(qry).Tables(0).Rows.Count > 0 Then
                Me.Label25.Visible = True
                Me.Label25.Text = con.SqlDs(qry).Tables(0).Rows(0).Item(0).ToString
            Else
                Me.Label25.Visible = False
                Me.Label25.Text = ""
                clear()
                smartobj.alertwindow(Me.Page, "Invalid Staff ID", "Prime")
                Exit Sub
            End If
        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "Data Warning Error...", "Prime")

        End Try
    End Sub
    Protected Sub DrpAccountTier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpAccountTier.SelectedIndexChanged
        If Me.DrpAccountTier.SelectedIndex <> 0 Then
            Dim QryString As String = "Select isnull(MaxDepositAmt,0)'MaxDepositAmt',isnull(MaxCummulativeBal,0)'MaxCummulativeBal' from tbl_Account_Tier where Tier_id = '" & Me.DrpAccountTier.SelectedValue & "'"
            If con.SqlDs(QryString).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(QryString).Tables(0).Rows
                    Me.LabelDepAmt.Visible = True
                    Me.LabelMaxCum.Visible = True
                    Me.lblMaxDepAmt.Visible = True
                    Me.lblMaxCumBal.Visible = True
                    Me.lblMaxDepAmt.Text = dr("MaxDepositAmt")
                    Me.lblMaxCumBal.Text = dr("MaxCummulativeBal")

                Next

            Else
                Me.LabelDepAmt.Visible = False
                Me.LabelMaxCum.Visible = False
                Me.lblMaxDepAmt.Visible = False
                Me.lblMaxCumBal.Visible = False
            End If
        Else
            Me.LabelDepAmt.Visible = False
            Me.LabelMaxCum.Visible = False
            Me.lblMaxDepAmt.Visible = False
            Me.lblMaxCumBal.Visible = False
        End If
    End Sub
End Class
