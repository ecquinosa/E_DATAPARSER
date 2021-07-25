
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports PDFLibrary

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

            Select Case System.IO.Path.GetExtension(inputFile).ToUpper
                Case ".XLS", ".XLSX"
                    Try
                        Dim PDFClass As New ClassPDF

                        Dim _frm As New frmConfig()
                        _frm.ShowDialog()

                        If Not _frm.IsSuccess Then
                            strErrMsg = "User cancel CONFIG selection process"

                            Return False
                        End If

                        PDFClass.SaveToPDF(_frm.Config_file, _dt, outputFolder)

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
                Case Else
            End Select

            dtData = _dt

            Return True
        Catch ex As Exception
            strErrMsg = "ClientDLL(before): Runtime error catched " & ex.Message & ex.ToString
            Return False
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

        '    CrDiskFileDestinationOptions.DiskFileName = String.Format("{0}\CARRIER_{1}.pdf", outputFolder, Now.ToString("yyyyMMdd_hhmmss"))
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
            strErrMsg = "ClientDLL(after): Runtime error catched " & ex.Message & ex.ToString
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