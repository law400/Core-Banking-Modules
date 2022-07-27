Imports Microsoft.Reporting.WebForms
Imports System.Reflection
Partial Class Reports_Statement
    Inherits System.Web.UI.Page
    Private retmsg As String = ""
    Private retval As Integer

    Sub refresh()
        Try
           
            Dim dt1 As Date
            Dim dt2 As Date


            Dim qry As String = ""


            If txtenddate.Text = "" Then
                dt2 = Profile.sysdate
                txtenddate.Text = Format(CDate(dt2), "dd/MM/yyyy")

            Else
                dt2 = CDate(Me.txtenddate.Text.Trim)

            End If

            If txtstartdate.Text = "" Then
                dt1 = dt2.AddMonths(-1)
                txtstartdate.Text = Format(CDate(dt1), "dd/MM/yyyy")

            Else
                dt1 = CDate(Me.txtstartdate.Text.Trim)

            End If
            Dim id As Integer

            If Me.rdbutton1.SelectedValue = "1" Then
                id = 1

            Else
                id = 2
            End If

            qry = ""
            qry = qry & "Exec [Proc_RptStatement] "
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtacctno.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Format(CDate(dt1), "MM-dd-yyyy")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Format(CDate(dt2), "MM-dd-yyyy")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtuserid.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(id) & ""



            Me.SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings("Prime").ConnectionString

            Me.SqlDataSource1.SelectCommandType = SqlDataSourceCommandType.Text
            SqlDataSource1.SelectCommand = qry
            ''Me.SqlDataSource1.SelectParameters.Item("age") = Me.txtage.Text
            Me.SqlDataSource1.DataBind()
            Me.ReportViewer2.DataBind()

   
           
            Me.ReportViewer2.Visible = True
            Me.ReportViewer2.LocalReport.Refresh()
            
            ''Dim mimeType, encoding, extension As String
            ''Dim warnings As Microsoft.Reporting.WebForms.Warning()
            ''Dim streamids As String
            ''Dim format As String = "PDF"
            ''Dim bytes As Byte = ReportViewer1.ServerReport.Render(format, "", mimeType, encoding, extension, streamids, warnings)

            ''Dim fs As IO.FileStream = New IO.FileStream(Server.MapPath("report.pdf"), IO.FileMode.OpenOrCreate)
            ''Dim data As Byte = New Byte(fs.Length)
            ''fs.Write(bytes, 0, bytes.Length)
            ''fs.Close()


            ' ''serverReport = ReportViewer1.ServerReport
            ' ''DisableUnwantedExportFormats()
            Me.ReportViewer2.LocalReport.Refresh()
            '' If con.SqlDs(qry).Tables(0).Rows.Count > 0 Then

            ''Else
            'Me.ReportViewer1.Visible = False
            'Me.ReportViewer1.LocalReport.Refresh()

            'End If



        Catch ex As Exception

            Me.ReportViewer2.Visible = False

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            refresh()
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Page.IsPostBack = False Then

            'If Profile.Userid = "" Then
            '    Response.Redirect("groupreport.aspx")
            'End If
            Me.txtuserid.Text = ""


            HyperLink1.Attributes.Add("onClick", "return popWin('" & txtacctno.ID & "');")
            ''Dim Dstring2 As String = "select deptid,deptname from tbl_department"
            'smartobj.loadComboValues("--Select a Department-- ", Me.drpdept, Dstring2)
            Me.txtuserid.Text = Request.QueryString("idc").ToString.Trim
          
            Me.ReportViewer2.Visible = False
            Me.ReportViewer2.LocalReport.EnableExternalImages = True

             Me.ReportViewer2.Height = 2000
            Me.ReportViewer2.Width = 800


        End If

    End Sub

    Protected Sub BtnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReturn.Click
        Response.Redirect("usercabal.aspx?id=" & Session("offcabal"))
    End Sub
    Protected Sub ReportViewer2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer2.PreRender
        ' Disable EXCEL format   Call DisableFormat(Me.ReportViewer1, "Excel") 
        Call DisableFormat(Me.ReportViewer2, "Excel")
    End Sub
    Protected Sub DisableFormat(ByRef viewer As ReportViewer, ByVal formatName As String)
        Const Flags As System.Reflection.BindingFlags = System.Reflection.BindingFlags.NonPublic + System.Reflection.BindingFlags.Public + System.Reflection.BindingFlags.Instance

        Dim m_previewService As System.Reflection.FieldInfo = viewer.LocalReport.GetType().GetField("m_previewService", Flags)
        Dim ListRenderingExtensions As System.Reflection.MethodInfo = m_previewService.FieldType.GetMethod("ListRenderingExtensions", Flags)

        Dim previewServiceInstance As Object = m_previewService.GetValue(viewer.LocalReport)
        Dim extensions As IList = ListRenderingExtensions.Invoke(previewServiceInstance, Nothing)

        Dim name As System.Reflection.PropertyInfo = extensions(0).GetType().GetProperty("Name", Flags)
        Dim extension As Object

        For Each extension In extensions
            If (String.Compare(name.GetValue(extension, Nothing).ToString(), formatName, True) = 0) Then

                Dim m_isVisible As System.Reflection.FieldInfo = extension.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.NonPublic + System.Reflection.BindingFlags.Instance)
                Dim m_isExposedExternally As System.Reflection.FieldInfo = extension.GetType().GetField("m_isExposedExternally", System.Reflection.BindingFlags.NonPublic + System.Reflection.BindingFlags.Instance)

                m_isVisible.SetValue(extension, False)
                m_isExposedExternally.SetValue(extension, False)
                Exit For

            End If

        Next extension
    End Sub
    Protected Sub txtacctno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtacctno.TextChanged
        Try
            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtacctno.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtacctno.Text = retmsg
                Exit Sub
            End If

            selfind = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldLoanTDAcct '" & Me.txtacctno.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtacctno.Text = retmsg
            End If
        Catch ex As Exception

        End Try
    End Sub

    
End Class
