Public Class frmConfig
    Public IsSuccess As Boolean = False
    Public Config_file As String = ""

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim ofd As New System.Windows.Forms.OpenFileDialog
        If ofd.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtConfig.Text = ofd.FileName
        End If
        ofd.Dispose()
        ofd = Nothing
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtConfig.Text = "" Then
            System.Windows.Forms.MessageBox.Show("Please enter valid Config File", "INVALID FILE", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Return
        ElseIf Not System.IO.File.Exists(txtConfig.Text) Then
            System.Windows.Forms.MessageBox.Show("Please enter valid ARFI file", "INVALID FILE", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Return
        End If

        'If Not System.IO.Path.GetFileNameWithoutExtension(txtConfig.Text).Contains("ARFI") Then
        If Not System.IO.Path.GetExtension(txtConfig.Text).Contains("xml") Then
            If System.Windows.Forms.MessageBox.Show("Selected filename is not config file. Are you sure you want to proceed?", "CONFIG", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return
        End If

        Config_file = txtConfig.Text
        IsSuccess = True
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class