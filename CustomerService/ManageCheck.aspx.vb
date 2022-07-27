Imports System.Web.UI.WebControls
Partial Class CustomerService_ManageCheck
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""

    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, _
      ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick
        Try
            MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value)
            Dim i As Integer
            'Make the selected menu item reflect the correct imageurl
            For i = 0 To Menu1.Items.Count - 1
                If i = e.Item.Value Then
                    Menu1.Items(i).ImageUrl = "~/Images/pic2.gif"
                Else
                    Menu1.Items(i).ImageUrl = "~/Images/pic1.gif"
                End If

            Next
            If Me.MultiView1.ActiveViewIndex = 0 Then
                qry = "Select * from tbl_bank"
                Dim chksupp As Integer
                For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                    chksupp = dr("ReqChqsupply").ToString.Trim

                Next
                If chksupp = 0 Then
                    Me.BtnSubmit1.Enabled = False
                    smartobj.alertwindow(Me.Page, "Cheque Supply Management Not Activated", "Prime")
                    Exit Sub
                Else
                    Me.BtnSubmit1.Enabled = True

                End If
            End If


        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "Data Server Error....", "Prime")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcctNo1.ClientID.ToString() + "');"
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        If Page.IsPostBack = False Then

            MultiView1.ActiveViewIndex = 0
            imgdate3.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtValueDate.ClientID.ToString() + "');"
            Me.HyperLink1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtReqDate.ClientID.ToString() + "');"
            Me.HyperLink2.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtDateReceived.ClientID.ToString() + "');"

            Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(branchcode)) as varchar) branchcode,branchname FROM tbl_branch where status=1"
            smartobj.loadComboValues("--Select a Branch--- ", Me.DrpBranch1, Dstring1)

            smartobj.loadComboValues("--Select a Branch--- ", Me.DrpBranch2, Dstring1)

            Dim Dstring2 As String = "SELECT cast(ltrim(rtrim(typeid)) as varchar) typeid,typedesc FROM tbl_checkbooks where status=1"
            smartobj.loadComboValues("--Select a CheckBook Type--- ", Me.DrpChkType1, Dstring2)

            smartobj.loadComboValues("--Select a CheckBook Type--- ", Me.DrpChkBook1, Dstring2)
            Dim Dstring4 As String = "SELECT cast(ltrim(rtrim(Apptypename)) as varchar) Apptypename,Apptypename FROM tbl_apptype where status=1"
            smartobj.loadComboValues("--Select a Application Type--- ", Me.DrpAcctType1, Dstring4)

            Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(SupplierID)) as varchar) Supplierid,Suppliername FROM tbl_supplier where status=1"
            smartobj.loadComboValues("--Select a Supplier Type--- ", Me.DrpSupplier, Dstring5)

            If Request.QueryString("Chk") <> "" Then
                MultiView1.ActiveViewIndex = 0
                Me.txtReceiptid.Text = Request.QueryString("Chk")
                Me.txtReceiptid.Visible = True
                Me.Label1.Visible = True
                Me.BtnSubmit1.Text = "Authorise"
                serchdt()
            Else
                Me.txtReceiptid.Visible = False
                Me.Label1.Visible = False
            End If

        End If
    End Sub

    Protected Sub txtAcctNo3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcctNo3.TextChanged
        Try
            Dim drsel As String = "select accounttitle,b.apptype from tbl_CASAAccount a,tbl_bankproduct b where a.accountnumber='" & Me.txtAcctNo3.Text & "' and a.status=1 and a.productcode=b.productcode"
            ''check apptype
            If con.SqlDs(drsel).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(drsel).Tables(0).Rows
                    Me.txtAcctName.Text = dr!accounttitle.ToString
                Next
                Me.Btnsubmit.Enabled = True

            Else
                smartobj.alertwindow(Me.Page, "Account Number Not Permitted On Cheque", "Prime")
                Me.Btnsubmit.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        'Dim valuedate As String
        latesttime = system.DateTime.Parse(Me.txtValueDate.Text)
        ' valuedate = Date.Parse(MyTrans1, MyCultureInfo)
        'latesttime = CDate(valuedate)
        Try

            If IsDate(latesttime) Then
                latesttime = latesttime.AddHours(Now.Hour)
                latesttime = latesttime.AddMinutes(Now.Minute)
                latesttime = latesttime.AddSeconds(Now.Second)
                'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
            End If
            Dim strval As String = ""
            If Me.RDBHotList.SelectedValue = "2" Then
                strval = "Declare @retval int,@retmsg varchar(100) Exec Proc_addHotList '" & Me.txtAcctNo3.Text.Trim.Replace("'", " ") & "'," &
                          "'" & Me.DrpChkBook1.SelectedValue.Trim & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.txtStart2.Text.Trim.Replace("'", " ") & "'," &
                          "'" & Me.txtEnd2.Text.Trim.Replace("'", " ") & "','" & Me.txtReason.Text.Trim.Replace("'", " ") & "','" & Session("Userid").Trim & "',@retval Output,@retmsg Output Select @retval,@retmsg"

            ElseIf Me.RDBHotList.SelectedValue = "1" Then
                strval = "Declare @retval int,@retmsg varchar(100) Exec Proc_remHotList '" & Me.txtAcctNo3.Text.Trim.Replace("'", " ") & "'," &
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

    Protected Sub txtAcctNo1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcctNo1.TextChanged
        Try
            Dim drsel As String = "select accounttitle,b.apptype,branchcode from tbl_CASAAccount a,tbl_bankproduct b where a.accountnumber='" & Me.txtAcctNo1.Text & "' and a.status=1 and b.apptype='" & "CK" & "' and a.productcode=b.productcode"
            ''check apptype
            If con.SqlDs(drsel).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(drsel).Tables(0).Rows
                    Me.txtAcctName2.Text = dr!accounttitle.ToString.Trim
                    Me.DrpAcctType1.SelectedValue = dr!apptype.ToString.Trim
                    Me.DrpBranch1.SelectedValue = dr!branchcode.ToString.Trim
                Next
                DrpAcctType1.Enabled = False
                DrpBranch1.Enabled = False
                Me.Btnsubmit.Enabled = True

            Else
                DrpAcctType1.Enabled = False
                DrpBranch1.Enabled = False
                smartobj.alertwindow(Me.Page, "Invalid Account Number Or Account No Not Permitted On Cheque", "Prime")
                Me.Btnsubmit.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim valuedate As String
        latesttime = System.DateTime.Parse(Me.txtReqDate.Text)
        ' valuedate = Date.Parse(MyTrans1, MyCultureInfo)
        'latesttime = CDate(valuedate)

        If IsDate(latesttime) Then
            latesttime = latesttime.AddHours(Now.Hour)
            latesttime = latesttime.AddMinutes(Now.Minute)
            latesttime = latesttime.AddSeconds(Now.Second)
            'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
        End If

        Dim strval As String = "Declare @retval int,@retmsg varchar(100) Exec Proc_ChqReq '" & Me.txtAcctNo1.Text.Trim.Replace("'", " ") & "'," &
        "'" & Me.DrpChkType1.SelectedValue.Trim & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.DrpBranch1.SelectedValue.Trim & "'," &
        "'" & Me.DrpBranch2.SelectedValue.Trim & "','" & Me.txtNarration.Text.Trim.Replace("'", " ") & "','" & Session("Userid") & "',@retval Output,@retmsg Output Select @retval,@retmsg"

        For Each dr As Data.DataRow In con.SqlDs(strval).Tables(0).Rows
            retval = dr(0).ToString
            retmsg = dr(1).ToString
        Next

        smartobj.alertwindow(Me.Page, retmsg, "Prime")
        smartobj.ClearWebPage(Me.Page)
        Me.Button1.Enabled = False
    End Sub


    Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncancel.Click
        smartobj.ClearWebPage(Me.Page)
        Me.txtAcctNo3.Text = ""
        Me.DrpChkBook1.SelectedValue = Nothing
        Me.txtStart2.Text = ""
        Me.txtEnd2.Text = ""
        Me.txtReason.Text = ""

        Me.Btnsubmit.Enabled = True
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        smartobj.ClearWebPage(Me.Page)
        Me.txtAcctNo1.Text = ""
        Me.DrpChkType1.SelectedValue = Nothing
        Me.DrpBranch1.SelectedValue = Nothing
        Me.DrpBranch2.SelectedValue = Nothing
        Me.txtNarration.Text = ""

        Me.Button1.Enabled = True
    End Sub

    Protected Sub BtnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReset.Click
        'smartobj.ClearWebPage(Me.Page)
        Me.txtReceiptid.Text = ""
        Me.DrpSupplier.SelectedValue = Nothing
        Me.txtOrder.Text = ""
        Me.txtQty.Text = ""
        Me.txtWayBill.Text = ""
        Me.txtCost.Text = ""
        Me.txtStartNo.Text = ""
        Me.txtEndNo.Text = ""
        Me.RDBOption.SelectedValue = Nothing

    End Sub
    Protected Sub RDBOption_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBOption.SelectedIndexChanged
        If Me.RDBOption.SelectedValue = "1" Then
            Me.Label1.Visible = False
            Me.txtReceiptid.Visible = False
            Me.txtReceiptid.Text = ""
            Me.BtnSubmit1.Text = "Submit"
            smartobj.ClearWebPage(Me.Page)
            Me.txtQty.Text = ""
            Me.txtCost.Text = ""
            Me.txtStartNo.Text = ""
            Me.txtEndNo.Text = ""
            Me.txtDateReceived.Text = ""
            Me.txtWayBill.Text = ""
            Me.txtOrder.Text = ""

        Else
            Me.BtnSubmit1.Text = "Update"
            Me.Label1.Visible = True
            Me.txtReceiptid.Visible = True
            Me.txtReceiptid.Text = ""
            smartobj.ClearWebPage(Me.Page)
            Me.txtQty.Text = ""
            Me.txtCost.Text = ""
            Me.txtStartNo.Text = ""
            Me.txtEndNo.Text = ""
            Me.txtDateReceived.Text = ""
            Me.txtWayBill.Text = ""
            Me.txtOrder.Text = ""

        End If
    End Sub
    Sub serchdt()
        Dim selrecipt As String = "Select * from tbl_Supplyrecord where receiptid='" & Me.txtReceiptid.Text.Trim & "'"
        If con.SqlDs(selrecipt).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selrecipt).Tables(0).Rows
                Me.DrpSupplier.SelectedValue = dr!supplyid.ToString.Trim
                Me.txtQty.Text = dr!qty.ToString.Trim
                Me.DrpSupplier.SelectedValue = dr!supplyid.ToString.Trim
                Me.txtCost.Text = CInt(dr!cost.ToString.Trim)
                Me.txtStartNo.Text = dr!startno.ToString.Trim
                Me.txtEndNo.Text = dr!endno.ToString.Trim
                Me.txtDateReceived.Text = Format(CDate(dr!valuedate.ToString.Trim), "dd/MM/yyyy")
                Me.txtWayBill.Text = dr!waybill.ToString.Trim
                Me.txtOrder.Text = dr!orderno.ToString.Trim

            Next
            Me.BtnSubmit1.Enabled = True

        Else
            smartobj.alertwindow(Me.Page, "Supply Receipt Not Valid", "Prime")
            Me.BtnSubmit1.Enabled = False
        End If
    End Sub
    Protected Sub txtReceiptid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceiptid.TextChanged
        serchdt()
    End Sub

    Protected Sub BtnSubmit1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit1.Click
        'Dim valuedate As String
        If Me.txtDateReceived.Text <> "" Then
            latesttime = System.DateTime.Parse(Me.txtDateReceived.Text)

        End If

        ' valuedate = Date.Parse(MyTrans1, MyCultureInfo)
        'latesttime = CDate(valuedate)

        If IsDate(latesttime) Then
            latesttime = latesttime.AddHours(Now.Hour)
            latesttime = latesttime.AddMinutes(Now.Minute)
            latesttime = latesttime.AddSeconds(Now.Second)
            'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
        End If

        If Me.txtReceiptid.Text = "" Then
            Me.txtReceiptid.Text = 0
        End If
        If Me.BtnSubmit1.Text = "Submit" Or Me.BtnSubmit1.Text = "Update" Then
            Dim strval As String = "Declare @retval int,@retmsg varchar(100) Exec Proc_Receipt '" & Me.txtReceiptid.Text.Trim.Replace("'", " ") & "'," &
                   "'" & Me.DrpSupplier.SelectedValue.Trim & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.txtOrder.Text.Trim.Replace("'", " ") & "','" & Me.txtQty.Text.Trim.Replace("'", " ") & "'," &
                   "'" & Me.txtWayBill.Text.Trim.Replace("'", " ") & "','" & Me.txtCost.Text.Trim.Replace("'", " ") & "','" & Me.txtStartNo.Text.Trim.Replace("'", " ") & "'," &
                   "'" & Me.txtEndNo.Text.Trim.Replace("'", " ") & "','" & Me.RDBOption.SelectedValue.Trim & "','" & Session("Userid").Trim & "',@retval Output,@retmsg Output Select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(strval).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next
            smartobj.alertwindow(Me.Page, retmsg, "Prime")
            smartobj.ClearWebPage(Me.Page)
            Me.BtnSubmit1.Enabled = False

        ElseIf Btnsubmit.Text = "Authorise" Then
            Dim strval As String = "Declare @retval int,@retmsg varchar(100) Exec Proc_ReceiptAuth '" & Me.txtReceiptid.Text.Trim.Replace("'", " ") & "','" & Session("Userid") & "'," &
       "@retval Output,@retmsg Output Select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(strval).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next
            smartobj.alertwindow(Me.Page, retmsg, "Prime")
            smartobj.ClearWebPage(Me.Page)
            Me.BtnSubmit1.Enabled = False

        End If

    End Sub


    Protected Sub txtStartNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStartNo.TextChanged
        Me.txtEndNo.Text = CInt(Me.txtStartNo.Text.Trim) + CInt(Me.txtQty.Text.Trim) - 1
    End Sub

    Protected Sub txtStart2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStart2.TextChanged
        Try

            qry = "Declare @retval int,@retmsg varchar(100) exec Proc_ValChknum '" & Me.txtStart2.Text.Trim & "','" & Me.txtAcctNo3.Text.Trim & "'," & _
            "@retval output,@retmsg output select @retval ,@retmsg"

            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next
            If retval <> "0" Then
                smartobj.alertwindow(Me.Page, retmsg, "Prime")
                smartobj.ClearWebPage(Me.Page)
                Me.Btnsubmit.Enabled = False
            Else
                Me.Btnsubmit.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtEnd2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEnd2.TextChanged
        Try

            qry = "Declare @retval int,@retmsg varchar(100) exec Proc_ValChknum '" & Me.txtEnd2.Text.Trim & "','" & Me.txtAcctNo3.Text.Trim & "'," & _
            "@retval output,@retmsg output select @retval ,@retmsg"

            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next
            If retval <> "0" Then
                smartobj.alertwindow(Me.Page, retmsg, "Prime")
                smartobj.ClearWebPage(Me.Page)
                Me.Btnsubmit.Enabled = False
            Else
                Me.Btnsubmit.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Response.Redirect("Default.aspx")
    End Sub

   
End Class
