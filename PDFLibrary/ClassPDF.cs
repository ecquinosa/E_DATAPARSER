using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using PdfSharp;
using PdfSharp.Drawing;
using System.IO;
using System.Data;
using PdfSharp.Pdf;
using System.Xml;
using System.Diagnostics;
using PDFPluginInterface;
using System.Drawing;
using System.Drawing.Printing;
using Utilities;
using BARCODEDLL;

namespace PDFLibrary
{
    //public class ClassPDF : MarshalByRefObject, IPlugin 
    public class ClassPDF : MarshalByRefObject
    {
        public event EventHandler<PDFEventArgs> OnStartEvent;
        public event EventHandler<PDFEventArgs> OnProcessEvent;
        public event EventHandler<PDFEventArgs> OnCompleteEvent;

        private Utility util = new Utility();
        private const string XMLRootNode = "Configurations";
        private string OutputDirectory = "";
        private bool isLandScape = false;
        private string UniqueField = "";
        DataTable OSPDT, PAGEDT;
        ObjectProperties objprop = new ObjectProperties();
        //Read Configuration
        private XmlNode ReadXMLConfig(string ConfigPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigPath);
            XmlNode rootnode = doc.DocumentElement.SelectSingleNode(XMLRootNode);
            OutputDirectory = rootnode.Attributes["Directory"].Value;
            return rootnode;
        }

        public bool Test()
        {
            return true;
        }

        List<PrintObject> HeadersObj = new List<PrintObject>();
        List<PrintObject> PageObj = new List<PrintObject>();
        List<PrintObject> OtherObj = new List<PrintObject>();

        //Get Header Configuration
        private void GetHeaderConfiguration(XmlNode node)
        {
            HeadersObj.Clear();
            XmlNode HeaderNode = node.SelectSingleNode("Header");
            foreach (XmlNode cnode in HeaderNode.ChildNodes)
            {
                PrintObject pobj = new PrintObject();
                HeadersObj.Add((PrintObject)objprop.GetPrintObjProperties(cnode, pobj));
            }
        }

        //Get Header Configuration
        private void GetPageConfiguration(XmlNode node)
        {
            PageObj.Clear();
            XmlNode PageNode = node.SelectSingleNode("Page");
            foreach (XmlNode cnode in PageNode.ChildNodes)
            {
                PrintObject pobj = new PrintObject();
                PageObj.Add((PrintObject)objprop.GetPrintObjProperties(cnode, pobj));
            }
        }

        //Get Other Configuration
        private void GetOtherConfiguration(XmlNode node)
        {
            OtherObj.Clear();
            XmlNode OtherNode = node.SelectSingleNode("Other");
            foreach (XmlNode cnode in OtherNode.ChildNodes)
            {
                PrintObject pobj = new PrintObject();
                OtherObj.Add((PrintObject)objprop.GetPrintObjProperties(cnode, pobj));
            }
        }

        //Get Header Configuration
        private DetailsObject dobj = new DetailsObject();
        private DetailsObject fobj = new DetailsObject();
        private void GetDetailConfiguration(XmlNode node)
        {
            List<PrintObject> DetailsObj = new List<PrintObject>();
            XmlNode DetailHeaderNode = node.SelectSingleNode("Detail");
            dobj = (DetailsObject)objprop.GetPrintObjProperties(DetailHeaderNode, dobj);

            foreach (XmlNode cnode in DetailHeaderNode.ChildNodes)
            {
                PrintObject pobj = new PrintObject();
                DetailsObj.Add((PrintObject)objprop.GetPrintObjProperties(cnode, pobj));
            }

            dobj.PobjList = DetailsObj;
        }

        private DetailsObject GetConfigurations(XmlNode node, string NodePath)
        {
            DetailsObject fobjects = new DetailsObject();
            List<PrintObject> ListObj = new List<PrintObject>();
            XmlNode DetailHeaderNode = node.SelectSingleNode(NodePath);
            fobjects = (DetailsObject)objprop.GetPrintObjProperties(DetailHeaderNode, fobjects);

            foreach (XmlNode cnode in DetailHeaderNode.ChildNodes)
            {
                PrintObject pobj = new PrintObject();
                ListObj.Add((PrintObject)objprop.GetPrintObjProperties(cnode, pobj));
            }

            fobjects.PobjList = ListObj;
            return fobjects;
        }

