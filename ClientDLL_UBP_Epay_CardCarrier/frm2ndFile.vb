
Public Class frm2ndFile

    Public IsSuccess As Boolean = False
    Public CardHolderAddress As String = ""

    Public Sub New(ByVal _2ndFile As String)

        ' This call is required by the designer.
        InitializeComponent()
        'txtFile.Text = _2ndFile

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtFile.Text = "" Then
            System.Windows.Forms.MessageBox.Show("Please enter valid file", "INVALID FILE", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Return
        ElseIf Not System.IO.File.Exists(txtFile.Text) Then
            System.Windows.Forms.MessageBox.Show("Please enter valid file", "INVALID FILE", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Return
        End If

        'If Not System.IO.Path.GetFileNameWithoutExtension(txtFile.Text).Contains("ARFI") Then
        '    If System.Windows.Forms.MessageBox.Show("Selected filename have no ARFI text. Are you sure you want to proceed?", "ARFI File", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return
        'End If

        CardHolderAddress = txtFile.Text
        IsSuccess = True
        Close()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim ofd As New System.Windows.Forms.OpenFileDialog
        If ofd.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtFile.Text = ofd.FileName
        End If
        ofd.Dispose()
        ofd = Nothing
    End Sub

    Private Sub frm2ndFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class