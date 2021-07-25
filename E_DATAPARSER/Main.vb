
Imports System.IO

Public Class Main

    Private CurrentStatus As String = ""
    Private _parserDLL As ParserDLL.ParserDLL

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

        PopulateProfiles()

        'SharedFunction.INPUT_FILE = "D:\20200122\Allcard Plant\UBP JAN 21 2020\NEW TEXT FILE_DAO\0909 sample\CDFRPL1_20190905201426_DAO_29.txt"
        'SharedFunction.OUTPUT_FOLDER = "D:\20200122\Allcard Plant\UBP JAN 21 2020\NEW TEXT FILE_DAO\0909 sample\TEST"
    End Sub

    Private Sub PopulateProfiles()
        Dim intSubDirCntr As Short = 0

        Dim nodes As New List(Of String)

        For Each strSubDir1 As String In Directory.GetDirectories(SharedFunction.Profiles_Repository)
            For Each strFile As String In Directory.GetFiles(strSubDir1)
                If Path.GetExtension(strFile).ToUpper = ".XML" Then
                    Dim bln As Boolean = True
                    Dim parentFolder As String = strSubDir1.Substring(strSubDir1.IndexOf("\") + 1)

                    If nodes.Count = 0 Then
addNode:
                        nodes.Add(parentFolder)
                        Dim root = New TreeNode(parentFolder)
                        tvProfile.Nodes.Add(root)
                        tvProfile.Nodes(intSubDirCntr).Nodes.Add(New TreeNode(Path.GetFileNameWithoutExtension(strFile)))
                    Else
                        For Each node As String In nodes
                            If node = parentFolder Then
                                bln = False
                            End If
                        Next

                        If bln Then GoTo addNode Else tvProfile.Nodes(intSubDirCntr).Nodes.Add(New TreeNode(Path.GetFileNameWithoutExtension(strFile)))
                    End If
                End If
            Next

            intSubDirCntr += 1
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim alh As New AllcardLicenseHandler.License
        'alh.GenerateLicense()
        alh.Validate()
        Return
        Dim b As New Neodynamic.WinControls.BarcodeProfessional.BarcodeProfessional
        b.Symbology = Neodynamic.WinControls.BarcodeProfessional.Symbology.Code128
        b.Code = TextBox2.Text
        'b.Save("b.bmp", Imaging.ImageFormat.Bmp)
        b.DisplayCode = False

        Dim CropRect As New Rectangle(0, 10, b.Image.Width, b.Image.Height)
        Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
        'MessageBox.Show("", "",)
        Using grp = Graphics.FromImage(CropImage)
            grp.DrawImage(b.Image, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            CropImage.Save("b2.bmp")
        End Using

        MessageBox.Show("Done!")


        'TextBox2.Text = String.Join(" ", System.Text.RegularExpressions.Regex.Replace(TextBox1.Text, "[^A-Za-z0-9\ ]", " ").Split({" "c}, StringSplitOptions.RemoveEmptyEntries))
        '
        ' ExportToExcel()
        'Form1.ShowDialog()
    End Sub

    Private Sub ProcessStatus()
        tsslStatus2.Text = CurrentStatus
        Application.DoEvents()
    End Sub

    Private Sub tsbParseData_Click(sender As Object, e As EventArgs) Handles tsbParseData.Click
        If SharedFunction.INPUT_FILE = "" Then
            SharedFunction.ShowErrorMessage("No input file selected")
            Return
        End If

        If SharedFunction.OUTPUT_FOLDER = "" Then
            SharedFunction.ShowErrorMessage("No output folder selected")
            Return
        End If

        FormStatus(True)

        _parserDLL = New ParserDLL.ParserDLL
        _parserDLL.INPUT_FILE = SharedFunction.INPUT_FILE
        _parserDLL.OUTPUT_FOLDER = SharedFunction.OUTPUT_FOLDER
        _parserDLL.InputParseData(SharedFunction.SelectedProfile, CurrentStatus, AddressOf ProcessStatus)
        SharedFunction.ParsedDataTable = _parserDLL.InputParsedData

        ShowUserControl(New ucData)

        If _parserDLL.ProcessLog <> "" Then
            SharedFunction.ShowWarningMessage("Please re-check xml file")
        End If

        SharedFunction.MenuDispo()

        FormStatus(False)
    End Sub

    Private Sub ShowUserControl(ByVal uc As UserControl)
        SplitContainer2.Panel2.Controls.Clear()
        uc.Dock = DockStyle.Fill
        SplitContainer2.Panel2.Controls.Add(uc)
    End Sub

    Private Sub tsbInputOutput_Click(sender As Object, e As EventArgs) Handles tsbInputOutput.Click
        ShowUserControl(New ucInputOutput)
    End Sub

    Private Sub tsbGenerate_Click(sender As Object, e As EventArgs) Handles tsbGenerate.Click
        If SharedFunction.INPUT_FILE = "" Then
            SharedFunction.ShowErrorMessage("No input file selected")
            Return
        End If

        If SharedFunction.OUTPUT_FOLDER = "" Then
            SharedFunction.ShowErrorMessage("No output folder selected")
            Return
        End If

        FormStatus(True)

        Dim ErrMsg As String = ""

        If Not _parserDLL.LoadedClientConfig.CDLL Is Nothing Then
            If File.Exists(_parserDLL.LoadedClientConfig.CDLL.FilePath) Then
                Dim oType As System.Type
                Dim oAssembly As System.Reflection.Assembly
                Dim oObject As System.Object

                oAssembly = System.Reflection.Assembly.LoadFrom(_parserDLL.LoadedClientConfig.CDLL.FilePath)
                oType = oAssembly.GetType(Path.GetFileNameWithoutExtension(_parserDLL.LoadedClientConfig.CDLL.FilePath) & ".ClientDLL")

                oObject = Activator.CreateInstance(oType)

                If _parserDLL.DLLProcessBeforeGeneration(oObject, SharedFunction.OUTPUT_FOLDER, SharedFunction.ParsedDataTable, ErrMsg, CurrentStatus, AddressOf ProcessStatus, _parserDLL.INPUT_FILE) Then
                    If _parserDLL.LoadedClientConfig.CDLL.RunNativeGenerateOutput Then _
                        _parserDLL.GenerateOutput(_parserDLL.LoadedClientConfig, _parserDLL.InputParsedData, CurrentStatus, AddressOf ProcessStatus)

                    If ErrMsg <> "" Then
                        SharedFunction.ShowMessage("Additional log from before process." & vbNewLine & vbNewLine & ErrMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                    For Each _dtOutput As DataTable In _parserDLL.OutputParsedData
                        ErrMsg = ""
                        If Not _parserDLL.DLLProcessAfterGeneration(oObject, SharedFunction.OUTPUT_FOLDER, _dtOutput, ErrMsg, CurrentStatus, AddressOf ProcessStatus, "pdf", _dtOutput.TableName) Then
                            SharedFunction.ShowErrorMessage("Process in DLL after output failed." & vbNewLine & vbNewLine & ErrMsg)
                        Else
                            If ErrMsg <> "" Then
                                SharedFunction.ShowMessage("Additional log from after process." & vbNewLine & vbNewLine & ErrMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        End If
                    Next

                    'SharedFunction.ParsedDataTable = _parserDLL.InputParsedData
                Else
                    SharedFunction.ShowErrorMessage("Process in DLL before output failed." & vbNewLine & vbNewLine & ErrMsg)
                End If
            Else
                SharedFunction.ShowErrorMessage("Unable to find '" & _parserDLL.LoadedClientConfig.CDLL.FilePath & "' dll")
                FormStatus(False)
                Return
            End If
        Else
            _parserDLL.GenerateOutput(_parserDLL.LoadedClientConfig, _parserDLL.InputParsedData, CurrentStatus, AddressOf ProcessStatus)
            SharedFunction.ParsedDataTable = _parserDLL.InputParsedData
        End If

        ShowUserControl(New ucData)

        SharedFunction.ShowInfoMessage("Process is complete")

        FormStatus(False)
    End Sub

    Private Sub tsbExceptions_Click(sender As Object, e As EventArgs) Handles tsbExceptions.Click
        Dim frm As New frmException(_parserDLL.LoadedClientConfig)
        frm.ShowDialog()

        If frm.Exception <> "" Then
            Dim _dt As DataTable = _parserDLL.InputParsedData
            SharedFunction.ParsedDataTable = _dt.Select(frm.Exception).CopyToDataTable

            ShowUserControl(New ucData)
        End If
    End Sub

    Private Sub tsbExportToExcel_Click(sender As Object, e As EventArgs) Handles tsbExportToExcel.Click
        FormStatus(True)

        Dim excelFile As String = String.Format("{0}\{1}.xls", SharedFunction.OUTPUT_FOLDER, Path.GetFileNameWithoutExtension(SharedFunction.INPUT_FILE))

        Dim errMsg As String = ""

        'If SharedFunction.ExportToExcel(SharedFunction.ParsedDataTable, excelFile, "data") Then
        If _parserDLL.ExportToExcel2(SharedFunction.ParsedDataTable, excelFile, errMsg) Then
            SharedFunction.ShowInfoMessage("Exporting process is complete")
        Else
            SharedFunction.ShowInfoMessage("Failed to export data")
        End If

        FormStatus(False)
    End Sub

    Private Sub tvProfile_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvProfile.NodeMouseClick
        If e.Node.GetNodeCount(True) = 0 Then
            SharedFunction.SelectedProfile = String.Format("{0}\{1}.xml", SharedFunction.Profiles_Repository, e.Node.FullPath)
            lblClientProfile.Text = e.Node.Text
        Else
            SharedFunction.SelectedProfile = ""
            lblClientProfile.Text = ""
            SplitContainer2.Panel2.Controls.Clear()
        End If

        SharedFunction.MenuDispo()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub FormStatus(ByVal IsBusy As Boolean)
        If IsBusy Then
            Cursor = Cursors.WaitCursor
            Me.Enabled = False
        Else
            Cursor = Cursors.Default
            Me.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sourceFolder As String = "F:\UBP MEMFILE ISSUE\source"
        Dim destiFolder As String = "F:\UBP MEMFILE ISSUE\revised"

        Dim lastLine As String = ""
        Dim sb As New System.Text.StringBuilder
        Dim sbTemp As New System.Text.StringBuilder
        For Each subDir As String In Directory.GetDirectories(sourceFolder)
            Dim dateFolder As String = subDir.Substring(subDir.LastIndexOf("\") + 1)

            For Each strFile As String In Directory.GetFiles(subDir)
                sb.Clear()
                sbTemp.Clear()

                Using sr As New StreamReader(strFile)
                    Dim filelastLine As String = ""
                    Dim IsStartCopy As Boolean = False

                    Do While Not sr.EndOfStream
                        Dim line As String = sr.ReadLine

                        If line.Trim <> "" Then
                            filelastLine = line.Split("|")(0)
                            If sbTemp.ToString = "" Then
                                sbTemp.Append(line)
                            Else
                                sbTemp.Append(Environment.NewLine & line)
                            End If

                            If lastLine = "" Then
                                If sb.ToString = "" Then
                                    sb.Append(line)
                                Else
                                    sb.Append(Environment.NewLine & line)
                                End If
                            Else
                                If Not IsStartCopy Then
                                    If lastLine = filelastLine Then
                                        IsStartCopy = True
                                    End If
                                Else
                                    If sb.ToString = "" Then
                                        sb.Append(line)
                                    Else
                                        sb.Append(Environment.NewLine & line)
                                    End If
                                End If
                            End If
                        End If
                    Loop

                    If Not IsStartCopy Then sb.Append(sbTemp.ToString)

                    If sb.ToString <> "" Then
                        If Not Directory.Exists(destiFolder & "\" & dateFolder) Then Directory.CreateDirectory(destiFolder & "\" & dateFolder)
                        File.WriteAllText(destiFolder & "\" & dateFolder & "\" & Path.GetFileNameWithoutExtension(strFile).Split("_")(0) & ".txt", sb.ToString)
                    End If

                    lastLine = filelastLine

                    sr.Dispose()
                    sr.Close()
                End Using
            Next
        Next

        MessageBox.Show("Done!")
    End Sub

    Private Sub tsbLog_Click(sender As Object, e As EventArgs) Handles tsbLog.Click
        ShowUserControl(New ucLog)
    End Sub

End Class