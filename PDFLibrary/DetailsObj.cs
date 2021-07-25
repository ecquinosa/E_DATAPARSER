using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PdfSharp.Drawing;

namespace PDFLibrary
{
    public class DetailsObject
    {
        public List<PrintObject> PobjList { get; set; }
        public int LocX { get; set; }
        public int LocY {get;set;}
        public int Width { get; set; }
        public int Heigth { get; set; }
        public XColor BorderColor { get; set; }
        public int BorderWidth { get; set; }
    }
}
