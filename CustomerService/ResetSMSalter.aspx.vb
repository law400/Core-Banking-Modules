Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports log4net
Imports log4net.Config

Partial Class CustomerService_ResetSMSalter
    Inherits SessionCheck
    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)

    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CustomerService_ResetSMSalter))
#Region "Task"

    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    Response.Redirect("~/home.aspx")
    'End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        Try

            If Me.txtAcNumber.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
                Exit Sub
            End If

            If Me.txtValueDate.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter a Value Date", "Prime")
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
            Dim selacc As String = "Select branchcode from tbl_UserProfile where userid='" & Profile.Userid.Trim & "'"
            If con.SqlDs(selacc).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(selacc).Tables(0).Rows(0)
                ''glnumber = drx.Item("postGl_Acctno").ToString.Trim
                branchcode = drx.Item("branchcode").ToString.Trim


            Else
                smartobj.alertwindow(Me.Page, "You Do Not Have Posting Right", "Prime")
                smartobj.ClearWebPage(Me.Page) : clear()
                Exit Sub
            End If
            Dim overline As String = Profile.overide
            If overline = "" Then
                overline = 0
            End If

            Dim insacc As String = "Declare @retval int,@retmsg varchar(150) exec proc_updsmsalter '" & Me.txtAcNumber.Text.Trim & "'," & _
           "'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.DropDownList1.SelectedValue.Trim & "','" & Profile.Userid.Trim & "',NULL,@retVal Output,@retmsg Output select @retval ,@retmsg"

            For Each dr As Data.DataRow In con.SqlDs(insacc).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString

            Next
            ' smartobj.ClearWebPage(Me.Page):clear

            smartobj.alertwindow(Me.Page, retmsg, "Prime")

           
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: ResetSMSalter BtnSubmit_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try

    End Sub
    Sub clear()
       
        Me.txtAcNumber.Text = ""
        DropDownList1.SelectedIndex = 0
        txtValueDate.Text = Format(CDate(Profile.sysdate), "dd/MM/yyyy")
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
    End Sub
    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            smartobj.ClearWebPage(Me.Page) : clear()
            Me.Btnsubmit.Enabled = True
        Catch ex As Exception

            logger.Info("CUSTOMER SERVICE: ResetSMSalter btnReset_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try
    End Sub

    Protected Sub txtAcNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcNumber.TextChanged
        Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtAcNumber.Text.Trim & "'"
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

                Dim idimg As String = drx.Item("customerid").ToString.Trim

                If Me.Label9.Text <> "Active" Then
                    Me.Label9.BackColor = Drawing.Color.Red
                Else
                    Me.Label9.BackColor = Drawing.Color.Orange
                    Me.Label9.ForeColor = Drawing.Color.Blue

                End If
                refresh()

                If prostatus = "1" Then
                    smartobj.alertwindow(Me.Page, prodesc, "Prime")
                    Me.Btnsubmit.Enabled = False
                Else
                    Me.Btnsubmit.Enabled = True
                End If

                

            Else

                Dim stu As String = drx.Item("acctstatus").ToString

                smartobj.alertwindow(Me.Page, "Account Status is " & stu, "Prime")

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
            smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

            Exit Sub
        End If

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
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        hypValueDate.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtValueDate.ClientID.ToString() + "');"
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"
        If Page.IsPostBack = False Then

            txtValueDate.Text = Format(CDate(Profile.sysdate), "dd/MM/yyyy")

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
    Sub refresh()
        Try
            GridView1.DataSource = FetchAllImagesInfo()
            GridView1.DataBind()
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: ResetSMSalter  Sub refresh" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
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
End Class
