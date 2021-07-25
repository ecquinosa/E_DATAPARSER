
Public Class SharedFunction

    Const MsgHeader = "DATA PARSER"

    Public Shared ParsedDataTable As DataTable = Nothing
    Public Shared ProcessError As New System.Text.StringBuilder
    Public Shared ProcessLog As New System.Text.StringBuilder

    'Public Shared CLIENT_XML_CONFIG As String = "Test2.xml"
    Public Shared INPUT_FILE As String = ""
    Public Shared OUTPUT_FOLDER As String = ""

    Public Shared SelectedProfile As String = ""

    Public Shared Profiles_Repository As String = "Profiles"

    Public Shared SuccessColor As Color = Color.LightGreen
    Public Shared ErrorColor As Color = Color.OrangeRed

    Public Shared Function ShowMessage(ByVal strMsg As String, Optional ByVal msgBoxBtn As MessageBoxButtons = MessageBoxButtons.YesNo, Optional ByVal msgBoxIcn As MessageBoxIcon = MessageBoxIcon.Question) As DialogResult
        Return MessageBox.Show(strMsg, MsgHeader, msgBoxBtn, msgBoxIcn)
    End Function

    Public Shared Function ShowInfoMessage(ByVal strMsg As String, Optional ByVal msgBoxBtn As MessageBoxButtons = MessageBoxButtons.OK) As DialogResult
        Return MessageBox.Show(strMsg, MsgHeader, msgBoxBtn, MessageBoxIcon.Information)
    End Function

    Public Shared Function ShowErrorMessage(ByVal strMsg As String, Optional ByVal msgBoxBtn As MessageBoxButtons = MessageBoxButtons.OK) As DialogResult
        Return MessageBox.Show(strMsg, MsgHeader, msgBoxBtn, MessageBoxIcon.Error)
    End Function

    Public Shared Function ShowWarningMessage(ByVal strMsg As String, Optional ByVal msgBoxBtn As MessageBoxButtons = MessageBoxButtons.OK) As DialogResult
        Return MessageBox.Show(strMsg, MsgHeader, msgBoxBtn, MessageBoxIcon.Warning)
    End Function

    Public Shared Sub HouseKeeping()
        ParsedDataTable = Nothing
        ProcessError.Length = 0
        ProcessLog.Length = 0
        INPUT_FILE = ""
        OUTPUT_FOLDER = ""
    End Sub

    Public Shared Function ExportToExcel(ByVal dt As DataTable, ByVal excelFile As String, ByVal sheetName As String) As Boolean
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelFile & ";Extended Properties=Excel 12.0 Xml;"
        Dim rNumb As Integer = 0
        Try
            Using con As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(connString)
                con.Open()
                Dim strField As System.Text.StringBuilder = New System.Text.StringBuilder()
                For i As Integer = 0 To dt.Columns.Count - 1
                    If dt.Columns(i).ColumnName <> "RecordID" Then
                        strField.Append("[" & dt.Columns(i).ColumnName & "],")
                    End If
                Next

                strField = strField.Remove(strField.Length - 1, 1)
                Dim sqlCmd = "CREATE TABLE [" & sheetName & "] (" + strField.ToString().Replace("]", "] text") & ")"
                Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(sqlCmd, con)
                cmd.ExecuteNonQuery()
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim strValue As System.Text.StringBuilder = New System.Text.StringBuilder()
                    For j As Integer = 0 To dt.Columns.Count - 1
                        If dt.Columns(j).ColumnName <> "RecordID" Then
                            strValue.Append("'" & dt.DefaultView(i)(j).ToString() & "',")
                        End If
                    Next

                    strValue = strValue.Remove(strValue.Length - 1, 1)
                    cmd.CommandText = "INSERT INTO [" & sheetName & "] (" + strField.ToString() & ") VALUES (" + strValue.ToString() & ")"
                    cmd.ExecuteNonQuery()
                    rNumb = i + 1
                Next

                con.Close()
            End Using

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Sub MenuDispo()
        Main.tsbInputOutput.Visible = IIf(Main.lblClientProfile.Text = "", False, True)
        Main.tsbParseData.Visible = IIf(SharedFunction.INPUT_FILE = "" Or SharedFunction.OUTPUT_FOLDER = "", False, True)
        Main.tssI1.Visible = Main.tsbParseData.Visible

        If SharedFunction.ParsedDataTable Is Nothing OrElse SharedFunction.ParsedDataTable.DefaultView.Count = 0 Then
            Main.tsbExceptions.Visible = False
            Main.tss2.Visible = Main.tsbExceptions.Visible
            Main.tsbGenerate.Visible = False
            Main.tsbExportToExcel.Visible = False
        Else
            Main.tsbExceptions.Visible = True
            Main.tss2.Visible = Main.tsbExceptions.Visible

            Main.tsbGenerate.Visible = True
            Main.tss3.Visible = Main.tsbGenerate.Visible

            Main.tsbExportToExcel.Visible = True
            Main.tss4.Visible = Main.tsbExportToExcel.Visible
        End If

        'tsbExceptions.Visible = IIf(SharedFunction.ParsedDataTable = "", False, True)
    End Sub

End Class
