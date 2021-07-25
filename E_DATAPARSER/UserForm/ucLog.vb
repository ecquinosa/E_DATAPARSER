Public Class ucLog

    Private Sub ucLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp.Value = Now
        Dim logDate As String = dtp.Value.Date.ToString("yyyyMMdd")
        BindLog(logDate)
    End Sub

    Private Sub BindLog(ByVal logDate As String)
        Dim file As String = String.Format("Log{0}.txt", logDate)
        If System.IO.File.Exists(file) Then rtb.LoadFile(file, RichTextBoxStreamType.PlainText)
    End Sub

    Private Sub dtp_ValueChanged(sender As Object, e As EventArgs) Handles dtp.ValueChanged
        Dim logDate As String = dtp.Value.Date.ToString("yyyyMMdd")
        BindLog(logDate)
    End Sub

End Class
