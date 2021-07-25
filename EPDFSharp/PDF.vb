
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf
Imports PdfSharp.Drawing.Layout
Imports PdfSharp.Pdf.IO

Public Class PDF

    Private sbLog As New System.Text.StringBuilder
    Private _totalPage As Integer = 0

    Public Property TotalPage As Integer
        Get
            Return _totalPage
        End Get
        Set(value As Integer)
            _totalPage = value
        End Set
    End Property

    Public ReadOnly Property ProcessLog As String
        Get
            Return sbLog.ToString
        End Get
    End Property

    Public Class Profile

        Public Class FieldCollection

            Private _id As String = ""
            Private _refId As String = ""
            Private _objType As String = ""
            Private _obj As Object = Nothing
            Private _defaultValue As String = ""
            Private _dataType As String = ""
            Private _stringFormat As String = ""

            Public Property ID As String
                Get
                    Return _id
                End Get
                Set(value As String)
                    _id = value
                End Set
            End Property

            Public Property RefID As String
                Get
                    Return _refId
                End Get
                Set(value As String)
                    _refId = value
                End Set
            End Property

            Public Property DefaultValue As String
                Get
                    Return _defaultValue
                End Get
                Set(value As String)
                    _defaultValue = value
                End Set
            End Property

            Public Property DataType As String
                Get
                    Return _dataType
                End Get
                Set(value As String)
                    _dataType = value
                End Set
            End Property

            Public Property StringFormat As String
                Get
                    Return _stringFormat
                End Get
                Set(value As String)
                    _stringFormat = value
                End Set
            End Property

            Public Property ObjectType As String
                Get
                    Return _objType
                End Get
                Set(value As String)
                    _objType = value
                End Set
            End Property

            Public Property FCObject As Object
                Get
                    Return _obj
                End Get
                Set(value As Object)
                    _obj = value
                End Set
            End Property

        End Class

        Public Class PageHeaderFieldCollection
            Inherits FieldCollection

            Private _isFirstPageOnly As Boolean = False

            Public Property FirstPageOnly As Boolean
                Get
                    Return _isFirstPageOnly
                End Get
                Set(ByVal value As Boolean)
                    _isFirstPageOnly = value
                End Set
            End Property

        End Class

        Public Class StringObject

            Private _value As String = ""
            Private _font As XFont
            Private _rect As XRect
            Private _xStringFormat As Short = 0
            Private _xBrush As Short = 0
            Private _paragraphAlignment As Short = 0
            Private _IsDrawRect As Short = 0

            Public Property Value As String
                Get
                    Return _value
                End Get
                Set(value As String)
                    _value = value
                End Set
            End Property

            Public Property Font As XFont
                Get
                    Return _font
                End Get
                Set(value As XFont)
                    _font = value
                End Set
            End Property

            Public Property XRect As XRect
                Get
                    Return _rect
                End Get
                Set(value As XRect)
                    _rect = value
                End Set
            End Property

            Public Property XStringFormat As Short
                Get
                    Return _xStringFormat
                End Get
                Set(value As Short)
                    _xStringFormat = value
                End Set
            End Property

            Public Property XBrush As Short
                Get
                    Return _xBrush
                End Get
                Set(value As Short)
                    _xBrush = value
                End Set
            End Property

            Public Property IsDrawRect As Short
                Get
                    Return _IsDrawRect
                End Get
                Set(value As Short)
                    _IsDrawRect = value
                End Set
            End Property

            Public Property ParagraphAlignment As Short
                Get
                    Return _paragraphAlignment
                End Get
                Set(value As Short)
                    _paragraphAlignment = value
                End Set
            End Property

            Public Function GetXStringFormat() As Drawing.XStringFormat
                Select Case _xStringFormat
                    Case 0
                        Return Drawing.XStringFormats.Default
                    Case 1
                        Return Drawing.XStringFormats.Center
                    Case 2
                        Return PdfSharp.Drawing.XStringFormats.TopLeft
                    Case 3
                        Return PdfSharp.Drawing.XStringFormats.TopCenter
                    Case 4
                        Return PdfSharp.Drawing.XStringFormats.BottomCenter
                End Select
            End Function

            Public Function GetXBrush() As Drawing.XBrush
                Select Case _xBrush
                    Case 0
                        Return Drawing.XBrushes.Black
                    Case 1
                        Return Drawing.XBrushes.White
                    Case 2
                        Return Drawing.XBrushes.Green
                    Case 3
                        Return Drawing.XBrushes.Red
                    Case 4
                        Return Drawing.XBrushes.Blue
                    Case 5
                        Return Drawing.XBrushes.Orange
                    Case 6
                        Return Drawing.XBrushes.Gray
                    Case 7
                        Return Drawing.XBrushes.Silver
                End Select
            End Function

            Public Function GetParagraphAlignment() As XParagraphAlignment
                Select Case _paragraphAlignment
                    Case 0
                        Return XParagraphAlignment.Default
                    Case 1
                        Return XParagraphAlignment.Left
                    Case 2
                        Return XParagraphAlignment.Center
                    Case 3
                        Return XParagraphAlignment.Right
                    Case 4
                        Return XParagraphAlignment.Justify
                End Select
            End Function
        End Class

        Public Class LineObject

            Private _lineHeight As Double = 1
            Private _x As Double = 10
            Private _y As Double = 60
            Private _width As Double = 100
            Private _height As Double = 60
            Private _xColor As XColor

            Public Property LineHeight As Double
                Get
                    Return _lineHeight
                End Get
                Set(value As Double)
                    _lineHeight = value
                End Set
            End Property

            Public Property X As Double
                Get
                    Return _x
                End Get
                Set(value As Double)
                    _x = value
                End Set
            End Property

            Public Property Y As Double
                Get
                    Return _y
                End Get
                Set(value As Double)
                    _y = value
                End Set
            End Property

            Public Property Width As Double
                Get
                    Return _width
                End Get
                Set(value As Double)
                    _width = value
                End Set
            End Property

            Public Property Height As Double
                Get
                    Return _height
                End Get
                Set(value As Double)
                    _height = value
                End Set
            End Property

            Public Property XColor As XColor
                Get
                    Return _xColor
                End Get
                Set(value As XColor)
                    _xColor = value
                End Set
            End Property

        End Class

        Public Class RectangleObject

            Private _lineHeight As Double = 1
            Private _rect As XRect
            Private _xColor As XColor

            Public Property LineHeight As Double
                Get
                    Return _lineHeight
                End Get
                Set(value As Double)
                    _lineHeight = value
                End Set
            End Property

            Public Property XRect As XRect
                Get
                    Return _rect
                End Get
                Set(value As XRect)
                    _rect = value
                End Set
            End Property

            Public Property XColor As XColor
                Get
                    Return _xColor
                End Get
                Set(value As XColor)
                    _xColor = value
                End Set
            End Property

        End Class

        Public Class ImageFromFileObject

            Private _diType As Short = 0
            Private _rect As XRect

            Public Property DIType As Short
                Get
                    Return _diType
                End Get
                Set(value As Short)
                    _diType = value
                End Set
            End Property

            Public Property XRect As XRect
                Get
                    Return _rect
                End Get
                Set(value As XRect)
                    _rect = value
                End Set
            End Property

        End Class

        Public Class BarcodeObject

            Private _barcodeSymbology As String = ""
            Private _imageFormat As String = ""
            Private _displayCode As Short = 0
            Private _rect As XRect
            Private _crop As Crop

            Public Property BarcodeSymbology As String
                Get
                    Return _barcodeSymbology
                End Get
                Set(value As String)
                    _barcodeSymbology = value
                End Set
            End Property

            Public Property ImageFormat As String
                Get
                    Return _imageFormat
                End Get
                Set(value As String)
                    _imageFormat = value
                End Set
            End Property

            Public Property DisplayCode As Short
                Get
                    Return _displayCode
                End Get
                Set(value As Short)
                    _displayCode = value
                End Set
            End Property

            Public Property XRect As XRect
                Get
                    Return _rect
                End Get
                Set(value As XRect)
                    _rect = value
                End Set
            End Property

            Public Property Crop As Crop
                Get
                    Return _crop
                End Get
                Set(value As Crop)
                    _crop = value
                End Set
            End Property

            Public Function GetSymbology() As Neodynamic.WinControls.BarcodeProfessional.Symbology
                Select Case _barcodeSymbology
                    Case "Code39"
                        Return Neodynamic.WinControls.BarcodeProfessional.Symbology.Code39
                    Case "Code128"
                        Return Neodynamic.WinControls.BarcodeProfessional.Symbology.Code128
                    Case "Pdf417"
                        Return Neodynamic.WinControls.BarcodeProfessional.Symbology.Pdf417
                    Case "AztecCode"
                        Return Neodynamic.WinControls.BarcodeProfessional.Symbology.AztecCode
                    Case "QRCode"
                        Return Neodynamic.WinControls.BarcodeProfessional.Symbology.QRCode
                    Case "Code11"
                        Return Neodynamic.WinControls.BarcodeProfessional.Symbology.Code11
                    Case "Ean13"
                        Return Neodynamic.WinControls.BarcodeProfessional.Symbology.Ean13
                End Select
            End Function

            Public Function GetImageFormat() As System.Drawing.Imaging.ImageFormat
                Select Case _imageFormat
                    Case "jpg"
                        Return System.Drawing.Imaging.ImageFormat.Jpeg
                    Case "png"
                        Return System.Drawing.Imaging.ImageFormat.Png
                    Case "Gif"
                        Return System.Drawing.Imaging.ImageFormat.Gif
                    Case "bmp"
                        Return System.Drawing.Imaging.ImageFormat.Bmp
                End Select
            End Function


        End Class

        Public Class XFont

            Private _fontName As String = "Arial"
            Private _fontSize As Double = 10
            Private _fontStyle As Short = PdfSharp.Drawing.XFontStyle.Regular

            Public Property FontName As String
                Get
                    Return _fontName
                End Get
                Set(value As String)
                    _fontName = value
                End Set
            End Property

            Public Property FontSize As Double
                Get
                    Return _fontSize
                End Get
                Set(value As Double)
                    _fontSize = value
                End Set
            End Property

            Public Property FontStyle As Short
                Get
                    Return _fontStyle
                End Get
                Set(value As Short)
                    _fontStyle = value
                End Set
            End Property

        End Class

        Public Class XRect

            Private _xValue As Double = 0
            Private _yValue As Double = 0
            Private _width As Double = 0
            Private _height As Double = 0

            Public Property X As Double
                Get
                    Return _xValue
                End Get
                Set(value As Double)
                    _xValue = value
                End Set
            End Property

            Public Property Y As Double
                Get
                    Return _yValue
                End Get
                Set(value As Double)
                    _yValue = value
                End Set
            End Property

            Public Property Width As Double
                Get
                    Return _width
                End Get
                Set(value As Double)
                    _width = value
                End Set
            End Property

            Public Property Height As Double
                Get
                    Return _height
                End Get
                Set(value As Double)
                    _height = value
                End Set
            End Property

        End Class

        Public Class XColor

            Private _xColorProperty As String = ""
            Private _parameter As String = ""

            Public Property xColorProperty As String
                Get
                    Return _xColorProperty
                End Get
                Set(value As String)
                    _xColorProperty = value
                End Set
            End Property

            Public Property Parameter As String
                Get
                    Return _parameter
                End Get
                Set(value As String)
                    _parameter = value
                End Set
            End Property

            Public Function GetXColorProperty() As PdfSharp.Drawing.XColor
                Select Case _xColorProperty
                    Case "FromArgb"
                        If _parameter.Split(",").Length = 3 Then
                            Return PdfSharp.Drawing.XColor.FromArgb(_parameter.Split(",")(0), _parameter.Split(",")(1), _parameter.Split(",")(2))
                        ElseIf _parameter.Split(",").Length = 4 Then
                            Return PdfSharp.Drawing.XColor.FromArgb(_parameter.Split(",")(0), _parameter.Split(",")(1), _parameter.Split(",")(2), _parameter.Split(",")(3))
                        Else
                            Return PdfSharp.Drawing.XColor.FromArgb(System.Drawing.Color.FromName(_parameter))
                        End If
                    Case "FromGrayScale"
                        Return PdfSharp.Drawing.XColor.FromGrayScale(CDbl(_parameter))
                    Case "FromName"
                        Return PdfSharp.Drawing.XColor.FromName(_parameter)
                End Select
            End Function

        End Class

        Public Class PageHeader

            Private _fieldCollections() As PageHeaderFieldCollection = Nothing

            Public Property FieldCollections As PageHeaderFieldCollection()
                Get
                    Return _fieldCollections
                End Get
                Set(value As PageHeaderFieldCollection())
                    _fieldCollections = value
                End Set
            End Property

        End Class

        Public Class RowHeader

            Private _fieldCollections() As PageHeaderFieldCollection = Nothing

            Public Property FieldCollections As PageHeaderFieldCollection()
                Get
                    Return _fieldCollections
                End Get
                Set(value As PageHeaderFieldCollection())
                    _fieldCollections = value
                End Set
            End Property

        End Class

        Public Class RowFooter

            Private _fieldCollections() As PageHeaderFieldCollection = Nothing

            Public Property FieldCollections As PageHeaderFieldCollection()
                Get
                    Return _fieldCollections
                End Get
                Set(value As PageHeaderFieldCollection())
                    _fieldCollections = value
                End Set
            End Property

        End Class

        Public Class PageFooter

            Private _pagingStyle As Short

            Public Property PagingStyle As Short
                Get
                    Return _pagingStyle
                End Get
                Set(value As Short)
                    _pagingStyle = value
                End Set
            End Property

        End Class

        Public Class Crop

            Private _xValue As Double = 0
            Private _yValue As Double = 0
            Private _width As Double = 0
            Private _height As Double = 0

            Public Property X As Double
                Get
                    Return _xValue
                End Get
                Set(value As Double)
                    _xValue = value
                End Set
            End Property

            Public Property Y As Double
                Get
                    Return _yValue
                End Get
                Set(value As Double)
                    _yValue = value
                End Set
            End Property

            Public Property Width As Double
                Get
                    Return _width
                End Get
                Set(value As Double)
                    _width = value
                End Set
            End Property

            Public Property Height As Double
                Get
                    Return _height
                End Get
                Set(value As Double)
                    _height = value
                End Set
            End Property

        End Class

    End Class

    Private BarcodeRepository As String = ""

    Public Sub GeneratePDF(ByVal dt As DataTable, ByVal PDFOutput As ParserDLL.ParserDLL.PDFOutput, ByVal OutputRepository As String,
                           Optional ByVal IsSampleOnly As Boolean = False,
                           Optional ByRef outputFile As String = "")



        ' Create a new PDF document
        Dim document As PdfDocument = New PdfDocument
        'document.Info.Title = "Created with PDFsharp"

        'Dim intPage As Integer = 0
        'Dim intAdd As Integer = 10
        Dim intRecord As Integer = 1
        Dim page As PdfPage
        Dim gfx As XGraphics

        Dim dtHeight As New DataTable
        dtHeight.Columns.Add("ID", GetType(String))
        dtHeight.Columns.Add("Height", GetType(Double))

        Dim intComputedTotalPage As Integer = 1 'dt.DefaultView.Count
        If PDFOutput.RecordPerPage > 1 Then
            If PDFOutput.RecordPerPage < dt.DefaultView.Count Then
                Dim strQuotient As String = (dt.DefaultView.Count / PDFOutput.RecordPerPage).ToString
                If Not strQuotient.Contains(".") Then
                    intComputedTotalPage = CInt(strQuotient)
                Else
                    intComputedTotalPage = CInt(strQuotient.Split(".")(0)) + 1
                End If
            End If
        End If

        Dim intSequenceCntr As Integer = 1
        Dim pageHeader As Profile.PageHeader = Nothing
        Dim pageFooter As Profile.PageFooter = Nothing

        For Each rw As DataRow In dt.Rows
            If PDFOutput.RecordPerPage = 1 Then
                'Dim page As PdfPage
                page = document.AddPage
                If PDFOutput.PageOrientation = "Landscape" Then
                    page.Orientation = PageOrientation.Landscape
                End If

                If PDFOutput.PageSize > 0 Then page.Size = GetPageSize(PDFOutput.PageSize)

                gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Prepend)
            Else
                If intRecord = 1 Then
                    page = document.AddPage
                    If PDFOutput.PageOrientation = "Landscape" Then
                        page.Orientation = PageOrientation.Landscape
                    End If

                    If PDFOutput.PageSize > 0 Then page.Size = GetPageSize(PDFOutput.PageSize)

                    gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Append)
                End If
            End If

            ' Get an XGraphics object for drawinge
            'Dim gfx As XGraphics = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Prepend)
            Dim tf As New XTextFormatter(gfx)

            ' Draw the text
            For Each fc As Profile.FieldCollection In PDFOutput.PDFOutputFieldElements
                Dim rwHeight As DataRow = dtHeight.NewRow
                rwHeight("ID") = fc.ID

                WriteObject(PDFOutput, gfx, fc, tf, rw, dtHeight, intRecord, intSequenceCntr, , rwHeight)
            Next

            If intRecord = 1 Then
                If Not PDFOutput.PageHeader Is Nothing Then
                    For Each phfc As Profile.PageHeaderFieldCollection In PDFOutput.PageHeader.FieldCollections
                        WriteObject(PDFOutput, gfx, phfc, tf, rw, dtHeight, intRecord, intSequenceCntr, 0)
                    Next
                End If

                If Not PDFOutput.RowHeader Is Nothing Then
                    For Each phfc As Profile.PageHeaderFieldCollection In PDFOutput.RowHeader.FieldCollections
                        WriteObject(PDFOutput, gfx, phfc, tf, rw, dtHeight, intRecord, intSequenceCntr, 2)
                    Next
                End If

                If Not PDFOutput.PageFooter Is Nothing Then DrawFooter(document, page, gfx, intComputedTotalPage, PDFOutput.PageFooter.PagingStyle)
            End If

            ''''http://pdfsharp.net/wiki/Graphics-sample.ashx#Show_how_to_align_text_in_the_layout_rectangle_18
            '''combine pdf files
            '''http://www.pdfsharp.net/wiki/ConcatenateDocuments-sample.ashx

            'gfx = Nothing
            'page = Nothing

            If PDFOutput.RecordPerPage = 1 Then
                dtHeight.Clear()
            Else
                Dim intLastRowsHeight As Integer = 0

                Dim firstID As String = dtHeight.Rows(0)(0)
                For Each rwH As DataRow In dtHeight.Select("ID='" & firstID & "'")
                    intLastRowsHeight += rwH("Height")
                Next

                If intRecord = 50 Then
                    Console.Write("TEST")
                End If

                If intRecord < PDFOutput.RecordPerPage Then
                    intRecord += 1

                    Select Case intSequenceCntr
                        Case dt.DefaultView.Count, PDFOutput.RecordPerPage
                            WriteRowFooter(PDFOutput, gfx, tf, rw, dtHeight, intRecord, intSequenceCntr, document.PageCount, intComputedTotalPage, dt, intLastRowsHeight + 17)
                    End Select

                    'If intRecord = dt.DefaultView.Count Then _
                    'WriteRowFooter(PDFOutput, gfx, tf, rw, dtHeight, intRecord, intSequenceCntr, document.PageCount, intComputedTotalPage, dt, intLastRowsHeight + 27)
                Else
                    Select Case intRecord
                        Case dt.DefaultView.Count, PDFOutput.RecordPerPage
                            WriteRowFooter(PDFOutput, gfx, tf, rw, dtHeight, intRecord, intSequenceCntr, document.PageCount, intComputedTotalPage, dt, intLastRowsHeight + 17)
                    End Select

                    intRecord = 1
                    page = Nothing
                    gfx = Nothing
                    dtHeight.Clear()
                End If
            End If

            tf = Nothing

            intSequenceCntr += 1

            If IsSampleOnly Then Exit For
        Next

        ' Save the document...
        Dim filename As String = String.Format("{0}\{1}_{2}{3}.pdf", OutputRepository, dt.TableName, Now.ToString("hhmmss"), PDFOutput.OutputFileName)
        outputFile = filename
        document.Save(filename)

        'Try
        '    System.IO.Directory.Delete(BarcodeFolder, True)
        'Catch ex As Exception
        'End Try

        ' ...and start a viewer.
        'Process.Start(filename)
    End Sub

    Private Sub WriteRowFooter(ByVal PDFOutput As ParserDLL.ParserDLL.PDFOutput, ByVal gfx As XGraphics,
                               ByVal tf As XTextFormatter, ByVal rw As DataRow, ByVal dtHeight As DataTable,
                               ByVal intRecord As Integer, ByVal intSequenceCntr As Integer,
                               ByVal pageCount As Integer, ByVal intComputedTotalPage As Integer,
                               ByVal dtSourceData As DataTable,
                               ByVal intLastRowsHeight As Integer)
        'Dim intLastRowsHeight As Integer = 0

        'Dim firstID As String = dtHeight.Rows(0)(0)
        'For Each rwH As DataRow In dtHeight.Select("ID='" & firstID & "'")
        '    intLastRowsHeight += rwH("Height")
        'Next

        If PDFOutput.RecordPerPage > 1 And pageCount = intComputedTotalPage Then
            If Not PDFOutput.RowFooter Is Nothing Then
                Dim dtGroupingSummary As New DataTable
                dtGroupingSummary.Columns.Add("ID", GetType(String))
                dtGroupingSummary.Columns.Add("Function", GetType(String))
                dtGroupingSummary.Columns.Add("Value", GetType(Int32))

                Dim rwGrouping As DataRow = dtGroupingSummary.NewRow

                For Each phfc As Profile.PageHeaderFieldCollection In PDFOutput.RowFooter.FieldCollections
                    Dim id As String = ""
                    Dim func As String = ""
                    If phfc.DefaultValue.Contains("Sum(") Then
                        id = phfc.DefaultValue.Replace("Sum(", "").Replace(")", "")
                        func = "Sum"
                    ElseIf phfc.DefaultValue.Contains("Count") Then
                        id = phfc.DefaultValue.Replace("Count(", "").Replace(")", "")
                        func = "Count"
                    End If

                    If id <> "" Then
                        If dtGroupingSummary.Select("ID='" & id & "'").Length = 0 Then
                            rwGrouping(0) = id
                            rwGrouping(1) = func

                            If func = "Sum" Then
                                Dim intTotal As Integer = 0
                                For Each rwData As DataRow In dtSourceData.Rows
                                    intTotal += rwData(id)
                                Next

                                rwGrouping(2) = intTotal
                                dtGroupingSummary.Rows.Add(rwGrouping)
                            ElseIf func = "Count" Then
                                rwGrouping(2) = dtSourceData.DefaultView.Count
                                dtGroupingSummary.Rows.Add(rwGrouping)
                            End If
                        End If
                    End If

                    'Dim rwHeight2 As DataRow = dtHeight.NewRow
                    'rwHeight2("ID") = phfc.ID

                    If dtGroupingSummary.Select(String.Format("ID='{0}' AND Function='{1}'", id, func)).Length > 0 Then
                        WriteObject(PDFOutput, gfx, phfc, tf, dtGroupingSummary.Select(String.Format("ID='{0}' AND Function='{1}'", id, func))(0), Nothing, intRecord, intSequenceCntr, 4, , intLastRowsHeight)
                    Else
                        WriteObject(PDFOutput, gfx, phfc, tf, rw, Nothing, intRecord, intSequenceCntr, 4, , intLastRowsHeight)
                    End If

                Next
            End If
        End If
    End Sub

    Private Function GetPageSize(ByVal size As Integer) As PageSize
        Select Case size
            Case 1
                Return PageSize.A0
            Case 2
                Return PageSize.A1
            Case 3
                Return PageSize.A2
            Case 4
                Return PageSize.A3
            Case 5
                Return PageSize.A4
            Case 6
                Return PageSize.A5
            Case 7
                Return PageSize.RA0
            Case 8
                Return PageSize.RA1
            Case 9
                Return PageSize.RA2
            Case 10
                Return PageSize.RA3
            Case 11
                Return PageSize.RA4
            Case 12
                Return PageSize.RA5
            Case 13
                Return PageSize.B0
            Case 14
                Return PageSize.B1
            Case 15
                Return PageSize.B2
            Case 16
                Return PageSize.B3
            Case 17
                Return PageSize.B4
            Case 18
                Return PageSize.B5
            Case 100
                Return PageSize.Quarto
            Case 101
                Return PageSize.Foolscap
            Case 102
                Return PageSize.Executive
            Case 103
                Return PageSize.GovernmentLetter
            Case 104
                Return PageSize.Letter
            Case 105
                Return PageSize.Legal
            Case 106
                Return PageSize.Ledger
            Case 107
                Return PageSize.Tabloid
            Case 108
                Return PageSize.Post
            Case 109
                Return PageSize.Crown
            Case 110
                Return PageSize.LargePost
            Case 111
                Return PageSize.Demy
            Case 112
                Return PageSize.Medium
            Case 113
                Return PageSize.Royal
            Case 114
                Return PageSize.Elephant
            Case 115
                Return PageSize.DoubleDemy
            Case 116
                Return PageSize.QuadDemy
            Case 117
                Return PageSize.STMT
            Case 120
                Return PageSize.Folio
            Case 121
                Return PageSize.Statement
            Case 122
                Return PageSize.Size10x14
        End Select
    End Function

    Private Sub WriteObject(ByVal PDFOutput As ParserDLL.ParserDLL.PDFOutput, ByVal gfx As XGraphics, ByVal fc As Object,
                            ByVal tf As XTextFormatter, ByVal rw As DataRow, ByRef dtHeight As DataTable,
                            ByVal intRecord As Integer, ByVal intSequenceCntr As Integer,
                            Optional ByVal Type As Short = 3,
                            Optional ByVal rwHeight As DataRow = Nothing,
                            Optional RowTotalHeight As Integer = 0)
        'type 0=PageHeader, 1=PageFooter, 2=RowHeader, 3=Row, 4=RowFooter

        If Type = 3 Then
            fc = DirectCast(fc, Profile.FieldCollection)
        Else
            fc = DirectCast(fc, PDF.Profile.PageHeaderFieldCollection)
        End If

        If fc.ObjectType = "String" Then
            Dim stringObject As Profile.StringObject = fc.FCObject

            Dim intHeight As Integer = stringObject.XRect.Y

            Select Case Type
                Case 3
                    If intRecord = 1 Then
                        rwHeight("Height") = stringObject.XRect.Y
                    Else
                        rwHeight("Height") = stringObject.XRect.Height
                    End If

                    dtHeight.Rows.Add(rwHeight)
                    intHeight = GetTotalHeight(dtHeight, fc.ID)
                Case 4
                    intHeight = RowTotalHeight
            End Select

            'If RowType > 0 Then dtHeight.Rows.Add(rwHeight)
            Dim font As XFont = New XFont(stringObject.Font.FontName, stringObject.Font.FontSize, stringObject.Font.FontStyle)

            'If RowType > 0 Then intHeight = GetTotalHeight(dtHeight, fc.ID)
            Dim rect As XRect = New XRect(stringObject.XRect.X, intHeight, stringObject.XRect.Width, stringObject.XRect.Height)
            If stringObject.IsDrawRect = 1 Then
                Dim pen As XPen = New XPen(XColor.FromName("Black"))
                gfx.DrawRectangle(pen, rect)
            End If
            tf.Alignment = stringObject.GetParagraphAlignment
            If fc.ID = "SeqCntr" Then
                tf.DrawString(intSequenceCntr.ToString, font, stringObject.GetXBrush, New XRect(rect.X + 5, rect.Y, rect.Width - 5, rect.Height), stringObject.GetXStringFormat)
            Else
                If Type = 3 Then
                    tf.DrawString(rw(fc.RefID).ToString.Trim, font, stringObject.GetXBrush, New XRect(rect.X + 5, rect.Y, rect.Width - 5, rect.Height), stringObject.GetXStringFormat)
                Else
                    Dim value As String = GetFieldValue(fc, rw, "")
                    tf.DrawString(value, font, stringObject.GetXBrush, New XRect(rect.X + 5, rect.Y, rect.Width - 5, rect.Height), stringObject.GetXStringFormat)
                End If
            End If
        ElseIf fc.ObjectType = "Line" Then
            Dim lineObject As Profile.LineObject = fc.FCObject

            Select Case Type
                Case 3
                    If intRecord = 1 Then
                        rwHeight("Height") = lineObject.Y
                    Else
                        rwHeight("Height") = lineObject.Height
                    End If

                    dtHeight.Rows.Add(rwHeight)
            End Select

            'If RowType > 0 Then dtHeight.Rows.Add(rwHeight)
            Dim pen As XPen = New XPen(lineObject.XColor.GetXColorProperty, lineObject.LineHeight)
            gfx.DrawLine(pen, lineObject.X, GetTotalHeight(dtHeight, fc.ID), lineObject.Width, lineObject.Height)
        ElseIf fc.ObjectType = "Rectangle" Then
            Dim rectangleObject As Profile.RectangleObject = fc.FCObject

            Select Case Type
                Case 3
                    If intRecord = 1 Then
                        rwHeight("Height") = rectangleObject.XRect.Y
                    Else
                        rwHeight("Height") = rectangleObject.XRect.Height
                    End If

                    dtHeight.Rows.Add(rwHeight)
            End Select

            'If RowType > 0 Then dtHeight.Rows.Add(rwHeight)
            Dim rect As XRect = New XRect(rectangleObject.XRect.X, GetTotalHeight(dtHeight, fc.ID), rectangleObject.XRect.Width, rectangleObject.XRect.Height)
            Dim pen As XPen = New XPen(rectangleObject.XColor.GetXColorProperty, rectangleObject.LineHeight)
            gfx.DrawRectangle(pen, rect)
        ElseIf fc.ObjectType = "ImageFromFile" Then
            Dim imageFromFileObject As Profile.ImageFromFileObject = fc.FCObject
            Dim ImageFolder As String = String.Format("{0}\Images", PDFOutput.ClientProfilePath)
            Dim file As String = String.Format("{0}\{1}", ImageFolder, rw(fc.RefID).ToString.Trim)
            If Not System.IO.Directory.Exists(ImageFolder) Then System.IO.Directory.CreateDirectory(ImageFolder)
            If System.IO.File.Exists(file) Then
                Dim xImage As XImage = XImage.FromFile(file)
                Dim rect As XRect = New XRect(imageFromFileObject.XRect.X, imageFromFileObject.XRect.Y, imageFromFileObject.XRect.Width, imageFromFileObject.XRect.Height)
                gfx.DrawImage(xImage, rect)
            Else
                sbLog.AppendLine("GeneratePDF(): '" & file & "' does not exist")
            End If
        ElseIf fc.ObjectType = "Barcode" Then
            Dim barcodeObject As Profile.BarcodeObject = fc.FCObject
            'Dim BarcodeFolder As String = String.Format("{0}\Barcodes", PDFOutput.ClientProfilePath)
            BarcodeRepository = String.Format("{0}\Barcodes", PDFOutput.ClientProfilePath)
            If Not System.IO.Directory.Exists(BarcodeRepository) Then System.IO.Directory.CreateDirectory(BarcodeRepository)
            Dim file As String = String.Format("{0}\{1}", BarcodeRepository, String.Format("{0}.{1}", rw(fc.RefID).ToString.Trim, barcodeObject.ImageFormat))

            Select Case barcodeObject.BarcodeSymbology
                Case "QRCode"
                    file = String.Format("{0}\{1}", BarcodeRepository, String.Format("{0}qr.{1}", rw(fc.RefID).ToString.Trim, barcodeObject.ImageFormat))
                    Dim qrCode As New QRGenerator
                    If qrCode.RenderQrCode(rw(fc.RefID).ToString.Trim, "M", file) Then

                    End If
                Case Else
                    Dim _barcode As New Neodynamic.WinControls.BarcodeProfessional.BarcodeProfessional
                    '_barcode.AddChecksum = False
                    _barcode.Symbology = barcodeObject.GetSymbology
                    _barcode.Code = rw(fc.RefID).ToString.Trim
                    '_barcode.Code = "02201002220782100001"

                    _barcode.BarHeight = 0.6!
                    _barcode.BarWidth = 0.01114!
                    _barcode.BearerBarWidth = -0.05!
                    _barcode.BorderStyle = System.Windows.Forms.Border3DStyle.Flat

                    If barcodeObject.DisplayCode = 0 Then _barcode.DisplayCode = False Else _barcode.DisplayCode = True

                    Dim fileTemp As String = "tempBarcode.bmp"
                    Dim fileTemp2 As String = "tempBarcode2.bmp"

                    'Dim fileTemp3 As String = "tempBarcode3.jpg"
                    '_barcode.Save(fileTemp3, System.Drawing.Imaging.ImageFormat.Jpeg, 600, 300)

                    Dim CropRect As New System.Drawing.Rectangle(0, 10, _barcode.Image.Width, _barcode.Image.Height)
                    Dim CropImage = New System.Drawing.Bitmap(CropRect.Width, CropRect.Height)

                    Using grp = System.Drawing.Graphics.FromImage(CropImage)
                        grp.DrawImage(_barcode.Image, New System.Drawing.Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, System.Drawing.GraphicsUnit.Pixel)
                        CropImage.Save(fileTemp)
                    End Using

                    CropImage.Dispose()

                    Dim bmpTemp As System.Drawing.Bitmap = System.Drawing.Image.FromFile(fileTemp)
                    Dim CropRect2 As New System.Drawing.Rectangle(barcodeObject.Crop.X, barcodeObject.Crop.Y, barcodeObject.Crop.Width, barcodeObject.Crop.Height)
                    Dim CropImage2 = New System.Drawing.Bitmap(CropRect2.Width, CropRect2.Height)

                    Using grp = System.Drawing.Graphics.FromImage(CropImage2)
                        grp.DrawImage(bmpTemp, New System.Drawing.Rectangle(0, 0, CropRect2.Width, CropRect2.Height), CropRect2, System.Drawing.GraphicsUnit.Pixel)
                        CropImage2.Save(fileTemp2)
                    End Using

                    bmpTemp.Dispose()
                    CropImage2.Dispose()

                    If System.IO.File.Exists(file) Then System.IO.File.Delete(file)
                    System.IO.File.Copy(fileTemp2, file)
            End Select


            ''_barcode.Save(file, barcodeObject.GetImageFormat)
            If System.IO.File.Exists(file) Then
                Dim xImage As XImage = XImage.FromFile(file)
                Dim rect As XRect = New XRect(barcodeObject.XRect.X, barcodeObject.XRect.Y, barcodeObject.XRect.Width, barcodeObject.XRect.Height)
                Dim _width As Double = barcodeObject.XRect.Width
                Dim _height As Double = barcodeObject.XRect.Height
                If _width = 0 Then _width = xImage.PointWidth
                If _height = 0 Then _height = xImage.PointHeight
                gfx.DrawImage(xImage, barcodeObject.XRect.X, barcodeObject.XRect.Y, _width, _height)

                'DrawImageRotated(gfx, xImage)

                xImage.Dispose()
                xImage = Nothing
            Else
                sbLog.AppendLine("GeneratePDF(): '" & file & "' does not exist")
            End If
        End If
    End Sub

    Private Function GetTotalHeight(ByVal dtHeight As DataTable, ByVal ID As String) As Double
        Dim intHeight As Double = 0
        For Each rw As DataRow In dtHeight.Select("ID='" & ID & "'")
            intHeight += rw("Height")
        Next

        Return intHeight
    End Function

    Private Function GetFieldCollection(ByVal PDFOutput As ParserDLL.ParserDLL.PDFOutput, ByVal ID As String) As Profile.FieldCollection
        Return PDFOutput.PDFOutputFieldElements.OfType(Of Profile.FieldCollection)().Where(Function(element) element.ID.Contains(ID))(0)
    End Function

    Private Function GetFieldValue(ByVal _fieldCollection As PDF.Profile.PageHeaderFieldCollection, ByVal rw As DataRow, ByVal fileName As String) As String
        'Dim _fieldCollection = GetObjectByID(phfc, ID)

        Try
            If _fieldCollection.DefaultValue = "" Then
                If rw.Table.Columns.Contains(_fieldCollection.RefID) Then
                    Return rw(_fieldCollection.RefID).ToString
                Else
                    Return ""
                End If
            ElseIf _fieldCollection.DefaultValue = "Now()" And _fieldCollection.DataType = "DateTime" Then
                Return Now.ToString(_fieldCollection.StringFormat)
            ElseIf _fieldCollection.DefaultValue.Contains("Count") Then
                Return rw(2)
            ElseIf _fieldCollection.DefaultValue.Contains("Sum") Then
                Return rw(2)
            ElseIf _fieldCollection.DefaultValue = "FileName()" Then
                'If _fieldCollection.FilePathType = "1" Then
                '    Return System.IO.Path.GetFileName(fileName)
                'ElseIf _fieldCollection.FilePathType = "2" Then
                '    Return System.IO.Path.GetFileNameWithoutExtension(fileName)
                'End If
                'ElseIf _fieldElementOutput.DefaultValue <> "" And _fieldElementOutput.DefaultValue.Contains(openTagField) Then
                '    Return GetDefaultValueWithCombination(output, _fieldElementOutput.DefaultValue, rw, fileName)
            ElseIf _fieldCollection.DefaultValue <> "" Then
                Return _fieldCollection.DefaultValue
            End If
        Catch ex As Exception
            If rw.Table.Columns.Contains(_fieldCollection.RefID) Then
                Return rw(_fieldCollection.RefID).ToString
            End If
        End Try
    End Function

    Private Function GetObjectByID(ByVal objects() As Object, ByVal ID As String) As Object
        Return objects.OfType(Of Object)().Where(Function(element) element.ID.Contains(ID))(0)
    End Function

    Public Sub DrawHeader(ByVal document As PdfDocument, ByVal page As PdfPage, ByVal gfx As XGraphics, ByVal title As String)
        'Header
        Dim rect As XRect = New XRect(New XPoint(), gfx.PageSize)
        rect.Inflate(-10, -15)
        Dim font As XFont = New XFont("Verdana", 14, XFontStyle.Bold)
        gfx.DrawString(title, font, XBrushes.MidnightBlue, rect, XStringFormats.TopCenter)
        rect.Inflate(-20, -30)
        gfx.DrawString(title, font, XBrushes.MidnightBlue, rect, XStringFormats.TopCenter)
    End Sub

    Public Sub DrawFooter(ByVal document As PdfDocument, ByVal page As PdfPage, ByVal gfx As XGraphics, ByVal intTotalPage As Integer, ByVal PagingStyle As Short)
        'page
        Dim rect As XRect = New XRect(New XPoint(), gfx.PageSize)
        Dim format As XStringFormat = New XStringFormat()
        format.Alignment = XStringAlignment.Near
        format.LineAlignment = XLineAlignment.Far
        rect.Offset(0, 5) 'if with header
        rect.Offset(0, -15)
        Dim font As XFont = New XFont("Verdana", 5, XFontStyle.Regular)
        format.Alignment = XStringAlignment.Center
        If PagingStyle = 1 Then
            gfx.DrawString(String.Format("{0}", document.PageCount.ToString("N0")), font, XBrushes.Black, rect, format)
        ElseIf PagingStyle = 2 Then
            gfx.DrawString(String.Format("{0} / {1}", document.PageCount.ToString("N0"), intTotalPage.ToString("N0")), font, XBrushes.Black, rect, format)
        End If
    End Sub

    Public Sub MergeFiles(ByVal files() As String, ByVal outputFile As String)
        Dim outputDocument As PdfDocument = New PdfDocument()

        For Each file As String In files

            Dim inputDocument As PdfDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import)
            Dim count As Integer = inputDocument.PageCount

            For idx As Integer = 0 To count - 1
                Dim page As PdfPage = inputDocument.Pages(idx)
                outputDocument.AddPage(page)
            Next
        Next

        'Const filename As String = "ConcatenatedDocument1_tempfile.pdf"
        Try
            outputDocument.Save(outputFile)

            For Each file As String In files
                System.IO.File.Delete(file)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Housekeeping()
        If System.IO.Directory.Exists(BarcodeRepository) Then System.IO.Directory.Delete(BarcodeRepository, True)
    End Sub

    Public Sub Sample()
        ' Create a new PDF document
        Dim document As PdfDocument = New PdfDocument
        document.Info.Title = "Created with PDFsharp"

        ' Create an empty page
        Dim page As PdfPage = document.AddPage

        ' Get an XGraphics object for drawing
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)

        ' Draw crossing lines
        Dim pen As XPen = New XPen(XColor.FromArgb(255, 0, 0))

        gfx.DrawLine(pen, New XPoint(0, 0), New XPoint(page.Width.Point, page.Height.Point))
        gfx.DrawLine(pen, New XPoint(page.Width.Point, 0), New XPoint(0, page.Height.Point))

        'gfx.DrawImage(image, (dx - width) / 2, 0, width, height);


        '' Draw an ellipse
        'gfx.DrawEllipse(pen, 3 * page.Width.Point / 10, 3 * page.Height.Point / 10, 2 * page.Width.Point / 5, 2 * page.Height.Point / 5)

        '' Create a font
        'Dim font As XFont = New XFont("Verdana", 20, XFontStyle.Bold)

        '' Draw the text
        'gfx.DrawString("Hello, World!", font, XBrushes.Black, New XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center)

        ' Save the document...

        Dim filename As String = "F:\HelloWorld.pdf"
        document.Save(filename)

        ' ...and start a viewer.
        Process.Start(filename)
    End Sub

    Public Sub DrawTitle(ByVal document As PdfDocument, ByVal page As PdfPage, ByVal gfx As XGraphics, ByVal title As String)
        'Header
        Dim rect As XRect = New XRect(New XPoint(), gfx.PageSize)
        rect.Inflate(-10, -15)
        Dim font As XFont = New XFont("Verdana", 14, XFontStyle.Bold)
        gfx.DrawString(title, font, XBrushes.MidnightBlue, rect, XStringFormats.TopCenter)
        rect.Inflate(-20, -30)
        gfx.DrawString(title, font, XBrushes.MidnightBlue, rect, XStringFormats.TopCenter)

        'footer
        rect.Offset(0, 5)
        font = New XFont("Verdana", 8, XFontStyle.Italic)
        Dim format As XStringFormat = New XStringFormat()
        format.Alignment = XStringAlignment.Near
        format.LineAlignment = XLineAlignment.Far
        gfx.DrawString("Created with " & PdfSharp.ProductVersionInfo.Producer, font, XBrushes.DarkOrchid, rect, format)

        'page
        font = New XFont("Verdana", 8)
        format.Alignment = XStringAlignment.Center
        gfx.DrawString(document.PageCount.ToString(), font, XBrushes.DarkOrchid, rect, format)
        'document.Outlines.Add(title, page, True)
    End Sub

    '    Public Class Length
    '{
    '    Private Const Double MillimetersPerInch = 25.4;
    '    Private Double _Millimeters;

    '    Public Static Length FromMillimeters(Double mm)
    '    {
    '         Return New Length { _Millimeters = mm };
    '    }

    '    Public Static Length FromInch(Double inch)
    '    {
    '         Return New Length { _Millimeters = inch * MillimetersPerInch };
    '    }

    '    Public Double Inch { Get { Return _Millimeters / MillimetersPerInch; } } 
    '    Public Double Millimeters { Get { Return _Millimeters; } }
    '}

    Public Sub BeginBox(ByVal gfx As XGraphics, ByVal number As Integer, ByVal title As String)
        'Const dEllipse As Integer = 15
        'Dim rect As XRect = New XRect(0, 20, 300, 200)
        'If number Mod 2 = 0 Then rect.X = 300 - 5
        'rect.Y = 40 + ((number - 1) / 2) * (200 - 5)
        'rect.Inflate(-10, -10)
        'Dim rect2 As XRect = rect
        'rect2.Offset(gfx.PageSize.Width, gfx.PageSize.Width) 'Me.borderWidth, Me.borderWidth)
        'gfx.DrawRoundedRectangle(New XSolidBrush(), rect2, New XSize(dEllipse + 8, dEllipse + 8))
        'Dim brush As XLinearGradientBrush = New XLinearGradientBrush(rect, XColor.FromName("Black"), XColor.FromName("Black"), XLinearGradientMode.Vertical)
        'gfx.DrawRoundedRectangle(Me.borderPen, brush, rect, New XSize(dEllipse, dEllipse))
        'rect.Inflate(-5, -5)
        'Dim font As XFont = New XFont("Verdana", 12, XFontStyle.Regular)
        'gfx.DrawString(title, font, XBrushes.Navy, rect, XStringFormats.TopCenter)
        'rect.Inflate(-10, -5)
        'rect.Y += 20
        'rect.Height -= 20
        ''Me.state = gfx.Save()
        'gfx.Save()
        'gfx.TranslateTransform(rect.X, rect.Y)
    End Sub

    Public Sub EndBox(ByVal gfx As XGraphics)
        gfx.Restore()
    End Sub

    Public Sub DrawImageRotated(ByVal gfx As XGraphics, ByVal image As XImage)
        Const dx As Double = 250, dy = 140
        gfx.TranslateTransform(dx / 2, dy / 2)
        gfx.ScaleTransform(0.7)
        gfx.RotateTransform(-90)
        gfx.TranslateTransform(-dx / 2, -dy / 2)
        Dim Width As Double = image.PixelWidth * 72 / image.HorizontalResolution
        Dim Height As Double = image.PixelHeight * 72 / image.HorizontalResolution
        gfx.DrawImage(image, (dx - Width) / 2, 0, Width, Height)
    End Sub

End Class
