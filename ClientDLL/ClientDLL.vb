
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClientDLL

    Private crReportDocument As New ReportDocument
    Private strErrorMessage As String
    Private strErrMsg As String = ""

    Public Property ErrorMessage As String
        Get
            Return strErrMsg
        End Get
        Set(value As String)
            strErrMsg = value
        End Set
    End Property

    Public Function ProcessBeforeGeneration(ByVal outputFolder As String, ByRef dtData As DataTable, ByRef status As String, ByRef _action As Action,
                                            Optional ByVal inputFile As String = "") As Boolean
        Try
            Dim sbError As New System.Text.StringBuilder

            Dim _dt As DataTable = dtData

            Dim _frm As New frmARFI(inputFile.Replace("_VF", "_ARFI").Replace("_VC", "_ARFI").Replace("_vf", "_ARFI").Replace("_vc", "_ARFI"))
            _frm.ShowDialog()

            If Not _frm.IsSuccess Then
                strErrMsg = "User cancel ARFI selection process"
                Return False
            End If

            Dim dtARFI As New DataTable
            dtARFI.Columns.Add("REFNO", GetType(String))
            dtARFI.Columns.Add("ADDRESS1", GetType(String))
            dtARFI.Columns.Add("ADDRESS2", GetType(String))
            dtARFI.Columns.Add("ADDRESS3", GetType(String))
            dtARFI.Columns.Add("ADDRESS4", GetType(String))

            Dim intLine As Integer = 1
            Dim REFNO As String = ""

            Try
                Using sr As New System.IO.StreamReader(_frm.ARFI_File)
                    Dim strLines As String = sr.ReadToEnd

                    For Each strLine As String In strLines.Split(vbLf)
                        If strLine.Trim <> "" Then
                            REFNO = strLine.Substring(341, 16)

                            Dim rw As DataRow = dtARFI.NewRow
                            rw(0) = REFNO
                            rw(1) = strLine.Substring(376, 100)
                            rw(2) = strLine.Substring(476, 100)
                            rw(3) = strLine.Substring(576, 100)
                            rw(4) = strLine.Substring(676, 100)
                            dtARFI.Rows.Add(rw)
                            intLine += 1
                            REFNO = ""
                        End If
                    Next

                    sr.Close()
                    sr.Dispose()
                End Using
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show("Error reading line " & intLine.ToString & ", REFNO " & REFNO, "ARFI file error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Return False
            End Try

            For Each rw As DataRow In dtData.Rows
                If dtARFI.Select("REFNO='" & rw("REFNO").ToString & "'").Length > 0 Then
                    Dim rwARFI() As DataRow = dtARFI.Select("REFNO='" & rw("REFNO").ToString & "'")
                    _dt.Select("REFNO='" & rw("REFNO").ToString & "'")(0)("ADDRESS1") = rwARFI(0)("ADDRESS1").ToString
                    _dt.Select("REFNO='" & rw("REFNO").ToString & "'")(0)("ADDRESS2") = rwARFI(0)("ADDRESS2").ToString
                    _dt.Select("REFNO='" & rw("REFNO").ToString & "'")(0)("ADDRESS3") = rwARFI(0)("ADDRESS3").ToString
                    _dt.Select("REFNO='" & rw("REFNO").ToString & "'")(0)("ADDRESS4") = rwARFI(0)("ADDRESS4").ToString
                Else
                    sbError.AppendLine("Unable to find refno " & rw("REFNO").ToString & " in ARFI file")
                End If
            Next

            dtData = _dt

            Return True
        Catch ex As Exception
            strErrMsg = "ClientDLL(before): Runtime error catched " & ex.Message
            Return False
        End Try
    End Function

    Public Function ProcessAfterGeneration(ByVal outputFolder As String,
                                           ByRef dtData As DataTable, ByRef status As String, ByRef _action As Action,
                                           Optional extension As String = "pdf", Optional ByVal fileName As String = "") As Boolean
        Dim sbError As New System.Text.StringBuilder
        Dim _dt As DataTable = dtData

        Try
            _dt.Columns.Add("IS_SHOW_GREETINGS", GetType(System.Boolean))

            For Each rw As DataRow In _dt.Rows
                If fileName = "" Then
                    rw("IS_SHOW_GREETINGS") = False
                Else
                    If System.IO.Path.GetFileNameWithoutExtension(fileName).Contains("PR_3") Then
                        rw("IS_SHOW_GREETINGS") = True
                        'rw("GREETINGS2") = ""
                    Else
                        rw("IS_SHOW_GREETINGS") = False
                    End If
                End If
            Next

            crReportDocument = New RptCarrier
            crReportDocument.SetDataSource(_dt)
            'OpenReportDbase()
            '
            Dim fileExt As String = extension
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
            Dim CrFormatTypeOptionsPDF As New PdfRtfWordFormatOptions
            Dim CrFormatTypeOptionsXLS As New ExcelFormatOptions

            CrDiskFileDestinationOptions.DiskFileName = String.Format("{0}\CARRIER{1}_{2}.pdf", outputFolder, IIf(fileName = "", "", "_" & fileName), Now.ToString("yyyyMMdd_hhmmss"))
            CrExportOptions = crReportDocument.ExportOptions

            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .DestinationOptions = CrDiskFileDestinationOptions
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .FormatOptions = CrFormatTypeOptionsPDF

            End With
            Try
                crReportDocument.Export()
            Catch ex As Exception
                strErrorMessage = ex.Message
                Return False
            End Try

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message

            Return False
        Finally
            If Not crReportDocument Is Nothing Then
                crReportDocument.Close()
                crReportDocument.Dispose()
            End If
        End Try

        Try
            dtData = _dt

            'MsgBox("ProcessAfterGeneration")

            If sbError.ToString <> "" Then
                strErrMsg = sbError.ToString

                Return False
            End If

            Return True
        Catch ex As Exception
            strErrMsg = "ClientDLL(after): Runtime error catched " & ex.Message
            Return False
        End Try
    End Function

End Class
