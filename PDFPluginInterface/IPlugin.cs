using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PDFPluginInterface
{
    public interface IPlugin
    {
        void SaveToPDF(string ConfigPath, DataTable Data, string[] FileName);
        void Cancel();
        event EventHandler<PDFEventArgs> OnStartEvent;
        event EventHandler<PDFEventArgs> OnProcessEvent;
        event EventHandler<PDFEventArgs> OnCompleteEvent;
    }
}
