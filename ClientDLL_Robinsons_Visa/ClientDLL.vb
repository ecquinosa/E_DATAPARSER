
Imports Excel = Microsoft.Office.Interop.Excel
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

            dtData = _dt

            'MsgBox("ProcessBeforeGeneration")

            If sbError.ToString <> "" Then
                strErrMsg = sbError.ToString

                Return False
            End If

            Return True
        Catch ex As Exception
            strErrMsg = "ClientDLL(before): Runtime error catched " & ex.Message
            Return False
        End Try
    End Function

    Public Function ProcessAfterGeneration(ByVal outputFolder As String,
                                           ByRef dtData As DataTable, ByRef status As String, ByRef _action As Action,
                                           Optional extension As String = "pdf", Optional ByVal fileName As String = "") As Boolean
        'Dim frm As New frmOutput
        'frm.ShowDialog()
        Dim fileExt As String = "xls" 'frm.fileExt
        'frm = Nothing

        Dim sbError As New System.Text.StringBuilder
        Dim _dt As DataTable = dtData

        If fileExt = "xls" Then
            Dim errMsg As String = ""
            Return ExportToExcel(dtData, outputFolder & "\Transmittal" & System.IO.Path.GetFileNameWithoutExtension(fileName) & ".xls", errMsg, {"No", "NAME", "CARD NUMBER", "COMPANY NAME", "BRANCH NAME"})
        End If


        Try
            crReportDocument = New RptTransmittal
            crReportDocument.SetDataSource(_dt)
            'OpenReportDbase()            '

            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
            Dim CrFormatTypeOptionsPDF As New PdfRtfWordFormatOptions
            Dim CrFormatTypeOptionsXLS As New ExcelFormatOptions

            CrDiskFileDestinationOptions.DiskFileName = String.Format("{0}\Transmittal{1}." & fileExt, outputFolder, IIf(fileName = "", Now.ToString("yyyyMMdd_hhmmss"), fileName))
            CrExportOptions = crReportDocument.ExportOptions

            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .DestinationOptions = CrDiskFileDestinationOptions
                Select Case fileExt
                    Case "pdf"
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .FormatOptions = CrFormatTypeOptionsPDF
                    Case "xls", "xlsx"
                        .ExportFormatType = ExportFormatType.Excel
                        .FormatOptions = CrFormatTypeOptionsXLS

                End Select

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

    Private Function ExportToExcel(ByVal dtData As DataTable, ByVal outputFile As String, ByRef errMsg As String,
                                   Optional ByVal colHeader() As String = Nothing) As Boolean
        Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application()
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet


        Try
            If xlApp Is Nothing Then
                errMsg = "Excel is not properly installed!"
                Return False
            End If

            Dim misValue As Object = System.Reflection.Missing.Value
            Dim chartRange As Excel.Range

            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")

            chartRange = xlWorkSheet.Range("A1", "E1")
            chartRange.Merge()
            chartRange = xlWorkSheet.Range("A2", "E2")
            chartRange.Merge()
            chartRange = xlWorkSheet.Range("A3", "E3")
            chartRange.Merge()

            xlWorkSheet.Cells(1, 1) = "TRANSMITTAL REPORT"
            xlWorkSheet.Cells(1, 1).HorizontalAlignment = 3
            xlWorkSheet.Cells(2, 1) = "ROBINSONS BANK"
            xlWorkSheet.Cells(2, 1).HorizontalAlignment = 3
            xlWorkSheet.Cells(3, 1) = System.IO.Path.GetFileNameWithoutExtension(outputFile.Replace("Transmittal", "")) '"V" & Now.ToString("MMddyyyy")
            xlWorkSheet.Cells(3, 1).HorizontalAlignment = 3

            chartRange = xlWorkSheet.Range("A1", "A3")
            chartRange.Font.Bold = True

            If Not colHeader Is Nothing Then
                For iColHeader As Short = 0 To colHeader.Length - 1
                    xlWorkSheet.Cells(8, iColHeader + 1) = colHeader(iColHeader)
                    xlWorkSheet.Cells(8, iColHeader + 1).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
                    xlWorkSheet.Cells(8, iColHeader + 1).HorizontalAlignment = 3
                Next
            End If

            chartRange = xlWorkSheet.Range("A8", "E8")
            chartRange.Font.Bold = True

            Dim intRowIndex As Integer = 9
            Dim intRecordCntr As Integer = 1

            xlWorkSheet.Range("A:A").ColumnWidth = 8.43
            xlWorkSheet.Range("B:B").ColumnWidth = 40.0
            xlWorkSheet.Range("C:C").ColumnWidth = 40.0
            xlWorkSheet.Range("D:D").ColumnWidth = 40.0
            xlWorkSheet.Range("E:E").ColumnWidth = 40.0


            For Each rw As DataRow In dtData.Rows
                xlWorkSheet.Cells(intRowIndex, 1) = intRecordCntr
                xlWorkSheet.Cells(intRowIndex, 1).HorizontalAlignment = 3
                xlWorkSheet.Cells(intRowIndex, 1).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                xlWorkSheet.Cells(intRowIndex, 2) = rw("CARDNAME")
                xlWorkSheet.Cells(intRowIndex, 2).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                xlWorkSheet.Cells(intRowIndex, 3) = "'" & rw("CARDNUMBER")
                xlWorkSheet.Cells(intRowIndex, 3).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
                xlWorkSheet.Cells(intRowIndex, 3).HorizontalAlignment = 3

                xlWorkSheet.Cells(intRowIndex, 4) = rw("COMPANY")
                xlWorkSheet.Cells(intRowIndex, 4).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                xlWorkSheet.Cells(intRowIndex, 5) = rw("BRANCH_NAME")
                xlWorkSheet.Cells(intRowIndex, 5).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                intRowIndex += 1
                intRecordCntr += 1
            Next

            intRowIndex += 1
            xlWorkSheet.Cells(intRowIndex, 2) = "TOTAL"
            xlWorkSheet.Cells(intRowIndex, 2).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
            xlWorkSheet.Cells(intRowIndex, 2).HorizontalAlignment = 3
            xlWorkSheet.Cells(intRowIndex, 2).Font.Bold = True

            xlWorkSheet.Cells(intRowIndex, 3) = (intRecordCntr - 1).ToString("N0")
            xlWorkSheet.Cells(intRowIndex, 3).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
            xlWorkSheet.Cells(intRowIndex, 3).HorizontalAlignment = 3
            xlWorkSheet.Cells(intRowIndex, 3).Font.Bold = True

            Dim _xlFileFormat As Excel.XlFileFormat = Excel.XlFileFormat.xlExcel8
            If System.IO.Path.GetExtension(outputFile).ToUpper = ".XLSX" Then _xlFileFormat = Excel.XlFileFormat.xlWorkbookNormal

            xlWorkBook.SaveAs(outputFile, _xlFileFormat, misValue, misValue, misValue, misValue,
             Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
            xlWorkBook.Close(True, misValue, misValue)
            xlApp.Quit()
            System.Threading.Thread.Sleep(1000)

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)

            Return False
        Finally
            releaseObject(xlWorkSheet)
            releaseObject(xlWorkBook)
            releaseObject(xlApp)
        End Try

    End Function

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Class
