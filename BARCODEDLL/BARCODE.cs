using System;
using System.Collections.Generic;
using System.Text;
using Neodynamic.WinControls.BarcodeProfessional;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;
using Gma.QrCodeNet.Encoding;

namespace BARCODEDLL
{
    public class BARCODE
    {
        public BarcodeProfessional bp = new BarcodeProfessional();
        public Image ReturnImage { private set; get; }
        public PrintDocument document {get;set;}
        private string _PrinterName = "";
        private string _Data = "";
        private int _X = 0;
        private int _Y = 0;
        private bool _isLandScape = false;
        private Bitmap CropImage = null;
        public int Heigth { get; set; }
        public int Width { get; set; }
        public string symBology
        {
            set
            {
                switch (value)
                {
                    case "AustraliaPost": _SymBology = Symbology.AustraliaPost; break;
                    case "AztecCode": _SymBology = Symbology.AztecCode; break;
                    case "Codabar": _SymBology = Symbology.Codabar; break;
                    case "Code11": _SymBology = Symbology.Code11; break;
                    case "Code128": _SymBology = Symbology.Code128; break;
                    case "Code16k": _SymBology = Symbology.Code16k; break;
                    case "Code32": _SymBology = Symbology.Code32; break;
                    case "Code39": _SymBology = Symbology.Code39; break;
                    case "Code93": _SymBology = Symbology.Code93; break;
                    case "CompactPdf417": _SymBology = Symbology.CompactPdf417; break;
                    case "Pdf417": _SymBology = Symbology.Pdf417; break;
                    case "MacroPdf417": _SymBology = Symbology.MacroPdf417; break;
                    case "MicroPdf417": _SymBology = Symbology.MicroPdf417; break;
                    case "DataMatrix": _SymBology = Symbology.DataMatrix; break;
                    case "DeutschePostIdentcode": _SymBology = Symbology.DeutschePostIdentcode; break;
                    case "DeutschePostLeitcode": _SymBology = Symbology.DeutschePostLeitcode; break;
                    case "Ean13": _SymBology = Symbology.Ean13; break;
                    case "Ean8": _SymBology = Symbology.Ean8; break;
                    case "Ean99": _SymBology = Symbology.Ean99; break;
                    case "QRCode": _SymBology = Symbology.QRCode; break;
                }
            }
        }

        public void initializeBARCODE() 
        {
            bp.Symbology = _SymBology;
            bp.DisplayCode = DisplayCode;
            bp.CodeAlignment = alignment;
            bp.QRCodeVersion = QRCodeVersion.Auto;
            bp.QRCodeEncoding = QRCodeEncoding.Byte;
        } 

        Symbology _SymBology = Symbology.Code128;
        public SYMBOLOGY SymBology 
        { 
            set
            {
                switch (value) 
                {
                    case SYMBOLOGY.AustraliaPost: _SymBology = Symbology.AustraliaPost; break;
                    case SYMBOLOGY.AztecCode: _SymBology = Symbology.AztecCode; break;
                    case SYMBOLOGY.Codabar: _SymBology = Symbology.Codabar; break;
                    case SYMBOLOGY.Code11: _SymBology = Symbology.Code11; break;
                    case SYMBOLOGY.Code128: _SymBology = Symbology.Code128; break;
                    case SYMBOLOGY.Code16k: _SymBology = Symbology.Code16k; break;
                    case SYMBOLOGY.Code32: _SymBology = Symbology.Code32; break;
                    case SYMBOLOGY.Code39: _SymBology = Symbology.Code39; break;
                    case SYMBOLOGY.Code93: _SymBology = Symbology.Code93; break;
                    case SYMBOLOGY.CompactPdf417: _SymBology = Symbology.CompactPdf417; break;
                    case SYMBOLOGY.DataMatrix: _SymBology = Symbology.DataMatrix; break;
                    case SYMBOLOGY.DeutschePostIdentcode: _SymBology = Symbology.DeutschePostIdentcode; break;
                    case SYMBOLOGY.DeutschePostLeitcode: _SymBology = Symbology.DeutschePostLeitcode; break;
                    case SYMBOLOGY.Ean13: _SymBology = Symbology.Ean13; break;
                    case SYMBOLOGY.Ean8: _SymBology = Symbology.Ean8; break;
                    case SYMBOLOGY.Ean99: _SymBology = Symbology.Ean99; break;
                    case SYMBOLOGY.QRCode: _SymBology = Symbology.QRCode; break;
                }

            } 
        }

        
        public enum CodeAlignMents
        {
            AboveCenter, AboveLeft, AboveRight, BelowCenter, BelowLeft, BelowRight
        }