        /// <summary>
        /// Save to PDF Process.........
        /// </summary>
        /// <param name="ConfigPath"></param>
        /// <param name="Data"></param>
        /// <param name="FName"></param>
        //public void SaveToPDF(string ConfigPath, DataTable Data, string[] FName)
        //Louie
        public void SaveToPDF(string ConfigPath, DataTable Data, string FilePath)
        {
            List<ObjectData> list = new List<ObjectData>();

            foreach (DataRow row in Data.Rows)
            {
                ObjectData obj = new ObjectData
                {
                    _BarCode = row[1].ToString()
                };
                list.Add(obj);
            }

            XmlNode node = ReadXMLConfig(ConfigPath);
            //GetConfigurations
            GetHeaderConfiguration(node);
            GetPageConfiguration(node);
            GetDetailConfiguration(node);
            fobj = GetConfigurations(node, "Footer");

            //GetOtherConfiguration(node);
            int RowCounter = 0, ColCounter = 0, RowSpace = 0, ColSpace = 0;
            string FileNameAdd = "";
            if (node.Attributes["RowCount"] != null) RowCounter = Convert.ToInt32(node.Attributes["RowCount"].Value);
            if (node.Attributes["ColumnCount"] != null) ColCounter = Convert.ToInt32(node.Attributes["ColumnCount"].Value);
            if (node.Attributes["RowSpace"] != null) RowSpace = Convert.ToInt32(node.Attributes["RowSpace"].Value);
            if (node.Attributes["ColSpace"] != null) ColSpace = Convert.ToInt32(node.Attributes["ColSpace"].Value);
            if (node.Attributes["isLandScape"] != null) ColSpace = Convert.ToInt32(node.Attributes["ColSpace"].Value);
            if (node.Attributes["FileName"] != null) FileNameAdd = node.Attributes["FileName"].Value;
            if (node.Attributes["UniqueField"] != null) UniqueField = node.Attributes["UniqueField"].Value;
            //Get OSP
            XmlNode ospnode = node.SelectSingleNode("Other");
            if (ospnode != null)
            {
                string osppath = ospnode.Attributes["Path"].Value;
                string tableName = ospnode.Attributes["TableName"].Value;
                OSPDT = util.ReadExcel(osppath);
                OSPDT.TableName = tableName;
            }

            Data.TableName = "Data";
            //if (!Data.Columns.Contains("TOTAL")) Data.Columns.Add("TOTAL");
            //if (!Data.Columns.Contains("TOTALCOUNT")) Data.Columns.Add("TOTALCOUNT");
            //if (!Data.Columns.Contains("PAGENO")) Data.Columns.Add("PAGENO");
            //if (!Data.Columns.Contains("TOTALPAGE")) Data.Columns.Add("TOTALPAGE");

            DataTable PAGEDT = new DataTable("PAGE");
            PAGEDT.Columns.Add("PAGENO");
            PAGEDT.Columns.Add("TOTALPAGE");
            PAGEDT.Columns.Add("BRANCHCODE");
            PAGEDT.Columns.Add("TOTAL");
            PAGEDT.Columns.Add("GRANDTOTAL");
            PAGEDT.Columns.Add("FILEDATE");

            DataRow pdr = PAGEDT.NewRow();
            PAGEDT.Rows.Add(pdr);

            List<DataTable> DTList = new List<DataTable>();
            DTList.Add(Data);
            DTList.Add(OSPDT);
            DTList.Add(PAGEDT);

            //Check if Deirectory Exist
            int FileIndex = 0;
            int pcounter = 1;
            //foreach (string FileName in FName)
            //{
            //    string FilePath = Path.Combine(OutputDirectory, Path.GetFileNameWithoutExtension(FileName) + FileNameAdd);
            //    PdfDocument pdf = new PdfDocument();
            //    pdf.Info.Title = Path.GetFileNameWithoutExtension(FileName);

            //    //Get Unique Fields =================================================================================================
            //    List<UniqueFieldsClass> UniqueFields = GetUniqueFieldData(Data, UniqueField);


            //    int StartLocY = 0, StartLocX = 0; int objWidth = 0;
            //    int counter = 1; int ccounter = 1; int PageNo = 1;
            //    int FooterLocY = 0;
            //    XGraphics graph = null ;

            //    DataRow dr = null;

            //    foreach (UniqueFieldsClass uField in UniqueFields)
            //    {
            //        //Get Total Page
            //        int totalpage = UniqueFields.Count / RowCounter;
            //        decimal per = UniqueFields.Count % RowCounter;
            //        if (per != 0)
            //        {
            //            totalpage++;
            //        }

            //        PAGEDT.Rows[0]["TOTALPAGE"] = totalpage.ToString();
            //        PAGEDT.Rows[0]["BRANCHCODE"] = uField.ColumnField;
            //        PAGEDT.Rows[0]["TOTAL"] = uField.Data.Length;
            //        DateTime fileCreatedDate = File.GetCreationTime(FileName);
            //        PAGEDT.Rows[0]["FILEDATE"] = fileCreatedDate;

            //        string sgtotal = PAGEDT.Rows[0]["GRANDTOTAL"].ToString();
            //        if (sgtotal == "") sgtotal = "0";
            //        int gtotal = Convert.ToInt32(sgtotal);
            //        gtotal += uField.Data.Length;
            //        PAGEDT.Rows[0]["GRANDTOTAL"] = gtotal;

            //        //Print Headers 
            //        if (counter == 1 && ccounter == 1)
            //        {
            //            PAGEDT.Rows[0]["PAGENO"] = PageNo.ToString();
            //            PdfPage pdfPage = pdf.AddPage();
            //            if (isLandScape) pdfPage.Orientation = PageOrientation.Landscape;
            //            graph = XGraphics.FromPdfPage(pdfPage);
            //            if(PageNo ==1) PrintHeaders(ref graph, DTList, UniqueField, uField.ColumnField);
            //            PrintPage(ref graph, DTList, UniqueField, uField.ColumnField);
            //            PageNo++;
            //        }
            //Louie
            PdfDocument pdf = new PdfDocument();
            XSize size = PageSizeConverter.ToSize(PdfSharp.PageSize.A4);

            foreach (var FileName in list)
            {
                //string FilePath = Path.Combine(OutputDirectory, Path.GetFileNameWithoutExtension(FileName) + FileNameAdd);
                //pdf.Info.Title = Path.GetFileNameWithoutExtension(FileName);

                //Get Unique Fields =================================================================================================
                List<UniqueFieldsClass> UniqueFields = GetUniqueFieldData(Data, UniqueField);

                int StartLocY = 0, StartLocX = 0; int objWidth = 0;
                int counter = 1; int ccounter = 1; int PageNo = 1;
                int FooterLocY = 0;
                XGraphics graph = null;

                DataRow dr = null;

                foreach (UniqueFieldsClass uField in UniqueFields)
                {
                    //Get Total Page
                    int totalpage = UniqueFields.Count / RowCounter;
                    decimal per = UniqueFields.Count % RowCounter;
                    if (per != 0)
                    {
                        totalpage++;
                    }

                    //PAGEDT.Rows[0]["TOTALPAGE"] = totalpage.ToString();
                    //PAGEDT.Rows[0]["BRANCHCODE"] = uField.ColumnField;
                    //PAGEDT.Rows[0]["TOTAL"] = uField.Data.Length;
                    //DateTime fileCreatedDate = File.GetCreationTime(FileName);
                    //PAGEDT.Rows[0]["FILEDATE"] = fileCreatedDate;

                    //string sgtotal = PAGEDT.Rows[0]["GRANDTOTAL"].ToString();
                    //if (sgtotal == "") sgtotal = "0";
                    //int gtotal = Convert.ToInt32(sgtotal);
                    //gtotal += uField.Data.Length;
                    //PAGEDT.Rows[0]["GRANDTOTAL"] = gtotal;

                    //Print Headers 
                    if (counter == 1 && ccounter == 1)
                    {
                        PAGEDT.Rows[0]["PAGENO"] = PageNo.ToString();
                        PdfPage pdfPage = pdf.AddPage();
                        if (isLandScape) pdfPage.Orientation = PageOrientation.Landscape;
                        graph = XGraphics.FromPdfPage(pdfPage);
                        if (PageNo == 1) PrintHeaders(ref graph, DTList, UniqueField, uField.ColumnField);
                        PrintPage(ref graph, DTList, UniqueField, uField.ColumnField);
                        PageNo++;
                    }

                    dr = PAGEDT.Rows[0];
                    //Print Details
                    PrintDetails(ref graph, dr, ref StartLocY, ref StartLocX, ref objWidth, FileName._BarCode);
                    StartLocY += RowSpace;
                    counter++;
                    ccounter++;
                    FooterLocY = dobj.LocY + StartLocY;
                    if (counter > RowCounter)
                    {
                        StartLocY = 0;
                        ccounter++;
                        counter = 1;
                        StartLocX += objWidth + ColSpace;
                        if (ccounter > ColCounter)
                        {
                            StartLocX = 0;
                            ccounter = 1;
                        }
                    }

                    pcounter++;
                    //Progress
                    if (OnProcessEvent != null)
                    {
                        PDFEventArgs txnargs = new PDFEventArgs();
                        txnargs.MaxProgess = Data.Rows.Count;
                        txnargs.Progress = counter;
                        //txnargs.MessageStatus = "Processing [" + Path.GetFileNameWithoutExtension(FileName) + "] Record " + pcounter + " of " + txnargs.MaxProgess.ToString();
                        OnProcessEvent(this, txnargs);
                    }

                }


                PrintFooter(ref graph, dr, FooterLocY, StartLocX, objWidth);


                FileIndex++;
            }
            string _date = System.DateTime.Now.ToString("yyyy-MM-dd HHmmss");

            if (!Directory.Exists(OutputDirectory)) Directory.CreateDirectory(OutputDirectory);
            pdf.Save(FilePath + "\\Barcode-" + _date + ".pdf");
            //string GetFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            //Process.Start(FilePath);
        }

