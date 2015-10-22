Public Class frmConfig

    Public filePath As String = ""
    Private Sub btnOpenLog_Click(sender As Object, e As EventArgs) Handles btnOpenLog.Click
        Process.Start(filePath)
    End Sub
End Class