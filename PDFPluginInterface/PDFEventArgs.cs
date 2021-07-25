using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDFPluginInterface
{
    public class PDFEventArgs: EventArgs
    {
        public string MessageStatus { get; set; }
        public int Progress { get; set; }
        public int MaxProgess { get; set; }
    }
}