        //Print Headers ===========================================================================================================
        private void PrintHeaders(ref XGraphics graph, List<DataTable> TableList, string UniqueFieldName, string UniqueFieldValue)
        {
            foreach (PrintObject pobj in HeadersObj)
            {
                List<DataTable> dt = TableList.Where(d => d.TableName == pobj.DataTable).ToList<DataTable>();
                string query = String.Format("{0} = '{1}'", UniqueFieldName, UniqueFieldValue);
                DataRow[] drs = dt[0].Select(query);
                DataRow dr = null;
                if (drs.Length != 0) dr = drs[0];

                string dValue = "####NODATA#####";
                if (drs.Length != 0) dValue = util.GetData(dr, pobj.Value);

                Rectangle rect = new Rectangle(pobj.LocX, pobj.LocY, pobj.Width, pobj.Heigth);
                XStringFormat xsformat = new XStringFormat();
                xsformat.Alignment = pobj.Alignment;
                xsformat.LineAlignment = pobj.LineAlignment;
                XFont font = new XFont(pobj.FontFamily.Name, Convert.ToDouble(pobj.FontSize), pobj.FontStyle);
                XSize stringSize = new XSize();

                switch (pobj.FieldType)
                {
                    case "TEXT":
                        stringSize = graph.MeasureString(dValue, font, xsformat);
                        if (stringSize.Width > rect.Width)
                        {
                            PrintTextLines(dValue, rect, graph, font, pobj.FontColor, xsformat);
                        }
                        else
                        {
                            graph.DrawString(dValue, font, pobj.FontColor, rect, xsformat);
                        }
                        break;
                    case "IMAGE":
                        Image img = new Bitmap(dValue);
                        graph.DrawImage(img, rect);
                        break;
                    case "BARCODE":
                        BARCODE bcode = new BARCODE();
                        bcode.symBology = pobj.Symbology;
                        bcode.Heigth = 0;//po.Height;
                        bcode.Width = 0;//po.Width;
                        Bitmap barcode = bcode.GenerateBarcode(dValue);
                        Point pf = new Point(pobj.LocX, pobj.LocY);
                        barcode.Save("Barcode.bmp");
                        Size size = new Size(pobj.Width, pobj.Heigth);
                        Rectangle rec = new Rectangle(pf, size);
                        if (barcode != null)
                        {
                            graph.DrawImage(barcode, rec); //g.DrawImage(barcode, pf); 
                        }
                        break;
                    case "DATETIMENOW":
                        string DateValue = DateTime.Now.ToString(dValue);
                        stringSize = graph.MeasureString(DateValue, font, xsformat);
                        if (stringSize.Width > rect.Width)
                        {
                            PrintTextLines(DateValue, rect, graph, font, pobj.FontColor, xsformat);
                        }
                        else
                        {
                            graph.DrawString(DateValue, font, pobj.FontColor, rect, xsformat);
                        }
                        break;
                    case "DATETIME":
                        DateTime DateFromVal = DateTime.Now;
                        DateTime expectedDate;
                        if (DateTime.TryParse(dValue, out expectedDate))
                        {
                            DateFromVal = Convert.ToDateTime(dValue);
                        }

                        string StringFormat = util.GetData(dr, pobj.StringFormat);
                        string DateVal = DateFromVal.ToString(StringFormat);
                        stringSize = graph.MeasureString(DateVal, font, xsformat);
                        if (stringSize.Width > rect.Width)
                        {
                            PrintTextLines(DateVal, rect, graph, font, pobj.FontColor, xsformat);
                        }
                        else
                        {
                            graph.DrawString(DateVal, font, pobj.FontColor, rect, xsformat);
                        }
                        break;

                }
                //Draw Border
                if (pobj.BorderWidth != 0)
                {
                    graph.DrawRectangle(new XPen(pobj.BorderColor, pobj.BorderWidth), Rectangle.Round(rect));
                }
            }
        }

