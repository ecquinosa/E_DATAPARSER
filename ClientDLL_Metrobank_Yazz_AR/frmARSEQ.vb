Public Class frmARSEQ

    Private intLastSeq As Integer = 0
    Public IsSubmitted As Boolean = False
    Public EnteredLastSequence As Integer = 0

    Public Sub New(ByVal intLastSeq As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        Me.intLastSeq = intLastSeq
        txtLastSequence.Text = intLastSeq.ToString("N0")
        txtLastSequence.SelectAll()
        txtLastSequence.Focus()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmARSEQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtLastSequence.Text = "" Then
            System.Windows.Forms.MessageBox.Show("Please enter valid last sequence number...", Me.Text, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)
        ElseIf Not IsNumeric(txtLastSequence.Text) Then
            System.Windows.Forms.MessageBox.Show("Please enter valid last sequence number...", Me.Text, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)
        Else
            IsSubmitted = True
            EnteredLastSequence = txtLastSequence.Text
            Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class