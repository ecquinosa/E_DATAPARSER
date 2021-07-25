using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PdfSharp.Drawing;

namespace PDFLibrary
{
    public class PrintObject
    {
        public string Name { get; set; }
        public string DataTable { get; set; }
        public string FieldType { get; set; }
        public XFontFamily FontFamily { get; set; }
        public int FontSize { get; set; }
        public XFontStyle FontStyle { get; set; }
        public XBrush FontColor { get; set; }
        public XStringAlignment Alignment { get; set; }
        public XLineAlignment LineAlignment { get; set; }
        public int BorderWidth { get; set; }
        public XColor BorderColor { get; set; }
        public int LocX { get; set; }
        public int LocY { get; set; }
        public int Heigth { get; set; }
        public int Width { get; set; }
        public string Value { get; set; }
        public string Symbology { get; set; }
        public string StringFormat { get; set; }
    }
}
