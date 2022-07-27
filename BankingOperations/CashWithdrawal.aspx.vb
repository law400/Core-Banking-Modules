Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports Telerik.Web.UI
Imports log4net
Imports log4net.Config
Partial Class cashwithdral
    Inherits SessionCheck
    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(cashwithdral))

    Private Bsubmit As Boolean
#Region "Task"
    Protected Sub txtPayAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPayAmount.TextChanged
        Try
            txtPayAmount.Text = smartobj.FormatMoney(txtPayAmount.Text)
            txtTransAmount.Text = CInt(txtRate.Text.Trim) * CDec(txtPayAmount.Text.Trim)
            txtTransAmount.Text = smartobj.FormatMoney(txtTransAmount.Text)
            Me.txtTellerNo.Focus()
        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "Invalid Amount Specified", "Halt")
        End Try
    End Sub
    Sub till()
        Dim strTill As String = "Exec [proc_tellerBalance] '" & Session("Userid").ToString.Trim & "'," & Session("node_ID") & ""
        Me.GridView2.DataSource = con.SqlDs(strTill).Tables(0)
        Me.GridView2.DataBind()
    End Sub
    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    ''  Response.Redirect("~/home.aspx")
    '    Dim url As String = "~/Tenant" + Session("node_ID").ToString + "/Home.aspx"


    '    ''   Response.Redirect("~/Home.aspx")
    '    Response.Redirect(url)
    'End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try

            If Bsubmit = False Then
                Bsubmit = True
                Me.btnSubmit.Enabled = False

                Dim selex As String = "Select accountno from tbl_postlog where accountno='" & Me.txtAcNumber.Text.Trim & "' and node_id=" & Session("node_ID")
                If con.SqlDs(selex).Tables(0).Rows.Count > 0 Then
                    Exit Sub
                Else

                    Dim inst As String = "Insert into tbl_postlog(AccountNo,node_id) Values ('" & Me.txtAcNumber.Text.Trim & "'," & Session("node_ID") & ")"
                    con.SqlDs(inst)

                End If

                If Me.txtTellerNo.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Teller No", "Prime")
                    txtTellerNo.Focus()
                    Exit Sub
                End If

                If Not IsNumeric(Me.txtTellerNo.Text) Then
                    smartobj.alertwindow(Me.Page, "Teller Number Must Be Numeric ", "Prime")
                    txtTellerNo.Focus()
                    Exit Sub
                End If
                If Me.txtAcNumber.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
                    txtAcNumber.Focus()
                    Exit Sub
                End If
                If Len(Me.txtNaration.Text.Trim) > 60 Then
                    smartobj.alertwindow(Me.Page, "Narration Too Long", "Prime")
                    txtNaration.Focus()
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

                If Me.txtPayAmount.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Posting amount", "Prime")
                    txtPayAmount.Focus()
                    Exit Sub
                End If

                latesttime = CDate(Me.txtValueDate.Text)
                If IsDate(latesttime) Then
                    latesttime = latesttime.AddHours(Now.Hour)
                    latesttime = latesttime.AddMinutes(Now.Minute)
                    latesttime = latesttime.AddSeconds(Now.Second)
                End If

                Dim branchcode As String
                Dim selacc As String = "Select branchcode,postGl_Acctno from tbl_UserProfile where userid='" & Session("Userid").Trim & "' and node_id = " & Session("node_ID") & ""
                If con.SqlDs(selacc).Tables(0).Rows.Count > 0 Then
                    drx = con.SqlDs(selacc).Tables(0).Rows(0)
                    glnumber = drx.Item("postGl_Acctno").ToString.Trim
                    branchcode = drx.Item("branchcode").ToString.Trim

                    If glnumber = "" Then
                        smartobj.alertwindow(Me.Page, "You Do Not Have Posting Right Account number", "Prime")
                        Exit Sub
                    End If

                Else
                    smartobj.alertwindow(Me.Page, "You Do Not Have Posting Right", "Prime")
                    smartobj.ClearWebPage(Me.Page) : clear()
                    Exit Sub
                End If

                Dim overline As String
                Dim overlineid As String

                If Session("overide") = "1" Then
                    If Session("valid") <> "0" Then
                        smartobj.alertwindow(Me.Page, "Transaction Was Not Overriden.Please Re-Post Transaction", "Prime")
                        smartobj.ClearWebPage(Me.Page)
                        Exit Sub
                    Else
                        overline = Session("overide")
                        overlineid = Session("overideid")
                    End If

                Else
                    overline = 0
                    overlineid = 0
                End If
                qry = "Declare @retval int,@behav int,@retmsg varchar(100) exec Proc_InfoPosting '" & Me.txtAcNumber.Text.Trim & "'," &
                 "'" & glnumber & "'," & CDbl(Me.txtTransAmount.Text.Trim) & ",'" & "522" & "','" & "008" & "'," &
                 "'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Session("Userid").Trim & "',null,'" & branchcode & "','" & Me.txtNaration.Text.Trim.Replace("'", "") & "','" & "0" & "'," &
                 "'" & Me.drpCurrency.SelectedValue.Trim & "','" & "1" & "','" & "2" & "'," & CInt(Me.txtRate.Text.Trim) & ",'" & Me.txtTellerNo.Text.Trim & "'," &
                 "null,null,null,null,null,null,'" & overline & "','" & overlineid & "',null,@behav output,@retval output,@retmsg output," & Session("node_ID") & " select @behav, @retval ,@retmsg"


                For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                    behav = dr(0).ToString
                    retval = dr(1).ToString
                    retmsg = dr(2).ToString
                Next

                'If behav = 2 Then
                If behav > 1 Then
                    ''Me.btnSubmit.Enabled = False
                    Dim selex1 As String = "Delete from tbl_postlog where accountno='" & Me.txtAcNumber.Text.Trim & "' and node_id = " & Session("node_ID") & ""
                    con.SqlDs(selex1)

                    smartobj.alertwindow(Me.Page, retmsg & " Choose Overide Button and Call For Override", "Prime")
                    ''Response.Write("<script>window.open('/Prime/BankingOperations/Override.aspx', 'overlinePopup','titlebar=no,left=50,top=100,width=220,height=220,resizable=no');</script>")
                    HypAuth.Visible = True
                    Me.btnSubmit.Enabled = True
                    'Session("overide") = "1"
                    Session("overide") = "0"
                    Me.btnAppoff.Enabled = True
                    Exit Sub
                Else
                    smartobj.alertwindow(Me.Page, retmsg, "Prime")
                    smartobj.ClearWebPage(Me.Page) : clear()
                    '' Me.btnSubmit.Enabled = False
                    Me.btnSubmit.Enabled = False

                    HypAuth.Visible = False
                    Me.btnAppoff.Enabled = False

                End If

                If retval = 0 Then
                    Me.btnSubmit.Enabled = False

                    Dim selex1 As String = "Delete from tbl_postlog where accountno='" & Me.txtAcNumber.Text.Trim & "' and node_id = " & Session("node_ID") & ""
                    con.SqlDs(selex1)



                Else
                    Me.btnSubmit.Enabled = True
                End If
                Session("overide") = ""
                Session("overideid") = ""
                Session("valid") = ""
                Bsubmit = False

            End If

            till()
        Catch ex As Exception
            logger.Info("BANKING OPERATION: CASH WITHDRAW SUBMIT BTN'" _
         & vbNewLine & "   <<<<Direction: OUTPUT" _
         & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
         & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
         & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
         & vbNewLine & "******************************************************************************************************")
            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try

    End Sub
    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            smartobj.ClearWebPage(Me.Page) : clear()
            Me.btnAppoff.Enabled = True
            Me.btnSubmit.Enabled = True
            Session("overide") = ""
            Session("overideid") = ""
            Session("valid") = ""
            Label1.Text = String.Empty
            Label2.Text = String.Empty
            Label3.Text = String.Empty
            Label4.Text = String.Empty
            Label5.Text = String.Empty
            Label6.Text = String.Empty
            Label7.Text = String.Empty
            Label8.Text = String.Empty
            Label9.Text = String.Empty
            Label12.Text = String.Empty
            txtTransAmount.Text = String.Empty
            refresh()
            txtAcNumber.Focus()
        Catch ex As Exception
            logger.Info("BANKING OPERATION: CASH WITHDRAW RESET BTN'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try
    End Sub
    Sub selcurrency()
        Try
            Dim Lock As Integer
            qry = "Select lockcurrency,country from tbl_bank where node_id = " & Session("node_ID") & ""
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
            logger.Info("BANKING OPERATION: CASH WITHDRAW SELECT CURRENCY'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try
    End Sub
    'Protected Sub txtTellerNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTellerNo.TextChanged
    '    Try

    '        qry = "Declare @retval int,@retmsg varchar(100) exec proc_validatetill '" & Me.txtTellerNo.Text.Trim & "','" & Me.txtAcNumber.Text.Trim & "'," & _
    '        "'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "',@retval output,@retmsg output select @retval ,@retmsg"

    '        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
    '            retval = dr(0).ToString
    '            retmsg = dr(1).ToString
    '        Next
    '        If retval <> "0" Then
    '            smartobj.alertwindow(Me.Page, retmsg, "Prime")
    '             smartobj.ClearWebPage(Me.Page): Clear
    '            Me.btnSubmit.Enabled = False
    '        Else
    '            Me.btnSubmit.Enabled = True
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub txtAcNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcNumber.TextChanged


        Session("Custchg1") = ""
        'post = Guid.NewGuid.ToString
        'Dim xItem As New ListItem
        'xItem.Text = post

        Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
        For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
            retval = dr(0).ToString
            retmsg = dr(1).ToString
        Next

        If retval = "0" Then
            Me.txtAcNumber.Text = retmsg
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
            Session("Custchg1") = Me.txtAcNumber.Text.Trim
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

            Me.Label12.Text = drx.Item("TotalCharge").ToString

            'If Me.Label9.Text <> "Active" Then
            '    Me.Label9.BackColor = Drawing.Color.Red
            'Else
            '    Me.Label9.BackColor = Drawing.Color.Orange
            '    Me.Label9.ForeColor = Drawing.Color.Blue

            'End If


            If Me.Label12.Text.Trim <> "" Then
                If CDec(Me.Label12.Text.Trim) > 0 Then
                    Me.LnkCharge.Visible = True
                Else
                    Me.LnkCharge.Visible = False

                End If
            End If

            Dim idimg As String = drx.Item("customerid").ToString.Trim

            refresh()
            ''end display photo
            Dim selex As String = "Delete from tbl_postlog where accountno='" & Me.txtAcNumber.Text.Trim & "' and node_id=" & Session("node_ID") & ""
            con.SqlDs(selex)

            Me.txtPayAmount.Focus()

            Me.txtNaration.Text = "Csh Wtd By " & Me.Label1.Text.Trim

            If prostatus = "1" Then
                smartobj.alertwindow(Me.Page, prodesc, "Prime")
                Me.btnSubmit.Enabled = False
                Me.btnAppoff.Enabled = False

            Else
                Me.btnAppoff.Enabled = True
                Me.btnSubmit.Enabled = True
            End If
            selcurrency()
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
            'Image1.Visible = False
            smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

            Exit Sub
        End If


    End Sub
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
            logger.Info("BANKING OPERATION: CASH WITHDRAW GRIDVIEW REFERSH'" _
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
        LnkCharge.NavigateUrl = "javascript:Chgdetail('document.aspnetForm." + txtNoRow.ClientID.ToString() + "');"
        LnkCharge0.NavigateUrl = "javascript:acctdetail('document.aspnetForm." + txtNoRow.ClientID.ToString() + "');"

        hypValueDate.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtValueDate.ClientID.ToString() + "');"
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = ""
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "CASH WITHDRAWAL" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)

        menuname.Text = Request.QueryString("XXX")
        If menuname.Text = "" Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Validate_Access(menuname.Text) = 0 Then
            Response.Redirect("~/Unauthorize.aspx")
        End If
        txtNoRow.Text = 20
        HypAuth.NavigateUrl = "javascript:authPicker('document.aspnetForm." + txtNoRow.ClientID.ToString() + "');"

        If Page.IsPostBack = False Then
            Try
                Session("Custchg1") = ""
                till()
                If Session("valid") <> "0" Then
                    Me.btnAppoff.Enabled = True
                    Me.btnSubmit.Enabled = False
                    Session("overide") = ""
                    Session("overideid") = ""
                    Session("valid") = ""

                Else
                    Me.btnAppoff.Enabled = False
                    Me.btnSubmit.Enabled = True

                End If


                loaddate()

            Catch ex As Exception
                logger.Info("BANKING OPERATION: CASH WITHDRAW PAGE LOAD POSTBACK'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
                smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")
                Exit Sub
            End Try
            'If IsDate(latesttime) Then
            '    'latesttime = latesttime.AddHours(Now.Hour)
            '    'latesttime = latesttime.AddMinutes(Now.Minute)
            '    'latesttime = latesttime.AddSeconds(Now.Second)
            '    latesttime = Format(CDate(latesttime.Date), "dd/MM/yyyy")
            'End If
            Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(countrycode)) as varchar) countrycode,currencymne FROM tbl_country where  status=1"
            smartobj.loadComboValues("--Select a Currency--- ", Me.drpCurrency, Dstring7)
        End If
    End Sub
    Sub loaddate()
        Dim qry As String = "select cast(sys_date as datetime)sys_date,sys_phase from tbl_system where node_id = " & Session("node_ID") & ""
        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
            latesttime = Format(CDate(dr!sys_date), "dd/MM/yyyy")
        Next
        Me.txtValueDate.Text = latesttime
    End Sub

#End Region

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
    Protected Sub btnAppoff_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAppoff.Click
        Try



            If Me.txtTellerNo.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Teller No", "Prime")
                txtTellerNo.Focus()
                Exit Sub
            End If

            If Not IsNumeric(Me.txtTellerNo.Text) Then
                smartobj.alertwindow(Me.Page, "Teller Number Must Be Numeric ", "Prime")
                txtTellerNo.Focus()
                Exit Sub
            End If

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

            If Me.txtPayAmount.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Posting amount", "Prime")
                txtPayAmount.Focus()
                Exit Sub
            End If

            latesttime = CDate(Me.txtValueDate.Text)
            If IsDate(latesttime) Then
                latesttime = latesttime.AddHours(Now.Hour)
                latesttime = latesttime.AddMinutes(Now.Minute)
                latesttime = latesttime.AddSeconds(Now.Second)
            End If

            Dim branchcode As String
            Dim selacc As String = "Select branchcode,postGl_Acctno from tbl_UserProfile where userid='" & Session("Userid").Trim & "' and node_id = " & Session("node_ID") & ""
            If con.SqlDs(selacc).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(selacc).Tables(0).Rows(0)
                glnumber = drx.Item("postGl_Acctno").ToString.Trim
                branchcode = drx.Item("branchcode").ToString.Trim


                If glnumber = "" Then
                    smartobj.alertwindow(Me.Page, "You Do Not Have Posting Right Account number", "Prime")
                    Exit Sub
                End If
            Else
                smartobj.alertwindow(Me.Page, "You Do Not Have Posting Right", "Prime")
                smartobj.ClearWebPage(Me.Page) : clear()
                Exit Sub
            End If
            Dim overline As String = Session("overide")
            If overline = "" Then
                overline = 0
            End If

            Dim nextauth As String
            Dim qry99 As String
            Dim retval22 As String

            nextauth = "null"



            qry99 = "declare @retval1 int, @retmsg1 varchar(50) exec proc_GetNextAuth '" & Session("Userid").Trim & "', @retval1 output,@retmsg1 output, " & Session("node_ID") & " select @retval1, @retmsg1"
            For Each dr As Data.DataRow In con.SqlDs(qry99).Tables(0).Rows
                retval22 = dr(0).ToString
                nextauth = dr(1).ToString
            Next


            qry = "Declare @retval int,@retmsg varchar(100) exec Proc_InsAuthTran '" & Me.txtAcNumber.Text.Trim & "'," &
             "'" & glnumber & "'," & CDbl(Me.txtTransAmount.Text.Trim) & ",'" & "522" & "','" & "008" & "'," &
             "'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Session("Userid").Trim & "','" & nextauth.Trim & "','" & branchcode & "','" & Me.txtNaration.Text.Trim.Replace("'", "") & "','" & "0" & "'," &
             "'" & Me.drpCurrency.SelectedValue.Trim & "','" & "1" & "','" & "2" & "'," & CInt(Me.txtRate.Text.Trim) & ",'" & Me.txtTellerNo.Text.Trim & "'," &
             "null,null,null,null,null,null,'" & overline & "','" & "Cash Withdrawal" & "',NULL,@retVal output,@retmsg output, " & Session("node_ID") & " select @retval ,@retmsg"


            ''qry = "Declare @retval int,@retmsg varchar(100) exec Proc_InsertCASA '" & glnumber & "'," & _
            ''"'" & Me.txtAcNumber.Text.Trim & "','" & CDbl(Me.txtTransAmount.Text.Trim) & "','" & "001" & "'," & _
            ''"'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "',null,'" & Session("Userid").Trim & "',null,'" & Me.txtNaration.Text.Trim & "'," & _
            ''"'" & Me.drpCurrency.SelectedValue.Trim & "'," & CInt(Me.txtRate.Text.Trim) & ",'" & Me.txtTellerNo.Text.Trim & "'," & _
            ''"null,null,null,NULL,@retVal output,@retmsg output select @retval ,@retmsg"

            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            smartobj.alertwindow(Me.Page, retmsg, "Prime")
            Me.btnAppoff.Enabled = False
            clear()

        Catch ex As Exception
            logger.Info("BANKING OPERATION: CASH WITHDRAW FORWARD FOR APPROVAL'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try
    End Sub
    Sub clear()
        Me.txtAcNumber.Text = ""
        Me.txtNaration.Text = ""
        Me.txtNaration.Text = ""
        Me.txtPayAmount.Text = ""
        Me.txtRate.Text = ""
        Me.txtTellerNo.Text = ""
        Me.drpCurrency.SelectedValue = 0
        Me.HypAuth.Visible = False
        retval = -1
        retmsg = ""
        loaddate()
    End Sub


    Protected Sub txtTellerNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTellerNo.TextChanged
        Me.txtNaration.Focus()
    End Sub

    Protected Sub txtNaration_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNaration.TextChanged
        Me.btnSubmit.Focus()
    End Sub



    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    'Protected Sub RadComboBox2_ItemsRequested(sender As Object, e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBox2.ItemsRequested
    '    Dim combo As RadComboBox = DirectCast(sender, RadComboBox)
    '    MyCon.Open()
    '    Dim sql As String = "SELECT [AccountNumber],[Accounttitle] + ' ('+Accountnumber+')' Accounttitle from [tbl_casaaccount] WHERE node_id = " & Session("node_ID") & " and Accounttitle LIKE '%" + e.Text + "%'"
    '    Dim adapter As New SqlDataAdapter(sql, MyCon)
    '    Dim dt As New DataTable()
    '    adapter.Fill(dt)
    '    MyCon.Close()
    '    For Each row As DataRow In dt.Rows
    '        Dim item As New RadComboBoxItem(row("Accounttitle").ToString(), row("AccountNumber").ToString())
    '        combo.Items.Add(item)
    '    Next
    'End Sub
    Private Function GetData(ByVal text As String) As DataTable
        Dim sql As String = "SELECT [AccountNumber],[Accounttitle] + ' ('+Accountnumber+')' Accounttitle from [tbl_casaaccount] WHERE node_id = " & Session("node_ID") & " and Accounttitle LIKE '%' + @text + '%'"
        Dim adapter As New SqlDataAdapter(sql, MyCon)
        adapter.SelectCommand.Parameters.AddWithValue("@text", text.Replace("%", "[%]"))

        Dim data As New DataTable()
        adapter.Fill(data)

        Return data
    End Function
    Protected Sub RadComboBox2_ItemsRequested(ByVal sender As Object, ByVal e As RadComboBoxItemsRequestedEventArgs)
        Dim data As DataTable = GetData(e.Text)
        Dim ItemsPerRequest As Integer = 10

        Dim itemOffset As Integer = e.NumberOfItems
        Dim endOffset As Integer = Math.Min(itemOffset + ItemsPerRequest, data.Rows.Count)
        e.EndOfItems = endOffset = data.Rows.Count

        For i As Integer = itemOffset To endOffset - 1
            RadComboBox2.Items.Add(New RadComboBoxItem(data.Rows(i)("Accounttitle").ToString(), data.Rows(i)("AccountNumber").ToString()))
        Next

    End Sub

    'Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
    '    If Session("node_ID") = Nothing Then
    '        Response.Redirect("../PageExpire.aspx")
    '    Else
    '        Me.MasterPageFile = "~/Tenant" + Session("node_ID").ToString + "/Tenant.master"

    '    End If
    'End Sub
    Protected Sub RadComboBox2_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBox2.SelectedIndexChanged
        Me.txtAcNumber.Text = RadComboBox2.SelectedValue
        Try
            Session("Custchg1") = ""
            'post = Guid.NewGuid.ToString
            'Dim xItem As New ListItem
            'xItem.Text = post

            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAcNumber.Text = retmsg
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
                Session("Custchg1") = Me.txtAcNumber.Text.Trim
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
                Me.Label10.Text = drx.Item("TotalCharge").ToString

                'If Me.Label9.Text <> "Active" Then
                '    Me.Label9.BackColor = Drawing.Color.Red
                'Else
                '    Me.Label9.BackColor = Drawing.Color.Orange
                '    Me.Label9.ForeColor = Drawing.Color.Blue

                'End If

                If Me.Label10.Text.Trim <> "" Then
                    If CDec(Me.Label10.Text.Trim) > 0 Then
                        Me.LnkCharge.Visible = True
                    Else
                        Me.LnkCharge.Visible = False

                    End If
                End If

                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString

                Dim idimg As String = drx.Item("customerid").ToString.Trim

                'Image1.Visible = True
                'Image1.ImageUrl = FormatURL(idimg)
                Me.txtNaration.Text = "Csh Wtd By " & Me.Label1.Text.Trim & ""

                If prostatus = "1" Then
                    smartobj.alertwindow(Me.Page, prodesc, "Prime")
                    Me.btnSubmit.Enabled = False
                    Me.btnAppoff.Enabled = False

                Else
                    Me.btnAppoff.Enabled = True
                    Me.btnSubmit.Enabled = True
                End If
                selcurrency()

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
                'Image1.Visible = False
                smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                Exit Sub
            End If
            Me.txtPayAmount.Focus()
            Dim selex As String = "Delete from tbl_postlog where accountno='" & Me.txtAcNumber.Text.Trim & "' and node_id = " & Session("node_ID") & ""
            con.SqlDs(selex)

        Catch ex As Exception
            logger.Info("BANKING OPERATION: CASH WITHDRAW RADCOMBOX SELECTED INDEX CHANGED'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try

    End Sub

    Protected Sub CheckSearch_CheckedChanged(sender As Object, e As EventArgs) Handles CheckSearch.CheckedChanged
        If CheckSearch.Checked = True Then
            RadComboBox2.Visible = True
        Else
            RadComboBox2.Visible = False
        End If
    End Sub
   
End Class
