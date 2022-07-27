Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports log4net
Imports log4net.Config
Imports Toastr

Partial Class CustomerService_ReactivateAcct
    Inherits SessionCheck
    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)

    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CustomerService_ReactivateAcct))
#Region "Task"

    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    Response.Redirect("~/home.aspx")
    'End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        Try

            If Me.txtAcNumber.Text = "" Then
                'smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
				smartobj.ShowToast(Me.Page, ToastType.Error, "Enter Account Number", "Error!", ToastPosition.TopRight, True)
                Exit Sub
            End If

            If Me.txtValueDate.Text = "" Then
                'smartobj.alertwindow(Me.Page, "Enter a Value Date", "Prime")
				smartobj.ShowToast(Me.Page, ToastType.Error, "Enter a Value Date", "Error!", ToastPosition.TopRight, True)
                Exit Sub
            End If

            If Me.txtNaration.Text = "" Then
                'smartobj.alertwindow(Me.Page, "Enter Posting Narration", "Prime")
				smartobj.ShowToast(Me.Page, ToastType.Error, "Enter Posting Narration", "Error!", ToastPosition.TopRight, True)
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
            Dim selacc As String = "Select branchcode from tbl_UserProfile where userid='" & Session("Userid").Trim & "' and node_id=" & Session("Node_ID")
            If con.SqlDs(selacc).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(selacc).Tables(0).Rows(0)
                ''glnumber = drx.Item("postGl_Acctno").ToString.Trim
                branchcode = drx.Item("branchcode").ToString.Trim


            Else
                'smartobj.alertwindow(Me.Page, "You Do Not Have Posting Right", "Prime")
				smartobj.ShowToast(Me.Page, ToastType.Error, "You Do Not Have Posting Right", "Error!", ToastPosition.TopRight, True)
                smartobj.ClearWebPage(Me.Page) : clear()
                Exit Sub
            End If
            Dim overline As String = Session("overide")
            If overline = "" Then
                overline = 0
            End If

            Dim insacc As String = "Declare @retval int,@retmsg varchar(150) exec proc_InsReactivate '" & Me.txtAcNumber.Text.Trim & "'," &
           "'" & CDec("0") & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Session("Userid").Trim & "',NULL,@retVal Output,@retmsg Output," & Session("Node_ID") & " select @retval ,@retmsg"

            For Each dr As Data.DataRow In con.SqlDs(insacc).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString

            Next
            ' smartobj.ClearWebPage(Me.Page):clear

            'smartobj.alertwindow(Me.Page, retmsg, "Prime")

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
			if retval = "0" then
				smartobj.ShowToast(Me.Page, ToastType.Success, retmsg, "Yessss!", ToastPosition.TopRight, True)
				Me.Clear2()
			else
				smartobj.ShowToast(Me.Page, ToastType.Error, retmsg, "Error!", ToastPosition.TopRight, True)
			End if
            Session("overide") = ""
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: ReactivateAcct Submit BTN'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            'smartobj.alertwindow(Me.Page, "An Error has Occurred", "Prime")
			smartobj.ShowToast(Me.Page, ToastType.Error, "An Error has Occurred", "Error!", ToastPosition.TopRight, True)

        End Try

    End Sub
    Sub clear()
       
        Me.txtNaration.Text = ""
        Me.txtAcNumber.Text = ""
    End Sub
    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            smartobj.ClearWebPage(Me.Page) : clear()
            Me.Btnsubmit.Enabled = True
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
            refresh()
            txtAcNumber.Focus()
        Catch ex As Exception

            logger.Info("CUSTOMER SERVICE: REACTIVATE ACCOUNT RESET BTN'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try
    End Sub

    Protected Sub txtAcNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcNumber.TextChanged
        Try
            Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtAcNumber.Text.Trim & "', " & Session("Node_ID")
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
                Dim st As Integer = drx.Item("status")

                If (st <> 0 Or st <> 1 Or st <> 3) Then


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
                    Dim prodcode As String = drx.Item("Product Code").ToString

                    Dim prostatus As String = drx.Item("prodstatus").ToString
                    Dim prodesc As String = drx.Item("proddesc").ToString
					Dim AcctStatus as String = drx.Item("acctstatus").ToString

                    Me.txtNaration.Text = "Account Reactivation In Favour Of: " & Me.Label1.Text.Trim
                    Dim idimg As String = drx.Item("customerid").ToString.Trim
                    refresh()


                    If Me.Label9.Text <> "Active" Then
                        Me.Label9.BackColor = Drawing.Color.Red
                    Else
                        Me.Label9.BackColor = Drawing.Color.Orange
                        Me.Label9.ForeColor = Drawing.Color.Blue

                    End If

                    If prostatus = "1" Then
                        smartobj.alertwindow(Me.Page, prodesc, "Prime")
                        Me.Btnsubmit.Enabled = False
                    Else
                        Me.Btnsubmit.Enabled = True
                    End If
					
					If AcctStatus = "Active" Then
                        'smartobj.alertwindow(Me.Page, "Member Account is Active and Cannot be Reactivated ", "Prime")
						smartobj.ShowToast(Me.Page, ToastType.Error, "Member Account is Active and Cannot be Reactivated", "Error!", ToastPosition.TopRight, True)
                        Me.Btnsubmit.Enabled = False
						Me.txtNaration.Text = Nothing
                    Else
                        Me.Btnsubmit.Enabled = True
                    End If

                    'If prodcode <> "" Then
                        'Dim seldorcharge As String = "select penalty from tbl_dormancy where prodcode='" & prodcode.Trim & "'"
                        'If con.SqlDs(seldorcharge).Tables(0).Rows.Count > 0 Then
                            'Me.txtcharges.Text = con.SqlDs(seldorcharge).Tables(0).Rows(0).Item(0).ToString

                        'End If

                    'Else
                        'Me.txtcharges.Text = "0"
                    'End If

                Else

                    Dim stu As String = drx.Item("acctstatus").ToString

                    'smartobj.alertwindow(Me.Page, "Account Status is " & stu, "Prime")
					smartobj.ShowToast(Me.Page, ToastType.Error, "Account Status is " & stu, "Error!", ToastPosition.TopRight, True)

                    Exit Sub

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
                'smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")
				smartobj.ShowToast(Me.Page, ToastType.Error, "Account Number Does Not Exist", "Error!", ToastPosition.TopRight, True)

                Exit Sub
            End If
        Catch ex As Exception

            logger.Info("CUSTOMER SERVICE: REACTIVATE ACCOUNT Txt_AccountNo TEXT CHANGED'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
            'smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
			smartobj.ShowToast(Me.Page, ToastType.Error, "Error has Occurred", "Error!", ToastPosition.TopRight, True)

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
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
		
		Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)
        menuname.Text = Request.QueryString("XXX")
        If menuname.Text = "" Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Validate_Access(menuname.Text) = 0 Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        hypValueDate.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtValueDate.ClientID.ToString() + "');"
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"
        If Page.IsPostBack = False Then

            txtValueDate.Text = Format(CDate(Session("sysdate")), "dd/MM/yyyy")

        End If
    End Sub


#End Region
    Private Function FetchAllImagesInfo() As DataTable
        Dim Sql As String = "Exec Proc_SelMandateInfo '" & Me.txtAcNumber.Text.Trim & "'"
        Dim da As SqlDataAdapter = New SqlDataAdapter(Sql, MyCon)
        Dim dt As DataTable = New DataTable()
        da.Fill(dt)
        Return dt

    End Function
	
	 Function Validate_Access(ByVal MenuName As String) As Integer
        Try
            qry = " declare @retVal int " & vbNewLine
            qry = qry & "execute Proc_RM_Validate "
            qry = qry & smartobj.EncoteWithSingleQuote(Session("Roleid")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(MenuName) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Session("Userid")) & ",@retVal OUTPUT," & Session("node_id") & " "
            qry = qry & " select @retVal"

            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
            Next
            Return retval
        Catch ex As Exception
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Validating Menu", "Error!", ToastPosition.TopRight, True)
            Return retval
        End Try

    End Function
	
    Sub refresh()
        Try
            GridView1.DataSource = FetchAllImagesInfo()
            GridView1.DataBind()
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: REACTIVATE ACCOUNT Refresh Sub'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try
        'Dim ds As New DataSet
        'Dim da As SqlClient.SqlDataAdapter

        ' ''display photo'
        'Dim sel As String = "Exec Proc_SelMandateInfo '" & Me.txtAcNumber.Text.Trim & "'"
        'If con.SqlDs(sel).Tables(0).Rows.Count > 0 Then
        '    'da = New SqlClient.SqlDataAdapter(sel, MyCon)
        '    'da.Fill(ds)
        '    'ds.Tables(0).Columns.Add("imgFile")
        '    'ds.Tables(0).Columns.Add("imgFile2")

        '    'For Each tempRow As DataRow In ds.Tables(0).Rows
        '    '    ' drx=con.SqlDs (sel).Tables (0).Rows (0)
        '    '    tempRow.Item("imgFile") = ("getimg.aspx?id=" & tempRow.Item("accountnumber"))
        '    '    tempRow.Item("imgFile2") = ("getimg2.aspx?id=" & tempRow.Item("accountnumber"))

        '    'Next

        '    GridView1.DataSource = con.SqlDs(sel).Tables(0)
        '    GridView1.DataBind()
        '    GridView1.Visible = True
        'Else
        '    GridView1.Visible = False
        'End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
        refresh()

    End Sub
	
	Public Sub Clear2()
		Me.Btnsubmit.Enabled = True
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
		Me.txtNaration.Text = ""
        Me.txtAcNumber.Text = ""
		refresh()
		txtAcNumber.Focus()
	End Sub

    
End Class
