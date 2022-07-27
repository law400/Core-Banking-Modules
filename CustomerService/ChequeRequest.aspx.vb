Imports System.Web.UI.WebControls
Partial Class CustomerService_ChequeRequest
    Inherits SessionCheck
    Public qry As String
    Public Bvalid As Boolean
    Public maindesc As String = "Department Creation"
    Dim retmsg As String = ""
    Dim retval As Integer
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

                showedit()
            Else
                showlist()
            End If
        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "Data Server Error....", "Prime")
        End Try
    End Sub

    Sub showadd()
        Me.btnsubmit.Text = "Submit"
        smartobj.ClearWebPage(Me.Page)
        Me.MultiView1.Visible = False
        btnsubmit.Enabled = True

    End Sub
    Sub showedit()
        Me.btnsubmit.Text = "Update"
        smartobj.ClearWebPage(Me.Page)
        Me.MultiView1.Visible = False
        btnsubmit.Enabled = True


    End Sub
    Sub showlist()
        Me.MultiView1.Visible = True
        MultiView1.ActiveViewIndex = 0
        btnsubmit.Enabled = False
    End Sub
    Sub bind2()
        Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcctNo1.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
        For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
            retval = dr(0).ToString
            retmsg = dr(1).ToString
        Next

        If retval = "0" Then
            Me.txtAcctNo1.Text = retmsg
        End If

        Dim selBind As String = "exec proc_Accountcheque '" & Me.txtAcctNo1.Text.Trim & "'"
        If con.SqlDs(selBind).Tables(0).Rows.Count > 0 Then
            GridView1.DataSource = con.SqlDs(selBind)
            GridView1.DataBind()
            Me.GridView1.Visible = True
        Else
            Me.GridView1.Visible = False
        End If

    End Sub

    Sub clearer()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            If Me.btnsubmit.Text = "Submit" Then
                If Me.DrpBranch2.SelectedValue.Length < 2 Then
                    smartobj.alertwindow(Me.Page, "Please Choose a Destination Branch", "Prime")
                    Exit Sub
                End If
                If IsDate(latesttime) Then
                    latesttime = latesttime.AddHours(Now.Hour)
                    latesttime = latesttime.AddMinutes(Now.Minute)
                    latesttime = latesttime.AddSeconds(Now.Second)
                    'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
                End If

                Dim strval As String = "Declare @retval int,@retmsg varchar(100) Exec Proc_insChqReq '" & Me.txtAcctNo1.Text.Trim.Replace("'", " ") & "'," &
                "'" & Me.DrpChkType1.SelectedValue.Trim & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.DrpBranch1.SelectedValue.Trim & "'," &
                "'" & Me.DrpBranch2.SelectedValue.Trim & "','" & Me.txtNarration.Text.Trim.Replace("'", " ") & "'," & CDec(Me.txttotcost.Text.Trim) & "," & CInt(Me.txtnolv.Text.Trim) & "," & CDec(Me.txtunitpr.Text.Trim) & ",'" & Session("Userid") & "',NULL,@retVal Output,@retmsg Output Select @retval,@retmsg"

                For Each dr As Data.DataRow In con.SqlDs(strval).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next

                smartobj.alertwindow(Me.Page, retmsg, "Prime")
                smartobj.ClearWebPage(Me.Page)
                Me.lblName.Text = ""
                Me.btnsubmit.Enabled = False

            ElseIf Me.btnsubmit.Text = "Update" Then

                Dim strval As String = "Declare @retval int,@retmsg varchar(100) Exec Proc_insChqReq '" & Me.txtAcctNo1.Text.Trim.Replace("'", " ") & "'," &
   "'" & Me.DrpChkType1.SelectedValue.Trim & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.DrpBranch1.SelectedValue.Trim & "'," &
   "'" & Me.DrpBranch2.SelectedValue.Trim & "','" & Me.txtNarration.Text.Trim.Replace("'", " ") & "'," & CDec(Me.txttotcost.Text.Trim) & "," & CInt(Me.txtnolv.Text.Trim) & "," & CDec(Me.txtunitpr.Text.Trim) & ",'" & Session("Userid") & "',@retval Output,@retmsg Output Select @retval,@retmsg"

                For Each dr As Data.DataRow In con.SqlDs(strval).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next

            End If
            Me.GridView1.DataBind()


        Catch ex As Exception

        End Try
    End Sub

    Sub detail2()
        Try
            ''check apptype
            Dim drsel As String = "select accounttitle,b.apptype,branchcode from tbl_CASAAccount a,tbl_bankproduct b where a.accountnumber='" & Me.txtAcctNo1.Text & "' and a.status=1 and a.productcode=b.productcode"

            If con.SqlDs(drsel).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(drsel).Tables(0).Rows
                    Me.lblName.Text = dr!accounttitle.ToString.Trim
                    Me.DrpAcctType1.SelectedValue = dr!apptype.ToString.Trim
                    Me.DrpBranch1.SelectedValue = dr!branchcode.ToString.Trim
                Next
                If Me.DrpAcctType1.SelectedItem.Text <> "CK" Then
                    smartobj.alertwindow(Me.Page, "Cheque Request is not Granted on a Non- Checking Account", "Prime")
                    smartobj.ClearWebPage(Me.Page)
                    Me.DrpAcctType1.SelectedValue = vbNullString
                    Me.DrpBranch1.SelectedValue = vbNullString
                    Exit Sub
                End If
                DrpAcctType1.Enabled = False
                DrpBranch1.Enabled = False
                Me.btnsubmit.Enabled = True

                Dim drsel2 As String = "select * from dbo.tbl_CheqRequest where id=" & Me.GridView1.SelectedValue & " and accountnumber='" & Me.txtAcctNo1.Text.Trim & "'"

                Me.txtReqDate.Text = con.SqlDs(drsel2).Tables(0).Rows(0).Item("daterec").ToString
                Me.txtNarration.Text = con.SqlDs(drsel2).Tables(0).Rows(0).Item("narration").ToString
                Me.txttotcost.Text = con.SqlDs(drsel2).Tables(0).Rows(0).Item("costtocustomer").ToString
                Me.DrpChkType1.SelectedValue = con.SqlDs(drsel2).Tables(0).Rows(0).Item("chktype").ToString
                Me.txtunitpr.Text = con.SqlDs(drsel2).Tables(0).Rows(0).Item("currentcost").ToString
                Me.txtnolv.Text = con.SqlDs(drsel2).Tables(0).Rows(0).Item("numberofleaves").ToString
                Dim status As Integer = con.SqlDs(drsel2).Tables(0).Rows(0).Item("status").ToString

                ''if status<>1  disable
                If status <> 1 Then
                    Me.btnsubmit.Enabled = False
                Else
                    Me.btnsubmit.Enabled = True
                End If
            Else
                DrpAcctType1.Enabled = False
                DrpBranch1.Enabled = False
                smartobj.alertwindow(Me.Page, "Invalid Account Number Or Account No Not Permitted On Cheque", "Prime")
                Me.btnsubmit.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub


    Sub detail()
        Try
            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcctNo1.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAcctNo1.Text = retmsg
            End If
            Dim drsel As String = "select accounttitle,b.apptype,branchcode from tbl_CASAAccount a,tbl_bankproduct b where a.accountnumber='" & Me.txtAcctNo1.Text & "' and a.status=1 and a.productcode=b.productcode"
            ''check apptype
            If con.SqlDs(drsel).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(drsel).Tables(0).Rows
                    Me.lblName.Text = dr!accounttitle.ToString.Trim
                    Me.DrpAcctType1.SelectedValue = dr!apptype.ToString.Trim
                    Me.DrpBranch1.SelectedValue = dr!branchcode.ToString.Trim
                Next
                If Me.DrpAcctType1.SelectedItem.Text <> "CK" Then
                    smartobj.alertwindow(Me.Page, "Cheque Request is not Granted on a Non- Checking Account", "Prime")
                    smartobj.ClearWebPage(Me.Page)
                    Me.DrpAcctType1.SelectedValue = vbNullString
                    Me.DrpBranch1.SelectedValue = vbNullString
                    Exit Sub
                End If
                DrpAcctType1.Enabled = False
                DrpBranch1.Enabled = False
                Me.btnsubmit.Enabled = True

            Else
                DrpAcctType1.Enabled = False
                DrpBranch1.Enabled = False
                smartobj.alertwindow(Me.Page, "Invalid Account Number Or Account No Not Permitted On Cheque", "Prime")
                Me.btnsubmit.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        ''  Me.txthidden.Text = Me.GridView1.SelectedValue
        detail2()
    End Sub

    Protected Sub BtnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreset.Click
        Try
            clearer()
        Catch ex As Exception

        End Try
    End Sub

    
    Protected Sub txtAcctNo1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcctNo1.TextChanged
        bind2()
        detail()
    End Sub

  
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcctNo1.ClientID.ToString() + "');"
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        If Page.IsPostBack = False Then
           
            Me.HyperLink1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtReqDate.ClientID.ToString() + "');"

            Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(branchcode)) as varchar) branchcode,branchname FROM tbl_branch where status=1"
            smartobj.loadComboValues("--Select a Branch--- ", Me.DrpBranch1, Dstring1)

            smartobj.loadComboValues("--Select a Branch--- ", Me.DrpBranch2, Dstring1)

            Dim Dstring2 As String = "SELECT cast(ltrim(rtrim(typeid)) as varchar) typeid,typedesc FROM tbl_checkbooks where status=1"
            smartobj.loadComboValues("--Select a CheckBook Type--- ", Me.DrpChkType1, Dstring2)

            Dim Dstring4 As String = "SELECT cast(ltrim(rtrim(Apptypename)) as varchar) Apptypename,Apptypename FROM tbl_apptype where status=1"
            smartobj.loadComboValues("--Select a Application Type--- ", Me.DrpAcctType1, Dstring4)
            Me.lblName.Text = ""


        End If
    End Sub

    Protected Sub DrpChkType1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpChkType1.SelectedIndexChanged
        Try

            Dim selcost As String = "Select * from tbl_checkbooks where typeid='" & Me.DrpChkType1.SelectedValue.Trim & "'"
            If con.SqlDs(selcost).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(selcost).Tables(0).Rows(0)
                Me.txtunitpr.Text = drx.Item("currentcost").ToString
                Me.txtnolv.Text = drx.Item("numberofleaves").ToString
            End If

            Me.txttotcost.Text = CDec(Me.txtunitpr.Text.Trim) * CDec(Me.txtnolv.Text.Trim)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class
