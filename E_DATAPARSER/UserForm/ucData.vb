
Public Class ucData

    Private Sub ucData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grid.DataSource = SharedFunction.ParsedDataTable
    End Sub

End Class
