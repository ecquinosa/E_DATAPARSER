
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

            Try
                _dt.Columns.Add("BARCODE", GetType(System.Byte()))
            Catch ex As Exception
            End Try

            Dim BarcodePath As String = String.Format("{0}\TempBarcode.jpg", System.Windows.Forms.Application.StartupPath)
            Dim bln As Boolean

            For Each rw As DataRow In _dt.Rows
                rw("NAME") = String.Format("{0}{1} {2}", rw("FNAME").ToString.Trim, IIf(rw("MNAME").ToString.ToString.Trim = "", "", " " & rw("MNAME").ToString.ToString.Trim), rw("LNAME").ToString.ToString.Trim)
                rw("ADDRESS") = String.Format("{0} {1} {2} {3} {4}", rw("ADDRESS1").ToString.Trim, rw("ADDRESS2").ToString.Trim, rw("ADDRESS3").ToString.Trim, rw("CITY").ToString.Trim, rw("PROVINCE").ToString.Trim)


                If System.IO.File.Exists(BarcodePath) Then System.IO.File.Delete(BarcodePath)

                'barcode
                For i As Short = 1 To 3
                    bln = GenerateBarcode(Now.ToString("hhmmss"), BarcodePath)
                    If bln Then Exit For
                    System.Threading.Thread.Sleep(3000)
                Next

                rw("BARCODE") = System.IO.File.ReadAllBytes(BarcodePath)
                rw.AcceptChanges()
            Next

            If Generate_Carrier(_dt,
                                String.Format("{0}\CARRIER{1}_{2}.pdf", outputFolder, IIf(IO.Path.GetFileNameWithoutExtension(inputFile) = "", "", "_" & IO.Path.GetFileNameWithoutExtension(inputFile)), Now.ToString("yyyyMMdd_hhmmss")),
                                New RptCarrier) Then

            End If

            '    CrDiskFileDestinationOptions.DiskFileName = String.Format("{0}\CARRIER{1}_{2}.pdf", outputFolder, IIf(fileName = "", "", "_" & fileName), Now.ToString("yyyyMMdd_hhmmss"))

            dtData = _dt

            Return True
        Catch ex As Exception
            strErrMsg = "ClientDLL(before): Runtime error catched " & ex.Message
            Return False
        End Try
    End Function

    Private Function Generate_Carrier(ByVal _dt As DataTable, ByVal outputFile As String, ByVal rd As ReportDocument) As Boolean
        Try
            crReportDocument = rd

            crReportDocument.SetDataSource(_dt)
            '
            Dim fileExt As String = ".pdf"
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
            Dim CrFormatTypeOptionsPDF As New PdfRtfWordFormatOptions
            Dim CrFormatTypeOptionsXLS As New ExcelFormatOptions

            CrDiskFileDestinationOptions.DiskFileName = outputFile

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
    End Function

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
