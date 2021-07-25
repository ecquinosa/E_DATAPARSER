

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

            For Each rw As DataRow In _dt.Rows
                If rw("EB-POSTING-FLAG").ToString.Trim = "PP" Then
                    rw("EMBOSSINGNAME1") = ""
                ElseIf rw("EB-POSTING-FLAG").ToString.Trim = "NP" Then
                    rw("EMBOSSINGNAME1") = "C/O " & rw("EMBOSSINGNAME1").ToString.Trim
                End If

                rw.AcceptChanges()
            Next

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

End Class
