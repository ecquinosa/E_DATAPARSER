
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

            If Not _dt.Columns.Contains("COMPLETE_NAME") Then
                _dt.Columns.Add("COMPLETE_NAME", GetType(String))
                _dt.Columns.Add("COMPLETE_ADDRESS", GetType(String))
                _dt.Columns.Add("BARCODE", GetType(System.Byte()))
            End If

            Dim BarcodePath As String = String.Format("{0}\TempBarcode.jpg", System.Windows.Forms.Application.StartupPath)

            Select Case System.IO.Path.GetExtension(inputFile).ToUpper
                Case ".XLS", ".XLSX"
                    Try
                        For Each rw As DataRow In _dt.Rows
                            If ConvertToEmptyString(rw("STATEMENTDATE")) <> "" Then _
                                rw("STATEMENTDATE") = CDate(rw("STATEMENTDATE").ToString).ToString("MM/dd/yyyy")
                            If ConvertToEmptyString(rw("PAYMENTDUEDATE")) <> "" Then _
                                rw("PAYMENTDUEDATE") = CDate(rw("PAYMENTDUEDATE").ToString).ToString("MM/dd/yyyy")
                            If ConvertToEmptyString(rw("CREDITLIMIT")) <> "" Then _
                                rw("CREDITLIMIT") = CDec(rw("CREDITLIMIT").ToString).ToString("N0")
                            rw("COMPLETE_ADDRESS") = String.Format("{0}{1}{2}", rw("ADDRESS").ToString.Trim, IIf(rw("COUNTRY").ToString = "", "", " " & rw("COUNTRY").ToString.Trim), IIf(rw("ZIPCODE").ToString = "", "", " " & rw("ZIPCODE").ToString.Trim))
                            rw("COMPLETE_NAME") = String.Format("{0}{1} {2}", rw("FNAME").ToString.Trim, IIf(rw("MNAME").ToString = "", "", " " & rw("MNAME").ToString.Trim), rw("LNAME").ToString.Trim)
                            rw("CARDNO") = String.Format("{0} XXXX XXXX {1}", Microsoft.VisualBasic.Left(rw("CARDNO").ToString.Trim, 4), Microsoft.VisualBasic.Right(rw("CARDNO").ToString.Trim, 4))

                            If System.IO.File.Exists(BarcodePath) Then System.IO.File.Delete(BarcodePath)
                            Dim bln As Boolean
                            Dim rn As New Random

                            'barcode
                            Dim barcode As String = rw("REFNO").ToString.Trim 'Now.ToString("ddMMyy") & rn.Next(1000, 9999) & rn.Next(100, 999)
                            For i As Short = 1 To 3
                                bln = GenerateBarcode(barcode, BarcodePath)
                                If bln Then Exit For
                                System.Threading.Thread.Sleep(3000)
                            Next

                            If System.IO.File.Exists(BarcodePath) Then
                                rw("BARCODE") = System.IO.File.ReadAllBytes(BarcodePath)
                            Else
                                dtData = _dt
                                strErrMsg = "ClientDLL(before): Failed to generate barcode " & barcode
                                Return False
                            End If

                            rw.AcceptChanges()
                        Next

                        Dim errMsg As String = ""
                        If Not GenerateRPT_DataSource(New RptCarrier, _dt, String.Format("{0}\CARRIER_{1}_{2}.pdf", outputFolder, System.IO.Path.GetFileNameWithoutExtension(inputFile), Now.ToString("yyyyMMdd_hhmmss")), errMsg) Then
                            dtData = _dt
                            strErrMsg = "ClientDLL(before): Error " & errMsg
                            Return False
                        Else
                            If Not GenerateRPT_DataSource(New RptAR, _dt, String.Format("{0}\AR_{1}_{2}.pdf", outputFolder, System.IO.Path.GetFileNameWithoutExtension(inputFile), Now.ToString("yyyyMMdd_hhmmss")), errMsg) Then
                                dtData = _dt
                                strErrMsg = "ClientDLL(before): Error " & errMsg
                                Return False
                            End If
                        End If
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

    Public Function ProcessBeforeGeneration_bak(ByVal outputFolder As String, ByRef dtData As DataTable, ByRef status As String, ByRef _action As Action,
                                            Optional ByVal inputFile As String = "") As Boolean
        Try
            Dim sbError As New System.Text.StringBuilder

            Dim _dt As DataTable = dtData

            If Not _dt.Columns.Contains("COMPLETE_NAME") Then
                _dt.Columns.Add("COMPLETE_NAME", GetType(String))
                _dt.Columns.Add("COMPLETE_ADDRESS", GetType(String))
            End If

            Select Case System.IO.Path.GetExtension(inputFile).ToUpper
                Case ".XLS", ".XLSX"
                    Try
                        For Each rw As DataRow In _dt.Rows
                            If ConvertToEmptyString(rw("STATEMENTDATE")) <> "" Then _
                                rw("STATEMENTDATE") = CDate(rw("STATEMENTDATE").ToString).ToString("MM/dd/yyyy")
                            If ConvertToEmptyString(rw("PAYMENTDUEDATE")) <> "" Then _
                                rw("PAYMENTDUEDATE") = CDate(rw("PAYMENTDUEDATE").ToString).ToString("MM/dd/yyyy")
                            If ConvertToEmptyString(rw("CREDITLIMIT")) <> "" Then _
                                rw("CREDITLIMIT") = CDec(rw("CREDITLIMIT").ToString).ToString("N0")
                            rw("COMPLETE_ADDRESS") = String.Format("{0}{1}{2}", rw("ADDRESS").ToString.Trim, IIf(rw("COUNTRY").ToString = "", "", " " & rw("COUNTRY").ToString.Trim), IIf(rw("ZIPCODE").ToString = "", "", " " & rw("ZIPCODE").ToString.Trim))
                            rw("COMPLETE_NAME") = String.Format("{0}{1} {2}", rw("FNAME").ToString.Trim, IIf(rw("MNAME").ToString = "", "", " " & rw("MNAME").ToString.Trim), rw("LNAME").ToString.Trim)
                            rw("CARDNO") = String.Format("{0} XXXX XXXX {1}", Microsoft.VisualBasic.Left(rw("CARDNO").ToString.Trim, 4), Microsoft.VisualBasic.Right(rw("CARDNO").ToString.Trim, 4))
                            rw.AcceptChanges()
                        Next

                        crReportDocument = New RptCarrier
                        crReportDocument.SetDataSource(_dt)
                        '
                        'Dim fileExt As String = extension
                        Dim CrExportOptions As ExportOptions
                        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                        Dim CrFormatTypeOptionsPDF As New PdfRtfWordFormatOptions
                        Dim CrFormatTypeOptionsXLS As New ExcelFormatOptions

                        CrDiskFileDestinationOptions.DiskFileName = String.Format("{0}\CARRIER_{1}_{2}.pdf", outputFolder, System.IO.Path.GetFileNameWithoutExtension(inputFile), Now.ToString("yyyyMMdd_hhmmss"))
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
                Case Else
            End Select

            dtData = _dt

            Return True
        Catch ex As Exception
            strErrMsg = "ClientDLL(before): Runtime error catched " & ex.Message & ex.ToString
            Return False
        End Try
    End Function

    Private Function GenerateRPT_DataSource(ByVal _crReportDocument As ReportDocument, ByVal dtData As DataTable, ByVal outputFile As String, ByRef errMsg As String) As Boolean
        Try
            Dim sbError As New System.Text.StringBuilder

            crReportDocument = _crReportDocument
            crReportDocument.SetDataSource(dtData)
            '
            'Dim fileExt As String = extension
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
                errMsg = ex.Message
                Return False
            End Try

            Return True
        Catch ex As Exception
            errMsg = ex.Message

            Return False
        Finally
            If Not crReportDocument Is Nothing Then
                crReportDocument.Close()
                crReportDocument.Dispose()
            End If
        End Try
    End Function

    Private Function ConvertToEmptyString(ByVal obj As Object) As String
        If IsDBNull(obj) Then
            Return ""
        ElseIf obj.ToString.trim = "" Then
            Return ""
        Else
            Return obj.ToString
        End If
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
