Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Class Services_Subscriber
    Inherits System.Web.UI.Page
    Dim bll As New BusinessLayer.BLL
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ConfigureExport()
        RadGrid1.MasterTableView.ExportToExcel()

    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        ConfigureExport()

        RadGrid1.MasterTableView.ExportToWord()

    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        ConfigureExport()


        RadGrid1.MasterTableView.ExportToCSV()

    End Sub
    Protected Sub RadGrid1_ExcelMLExportRowCreated(ByVal source As Object, ByVal e As Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowCreatedArgs)
        If e.RowType = Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowType.DataRow Then
            If e.Row.Cells(0) IsNot Nothing AndAlso (DirectCast(e.Row.Cells(0).Data.DataItem, String)).Contains("U") Then
                e.Row.Cells(0).StyleValue = "MyCustomStyle"
            End If
        End If
    End Sub

    Protected Sub RadGrid2_ExcelMLExportRowCreated(ByVal source As Object, ByVal e As Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowCreatedArgs)
        If e.RowType = Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowType.DataRow Then
            If e.Row.Cells(0) IsNot Nothing AndAlso (DirectCast(e.Row.Cells(0).Data.DataItem, String)).Contains("U") Then
                e.Row.Cells(0).StyleValue = "MyCustomStyle"
            End If
        End If
    End Sub
    Protected Sub RadGrid1_ExcelMLExportStylesCreated(ByVal source As Object, ByVal e As Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLStyleCreatedArgs)
        For Each style As Telerik.Web.UI.GridExcelBuilder.StyleElement In e.Styles
            If style.Id = "headerStyle" Then
                style.FontStyle.Bold = True
                style.FontStyle.Color = System.Drawing.Color.Gainsboro
                style.InteriorStyle.Color = System.Drawing.Color.Wheat
                style.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid
            ElseIf style.Id = "itemStyle" Then
                style.InteriorStyle.Color = System.Drawing.Color.WhiteSmoke
                style.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid
            ElseIf style.Id = "alternatingItemStyle" Then
                style.InteriorStyle.Color = System.Drawing.Color.LightGray
                style.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid
            End If
        Next

        Dim myStyle As New Telerik.Web.UI.GridExcelBuilder.StyleElement("MyCustomStyle")
        myStyle.FontStyle.Bold = True
        myStyle.FontStyle.Italic = True
        myStyle.InteriorStyle.Color = System.Drawing.Color.Gray
        myStyle.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid
        e.Styles.Add(myStyle)
    End Sub

    Protected Sub RadGrid1_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs)
        If e.CommandName = Telerik.Web.UI.RadGrid.ExportToExcelCommandName OrElse e.CommandName = Telerik.Web.UI.RadGrid.ExportToWordCommandName OrElse e.CommandName = Telerik.Web.UI.RadGrid.ExportToCsvCommandName OrElse e.CommandName = Telerik.Web.UI.RadGrid.ExportToPdfCommandName Then
            ConfigureExport()
        End If
    End Sub
    Public Sub ConfigureExport()

        RadGrid1.ExportSettings.ExportOnlyData = True
        RadGrid1.ExportSettings.IgnorePaging = True
        RadGrid1.ExportSettings.OpenInNewWindow = True

    End Sub
    Protected Sub RadGrid2_ExcelMLExportStylesCreated(ByVal source As Object, ByVal e As Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLStyleCreatedArgs)
        For Each style As Telerik.Web.UI.GridExcelBuilder.StyleElement In e.Styles
            If style.Id = "headerStyle" Then
                style.FontStyle.Bold = True
                style.FontStyle.Color = System.Drawing.Color.Gainsboro
                style.InteriorStyle.Color = System.Drawing.Color.Wheat
                style.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid
            ElseIf style.Id = "itemStyle" Then
                style.InteriorStyle.Color = System.Drawing.Color.WhiteSmoke
                style.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid
            ElseIf style.Id = "alternatingItemStyle" Then
                style.InteriorStyle.Color = System.Drawing.Color.LightGray
                style.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid
            End If
        Next

        Dim myStyle As New Telerik.Web.UI.GridExcelBuilder.StyleElement("MyCustomStyle")
        myStyle.FontStyle.Bold = True
        myStyle.FontStyle.Italic = True
        myStyle.InteriorStyle.Color = System.Drawing.Color.Gray
        myStyle.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid
        e.Styles.Add(myStyle)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

        End If
    End Sub

    Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        Response.Redirect("Subscriberdetail.aspx")
    End Sub

    
    Protected Overrides Sub OnPreRenderComplete(e As EventArgs)
        MyBase.OnPreRenderComplete(e)
        Dim rowCount As Integer = RadGrid1.MasterTableView.GetItems(New GridItemType() {GridItemType.Item, GridItemType.AlternatingItem}).Length
        If rowCount > 0 Then
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            CheckBox1.Enabled = True
            CheckBox2.Enabled = True
            CheckBox3.Enabled = True
        Else
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False

        End If
    End Sub
End Class