        //Print Details============================================================================================================
        private void PrintDetails(ref XGraphics graph, DataRow dr, ref int StartLocY, ref int StartLocX, ref int objWidth, String _BarCode)
        {
            int CurLocY = 0, CurLocX = 0; int CurHeigth = 0;
            CurLocY = dobj.LocY + StartLocY; CurLocX = dobj.LocX + StartLocX;
            CurHeigth += dobj.Heigth;
            objWidth = dobj.Width;
            foreach (PrintObject pobj in dobj.PobjList)
            {
                int LocY = pobj.LocY + CurLocY;
                int LocX = pobj.LocX + CurLocX;
                string dValue = "";
                Rectangle rect = new Rectangle(LocX, LocY, pobj.Width, pobj.Heigth);

                //dValue = util.GetData(dr, pobj.Value);
                //Louie
                dValue = _BarCode;

                XStringFormat xsformat = new XStringFormat();
                xsformat.Alignment = pobj.Alignment;
                xsformat.LineAlignment = pobj.LineAlignment;
                XFont font = new XFont(pobj.FontFamily.Name, Convert.ToDouble(pobj.FontSize), pobj.FontStyle);
                XSize stringSize = new XSize();
                stringSize = graph.MeasureString(dValue, font, xsformat);

                switch (pobj.FieldType)
                {
                    case "TEXT":
                        if (stringSize.Width > rect.Width)
                        {
                            PrintTextLines(dValue, rect, graph, font, pobj.FontColor, xsformat);
                        }
                        else
                        {
                            graph.DrawString(dValue, font, pobj.FontColor, rect, xsformat);
                        }
                        if (pobj.BorderWidth != 0)
                        {
                            graph.DrawRectangle(new XPen(pobj.BorderColor, pobj.BorderWidth), Rectangle.Round(rect));
                        }
                        break;
                    case "IMAGE":
                        Image img = new Bitmap(dValue);
                        graph.DrawImage(img, rect);
                        if (pobj.BorderWidth != 0)
                        {
                            graph.DrawRectangle(new XPen(pobj.BorderColor, pobj.BorderWidth), Rectangle.Round(rect));
                        }
                        break;
                    case "BARCODE":
                        BARCODE bcode = new BARCODE();
                        bcode.symBology = pobj.Symbology;
                        bcode.Heigth = 0;//po.Height;
                        bcode.Width = 0;//po.Width;
                        Bitmap barcode = bcode.GenerateBarcode(dValue);
                        Point pf = new Point(LocX, LocY);
                        barcode.Save("Barcode.bmp");
                        Size size = new Size(pobj.Width, pobj.Heigth);
                        Rectangle rec = new Rectangle(pf, size);
                        if (barcode != null)
                        {
                            graph.DrawImage(barcode, rec); //g.DrawImage(barcode, pf); 
                        }
                        if (pobj.BorderWidth != 0)
                        {
                            graph.DrawRectangle(new XPen(pobj.BorderColor, pobj.BorderWidth), rect);
                        }
                        break;
                    case "DATETIMENOW":
                        string DateValue = DateTime.Now.ToString(dValue);
                        stringSize = graph.MeasureString(DateValue, font, xsformat);
                        if (stringSize.Width > rect.Width)
                        {
                            PrintTextLines(DateValue, rect, graph, font, pobj.FontColor, xsformat);
                        }
                        else
                        {
                            graph.DrawString(DateValue, font, pobj.FontColor, rect, xsformat);
                        }
                        if (pobj.BorderWidth != 0)
                        {
                            graph.DrawRectangle(new XPen(pobj.BorderColor, pobj.BorderWidth), rect);
                        }
                        break;
                    case "DATETIME":
                        DateTime DateFromVal = DateTime.Now;
                        DateTime expectedDate;
                        if (DateTime.TryParse(dValue, out expectedDate))
                        {
                            DateFromVal = Convert.ToDateTime(dValue);
                        }

                        string StringFormat = util.GetData(dr, pobj.StringFormat);
                        string DateVal = DateFromVal.ToString(StringFormat);
                        stringSize = graph.MeasureString(DateVal, font, xsformat);
                        if (stringSize.Width > rect.Width)
                        {
                            PrintTextLines(DateVal, rect, graph, font, pobj.FontColor, xsformat);
                        }
                        else
                        {
                            graph.DrawString(DateVal, font, pobj.FontColor, rect, xsformat);
                        }
                        break;
                }
            }

            if (dobj.BorderWidth != 0)
            {
                Rectangle drect = new Rectangle(CurLocX, CurLocY, dobj.Width, dobj.Heigth);
                graph.DrawRectangle(new XPen(dobj.BorderColor, dobj.BorderWidth), drect);
            }
            StartLocY += CurHeigth;
            //StartLocX += CurLocX;
        }


