
Imports Excel = Microsoft.Office.Interop.Excel

Public Class ClientDLL

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
            Return ExportToExcel(dtData, outputFolder & "\Transmittal" & System.IO.Path.GetFileNameWithoutExtension(fileName) & ".xls", errMsg, {"NO.", "BRANCH CODE", "BRANCH NAME", "BRANCH GROUP", "QUANTITY", "NO Of BOX", "CARDS PER BOX"})
        End If

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

            Dim startColumn As String = "A"
            Dim endColumn As String = "G"

            chartRange = xlWorkSheet.Range(startColumn & "1", endColumn & "1")
            chartRange.Merge()
            chartRange = xlWorkSheet.Range(startColumn & "2", endColumn & "2")
            chartRange.Merge()
            chartRange = xlWorkSheet.Range(startColumn & "3", endColumn & "3")
            chartRange.Merge()

            xlWorkSheet.Cells(1, 1) = "LANDBANK OF THE PHILIPPINES"
            xlWorkSheet.Cells(1, 1).HorizontalAlignment = 3
            xlWorkSheet.Cells(2, 1) = "TRANSMITTAL SUMMARY REPORT"
            xlWorkSheet.Cells(2, 1).HorizontalAlignment = 3
            xlWorkSheet.Cells(3, 1) = dtData.Rows(0)("OUTPUTFILE")
            xlWorkSheet.Cells(3, 1).HorizontalAlignment = 3

            chartRange = xlWorkSheet.Range(startColumn & "1", endColumn & "3")
            chartRange.Font.Bold = True

            If Not colHeader Is Nothing Then
                For iColHeader As Short = 0 To colHeader.Length - 1
                    xlWorkSheet.Cells(5, iColHeader + 1) = colHeader(iColHeader)
                    xlWorkSheet.Cells(5, iColHeader + 1).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
                    xlWorkSheet.Cells(5, iColHeader + 1).HorizontalAlignment = 3
                Next
            End If

            chartRange = xlWorkSheet.Range(startColumn & "5", endColumn & "5")
            chartRange.Font.Bold = True

            Dim intRowIndex As Integer = 6
            Dim intRecordCntr As Integer = 1
            Dim intCntrSummary As Integer = 0

            xlWorkSheet.Range("A:A").ColumnWidth = 8.43
            xlWorkSheet.Range("B:B").ColumnWidth = 15.0
            xlWorkSheet.Range("C:C").ColumnWidth = 40.0
            xlWorkSheet.Range("D:D").ColumnWidth = 40.0
            xlWorkSheet.Range("E:E").ColumnWidth = 15.0
            xlWorkSheet.Range("F:F").ColumnWidth = 15.0
            xlWorkSheet.Range("G:G").ColumnWidth = 15.0

            Dim intQtyPerBox As Integer = 500

            For Each rw As DataRow In dtData.Rows
                xlWorkSheet.Cells(intRowIndex, 1) = intRecordCntr
                xlWorkSheet.Cells(intRowIndex, 1).HorizontalAlignment = 3
                xlWorkSheet.Cells(intRowIndex, 1).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                xlWorkSheet.Cells(intRowIndex, 2).NumberFormat = "@"
                xlWorkSheet.Cells(intRowIndex, 2) = rw("BRANCHCODE").ToString
                xlWorkSheet.Cells(intRowIndex, 2).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
                xlWorkSheet.Cells(intRowIndex, 2).HorizontalAlignment = 3

                xlWorkSheet.Cells(intRowIndex, 3) = rw("BRANCHNAME").ToString.Trim.ToUpper
                xlWorkSheet.Cells(intRowIndex, 3).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                xlWorkSheet.Cells(intRowIndex, 4) = rw("BRANCHGROUP").ToString.Trim.ToUpper
                xlWorkSheet.Cells(intRowIndex, 4).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                intCntrSummary += CInt(rw("CNTR"))

                xlWorkSheet.Cells(intRowIndex, 5) = CInt(rw("CNTR")).ToString("N0")
                xlWorkSheet.Cells(intRowIndex, 5).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
                xlWorkSheet.Cells(intRowIndex, 5).HorizontalAlignment = 3

                xlWorkSheet.Cells(intRowIndex, 6) = NoOfBox(CInt(rw("CNTR")), intQtyPerBox)
                xlWorkSheet.Cells(intRowIndex, 6).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
                xlWorkSheet.Cells(intRowIndex, 6).HorizontalAlignment = 3

                xlWorkSheet.Cells(intRowIndex, 7) = intQtyPerBox.ToString
                xlWorkSheet.Cells(intRowIndex, 7).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
                xlWorkSheet.Cells(intRowIndex, 7).HorizontalAlignment = 3

                intRowIndex += 1
                intRecordCntr += 1
            Next

            intRowIndex += 1
            xlWorkSheet.Cells(intRowIndex, 4) = "TOTAL"
            xlWorkSheet.Cells(intRowIndex, 4).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
            xlWorkSheet.Cells(intRowIndex, 4).HorizontalAlignment = 3
            xlWorkSheet.Cells(intRowIndex, 4).Font.Bold = True

            xlWorkSheet.Cells(intRowIndex, 5) = (intCntrSummary).ToString("N0")
            xlWorkSheet.Cells(intRowIndex, 5).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
            xlWorkSheet.Cells(intRowIndex, 5).HorizontalAlignment = 3
            xlWorkSheet.Cells(intRowIndex, 5).Font.Bold = True

            Dim _xlFileFormat As Excel.XlFileFormat = Excel.XlFileFormat.xlExcel8
            If System.IO.Path.GetExtension(outputFile).ToUpper = ".XLSX" Then _xlFileFormat = Excel.XlFileFormat.xlWorkbookNormal

            outputFile = String.Format("{0}\{1}", outputFile.Substring(0, outputFile.LastIndexOf("\")), System.IO.Path.GetFileName(outputFile).Replace("_", "_B" & dtData.Rows(0)("BATCH") & "_"))

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

    Private Function NoOfBox(ByVal Qty As Integer, ByVal QtyPerBox As Integer) As String
        Dim intBoxCntr As Integer = 0

        Dim RunningQty As Integer = Qty

        Do While RunningQty > QtyPerBox
            RunningQty = RunningQty - QtyPerBox
            intBoxCntr += 1
        Loop

        intBoxCntr += 1

        Return intBoxCntr.ToString
    End Function

End Class
