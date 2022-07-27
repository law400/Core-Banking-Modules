Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Partial Class CustomerService_MandateDetail
    Inherits SessionCheck
    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Protected Sub txtAcNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcNumber.TextChanged
        loadaacct()
    End Sub
    Sub loadaacct()
        Dim retval As Integer
        Dim retmsg As String = ""
        Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output," & Session("node_ID") & " select @retval,@retmsg"
        For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
            retval = dr(0).ToString
            retmsg = dr(1).ToString
        Next

        If retval = "0" Then
            Me.txtAcNumber.Text = retmsg
        End If

        Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtAcNumber.Text.Trim & "'," & Session("node_ID") & ""
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
            Me.Label4.Text = smartobj.FormatMoney(Format(drx.Item("bkbal"), "###0.00"))
            Me.Label5.Text = smartobj.FormatMoney(Format(drx.Item("effbal"), "###0.00"))
            Me.Label6.Text = smartobj.FormatMoney(Format(drx.Item("usebal"), "###0.00"))
            Me.Label7.Text = drx.Item("acctty").ToString
            Me.Label8.Text = drx.Item("source").ToString
            Me.Label9.Text = drx.Item("acctstatus").ToString
            Dim prostatus As String = drx.Item("prodstatus").ToString
            Dim prodesc As String = drx.Item("proddesc").ToString

            Dim idimg As String = drx.Item("customerid").ToString.Trim

            refresh()
            ''end display photo
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
        Dim Sql As String = "Exec Proc_SelMandateInfo '" & Me.txtAcNumber.Text.Trim & "'," & Session("node_ID") & ""
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
    'Sub refresh()
    '    Dim ds As New DataSet
    '    Dim da As SqlClient.SqlDataAdapter

    '    ''display photo'
    '    Dim sel As String = "Exec Proc_SelMandateInfo '" & Me.txtAcNumber.Text.Trim & "'"
    '    If con.SqlDs(sel).Tables(0).Rows.Count > 0 Then
    '        da = New SqlClient.SqlDataAdapter(sel, MyCon)
    '        da.Fill(ds)
    '        ds.Tables(0).Columns.Add("imgFile")
    '        ds.Tables(0).Columns.Add("imgFile2")

    '        For Each tempRow As DataRow In ds.Tables(0).Rows
    '            tempRow.Item("imgFile") = ("getimg.aspx?id=" & tempRow.Item("accountnumber"))
    '            tempRow.Item("imgFile2") = ("getimg2.aspx?id=" & tempRow.Item("accountnumber"))

    '        Next
    '        GridView1.DataSource = ds
    '        GridView1.DataBind()
    '        GridView1.Visible = True
    '    Else
    '        GridView1.Visible = False
    '    End If
    'End Sub

    'Protected Sub BtnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click

    '    Response.Redirect("default.aspx")

    'End Sub
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
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = ""
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "VIEW MANDATE" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)

        menuname.Text = Request.QueryString("XXX")
        If menuname.Text = "" Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Validate_Access(menuname.Text) = 0 Then
            Response.Redirect("~/Unauthorize.aspx")
        End If
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"

        If Page.IsPostBack = False Then
            If Request.QueryString("id") <> Nothing Then
                Me.txtAcNumber.Text = Request.QueryString("id")
                loadaacct()
            End If
        End If
    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        smartobj.ClearWebPage(Me.Page) : clear()

    End Sub
    Sub clear()
        '' Me.txtAcNumber.Text = ""
        Me.txtAcNumber.Text = ""
        Me.Label1.Text = ""
        Me.Label2.Text = ""
        Me.Label3.Text = ""
        Me.Label4.Text = ""
        Me.Label5.Text = ""
        Me.Label6.Text = ""
        Me.Label7.Text = ""
        Me.Label8.Text = ""
        Me.Label9.Text = ""

        GridView1.DataSource = Nothing
        GridView1.DataBind()
    End Sub
End Class
