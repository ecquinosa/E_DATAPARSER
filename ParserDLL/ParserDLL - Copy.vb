
Imports System.Xml
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Public Class ParserDLL2

    '    Private _clientConfig As ClientConfig = Nothing
    '    Private _dtInputData As DataTable = Nothing
    '    Private _dtOutputData() As DataTable = Nothing
    '    Private CurrentStatus As String = ""

    '    Private openTagField As String = "{{"
    '    Private closeTagField As String = "}}"

    '    Private openTagFunction As String = "<<"
    '    Private closeTagFunction As String = ">>"

    '    Private _inputFile As String = ""
    '    Private _OutputFile As String = ""

    '    Private inputTotalRecords As Integer = 0
    '    Private inputSuccessCnt As Integer = 0
    '    Private inputFailedCnt As Integer = 0

    '    Private sbLog As New System.Text.StringBuilder

    '    Public Property INPUT_FILE As String
    '        Get
    '            Return _inputFile
    '        End Get
    '        Set(value As String)
    '            _inputFile = value
    '        End Set
    '    End Property

    '    Public Property OUTPUT_FOLDER As String
    '        Get
    '            Return _OutputFile
    '        End Get
    '        Set(value As String)
    '            _OutputFile = value
    '        End Set
    '    End Property

    '    Public ReadOnly Property ProcessLog As String
    '        Get
    '            Return sbLog.ToString
    '        End Get
    '    End Property

    '    Public ReadOnly Property InputParsedData As DataTable
    '        Get
    '            Return _dtInputData
    '        End Get
    '    End Property

    '    Public ReadOnly Property OutputParsedData As DataTable()
    '        Get
    '            Return _dtOutputData
    '        End Get
    '    End Property

    '    Public ReadOnly Property LoadedClientConfig As ClientConfig
    '        Get
    '            Return _clientConfig
    '        End Get
    '    End Property

    '    Public Enum ParserType
    '        FixLen = 1
    '        Delimited = 2
    '    End Enum

    '    Public Enum Xml_ElementName
    '        ClientProfile = 1
    '        Input
    '        Output
    '        DLL
    '        ParserType
    '        Delimiter
    '        Column
    '        ID
    '        IDLabel
    '        StartPosition
    '        DataLength
    '        IndexPosition
    '        PaddedChar
    '        DefaultValue
    '        DataType
    '        StringFormat
    '        IsPutHeader
    '        IsUseHeader
    '        FileExtension
    '        OutputFileName
    '        FilterExpression
    '        SortExpression
    '        IsWithHeader
    '        FilePath
    '        RunNativeGenerateOutput
    '        Exclusion
    '        Expression
    '        Value
    '        Condition
    '        Grouping
    '        Trim
    '        SheetName
    '        ExclColumnQuery
    '        ExclWhereQuery
    '        SheetColumnName
    '        FilePathType
    '        PDFOutput
    '        ObjectType
    '        RecordPerPage
    '        XFontName
    '        XFontSize
    '        XFontStyle
    '        XRectX
    '        XRectY
    '        XRectWidth
    '        XRectHeight
    '        XStringFormat
    '        XBrush
    '        XParagraphAlignment
    '        IsDrawRect
    '        Concatenate
    '        SubStr
    '        RefID
    '        XColorProperty
    '        XColorParameter
    '        LineHeight
    '        X
    '        Y
    '        Width
    '        Height
    '        DIType
    '        ImageFromFile
    '        BarcodeSymbology
    '        ImageFormat
    '        BarcodeDisplayCode
    '        PagingStyle
    '        PageHeader
    '        PageFooter
    '        CropX
    '        CropY
    '        CropWidth
    '        CropHeight
    '        Replace
    '        OldValue
    '        NewValue
    '        PageOrientation
    '        IsDisplay
    '        FirstPageOnly
    '        RowHeader
    '        RowFooter
    '        IsMergePDF
    '        PageSize
    '        Split
    '    End Enum

    '    Public Enum FilterExpression
    '        EqualsTo = 1
    '        NotEqualsTo
    '        Contains
    '        NotContains
    '        LessThanAndEqualsTo
    '        GreaterThanAndEqualsTo
    '    End Enum

    '    Class ClientConfig

    '        Private _dll As DLL = Nothing
    '        Private _input As Input = Nothing
    '        Private _outputs() As Output = Nothing
    '        Private _inputfieldElements() As FieldElement = Nothing
    '        'Private _outputfieldElements() As OutputFieldElement
    '        Private _concatenates() As Concatenate = Nothing
    '        Private _replaces() As Replace = Nothing
    '        Private _exclusion() As Exclusion = Nothing

    '        Private _pdfOutputs() As PDFOutput = Nothing

    '        Public Property CDLL As DLL
    '            Get
    '                Return _dll
    '            End Get
    '            Set(value As DLL)
    '                _dll = value
    '            End Set
    '        End Property

    '        Public Property Input As Input
    '            Get
    '                Return _input
    '            End Get
    '            Set(value As Input)
    '                _input = value
    '            End Set
    '        End Property

    '        Public Property Outputs As Output()
    '            Get
    '                Return _outputs
    '            End Get
    '            Set(value As Output())
    '                _outputs = value
    '            End Set
    '        End Property

    '        Public Property PDFOutputs As PDFOutput()
    '            Get
    '                Return _pdfOutputs
    '            End Get
    '            Set(value As PDFOutput())
    '                _pdfOutputs = value
    '            End Set
    '        End Property

    '        Public Property Concatenates As Concatenate()
    '            Get
    '                Return _concatenates
    '            End Get
    '            Set(value As Concatenate())
    '                _concatenates = value
    '            End Set
    '        End Property

    '        Public Property Replaces As Replace()
    '            Get
    '                Return _replaces
    '            End Get
    '            Set(value As Replace())
    '                _replaces = value
    '            End Set
    '        End Property

    '        Public Property Exclusions As Exclusion()
    '            Get
    '                Return _exclusion
    '            End Get
    '            Set(value As Exclusion())
    '                _exclusion = value
    '            End Set
    '        End Property

    '        Public Property InputFieldElements As FieldElement()
    '            Get
    '                Return _inputfieldElements
    '            End Get
    '            Set(value As FieldElement())
    '                _inputfieldElements = value
    '            End Set
    '        End Property

    '        'Public Property OutputFieldElements As OutputFieldElement()
    '        '    Get
    '        '        Return _OutputFieldElements
    '        '    End Get
    '        '    Set(value As OutputFieldElement())
    '        '        _OutputFieldElements = value
    '        '    End Set
    '        'End Property

    '    End Class

    '    Class DLL

    '        Private _filePath As String = ""
    '        Private _IsRunNativeGenerateOutput As Boolean

    '        Public Property FilePath As String
    '            Get
    '                Return _filePath
    '            End Get
    '            Set(value As String)
    '                _filePath = value
    '            End Set
    '        End Property

    '        Public Property RunNativeGenerateOutput As Boolean
    '            Get
    '                Return _IsRunNativeGenerateOutput
    '            End Get
    '            Set(value As Boolean)
    '                _IsRunNativeGenerateOutput = value
    '            End Set
    '        End Property

    '    End Class

    '    Class Input

    '        Private _IsWithHeader As Boolean
    '        Private _parserType As ParserType
    '        Private _delimiter As String = ""

    '        Private _fileExtension As String = ""
    '        Private _sheetName As String = ""
    '        Private _colQuery As String = ""
    '        Private _whereQuery As String = ""

    '        Public Property ParserType As ParserType
    '            Get
    '                Return _parserType
    '            End Get
    '            Set(value As ParserType)
    '                _parserType = value
    '            End Set
    '        End Property

    '        Public Property Delimiter As String
    '            Get
    '                Return _delimiter
    '            End Get
    '            Set(value As String)
    '                _delimiter = value
    '            End Set
    '        End Property

    '        Public Property IsWithHeader As Boolean
    '            Get
    '                Return _IsWithHeader
    '            End Get
    '            Set(value As Boolean)
    '                _IsWithHeader = value
    '            End Set
    '        End Property

    '        Public Property FileExtension As String
    '            Get
    '                Return _fileExtension
    '            End Get
    '            Set(value As String)
    '                _fileExtension = value
    '            End Set
    '        End Property

    '        Public Property SheetName As String
    '            Get
    '                Return _sheetName
    '            End Get
    '            Set(value As String)
    '                _sheetName = value
    '            End Set
    '        End Property

    '        Public Property ExclColumnQuery As String
    '            Get
    '                Return _colQuery
    '            End Get
    '            Set(value As String)
    '                _colQuery = value
    '            End Set
    '        End Property

    '        Public Property ExclWhereQuery As String
    '            Get
    '                Return _whereQuery
    '            End Get
    '            Set(value As String)
    '                _whereQuery = value
    '            End Set
    '        End Property

    '    End Class

    '    Class Output
    '        Inherits Input

    '        Private _fileAttr As FileAttr = Nothing
    '        Private _grouping As Grouping = Nothing
    '        'Private _exclusion As Exclusion = Nothing
    '        Private _outputfieldElements() As OutputFieldElement
    '        Private _pdfOutput As String = ""
    '        Private _exclusion As String = ""

    '        Public Property FileAttr As FileAttr
    '            Get
    '                Return _fileAttr
    '            End Get
    '            Set(value As FileAttr)
    '                _fileAttr = value
    '            End Set
    '        End Property

    '        Public Property Grouping As Grouping
    '            Get
    '                Return _grouping
    '            End Get
    '            Set(value As Grouping)
    '                _grouping = value
    '            End Set
    '        End Property

    '        Public Property Exclusion As String
    '            Get
    '                Return _exclusion
    '            End Get
    '            Set(value As String)
    '                _exclusion = value
    '            End Set
    '        End Property

    '        Public Property PDFOutput As String
    '            Get
    '                Return _pdfOutput
    '            End Get
    '            Set(value As String)
    '                _pdfOutput = value
    '            End Set
    '        End Property

    '        Public Property OutputFieldElements As OutputFieldElement()
    '            Get
    '                Return _outputfieldElements
    '            End Get
    '            Set(value As OutputFieldElement())
    '                _outputfieldElements = value
    '            End Set
    '        End Property

    '    End Class

    '    Class FieldElement

    '        Private _id As String = ""
    '        Private _startPosition As Integer = 0
    '        Private _dataLength As Integer = 0
    '        Private _indexPosition As Integer = 0

    '        Private _defaultValue As String = ""
    '        Private _isUseHeader As Short = 0

    '        Private _sheetColumnName As String = ""
    '        Private _filePathType As String = ""

    '        Private _concatenate As String = ""
    '        Private _replace As String = ""

    '        Public Property ID As String
    '            Get
    '                Return _id
    '            End Get
    '            Set(value As String)
    '                _id = value
    '            End Set
    '        End Property

    '        Public Property StartPosition As Integer
    '            Get
    '                Return _startPosition
    '            End Get
    '            Set(value As Integer)
    '                _startPosition = value
    '            End Set
    '        End Property

    '        Public Property DataLength As Integer
    '            Get
    '                Return _dataLength
    '            End Get
    '            Set(value As Integer)
    '                _dataLength = value
    '            End Set
    '        End Property

    '        Public Property IndexPosition As Integer
    '            Get
    '                Return _indexPosition
    '            End Get
    '            Set(value As Integer)
    '                _indexPosition = value
    '            End Set
    '        End Property

    '        Public Property DefaultValue As String
    '            Get
    '                Return _defaultValue
    '            End Get
    '            Set(value As String)
    '                _defaultValue = value
    '            End Set
    '        End Property

    '        Public Property SheetColumnName As String
    '            Get
    '                Return _sheetColumnName
    '            End Get
    '            Set(value As String)
    '                _sheetColumnName = value
    '            End Set
    '        End Property

    '        Public Property FilePathType As String
    '            Get
    '                Return _filePathType
    '            End Get
    '            Set(value As String)
    '                _filePathType = value
    '            End Set
    '        End Property

    '        Public Property IsUseHeader As Short
    '            Get
    '                Return _isUseHeader
    '            End Get
    '            Set(value As Short)
    '                _isUseHeader = value
    '            End Set
    '        End Property

    '        Public Property Concatenate As String
    '            Get
    '                Return _concatenate
    '            End Get
    '            Set(value As String)
    '                _concatenate = value
    '            End Set
    '        End Property

    '        Public Property Replace As String
    '            Get
    '                Return _replace
    '            End Get
    '            Set(value As String)
    '                _replace = value
    '            End Set
    '        End Property

    '    End Class

    '    Class OutputFieldElement
    '        Inherits FieldElement

    '        Private _padChar As String = ""
    '        Private _dataType As String = ""
    '        Private _stringFormat As String = ""
    '        Private _idLabel As String = ""
    '        Private _isPutHeader As Short = 0
    '        'Private _exclusion As String = ""
    '        Private _isDisplay As Short = 1

    '        Public Property IDLabel As String
    '            Get
    '                Return _idLabel
    '            End Get
    '            Set(value As String)
    '                _idLabel = value
    '            End Set
    '        End Property

    '        Public Property DataType As String
    '            Get
    '                Return _dataType
    '            End Get
    '            Set(value As String)
    '                _dataType = value
    '            End Set
    '        End Property

    '        Public Property StringFormat As String
    '            Get
    '                Return _stringFormat
    '            End Get
    '            Set(value As String)
    '                _stringFormat = value
    '            End Set
    '        End Property

    '        Public Property PaddedChar As String
    '            Get
    '                Return _padChar
    '            End Get
    '            Set(value As String)
    '                _padChar = value
    '            End Set
    '        End Property

    '        Public Property IsPutHeader As Short
    '            Get
    '                Return _isPutHeader
    '            End Get
    '            Set(value As Short)
    '                _isPutHeader = value
    '            End Set
    '        End Property

    '        Public Property IsDisplay As Short
    '            Get
    '                Return _isDisplay
    '            End Get
    '            Set(value As Short)
    '                _isDisplay = value
    '            End Set
    '        End Property

    '        'Public Property Exclusion As String
    '        '    Get
    '        '        Return _exclusion
    '        '    End Get
    '        '    Set(value As String)
    '        '        _exclusion = value
    '        '    End Set
    '        'End Property

    '    End Class

    '    Class FileAttr

    '        Private _fileExt As String = ""
    '        Private _fileOutputName As String = ""

    '        Public Property FileExtension As String
    '            Get
    '                Return _fileExt
    '            End Get
    '            Set(value As String)
    '                _fileExt = value
    '            End Set
    '        End Property

    '        Public Property FileOutputName As String
    '            Get
    '                Return _fileOutputName
    '            End Get
    '            Set(value As String)
    '                _fileOutputName = value
    '            End Set
    '        End Property

    '    End Class

    '    Class Grouping

    '        Private _groupConditions() As GroupingCondition = Nothing

    '        Public Property GroupingConditions As GroupingCondition()
    '            Get
    '                Return _groupConditions
    '            End Get
    '            Set(value As GroupingCondition())
    '                _groupConditions = value
    '            End Set
    '        End Property

    '    End Class

    '    Public Class GroupingCondition

    '        Private _fileAttr As FileAttr = Nothing
    '        Private _filterExpression As String = ""
    '        Private _sortExpression As String = ""

    '        Public Property FilterExpression As String
    '            Get
    '                Return _filterExpression
    '            End Get
    '            Set(value As String)
    '                _filterExpression = value
    '            End Set
    '        End Property

    '        Public Property SortExpression As String
    '            Get
    '                Return _sortExpression
    '            End Get
    '            Set(value As String)
    '                _sortExpression = value
    '            End Set
    '        End Property

    '        Public Property FileAttr As FileAttr
    '            Get
    '                Return _fileAttr
    '            End Get
    '            Set(value As FileAttr)
    '                _fileAttr = value
    '            End Set
    '        End Property

    '    End Class

    '    Public Class Exclusion

    '        Private _id As String = ""
    '        Private _fieldElements() As ExclusionFieldElement = Nothing

    '        Public Property ID As String
    '            Get
    '                Return _id
    '            End Get
    '            Set(value As String)
    '                _id = value
    '            End Set
    '        End Property

    '        Public Property FieldElements As ExclusionFieldElement()
    '            Get
    '                Return _fieldElements
    '            End Get
    '            Set(value As ExclusionFieldElement())
    '                _fieldElements = value
    '            End Set
    '        End Property

    '    End Class

    '    'Public Class ExclusionCondition

    '    '    Private _id As String = ""
    '    '    Private _expression As String = ""
    '    '    Private _value As String = ""
    '    '    Private _IsTrim As Boolean = False

    '    '    Public Property ID As String
    '    '        Get
    '    '            Return _id
    '    '        End Get
    '    '        Set(value As String)
    '    '            _id = value
    '    '        End Set
    '    '    End Property

    '    '    Public Property Expression As String
    '    '        Get
    '    '            Return _expression
    '    '        End Get
    '    '        Set(value As String)
    '    '            _expression = value
    '    '        End Set
    '    '    End Property

    '    '    Public Property Value As String
    '    '        Get
    '    '            Return _value
    '    '        End Get
    '    '        Set(value As String)
    '    '            _value = value
    '    '        End Set
    '    '    End Property

    '    '    Public Property Trim As Boolean
    '    '        Get
    '    '            Return _IsTrim
    '    '        End Get
    '    '        Set(value As Boolean)
    '    '            _IsTrim = value
    '    '        End Set
    '    '    End Property

    '    'End Class

    '    Public Class Replace

    '        Private _id As String = ""
    '        Private _fieldElements() As ReplaceFieldElement = Nothing

    '        Public Property ID As String
    '            Get
    '                Return _id
    '            End Get
    '            Set(value As String)
    '                _id = value
    '            End Set
    '        End Property

    '        Public Property FieldElements As ReplaceFieldElement()
    '            Get
    '                Return _fieldElements
    '            End Get
    '            Set(value As ReplaceFieldElement())
    '                _fieldElements = value
    '            End Set
    '        End Property

    '    End Class

    '    Public Class Concatenate

    '        Private _id As String = ""
    '        Private _fieldElements() As ConcatenateFieldElement = Nothing

    '        Public Property ID As String
    '            Get
    '                Return _id
    '            End Get
    '            Set(value As String)
    '                _id = value
    '            End Set
    '        End Property

    '        Public Property FieldElements As ConcatenateFieldElement()
    '            Get
    '                Return _fieldElements
    '            End Get
    '            Set(value As ConcatenateFieldElement())
    '                _fieldElements = value
    '            End Set
    '        End Property

    '    End Class

    '    Public Class Split

    '        Private _id As String = ""
    '        Private _defaultValue As String = ""
    '        Private _fieldElements() As SplitFieldElement = Nothing

    '        Public Property ID As String
    '            Get
    '                Return _id
    '            End Get
    '            Set(value As String)
    '                _id = value
    '            End Set
    '        End Property

    '        Public Property FieldElements As SplitFieldElement()
    '            Get
    '                Return _fieldElements
    '            End Get
    '            Set(value As SplitFieldElement())
    '                _fieldElements = value
    '            End Set
    '        End Property

    '        Public Property DefaultValue As String
    '            Get
    '                Return _defaultValue
    '            End Get
    '            Set(value As String)
    '                _defaultValue = value
    '            End Set
    '        End Property

    '    End Class

    '    Public Class ConcatenateFieldElement

    '        Private _id As String = ""
    '        Private _refID As String = ""
    '        Private _subStr As String = ""
    '        Private _defaultValue As String = ""

    '        Public Property ID As String
    '            Get
    '                Return _id
    '            End Get
    '            Set(value As String)
    '                _id = value
    '            End Set
    '        End Property

    '        Public Property RefID As String
    '            Get
    '                Return _refID
    '            End Get
    '            Set(value As String)
    '                _refID = value
    '            End Set
    '        End Property

    '        Public Property SubStr As String
    '            Get
    '                Return _subStr
    '            End Get
    '            Set(value As String)
    '                _subStr = value
    '            End Set
    '        End Property

    '        Public Property DefaultValue As String
    '            Get
    '                Return _defaultValue
    '            End Get
    '            Set(value As String)
    '                _defaultValue = value
    '            End Set
    '        End Property

    '    End Class

    '    Public Class ExclusionFieldElement

    '        Private _id As String = ""
    '        Private _refID As String = ""
    '        Private _value As String = ""
    '        Private _filterExpression As String = ""
    '        Private _dataType As String = ""

    '        Public Property ID As String
    '            Get
    '                Return _id
    '            End Get
    '            Set(value As String)
    '                _id = value
    '            End Set
    '        End Property

    '        Public Property RefID As String
    '            Get
    '                Return _refID
    '            End Get
    '            Set(value As String)
    '                _refID = value
    '            End Set
    '        End Property

    '        Public Property Value As String
    '            Get
    '                Return _value
    '            End Get
    '            Set(value As String)
    '                _value = value
    '            End Set
    '        End Property

    '        Public Property FilterExpression As String
    '            Get
    '                Return _filterExpression
    '            End Get
    '            Set(value As String)
    '                _filterExpression = value
    '            End Set
    '        End Property

    '        Public Property DataType As String
    '            Get
    '                Return _dataType
    '            End Get
    '            Set(value As String)
    '                _dataType = value
    '            End Set
    '        End Property

    '    End Class

    '    Public Class ReplaceFieldElement

    '        Private _id As String = ""
    '        Private _refID As String = ""
    '        Private _oldValue As String = ""
    '        Private _newValue As String = ""
    '        Private _defaultValue As String = ""

    '        Public Property ID As String
    '            Get
    '                Return _id
    '            End Get
    '            Set(value As String)
    '                _id = value
    '            End Set
    '        End Property

    '        Public Property RefID As String
    '            Get
    '                Return _refID
    '            End Get
    '            Set(value As String)
    '                _refID = value
    '            End Set
    '        End Property

    '        Public Property OldValue As String
    '            Get
    '                Return _oldValue
    '            End Get
    '            Set(value As String)
    '                _oldValue = value
    '            End Set
    '        End Property

    '        Public Property NewValue As String
    '            Get
    '                Return _newValue
    '            End Get
    '            Set(value As String)
    '                _newValue = value
    '            End Set
    '        End Property

    '        Public Property DefaultValue As String
    '            Get
    '                Return _defaultValue
    '            End Get
    '            Set(value As String)
    '                _defaultValue = value
    '            End Set
    '        End Property

    '    End Class

    '    Public Class SplitFieldElement

    '        Private _id As String = ""
    '        Private _refID As String = ""
    '        Private _delimiter As String = ""
    '        Private _indexPosition As Integer
    '        Private _defaultValue As String = ""

    '        Public Property ID As String
    '            Get
    '                Return _id
    '            End Get
    '            Set(value As String)
    '                _id = value
    '            End Set
    '        End Property

    '        Public Property RefID As String
    '            Get
    '                Return _refID
    '            End Get
    '            Set(value As String)
    '                _refID = value
    '            End Set
    '        End Property

    '        Public Property Delimiter As String
    '            Get
    '                Return _delimiter
    '            End Get
    '            Set(value As String)
    '                _delimiter = value
    '            End Set
    '        End Property

    '        Public Property IndexPosition As Integer
    '            Get
    '                Return _indexPosition
    '            End Get
    '            Set(value As Integer)
    '                _indexPosition = value
    '            End Set
    '        End Property

    '        Public Property DefaultValue As String
    '            Get
    '                Return _defaultValue
    '            End Get
    '            Set(value As String)
    '                _defaultValue = value
    '            End Set
    '        End Property

    '    End Class

    '    Class PDFOutput

    '        Private _id As String = ""
    '        Private _recordPerPage As Integer = 1
    '        Private _outputFileName As String = ""
    '        Private _clientProfilePath As String = ""
    '        Private _pdfOutputfieldElements() As EPDFSharp.PDF.Profile.FieldCollection
    '        Private _pageHeader As EPDFSharp.PDF.Profile.PageHeader
    '        Private _pageFooter As EPDFSharp.PDF.Profile.PageFooter
    '        Private _rowHeader As EPDFSharp.PDF.Profile.RowHeader
    '        Private _rowFooter As EPDFSharp.PDF.Profile.RowFooter
    '        Private _pageOrientation As String = ""
    '        Private _isMergePDF As Boolean = False
    '        Private _pageSize As Integer = 0

    '        Public Property ID As String
    '            Get
    '                Return _id
    '            End Get
    '            Set(value As String)
    '                _id = value
    '            End Set
    '        End Property

    '        Public Property ClientProfilePath As String
    '            Get
    '                Return _clientProfilePath
    '            End Get
    '            Set(value As String)
    '                _clientProfilePath = value
    '            End Set
    '        End Property

    '        Public Property RecordPerPage As Integer
    '            Get
    '                Return _recordPerPage
    '            End Get
    '            Set(value As Integer)
    '                _recordPerPage = value
    '            End Set
    '        End Property

    '        Public Property OutputFileName As String
    '            Get
    '                Return _outputFileName
    '            End Get
    '            Set(value As String)
    '                _outputFileName = value
    '            End Set
    '        End Property

    '        Public Property PDFOutputFieldElements As EPDFSharp.PDF.Profile.FieldCollection()
    '            Get
    '                Return _pdfOutputfieldElements
    '            End Get
    '            Set(value As EPDFSharp.PDF.Profile.FieldCollection())
    '                _pdfOutputfieldElements = value
    '            End Set
    '        End Property

    '        Public Property PageHeader As EPDFSharp.PDF.Profile.PageHeader
    '            Get
    '                Return _pageHeader
    '            End Get
    '            Set(value As EPDFSharp.PDF.Profile.PageHeader)
    '                _pageHeader = value
    '            End Set
    '        End Property

    '        Public Property PageFooter As EPDFSharp.PDF.Profile.PageFooter
    '            Get
    '                Return _pageFooter
    '            End Get
    '            Set(value As EPDFSharp.PDF.Profile.PageFooter)
    '                _pageFooter = value
    '            End Set
    '        End Property

    '        Public Property RowHeader As EPDFSharp.PDF.Profile.RowHeader
    '            Get
    '                Return _rowHeader
    '            End Get
    '            Set(value As EPDFSharp.PDF.Profile.RowHeader)
    '                _rowHeader = value
    '            End Set
    '        End Property

    '        Public Property RowFooter As EPDFSharp.PDF.Profile.RowFooter
    '            Get
    '                Return _rowFooter
    '            End Get
    '            Set(value As EPDFSharp.PDF.Profile.RowFooter)
    '                _rowFooter = value
    '            End Set
    '        End Property

    '        Public Property PageOrientation As String
    '            Get
    '                Return _pageOrientation
    '            End Get
    '            Set(value As String)
    '                _pageOrientation = value
    '            End Set
    '        End Property

    '        Public Property MergePDF As Boolean
    '            Get

    '                Return _isMergePDF
    '            End Get
    '            Set(value As Boolean)
    '                _isMergePDF = value
    '            End Set
    '        End Property

    '        Public Property PageSize As Integer
    '            Get
    '                Return _pageSize
    '            End Get
    '            Set(value As Integer)
    '                _pageSize = value
    '            End Set
    '        End Property

    '    End Class

    '    Public Class PDFOutputHeader

    '        Private _id As String = ""
    '        Private _recordPerPage As Integer = 1
    '        Private _outputFileName As String = ""
    '        Private _pdfOutputfieldElements() As EPDFSharp.PDF.Profile.FieldCollection

    '        Public Property ID As String
    '            Get
    '                Return _id
    '            End Get
    '            Set(value As String)
    '                _id = value
    '            End Set
    '        End Property

    '    End Class

    '    Public Sub CreateClientProfile(ByVal clientConfig As ClientConfig)
    '        ' Create XmlWriterSettings.
    '        Dim settings As XmlWriterSettings = New XmlWriterSettings()
    '        settings.Indent = True

    '        ' Create XmlWriter.
    '        Using writer As XmlWriter = XmlWriter.Create("Test.xml", settings)
    '            ' Begin writing.
    '            writer.WriteStartDocument()

    '            writer.WriteStartElement(GetEnumDesc(Xml_ElementName.ClientProfile)) 'ClientProfile

    '            writer.WriteStartElement(GetEnumDesc(Xml_ElementName.Input)) 'Input
    '            writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.ParserType), GetEnumDesc(clientConfig.Input.ParserType))
    '            If clientConfig.Input.ParserType = ParserType.Delimited Then _
    '                writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.Delimiter), clientConfig.Input.Delimiter)

    '            For Each fieldElement As FieldElement In clientConfig.InputFieldElements
    '                writer.WriteStartElement(GetEnumDesc(Xml_ElementName.Column))
    '                writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.ID), fieldElement.ID)
    '                If clientConfig.Input.ParserType = ParserType.FixLen Then
    '                    writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.StartPosition), fieldElement.StartPosition)
    '                    writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.DataLength), fieldElement.DataLength)
    '                Else
    '                    writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.IndexPosition), fieldElement.IndexPosition)
    '                End If
    '                writer.WriteEndElement()
    '            Next

    '            ' End document.
    '            writer.WriteEndElement() 'Input

    '            'writer.WriteStartElement(GetEnumDesc(Xml_ElementName.Output)) 'Output
    '            'writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.ParserType), GetEnumDesc(clientConfig.Output.ParserType))
    '            'If clientConfig.Output.ParserType = ParserType.Delimited Then _
    '            '    writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.Delimiter), clientConfig.Output.Delimiter)

    '            'writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.FileExtension), GetEnumDesc(clientConfig.Output.FileExtension))

    '            'For Each outputFieldElements As OutputFieldElement In clientConfig.OutputFieldElements
    '            '    writer.WriteStartElement(GetEnumDesc(Xml_ElementName.Column))
    '            '    writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.ID), outputFieldElements.ID)
    '            '    writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.IDLabel), outputFieldElements.IDLabel)

    '            '    If clientConfig.Output.ParserType = ParserType.FixLen Then
    '            '        writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.DataLength), outputFieldElements.DataLength)
    '            '        writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.PaddedChar), outputFieldElements.PaddedChar)
    '            '    End If

    '            '    If outputFieldElements.DefaultValue <> "" Then writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.DefaultValue), outputFieldElements.DefaultValue)
    '            '    If outputFieldElements.DataType <> "" Then writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.DataType), outputFieldElements.DataType)
    '            '    If outputFieldElements.StringFormat <> "" Then writer.WriteAttributeString(GetEnumDesc(Xml_ElementName.StringFormat), outputFieldElements.StringFormat)

    '            '    writer.WriteEndElement()
    '            'Next

    '            writer.WriteEndElement()

    '            writer.WriteEndElement() 'ClientProfile

    '            writer.WriteEndDocument()
    '        End Using
    '    End Sub

    '    Private Sub BindFieldData(ByRef objField As Object, ByVal objValue As Object)
    '        objField = objValue
    '    End Sub

    '    Public Function LoadClientProfile(ByVal xmlClientProfile As String) As ClientConfig
    '        Try
    '            Dim clientConfig As New ClientConfig

    '            Dim dll As DLL = Nothing
    '            Dim input As New Input
    '            Dim outputs As New List(Of Output)
    '            Dim inputfieldElements As New List(Of FieldElement)
    '            Dim pdfoutputs As New List(Of PDFOutput)
    '            Dim concatenates As New List(Of Concatenate)
    '            Dim replaces As New List(Of Replace)
    '            Dim splits As New List(Of Split)
    '            Dim exclusions As New List(Of Exclusion)

    '            Dim xmldoc As New XmlDataDocument()
    '            Dim xmlnode As XmlNodeList

    '            Dim fs As New FileStream(xmlClientProfile, FileMode.Open, FileAccess.Read)
    '            xmldoc.Load(fs)

    '            For Each xDE As XmlNode In xmldoc.DocumentElement
    '                Select Case xDE.Name
    '                    Case GetEnumDesc(Xml_ElementName.Input)
    '                        'xmlnode = xmldoc.GetElementsByTagName(GetEnumDesc(Xml_ElementName.Input))

    '                        For Each xmlAttribute As XmlAttribute In xDE.Attributes
    '                            Select Case xmlAttribute.Name
    '                                Case GetEnumDesc(Xml_ElementName.IsWithHeader)
    '                                    input.IsWithHeader = CBool(xmlAttribute.Value)
    '                                Case GetEnumDesc(Xml_ElementName.ParserType)
    '                                    input.ParserType = DirectCast([Enum].Parse(GetType(ParserType), xmlAttribute.Value), Integer)
    '                                Case GetEnumDesc(Xml_ElementName.Delimiter)
    '                                    input.Delimiter = xmlAttribute.Value
    '                                Case GetEnumDesc(Xml_ElementName.FileExtension)
    '                                    input.FileExtension = xmlAttribute.Value
    '                                Case GetEnumDesc(Xml_ElementName.SheetName)
    '                                    input.SheetName = xmlAttribute.Value
    '                                Case GetEnumDesc(Xml_ElementName.ExclColumnQuery)
    '                                    input.ExclColumnQuery = xmlAttribute.Value
    '                                Case GetEnumDesc(Xml_ElementName.ExclWhereQuery)
    '                                    input.ExclWhereQuery = xmlAttribute.Value
    '                            End Select
    '                        Next

    '                        'xmlnode = xmldoc.GetElementsByTagName(GetEnumDesc(Xml_ElementName.Input))

    '                        For Each _xmlChildNode As XmlNode In xDE.ChildNodes
    '                            Dim inputfieldElement As New FieldElement

    '                            For Each xmlAttribute As XmlAttribute In _xmlChildNode.Attributes
    '                                Select Case xmlAttribute.Name
    '                                    Case GetEnumDesc(Xml_ElementName.ID)
    '                                        inputfieldElement.ID = xmlAttribute.Value
    '                                    Case GetEnumDesc(Xml_ElementName.StartPosition)
    '                                        inputfieldElement.StartPosition = xmlAttribute.Value
    '                                    Case GetEnumDesc(Xml_ElementName.DataLength)
    '                                        inputfieldElement.DataLength = xmlAttribute.Value
    '                                    Case GetEnumDesc(Xml_ElementName.IndexPosition)
    '                                        inputfieldElement.IndexPosition = xmlAttribute.Value
    '                                    Case GetEnumDesc(Xml_ElementName.SheetColumnName)
    '                                        inputfieldElement.SheetColumnName = xmlAttribute.Value
    '                                    Case GetEnumDesc(Xml_ElementName.Replace)
    '                                        inputfieldElement.Replace = xmlAttribute.Value
    '                                    Case GetEnumDesc(Xml_ElementName.Concatenate)
    '                                        inputfieldElement.Concatenate = xmlAttribute.Value
    '                                End Select
    '                            Next

    '                            inputfieldElements.Add(inputfieldElement)
    '                        Next
    '                    Case GetEnumDesc(Xml_ElementName.Output)
    '                        Dim output As New Output
    '                        Dim fileAttr As FileAttr = Nothing
    '                        Dim grouping As Grouping = Nothing
    '                        'Dim exclusion As Exclusion = Nothing
    '                        Dim outputfieldElements As New List(Of OutputFieldElement)

    '                        'xmlnode = xmldoc.GetElementsByTagName(GetEnumDesc(Xml_ElementName.Output))

    '                        For Each xmlAttribute As XmlAttribute In xDE.Attributes
    '                            Select Case xmlAttribute.Name
    '                                Case GetEnumDesc(Xml_ElementName.ParserType)
    '                                    output.ParserType = DirectCast([Enum].Parse(GetType(ParserType), xmlAttribute.Value), Integer)
    '                                Case GetEnumDesc(Xml_ElementName.Delimiter)
    '                                    output.Delimiter = xmlAttribute.Value
    '                                Case GetEnumDesc(Xml_ElementName.OutputFileName)
    '                                    If fileAttr Is Nothing Then fileAttr = New FileAttr
    '                                    fileAttr.FileOutputName = xmlAttribute.Value
    '                                Case GetEnumDesc(Xml_ElementName.FileExtension)
    '                                    If fileAttr Is Nothing Then fileAttr = New FileAttr
    '                                    fileAttr.FileExtension = xmlAttribute.Value
    '                                Case GetEnumDesc(Xml_ElementName.IsWithHeader)
    '                                    output.IsWithHeader = CBool(xmlAttribute.Value)
    '                                Case GetEnumDesc(Xml_ElementName.PDFOutput)
    '                                    output.PDFOutput = xmlAttribute.Value
    '                                Case GetEnumDesc(Xml_ElementName.Exclusion)
    '                                    output.Exclusion = xmlAttribute.Value
    '                            End Select
    '                        Next

    '                        'xmlnode = xmldoc.GetElementsByTagName(GetEnumDesc(Xml_ElementName.Output))

    '                        For Each _xmlChildNode As XmlNode In xDE.ChildNodes

    '                            Select Case _xmlChildNode.Name
    '                                Case GetEnumDesc(Xml_ElementName.Column)
    '                                    Dim outputfieldElement As New OutputFieldElement

    '                                    For Each xmlAttribute As XmlAttribute In _xmlChildNode.Attributes
    '                                        Select Case xmlAttribute.Name
    '                                            Case GetEnumDesc(Xml_ElementName.ID)
    '                                                outputfieldElement.ID = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.IDLabel)
    '                                                outputfieldElement.IDLabel = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.DataLength)
    '                                                outputfieldElement.DataLength = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.PaddedChar)
    '                                                outputfieldElement.PaddedChar = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.DataType)
    '                                                outputfieldElement.DataType = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.DefaultValue)
    '                                                outputfieldElement.DefaultValue = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.FilePathType)
    '                                                outputfieldElement.FilePathType = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.StringFormat)
    '                                                outputfieldElement.StringFormat = xmlAttribute.Value
    '                                        'Case GetEnumDesc(Xml_ElementName.Exclusion)
    '                                        '    outputfieldElement.Exclusion = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.Concatenate)
    '                                                outputfieldElement.Concatenate = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.Replace)
    '                                                outputfieldElement.Replace = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.IsDisplay)
    '                                                outputfieldElement.IsDisplay = CShort(xmlAttribute.Value)
    '                                        End Select
    '                                    Next

    '                                    outputfieldElements.Add(outputfieldElement)
    '                                Case GetEnumDesc(Xml_ElementName.Grouping)
    '                                    Dim _groupConditions As New List(Of GroupingCondition)

    '                                    For Each _groupingChildNode As XmlNode In _xmlChildNode.ChildNodes
    '                                        Select Case _groupingChildNode.Name
    '                                            Case GetEnumDesc(Xml_ElementName.Condition)
    '                                                Dim _groupCondition As New GroupingCondition
    '                                                Dim _fileAttr As FileAttr = Nothing

    '                                                For Each xmlAttribute As XmlAttribute In _groupingChildNode.Attributes
    '                                                    Select Case xmlAttribute.Name
    '                                                        Case GetEnumDesc(Xml_ElementName.FilterExpression)
    '                                                            _groupCondition.FilterExpression = xmlAttribute.Value
    '                                                        Case GetEnumDesc(Xml_ElementName.SortExpression)
    '                                                            _groupCondition.SortExpression = xmlAttribute.Value
    '                                                        Case GetEnumDesc(Xml_ElementName.OutputFileName)
    '                                                            If _fileAttr Is Nothing Then _fileAttr = New FileAttr
    '                                                            _fileAttr.FileOutputName = xmlAttribute.Value
    '                                                        Case GetEnumDesc(Xml_ElementName.FileExtension)
    '                                                            If _fileAttr Is Nothing Then _fileAttr = New FileAttr
    '                                                            _fileAttr.FileExtension = xmlAttribute.Value
    '                                                    End Select
    '                                                Next

    '                                                If Not _fileAttr Is Nothing Then _groupCondition.FileAttr = _fileAttr
    '                                                If Not _groupCondition Is Nothing Then _groupConditions.Add(_groupCondition)
    '                                        End Select
    '                                    Next

    '                                    If Not _groupConditions Is Nothing Then
    '                                        'If Not _groupConditions Is Nothing Then grouping = New Grouping
    '                                        grouping = New Grouping
    '                                        grouping.GroupingConditions = _groupConditions.ToArray
    '                                    End If
    '                                    'Case GetEnumDesc(Xml_ElementName.Exclusion)
    '                                    '    Dim _exclusionConditions As New List(Of ExclusionCondition)

    '                                    '    For Each _exclusionChildNode As XmlNode In _xmlChildNode.ChildNodes
    '                                    '        Select Case _exclusionChildNode.Name
    '                                    '            Case GetEnumDesc(Xml_ElementName.Condition)
    '                                    '                Dim _exclusionCondition As New ExclusionCondition

    '                                    '                For Each xmlAttribute As XmlAttribute In _exclusionChildNode.Attributes
    '                                    '                    Select Case xmlAttribute.Name
    '                                    '                        Case GetEnumDesc(Xml_ElementName.ID)
    '                                    '                            _exclusionCondition.ID = xmlAttribute.Value
    '                                    '                        Case GetEnumDesc(Xml_ElementName.FilterExpression)
    '                                    '                            _exclusionCondition.Expression = xmlAttribute.Value
    '                                    '                        Case GetEnumDesc(Xml_ElementName.Value)
    '                                    '                            _exclusionCondition.Value = xmlAttribute.Value
    '                                    '                        Case GetEnumDesc(Xml_ElementName.Trim)
    '                                    '                            _exclusionCondition.Trim = CBool(xmlAttribute.Value)
    '                                    '                    End Select
    '                                    '                Next

    '                                    '                If Not _exclusionCondition Is Nothing Then _exclusionConditions.Add(_exclusionCondition)
    '                                    '        End Select
    '                                    '    Next

    '                                    'If Not _exclusionConditions Is Nothing Then
    '                                    '    'If Not _exclusionConditions Is Nothing Then exclusion = New Exclusion
    '                                    '    exclusion = New Exclusion
    '                                    '    exclusion.ExclusionConditions = _exclusionConditions.ToArray
    '                                    'End If
    '                            End Select
    '                        Next

    '                        If Not fileAttr Is Nothing Then output.FileAttr = fileAttr
    '                        If Not grouping Is Nothing Then output.Grouping = grouping
    '                        'If Not exclusion Is Nothing Then output.Exclusion = exclusion
    '                        output.OutputFieldElements = outputfieldElements.ToArray

    '                        outputs.Add(output)
    '                    Case GetEnumDesc(Xml_ElementName.PDFOutput)
    '                        Dim pdfOutput As New PDFOutput
    '                        Dim pdfoutputfieldElements As New List(Of EPDFSharp.PDF.Profile.FieldCollection)

    '                        For Each xmlAttribute As XmlAttribute In xDE.Attributes
    '                            Select Case xmlAttribute.Name
    '                                Case GetEnumDesc(Xml_ElementName.ID)
    '                                    pdfOutput.ID = xmlAttribute.Value
    '                                Case GetEnumDesc(Xml_ElementName.RecordPerPage)
    '                                    pdfOutput.RecordPerPage = CInt(xmlAttribute.Value)
    '                                Case GetEnumDesc(Xml_ElementName.OutputFileName)
    '                                    pdfOutput.OutputFileName = xmlAttribute.Value
    '                                Case GetEnumDesc(Xml_ElementName.PageOrientation)
    '                                    pdfOutput.PageOrientation = xmlAttribute.Value
    '                                Case GetEnumDesc(Xml_ElementName.IsMergePDF)
    '                                    pdfOutput.MergePDF = CBool(xmlAttribute.Value)
    '                                Case GetEnumDesc(Xml_ElementName.PageSize)
    '                                    pdfOutput.PageSize = CInt(xmlAttribute.Value)
    '                            End Select
    '                        Next

    '                        For Each _xmlChildNode As XmlNode In xDE.ChildNodes
    '                            Dim pdfoutputfieldElement As New EPDFSharp.PDF.Profile.FieldCollection
    '                            Dim stringObject As EPDFSharp.PDF.Profile.StringObject = Nothing
    '                            Dim lineObject As EPDFSharp.PDF.Profile.LineObject = Nothing
    '                            Dim rectangleObject As EPDFSharp.PDF.Profile.RectangleObject = Nothing
    '                            Dim imageFromFileObject As EPDFSharp.PDF.Profile.ImageFromFileObject = Nothing
    '                            Dim barcodeObject As EPDFSharp.PDF.Profile.BarcodeObject = Nothing
    '                            Dim xFont As EPDFSharp.PDF.Profile.XFont = Nothing
    '                            Dim xRect As EPDFSharp.PDF.Profile.XRect = Nothing
    '                            Dim crop As EPDFSharp.PDF.Profile.Crop = Nothing
    '                            Dim xColor As EPDFSharp.PDF.Profile.XColor = Nothing
    '                            Dim pageHeader As EPDFSharp.PDF.Profile.PageHeader = Nothing
    '                            Dim pageFooter As EPDFSharp.PDF.Profile.PageFooter = Nothing
    '                            Dim rowHeader As EPDFSharp.PDF.Profile.RowHeader = Nothing
    '                            Dim rowFooter As EPDFSharp.PDF.Profile.RowFooter = Nothing

    '                            Select Case _xmlChildNode.Name
    '                                Case GetEnumDesc(Xml_ElementName.Column)
    '                                    For Each xmlAttribute As XmlAttribute In _xmlChildNode.Attributes
    '                                        Select Case xmlAttribute.Name
    '                                            Case GetEnumDesc(Xml_ElementName.ID)
    '                                                pdfoutputfieldElement.ID = xmlAttribute.Value
    '                                                pdfoutputfieldElement.RefID = pdfoutputfieldElement.ID
    '                                            Case GetEnumDesc(Xml_ElementName.RefID)
    '                                                pdfoutputfieldElement.RefID = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.ObjectType)
    '                                                pdfoutputfieldElement.ObjectType = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.XFontName)
    '                                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                                If xFont Is Nothing Then xFont = New EPDFSharp.PDF.Profile.XFont
    '                                                xFont.FontName = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.XFontSize)
    '                                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                                If xFont Is Nothing Then xFont = New EPDFSharp.PDF.Profile.XFont
    '                                                xFont.FontSize = CDbl(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.XFontStyle)
    '                                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                                If xFont Is Nothing Then xFont = New EPDFSharp.PDF.Profile.XFont
    '                                                xFont.FontStyle = CShort(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.XRectX)
    '                                                If pdfoutputfieldElement.ObjectType = "String" Then
    '                                                    If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "Rectangle" Then
    '                                                    If rectangleObject Is Nothing Then rectangleObject = New EPDFSharp.PDF.Profile.RectangleObject
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "ImageFromFile" Then
    '                                                    If imageFromFileObject Is Nothing Then imageFromFileObject = New EPDFSharp.PDF.Profile.ImageFromFileObject
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "Barcode" Then
    '                                                    If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                                End If
    '                                                If xRect Is Nothing Then xRect = New EPDFSharp.PDF.Profile.XRect
    '                                                xRect.X = CDbl(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.XRectY)
    '                                                If pdfoutputfieldElement.ObjectType = "String" Then
    '                                                    If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "Rectangle" Then
    '                                                    If rectangleObject Is Nothing Then rectangleObject = New EPDFSharp.PDF.Profile.RectangleObject
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "ImageFromFile" Then
    '                                                    If imageFromFileObject Is Nothing Then imageFromFileObject = New EPDFSharp.PDF.Profile.ImageFromFileObject
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "Barcode" Then
    '                                                    If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                                End If
    '                                                If xRect Is Nothing Then xRect = New EPDFSharp.PDF.Profile.XRect
    '                                                xRect.Y = CDbl(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.XRectWidth)
    '                                                If pdfoutputfieldElement.ObjectType = "String" Then
    '                                                    If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "Rectangle" Then
    '                                                    If rectangleObject Is Nothing Then rectangleObject = New EPDFSharp.PDF.Profile.RectangleObject
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "ImageFromFile" Then
    '                                                    If imageFromFileObject Is Nothing Then imageFromFileObject = New EPDFSharp.PDF.Profile.ImageFromFileObject
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "Barcode" Then
    '                                                    If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                                End If
    '                                                If xRect Is Nothing Then xRect = New EPDFSharp.PDF.Profile.XRect
    '                                                xRect.Width = CDbl(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.XRectHeight)
    '                                                If pdfoutputfieldElement.ObjectType = "String" Then
    '                                                    If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "Rectangle" Then
    '                                                    If rectangleObject Is Nothing Then rectangleObject = New EPDFSharp.PDF.Profile.RectangleObject
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "ImageFromFile" Then
    '                                                    If imageFromFileObject Is Nothing Then imageFromFileObject = New EPDFSharp.PDF.Profile.ImageFromFileObject
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "Barcode" Then
    '                                                    If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                                End If
    '                                                If xRect Is Nothing Then xRect = New EPDFSharp.PDF.Profile.XRect
    '                                                xRect.Height = CDbl(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.XStringFormat)
    '                                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                                stringObject.XStringFormat = CShort(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.XBrush)
    '                                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                                stringObject.XBrush = CShort(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.XParagraphAlignment)
    '                                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                                stringObject.ParagraphAlignment = CShort(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.IsDrawRect)
    '                                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                                stringObject.IsDrawRect = CShort(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.LineHeight)
    '                                                If pdfoutputfieldElement.ObjectType = "Line" Then
    '                                                    If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                                    lineObject.LineHeight = CDbl(xmlAttribute.Value)
    '                                                ElseIf pdfoutputfieldElement.ObjectType = "Rectangle" Then
    '                                                    If rectangleObject Is Nothing Then rectangleObject = New EPDFSharp.PDF.Profile.RectangleObject
    '                                                    rectangleObject.LineHeight = CDbl(xmlAttribute.Value)
    '                                                End If
    '                                            Case GetEnumDesc(Xml_ElementName.X)
    '                                                If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                                lineObject.X = CDbl(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.Y)
    '                                                If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                                lineObject.Y = CDbl(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.Width)
    '                                                If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                                lineObject.Width = CDbl(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.Height)
    '                                                If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                                lineObject.Height = CDbl(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.XColorProperty)
    '                                                If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                                If xColor Is Nothing Then xColor = New EPDFSharp.PDF.Profile.XColor
    '                                                xColor.xColorProperty = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.XColorParameter)
    '                                                If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                                If xColor Is Nothing Then xColor = New EPDFSharp.PDF.Profile.XColor
    '                                                xColor.Parameter = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.DIType)
    '                                                If imageFromFileObject Is Nothing Then imageFromFileObject = New EPDFSharp.PDF.Profile.ImageFromFileObject
    '                                                imageFromFileObject.DIType = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.BarcodeSymbology)
    '                                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                                barcodeObject.BarcodeSymbology = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.ImageFormat)
    '                                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                                barcodeObject.ImageFormat = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.BarcodeDisplayCode)
    '                                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                                barcodeObject.DisplayCode = CShort(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.CropX)
    '                                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                                If crop Is Nothing Then crop = New EPDFSharp.PDF.Profile.Crop
    '                                                crop.X = CDbl(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.CropY)
    '                                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                                If crop Is Nothing Then crop = New EPDFSharp.PDF.Profile.Crop
    '                                                crop.Y = CDbl(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.CropWidth)
    '                                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                                If crop Is Nothing Then crop = New EPDFSharp.PDF.Profile.Crop
    '                                                crop.Width = CDbl(xmlAttribute.Value)
    '                                            Case GetEnumDesc(Xml_ElementName.CropHeight)
    '                                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                                If crop Is Nothing Then crop = New EPDFSharp.PDF.Profile.Crop
    '                                                crop.Height = CDbl(xmlAttribute.Value)
    '                                        End Select
    '                                    Next

    '                                    If pdfoutputfieldElement.ObjectType = "String" Then
    '                                        stringObject.Font = xFont
    '                                        stringObject.XRect = xRect
    '                                        pdfoutputfieldElement.FCObject = stringObject
    '                                    ElseIf pdfoutputfieldElement.ObjectType = "Line" Then
    '                                        lineObject.XColor = xColor
    '                                        pdfoutputfieldElement.FCObject = lineObject
    '                                    ElseIf pdfoutputfieldElement.ObjectType = "Rectangle" Then
    '                                        rectangleObject.XColor = xColor
    '                                        rectangleObject.XRect = xRect
    '                                        pdfoutputfieldElement.FCObject = rectangleObject
    '                                    ElseIf pdfoutputfieldElement.ObjectType = "ImageFromFile" Then
    '                                        imageFromFileObject.XRect = xRect
    '                                        pdfoutputfieldElement.FCObject = imageFromFileObject
    '                                    ElseIf pdfoutputfieldElement.ObjectType = "Barcode" Then
    '                                        barcodeObject.XRect = xRect
    '                                        barcodeObject.Crop = crop
    '                                        pdfoutputfieldElement.FCObject = barcodeObject
    '                                    End If

    '                                    pdfoutputfieldElements.Add(pdfoutputfieldElement)
    '                                    pdfoutputfieldElement = Nothing
    '                                    stringObject = Nothing
    '                                    lineObject = Nothing
    '                                    rectangleObject = Nothing
    '                                    imageFromFileObject = Nothing
    '                                    barcodeObject = Nothing
    '                                    xColor = Nothing
    '                                    xRect = Nothing
    '                                    crop = Nothing
    '                                    xFont = Nothing
    '                            End Select


    '                            Dim fieldCollections As List(Of EPDFSharp.PDF.Profile.PageHeaderFieldCollection) = Nothing
    '                            Select Case _xmlChildNode.Name
    '                                Case GetEnumDesc(Xml_ElementName.PageHeader)
    '                                    fieldCollections = PopulateConfigPerNode(_xmlChildNode)

    '                                    If Not fieldCollections Is Nothing Then
    '                                        pageHeader = New EPDFSharp.PDF.Profile.PageHeader
    '                                        pageHeader.FieldCollections = fieldCollections.ToArray
    '                                        pdfOutput.PageHeader = pageHeader
    '                                    End If
    '                                Case GetEnumDesc(Xml_ElementName.PageFooter)
    '                                    For Each xmlAttribute As XmlAttribute In _xmlChildNode.Attributes
    '                                        Select Case xmlAttribute.Name
    '                                            Case GetEnumDesc(Xml_ElementName.PagingStyle)
    '                                                If pageFooter Is Nothing Then pageFooter = New EPDFSharp.PDF.Profile.PageFooter
    '                                                pageFooter.PagingStyle = xmlAttribute.Value
    '                                        End Select
    '                                    Next

    '                                    If Not pageFooter Is Nothing Then pdfOutput.PageFooter = pageFooter
    '                                Case GetEnumDesc(Xml_ElementName.RowHeader)
    '                                    fieldCollections = PopulateConfigPerNode(_xmlChildNode)

    '                                    If Not fieldCollections Is Nothing Then
    '                                        rowHeader = New EPDFSharp.PDF.Profile.RowHeader
    '                                        rowHeader.FieldCollections = fieldCollections.ToArray
    '                                        pdfOutput.RowHeader = rowHeader
    '                                    End If
    '                                Case GetEnumDesc(Xml_ElementName.RowFooter)
    '                                    fieldCollections = PopulateConfigPerNode(_xmlChildNode)

    '                                    If Not fieldCollections Is Nothing Then
    '                                        rowFooter = New EPDFSharp.PDF.Profile.RowFooter
    '                                        rowFooter.FieldCollections = fieldCollections.ToArray
    '                                        pdfOutput.RowFooter = rowFooter
    '                                    End If
    '                            End Select

    '                            'rowheader
    '                            Dim phFieldCollections As List(Of EPDFSharp.PDF.Profile.PageHeaderFieldCollection) = Nothing
    '                            Select Case _xmlChildNode.Name
    '                                Case GetEnumDesc(Xml_ElementName.PageHeader)
    '                                    phFieldCollections = PopulateConfigPerNode(_xmlChildNode)

    '                                    If Not phFieldCollections Is Nothing Then
    '                                        pageHeader = New EPDFSharp.PDF.Profile.PageHeader
    '                                        pageHeader.FieldCollections = fieldCollections.ToArray
    '                                        pdfOutput.PageHeader = pageHeader
    '                                    End If
    '                            End Select





    '                            'If Not pageHeader Is Nothing Then pdfOutput.PageHeader = pageHeader

    '                        Next

    '                        pdfOutput.ClientProfilePath = New FileInfo(xmlClientProfile).DirectoryName
    '                        pdfOutput.PDFOutputFieldElements = pdfoutputfieldElements.ToArray

    '                        pdfoutputs.Add(pdfOutput)
    '                    Case GetEnumDesc(Xml_ElementName.Concatenate)
    '                        Dim concatenate As New Concatenate
    '                        Dim _fieldElements As New List(Of ConcatenateFieldElement)

    '                        For Each xmlAttribute As XmlAttribute In xDE.Attributes
    '                            Select Case xmlAttribute.Name
    '                                Case GetEnumDesc(Xml_ElementName.ID)
    '                                    concatenate.ID = xmlAttribute.Value
    '                            End Select
    '                        Next

    '                        For Each _xmlChildNode As XmlNode In xDE.ChildNodes
    '                            Dim _fieldElement As New ConcatenateFieldElement
    '                            Select Case _xmlChildNode.Name
    '                                Case GetEnumDesc(Xml_ElementName.Column)
    '                                    For Each xmlAttribute As XmlAttribute In _xmlChildNode.Attributes
    '                                        Select Case xmlAttribute.Name
    '                                            Case GetEnumDesc(Xml_ElementName.ID)
    '                                                _fieldElement.ID = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.RefID)
    '                                                _fieldElement.RefID = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.SubStr)
    '                                                _fieldElement.SubStr = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.DefaultValue)
    '                                                _fieldElement.DefaultValue = xmlAttribute.Value
    '                                        End Select
    '                                    Next
    '                            End Select

    '                            If Not _fieldElements Is Nothing Then _fieldElements.Add(_fieldElement)
    '                        Next

    '                        If Not _fieldElements Is Nothing Then concatenate.FieldElements = _fieldElements.ToArray
    '                        concatenates.Add(concatenate)
    '                    Case GetEnumDesc(Xml_ElementName.Replace)
    '                        Dim replace As New Replace
    '                        Dim _fieldElements As New List(Of ReplaceFieldElement)

    '                        For Each xmlAttribute As XmlAttribute In xDE.Attributes
    '                            Select Case xmlAttribute.Name
    '                                Case GetEnumDesc(Xml_ElementName.ID)
    '                                    replace.ID = xmlAttribute.Value
    '                            End Select
    '                        Next

    '                        For Each _xmlChildNode As XmlNode In xDE.ChildNodes
    '                            Dim _fieldElement As New ReplaceFieldElement
    '                            Select Case _xmlChildNode.Name
    '                                Case GetEnumDesc(Xml_ElementName.Column)
    '                                    For Each xmlAttribute As XmlAttribute In _xmlChildNode.Attributes
    '                                        Select Case xmlAttribute.Name
    '                                            Case GetEnumDesc(Xml_ElementName.ID)
    '                                                _fieldElement.ID = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.RefID)
    '                                                _fieldElement.RefID = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.OldValue)
    '                                                _fieldElement.OldValue = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.NewValue)
    '                                                _fieldElement.NewValue = xmlAttribute.Value
    '                                        End Select
    '                                    Next
    '                            End Select

    '                            If Not _fieldElements Is Nothing Then _fieldElements.Add(_fieldElement)
    '                        Next

    '                        If Not _fieldElements Is Nothing Then replace.FieldElements = _fieldElements.ToArray
    '                        replaces.Add(replace)
    '                    Case GetEnumDesc(Xml_ElementName.Split)
    '                        Dim split As New Split
    '                        Dim _fieldElements As New List(Of SplitFieldElement)

    '                        For Each xmlAttribute As XmlAttribute In xDE.Attributes
    '                            Select Case xmlAttribute.Name
    '                                Case GetEnumDesc(Xml_ElementName.ID)
    '                                    split.ID = xmlAttribute.Value
    '                            End Select
    '                        Next

    '                        For Each _xmlChildNode As XmlNode In xDE.ChildNodes
    '                            Dim _fieldElement As New SplitFieldElement
    '                            Select Case _xmlChildNode.Name
    '                                Case GetEnumDesc(Xml_ElementName.Column)
    '                                    For Each xmlAttribute As XmlAttribute In _xmlChildNode.Attributes
    '                                        Select Case xmlAttribute.Name
    '                                            Case GetEnumDesc(Xml_ElementName.ID)
    '                                                _fieldElement.ID = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.RefID)
    '                                                _fieldElement.RefID = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.DefaultValue)
    '                                                _fieldElement.DefaultValue = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.Delimiter)
    '                                                _fieldElement.Delimiter = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.IndexPosition)
    '                                                _fieldElement.IndexPosition = CInt(xmlAttribute.Value)
    '                                        End Select
    '                                    Next
    '                            End Select

    '                            If Not _fieldElements Is Nothing Then _fieldElements.Add(_fieldElement)
    '                        Next

    '                        If Not _fieldElements Is Nothing Then split.FieldElements = _fieldElements.ToArray
    '                        splits.Add(split)
    '                    Case GetEnumDesc(Xml_ElementName.Exclusion)
    '                        Dim exclusion As New Exclusion
    '                        Dim _fieldElements As New List(Of ExclusionFieldElement)

    '                        For Each xmlAttribute As XmlAttribute In xDE.Attributes
    '                            Select Case xmlAttribute.Name
    '                                Case GetEnumDesc(Xml_ElementName.ID)
    '                                    exclusion.ID = xmlAttribute.Value
    '                            End Select
    '                        Next

    '                        For Each _xmlChildNode As XmlNode In xDE.ChildNodes
    '                            Dim _fieldElement As New ExclusionFieldElement
    '                            Select Case _xmlChildNode.Name
    '                                Case GetEnumDesc(Xml_ElementName.Column)
    '                                    For Each xmlAttribute As XmlAttribute In _xmlChildNode.Attributes
    '                                        Select Case xmlAttribute.Name
    '                                            Case GetEnumDesc(Xml_ElementName.ID)
    '                                                _fieldElement.ID = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.RefID)
    '                                                _fieldElement.RefID = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.FilterExpression)
    '                                                _fieldElement.FilterExpression = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.Value)
    '                                                _fieldElement.Value = xmlAttribute.Value
    '                                            Case GetEnumDesc(Xml_ElementName.DataType)
    '                                                _fieldElement.DataType = xmlAttribute.Value
    '                                        End Select
    '                                    Next
    '                            End Select

    '                            If Not _fieldElements Is Nothing Then _fieldElements.Add(_fieldElement)
    '                        Next

    '                        If Not _fieldElements Is Nothing Then exclusion.FieldElements = _fieldElements.ToArray
    '                        exclusions.Add(exclusion)
    '                    Case GetEnumDesc(Xml_ElementName.DLL)
    '                        dll = New DLL
    '                        For Each xmlAttribute As XmlAttribute In xDE.Attributes
    '                            Select Case xmlAttribute.Name
    '                                Case GetEnumDesc(Xml_ElementName.FilePath)
    '                                    dll.FilePath = xmlAttribute.Value
    '                                Case GetEnumDesc(Xml_ElementName.RunNativeGenerateOutput)
    '                                    dll.RunNativeGenerateOutput = CBool(xmlAttribute.Value)
    '                            End Select
    '                        Next
    '                End Select
    '            Next

    '            clientConfig.CDLL = dll
    '            clientConfig.Input = input
    '            clientConfig.InputFieldElements = inputfieldElements.ToArray
    '            clientConfig.Outputs = outputs.ToArray
    '            clientConfig.PDFOutputs = pdfoutputs.ToArray
    '            clientConfig.Concatenates = concatenates.ToArray
    '            clientConfig.Replaces = replaces.ToArray
    '            clientConfig.Exclusions = exclusions.ToArray

    '            xmldoc = Nothing
    '            xmlnode = Nothing
    '            fs.Flush()
    '            fs = Nothing

    '            _dtInputData = New DataTable
    '            Dim colRecordID As New DataColumn
    '            colRecordID.ColumnName = "RecordID"
    '            colRecordID.DataType = GetType(Int32)
    '            colRecordID.AutoIncrement = True
    '            colRecordID.AutoIncrementSeed = 1
    '            colRecordID.AutoIncrementStep = 1
    '            _dtInputData.Columns.Add(colRecordID)

    '            For Each inputfieldElement As FieldElement In clientConfig.InputFieldElements
    '                _dtInputData.Columns.Add(inputfieldElement.ID, GetType(String))
    '            Next

    '            Return clientConfig
    '        Catch ex As Exception
    '            SaveToLog("LoadClientProfile(): " & ex.Message)
    '            sbLog.Append("LoadClientProfile(): " & ex.Message)
    '            Return Nothing
    '        End Try
    '    End Function

    '    Private Function PopulateConfigPerNode(ByVal xmlNode As XmlNode) As Object
    '        Dim fieldCollections As List(Of EPDFSharp.PDF.Profile.PageHeaderFieldCollection) = Nothing

    '        For Each _xmlNode As XmlNode In xmlNode.ChildNodes
    '            Select Case _xmlNode.Name
    '                Case GetEnumDesc(Xml_ElementName.Column)
    '                    Dim fieldCollection As New EPDFSharp.PDF.Profile.PageHeaderFieldCollection
    '                    Dim stringObject As EPDFSharp.PDF.Profile.StringObject = Nothing
    '                    Dim lineObject As EPDFSharp.PDF.Profile.LineObject = Nothing
    '                    Dim rectangleObject As EPDFSharp.PDF.Profile.RectangleObject = Nothing
    '                    Dim imageFromFileObject As EPDFSharp.PDF.Profile.ImageFromFileObject = Nothing
    '                    Dim barcodeObject As EPDFSharp.PDF.Profile.BarcodeObject = Nothing

    '                    Dim xFont As EPDFSharp.PDF.Profile.XFont = Nothing
    '                    Dim xRect As EPDFSharp.PDF.Profile.XRect = Nothing
    '                    Dim crop As EPDFSharp.PDF.Profile.Crop = Nothing
    '                    Dim xColor As EPDFSharp.PDF.Profile.XColor = Nothing

    '                    For Each xmlAttribute As XmlAttribute In _xmlNode.Attributes
    '                        Select Case xmlAttribute.Name
    '                            Case GetEnumDesc(Xml_ElementName.ID)
    '                                fieldCollection.ID = xmlAttribute.Value
    '                                fieldCollection.RefID = fieldCollection.ID
    '                            Case GetEnumDesc(Xml_ElementName.RefID)
    '                                fieldCollection.RefID = xmlAttribute.Value
    '                            Case GetEnumDesc(Xml_ElementName.DefaultValue)
    '                                fieldCollection.DefaultValue = xmlAttribute.Value
    '                            Case GetEnumDesc(Xml_ElementName.DataType)
    '                                fieldCollection.DataType = xmlAttribute.Value
    '                            Case GetEnumDesc(Xml_ElementName.StringFormat)
    '                                fieldCollection.StringFormat = xmlAttribute.Value
    '                            Case GetEnumDesc(Xml_ElementName.FirstPageOnly)
    '                                fieldCollection.FirstPageOnly = CBool(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.ObjectType)
    '                                fieldCollection.ObjectType = xmlAttribute.Value
    '                            Case GetEnumDesc(Xml_ElementName.XFontName)
    '                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                If xFont Is Nothing Then xFont = New EPDFSharp.PDF.Profile.XFont
    '                                xFont.FontName = xmlAttribute.Value
    '                            Case GetEnumDesc(Xml_ElementName.XFontSize)
    '                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                If xFont Is Nothing Then xFont = New EPDFSharp.PDF.Profile.XFont
    '                                xFont.FontSize = CDbl(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.XFontStyle)
    '                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                If xFont Is Nothing Then xFont = New EPDFSharp.PDF.Profile.XFont
    '                                xFont.FontStyle = CShort(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.XRectX)
    '                                If fieldCollection.ObjectType = "String" Then
    '                                    If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                End If
    '                                If xRect Is Nothing Then xRect = New EPDFSharp.PDF.Profile.XRect
    '                                xRect.X = CDbl(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.XRectY)
    '                                If fieldCollection.ObjectType = "String" Then
    '                                    If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                End If
    '                                If xRect Is Nothing Then xRect = New EPDFSharp.PDF.Profile.XRect
    '                                xRect.Y = CDbl(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.XRectWidth)
    '                                If fieldCollection.ObjectType = "String" Then
    '                                    If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                End If
    '                                If xRect Is Nothing Then xRect = New EPDFSharp.PDF.Profile.XRect
    '                                xRect.Width = CDbl(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.XRectHeight)
    '                                If fieldCollection.ObjectType = "String" Then
    '                                    If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                End If
    '                                If xRect Is Nothing Then xRect = New EPDFSharp.PDF.Profile.XRect
    '                                xRect.Height = CDbl(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.XStringFormat)
    '                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                stringObject.XStringFormat = CShort(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.XBrush)
    '                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                stringObject.XBrush = CShort(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.XParagraphAlignment)
    '                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                stringObject.ParagraphAlignment = CShort(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.IsDrawRect)
    '                                If stringObject Is Nothing Then stringObject = New EPDFSharp.PDF.Profile.StringObject
    '                                stringObject.IsDrawRect = CShort(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.X)
    '                                If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                lineObject.X = CDbl(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.Y)
    '                                If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                lineObject.Y = CDbl(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.Width)
    '                                If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                lineObject.Width = CDbl(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.Height)
    '                                If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                lineObject.Height = CDbl(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.XColorProperty)
    '                                If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                If xColor Is Nothing Then xColor = New EPDFSharp.PDF.Profile.XColor
    '                                xColor.xColorProperty = xmlAttribute.Value
    '                            Case GetEnumDesc(Xml_ElementName.XColorParameter)
    '                                If lineObject Is Nothing Then lineObject = New EPDFSharp.PDF.Profile.LineObject
    '                                If xColor Is Nothing Then xColor = New EPDFSharp.PDF.Profile.XColor
    '                                xColor.Parameter = xmlAttribute.Value
    '                            Case GetEnumDesc(Xml_ElementName.DIType)
    '                                If imageFromFileObject Is Nothing Then imageFromFileObject = New EPDFSharp.PDF.Profile.ImageFromFileObject
    '                                imageFromFileObject.DIType = xmlAttribute.Value
    '                            Case GetEnumDesc(Xml_ElementName.BarcodeSymbology)
    '                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                barcodeObject.BarcodeSymbology = xmlAttribute.Value
    '                            Case GetEnumDesc(Xml_ElementName.ImageFormat)
    '                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                barcodeObject.ImageFormat = xmlAttribute.Value
    '                            Case GetEnumDesc(Xml_ElementName.BarcodeDisplayCode)
    '                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                barcodeObject.DisplayCode = CShort(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.CropX)
    '                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                If crop Is Nothing Then crop = New EPDFSharp.PDF.Profile.Crop
    '                                crop.X = CDbl(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.CropY)
    '                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                If crop Is Nothing Then crop = New EPDFSharp.PDF.Profile.Crop
    '                                crop.Y = CDbl(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.CropWidth)
    '                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                If crop Is Nothing Then crop = New EPDFSharp.PDF.Profile.Crop
    '                                crop.Width = CDbl(xmlAttribute.Value)
    '                            Case GetEnumDesc(Xml_ElementName.CropHeight)
    '                                If barcodeObject Is Nothing Then barcodeObject = New EPDFSharp.PDF.Profile.BarcodeObject
    '                                If crop Is Nothing Then crop = New EPDFSharp.PDF.Profile.Crop
    '                                crop.Height = CDbl(xmlAttribute.Value)
    '                        End Select
    '                    Next

    '                    If fieldCollection.ObjectType = "String" Then
    '                        stringObject.Font = xFont
    '                        stringObject.XRect = xRect
    '                        fieldCollection.FCObject = stringObject
    '                    End If

    '                    If fieldCollections Is Nothing Then
    '                        fieldCollections = New List(Of EPDFSharp.PDF.Profile.PageHeaderFieldCollection)
    '                    End If
    '                    fieldCollections.Add(fieldCollection)
    '                    fieldCollection = Nothing
    '                    stringObject = Nothing
    '                    xColor = Nothing
    '                    xRect = Nothing
    '                    crop = Nothing
    '                    xFont = Nothing
    '            End Select
    '        Next

    '        If Not fieldCollections Is Nothing Then
    '            Return fieldCollections
    '        Else
    '            Return Nothing
    '        End If
    '    End Function

    '    Public Sub InputParseData(ByVal xmlClientProfile As String, ByRef status As String, ByRef _action As Action)
    '        Try
    '            SaveToLog("==========================================================================================================================")

    '            _clientConfig = LoadClientProfile(xmlClientProfile)

    '            Dim intCntr As Integer = 0

    '            Dim IsFirstLine As Boolean = True

    '            Select Case _clientConfig.Input.FileExtension.ToUpper
    '                Case ".XLS", ".XLSX"
    '                    Dim dtExcel As DataTable = Nothing
    '                    Dim arrSheets As New ArrayList
    '                    LoadSheets(_inputFile, arrSheets)
    '                    LoadExcelFile(_inputFile, IIf(_clientConfig.Input.SheetName = "", arrSheets(0), _clientConfig.Input.SheetName), _clientConfig.Input.ExclColumnQuery, _clientConfig.Input.ExclWhereQuery, dtExcel)
    '                    For Each rwExcel As DataRow In dtExcel.Rows
    '                        AddData("", rwExcel, IsFirstLine, dtExcel.DefaultView.Count, status, _action, intCntr)
    '                        inputTotalRecords += 1
    '                    Next
    '                Case Else
    '                    Dim strLines() As String = File.ReadAllLines(_inputFile)
    '                    For Each strLine As String In strLines
    '                        AddData(strLine, Nothing, IsFirstLine, strLines.Length, status, _action, intCntr)
    '                        inputTotalRecords += 1
    '                    Next
    '                    'Using sr As New StreamReader(_inputFile)
    '                    '    Do While Not sr.EndOfStream
    '                    '        Dim strLine As String = sr.ReadLine
    '                    '        AddData(strLine, Nothing, IsFirstLine, 0, status, _action, intCntr)
    '                    '        inputTotalRecords += 1
    '                    '    Loop
    '                    '    sr.Close()
    '                    '    sr.Dispose()
    '                    'End Using
    '            End Select

    '            SaveToLog("Input file: " + _inputFile)
    '            SaveToLog("Success: " + inputSuccessCnt.ToString("N0") & "   Failed: " + inputFailedCnt.ToString("N0"))
    '            SaveToLog("Total: " + inputTotalRecords.ToString("N0"))
    '        Catch ex As Exception
    '            sbLog.AppendLine("InputParseData(): Runtime error catched " & ex.Message)
    '            SaveToLog("InputParseData(): Runtime error catched " & ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub AddData(ByVal strLine As String, ByVal rwExcel As DataRow, ByRef IsFirstLine As Boolean, ByVal inTotalRecords As Integer,
    '                        ByRef status As String, ByRef _action As Action, ByRef intCntr As Integer)
    '        Try
    '            If strLine = "" And rwExcel Is Nothing Then Return

    '            Dim IsAddRow As Boolean = True

    '            If _clientConfig.Input.IsWithHeader Then
    '                If IsFirstLine Then
    '                    IsFirstLine = False
    '                    IsAddRow = False
    '                End If
    '            End If

    '            If IsAddRow Then
    '                If strLine <> "" Then
    '                    If AddDataRow_TxtFile(_clientConfig, strLine) Then
    '                        'intSuccess += 1
    '                        inputSuccessCnt += 1
    '                    Else
    '                        'intFailed += 1
    '                        inputFailedCnt += 1
    '                    End If
    '                ElseIf Not rwExcel Is Nothing Then
    '                    If AddDataRow_Excel(_clientConfig, rwExcel) Then
    '                        inputSuccessCnt += 1
    '                    Else
    '                        inputFailedCnt += 1
    '                    End If
    '                End If
    '            End If
    '        Catch ex As Exception
    '            sbLog.AppendLine(String.Format("{0}(): Line {1}, Runtime error catched {2}", "AddData", IIf(strLine = "", rwExcel(0), strLine.Substring(0, 20)), ex.Message))
    '            SaveToLog(String.Format("{0}(): Line {1}, Runtime error catched {2}", "AddData", IIf(strLine = "", rwExcel(0), strLine.Substring(0, 20)), ex.Message))
    '            inputFailedCnt += 1
    '        End Try

    '        intCntr += 1
    '        CurrentStatus = String.Format("{0} of {1}", intCntr.ToString("N0"), inTotalRecords.ToString("N0"))

    '        status = CurrentStatus
    '        _action.Invoke()
    '    End Sub

    '    Private Function AddDataRow_TxtFile(ByVal clientConfig As ClientConfig, ByVal strLine As String) As Boolean
    '        Dim colName As String = ""
    '        Try
    '            Dim rwData As DataRow = _dtInputData.NewRow
    '            For Each colData As DataColumn In _dtInputData.Columns
    '                colName = colData.ColumnName
    '                If colData.ColumnName <> "RecordID" Then
    '                    Dim response
    '                    Dim _fieldElement = GetInputColumnAttribute(clientConfig, colData.ColumnName)
    '                    Dim value As String = ""

    '                    If clientConfig.Input.ParserType = ParserDLL.ParserType.FixLen Then
    '                        Try
    '                            value = strLine.Substring(_fieldElement.StartPosition, _fieldElement.DataLength)
    '                        Catch ex As Exception
    '                            value = strLine.Substring(_fieldElement.StartPosition)
    '                        End Try
    '                    ElseIf clientConfig.Input.ParserType = ParserDLL.ParserType.Delimited Then
    '                        Try
    '                            value = strLine.Split(clientConfig.Input.Delimiter)(_fieldElement.IndexPosition)
    '                        Catch ex As Exception
    '                            value = "Error"
    '                        End Try
    '                    End If

    '                    If _fieldElement.Replace <> "" Then
    '                        response = GetReplaceByID(_clientConfig.Replaces, _fieldElement.Replace)
    '                        If Not response Is Nothing Then value = ReplaceValue(response, value)
    '                    End If

    '                    If _fieldElement.Concatenate <> "" Then
    '                        response = GetConcatenateByID(_clientConfig.Concatenates, _fieldElement.Concatenate)
    '                        If Not response Is Nothing Then value = ConcatenatedValue(response, rwData)
    '                    End If

    '                    rwData(colData.ColumnName) = value
    '                End If
    '            Next
    '            _dtInputData.Rows.Add(rwData)
    '            Return True
    '        Catch ex As Exception
    '            sbLog.Append("AddDataRow_TxtFile(): " + colName + " - " + ex.Message)
    '            SaveToLog(String.Format("{0}(): Line {1}, Field {2}, Runtime error catched {3}", "AddDataRow_TxtFile", strLine.Substring(0, 20), colName, ex.Message))
    '            Return False
    '        End Try
    '    End Function

    '    Private Function AddDataRow_Excel(ByVal clientConfig As ClientConfig, ByVal rwExcel As DataRow) As Boolean
    '        Try
    '            Dim rwData As DataRow = _dtInputData.NewRow
    '            For Each colData As DataColumn In _dtInputData.Columns
    '                If colData.ColumnName <> "RecordID" Then
    '                    Dim _fieldElement = GetInputColumnAttribute(clientConfig, colData.ColumnName)
    '                    rwData(colData.ColumnName) = rwExcel(colData.ColumnName)
    '                End If
    '            Next
    '            _dtInputData.Rows.Add(rwData)
    '            Return True
    '        Catch ex As Exception
    '            SaveToLog(String.Format("{0}(): Line {1}, Runtime error catched {2}", "AddDataRow_Excel", rwExcel(0), ex.Message))
    '            Return False
    '        End Try
    '    End Function

    '    Public Function DLLProcessBeforeGeneration(ByVal oObject As System.Object, ByVal outputFolder As String,
    '                                           ByRef dtData As DataTable, ByRef ErrMsg As String,
    '                                           ByRef status As String, ByRef _action As Action,
    '                                           Optional inputFile As String = "") As Boolean
    '        If oObject.ProcessBeforeGeneration(outputFolder, dtData, status, _action, inputFile) Then
    '            ErrMsg = oObject.ErrorMessage
    '            Return True
    '        Else
    '            ErrMsg = oObject.ErrorMessage
    '            Return False
    '        End If
    '    End Function

    '    Public Function DLLProcessAfterGeneration(ByVal oObject As System.Object, ByVal outputFolder As String,
    '                                          ByRef dtData As DataTable, ByRef ErrMsg As String,
    '                                          ByRef status As String, ByRef _action As Action,
    '                                          Optional extension As String = "pdf", Optional ByVal fileName As String = "") As Boolean
    '        If oObject.ProcessAfterGeneration(outputFolder, dtData, status, _action, "pdf", fileName) Then
    '            ErrMsg = oObject.ErrorMessage
    '            Return True
    '        Else
    '            ErrMsg = oObject.ErrorMessage
    '            Return False
    '        End If
    '    End Function

    '    Public Sub GenerateOutput(ByVal clientConfig As ClientConfig, ByVal dtData As DataTable, ByRef status As String, ByRef _action As Action)
    '        If dtData Is Nothing Then
    '            sbLog.AppendLine("GenerateOutput(): Table data is nothing")
    '            Return
    '        End If

    '        Dim sbLine As New System.Text.StringBuilder
    '        Dim sbData As New System.Text.StringBuilder
    '        Dim _dtOutputs As New List(Of DataTable)

    '        Dim intCntr As Integer = 0
    '        Dim errMsg As String = ""

    '        Dim _sbHeader As New System.Text.StringBuilder
    '        Dim dtFileForMerge As DataTable

    '        For Each _output As Output In clientConfig.Outputs
    '            'create output table
    '            Dim _dtOutput As New DataTable

    '            For Each outputFieldElements As OutputFieldElement In _output.OutputFieldElements
    '                _dtOutput.Columns.Add(outputFieldElements.ID, GetType(String))

    '                If _output.ParserType = ParserType.FixLen Then
    '                    _sbHeader.Append(outputFieldElements.ID)
    '                Else
    '                    If _sbHeader.ToString = "" Then
    '                        _sbHeader.Append(outputFieldElements.ID)
    '                    Else
    '                        _sbHeader.Append(_output.Delimiter & outputFieldElements.ID)
    '                    End If
    '                End If
    '            Next

    '            Dim _pdf As EPDFSharp.PDF
    '            If _output.Grouping Is Nothing Then
    '                '_sbHeader.Length = 0

    '                _dtOutput.TableName = Path.GetFileNameWithoutExtension(_inputFile)

    '                GenerateOutputTable(_output, dtData, intCntr, _dtOutput, _dtOutputs, status, _action)

    '                _dtOutputs(_dtOutputs.Count - 1).TableName = Path.GetFileNameWithoutExtension(_inputFile)


    '                If Not _output.PDFOutput.Contains(",") Then
    '                    Dim response = GetPDFOutputByID(clientConfig.PDFOutputs, _output.PDFOutput)
    '                    If Not response Is Nothing Then
    '                        _pdf = New EPDFSharp.PDF
    '                        _pdf.GeneratePDF(_dtOutputs(_dtOutputs.Count - 1), response, _OutputFile)
    '                        If _pdf.ProcessLog <> "" Then sbLog.AppendLine(_pdf.ProcessLog)
    '                    End If
    '                Else
    '                    _pdf = New EPDFSharp.PDF
    '                    For Each _pdfOutputID As String In _output.PDFOutput.Split(",")
    '                        Dim response = GetPDFOutputByID(clientConfig.PDFOutputs, _pdfOutputID)
    '                        If Not response Is Nothing Then
    '                            _pdf.GeneratePDF(_dtOutputs(_dtOutputs.Count - 1), response, _OutputFile)
    '                            If _pdf.ProcessLog <> "" Then sbLog.AppendLine(_pdf.ProcessLog)
    '                        End If
    '                    Next
    '                End If

    '                'If _output.IsWithHeader Then
    '                '    For Each colOutput As DataColumn In _dtOutput.Columns
    '                '        If _output.ParserType = ParserType.FixLen Then
    '                '            sbLine.Append(colOutput.ColumnName)
    '                '        Else
    '                '            If sbLine.ToString = "" Then
    '                '                sbLine.Append(colOutput.ColumnName)
    '                '            Else
    '                '                sbLine.Append(_output.Delimiter & colOutput.ColumnName)
    '                '            End If
    '                '        End If
    '                '    Next

    '                '    sbData.Append(sbLine.ToString)
    '                '    sbLine.Length = 0
    '                'End If

    '                'For Each rwOutput As DataRow In _dtOutput.Rows
    '                For Each rwOutput As DataRow In _dtOutputs(_dtOutputs.Count - 1).Rows
    '                    For Each colOutput As DataColumn In _dtOutputs(_dtOutputs.Count - 1).Columns
    '                        Dim IsDisplay As Short = GetOutputColumnAttribute(_output, colOutput.ColumnName).IsDisplay

    '                        If _output.ParserType = ParserType.FixLen Then
    '                            If IsDisplay = 1 Then sbLine.Append(rwOutput(colOutput).ToString)
    '                        Else
    '                            If sbLine.ToString = "" Then
    '                                If IsDisplay = 1 Then sbLine.Append(rwOutput(colOutput).ToString)
    '                            Else
    '                                If IsDisplay = 1 Then sbLine.Append(_output.Delimiter & rwOutput(colOutput).ToString)
    '                            End If
    '                        End If
    '                    Next

    '                    sbData.Append(sbLine.ToString & vbNewLine)
    '                    sbLine.Length = 0
    '                Next
    '            Else
    '                dtFileForMerge = New DataTable
    '                dtFileForMerge.Columns.Add("ID", GetType(String))
    '                dtFileForMerge.Columns.Add("File", GetType(String))
    '                dtFileForMerge.Columns.Add("OutputFileName", GetType(String))
    '                For Each groupCondition As GroupingCondition In _output.Grouping.GroupingConditions
    '                    '_sbHeader.Length = 0

    '                    'Dim _dtDistinct As DataTable = dtData.DefaultView.ToTable(True, New String() {groupCondition.FilterExpression}.ToArray)

    '                    Dim colNames As New List(Of String)
    '                    For Each col As String In groupCondition.FilterExpression.Split(",")
    '                        colNames.Add(col)
    '                    Next

    '                    Dim _dtDistinct As DataTable = dtData.DefaultView.ToTable(True, colNames.ToArray)

    '                    Dim sbFileName As New System.Text.StringBuilder
    '                    Dim sbExpression As New System.Text.StringBuilder


    '                    For Each _rwDistinct As DataRow In _dtDistinct.Rows
    '                        Dim colValues As New List(Of String)

    '                        sbExpression.Length = 0
    '                        For Each col As String In colNames
    '                            If sbExpression.ToString = "" Then
    '                                sbExpression.Append(String.Format("{0}='{1}'", col, _rwDistinct(col).ToString.Trim))
    '                            Else
    '                                sbExpression.Append(String.Format(" AND {0}='{1}'", col, _rwDistinct(col).ToString.Trim))
    '                            End If

    '                            colValues.Add(_rwDistinct(col).ToString.Trim)
    '                        Next

    '                        Dim _dtGroup As DataTable = dtData.Select(sbExpression.ToString).CopyToDataTable
    '                        If groupCondition.SortExpression <> "" Then _dtGroup.DefaultView.Sort = groupCondition.SortExpression

    '                        '_dtOutputs(_dtOutputs.Count - 1).TableName = Path.GetFileNameWithoutExtension(_inputFile)
    '                        _dtOutput.TableName = Path.GetFileNameWithoutExtension(_inputFile)

    '                        GenerateOutputTable(_output, _dtGroup, intCntr, _dtOutput, _dtOutputs, status, _action)

    '                        For Each rwOutput As DataRow In _dtOutput.Rows
    '                            For Each colOutput As DataColumn In _dtOutput.Columns
    '                                Dim IsDisplay As Short = GetOutputColumnAttribute(_output, colOutput.ColumnName).IsDisplay

    '                                If _output.ParserType = ParserType.FixLen Then
    '                                    If IsDisplay = 1 Then sbLine.Append(rwOutput(colOutput).ToString)
    '                                Else
    '                                    If sbLine.ToString = "" Then
    '                                        If IsDisplay = 1 Then sbLine.Append(rwOutput(colOutput).ToString)
    '                                    Else
    '                                        If IsDisplay = 1 Then sbLine.Append(_output.Delimiter & rwOutput(colOutput).ToString)
    '                                    End If
    '                                End If
    '                            Next

    '                            sbData.Append(sbLine.ToString & vbNewLine)
    '                            sbLine.Length = 0
    '                        Next

    '                        If Not groupCondition.FileAttr Is Nothing Then
    '                            Dim gcFileName As String = groupCondition.FileAttr.FileOutputName

    '                            For i As Short = 0 To colNames.Count - 1
    '                                gcFileName = gcFileName.Replace(colNames(i), colValues(i).Replace(" ", ""))
    '                            Next

    '                            _dtOutputs(_dtOutputs.Count - 1).TableName = String.Format("{0}{1}", Path.GetFileNameWithoutExtension(_inputFile), gcFileName)

    '                            Select Case groupCondition.FileAttr.FileExtension
    '                                Case ".txt"
    '                                    File.WriteAllText(String.Format("{0}\{1}{2}{3}", _OutputFile, Path.GetFileNameWithoutExtension(_inputFile), gcFileName, groupCondition.FileAttr.FileExtension), sbData.ToString)
    '                                Case ".xls", ".xlsx"
    '                                    Dim excelFile As String = String.Format("{0}\{1}{2}{3}", _OutputFile, Path.GetFileNameWithoutExtension(_inputFile), gcFileName, groupCondition.FileAttr.FileExtension)

    '                                    'If ExportToExcel(_dtOutput, excelFile, "data") Then
    '                                    If ExportToExcel2(_dtOutput, excelFile, errMsg) Then
    '                                        'SharedFunction.ShowInfoMessage("Exporting process is complete")
    '                                    Else
    '                                        'SharedFunction.ShowInfoMessage("Failed to export data")
    '                                    End If
    '                            End Select
    '                        End If

    '                        If Not _output.PDFOutput.Contains(",") Then
    '                            Dim response = GetPDFOutputByID(clientConfig.PDFOutputs, _output.PDFOutput)
    '                            If Not response Is Nothing Then
    '                                _pdf = New EPDFSharp.PDF
    '                                _pdf.GeneratePDF(_dtOutputs(_dtOutputs.Count - 1), response, _OutputFile)
    '                                If _pdf.ProcessLog <> "" Then sbLog.AppendLine(_pdf.ProcessLog)
    '                            End If
    '                        Else
    '                            _pdf = New EPDFSharp.PDF
    '                            Dim outputFile As String = ""
    '                            For Each _pdfOutputID As String In _output.PDFOutput.Split(",")
    '                                Dim response = GetPDFOutputByID(clientConfig.PDFOutputs, _pdfOutputID)
    '                                If Not response Is Nothing Then
    '                                    _pdf.GeneratePDF(_dtOutputs(_dtOutputs.Count - 1), response, _OutputFile,, outputFile)
    '                                    If _pdf.ProcessLog <> "" Then
    '                                        sbLog.AppendLine(_pdf.ProcessLog)
    '                                    Else
    '                                        Dim rw As DataRow = dtFileForMerge.NewRow
    '                                        rw(0) = response.ID
    '                                        rw(1) = outputFile
    '                                        rw(2) = response.OutputFileName
    '                                        dtFileForMerge.Rows.Add(rw)
    '                                    End If
    '                                End If
    '                            Next
    '                        End If

    '                        sbData.Length = 0
    '                        _dtOutput.Clear()
    '                    Next
    '                Next

    '                If Not dtFileForMerge Is Nothing Then
    '                    Dim dtFileForMergeUnique As DataTable = dtFileForMerge.DefaultView.ToTable(True, "ID", "OutputFileName")
    '                    For Each rwFileForMergeUnique As DataRow In dtFileForMergeUnique.Rows
    '                        Dim files As New List(Of String)
    '                        For Each rwFiles As DataRow In dtFileForMerge.Select("ID='" & rwFileForMergeUnique(0) & "' AND OutputFileName='" & rwFileForMergeUnique("OutputFileName") & "'")
    '                            files.Add(rwFiles(1))
    '                        Next

    '                        _pdf.MergeFiles(files.ToArray, String.Format("{0}\{1}_{2}{3}.pdf", _OutputFile, Path.GetFileNameWithoutExtension(_inputFile), Now.ToString("hhmmss"), rwFileForMergeUnique("OutputFileName")))
    '                    Next
    '                End If
    '            End If

    '            If Not _pdf Is Nothing Then
    '                _pdf.Housekeeping()
    '                _pdf = Nothing
    '            End If

    '            Try
    '                If Not _output.FileAttr Is Nothing Then
    '                    Select Case _output.FileAttr.FileExtension
    '                        Case ".txt"
    '                            If _output.IsWithHeader Then
    '                                File.WriteAllText(String.Format("{0}\{1}{2}{3}", _OutputFile, Path.GetFileNameWithoutExtension(_inputFile), _output.FileAttr.FileOutputName, _output.FileAttr.FileExtension), _sbHeader.ToString & vbNewLine & sbData.ToString)
    '                            Else
    '                                File.WriteAllText(String.Format("{0}\{1}{2}{3}", _OutputFile, Path.GetFileNameWithoutExtension(_inputFile), _output.FileAttr.FileOutputName, _output.FileAttr.FileExtension), sbData.ToString)
    '                            End If
    '                        Case ".xls", ".xlsx"
    '                            Dim excelFile As String = String.Format("{0}\{1}{2}{3}", _OutputFile, Path.GetFileNameWithoutExtension(_inputFile), _output.FileAttr.FileOutputName, _output.FileAttr.FileExtension)

    '                            'If ExportToExcel(_dtOutput, excelFile, "data") Then
    '                            If ExportToExcel2(_dtOutput, excelFile, errMsg) Then
    '                                'SharedFunction.ShowInfoMessage("Exporting process is complete")
    '                            Else
    '                                'SharedFunction.ShowInfoMessage("Failed to export data")
    '                            End If
    '                    End Select
    '                End If
    '            Catch ex As Exception
    '                sbLog.AppendLine("GenerateOutput(): Error in saving file. Runtime error catched " & ex.Message)
    '            End Try
    '        Next

    '        _dtOutputData = _dtOutputs.ToArray
    '    End Sub

    '    Private Sub GenerateOutputTable(ByVal _output As Output, ByVal dtData As DataTable, ByRef intCntr As Integer,
    '                                ByRef _dtOutput As DataTable, ByRef _dtOutputs As List(Of DataTable),
    '                                ByRef status As String, ByRef _action As Action)
    '        Dim response
    '        intCntr = 0

    '        For Each rw As DataRowView In dtData.DefaultView
    '            Dim _IsExclude As Boolean = False
    '            Dim rwOutput As DataRow = _dtOutput.NewRow

    '            For Each outputFieldElements As OutputFieldElement In _output.OutputFieldElements
    '                Dim _fieldElement = GetOutputColumnAttribute(_output, outputFieldElements.ID)
    '                Dim _value As String = GetFieldValue(_output, outputFieldElements.ID, rw.Row, _dtOutput.TableName)

    '                If _fieldElement.Replace <> "" Then
    '                    response = GetReplaceByID(_clientConfig.Replaces, _fieldElement.Replace)
    '                    If Not response Is Nothing Then _value = ReplaceValue(response, rw.Row)
    '                End If

    '                rwOutput(outputFieldElements.ID) = _value
    '            Next

    '            _dtOutput.Rows.Add(rwOutput)
    '        Next

    '        Dim _dt As DataTable = _dtOutput.Copy

    '        For Each rw As DataRow In _dt.Rows
    '            Dim _IsExclude As Boolean = False

    '            For Each outputFieldElements As OutputFieldElement In _output.OutputFieldElements

    '                If Not IsDBNull(rw(outputFieldElements.ID)) Then
    '                    Dim _fieldElement = GetOutputColumnAttribute(_output, outputFieldElements.ID)
    '                    Dim _value As String = rw(outputFieldElements.ID)

    '                    If _fieldElement.Concatenate <> "" Then
    '                        response = GetConcatenateByID(_clientConfig.Concatenates, _fieldElement.Concatenate)
    '                        If Not response Is Nothing Then _value = ConcatenatedValue(response, rw)
    '                    End If

    '                    'If _fieldElement.Exclusion <> "" Then
    '                    '    Dim response = GetObjectByID(_clientConfig.Exclusions, _fieldElement.Exclusion)
    '                    '    If Not response Is Nothing Then
    '                    '        _IsExclude = IsExcludeRow(response, rw)
    '                    '    End If
    '                    'End If

    '                    'If Not _IsExclude Then
    '                    '    rw(outputFieldElements.ID) = _value
    '                    '    rw.AcceptChanges()
    '                    'Else
    '                    '    rw.Delete()
    '                    'End If

    '                    rw(outputFieldElements.ID) = _value
    '                    rw.AcceptChanges()
    '                End If
    '            Next

    '            'If Not _IsExclude Then
    '            '    _dtOutput.Rows.Add(rwOutput)
    '            '    'Else
    '            '    'Console.Write("TEST")
    '            'End If

    '            intCntr += 1
    '            CurrentStatus = String.Format("{0} of {1}", intCntr.ToString("N0"), dtData.DefaultView.Count.ToString("N0"))

    '            status = CurrentStatus
    '            _action.Invoke()
    '        Next

    '        _dt.AcceptChanges()

    '        response = GetObjectByID(_clientConfig.Exclusions, _output.Exclusion)
    '        If Not response Is Nothing Then
    '            Dim filterCriteria As String = GetExlusions(response)
    '            If filterCriteria <> "" Then
    '                If _dt.Select(filterCriteria).Length > 0 Then
    '                    Dim _filteredTable As DataTable = _dt.Select(filterCriteria).CopyToDataTable
    '                    _dtOutputs.Add(_filteredTable)
    '                Else
    '                    _dtOutputs.Add(_dt)
    '                End If
    '            Else
    '                _dtOutputs.Add(_dt)
    '            End If
    '        Else
    '            _dtOutputs.Add(_dt)
    '        End If

    '        'Next
    '    End Sub

    '    'Private Sub GenerateOutputTable(ByVal _output As Output, ByVal dtData As DataTable, ByRef intCntr As Integer,
    '    '                            ByRef _dtOutput As DataTable, ByRef _dtOutputs As List(Of DataTable),
    '    '                            ByRef status As String, ByRef _action As Action)
    '    '    'For Each _dt As DataTable In dtData
    '    '    intCntr = 0

    '    '    For Each rw As DataRowView In dtData.DefaultView
    '    '        Dim _IsExclude As Boolean = False
    '    '        Dim rwOutput As DataRow = _dtOutput.NewRow

    '    '        For Each outputFieldElements As OutputFieldElement In _output.OutputFieldElements
    '    '            Dim _fieldElement = GetOutputColumnAttribute(_output, outputFieldElements.ID)
    '    '            Dim _value As String = GetFieldValue(_output, outputFieldElements.ID, rw.Row, _dtOutput.TableName)

    '    '            If _fieldElement.Concatenate <> "" Then
    '    '                Dim response = GetConcatenateByID(_clientConfig.Concatenates, _fieldElement.Concatenate)
    '    '                If Not response Is Nothing Then _value = ConcatenatedValue(response, rw.Row)
    '    '            End If

    '    '            If _fieldElement.Replace <> "" Then
    '    '                Dim response = GetReplaceByID(_clientConfig.Replaces, _fieldElement.Replace)
    '    '                If Not response Is Nothing Then _value = ReplaceValue(response, rw.Row)
    '    '            End If

    '    '            If outputFieldElements.Exclusion <> "" Then
    '    '                If Not _IsExclude Then _IsExclude = IsExclude(_value, outputFieldElements.Exclusion, _output.Exclusion)
    '    '            End If

    '    '            rwOutput(outputFieldElements.ID) = _value
    '    '        Next

    '    '        If Not _IsExclude Then
    '    '            _dtOutput.Rows.Add(rwOutput)
    '    '            'Else
    '    '            'Console.Write("TEST")
    '    '        End If

    '    '        intCntr += 1
    '    '        CurrentStatus = String.Format("{0} of {1}", intCntr.ToString("N0"), dtData.DefaultView.Count.ToString("N0"))

    '    '        status = CurrentStatus
    '    '        _action.Invoke()
    '    '    Next

    '    '    Dim _dt As DataTable = _dtOutput.Copy

    '    '    _dtOutputs.Add(_dt)
    '    '    'Next
    '    'End Sub

    '    'Private Function IsExclude(ByVal data As String, ByVal exclusionParam As String, ByVal exclusion As Exclusion) As Boolean
    '    '    For Each param As String In exclusionParam.Split(",")
    '    '        For Each _exclusionCondition As ExclusionCondition In exclusion.ExclusionConditions
    '    '            If _exclusionCondition.ID = param Then
    '    '                Select Case CType(_exclusionCondition.Expression, FilterExpression)
    '    '                    Case FilterExpression.Contains
    '    '                        If data.Contains(_exclusionCondition.Value) Then Return True
    '    '                    Case FilterExpression.EqualsTo
    '    '                        If _exclusionCondition.Trim Then
    '    '                            If _exclusionCondition.Value = Trim(data) Then Return True
    '    '                        Else
    '    '                            If _exclusionCondition.Value = data Then Return True
    '    '                        End If
    '    '                    Case FilterExpression.GreaterThanAndEqualsTo
    '    '                        If CInt(data) > CInt(_exclusionCondition.Value) Then Return True
    '    '                    Case FilterExpression.LessThanAndEqualsTo
    '    '                        If CInt(data) < CInt(_exclusionCondition.Value) Then Return True
    '    '                    Case FilterExpression.NotEqualsTo
    '    '                        If _exclusionCondition.Trim Then
    '    '                            If _exclusionCondition.Value <> Trim(data) Then Return True
    '    '                        Else
    '    '                            If _exclusionCondition.Value <> data Then Return True
    '    '                        End If
    '    '                End Select
    '    '            End If
    '    '        Next
    '    '    Next

    '    '    Return False
    '    'End Function

    '    Private Overloads Function ConcatenatedValue(ByVal concatenate As Concatenate, ByVal rw As DataRow) As String
    '        Dim sbResult As New System.Text.StringBuilder
    '        Dim fieldID As String = ""

    '        Try
    '            For Each fieldElement As ConcatenateFieldElement In concatenate.FieldElements
    '                fieldID = fieldElement.ID

    '                'If fieldID = "EXPDATE1" Then
    '                '    Console.Write("TEST")
    '                'End If

    '                'If concatenate.ID = "002" Then
    '                '    Console.Write("TEST")
    '                'End If

    '                If fieldElement.SubStr = "" And fieldElement.DefaultValue <> "" Then
    '                    sbResult.Append(fieldElement.DefaultValue)
    '                ElseIf fieldElement.SubStr = "" And fieldElement.DefaultValue = "" Then
    '                    sbResult.Append(rw(fieldElement.RefID).ToString.Trim)
    '                Else
    '                    If Not fieldElement.SubStr.Contains(",") Then
    '                        sbResult.Append(rw(fieldElement.RefID).ToString.Trim.Substring(fieldElement.SubStr))
    '                    Else
    '                        sbResult.Append(rw(fieldElement.RefID).ToString.Trim.Substring(fieldElement.SubStr.Split(",")(0), fieldElement.SubStr.Split(",")(1)))
    '                    End If
    '                End If
    '            Next
    '        Catch ex As Exception
    '            sbLog.AppendLine("ConcatenatedValue(): Failed in ID " & fieldID & ". Runtime error catched " & ex.Message)
    '        End Try

    '        Return sbResult.ToString
    '    End Function

    '    'Private Overloads Function ConcatenatedValue(ByVal concatenate As Concatenate, ByVal line As String) As String
    '    '    Dim sbResult As New System.Text.StringBuilder
    '    '    Dim fieldID As String = ""

    '    '    Try
    '    '        For Each fieldElement As ConcatenateFieldElement In concatenate.FieldElements
    '    '            fieldID = fieldElement.ID

    '    '            Dim _refIDFieldElement = GetInputColumnAttribute(_clientConfig, fieldElement.RefID)
    '    '            Dim value As String = ""

    '    '            If _clientConfig.Input.ParserType = ParserDLL.ParserType.FixLen Then
    '    '                Try
    '    '                    value = line.Substring(_refIDFieldElement.StartPosition, _refIDFieldElement.DataLength)
    '    '                Catch ex As Exception
    '    '                    value = line.Substring(_refIDFieldElement.StartPosition)
    '    '                End Try
    '    '            ElseIf _clientConfig.Input.ParserType = ParserDLL.ParserType.Delimited Then
    '    '                Try
    '    '                    value = line.Split(_clientConfig.Input.Delimiter)(_refIDFieldElement.IndexPosition)
    '    '                Catch ex As Exception
    '    '                    value = "Error"
    '    '                End Try
    '    '            End If

    '    '            If fieldElement.SubStr = "" And fieldElement.DefaultValue <> "" Then
    '    '                sbResult.Append(fieldElement.DefaultValue)
    '    '            ElseIf fieldElement.SubStr = "" And fieldElement.DefaultValue = "" Then
    '    '                sbResult.Append(value.Trim)
    '    '            Else
    '    '                If Not fieldElement.SubStr.Contains(",") Then
    '    '                    sbResult.Append(value.ToString.Trim.Substring(fieldElement.SubStr))
    '    '                Else
    '    '                    sbResult.Append(value.Trim.Substring(fieldElement.SubStr.Split(",")(0), fieldElement.SubStr.Split(",")(1)))
    '    '                End If
    '    '            End If
    '    '        Next
    '    '    Catch ex As Exception
    '    '        sbLog.AppendLine("ConcatenatedValue(): Failed in ID " & fieldID & ". Runtime error catched " & ex.Message)
    '    '    End Try

    '    '    Return sbResult.ToString
    '    'End Function

    '    Private Overloads Function ReplaceValue(ByVal replace As Replace, ByVal rw As DataRow) As String
    '        Dim sbResult As New System.Text.StringBuilder
    '        Dim fieldID As String = ""

    '        Try
    '            For Each fieldElement As ReplaceFieldElement In replace.FieldElements
    '                fieldID = fieldElement.ID
    '                sbResult.Append(rw(fieldElement.RefID).ToString.Trim.Replace(fieldElement.OldValue, fieldElement.NewValue))
    '            Next
    '        Catch ex As Exception
    '            sbLog.AppendLine("ReplaceValue(): Failed in ID " & fieldID & ". Runtime error catched " & ex.Message)
    '        End Try

    '        Return sbResult.ToString
    '    End Function

    '    Private Overloads Function ReplaceValue(ByVal replace As Replace, ByVal value As String) As String
    '        Dim sbResult As New System.Text.StringBuilder
    '        Dim fieldID As String = ""
    '        Try
    '            For Each fieldElement As ReplaceFieldElement In replace.FieldElements
    '                fieldID = fieldElement.ID
    '                sbResult.Append(value.Trim.Replace(fieldElement.OldValue, fieldElement.NewValue))
    '            Next
    '        Catch ex As Exception
    '            sbLog.AppendLine("ReplaceValue(): Failed in ID " & fieldID & ". Runtime error catched " & ex.Message)
    '        End Try

    '        Return sbResult.ToString
    '    End Function

    '    'Private Function IsExcludeRow(ByVal exclusion As Exclusion, ByVal rw As DataRow) As Boolean
    '    '    Dim fieldID As String = ""

    '    '    Dim Conditions As New List(Of Boolean)

    '    '    Try
    '    '        For Each fieldElement As ExclusionFieldElement In exclusion.FieldElements
    '    '            Dim bln As Boolean = False

    '    '            fieldID = fieldElement.ID
    '    '            Select Case CType(fieldElement.FilterExpression, FilterExpression)
    '    '                Case FilterExpression.Contains
    '    '                    If rw(fieldElement.RefID).ToString.Trim.Contains(fieldElement.Value) Then bln = True
    '    '                Case FilterExpression.EqualsTo
    '    '                    If fieldElement.DataType = "String" Then
    '    '                        If rw(fieldElement.RefID).ToString.Trim = fieldElement.Value Then bln = True
    '    '                    ElseIf fieldElement.DataType = "Number" Then
    '    '                        If CInt(rw(fieldElement.RefID)) = CInt(fieldElement.Value) Then bln = True
    '    '                    End If
    '    '                Case FilterExpression.LessThanAndEqualsTo
    '    '                    If CInt(rw(fieldElement.RefID)) <= CInt(fieldElement.Value) Then bln = True
    '    '                Case FilterExpression.GreaterThanAndEqualsTo
    '    '                    If CInt(rw(fieldElement.RefID)) >= CInt(fieldElement.Value) Then bln = True
    '    '                Case FilterExpression.NotEqualsTo
    '    '                    If fieldElement.DataType = "String" Then
    '    '                        If rw(fieldElement.RefID).ToString.Trim <> fieldElement.Value Then bln = True
    '    '                    ElseIf fieldElement.DataType = "Number" Then
    '    '                        If CInt(rw(fieldElement.RefID)) <> CInt(fieldElement.Value) Then bln = True
    '    '                    End If
    '    '            End Select

    '    '            Conditions.Add(bln)
    '    '        Next

    '    '        For Each condition As Boolean In Conditions
    '    '            If Not condition Then Return False
    '    '        Next

    '    '        Return True
    '    '    Catch ex As Exception
    '    '        sbLog.AppendLine("IsExcludeRow(): Failed in ID " & fieldID & ". Runtime error catched " & ex.Message)
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    Private Function GetExlusions(ByVal exclusion As Exclusion) As String
    '        Dim sb As New System.Text.StringBuilder
    '        Dim sbResult As New System.Text.StringBuilder
    '        Dim fieldID As String = ""

    '        Try
    '            Dim objts = exclusion.FieldElements.OfType(Of ExclusionFieldElement).GroupBy(Function(x) x.RefID).Select(Function(x) x.First).ToList

    '            For Each fieldElementRefID As ExclusionFieldElement In objts
    '                If sbResult.ToString <> "" Then sbResult.Append(" AND ")

    '                For Each fieldElement As ExclusionFieldElement In exclusion.FieldElements.OfType(Of ExclusionFieldElement)().Where(Function(element) element.RefID.Contains(fieldElementRefID.RefID))
    '                    If sb.ToString <> "" Then sb.Append(" OR ")

    '                    fieldID = fieldElement.ID
    '                    Select Case CType(fieldElement.FilterExpression, FilterExpression)
    '                        Case FilterExpression.EqualsTo
    '                            If fieldElement.DataType = "String" Then
    '                                sb.Append(String.Format("{0}='{1}'", fieldElement.RefID, fieldElement.Value))
    '                            ElseIf fieldElement.DataType = "Number" Then
    '                                sb.Append(String.Format("{0}={1}", fieldElement.RefID, fieldElement.Value))
    '                            End If
    '                        Case FilterExpression.NotEqualsTo
    '                            If fieldElement.DataType = "String" Then
    '                                sb.Append(String.Format("{0}<>'{1}'", fieldElement.RefID, fieldElement.Value))
    '                            ElseIf fieldElement.DataType = "Number" Then
    '                                sb.Append(String.Format("{0}<>{1}", fieldElement.RefID, fieldElement.Value))
    '                            End If
    '                        Case FilterExpression.Contains
    '                            sb.Append(String.Format("{0} LIKE '%{1}%'", fieldElement.RefID, fieldElement.Value))
    '                        Case FilterExpression.NotContains
    '                            sb.Append(String.Format("{0} NOT LIKE '%{1}%'", fieldElement.RefID, fieldElement.Value))
    '                        Case FilterExpression.LessThanAndEqualsTo
    '                            sb.Append(String.Format("{0}<={1}", fieldElement.RefID, fieldElement.Value))
    '                        Case FilterExpression.GreaterThanAndEqualsTo
    '                            sb.Append(String.Format("{0}>={1}", fieldElement.RefID, fieldElement.Value))
    '                    End Select
    '                Next

    '                sbResult.Append(sb.ToString)
    '                sb.Length = 0
    '            Next

    '            'Try
    '            '    For Each fieldElement As ExclusionFieldElement In exclusion.FieldElements
    '            '        If sbResult.ToString <> "" Then sbResult.Append(" AND ")

    '            '        fieldID = fieldElement.ID
    '            '        Select Case CType(fieldElement.FilterExpression, FilterExpression)
    '            '            Case FilterExpression.EqualsTo
    '            '                If fieldElement.DataType = "String" Then
    '            '                    sbResult.Append(String.Format("{0}='{1}'", fieldElement.RefID, fieldElement.Value))
    '            '                ElseIf fieldElement.DataType = "Number" Then
    '            '                    sbResult.Append(String.Format("{0}={1}", fieldElement.RefID, fieldElement.Value))
    '            '                End If
    '            '            Case FilterExpression.NotEqualsTo
    '            '                If fieldElement.DataType = "String" Then
    '            '                    sbResult.Append(String.Format("{0}<>'{1}'", fieldElement.RefID, fieldElement.Value))
    '            '                ElseIf fieldElement.DataType = "Number" Then
    '            '                    sbResult.Append(String.Format("{0}<>{1}", fieldElement.RefID, fieldElement.Value))
    '            '                End If
    '            '            Case FilterExpression.Contains
    '            '                sbResult.Append(String.Format("{0} LIKE '%{1}%'", fieldElement.RefID, fieldElement.Value))
    '            '            Case FilterExpression.NotContains
    '            '                sbResult.Append(String.Format("{0} NOT LIKE '%{1}%'", fieldElement.RefID, fieldElement.Value))
    '            '            Case FilterExpression.LessThanAndEqualsTo
    '            '                sbResult.Append(String.Format("{0}<={1}", fieldElement.RefID, fieldElement.Value))
    '            '            Case FilterExpression.GreaterThanAndEqualsTo
    '            '                sbResult.Append(String.Format("{0}>={1}", fieldElement.RefID, fieldElement.Value))
    '            '        End Select
    '            '    Next

    '            Return sbResult.ToString
    '        Catch ex As Exception
    '            sbLog.AppendLine("GetExlusions(): Failed in ID " & fieldID & ". Runtime error catched " & ex.Message)
    '            Return ""
    '        End Try
    '    End Function

    '    Private Function ExportToExcel(ByVal dt As DataTable, ByVal excelFile As String, ByVal sheetName As String) As Boolean
    '        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelFile & ";Extended Properties=Excel 12.0 Xml;"
    '        Dim rNumb As Integer = 0
    '        Try
    '            Using con As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(connString)
    '                con.Open()
    '                Dim strField As System.Text.StringBuilder = New System.Text.StringBuilder()
    '                For i As Integer = 0 To dt.Columns.Count - 1
    '                    If dt.Columns(i).ColumnName <> "RecordID" Then
    '                        strField.Append("[" & dt.Columns(i).ColumnName & "],")
    '                    End If
    '                Next

    '                strField = strField.Remove(strField.Length - 1, 1)
    '                Dim sqlCmd = "CREATE TABLE [" & sheetName & "] (" + strField.ToString().Replace("]", "] text") & ")"
    '                Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(sqlCmd, con)
    '                cmd.ExecuteNonQuery()
    '                For i As Integer = 0 To dt.Rows.Count - 1
    '                    Dim strValue As System.Text.StringBuilder = New System.Text.StringBuilder()
    '                    For j As Integer = 0 To dt.Columns.Count - 1
    '                        If dt.Columns(j).ColumnName <> "RecordID" Then
    '                            strValue.Append("'" & dt.DefaultView(i)(j).ToString() & "',")
    '                        End If
    '                    Next

    '                    strValue = strValue.Remove(strValue.Length - 1, 1)
    '                    cmd.CommandText = "INSERT INTO [" & sheetName & "] (" + strField.ToString() & ") VALUES (" + strValue.ToString() & ")"
    '                    cmd.ExecuteNonQuery()
    '                    rNumb = i + 1
    '                Next

    '                con.Close()
    '            End Using

    '            Return True
    '        Catch ex As Exception
    '            sbLog.AppendLine("ExportToExcel(): Runtime error catched " & ex.Message)
    '            Return False
    '        End Try
    '    End Function

    '    Public Function ExportToExcel2(ByVal dtData As DataTable, ByVal outputFile As String, ByRef errMsg As String,
    '                                Optional ByVal IsIncludeRecordID As Boolean = False,
    '                                Optional ByVal IsWithHeader As Boolean = True) As Boolean
    '        Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application()
    '        Dim xlWorkBook As Excel.Workbook
    '        Dim xlWorkSheet As Excel.Worksheet

    '        Try
    '            If xlApp Is Nothing Then
    '                errMsg = "Excel is not properly installed!"
    '                Return False
    '            End If

    '            Dim misValue As Object = System.Reflection.Missing.Value
    '            Dim chartRange As Excel.Range

    '            xlWorkBook = xlApp.Workbooks.Add(misValue)
    '            xlWorkSheet = xlWorkBook.Sheets("sheet1")

    '            Dim intRowIndex As Integer = 1
    '            Dim iCol_Adjustment As Short = 0
    '            If IsIncludeRecordID Then iCol_Adjustment = 1

    '            If IsWithHeader Then
    '                For iCol As Short = 0 To dtData.Columns.Count - 1
    '                    If iCol = 0 And dtData.Columns(iCol).ColumnName = "RecordID" Then
    '                        If IsIncludeRecordID Then
    '                            xlWorkSheet.Cells(intRowIndex, iCol + iCol_Adjustment) = dtData.Columns(iCol).ColumnName
    '                        End If
    '                    ElseIf iCol = 0 And dtData.Columns(iCol).ColumnName <> "RecordID" Then
    '                        iCol_Adjustment = 1
    '                        xlWorkSheet.Cells(intRowIndex, iCol + iCol_Adjustment) = dtData.Columns(iCol).ColumnName
    '                    Else
    '                        xlWorkSheet.Cells(intRowIndex, iCol + iCol_Adjustment) = dtData.Columns(iCol).ColumnName
    '                    End If
    '                Next

    '                intRowIndex += 1
    '            End If

    '            Dim intRecordCntr As Integer = 1

    '            For Each rw As DataRow In dtData.Rows
    '                For iCol As Short = 0 To dtData.Columns.Count - 1
    '                    Select Case dtData.Columns(iCol).ColumnName.ToUpper
    '                        Case "RECORDID"
    '                            If IsIncludeRecordID Then _
    '                            xlWorkSheet.Cells(intRowIndex, iCol + iCol_Adjustment) = rw(dtData.Columns(iCol).ColumnName).ToString
    '                        Case "EXPIRYDATE", "EXPIRY_DATE", "REFNO"
    '                            xlWorkSheet.Cells(intRowIndex, iCol + iCol_Adjustment) = "'" & rw(dtData.Columns(iCol).ColumnName).ToString
    '                            xlWorkSheet.Cells(intRowIndex, iCol + iCol_Adjustment).NumberFormat = "@"
    '                        Case Else
    '                            xlWorkSheet.Cells(intRowIndex, iCol + iCol_Adjustment) = rw(dtData.Columns(iCol).ColumnName).ToString
    '                            xlWorkSheet.Cells(intRowIndex, iCol + iCol_Adjustment).NumberFormat = "@"
    '                    End Select

    '                    xlWorkSheet.Cells(intRowIndex, iCol + iCol_Adjustment).EntireColumn.AutoFit()
    '                Next

    '                intRowIndex += 1
    '                intRecordCntr += 1
    '            Next

    '            Dim _xlFileFormat As Excel.XlFileFormat = Excel.XlFileFormat.xlExcel8
    '            If Path.GetExtension(outputFile).ToUpper = ".XLSX" Then _xlFileFormat = Excel.XlFileFormat.xlWorkbookNormal

    '            xlWorkBook.SaveAs(outputFile, _xlFileFormat, misValue, misValue, misValue, misValue,
    '         Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
    '            xlWorkBook.Close(True, misValue, misValue)
    '            xlApp.Quit()
    '            System.Threading.Thread.Sleep(1000)

    '            Return True
    '        Catch ex As Exception
    '            'MsgBox(ex.Message)
    '            sbLog.AppendLine("ExportToExcel(): Runtime error catched " & ex.Message)

    '            Return False
    '        Finally
    '            releaseObject(xlWorkSheet)
    '            releaseObject(xlWorkBook)
    '            releaseObject(xlApp)
    '        End Try

    '    End Function

    '    Private Sub releaseObject(ByVal obj As Object)
    '        Try
    '            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
    '            obj = Nothing
    '        Catch ex As Exception
    '            obj = Nothing
    '        Finally
    '            GC.Collect()
    '        End Try
    '    End Sub

    '#Region " Misc "

    '    Private Function GetFieldValue(ByVal output As Output, ByVal ID As String, ByVal rw As DataRow, ByVal fileName As String) As String
    '        Dim _fieldElementInput = GetInputColumnAttribute(_clientConfig, ID)
    '        Dim _fieldElementOutput = GetOutputColumnAttribute(output, ID)

    '        If ID = "EXPIRYDATE1" Then
    '            Console.Write("TEST")
    '        End If

    '        If output.ParserType = ParserType.FixLen Then
    '            Try
    '                If _fieldElementOutput.DefaultValue = "" Then
    '                    If rw.Table.Columns.Contains(ID) Then
    '                        Dim intDataLength As Integer = _fieldElementOutput.DataLength
    '                        If intDataLength = 0 Then intDataLength = _fieldElementInput.DataLength
    '                        If intDataLength > 0 Then
    '                            Return rw(ID).ToString.Substring(0, intDataLength)
    '                        Else
    '                            Return rw(ID).ToString()
    '                        End If
    '                    Else
    '                        Return ""
    '                    End If
    '                ElseIf _fieldElementOutput.DefaultValue = "Now()" And _fieldElementOutput.DataType = "DateTime" Then
    '                    Return Now.ToString(_fieldElementOutput.StringFormat)
    '                ElseIf _fieldElementOutput.DefaultValue = "FileName()" Then
    '                    If _fieldElementOutput.FilePathType = "1" Then
    '                        Return Path.GetFileName(fileName)
    '                    ElseIf _fieldElementOutput.FilePathType = "2" Then
    '                        Return Path.GetFileNameWithoutExtension(fileName)
    '                    End If
    '                ElseIf _fieldElementOutput.DefaultValue <> "" And _fieldElementOutput.DefaultValue.Contains(openTagField) Then
    '                    If _fieldElementOutput.ID = "OUTPUT" Then
    '                        Console.Write("TEST")
    '                    ElseIf _fieldElementOutput.ID = "TRACK1" Then
    '                        Console.Write("TEST")
    '                    End If
    '                    Return GetDefaultValueWithCombination(output, _fieldElementOutput.DefaultValue, rw, fileName)
    '                ElseIf _fieldElementOutput.DefaultValue <> "" Then
    '                    If _fieldElementOutput.DataLength > 0 And _fieldElementOutput.PaddedChar <> "" Then
    '                        Return _fieldElementOutput.DefaultValue.PadRight(_fieldElementOutput.DataLength, _fieldElementOutput.PaddedChar)
    '                    Else
    '                        Return _fieldElementOutput.DefaultValue
    '                    End If
    '                End If
    '            Catch ex As Exception
    '                If rw.Table.Columns.Contains(ID) Then
    '                    'Return rw(ID).ToString.Substring(0, _fieldElementInput.DataLength - 1)
    '                    Return rw(ID).ToString
    '                End If
    '            End Try
    '        ElseIf output.ParserType = ParserType.Delimited Then
    '            If _fieldElementOutput.DefaultValue = "" Then
    '                Try
    '                    Return rw(ID).ToString
    '                Catch ex As Exception
    '                    Return ""
    '                End Try
    '            ElseIf _fieldElementOutput.DefaultValue = "Now()" And _fieldElementOutput.DataType = "DateTime" Then
    '                Return Now.ToString(_fieldElementOutput.StringFormat)
    '            ElseIf _fieldElementOutput.DefaultValue = "FileName()" Then
    '                If _fieldElementOutput.FilePathType = "1" Then
    '                    Return Path.GetFileName(fileName)
    '                ElseIf _fieldElementOutput.FilePathType = "2" Then
    '                    Return Path.GetFileNameWithoutExtension(fileName)
    '                End If
    '            ElseIf _fieldElementOutput.DefaultValue <> "" And _fieldElementOutput.DefaultValue.Contains(openTagField) Then
    '                Return GetDefaultValueWithCombination(output, _fieldElementOutput.DefaultValue, rw, fileName)
    '            ElseIf _fieldElementOutput.DefaultValue <> "" Then
    '                Return _fieldElementOutput.DefaultValue
    '            End If
    '        End If
    '    End Function

    '    Private Function GetInputColumnAttribute(ByVal clientConfig As ClientConfig, ByVal ID As String) As FieldElement
    '        Return clientConfig.InputFieldElements.OfType(Of FieldElement)().Where(Function(element) element.ID.Contains(ID))(0)
    '    End Function

    '    Private Function GetOutputColumnAttribute(ByVal output As Output, ByVal ID As String) As OutputFieldElement
    '        Return output.OutputFieldElements.OfType(Of OutputFieldElement)().Where(Function(element) element.ID.Contains(ID))(0)
    '    End Function

    '    Private Function GetPDFOutputByID(ByVal pdfOutputs() As PDFOutput, ByVal ID As String) As PDFOutput
    '        Return pdfOutputs.OfType(Of PDFOutput)().Where(Function(element) element.ID.Contains(ID))(0)
    '    End Function

    '    Private Function GetConcatenateByID(ByVal concatenates() As Concatenate, ByVal ID As String) As Concatenate
    '        Return concatenates.OfType(Of Concatenate)().Where(Function(element) element.ID.Contains(ID))(0)
    '    End Function

    '    Private Function GetObjectByID(ByVal objects() As Object, ByVal ID As String) As Object
    '        Return objects.OfType(Of Object)().Where(Function(element) element.ID.Contains(ID))(0)
    '    End Function

    '    Private Function GetReplaceByID(ByVal replaces() As Replace, ByVal ID As String) As Replace
    '        Return replaces.OfType(Of Replace)().Where(Function(element) element.ID.Contains(ID))(0)
    '    End Function

    '    Private Sub SaveToLog(ByVal data As String)
    '        Dim sw As New StreamWriter(String.Format("Log{0}.txt", Now.ToString("yyyyMMdd")), True)
    '        sw.Write(Now.ToString("MM/dd/yyyy hh:mm:ss tt ") & data & vbNewLine)
    '        sw.Close()
    '        sw.Dispose()
    '        sw = Nothing
    '    End Sub

    '    Private Function AddDataRow(ByVal clientConfig As ClientConfig, ByVal strLine As String) As Boolean
    '        Try
    '            Dim rwData As DataRow = _dtInputData.NewRow
    '            For Each colData As DataColumn In _dtInputData.Columns
    '                If colData.ColumnName <> "RecordID" Then
    '                    Dim _fieldElement = GetInputColumnAttribute(clientConfig, colData.ColumnName)
    '                    If clientConfig.Input.ParserType = ParserDLL.ParserType.FixLen Then
    '                        Try
    '                            rwData(colData.ColumnName) = strLine.Substring(_fieldElement.StartPosition, _fieldElement.DataLength)
    '                        Catch ex As Exception
    '                            rwData(colData.ColumnName) = strLine.Substring(_fieldElement.StartPosition)
    '                        End Try
    '                    ElseIf clientConfig.Input.ParserType = ParserDLL.ParserType.Delimited Then
    '                        Try
    '                            rwData(colData.ColumnName) = strLine.Split(clientConfig.Input.Delimiter)(_fieldElement.IndexPosition)
    '                        Catch ex As Exception
    '                            rwData(colData.ColumnName) = "Error"
    '                        End Try
    '                    End If
    '                End If
    '            Next
    '            _dtInputData.Rows.Add(rwData)
    '            Return True
    '        Catch ex As Exception
    '            SaveToLog(String.Format("{0}(): Line {1}, Runtime error catched {2}", "AddDataRow", strLine.Substring(0, 20), ex.Message))
    '            Return False
    '        End Try
    '    End Function

    '    Public Function ParserTypeDesc(ByVal ParserType As ParserType) As String
    '        If ParserType = ParserType.FixLen Then
    '            Return "FixLen"
    '        Else
    '            Return "Delimited"
    '        End If
    '    End Function

    '    Public Function GetEnumDesc(ByVal obj As Object) As String
    '        If TypeOf obj Is ParserType Then
    '            Return [Enum].GetName(GetType(ParserType), obj)
    '        ElseIf TypeOf obj Is Xml_ElementName Then
    '            Return [Enum].GetName(GetType(Xml_ElementName), obj)
    '        End If
    '    End Function

    '    Private Function GetDefaultValueWithCombination(ByVal output As Output, ByVal field As String, ByVal rw As DataRow, ByVal fileName As String) As String
    '        Dim arrs() As String = field.Split(openTagField)

    '        For Each arr As String In arrs
    '            If arr.Contains(closeTagField) Then
    '                field = field.Replace(String.Format("{0}{1}{2}", openTagField, arr.Substring(0, arr.IndexOf(closeTagField)).ToString, closeTagField), GetFieldValue(output, arr.Substring(0, arr.IndexOf(closeTagField)).ToString, rw, fileName))
    '            End If
    '        Next

    '        Return field
    '    End Function

    '#End Region

    '#Region " Excel "

    '    Private Function ExcelConStr(ByVal strExcelPath As String) As String
    '        If System.IO.Path.GetExtension(strExcelPath).ToUpper() = ".XLS" Then
    '            Return "Provider=Microsoft.Jet.OLEDB.4.0;Excel 8.0; Extended Properties=HDR=Yes; IMEX=1;Data Source=" + strExcelPath + ""
    '        Else
    '            Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strExcelPath + ";Extended Properties=Excel 12.0;"
    '        End If
    '    End Function

    '    Public Sub LoadExcelFile(ByVal strExcelPath As String, ByVal strExcelSheet As String, ByVal ColumnQuery As String, ByVal WhereQuery As String, ByRef dt As DataTable)
    '        Try
    '            Dim ds As New DataSet()
    '            Dim con As New System.Data.OleDb.OleDbConnection(ExcelConStr(strExcelPath))
    '            Dim cmd As System.Data.OleDb.OleDbCommand
    '            cmd = New System.Data.OleDb.OleDbCommand(String.Format("SELECT {0} FROM [{1}]{2}", ColumnQuery, strExcelSheet, IIf(WhereQuery = "", "", " WHERE " & WhereQuery)), con)

    '            cmd.CommandType = CommandType.Text

    '            con.Open()

    '            Dim da As New System.Data.OleDb.OleDbDataAdapter(cmd)
    '            da.Fill(ds, "Result")
    '            'da.Fill(dt)

    '            dt = ds.Tables(0)
    '            con.Close()
    '        Catch ex As Exception
    '            'MessageBox.Show(ex.Message, "Failed to load excel file...", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            SaveToLog("LoadExcelFile(): " & ex.Message)
    '        End Try
    '    End Sub

    '    Public Sub LoadExcelFileAddr(ByVal strExcelPath As String, ByVal strExcelSheet As String, ByRef dt As DataTable)
    '        Try
    '            Dim ds As New DataSet()
    '            Dim con As New System.Data.OleDb.OleDbConnection(ExcelConStr(strExcelPath))
    '            Dim cmd As System.Data.OleDb.OleDbCommand
    '            'cmd = New System.Data.OleDb.OleDbCommand("SELECT [GSIS ID NUMBER] FROM [" + strExcelSheet + "]", con)
    '            cmd = New System.Data.OleDb.OleDbCommand("SELECT * FROM [" + strExcelSheet + "]", con)
    '            cmd.CommandType = CommandType.Text

    '            con.Open()

    '            Dim da As New System.Data.OleDb.OleDbDataAdapter(cmd)
    '            da.Fill(ds, "Result")
    '            'da.Fill(dt)

    '            dt = ds.Tables(0)
    '            con.Close()
    '        Catch ex As Exception
    '            'MessageBox.Show(ex.Message, "Failed to load excel file...", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End Sub

    '    Public Sub LoadSheets(ByVal strExcelPath As String, ByRef arrSheets As ArrayList)
    '        Try
    '            Dim con As New System.Data.OleDb.OleDbConnection(ExcelConStr(strExcelPath))
    '            con.Open()

    '            Dim dtSheets As DataTable = con.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)

    '            con.Close()

    '            For Each rw As DataRow In dtSheets.Rows
    '                arrSheets.Add(rw("TABLE_NAME"))
    '            Next
    '        Catch ex As Exception
    '            Console.WriteLine(ex.Message)
    '        End Try
    '    End Sub

    '#End Region

End Class