        //Print Headers ===========================================================================================================
        private void PrintPage(ref XGraphics graph, List<DataTable> TableList, string UniqueFieldName, string UniqueFieldValue)
        {
            foreach (PrintObject pobj in PageObj)
            {
                List<DataTable> dt = TableList.Where(d => d.TableName == pobj.DataTable).ToList<DataTable>();
                string query = String.Format("{0} = '{1}'", UniqueFieldName, UniqueFieldValue);
                DataRow[] drs = dt[0].Select(query);
                DataRow dr = null;
                if (drs.Length != 0) dr = drs[0];

                string dValue = "####NODATA#####";
                if (drs.Length != 0) dValue = util.GetData(dr, pobj.Value);

                Rectangle rect = new Rectangle(pobj.LocX, pobj.LocY, pobj.Width, pobj.Heigth);
                XStringFormat xsformat = new XStringFormat();
                xsformat.Alignment = pobj.Alignment;
                xsformat.LineAlignment = pobj.LineAlignment;
                XFont font = new XFont(pobj.FontFamily.Name, Convert.ToDouble(pobj.FontSize), pobj.FontStyle);
                XSize stringSize = new XSize();

                switch (pobj.FieldType)
                {
                    case "TEXT":
                        stringSize = graph.MeasureString(dValue, font, xsformat);
                        if (stringSize.Width > rect.Width)
                        {
                            PrintTextLines(dValue, rect, graph, font, pobj.FontColor, xsformat);
                        }
                        else
                        {
                            graph.DrawString(dValue, font, pobj.FontColor, rect, xsformat);
                        }
                        break;
                    case "IMAGE":
                        Image img = new Bitmap(dValue);
                        graph.DrawImage(img, rect);
                        break;
                    case "BARCODE":
                        BARCODE bcode = new BARCODE();
                        bcode.symBology = pobj.Symbology;
                        bcode.Heigth = 0;//po.Height;
                        bcode.Width = 0;//po.Width;
                        Bitmap barcode = bcode.GenerateBarcode(dValue);
                        Point pf = new Point(pobj.LocX, pobj.LocY);
                        barcode.Save("Barcode.bmp");
                        Size size = new Size(pobj.Width, pobj.Heigth);
                        Rectangle rec = new Rectangle(pf, size);
                        if (barcode != null)
                        {
                            graph.DrawImage(barcode, rec); //g.DrawImage(barcode, pf); 
                        }
                        break;
                    case "DATETIMENOW":
                        string DateValue = DateTime.Now.ToString(dValue);
                        stringSize = graph.MeasureString(DateValue, font, xsformat);
                        if (stringSize.Width > rect.Width)
                        {
                            PrintTextLines(DateValue, rect, graph, font, pobj.FontColor, xsformat);
                        }
                        else
                        {
                            graph.DrawString(DateValue, font, pobj.FontColor, rect, xsformat);
                        }
                        break;
                    case "DATETIME":
                        DateTime DateFromVal = DateTime.Now;

                        DateTime expectedDate;
                        if (DateTime.TryParse(dValue, out expectedDate))
                        {
                            DateFromVal = Convert.ToDateTime(dValue);
                        }

                        string DateVal = DateFromVal.ToString(pobj.StringFormat);
                        stringSize = graph.MeasureString(DateVal, font, xsformat);
                        if (stringSize.Width > rect.Width)
                        {
                            PrintTextLines(DateVal, rect, graph, font, pobj.FontColor, xsformat);
                        }
                        else
                        {
                            graph.DrawString(DateVal, font, pobj.FontColor, rect, xsformat);
                        }
                        break;

                }
                //Draw Border
                if (pobj.BorderWidth != 0)
                {
                    graph.DrawRectangle(new XPen(pobj.BorderColor, pobj.BorderWidth), Rectangle.Round(rect));
                }
            }
        }
        //Print Footer=============================================================================================================
        private void PrintFooter(ref XGraphics graph, DataRow dr, int StartLocY, int StartLocX, int objWidth)
        {
            int CurLocY = 0, CurLocX = 0; int CurHeigth = 0;
            CurLocY = fobj.LocY + StartLocY; CurLocX = fobj.LocX + StartLocX;
            CurHeigth += fobj.Heigth;
            objWidth = fobj.Width;
            foreach (PrintObject pobj in fobj.PobjList)
            {
                int LocY = pobj.LocY + CurLocY;
                int LocX = pobj.LocX + CurLocX;
                string dValue = "";
                Rectangle rect = new Rectangle(LocX, LocY, pobj.Width, pobj.Heigth);

                dValue = util.GetData(dr, pobj.Value);
                switch (pobj.FieldType)
                {
                    case "TEXT":
                        XStringFormat xsformat = new XStringFormat();
                        xsformat.Alignment = pobj.Alignment;
                        xsformat.LineAlignment = pobj.LineAlignment;
                        XFont font = new XFont(pobj.FontFamily.Name, Convert.ToDouble(pobj.FontSize), pobj.FontStyle);
                        XSize stringSize = new XSize();
                        stringSize = graph.MeasureString(dValue, font, xsformat);
                        if (stringSize.Width > rect.Width)
                        {
                            PrintTextLines(dValue, rect, graph, font, pobj.FontColor, xsformat);
                        }
                        else
                        {
                            graph.DrawString(dValue, font, pobj.FontColor, rect, xsformat);
                        }
                        graph.DrawRectangle(new XPen(pobj.BorderColor, pobj.BorderWidth), rect);
                        break;
                    case "IMAGE":
                        Image img = new Bitmap(dValue);
                        graph.DrawImage(img, rect);
                        graph.DrawRectangle(new XPen(pobj.BorderColor, pobj.BorderWidth), Rectangle.Round(rect));
                        break;
                    case "BARCODE":
                        BARCODE bcode = new BARCODE();
                        bcode.symBology = pobj.Symbology;
                        bcode.Heigth = 0;//po.Height;
                        bcode.Width = 0;//po.Width;
                        Bitmap barcode = bcode.GenerateBarcode(dValue);
                        Point pf = new Point(LocX, LocY);
                        barcode.Save("Barcode.bmp");
                        Size size = new Size(pobj.Width, pobj.Heigth);
                        Rectangle rec = new Rectangle(pf, size);
                        if (barcode != null)
                        {
                            graph.DrawImage(barcode, rec); //g.DrawImage(barcode, pf); 
                        }
                        graph.DrawRectangle(new XPen(pobj.BorderColor, pobj.BorderWidth), rect);
                        break;
                }
            }

            Rectangle drect = new Rectangle(CurLocX, CurLocY, fobj.Width, fobj.Heigth);
            graph.DrawRectangle(new XPen(fobj.BorderColor, fobj.BorderWidth), drect);
            StartLocY += CurHeigth;
            //StartLocX += CurLocX;
        }

