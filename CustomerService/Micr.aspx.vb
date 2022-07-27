Imports System.Web.UI.WebControls
Partial Class CustomerService_Micr
    Inherits SessionCheck
    Sub bind1()
        Dim selBind As String = "Select * from tbl_supplyrecord where status=1"

        If con.SqlDs(selBind).Tables(0).Rows.Count > 0 Then
            GridView1.DataSource = con.SqlDs(selBind)
            GridView1.DataBind()
            Me.GridView1.Visible = True
        Else
            Me.GridView1.Visible = False
        End If
    End Sub
    Sub bind2()
        Dim selBind As String = "Exec proc_custrequestlist"

        If con.SqlDs(selBind).Tables(0).Rows.Count > 0 Then
            GridView2.DataSource = con.SqlDs(selBind)
            GridView2.DataBind()
            Me.GridView2.Visible = True
        Else
            Me.GridView2.Visible = False
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        If Page.IsPostBack = False Then
          
            bind1()
            bind2()

            'Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(receiptid)) as varchar) receiptid,receiptid FROM tbl_supplyrecord where status in ('" & "1" & "','" & "M" & "')"
            'smartobj.loadComboValues("--Choose a Receipt No --- ", Me.DrpOmmit, Dstring3)

        End If
    End Sub

    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        Dim gvIDs As String = ""
        Dim chkBox As Boolean = False

        For Each gv As GridViewRow In GridView1.Rows
            Dim selectedChkBxItem As CheckBox = CType(gv.FindControl("Check1"), CheckBox)
            If selectedChkBxItem.Checked Then
                chkBox = True
                gvIDs = CType(gv.FindControl("LblDoc1"), Label).Text.ToString
                If chkBox Then
                    Try
                        Dim updMicr As String = "Update tbl_supplyrecord set status=2 where receiptid='" & gvIDs & "'"
                        con.SqlDs(updMicr)

                    Catch ex As Exception

                    End Try
                End If
            End If
        Next

        smartobj.alertwindow(Me.Page, "Cheque Request delievered from store", "Prime")
        smartobj.ClearWebPage(Me.Page)
        clear()
        Me.BtnSubmit.Enabled = False

        bind1()
    End Sub

    'Protected Sub txtReceiptid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceiptid.TextChanged
    '    Dim selrecipt As String = "Select * from tbl_Supplyrecord where receiptid='" & Me.txtReceiptid.Text.Trim & "' and status=1"
    '    If con.SqlDs(selrecipt).Tables(0).Rows.Count > 0 Then
    '        For Each dr As Data.DataRow In con.SqlDs(selrecipt).Tables(0).Rows
    '            Me.DrpSupplier.SelectedValue = dr!supplyid.ToString.Trim
    '            Me.txtQty.Text = dr!qty.ToString.Trim
    '            Me.DrpSupplier.SelectedValue = dr!supplyid.ToString.Trim
    '            Me.DrpSupplier.Enabled = False
    '            Me.txtCost.Text = dr!cost.ToString.Trim
    '            Me.txtStartNo.Text = dr!startno.ToString.Trim
    '            Me.txtEndNo.Text = dr!endno.ToString.Trim
    '            Me.txtDateReceived.Text = Format(CDate(dr!valuedate.ToString.Trim), "dd/MM/yyyy")
    '            Me.txtWayBill.Text = dr!waybill.ToString.Trim
    '            Me.txtOrder.Text = dr!orderno.ToString.Trim
    '            Me.DrpChecktype.SelectedValue = dr!chktype.ToString.Trim

    '        Next

    '        Me.DrpChecktype.Enabled = False
    '        bind3()
    '        'Me.BtnSubmit1.Enabled = True

    '    Else
    '        smartobj.alertwindow(Me.Page, "Receipt Already Micr or Invalid", "Prime")
    '        Me.Btnsubmit1.Enabled = False
    '        Me.DrpChecktype.Enabled = vbNullString

    '    End If
    'End Sub
    'Sub bind3()
    '    Dim selBind As String = "Exec Proc_SupplyRangeDetail '" & Me.txtReceiptid.Text.Trim & "'"
    '    If con.SqlDs(selBind).Tables(0).Rows.Count > 0 Then
    '        GridView3.DataSource = con.SqlDs(selBind)
    '        GridView3.DataBind()
    '        Me.GridView3.Visible = True
    '        Me.Btnsubmit1.Enabled = False
    '    Else
    '        Me.GridView3.Visible = False
    '        Me.Btnsubmit1.Enabled = True

    '    End If

    'End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    '    If Page.IsPostBack = False Then

    '        Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(typeid)) as varchar) typeid,typedesc FROM tbl_checkbooks where status=1"
    '        smartobj.loadComboValues("--Select a CheckBook Type--- ", Me.DrpChecktype, Dstring3)

    '        Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(SupplierID)) as varchar) Supplierid,Suppliername FROM tbl_supplier where status=1"
    '        smartobj.loadComboValues("--Select a Supplier Type--- ", Me.DrpSupplier, Dstring5)



    '    End If
    'End Sub

    'Protected Sub Btnsubmit1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit1.Click
    '    Try
    '        'Dim valuedate As String
    '        latesttime = System.DateTime.Parse(Me.txtDateReceived.Text)
    '        ' valuedate = Date.Parse(MyTrans1, MyCultureInfo)
    '        'latesttime = CDate(valuedate)

    '        If Me.DrpChecktype.SelectedValue = Nothing Or Me.DrpChecktype.SelectedValue = "" Then
    '            smartobj.alertwindow(Me.Page, "Please Select a Check Book Type", "Prime")
    '            smartobj.ClearWebPage(Me.Page)
    '            Exit Sub
    '        End If
    '        If IsDate(latesttime) Then
    '            latesttime = latesttime.AddHours(Now.Hour)
    '            latesttime = latesttime.AddMinutes(Now.Minute)
    '            latesttime = latesttime.AddSeconds(Now.Second)
    '            'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
    '        End If
    '        If Me.txtReceiptid.Text = "" Then
    '            Me.txtReceiptid.Text = 0
    '        End If

    '        Dim strval As String = "Declare @retval int,@retmsg varchar(100) Exec Proc_Supplyrange '" & Me.txtReceiptid.Text.Trim & "','" & Profile.Userid & "'," & _
    '             "'" & Me.txtStartNo.Text.Trim & "','" & Me.txtEndNo.Text.Trim & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "',@retval Output,@retmsg Output Select @retval,@retmsg"
    '        For Each dr As Data.DataRow In con.SqlDs(strval).Tables(0).Rows
    '            retval = dr(0).ToString
    '            retmsg = dr(1).ToString
    '        Next


    '        smartobj.alertwindow(Me.Page, retmsg, "Prime")
    '        smartobj.ClearWebPage(Me.Page)
    '        Me.Btnsubmit1.Enabled = False
    '        bind3()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Response.Redirect("Default.aspx")

    'End Sub

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    smartobj.ClearWebPage(Me.Page)
    '    Me.Btnsubmit1.Enabled = True
    'End Sub

    Sub clear()
        Me.txtChktype.Text = ""
        Me.txtEndno.Text = ""
        Me.txtreceipt.Text = ""
        Me.txtserialno.Text = ""
        Me.txtstart.Text = ""
        Me.BtnSubmit.Enabled = True
    End Sub
    Protected Sub BtnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReset.Click
        clear()
        smartobj.ClearWebPage(Me.Page)
    End Sub

    Protected Sub BtnDiscard_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Me.txtreceipt.Text <> "" Then
                If Me.Chkundo.Checked = True Then
                    Dim insdisc As String = "Exec [Proc_Discardremcheque] '" & Me.txtserialno.Text.Trim & "','" & Me.txtreceipt.Text.Trim & "'"
                    con.SqlDs(insdisc)

                Else
                    Dim insdisc As String = "Exec [Proc_DiscardAddcheque] '" & Me.txtserialno.Text.Trim & "','" & Me.txtreceipt.Text.Trim & "'"
                    con.SqlDs(insdisc)

                End If

            Else
                smartobj.alertwindow(Me.Page, "Please Enter a Receipt No", "Prime")

            End If


        Catch ex As Exception

        End Try
    End Sub


    Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncancel.Click
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub BtnDiscard_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDiscard.Click
        If Not IsNumeric(Me.txtreceipt.Text.Trim) Then
            smartobj.alertwindow(Me.Page, "Please enter a numeric Value", "Prime")
            Exit Sub

        End If
    End Sub

    Protected Sub txtreceipt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtreceipt.TextChanged
        Try
            Dim insdisc As String = "Exec proc_listchkdetail '" & Me.txtreceipt.Text.Trim & "'"
            If con.SqlDs(insdisc).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(insdisc).Tables(0).Rows(0)
                Me.txtChktype.Text = drx.Item("typedesc")
                Me.txtstart.Text = drx.Item("startno")
                Me.txtEndno.Text = drx.Item("endno")

            End If
        Catch ex As Exception

        End Try
    End Sub
 
   
End Class
