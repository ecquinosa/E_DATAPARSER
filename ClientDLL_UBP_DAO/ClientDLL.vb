
'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.CrystalReports.Engine

Public Class ClientDLL

    ' Private crReportDocument As New ReportDocument
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

            Dim _frm As New frmREF("")
            _frm.ShowDialog()

            If Not _frm.IsSuccess Then
                strErrMsg = "User cancel address file selection process"
                Return False
            End If

            Try
                _dt.Columns.Add("BARCODE", GetType(System.Byte()))
            Catch ex As Exception
            End Try

            Dim BarcodePath As String = String.Format("{0}\TempBarcode.jpg", System.Windows.Forms.Application.StartupPath)
            Dim bln As Boolean

            Dim dtREF As New DataTable
            dtREF.Columns.Add("ACCOUNTNUMBER", GetType(String))
            dtREF.Columns.Add("ADDRESS", GetType(String))

            Dim intLine As Integer = 1
            Dim REFNO As String = ""

            Try
                Using sr As New System.IO.StreamReader(_frm.REF_File)
                    Dim strLines As String = sr.ReadToEnd

                    For Each strLine As String In strLines.Split(vbLf)
                        If strLine.Trim <> "" Then
                            If strLine.Trim.Contains("Name") Then
                            ElseIf strLine.Trim.Contains("Address") Then
                            Else
                                'REFNO = strLine.Split("|")(2)  'old txtfile
                                REFNO = strLine.Split("|")(1)

                                'remove multiple spaces
                                's = Regex.Replace(s, " {2,}", " ")

                                Dim rw As DataRow = dtREF.NewRow
                                rw(0) = REFNO
                                'rw(1) = strLine.Split("|")(4) 'old txtfile
                                rw(1) = strLine.Split("|")(0)
                                dtREF.Rows.Add(rw)
                                intLine += 1
                                REFNO = ""
                            End If
                        End If
                    Next

                    sr.Close()
                    sr.Dispose()
                End Using
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show("Error reading line " & intLine.ToString & ", REFNO " & REFNO, "Reference file error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Return False
            End Try

            For Each rw As DataRow In dtData.Rows
                If dtREF.Select("ACCOUNTNUMBER='" & rw("ACCOUNTNUMBER").ToString & "'").Length > 0 Then
                    Dim rwREF() As DataRow = dtREF.Select("ACCOUNTNUMBER='" & rw("ACCOUNTNUMBER").ToString & "'")

                    'If System.IO.File.Exists(BarcodePath) Then System.IO.File.Delete(BarcodePath)

                    ''barcode
                    'For i As Short = 1 To 3
                    '    bln = GenerateBarcode(rw("REFNO").ToString.Trim, BarcodePath)
                    '    If bln Then Exit For
                    '    System.Threading.Thread.Sleep(3000)
                    'Next

                    _dt.Select("ACCOUNTNUMBER='" & rw("ACCOUNTNUMBER").ToString & "'")(0)("ADDRESS") = rwREF(0)("ADDRESS").ToString
                    '_dt.Select("ACCOUNTNUMBER='" & rw("ACCOUNTNUMBER").ToString & "'")(0)("BARCODE") = System.IO.File.ReadAllBytes(BarcodePath)
                Else
                    _dt.Select("ACCOUNTNUMBER='" & rw("ACCOUNTNUMBER").ToString & "'")(0)("ADDRESS") = ""
                    sbError.AppendLine("Unable to find account number " & rw("ACCOUNTNUMBER").ToString & " in reference file")
                End If
            Next

            'If Generate_Carrier(_dt, 1,
            '                    String.Format("{0}\CARRIER_PIN{1}_{2}.pdf", outputFolder, IIf(IO.Path.GetFileNameWithoutExtension(inputFile) = "", "", "_" & IO.Path.GetFileNameWithoutExtension(inputFile)), Now.ToString("yyyyMMdd_hhmmss")),
            '                    New RptCarrier_PIN) Then

            'End If

            'Dim dtFiltered As DataTable
            'If _dt.Select("ADDRESS<>''").Length = 0 Then
            '    sbError.AppendLine("All address is empty")
            'Else
            '    dtFiltered = _dt.Select("ADDRESS<>''").CopyToDataTable

            '    If Generate_Carrier(dtFiltered, 2,
            '                        String.Format("{0}\CARRIER_CARD{1}_{2}.pdf", outputFolder, IIf(IO.Path.GetFileNameWithoutExtension(inputFile) = "", "", "_" & IO.Path.GetFileNameWithoutExtension(inputFile)), Now.ToString("yyyyMMdd_hhmmss")),
            '                        New RptCarrier_PIN) Then

            '    End If

            '    If Generate_Carrier(dtFiltered, 0,
            '                        String.Format("{0}\CARRIER_PLAY{1}_{2}.pdf", outputFolder, IIf(IO.Path.GetFileNameWithoutExtension(inputFile) = "", "", "_" & IO.Path.GetFileNameWithoutExtension(inputFile)), Now.ToString("yyyyMMdd_hhmmss")),
            '                        New RptCarrier) Then

            '    End If
            'End If

            dtData = _dt

            Return True
        Catch ex As Exception
            strErrMsg = "ClientDLL(before): Runtime error catched " & ex.Message
            Return False
        End Try
    End Function

    'Private Function Generate_Carrier(ByVal _dt As DataTable, ByVal ReportType As Integer, ByVal outputFile As String, ByVal rd As ReportDocument) As Boolean
    '    Try
    '        crReportDocument = rd 'New RptCarrier_PIN

    '        crReportDocument.SetDataSource(_dt)

    '        If ReportType > 0 Then crReportDocument.SetParameterValue(0, ReportType)
    '        '
    '        Dim fileExt As String = ".pdf"
    '        Dim CrExportOptions As ExportOptions
    '        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
    '        Dim CrFormatTypeOptionsPDF As New PdfRtfWordFormatOptions
    '        Dim CrFormatTypeOptionsXLS As New ExcelFormatOptions

    '        CrDiskFileDestinationOptions.DiskFileName = outputFile

    '        CrExportOptions = crReportDocument.ExportOptions

    '        With CrExportOptions
    '            .ExportDestinationType = ExportDestinationType.DiskFile
    '            .DestinationOptions = CrDiskFileDestinationOptions
    '            .ExportFormatType = ExportFormatType.PortableDocFormat
    '            .FormatOptions = CrFormatTypeOptionsPDF

    '        End With

    '        Try
    '            Dim doctoprint As New System.Drawing.Printing.PrintDocument()
    '            'doctoprint.PrinterSettings.PrinterName = doc
    '            For i = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
    '                Dim rawKind As Integer
    '                If doctoprint.PrinterSettings.PaperSizes(i).PaperName = "A5" Then
    '                    rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
    '                    crReportDocument.PrintOptions.PaperSize = rawKind
    '                    crReportDocument.Export()
    '                    Exit Function
    '                End If
    '            Next

    '            crReportDocument.Export()
    '        Catch ex As Exception
    '            strErrorMessage = ex.Message
    '            Return False
    '        End Try

    '        Return True
    '    Catch ex As Exception
    '        strErrorMessage = ex.Message

    '        Return False
    '    Finally
    '        If Not crReportDocument Is Nothing Then
    '            crReportDocument.Close()
    '            crReportDocument.Dispose()
    '        End If
    '    End Try
    'End Function

    Public Function ProcessAfterGeneration(ByVal outputFolder As String,
                                           ByRef dtData As DataTable, ByRef status As String, ByRef _action As Action,
                                           Optional extension As String = "pdf", Optional ByVal fileName As String = "") As Boolean

        Dim sbError As New System.Text.StringBuilder
        Dim _dt As DataTable = dtData

        'Try
        '    crReportDocument = New RptCarrier
        '    crReportDocument.SetDataSource(_dt)
        '    'OpenReportDbase()
        '    '
        '    Dim fileExt As String = extension
        '    Dim CrExportOptions As ExportOptions
        '    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
        '    Dim CrFormatTypeOptionsPDF As New PdfRtfWordFormatOptions
        '    Dim CrFormatTypeOptionsXLS As New ExcelFormatOptions

        '    CrDiskFileDestinationOptions.DiskFileName = String.Format("{0}\CARRIER{1}_{2}.pdf", outputFolder, IIf(fileName = "", "", "_" & fileName), Now.ToString("yyyyMMdd_hhmmss"))
        '    CrExportOptions = crReportDocument.ExportOptions

        '    With CrExportOptions
        '        .ExportDestinationType = ExportDestinationType.DiskFile
        '        .DestinationOptions = CrDiskFileDestinationOptions
        '        .ExportFormatType = ExportFormatType.PortableDocFormat
        '        .FormatOptions = CrFormatTypeOptionsPDF

        '    End With
        '    Try
        '        crReportDocument.Export()
        '    Catch ex As Exception
        '        strErrorMessage = ex.Message
        '        Return False
        '    End Try

        '    Return True
        'Catch ex As Exception
        '    strErrorMessage = ex.Message

        '    Return False
        'Finally
        '    If Not crReportDocument Is Nothing Then
        '        crReportDocument.Close()
        '        crReportDocument.Dispose()
        '    End If
        'End Try

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

    Public Function GenerateBarcode(ByVal strBarcode As String, ByVal outputFile As String) As Boolean
        Try
            'Dim strTempFile As String = String.Format("C:\Allcard\SSS_CPS\Temp1_{0}.jpg", strBarcode)
            Dim _image As System.Drawing.Image = GenCode128.Code128Rendering.MakeBarcodeImage(strBarcode, 2, True)
            _image.Save(outputFile, System.Drawing.Imaging.ImageFormat.Jpeg)
            _image.Dispose()
            _image = Nothing

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

End Class
