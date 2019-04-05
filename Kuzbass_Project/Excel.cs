using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Table;

namespace Kuzbass_Project
{
    class Excel
    {
        public void SplitData(Document Temp, string values)
        {
            Temp.DateCreate = DateTime.Now.ToString();
            Temp.QR = values;
            if (values.IndexOf("_") != -1)
            {
                Temp.Number = values.Remove(values.IndexOf("_"), values.Length - values.IndexOf("_"));
                values = values.Remove(0, values.IndexOf("_") + 1);
            }
            if (values.IndexOf("_") != -1)
            {
                Temp.List = values.Remove(values.IndexOf("_"), values.Length - values.IndexOf("_"));
                values = values.Remove(0, values.IndexOf("_") + 1);
            }
            if (values.IndexOf("_") != -1)
            {
                Temp.Name = values.Remove(values.IndexOf("_"), values.Length - values.IndexOf("_"));
                values = values.Remove(0, values.IndexOf("_") + 1);
            }
            if (values.IndexOf("_") != -1)
            {
                Temp.Executor = values.Remove(values.IndexOf("_"), values.Length - values.IndexOf("_"));
                values = values.Remove(0, values.IndexOf("_") + 1);
            }
            if (values.IndexOf("_") != -1)
            {
                Temp.Lenght = values.Remove(values.IndexOf("_"), values.Length - values.IndexOf("_"));
                values = values.Remove(0, values.IndexOf("_") + 1);
            }
            if (values.Trim() != "")
            {
                Temp.Weight = values;
            }
        }
        public void WriteReg(Document Name, int i, int rowCnt, ExcelPackage workbook, ExcelWorksheet ws1)
        {
            //Открытие созданного файла реестр
            ws1.Cells[i + rowCnt, 1].Value = Name.Number;
            ws1.Cells[i + rowCnt, 2].Value = Name.List;
            ws1.Cells[i + rowCnt, 3].Value = Name.Name;
            ws1.Cells[i + rowCnt, 4].Value = Name.Executor;
            ws1.Cells[i + rowCnt, 5].Value = Name.Lenght;
            ws1.Cells[i + rowCnt, 6].Value = Name.Weight;
            ws1.Cells[i + rowCnt, 7].Value = Name.DateCreate;
            workbook.Save();

        }
        //public void CreateAct(string path,Document Name,int i,int rowCnt)
        //{
        //    ExcelPackage workbook = new ExcelPackage(new System.IO.FileInfo(path));
        //    ExcelWorksheet ws1 = workbook.Workbook.Worksheets[1];

        //    ws1.Cells[i + rowCnt, 1].Value = Name.Number;
        //    ws1.Cells[i + rowCnt, 2].Value = Name.List;
        //    ws1.Cells[i + rowCnt, 3].Value = Name.Name;
        //    ws1.Cells[i + rowCnt, 4].Value = Name.Executor;
        //    ws1.Cells[i + rowCnt, 5].Value = Name.Lenght;
        //    ws1.Cells[i + rowCnt, 6].Value = Name.Weight;
        //    int last = ws1.Dimension.End.Row;
        //    ws1.Cells[last + 2, 4].Value = "Принял";
        //    ws1.Cells[last + 3, 4].Value = "Сдал";
        //    ws1.Cells[last + 2, 6].Value = "______________";
        //    ws1.Cells[last + 3, 6].Value = "______________";
        //    ws1.Cells[last + 2, 7].Value = "Линник О.В.";
        //    ws1.Cells[last + 3, 7].Value = "/______________/";
        //    workbook.Save();
        //}
    }
}


