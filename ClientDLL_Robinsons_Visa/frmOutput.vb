Public Class frmOutput

    Public fileExt As String = "pdf"

    Private Sub frmOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fileExt = "xls"
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fileExt = "pdf"
        Close()
    End Sub

End Class