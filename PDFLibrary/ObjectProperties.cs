using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.ComponentModel;
using PdfSharp.Drawing;
using System.Drawing;

namespace PDFLibrary
{
    public class ObjectProperties
    {
        //Get Print Object Properties
        public object GetPrintObjProperties(XmlNode HNode, object pobj)
        {
            foreach (PropertyInfo pinfo in pobj.GetType().GetProperties())
            {
                if (HNode.Attributes[pinfo.Name] == null) continue;
                string FValue = HNode.Attributes[pinfo.Name].Value;
                switch (pinfo.PropertyType.Name.ToUpper())
                {
                    case "STRING":
                        pinfo.SetValue(pobj, FValue, null);
                        break;
                    case "XFONTFAMILY":
                        // Create the FontConverter.
                        TypeConverter FConverter = TypeDescriptor.GetConverter(typeof(XFontFamily));
                        XFontFamily font = new XFontFamily(FValue);
                        pinfo.SetValue(pobj, font, null);
                        break;
                    case "XFONTSTYLE":
                        TypeConverter FSConverter = TypeDescriptor.GetConverter(typeof(XFontStyle));
                        string[] seperator = { "|" };
                        string[] SplitStr = FValue.Split(seperator, StringSplitOptions.None);
                        XFontStyle fontstyle = new XFontStyle();
                        foreach (string strstyle in SplitStr)
                        {
                            fontstyle = fontstyle | (XFontStyle)FSConverter.ConvertFromString(strstyle);
                        }
                       
                        pinfo.SetValue(pobj, fontstyle, null);
                        break;
                    case "XBRUSH":
                        XBrush brush = new XSolidBrush(XColor.FromName(FValue));
                        pinfo.SetValue(pobj, brush, null);
                        break;
                    case "XCOLOR":
                        XColor color = XColor.FromName(FValue);
                        pinfo.SetValue(pobj, color, null);
                        break;
                    case "XSTRINGALIGNMENT":
                        TypeConverter SConverter = TypeDescriptor.GetConverter(typeof(XStringAlignment));
                        XStringAlignment SAlignment = (XStringAlignment)SConverter.ConvertFromString(FValue);
                        pinfo.SetValue(pobj, SAlignment, null);
                        break;
                    case "XLINEALIGNMENT":
                        TypeConverter LConverter = TypeDescriptor.GetConverter(typeof(XLineAlignment));
                        XLineAlignment LAlignment = (XLineAlignment)LConverter.ConvertFromString(FValue);
                        pinfo.SetValue(pobj, LAlignment, null);
                        break;
                    case "INT32":
                        TypeConverter IConverter = TypeDescriptor.GetConverter(typeof(Int32));
                        StringAlignment Integer = (StringAlignment)IConverter.ConvertFromString(FValue);
                        pinfo.SetValue(pobj, Integer, null);
                        break;
                }
            }
            return pobj;
        }
    }
}