        Alignment alignment = Alignment.BelowCenter; 
        public CodeAlignMents CodeAlignment
        {
            set 
            {
                switch (value) 
                {
                    case CodeAlignMents.AboveCenter: alignment = Alignment.AboveCenter; break;
                    case CodeAlignMents.AboveLeft: alignment = Alignment.AboveLeft; break;
                    case CodeAlignMents.AboveRight: alignment = Alignment.AboveRight; break;
                    case CodeAlignMents.BelowCenter: alignment = Alignment.BelowCenter; break;
                    case CodeAlignMents.BelowLeft: alignment = Alignment.BelowLeft; break;
                    case CodeAlignMents.BelowRight: alignment = Alignment.BelowRight; break;
                }
            }
        }

        public bool DisplayCode { get; set;}
        public bool DisplayChecksum { get; set; }

        public enum SYMBOLOGY 
        {
            AustraliaPost, AztecCode, Codabar, Code11, Code128, Code16k, Code32,
            Code39, Code93, CompactPdf417, DataMatrix, DeutschePostIdentcode, DeutschePostLeitcode,
            Ean13, Ean8, Ean99, QRCode
        }

        private PrintDocument doc = new PrintDocument();
        public bool Generate(string PrinterName, string Data, int X, int Y, bool isLandScape)
        {
            try
            {


                initializeBARCODE();
                bp.Code = Data;
              
                           
                _PrinterName = PrinterName;
                if (PrinterName == null) return false;
                if (Data == null) return false;
                if (PrinterName == "") return false;
                if (Data == "") return false;
              
                _Data = Data;
                _X = X;
                _Y = Y;
                _isLandScape = isLandScape;

                using (MemoryStream ms = new MemoryStream())
                {
                    //bp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    Image img = System.Drawing.Image.FromStream(ms);

                    Rectangle rect = new Rectangle();
                    if (img.Height > 12) { rect.Height = img.Height - 12; } else { rect.Height = img.Height; }
                    if (img.Width > 10) { rect.Width = img.Width - 23; } else { rect.Width = img.Width; }
                    rect.X = 12;
                    rect.Y = 10;

                     if (img.Height > 10 && img.Width > 10)
                     {
                         CropImage = Crop(img, rect);
                         if (Heigth == 0) Heigth = CropImage.Height;
                         if (Width == 0) Width = CropImage.Width;
                         CropImage = Resize(CropImage, Width, Heigth, 100);
                     }
                     else 
                     {
                         CropImage = (Bitmap) img;
                     }

                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = _PrinterName;
                    ps.DefaultPageSettings.Landscape = isLandScape;

                    RectangleF printarea = ps.DefaultPageSettings.PrintableArea;

                    Bitmap RecImage;
                    if (isLandScape)
                    {
                        RecImage = new Bitmap(Convert.ToInt32(printarea.Height + 1), Convert.ToInt32(printarea.Width + 1));
                    }
                    else
                    {
                        RecImage = new Bitmap(Convert.ToInt32(printarea.Width+ 1), Convert.ToInt32(printarea.Height + 1));
                    }

                    Graphics g = Graphics.FromImage(RecImage);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.PageUnit = GraphicsUnit.Pixel;

                    //g.FillRectangle(new SolidBrush(Color.Green), 0, 0, RecImage.Width, RecImage.Height);
                    g.DrawRectangle(new Pen(Color.Blue), 0, 0, RecImage.Width -1, RecImage.Height -1);

                    Rectangle imgloc = new Rectangle(X +1, Y+1, CropImage.Width, CropImage.Height);
                    g.DrawImage(CropImage, imgloc);

                    ReturnImage = RecImage;

                    doc = new PrintDocument(); 
                    doc.BeginPrint += new PrintEventHandler(doc_BeginPrint);
                    doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
                    document = doc;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public Bitmap GenerateBarcode(string Data)
        {
            if (_SymBology == Symbology.QRCode || _SymBology == Symbology.Pdf417 ||
                _SymBology == Symbology.CompactPdf417 || _SymBology == Symbology.MacroPdf417 || _SymBology == Symbology.MicroPdf417)
            {
                return QRcode(Data);
            }
            else 
            {
                return Barcode(Data); 
            } 
        }

        public Bitmap Barcode(string Data)
        {
            try
            {
                initializeBARCODE();
                using (MemoryStream ms = new MemoryStream())
                {
                    bp.Code = Data;
                    bp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    Image imgs = System.Drawing.Image.FromStream(ms);

                    Rectangle rect = new Rectangle();
                    if (imgs.Height > 10) { rect.Height = imgs.Height - 15; } else { rect.Height = imgs.Height; }
                    if (imgs.Width > 10) { rect.Width = imgs.Width - 22; } else { rect.Width = imgs.Width; }
                    rect.X = 11;
                    rect.Y = 15;
                    if (Heigth != 0) rect.Height = Heigth;
                    if (Width != 0) rect.Width = Width;
                    CropImage = Crop(imgs, rect);

                    if (Heigth == 0) Heigth = CropImage.Height;
                    if (Width == 0) Width = CropImage.Width;
                }
            }
            catch (Exception ex)
            { }
            return CropImage;
        }

        public Bitmap QRcode(string Data)
        {
            try
            {
                //QrEncoder encoder = new QrEncoder();
                //QrCode qcode = encoder.Encode(Data.PadRight(100, ' '));
                //Bitmap tempbmp = new Bitmap(qcode.Matrix.Width, qcode.Matrix.Height);

                //for (int x = 0; x < qcode.Matrix.Width; x++)
                //{
                //    for (int y = 0; y < qcode.Matrix.Width; y++)
                //    {
                //        if (qcode.Matrix.InternalArray[x, y])
                //        {
                //            tempbmp.SetPixel(x, y, Color.Black);
                //        }
                //    }
                //}

                initializeBARCODE();
                using (MemoryStream ms = new MemoryStream())
                {
                    bp.Code = Data;
                    bp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg, 480, 480);
                    Image imgs = System.Drawing.Image.FromStream(ms);

                    Rectangle rect = new Rectangle();
                    if (imgs.Height > 10) { rect.Height = imgs.Height  - 40; } else { rect.Height = imgs.Height; }
                    if (imgs.Width > 10) { rect.Width = imgs.Width - 110; } else { rect.Width = imgs.Width; }
                    rect.X = 55;
                    rect.Y = 50;
                    CropImage = QRCrop(imgs, rect);
                    CropImage.Save("QRCODE.jpg", ImageFormat.Jpeg);
               }
            }
            catch
            { }
            return CropImage;
        }

        private Bitmap QRCrop(Image image, Rectangle Rect)
        {
            Bitmap cropBmp = null;
            if (Width != 0 && Heigth != 0)
            {
                Width *= 5;
                Heigth *= 5; 
                cropBmp = new Bitmap(Width, Heigth, PixelFormat.Format24bppRgb);
                using (Graphics graphics = Graphics.FromImage(cropBmp))
                {
                    cropBmp.SetResolution(480, 480); 
                    graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, Width, Heigth);
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PageUnit = GraphicsUnit.Pixel;
                    Rect.Y += 5;
                    Rect.Height += (3 * 5);
                    graphics.DrawImage(image, new Rectangle(0, 0, cropBmp.Width, cropBmp.Height), Rect, GraphicsUnit.Pixel);
                    //graphics.DrawRectangle(new Pen(Color.Black),5, 5, (Width * 5) - 1, Heigth - 1);
                }
            }
            else
            {
                cropBmp = new Bitmap(Rect.Width, Rect.Height);
                using (Graphics g = Graphics.FromImage(cropBmp))
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.DrawImage(image, new Rectangle(0, 0, cropBmp.Width, cropBmp.Height), Rect, GraphicsUnit.Pixel);
                }
            }

            return cropBmp;
        }

