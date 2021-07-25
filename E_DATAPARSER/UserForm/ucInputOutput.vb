
Public Class ucInputOutput

    Private Sub ucInputOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtInput.Text = SharedFunction.INPUT_FILE
        txtOutput.Text = SharedFunction.OUTPUT_FOLDER
    End Sub

    Private Sub btnBrowseInput_Click(sender As Object, e As EventArgs) Handles btnBrowseInput.Click
        Dim ofd As New OpenFileDialog
        If ofd.ShowDialog = DialogResult.OK Then
            txtInput.Text = ofd.FileName
        End If
        ofd.Dispose()
        ofd = Nothing

        SharedFunction.MenuDispo()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fbd As New FolderBrowserDialog
        If fbd.ShowDialog = DialogResult.OK Then
            txtOutput.Text = fbd.SelectedPath
        End If
        fbd.Dispose()
        fbd = Nothing
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtInput.Text = "" Then
            SharedFunction.ShowInfoMessage("Please specify input file")
            Return
        End If

        If Not System.IO.File.Exists(txtInput.Text) Then
            SharedFunction.ShowInfoMessage("Please specify valid file")
            Return
        End If

        If txtOutput.Text = "" Then
            SharedFunction.ShowInfoMessage("Please specify output folder")
            Return
        End If

        If Not System.IO.Directory.Exists(txtOutput.Text) Then
            SharedFunction.ShowInfoMessage("Please specify valid output folder")
            Return
        End If

        SharedFunction.INPUT_FILE = txtInput.Text
        SharedFunction.OUTPUT_FOLDER = txtOutput.Text
        SharedFunction.MenuDispo()
    End Sub

End Class
