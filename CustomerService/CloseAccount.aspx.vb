Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Partial Class CustomerService_CloseAccount
    Inherits SessionCheck
    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)

    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""

#Region "Task"

    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    ''' Response.Redirect("~/home.aspx")

    '    Dim url As String = "~/Tenant" + Session("node_ID").ToString + "/Home.aspx"


    '    ''   Response.Redirect("~/Home.aspx")
    '    Response.Redirect(url)
    'End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        Try

            ''If CDec(Me.Label6.Text.Trim) < 0 Then
            ''    smartobj.alertwindow(Me.Page, "Can Not Close Account In Debit", "Prime")
            ''    Exit Sub
            ''End If

            If Me.txtAcNumber.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
                txtAcNumber.Focus()
                Exit Sub
            End If

            If Me.txtValueDate.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter a Value Date", "Prime")
                txtValueDate.Focus()
                Exit Sub
            End If

            If Me.txtNaration.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Posting Narration", "Prime")
                txtNaration.Focus()
                Exit Sub
            End If

            If Me.DrpMigrated.SelectedIndex = "0" Then
                smartobj.alertwindow(Me.Page, "Select Closure Account for Balance Movement", "Prime")
                DrpMigrated.Focus()
                Exit Sub
            End If

            'If Me.txtPayAmount.Text = "" Then
            '    smartobj.alertwindow(Me.Page, "Enter Posting amount", "Prime")
            '    Exit Sub
            'End If

            latesttime = CDate(Me.txtValueDate.Text)
            ' valuedate = Date.Parse(MyTrans1, MyCultureInfo)
            'latesttime = CDate(valuedate)

            If IsDate(latesttime) Then
                latesttime = latesttime.AddHours(Now.Hour)
                latesttime = latesttime.AddMinutes(Now.Minute)
                latesttime = latesttime.AddSeconds(Now.Second)
                'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
            End If



            Dim branchcode As String
            Dim selacc As String = "Select branchcode from tbl_UserProfile where userid='" & Session("Userid").Trim & "' and node_id = " & Session("node_ID") & ""
            If con.SqlDs(selacc).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(selacc).Tables(0).Rows(0)
                ''glnumber = drx.Item("postGl_Acctno").ToString.Trim
                branchcode = drx.Item("branchcode").ToString.Trim


            Else
                smartobj.alertwindow(Me.Page, "You Do Not Have Posting Right", "Prime")
                smartobj.ClearWebPage(Me.Page) : clear()
                Exit Sub
            End If


            Dim insacc As String = "Declare @retval int,@retmsg varchar(200) exec proc_InsertClosure '" & Me.txtAcNumber.Text.Trim & "'," &
           "'" & CDec(Me.Label10.Text.Trim) & "','" & CDec(Me.Label11.Text.Trim) & "','" & CDec(Me.txtcharges.Text.Trim) & "', " &
           "'" & CDec(Me.Label6.Text.Trim) & "','" & Me.DrpMigrated.SelectedValue.Trim & "','" & Session("Userid").Trim & "',NULL,@retVal Output,@retmsg Output," & Session("node_ID") & " select @retval ,@retmsg"

            For Each dr As Data.DataRow In con.SqlDs(insacc).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString

            Next
            ' smartobj.ClearWebPage(Me.Page):clear
            clear()
            smartobj.alertwindow(Me.Page, retmsg, "Prime")

            ''qry = "Declare @retval int,@retmsg varchar(100) exec Proc_InsertCASA '" & glnumber & "'," & _
            ''"'" & Me.txtAcNumber.Text.Trim & "','" & CDbl(Me.txtTransAmount.Text.Trim) & "','" & "001" & "'," & _
            ''"'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "',null,'" & Session("Userid").Trim & "',null,'" & Me.txtNaration.Text.Trim & "'," & _
            ''"'" & Me.drpCurrency.SelectedValue.Trim & "'," & CInt(Me.txtRate.Text.Trim) & ",'" & Me.txtTellerNo.Text.Trim & "'," & _
            ''"null,null,null,NULL,@retVal output,@retmsg output select @retval ,@retmsg"


            'If behav = 2 Then
            '    Me.btnSubmit.Enabled = False
            '    smartobj.alertwindow(Me.Page, retmsg, "Prime")
            '    Response.Write("<script>window.open('/Prime/BankingOperations/Override.aspx', 'overlinePopup','titlebar=no,left=50,top=100,width=220,height=220,resizable=no');</script>")

            'Else
            '    smartobj.alertwindow(Me.Page, retmsg, "Prime")
            '    smartobj.ClearWebPage(Me.Page):clear
            '    Me.btnSubmit.Enabled = True

            'End If
            Session("overide") = ""
        Catch ex As Exception

        End Try

    End Sub
    Sub clear()
        Me.txtcharges.Text = ""
        Me.txtMigrated.Text = ""
        Me.txtNaration.Text = ""
        Me.txtAcNumber.Text = ""
        Me.txtValueDate.Text = ""
        GridView1.DataSource = Nothing
        GridView1.DataBind()
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
        Me.Label12.Text = ""
        Me.Label13.Text = ""
        Me.Label13.Text = ""
        Me.Label14.Text = ""
        Me.Label15.Text = ""
        Me.Label16.Text = ""
        Me.DrpMigrated.SelectedIndex = "0"

    End Sub
    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            smartobj.ClearWebPage(Me.Page) : clear()
            Me.Btnsubmit.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

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


            Dim selfind2 As String = "Select accountnumber from tbl_casaaccount where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and status=3 and node_id = " & Session("node_ID") & ""
            If con.SqlDs(selfind2).Tables(0).Rows.Count > 0 Then
                smartobj.alertwindow(Me.Page, "Account Already Closed", "Prime")
                Me.Btnsubmit.Enabled = False
                Exit Sub
            Else
                Me.Btnsubmit.Enabled = True

            End If

            Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
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
                Me.Label4.Text = drx.Item("bkbal").ToString
                Me.Label5.Text = drx.Item("effbal").ToString
                Me.Label6.Text = drx.Item("usebal").ToString
                Me.Label7.Text = drx.Item("acctty").ToString
                Me.Label8.Text = drx.Item("source").ToString
                Me.Label9.Text = drx.Item("acctstatus").ToString
                Me.Label10.Text = drx.Item("cintrate").ToString
                Me.Label11.Text = drx.Item("dintrate").ToString
                Me.Label12.Text = drx.Item("Pendingc").ToString
                Me.Label16.Text = drx.Item("ClosingCharge").ToString
                Me.Label13.Text = drx.Item("od").ToString
                Me.Label14.Text = drx.Item("holdbal").ToString
                ''Me.txtCharges.Text = drx.Item("ClosingCharge").ToString

                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString

                Me.txtNaration.Text = "Account Closure In Favour Of: " & Me.Label1.Text.Trim

                Me.txtcharges.Text = CDec(Me.Label12.Text.Trim) + CDec(Me.Label16.Text.Trim)

                Dim idimg As String = drx.Item("customerid").ToString.Trim

                refresh()

                If Me.Label9.Text = "Active" Then
                    Me.AcctStatus.Attributes.Add("class", "pull-right badge bg-green")
                Else

                    Me.AcctStatus.Attributes.Add("class", "pull-right badge bg-red")

                End If
                If drx.Item("bkbal") > 0 Then

                    Me.BookBalance.Attributes.Add("class", "pull-right badge bg-green")
                Else

                    Me.BookBalance.Attributes.Add("class", "pull-right badge bg-red")

                End If
                If drx.Item("effbal") > 0 Then

                    Me.EffectiveBal.Attributes.Add("class", "pull-right badge bg-green")
                Else

                    Me.EffectiveBal.Attributes.Add("class", "pull-right badge bg-red")

                End If

                If drx.Item("usebal") > 0 Then

                    Me.UsableBal.Attributes.Add("class", "pull-right badge bg-green")
                Else

                    Me.UsableBal.Attributes.Add("class", "pull-right badge bg-red")

                End If

                If prostatus = "1" Then
                    smartobj.alertwindow(Me.Page, prodesc, "Prime")
                    Me.Btnsubmit.Enabled = False
                Else
                    Me.Btnsubmit.Enabled = True
                End If
                'selcurrency()
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
                Me.Label12.Text = ""
                smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub
    Function FormatURL(ByVal strArgument As String) As String
        Return ("~/Customerservice/getimg.aspx?id=" & strArgument)
    End Function
#End Region
#Region "Declaration"
    Dim anx As Date
    Dim glnumber As String = ""
#End Region
#Region "PageLoad"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = ""
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "CLOSE ACCOUNT" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        hypValueDate.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtValueDate.ClientID.ToString() + "');"
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"
        Me.HyperLink1.NavigateUrl = "javascript:accountGLPicker('document.aspnetForm." + txtMigrated.ClientID.ToString() + "');"

        If Page.IsPostBack = False Then
            Me.Label15.Text = "Enter Account to Move Balance If Customer has more than One Account. Or Leave Blank to Move to Closing GL Account."
            txtValueDate.Text = Format(CDate(Session("sysdate")), "dd/MM/yyyy")

            Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(glnumber)) as varchar) glnumber,concat(ltrim(rtrim(glnumber)),' >> ', ltrim(rtrim(Acctname))) 'AcctName' FROM tbl_bankgl where node_id= " & Session("node_id") & " and substring(glnumber,11,4)<>'0000' order by glnumber "
            smartobj.loadComboValues("--Select a Closure Account--- ", Me.DrpMigrated, Dstring3)

        End If
    End Sub


#End Region
    Private Function FetchAllImagesInfo() As DataTable
        Dim Sql As String = "Exec Proc_SelMandateInfo '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Dim da As SqlDataAdapter = New SqlDataAdapter(Sql, MyCon)
        Dim dt As DataTable = New DataTable()
        da.Fill(dt)
        Return dt

    End Function
    Sub refresh()
        Try
            GridView1.DataSource = FetchAllImagesInfo()
            GridView1.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
        refresh()

    End Sub

    Protected Sub txtMigrated_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMigrated.TextChanged
        Try

            If Me.txtMigrated.Text <> "" Then
                Dim selacct3 As String = "select accountnumber,accounttitle from tbl_casaaccount where accountnumber='" & Me.txtMigrated.Text.Trim & "' and status=1 and node_id = " & Session("node_ID") & ""
                If con.SqlDs(selacct3).Tables(0).Rows.Count > 0 Then
                    Me.Btnsubmit.Enabled = True
                Else
                    smartobj.alertwindow(Me.Page, "Account Number Does not Exist", "")
                    Me.Btnsubmit.Enabled = False
                    Exit Sub
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
    '    If Session("node_ID") = Nothing Then
    '        Response.Redirect("../PageExpire.aspx")
    '    Else
    '        Me.MasterPageFile = "~/Tenant" + Session("node_ID").ToString + "/Tenant.master"

    '    End If
    'End Sub

End Class
