Public Class frmException

    Private clientConfig As ParserDLL.ParserDLL.ClientConfig

    Private dtException As DataTable

    Private _exception As String = ""

    Public ReadOnly Property Exception As String
        Get
            Return _exception
        End Get
    End Property

    Public Sub New(ByVal clientConfig As ParserDLL.ParserDLL.ClientConfig)

        ' This call is required by the designer.
        InitializeComponent()
        Me.clientConfig = clientConfig

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmException_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboColumn.Items.Add("RecordID")
        'For Each inputFieldElement As ParserDLL.ParserDLL.FieldElement In clientConfig.InputFieldElements
        For Each inputFieldElement As ParserDLL.ParserDLL.FieldElement In clientConfig.Input.FieldElements
            cboColumn.Items.Add(inputFieldElement.ID)
        Next

        cboColumn.SelectedIndex = 0

        Dim _parserDLL As New ParserDLL.ParserDLL
        For Each _expression As String In [Enum].GetNames(GetType(ParserDLL.ParserDLL.FilterExpression))
            cboExpression.Items.Add(_expression)
        Next
        _parserDLL = Nothing

        If dtException Is Nothing Then
            dtException = New DataTable
            dtException.Columns.Add("Column", GetType(String))
            dtException.Columns.Add("ExpressionID", GetType(ParserDLL.ParserDLL.FilterExpression))
            dtException.Columns.Add("Expression", GetType(String))
            dtException.Columns.Add("Value", GetType(String))
        Else
            grid.DataSource = dtException
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rw As DataRow = dtException.NewRow
        rw(0) = cboColumn.Text
        rw(1) = cboExpression.SelectedIndex + 1
        rw(2) = cboExpression.Text
        rw(3) = txtValue.Text
        dtException.Rows.Add(rw)
        grid.DataSource = dtException
    End Sub

    Private Sub ProcessException()
        Dim sb As New System.Text.StringBuilder
        For Each rw As DataRow In dtException.Rows
            If sb.ToString = "" Then
                sb.Append(rw(0).ToString.Trim)
            Else
                sb.Append(" AND " & rw(0).ToString.Trim)
            End If

            Select Case CType(rw(1), ParserDLL.ParserDLL.FilterExpression)
                Case ParserDLL.ParserDLL.FilterExpression.EqualsTo
                    If IsNumeric(rw(3)) Then
                        sb.Append("=" & rw(3).ToString.Trim)
                    Else
                        sb.Append("='" & rw(3).ToString.Trim & "'")
                    End If
                Case ParserDLL.ParserDLL.FilterExpression.LessThanAndEqualsTo
                    sb.Append(" <= " & CInt(rw(3).ToString.Trim))
                Case ParserDLL.ParserDLL.FilterExpression.GreaterThanAndEqualsTo
                    sb.Append(" >= " & CInt(rw(3).ToString.Trim))
                Case ParserDLL.ParserDLL.FilterExpression.Contains
                    sb.Append(" LIKE '%" & rw(3).ToString.Trim & "%'")
            End Select
        Next

        _exception = sb.ToString
    End Sub

    Private Sub frmException_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ProcessException()
    End Sub

End Class