Imports System.Web.UI.WebControls
Partial Class CustomerService_ManageCheckBook
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        hypValueDate.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtReqDate.ClientID.ToString() + "');"

        If Page.IsPostBack = False Then
           
            Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(branchcode)) as varchar) branchcode,branchname FROM tbl_branch where status=1"
            smartobj.loadComboValues("--Select a Branch--- ", Me.DrpBranch1, Dstring1)

            smartobj.loadComboValues("--Select a Branch--- ", Me.DrpBranch2, Dstring1)

            Dim Dstring2 As String = "SELECT cast(ltrim(rtrim(typeid)) as varchar) typeid,typedesc FROM tbl_checkbooks where status=1"
            smartobj.loadComboValues("--Select a CheckBook Type--- ", Me.DrpChkType1, Dstring2)

            Dim Dstring4 As String = "SELECT cast(ltrim(rtrim(PRODUCTTYPEshort)) as varchar) PRODUCTTYPEshort,PRODUCTTYPEDESC FROM tbl_PRODUCTTYPE where status=1 and productclass=1"
            smartobj.loadComboValues("--Select a Account Type--- ", Me.DrpAcctType1, Dstring4)

            hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcctNo1.ClientID.ToString() + "');"


            If Request.QueryString("Chk") <> "" Then
                Try
                    Me.txtAcctNo1.Text = Request.QueryString("Chk")
                    acctdet()

                Catch ex As Exception

                End Try
            Else

            End If

        End If
    End Sub
    Sub acctdet()
        Try
            Label6.Text = ""
            Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(branchcode)) as varchar) branchcode,branchname FROM tbl_branch where status=1"
            smartobj.loadComboValues("--Select a Branch--- ", Me.DrpBranch1, Dstring1)

            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcctNo1.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAcctNo1.Text = retmsg
            End If

            Dim drsel As String = "select accounttitle,b.productname,b.apptype,branchcode from tbl_CASAAccount a,tbl_bankproduct b where a.accountnumber='" & Me.txtAcctNo1.Text & "' and a.status=1 and a.productcode=b.productcode"
            ''check apptype
            If con.SqlDs(drsel).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(drsel).Tables(0).Rows
                    Me.lblName.Text = dr!accounttitle.ToString.Trim
                    Me.DrpAcctType1.SelectedValue = dr!apptype.ToString.Trim
                    Me.DrpBranch1.SelectedValue = dr!branchcode.ToString.Trim
                    Me.Label6.Text = dr!productname.ToString.Trim

                Next
                'Dim str As String = "select * from tbl_CheqRequest a,tbl_checkbooks b where a.chktype=b.typeid and a.status=1 and a.accountnumber='" & Me.txtAcctNo1.Text.Trim & "'"

                'If con.SqlDs(str).Tables(0).Rows.Count > 0 Then
                '    drx = con.SqlDs(str).Tables(0).Rows(0)
                '    Me.DrpChkType1.SelectedValue = drx.Item("chktype").ToString
                '    Me.DrpBranch1.SelectedValue = drx.Item("sourcebr").ToString
                '    Me.DrpBranch2.SelectedValue = drx.Item("destbr").ToString
                '    Me.txtnolv.Text = drx.Item("numberofleaves").ToString
                '    Me.txtunitpr.Text = drx.Item("unitpr").ToString
                '    Me.txtReqDate.Text = Format(CDate(drx.Item("daterec").ToString), "MM-dd-yyyy")
                '    Me.txttotcost.Text = drx.Item("currentcost").ToString
                '    Me.txtNarration.Text = drx.Item("narration").ToString

                'End If

                DrpAcctType1.Enabled = False
                DrpBranch1.Enabled = False
                Me.btnsubmit.Enabled = True
                Dim startno As String = ""
                Dim endno As String = ""

                'Dim selchq As String = "declare @startno decimal(18,0),@endno decimal(18,0)exec proc_Chqrange '" & Me.txtnolv.Text.Trim & "','" & Me.DrpChkType1.SelectedValue.Trim & "',@startno output,@endno output select @startno,@endno"
                'For Each dr As Data.DataRow In con.SqlDs(selchq).Tables(0).Rows
                '    startno = dr(0).ToString
                '    endno = dr(1).ToString

                'Next

                'If endno = "0" Then
                '    Me.btnsubmit.Enabled = False
                '    smartobj.alertwindow(Me.Page, "Cheque Not Available for Ranging", "Prime")
                '    Exit Sub
                'Else
                '    Me.txtstart.Text = startno
                '    Me.txtend.Text = endno
                'End If

            Else
                DrpAcctType1.Enabled = False
                DrpBranch1.Enabled = False
                smartobj.alertwindow(Me.Page, "Invalid Account Number Or Account No Not Permitted On Cheque", "Prime")
                Me.btnsubmit.Enabled = False
            End If

        Catch ex As Exception

        End Try
        'Dim drsel As String = "select accounttitle,b.apptype,branchcode from tbl_CASAAccount a,tbl_bankproduct b where a.accountnumber='" & Me.txtacctno1.Text.Trim & "' and a.status=1 and b.apptype='" & "CK" & "' and a.productcode=b.productcode"
        ' ''check apptype
        'If con.SqlDs(drsel).Tables(0).Rows.Count > 0 Then
        '    For Each dr As Data.DataRow In con.SqlDs(drsel).Tables(0).Rows
        '        Me.lblfullname.Text = dr!accounttitle.ToString.Trim
        '        Me.DrpAcctType1.SelectedValue = dr!apptype.ToString.Trim
        '        Me.DrpBranch1.SelectedValue = dr!branchcode.ToString.Trim
        '    Next
        '    DrpAcctType1.Enabled = False
        '    DrpBranch1.Enabled = False
        '    Me.Btnsubmit.Enabled = True
        '    Dim seldes As String = "select b.typeid,destbr from tbl_cheqrequest a,tbl_checkbooks b where a.chktype=b.typeid and a.accountnumber='" & Me.txtacctno1.Text.Trim & "'"
        '    Dim dr2 As Data.DataRow
        '    dr2 = con.SqlDs(seldes).Tables(0).Rows(0)
        '    Me.DrpChktype.SelectedValue = dr2.Item("typeid").ToString.Trim
        '    Me.DrpBranch2.SelectedValue = dr2.Item("destbr").ToString.Trim
        '    Me.DrpBranch2.Enabled = False
        '    Me.DrpChktype.Enabled = False

        'Else
        '    DrpAcctType1.Enabled = False
        '    DrpBranch1.Enabled = False
        '    smartobj.alertwindow(Me.Page, "Invalid Account Number Or Account No Not Permitted On Cheque", "Prime")
        '    Me.Btnsubmit.Enabled = False
        'End If
    End Sub
    Protected Sub Txtaccountnumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtacctno1.TextChanged
        Try
            acctdet()
            Me.DrpAcctType1.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DrpChktype1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpChkType1.SelectedIndexChanged
        Session("chkno") = 0
        'Dim selno As String = "select numberofleaves from tbl_checkbooks where typeid='" & Me.DrpChkType1.SelectedValue.Trim & "' and status=1"
        'If con.SqlDs(selno).Tables(0).Rows.Count > 0 Then
        '    For Each dr As Data.DataRow In con.SqlDs(selno).Tables(0).Rows
        '        Me.txtnolv.Text = dr!numberofleaves
        '    Next
        'End If
        Me.DrpBranch2.Focus()
        Dim selchq As String = "declare @startno decimal(18,0),@endno decimal(18,0),@leaflet int,@cost decimal(18,2) exec proc_Chqrange '" & Me.DrpChkType1.SelectedValue.Trim & "',@startno output,@endno output,@leaflet output,@cost output select @startno,@endno,@leaflet,@cost"
        For Each dr As Data.DataRow In con.SqlDs(selchq).Tables(0).Rows
            '' Me.txtstart.Text = dr(0).ToString
            '' Me.txtend.Text = dr(1).ToString
            Me.txtnolv.Text = dr(2).ToString
            Me.txtcost.Text = dr(3).ToString

        Next

        If Me.txtstart.Text <> "" Then
            Me.txtend.Text = CInt(txtnolv.Text.Trim) + CInt(txtstart.Text.Trim)

        End If

    End Sub
    Protected Function DisplayBlock(ByVal Block As Integer) As String
        If Block = 2 Then
            Return "Block"
        Else
            Return "Open"
        End If
    End Function
    Sub refgrid()
        Dim chstate As String = "Select * from tbl_checkbookrecord where accountnumber='" & Me.txtAcctNo1.Text.Trim & "' and serialno='" & Me.txtstart.Text.Trim & "' and checktype='" & Me.DrpChkType1.SelectedValue.Trim & "' and status in (1,2)"
        '"and status in (1,2)"
        If con.SqlDs(chstate).Tables(0).Rows.Count > 0 Then
            Me.txtend.ReadOnly = False
            Me.txtend.AutoPostBack = True
            Me.Btnsubmit.Text = "Update"
        Else
            Me.GridView1.Visible = False
            Me.txtend.AutoPostBack = False
            Me.txtend.Text = CInt(Session("chkno")) + CInt(Me.txtstart.Text)
            Me.txtEnd.ReadOnly = True
            Me.Btnsubmit.Text = "Submit"

        End If
    End Sub
    Protected Sub txtStart_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStart.TextChanged
        Try
            refgrid()
            Me.txtend.Text = CInt(txtnolv.Text.Trim) + CInt(txtstart.Text.Trim) - 1
            'Dim chstate As String = "Select * from tbl_checkbookrecord where accountnumber='" & Me.txtAcctNo1.Text.Trim & "' and startid='" & Me.txtstart.Text.Trim & "' and checktype='" & Me.DrpChkType1.SelectedValue.Trim & "' and status in (1,2)"
            Me.txtend.Focus()

            ''Dim chstate As String = "Select * from tbl_checkbookrecord where accountnumber='" & Me.txtacctno1.Text.Trim & "' and startid='" & Me.txtStart.Text.Trim & "' and endid='" & Me.txtEnd.Text.Trim & "' and checktype='" & Me.DrpChktype.SelectedValue.Trim & "'," & _
            ''"and status in (1,2)"
            'If con.SqlDs(chstate).Tables(0).Rows.Count > 0 Then
            '    Me.GridView1.DataSource = con.SqlDs(chstate).Tables(0)
            '    Me.GridView1.DataBind()
            '    Me.GridView1.Visible = True
            '    Me.btnsubmit.Text = "Update"
            'Else
            '    Me.GridView1.Visible = False
            '    Me.btnsubmit.Text = "Submit"

            'End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        If Me.btnsubmit.Text = "Range" Then
            If Me.DrpBranch2.SelectedIndex = 0 Then
                smartobj.alertwindow(Me.Page, "Please select branch", "Alert")
                Exit Sub

            ElseIf Me.DrpChkType1.SelectedIndex = 0 Then
                smartobj.alertwindow(Me.Page, "Please select chequebook type", "Alert")
                Exit Sub

            ElseIf Me.txtReqDate.Text = "" Then
                smartobj.alertwindow(Me.Page, "Please enter request date", "Alert")
                Exit Sub
            ElseIf Me.txttotcost.Text = "" Then
                smartobj.alertwindow(Me.Page, "Please enter total cost to customer", "Alert")
                Exit Sub


            ElseIf Me.txtstart.Text = "" Then
                smartobj.alertwindow(Me.Page, "Please enter start Serial Number", "Alert")
                Exit Sub
            End If

        End If
        ' ''If Me.Btnsubmit.Text = "Update" Then
        ' ''    Dim gvIDs As String = ""
        ' ''    Dim chkBox As Boolean = False
        ' ''    Dim flag As Integer

        ' ''    For Each gv As GridViewRow In GridView1.Rows
        ' ''        Dim selectedChkBxItem As CheckBox = CType(gv.FindControl("Check1"), CheckBox)
        ' ''        If selectedChkBxItem.Checked Then
        ' ''            chkBox = True
        ' ''            gvIDs = CType(gv.FindControl("LblDoc1"), Label).Text.ToString
        ' ''            If chkBox Then
        ' ''                Try
        ' ''                    Dim selVal As String = "select status from tbl_checkbookrecord where accountnumber='" & Me.txtacctno1.Text & "' and serialno = " & gvIDs & ""
        ' ''                    Dim intval As Integer
        ' ''                    For Each dr As Data.DataRow In con.SqlDs(selVal).Tables(0).Rows
        ' ''                        intval = dr!status
        ' ''                    Next

        ' ''                    If intval = 2 Then
        ' ''                        flag = 1
        ' ''                    ElseIf intval = 1 Then
        ' ''                        flag = 2
        ' ''                    End If


        ' ''                    Dim UPdVal As String = "Update tbl_checkbookrecord set status=" & flag & " where accountnumber='" & txtacctno1.Text & "' and serialno = " & gvIDs & ""
        ' ''                    con.SqlDs(UPdVal)
        ' ''                    refgrid()
        ' ''                Catch ex As Exception
        ' ''                    smartobj.alertwindow(Me.Page, "Server Error", "Prime")
        ' ''                End Try

        ' ''            End If
        ' ''        Else
        ' ''            chkBox = False
        ' ''            flag = 1
        ' ''        End If
        ' ''    Next
        ' ''Else
        ''insert into checkbookrecord and pass to reporting level
        'Me.Btnsubmit.Text = "Submit"
        Dim chk As Integer
        'If Me.ChkCharge.Checked = True Then
        '    chk = 1
        'Else
        '    chk = 0
        'End If
        latesttime = System.DateTime.Parse(Session("sysdate"))
        ' valuedate = Date.Parse(MyTrans1, MyCultureInfo)
        'latesttime = CDate(valuedate)

        If IsDate(latesttime) Then
            latesttime = latesttime.AddHours(Now.Hour)
            latesttime = latesttime.AddMinutes(Now.Minute)
            latesttime = latesttime.AddSeconds(Now.Second)
            'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
        End If

        If Me.txttotcost.Text = "" Then
            txttotcost.Text = 0
        End If

        Dim insacc As String = "Declare @retval int,@retmsg varchar(200) exec Proc_PostCheque '" & Me.txtAcctNo1.Text.Trim & "','" & CDec(Me.txtcost.Text.Trim) & "','" & CDec(Me.txttotcost.Text.Trim) & "'," &
   "'" & Me.DrpBranch2.SelectedValue.Trim & "'," & Me.txtstart.Text.Trim & "," & Me.txtend.Text.Trim & ",'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "'," &
   "'" & Me.DrpChkType1.SelectedValue.Trim & "'," & chk & ",'" & Me.txtNarration.Text.Trim & "','" & Session("Userid").Trim & "',NULL,@retVal Output,@retmsg Output select @retval ,@retmsg"

        For Each dr As Data.DataRow In con.SqlDs(insacc).Tables(0).Rows
            retval = dr(0).ToString
            retmsg = dr(1).ToString

        Next

        smartobj.alertwindow(Me.Page, retmsg, "Prime")
        smartobj.ClearWebPage(Me.Page)
        Me.btnsubmit.Enabled = False

        'End If
        display()
        clear()

    End Sub
    Sub display()
        Try
            Dim chstate As String = "Select * from tbl_checkbookrecord where accountnumber='" & Me.txtAcctNo1.Text.Trim & "' and serialno between '" & Me.txtstart.Text.Trim & "' and '" & Me.txtend.Text.Trim & "' and checktype='" & Me.DrpChkType1.SelectedValue.Trim & "' status<>3)"
            If con.SqlDs(chstate).Tables(0).Rows.Count > 0 Then
                Me.GridView1.DataSource = con.SqlDs(chstate).Tables(0)
                Me.GridView1.DataBind()
                Me.GridView1.Visible = True

            Else
                Me.GridView1.Visible = False
            End If


        Catch ex As Exception

        End Try
    End Sub

   
    'Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncancel.Click
    '    Response.Redirect("RequestList.aspx?ID=" & 3)
    'End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Response.Redirect("default.aspx")
    'End Sub
   
    Sub clear()
        Me.txttotcost.Text = ""
        Me.txtstart.Text = ""
        Me.txtReqDate.Text = ""
        Me.txtnolv.Text = ""
        Me.txtNarration.Text = ""
        Me.txtAcctNo1.Text = ""
        Me.DrpAcctType1.SelectedValue = Nothing
        Me.DrpBranch1.SelectedValue = Nothing
        Me.DrpChkType1.SelectedValue = Nothing
        Me.btnsubmit.Enabled = True
        Me.txtend.Text = ""
        Me.txtcost.Text = ""
    End Sub
    Protected Sub btnreset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreset.Click
        Try
            clear()
            lblName.Text = ""

        Catch ex As Exception

        End Try
    End Sub

   
    Protected Sub DrpAcctType1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpAcctType1.SelectedIndexChanged
        Me.DrpBranch1.Focus()
    End Sub

    Protected Sub DrpBranch1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpBranch1.SelectedIndexChanged
        Me.DrpChkType1.Focus()
    End Sub

    Protected Sub DrpBranch2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpBranch2.SelectedIndexChanged
        Me.txtnolv.Focus()
    End Sub

    Protected Sub txtnolv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnolv.TextChanged
        Me.txtcost.Focus()
    End Sub

    Protected Sub txtcost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcost.TextChanged
        Me.txtReqDate.Focus()
    End Sub

    Protected Sub txtReqDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReqDate.TextChanged
        Me.txttotcost.Focus()
    End Sub

    Protected Sub txtend_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtend.TextChanged
        Me.txtNarration.Focus()
    End Sub

    Protected Sub txtNarration_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNarration.TextChanged
        Me.btnsubmit.Focus()
    End Sub

    Protected Sub txttotcost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttotcost.TextChanged
        Try

            txttotcost.Text = smartobj.FormatMoney(txttotcost.Text)

            Me.txtstart.Focus()
            Dim midv As String = Mid(Me.Label6.Text.Trim, 1, 4)
            If midv = "staf" Or midv = "STAF" Then

            Else

                If CDec(Me.txttotcost.Text.Trim) < CDec(Me.txtcost.Text.Trim) Then
                    smartobj.alertwindow(Me.Page, "Cost to Customer Must not be less than Cheque book cost", "Prime")
                    Me.btnsubmit.Enabled = False
                    Exit Sub
                Else
                    Me.btnsubmit.Enabled = True

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