        //Print Multiple Lines
        private void PrintTextLines(string Data, Rectangle rect, XGraphics graph, XFont font, XBrush brush, XStringFormat xsformat)
        {
            XSize stringSize = new XSize();
            string textdata = "";
            int count = 0;
            List<string> textLines = new List<string>();
            string Tempdata = "";
            string[] splitval = Data.Split(' ');
            if (splitval.Length == 1)
            {
                textLines.Add(Data);
            }
            else
            {
                do
                {
                    Tempdata += splitval[count] + " ";
                    stringSize = graph.MeasureString(Tempdata, font, xsformat);
                    if (stringSize.Width >= rect.Width)
                    {
                        textLines.Add(textdata);
                        Tempdata = "";
                    }
                    else
                    {
                        textdata = Tempdata;
                        if (count >= (splitval.Length - 1))
                        {
                            textLines.Add(textdata);
                        }
                        count++;
                    }

                }
                while (count < splitval.Length);
            }
            int newH = rect.Height / textLines.Count;
            foreach (string sdta in textLines)
            {
                rect.Height = newH;
                graph.DrawString(sdta, font, brush, rect, xsformat);
                rect.Y += Convert.ToInt32(stringSize.Height);
            }
        }

        //Get Group List
        private List<UniqueFieldsClass> GetUniqueFieldData(DataTable Data, string ColumnName)
        {
            List<UniqueFieldsClass> UniqueFieldsList = new List<UniqueFieldsClass>();
            if (ColumnName == "")
            {
                UniqueFieldsClass uf = new UniqueFieldsClass();
                uf.ColumnField = "";
                string query = String.Format("");

                uf.Data = Data.Select(query);
                UniqueFieldsList.Add(uf);
                return UniqueFieldsList;
            }

            foreach (DataRow dr in Data.Rows)
            {
                string dta = dr[ColumnName].ToString();
                List<UniqueFieldsClass> filteredFields = UniqueFieldsList.Where(m => m.ColumnField == dta).ToList<UniqueFieldsClass>();
                if (filteredFields.Count == 0)
                {
                    UniqueFieldsClass uf = new UniqueFieldsClass();
                    uf.ColumnField = dta;
                    string query = String.Format("{0} = '{1}'", ColumnName, dta);
                    uf.Data = Data.Select(query);
                    UniqueFieldsList.Add(uf);
                }
            }
            return UniqueFieldsList;
        }

        //Cancel
        public void Cancel()
        {

        }
    }
}
