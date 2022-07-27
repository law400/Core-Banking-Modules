Imports System
Imports System.Data.OleDb
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient


Partial Class Mandate
    Inherits System.Web.UI.Page
#Region "Pageload"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Button3.Attributes.Add("onclick", "window.close('Authorise.aspx')")
        If Request.QueryString("field") <> "" Then
            Dim AcctNo As String = Request.QueryString("field")
            Me.lbl_AcctNo.Text = AcctNo
            Dim qryfetchid As String = Nothing
            qryfetchid = "select customerid from tbl_casaaccount with (nolock) where accountnumber = '" & AcctNo & "'"

            If con.SqlDs(qryfetchid).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(qryfetchid).Tables(0).Rows
                    Me.lbl_customerid.Text = dr!customerid.ToString
                Next

                Dim selcust As String = "Select accounttitle from tbl_casaaccount with (nolock) where accountnumber = '" & AcctNo & "'"
                If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                        Me.lbl_Customer.Text = dr!accounttitle.ToString

                    Next
                    Me.cust.Text = "For Accountnumber: "
                    Me.lbl_AcctNo.Visible = True
                End If
            Else
                lbl_customerid.Text = AcctNo
                Dim selcust As String = "Select accounttitle from tbl_casaaccount with (nolock) where customerid = '" & AcctNo & "'"
                If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                        Me.lbl_Customer.Text = dr!accounttitle.ToString
                    Next
                    Me.cust.Text = ""
                    Me.lbl_AcctNo.Visible = False
                End If
            End If
            Dim qry As String = Nothing
            qry = "Select customerImage,signatureImage from tbl_mandatepicts with (nolock) where mandateid = " & lbl_customerid.Text & ""
            RadGrid1.DataSource = con.SqlDs(qry)
            RadGrid1.DataBind()

            

        End If
    End Sub
#End Region
#Region "Task"
   
    

    
    'Sub returnToPage(ByVal staffid As String)
    '    Response.Write("<script>window.opener." + Request.QueryString("field").ToString() + ".value='" + staffid + "';window.close();</script>")
    'End Sub
#End Region


End Class
