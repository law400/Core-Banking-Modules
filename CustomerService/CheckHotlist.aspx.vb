Imports System.Web.UI.WebControls
Partial Class CustomerService_CheckHotlist
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Protected Sub Btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        Try

            If IsDate(latesttime) Then
                latesttime = latesttime.AddHours(Now.Hour)
                latesttime = latesttime.AddMinutes(Now.Minute)
                latesttime = latesttime.AddSeconds(Now.Second)
                'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
            End If
            Dim strval As String = ""
            If Me.RDBHotList.SelectedValue = "2" Then
                strval = "Declare @retval int,@retmsg varchar(100) Exec Proc_addHotList '" & Me.txtAcctNo.Text.Trim.Replace("'", " ") & "'," &
                          "'" & Me.DrpChkBook1.SelectedValue.Trim & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.txtStart2.Text.Trim.Replace("'", " ") & "'," &
                          "'" & Me.txtEnd2.Text.Trim.Replace("'", " ") & "','" & Me.txtReason.Text.Trim.Replace("'", " ") & "','" & Session("Userid").Trim & "',@retval Output,@retmsg Output Select @retval,@retmsg"

            ElseIf Me.RDBHotList.SelectedValue = "1" Then
                strval = "Declare @retval int,@retmsg varchar(100) Exec Proc_remHotList '" & Me.txtAcctNo.Text.Trim.Replace("'", " ") & "'," &
                          "'" & Me.DrpChkBook1.SelectedValue.Trim & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.txtStart2.Text.Trim.Replace("'", " ") & "'," &
                          "'" & Me.txtEnd2.Text.Trim.Replace("'", " ") & "','" & Me.txtReason.Text.Trim.Replace("'", " ") & "','" & Session("Userid").Trim & "',@retval Output,@retmsg Output Select @retval,@retmsg"

            End If

            For Each dr As Data.DataRow In con.SqlDs(strval).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            smartobj.alertwindow(Me.Page, retmsg, "Prime")
            smartobj.ClearWebPage(Me.Page)
            Me.Btnsubmit.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtAcctNo3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcctNo.TextChanged
        Try
            ''acctdet()
        Catch ex As Exception

        End Try
    End Sub
    'Sub acctdet()
    '    Try

    '        Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcctNo.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
    '        For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
    '            retval = dr(0).ToString
    '            retmsg = dr(1).ToString
    '        Next

    '        If retval = "0" Then
    '            Me.txtAcctNo.Text = retmsg
    '        End If

    '        Dim drsel As String = "select accounttitle,b.apptype,branchcode from tbl_CASAAccount a,tbl_bankproduct b where a.accountnumber='" & Me.txtAcctNo.Text & "' and a.status=1 and a.productcode=b.productcode"
    '        ''check apptype
    '        If con.SqlDs(drsel).Tables(0).Rows.Count > 0 Then
    '            For Each dr As Data.DataRow In con.SqlDs(drsel).Tables(0).Rows
    '                Me.txtAcctName.Text = dr!accounttitle.ToString.Trim
    '                Me.DrpChkBook1.SelectedValue = dr!apptype.ToString.Trim
    '            Next
    '            'Dim str As String = "select * from tbl_CheqRequest a,tbl_checkbooks b where a.chktype=b.typeid and a.status=1 and a.accountnumber='" & Me.txtAcctNo1.Text.Trim & "'"

    '            'If con.SqlDs(str).Tables(0).Rows.Count > 0 Then
    '            '    drx = con.SqlDs(str).Tables(0).Rows(0)
    '            '    Me.DrpChkType1.SelectedValue = drx.Item("chktype").ToString
    '            '    Me.DrpBranch1.SelectedValue = drx.Item("sourcebr").ToString
    '            '    Me.DrpBranch2.SelectedValue = drx.Item("destbr").ToString
    '            '    Me.txtnolv.Text = drx.Item("numberofleaves").ToString
    '            '    Me.txtunitpr.Text = drx.Item("unitpr").ToString
    '            '    Me.txtReqDate.Text = Format(CDate(drx.Item("daterec").ToString), "MM-dd-yyyy")
    '            '    Me.txttotcost.Text = drx.Item("currentcost").ToString
    '            '    Me.txtNarration.Text = drx.Item("narration").ToString

    '            'End If

    '            Me.DrpChkBook1.Enabled = False
    '            Me.Btnsubmit.Enabled = True
    '            Dim startno As String = ""
    '            Dim endno As String = ""

    '            'Dim selchq As String = "declare @startno decimal(18,0),@endno decimal(18,0)exec proc_Chqrange '" & Me.txtnolv.Text.Trim & "','" & Me.DrpChkType1.SelectedValue.Trim & "',@startno output,@endno output select @startno,@endno"
    '            'For Each dr As Data.DataRow In con.SqlDs(selchq).Tables(0).Rows
    '            '    startno = dr(0).ToString
    '            '    endno = dr(1).ToString

    '            'Next

    '            'If endno = "0" Then
    '            '    Me.btnsubmit.Enabled = False
    '            '    smartobj.alertwindow(Me.Page, "Cheque Not Available for Ranging", "Prime")
    '            '    Exit Sub
    '            'Else
    '            '    Me.txtstart.Text = startno
    '            '    Me.txtend.Text = endno
    '            'End If

    '        Else
    '            Me.DrpChkBook1.Enabled = False
    '            smartobj.alertwindow(Me.Page, "Invalid Account Number Or Account No Not Permitted On Cheque", "Prime")
    '            Me.btnsubmit.Enabled = False
    '        End If

    '    Catch ex As Exception

    '    End Try
    '    'Dim drsel As String = "select accounttitle,b.apptype,branchcode from tbl_CASAAccount a,tbl_bankproduct b where a.accountnumber='" & Me.txtacctno1.Text.Trim & "' and a.status=1 and b.apptype='" & "CK" & "' and a.productcode=b.productcode"
    '    ' ''check apptype
    '    'If con.SqlDs(drsel).Tables(0).Rows.Count > 0 Then
    '    '    For Each dr As Data.DataRow In con.SqlDs(drsel).Tables(0).Rows
    '    '        Me.lblfullname.Text = dr!accounttitle.ToString.Trim
    '    '        Me.DrpAcctType1.SelectedValue = dr!apptype.ToString.Trim
    '    '        Me.DrpBranch1.SelectedValue = dr!branchcode.ToString.Trim
    '    '    Next
    '    '    DrpAcctType1.Enabled = False
    '    '    DrpBranch1.Enabled = False
    '    '    Me.Btnsubmit.Enabled = True
    '    '    Dim seldes As String = "select b.typeid,destbr from tbl_cheqrequest a,tbl_checkbooks b where a.chktype=b.typeid and a.accountnumber='" & Me.txtacctno1.Text.Trim & "'"
    '    '    Dim dr2 As Data.DataRow
    '    '    dr2 = con.SqlDs(seldes).Tables(0).Rows(0)
    '    '    Me.DrpChktype.SelectedValue = dr2.Item("typeid").ToString.Trim
    '    '    Me.DrpBranch2.SelectedValue = dr2.Item("destbr").ToString.Trim
    '    '    Me.DrpBranch2.Enabled = False
    '    '    Me.DrpChktype.Enabled = False

    '    'Else
    '    '    DrpAcctType1.Enabled = False
    '    '    DrpBranch1.Enabled = False
    '    '    smartobj.alertwindow(Me.Page, "Invalid Account Number Or Account No Not Permitted On Cheque", "Prime")
    '    '    Me.Btnsubmit.Enabled = False
    '    'End If
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'hypValueDate.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtReqDate.ClientID.ToString() + "');"

    End Sub
End Class
