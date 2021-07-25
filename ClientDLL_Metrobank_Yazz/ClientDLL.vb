
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

            Select Case System.IO.Path.GetExtension(inputFile).ToUpper
                Case ".XLS", ".XLSX"
                    Try
                        Dim AR_REFNO_FILE As String = System.Windows.Forms.Application.StartupPath & "\AR_REFNO"
                        Dim AR_REFNO_LASTINDEX As Integer = 0

                        If Not System.IO.File.Exists(AR_REFNO_FILE) Then
                        Else
                            Dim AR_REFNO As String = System.IO.File.ReadAllText(AR_REFNO_FILE)
                            If AR_REFNO.Split("|")(0) = Now.ToShortDateString Then
                                AR_REFNO_LASTINDEX = AR_REFNO.Split("|")(1)
                            End If
                        End If

                        Dim frmARSEQ As New frmARSEQ(AR_REFNO_LASTINDEX)
                        frmARSEQ.ShowDialog()

                        If Not frmARSEQ.IsSubmitted Then
                            System.Windows.Forms.MessageBox.Show("User cancelled the AR SEQ window", "AR SEQUENCE", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                            Return False
                        End If

                        AR_REFNO_LASTINDEX = frmARSEQ.EnteredLastSequence

                        _dt.Columns.Add("BARCODE", GetType(System.Byte()))

                        Dim BarcodePath As String = String.Format("{0}\TempBarcode.jpg", System.Windows.Forms.Application.StartupPath)
                        Dim bln As Boolean

                        For Each rw As DataRow In _dt.Rows
                            If System.IO.File.Exists(BarcodePath) Then System.IO.File.Delete(BarcodePath)

                            AR_REFNO_LASTINDEX += 1

                            rw("AR_REFNO") = Now.ToString("yyyy-MMdd") & "-" & AR_REFNO_LASTINDEX.ToString.PadLeft(6, "0")

                            'barcode
                            For i As Short = 1 To 3
                                bln = GenerateBarcode(rw("AR_REFNO").ToString.Trim.Replace("-", ""), BarcodePath)
                                If bln Then Exit For
                                System.Threading.Thread.Sleep(3000)
                            Next

                            rw("FNAME") = rw("FNAME").ToString.ToUpper
                            rw("MNAME") = rw("MNAME").ToString.ToUpper
                            rw("LNAME") = rw("LNAME").ToString.ToUpper
                            rw("ADDRESS") = rw("ADDRESS").ToString.ToUpper
                            rw("ALT_ADDRESS") = rw("ALT_ADDRESS").ToString.ToUpper

                            rw("BARCODE") = System.IO.File.ReadAllBytes(BarcodePath)
                            rw.AcceptChanges()
                        Next

                        System.IO.File.WriteAllText(AR_REFNO_FILE, String.Format("{0}|{1}", Now.ToShortDateString, AR_REFNO_LASTINDEX))

                        crReportDocument = New RptAR_MSP
                        crReportDocument.SetDataSource(_dt)
                        'OpenReportDbase()
                        '
                        'Dim fileExt As String = extension
                        Dim CrExportOptions As ExportOptions
                        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                        Dim CrFormatTypeOptionsPDF As New PdfRtfWordFormatOptions
                        Dim CrFormatTypeOptionsXLS As New ExcelFormatOptions

                        CrDiskFileDestinationOptions.DiskFileName = String.Format("{0}\AR_{1}_{2}.pdf", outputFolder, System.IO.Path.GetFileNameWithoutExtension(inputFile), Now.ToString("yyyyMMdd_hhmmss"))
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
                    Dim _frm As New frmARFI(inputFile.Replace("_YBNP", "_ARFI"))
                    _frm.ShowDialog()

                    If Not _frm.IsSuccess Then
                        strErrMsg = "User cancel ARFI selection process"
                        Return False
                    End If

                    Dim dtARFI As New DataTable
                    dtARFI.Columns.Add("CARDNO", GetType(String))
                    dtARFI.Columns.Add("REFNO", GetType(String))

                    Dim intLine As Integer = 1
                    Dim REFNO As String = ""
                    Dim CARDNO As String = ""

                    Try
                        Using sr As New System.IO.StreamReader(_frm.ARFI_File)
                            Dim strLines As String = sr.ReadToEnd

                            For Each strLine As String In strLines.Split(vbLf)
                                If strLine.Trim <> "" Then
                                    CARDNO = strLine.Substring(341, 16)
                                    REFNO = strLine.Substring(369, 7)

                                    Dim rw As DataRow = dtARFI.NewRow
                                    rw(0) = CARDNO
                                    rw(1) = REFNO
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
                        If dtARFI.Select("CARDNO='" & rw("CARDNO").ToString & "'").Length > 0 Then
                            Dim rwARFI() As DataRow = dtARFI.Select("CARDNO='" & rw("CARDNO").ToString & "'")
                            _dt.Select("CARDNO='" & rw("CARDNO").ToString & "'")(0)("REFNO") = "'" & rwARFI(0)("REFNO").ToString
                            _dt.Select("CARDNO='" & rw("CARDNO").ToString & "'")(0)("CARDNO_4D") = "'" & _dt.Select("CARDNO='" & rw("CARDNO").ToString & "'")(0)("CARDNO_4D").ToString.Replace("/", "")
                            _dt.Select("CARDNO='" & rw("CARDNO").ToString & "'")(0)("EXPIRYDATE") = _dt.Select("CARDNO='" & rw("CARDNO").ToString & "'")(0)("EXPIRYDATE").ToString.Replace("/", "")
                            _dt.Select("CARDNO='" & rw("CARDNO").ToString & "'")(0)("CARDNO") = "'" & _dt.Select("CARDNO='" & rw("CARDNO").ToString & "'")(0)("CARDNO")
                        Else
                            sbError.AppendLine("Unable to find cardno " & rw("CARDNO").ToString & " in ARFI file")
                        End If
                    Next
            End Select

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
