
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Text.UTF8Encoding

Public Class PrintHelper

    Public WithEvents printDoc As New PrintDocument
    Private _pageDatas() As PageData
    Private intPageDataIndex As Integer = 0
    Private intDocumentElementIndex As Integer = 0

    Public Sub Print(ByVal _pageDatas() As PageData)
        Me._pageDatas = _pageDatas

        Using (printDoc)
            printDoc.PrinterSettings.PrinterName = "Microsoft XPS Document Writer"
            AddHandler printDoc.PrintPage,
             AddressOf Me.PrintPageHandler

            'If ifLoan = True Then
            'Dim ppsize As New PaperSize("Report Size", 430, 430)
            'printDoc.DefaultPageSettings.PaperSize = ppsize
            'Else
            '    Dim ppsize As New PaperSize("Report Size", 430, 375)
            '    printDoc.DefaultPageSettings.PaperSize = ppsize
            'End If

            'Dim marginRight, marginLeft, marginTop, marginBottom
            'printDoc.OriginAtMargins = True
            'printDoc.DefaultPageSettings.Margins.Left = 0
            'printDoc.DefaultPageSettings.Margins.Top = 0

            'printDoc.ToString()

            'printDoc.DocumentName = tRep & " " & ssnum & " " & dteGet

            'If False Then
            '    printDoc.Print()
            'Else54
            printDoc.PrinterSettings.PrinterName = "Microsoft XPS Document Writer"
            Dim ppDlg As New System.Windows.Forms.PrintPreviewDialog
            ppDlg.Document = printDoc
            ppDlg.Show()
            'End If
        End Using
    End Sub

    Private Sub PrintPageHandler(ByVal sender As Object, ByVal args As PrintPageEventArgs)
        For Each documentElement As DocumentElement In _pageDatas(intPageDataIndex).DocumentElements
            args.Graphics.DrawString(documentElement.Value, documentElement.Font, documentElement.Brush, documentElement.Location)
        Next

        If intPageDataIndex = _pageDatas.Length - 1 Then
            args.HasMorePages = False
        Else
            intPageDataIndex += 1
            args.HasMorePages = True
        End If

        Dim i As New PrintDocument



        'args.Graphics.DrawString(sample1, New Font(bodyFont, FontStyle.Regular), Brushes.Black, New RectangleF(15, 190, 420, 300))
        'args.Graphics.DrawString(String.Format("**TRANSACTION REFERENCE NO: {0}-{1}-{2}**", Now.ToString("yyyyMMdd"), SharedFunction.SOLUTION_CONFIG.KioskStationID, TxnRef.PadLeft(6, "0")), New Font(bodyFont, FontStyle.Regular), Brushes.Black, New RectangleF(15, 350, 420, 300))
    End Sub

    Public Sub printImage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles printDoc.PrintPage
        'Dim pcBox As New PictureBox
        'Dim newMargins As System.Drawing.Printing.Margins
        'pcBox.Image = System.Drawing.Bitmap.FromFile(String.Format("{0}\{1}", SharedFunction.IMAGES_FOLDER, "afpslai logo.png"))
        'pcBox.Size = New Size(70, 70)
        'newMargins = New System.Drawing.Printing.Margins(93, 200, 0, 0)
        ''newMargins = New System.Drawing.Printing.Margins(200, 200, 0, 0)

        'printDoc.DefaultPageSettings.Margins = newMargins

        'e.Graphics.DrawImage(pcBox.Image, 10, 10)
    End Sub

    'Return sb.ToString.Replace("�", ChrW(209))

    Public Class PageData

        Private _documentElements() As DocumentElement

        Public Property DocumentElements As DocumentElement()
            Get
                Return _documentElements
            End Get
            Set(value As DocumentElement())
                _documentElements = value
            End Set
        End Property

    End Class

    Public Class DocumentElement

        Private _font As Font = New Font("Arial", 10)
        Private _value As String = ""
        Private _brush As Brush = Brushes.Black
        Private _location As Point

        Public Property Value As String
            Get
                Return _value
            End Get
            Set(value As String)
                _value = value
            End Set
        End Property

        Public Property Font As Font
            Get
                Return _font
            End Get
            Set(value As Font)
                _font = value
            End Set
        End Property

        Public Property Brush As Brush
            Get
                Return _brush
            End Get
            Set(value As Brush)
                _brush = value
            End Set
        End Property

        Public Property Location As Point
            Get
                Return _location
            End Get
            Set(value As Point)
                _location = value
            End Set
        End Property
    End Class



End Class
