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
            Bitmap croppedBitmap = new Bitmap(myImage);
            croppedBitmap = croppedBitmap.Clone(
                        new Rectangle(
                            myImage.Width/2, myImage.Height/2,
                            myImage.Width - myImage.Width / 2,
                            myImage.Height - myImage.Height/2),
                        System.Drawing.Imaging.PixelFormat.DontCare);
            string path = @"C:\Users\Tom\Desktop\temp\" + index + ".tif";
            croppedBitmap.Save(path);
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
                        var fromEncodind = Encoding.GetEncoding(1251);//из какой кодировки
                        var bytes = fromEncodind.GetBytes(cash);
                        var toEncoding = Encoding.GetEncoding(866);//в какую кодировку
                        cash = toEncoding.GetString(bytes);
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

