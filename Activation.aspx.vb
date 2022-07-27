Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.io
Partial Class Activation
    Inherits System.Web.UI.Page
    Dim retval As Integer
    Dim Retmsg As String = ""
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
 Try

            Dim activationCode As String = Request.QueryString("ActivationCode")
            Dim UserNames As String = Request.QueryString("CoopName")
            Dim UserEmail As String = Request.QueryString("Email")

            'Dim activationCode As String = If(Not String.IsNullOrEmpty(Request.QueryString("ActivationCode")), Request.QueryString("ActivationCode"), Guid.Empty.ToString())

            '' Dim Node_id As String

            Dim FolderPath As String = ""

            Dim Activate As String = ""

            Activate = "Declare @retval int,@retmsg varchar(200) Exec Proc_UCP_Registration_Activation"
            Activate = Activate & "'" & activationCode & "',"


            Activate = Activate & "@retval Output,@retmsg Output Select @retval,@retmsg"

            For Each dr In con.SqlDs(Activate).Tables(0).Rows
                retval = dr(0).ToString
                Retmsg = dr(1).ToString
            Next




           

            Me.lbl_Fullname.Text = retmsg
        Catch ex As Exception
            Me.lbl_Fullname.Text = ex.Message
        End Try
    End Sub


 Sub CopyDirectory(ByVal sOriginal As String, ByVal sDestination As String)

        Dim oFiles() As IO.FileInfo
        Dim oFile As IO.FileInfo
        Dim oDirectory As New IO.DirectoryInfo(sOriginal)
        IO.Directory.CreateDirectory(sDestination)
        Try
            oFiles = oDirectory.GetFiles()

        Catch ex As UnauthorizedAccessException

            Exit Sub

        End Try


        For Each oFile In oFiles
            IO.File.Copy(oFile.FullName, sDestination & "\" & oFile.FullName.Substring(sOriginal.Length))

        Next


        Try
            For Each oEntry As IO.DirectoryInfo In oDirectory.GetDirectories

                CopyDirectory(oEntry.FullName, sDestination & "\" & oEntry.FullName.Substring(sOriginal.Length))
            Next
        Catch ex As Exception

        End Try
    End Sub


 Private Sub DeleteDirectory(path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
            'Delete all child Directories
            For Each dir As String In Directory.GetDirectories(path)
                DeleteDirectory(dir)
            Next
            'Delete a Directory
            Directory.Delete(path)
        End If
    End Sub



End Class