        private Bitmap Crop(Image image, Rectangle Rect)
        {
            Bitmap cropBmp = null;
            //cropBmp.SetResolution(500, 500); 

            if (Width != 0 && Heigth != 0)
            {
                cropBmp = new Bitmap(Width, Heigth, PixelFormat.Format24bppRgb);
                using (Graphics graphics = Graphics.FromImage(cropBmp))
                {
                    graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, Width , Heigth );
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PageUnit = GraphicsUnit.Pixel;
                    Rect.Y++;
                    Rect.Height+=3;
                    graphics.DrawImage(image, new Rectangle(0, 0, cropBmp.Width, cropBmp.Height), Rect, GraphicsUnit.Pixel);
                    graphics.DrawRectangle(new Pen(Color.Black), 0, 0, Width  - 1, Heigth  - 1);
                }
            }
            else
            {
                cropBmp = new Bitmap(Rect.Width, Rect.Height);
                using (Graphics g = Graphics.FromImage(cropBmp))
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.DrawImage(image, new Rectangle(0, 0, cropBmp.Width, cropBmp.Height), Rect, GraphicsUnit.Pixel);
                }
            } 
           
            return cropBmp;
        }

        private Bitmap Resize(Bitmap bmp, int maxWidth, int maxHeight, int quality) 
        {
            int newWidth = maxWidth;
            int newHeight = maxHeight;
            Bitmap RetBmp = null;
            //bmp.SetResolution(300, 300);
            // Convert other formats (including CMYK) to RGB.
            //float ratioW = 500 / 72;
            //float ratioH = 500 / 72; 
            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format64bppArgb);
            //newImage.SetResolution(300, 300);
           
            // Draws the image in the specified size with quality mode set to HighQuality
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, maxWidth, maxHeight);
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic; 
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PageUnit = GraphicsUnit.Pixel;  
                graphics.DrawImage(bmp, 1, 1,newWidth -1, newHeight);
                graphics.DrawRectangle(new Pen(Color.Black), 0, 0, maxWidth - 1, maxHeight - 1);  
            }

            
            //// Get an ImageCodecInfo object that represents the JPEG codec.
            //ImageCodecInfo imageCodecInfo = this.GetEncoderInfo(ImageFormat.Jpeg);

            //// Create an Encoder object for the Quality parameter.
            //System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;

            //// Create an EncoderParameters object. 
            //EncoderParameters encoderParameters = new EncoderParameters(1);

            //// Save the image as a JPEG file with quality level.
            //EncoderParameter encoderParameter = new EncoderParameter(encoder, quality);
            //encoderParameters.Param[0] = encoderParameter;

            
            //using (MemoryStream ms = new MemoryStream()) 
            //{
            //   // newImage.Save(ms, imageCodecInfo, encoderParameters);
            //    newImage.Save(ms,ImageFormat.Bmp);
            //    RetBmp = (Bitmap)Bitmap.FromStream(ms);
            //} 
            return newImage;
        }

        private ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }

        private void doc_BeginPrint(object sender, PrintEventArgs Args) 
        {
            doc.PrinterSettings.PrinterName = _PrinterName;
            doc.DefaultPageSettings.Landscape = _isLandScape;
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs Args)
        {
            Graphics g = Args.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            Rectangle imgloc = new Rectangle(_X, _Y, CropImage.Width, CropImage.Height);
            g.DrawImage(CropImage, imgloc);
        }

        public bool Print() 
        {
            if (doc == null) 
            {
                return false;
            }
            doc.Print(); 
            return true;
        }
    }
}
