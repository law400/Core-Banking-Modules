Imports System.Web.UI.WebControls
Partial Class CustomerService_AccountHold
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
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

            If e.Item.Text = "Add Lien" Then
                showadd()
            ElseIf e.Item.Text = "Release Lien" Then

                showedit()
            Else
                showlist()
            End If
        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "Data Server Error....", "Prime")
        End Try
    End Sub
    Sub showadd()

        Me.BtnSubmit.Text = "Submit"
        smartobj.ClearWebPage(Me.Page)
        Me.MultiView1.Visible = False
        BtnSubmit.Enabled = True
        ' reset()
    End Sub
    Sub showedit()
        Me.BtnSubmit.Text = "Release"
        smartobj.ClearWebPage(Me.Page)
        Me.MultiView1.Visible = False
        BtnSubmit.Enabled = True
        ' reset()

    End Sub
    Sub showlist()
        Me.MultiView1.Visible = True
        MultiView1.ActiveViewIndex = 0
        BtnSubmit.Enabled = False
    End Sub
    Protected Sub Btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        Try
            Dim retVal As String = "1"
            Dim retMsg As String = ""
            Dim ans1, ans2 As DateTime
            ' Dim userid As String = Session("Userid").ToString

            If Me.Txtaccountnumber.Text = "" Then
                smartobj.alertwindow(Me.Page, "Please enter accountnumber", "Prime")
                Txtaccountnumber.Focus()
                Exit Sub
            End If
            If txtAmount.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Amount", "Prime")
                txtAmount.Focus()
                Exit Sub
            End If
            If TxtStartDate.Text <> "" Then
                Try
                    ans1 = CDate(TxtStartDate.Text.Trim)
                Catch ex As Exception
                    smartobj.alertwindow(Me.Page, "Date Format Not supported", "Prime")
                    TxtStartDate.Focus()
                    Exit Sub
                End Try

            Else
                smartobj.alertwindow(Me.Page, "Enter Start Date", "Prime")
                TxtStartDate.Focus()
                Exit Sub
            End If

            If TxtEnddate.Text <> "" Then
                Try
                    Dim MyTrans As String = Trim(TxtEnddate.Text)
                    ans2 = CDate(TxtEnddate.Text.Trim)

                Catch ex As Exception
                    smartobj.alertwindow(Me.Page, "Date Format Not supported", "Prime")
                    TxtEnddate.Focus()
                    Exit Sub
                End Try

            Else
                smartobj.alertwindow(Me.Page, "Enter End Date", "Prime")
                TxtEnddate.Focus()
                Exit Sub
            End If
            If Me.Txtnarration.Text = "" Then
                smartobj.alertwindow(Me.Page, "Please select narration", "Prime")
                Txtnarration.Focus()
                Exit Sub
            End If

            If Me.RDBLien.SelectedValue = 0 Then
                smartobj.alertwindow(Me.Page, "Please select Lien Option", "Prime")
                RDBLien.Focus()
                Exit Sub
            End If


            ''If Format(CDate(ans1), "MM-dd-yyyy") > Format(CDate(ans2), "MM-dd-yyyy") Then
            ''    smartobj.alertwindow(Me.Page, "Start Date Must be Less than End Date", "Prime")
            ''    Exit Sub
            ''End If

            ans1 = Convert.ToDateTime(Me.TxtEnddate.Text.Trim)
            ans2 = Convert.ToDateTime(Me.TxtStartDate.Text.Trim)

            ''ans1 = Format(ans1, "MM-dd-yyyy")
            ''ans2 = Format(ans2, "MM-dd-yyyy")

            If ans1 < ans2 Then
                smartobj.alertwindow(Me.Page, "Start Date Must be Less than End Date", "Prime")
                '' Me.BtnSubmit.Enabled = False
                Exit Sub
            Else
                '' Me.BtnSubmit.Enabled = True

            End If
            If Not IsNumeric(txtAmount.Text) Or Val(txtAmount.Text) < 0 Then
                smartobj.alertwindow(Me.Page, "Hold Amount Amount must be numeric", "Prime")
                Exit Sub
            End If

            Dim lienoption As String = Me.RDBLien.SelectedValue.Trim

            If Me.Menu1.SelectedValue = "0" Or Me.Menu1.SelectedValue = "" Then
                qry = "declare @retVal int,@retMsg varchar(100) execute Proc_insaddHold '" & Me.Txtaccountnumber.Text & "'," & CDec(txtAmount.Text.Trim) & "," & CInt(Me.txtSeqNo.Text.Trim) & ",'" & Format(CDate(ans2), "MM/dd/yyyy hh:mm:ss") & "','" & Format(CDate(ans1), "MM/dd/yyyy hh:mm:ss") & "','" & Me.Txtnarration.Text.Trim & "','" & lienoption & "','" & Session("Userid").ToString & "',NULL,@retVal OUTPUT,@retMsg OUTPUT, " & Session("node_ID") & " select @retVal,@retMsg"

            ElseIf Me.Menu1.SelectedValue = "1" Then
                qry = "declare @retVal int,@retMsg varchar(100) execute Proc_insRemHold '" & Me.Txtaccountnumber.Text & "'," & CInt(Me.DrpSerial.SelectedValue.Trim) & ",'" & Session("Userid").ToString & "',NULL,@retVal OUTPUT,@retMsg OUTPUT," & Session("node_ID") & " select @retVal,@retMsg"
            End If

            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retMsg = ""
                retVal = dr(0).ToString
                retMsg = dr(1).ToString
            Next

            If retVal = "0" Then
                smartobj.alertwindow(Me.Page, retMsg, "Prime")
                Me.Btnsubmit.Enabled = False
                clear()
            Else
                Me.Btnsubmit.Enabled = True
                smartobj.alertwindow(Me.Page, retMsg, "Prime")
            End If



            Me.GridView1.DataBind()
        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

        End Try
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ImgDate.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + TxtStartDate.ClientID.ToString() + "');"
        Me.HyperLink1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + TxtEnddate.ClientID.ToString() + "');"
        Hypsearch.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + Txtaccountnumber.ClientID.ToString() + "');"
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = ""
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "MANAGE LIEN" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)

        menuname.Text = Request.QueryString("XXX")
        If menuname.Text = "" Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Validate_Access(menuname.Text) = 0 Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Page.IsPostBack = False Then
            Menu1.Items(0).Selected = True

        End If
    End Sub
    Protected Sub Txtaccountnumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtaccountnumber.TextChanged
        Try
            reset()
        Catch ex As Exception
            detail()
        End Try

    End Sub
    Sub reset()

        DrpSerial.Items.Clear()
        Dim app As String = ""
        DrpSerial.Items.Add(" ")

        If Me.Menu1.SelectedItem.Text.Trim = "Add Lien" Then
            detail()
        Else

            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.Txtaccountnumber.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.Txtaccountnumber.Text = retmsg
            End If
            If Me.Txtaccountnumber.Text = "" Then
                Exit Sub
            End If
            Dim seltyp As String = "Select accounttitle,* from tbl_holdtrans a,tbl_casaaccount b where a.accountnumber='" & Me.Txtaccountnumber.Text.Trim & "' and a.status=1 and a.accountnumber=b.accountnumber and b.node_id = " & Session("node_ID") & " and a.node_id = b.node_id"
            If con.SqlDs(seltyp).Tables(0).Rows.Count > 0 Then

                For Each dr As Data.DataRow In con.SqlDs(seltyp).Tables(0).Rows
                    Me.txtAccountName.Text = dr!accounttitle.ToString.Trim
                    DrpSerial.Items.Add(dr!holdnumber.ToString)
                Next
                Me.DrpSerial.Visible = True
                Me.txtSeqNo.Visible = False
                Me.txtAmount.Enabled = False
                Me.TxtStartDate.Enabled = False
                Me.TxtEnddate.Enabled = False
                Me.ImgDate.Enabled = False
                Me.HyperLink1.Enabled = False
                Me.Txtnarration.ReadOnly = True
            Else
                smartobj.alertwindow(Me.Page, "No Lien Placed On Account.", "Prime")
                Me.txtAccountName.Text = ""
                Exit Sub
            End If
        End If


    End Sub
    Sub detail()
        Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.Txtaccountnumber.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
        For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
            retval = dr(0).ToString
            retmsg = dr(1).ToString
        Next

        If retval = "0" Then
            Me.Txtaccountnumber.Text = retmsg
        End If

        Dim seltyp As String = "Select accountnumber,accounttitle,apptype,isnull(a.lien,0) lien from tbl_bankproduct a,tbl_casaaccount b where a.productcode=b.productcode and b.accountnumber='" & Me.Txtaccountnumber.Text.Trim & "' and b.node_id = " & Session("node_ID") & " and a.node_id = b.node_id"
        If con.SqlDs(seltyp).Tables(0).Rows.Count > 0 Then
            Dim lien As String = ""
            For Each dr As Data.DataRow In con.SqlDs(seltyp).Tables(0).Rows
                Me.txtAccountName.Text = dr!accounttitle.ToString.Trim
                lien = dr!lien.ToString.Trim

            Next
            If lien = "0" Then
                smartobj.alertwindow(Me.Page, "Lien is not Permitted On this Product Account", "Prime")
                Me.Txtaccountnumber.Text = ""
                Exit Sub
            End If
            Dim selacct As String = "select count(1) from tbl_holdTrans where accountnumber='" & Me.Txtaccountnumber.Text.Trim & "' and node_id = " & Session("node_ID") & ""
            Dim dr2 As Data.DataRow
            dr2 = con.SqlDs(selacct).Tables(0).Rows(0)
            Dim val As Integer = dr2.Item(0).ToString
            Me.txtSeqNo.Text = val + 1

            Me.DrpSerial.Visible = False
            Me.txtSeqNo.Visible = True
            Me.txtAmount.Enabled = True
            Me.TxtStartDate.Enabled = True
            Me.TxtEnddate.Enabled = True
            Me.ImgDate.Enabled = True
            Me.HyperLink1.Enabled = True
            Me.Txtnarration.ReadOnly = False
        Else
            smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")
            Me.txtAccountName.Text = ""
            Exit Sub
        End If

    End Sub
    Protected Sub DrpSerial_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpSerial.SelectedIndexChanged
        Try
            Dim seltyp As String = "Select * from tbl_holdtrans where accountnumber='" & Me.Txtaccountnumber.Text.Trim & "' and status=1 and holdnumber='" & Me.DrpSerial.SelectedValue.Trim & "' and node_id = " & Session("node_ID") & ""
            Dim dr2 As Data.DataRow
            dr2 = con.SqlDs(seltyp).Tables(0).Rows(0)
            'Me.txtAccountName.Text = dr2.Item("accounttitle").ToString
            'Me.txtAmount.Text = dr2.Item("accounttitle").ToString
            Me.txtAmount.Text = dr2.Item("holdamount").ToString
            Me.TxtStartDate.Text = Format(CDate(dr2.Item("effective_dt").ToString), "dd/MM/yyyy")
            Me.TxtEnddate.Text = Format(CDate(dr2.Item("end_dt").ToString), "dd/MM/yyyy")
            Me.Txtnarration.Text = dr2.Item("Holdreason").ToString
        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")
        End Try

    End Sub
    Sub clear()
        Me.txtAccountName.Text = ""
        Me.Txtaccountnumber.Text = ""
        Me.txtAmount.Text = ""
        Me.TxtEnddate.Text = ""
        Me.Txtnarration.Text = ""
        Me.txtSeqNo.Text = ""
        Me.TxtStartDate.Text = ""
    End Sub
    Protected Sub BtnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReset.Click
        Try
            smartobj.ClearWebPage(Me.Page) : clear()
            Me.BtnSubmit.Enabled = True

        Catch ex As Exception

        End Try
    End Sub
    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    Try
    '        Response.Redirect("Default.aspx")
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub txtAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        Try
            txtAmount.Text = smartobj.FormatMoney(txtAmount.Text)

        Catch ex As Exception

        End Try
    End Sub
End Class
