using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytescout.BarCodeReader;
using System.Drawing;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;



namespace Kuzbass_Project
{
    class Decode_tiff
    {
        public String Decode(string temp,int index)
        {
            Image myImage = Image.FromFile(temp);
            Bitmap source = new Bitmap(myImage);
            Bitmap CroppedImage = source.Clone(new System.Drawing.Rectangle(source.Width/2, source.Height/2, source.Width / 2, source.Height / 2), source.PixelFormat);
            string path = @"Temp\" + index + ".jpg";
            CroppedImage = new Bitmap(CroppedImage, new Size(source.Width / 5, source.Height / 5));
            CroppedImage.Save(path);
            myImage.Dispose();
            try
            {


                using (Reader reader = new Reader())
                {
                    reader.BarcodeTypesToFind.DataMatrix = true;
                    FoundBarcode[] barcodes = reader.ReadFrom(path);
                    string cash = null;
                    foreach (FoundBarcode code in barcodes)
                    {
                        cash = code.Value;
                    }
                    if (cash != null)
                    {
                        var fromEncodind = Encoding.GetEncoding("ISO-8859-1");//из какой кодировки
                        var bytes = fromEncodind.GetBytes(cash);
                        var toEncoding = Encoding.GetEncoding(1251);//в какую кодировку
                        cash = toEncoding.GetString(bytes);
                        while (cash.IndexOf("<FNC1>") != -1)
                            cash = cash.Replace("<FNC1>", "и");
                        cash = cash.Remove(cash.IndexOf('>'), cash.IndexOf('<') - cash.IndexOf('>')+1);
                        return cash;
                    }
                    else
                    {
                        cash = "Не правильно";
                        return cash;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

