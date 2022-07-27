Imports Toastr

Partial Class JustAnything
    Inherits System.Web.UI.Page
    Public Enum MessageType
        Success
        [Error]
        Info
        Warning
    End Enum
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub
    Protected Sub ShowMessage(Message As String, type As MessageType)
        ' ScriptManager.RegisterStartupScript(Me, Me.[GetType](), System.Guid.NewGuid().ToString(), "ShowMessage('" & Message & "','" & type.ToString() & "');", True)
        Toastr.ShowToast(Me, ToastType.Error, "Error has Occurred...", "Oops!", ToastPosition.TopRight, True)
    End Sub

    Protected Sub btnSuccess_Click(sender As Object, e As EventArgs) Handles btnSuccess.Click
        ShowMessage("Record submitted successfully", MessageType.Success)
    End Sub

    Protected Sub btnDanger_Click(sender As Object, e As EventArgs) Handles btnDanger.Click
        ShowMessage("A problem has occurred while submitting data", MessageType.Error)
    End Sub

    Protected Sub btnWarning_Click(sender As Object, e As EventArgs) Handles btnWarning.Click
        ShowMessage("There was a problem with your internet connection", MessageType.Warning)
    End Sub

    Protected Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
        ShowMessage("Please verify your data before submitting", MessageType.Info)
    End Sub
End Class
