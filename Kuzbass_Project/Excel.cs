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
        private string[,] values = null;
        public void CreateHeaderReg()
        {
            //Создание шапки реестра
            ExcelPackage workbook = new ExcelPackage(new System.IO.FileInfo(@"C:\Users\Админ-Пк\Desktop\Реестр\Реестр.xlsx"));
            ExcelWorksheet ws1 = workbook.Workbook.Worksheets[1];

            ws1.Cells["A1:G1"].Merge = true;
            ws1.Cells[1, 1].Value = "Реестр чертежей";
            ws1.Cells[1, 1].Style.Font.Size = 30;
            ws1.Column(1).Width = 15;
            ws1.Column(2).Width = 10;
            ws1.Column(3).Width = 20;
            ws1.Column(4).Width = 30;
            ws1.Column(5).Width = 15;
            ws1.Column(6).Width = 20;

            using (ExcelRange range = ws1.Cells["A2:F2"])
            {
                range.Style.Font.Bold = true;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.White);

                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Top.Color.SetColor(Color.Black);
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Color.SetColor(Color.Black);
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Color.SetColor(Color.Black);
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Color.SetColor(Color.Black);
            }
            ws1.Cells[2, 1].Value = "№ заказа";
            ws1.Cells[2, 2].Value = "Лист";
            ws1.Cells[2, 3].Value = "Марка";
            ws1.Cells[2, 4].Value = "Исполнитель";
            ws1.Cells[2, 5].Value = "Длина";
            ws1.Cells[2, 6].Value = "Вес без сварки";
            workbook.Save();
        }
        public void WriteReg(Document Name, int i,int rowCnt)
        {
            //Открытие созданного файла реестр
            ExcelPackage workbook = new ExcelPackage(new System.IO.FileInfo(@"C:\Users\Админ-Пк\Desktop\Реестр\Реестр.xlsx"));
            ExcelWorksheet ws1 = workbook.Workbook.Worksheets[1];
                Name.QR = values[i, 0];
                if (values[i, 0].IndexOf("_") != -1)
                {
                    Name.Number = values[i, 0].Remove(values[i, 0].IndexOf("_"), values[i, 0].Length - values[i, 0].IndexOf("_"));
                    values[i, 0] = values[i, 0].Remove(0, values[i, 0].IndexOf("_") + 1);
                }
                if (values[i, 0].IndexOf("_") != -1)
                {
                    Name.List = values[i, 0].Remove(values[i, 0].IndexOf("_"), values[i, 0].Length - values[i, 0].IndexOf("_"));
                    values[i, 0] = values[i, 0].Remove(0, values[i, 0].IndexOf("_") + 1);
                }
                if (values[i, 0].IndexOf("_") != -1)
                {
                    Name.Name = values[i, 0].Remove(values[i, 0].IndexOf("_"), values[i, 0].Length - values[i, 0].IndexOf("_"));
                    values[i, 0] = values[i, 0].Remove(0, values[i, 0].IndexOf("_") + 1);
                }
                if (values[i, 0].IndexOf("_") != -1)
                {
                    Name.Executor = values[i, 0].Remove(values[i, 0].IndexOf("_"), values[i, 0].Length - values[i, 0].IndexOf("_"));
                    values[i, 0] = values[i, 0].Remove(0, values[i, 0].IndexOf("_") + 1);
                }
                if (values[i, 0].IndexOf("_") != -1)
                {
                    Name.Lenght = values[i, 0].Remove(values[i, 0].IndexOf("_"), values[i, 0].Length - values[i, 0].IndexOf("_"));
                    values[i, 0] = values[i, 0].Remove(0, values[i, 0].IndexOf("_") + 1);
                }
                if (values[i, 0].Trim() != "")
                {
                    Name.Weight = values[i, 0];
                }
                ws1.Cells[i + rowCnt, 1].Value = Name.Number;
                ws1.Cells[i + rowCnt, 2].Value = Name.List;
                ws1.Cells[i + rowCnt, 3].Value = Name.Name;
                ws1.Cells[i + rowCnt, 4].Value = Name.Executor;
                ws1.Cells[i + rowCnt, 5].Value = Name.Lenght;
                ws1.Cells[i + rowCnt, 6].Value = Name.Weight;
                workbook.Save();
            
        }
        public int GetLeight()
        {
            int b = values.Length/7;
            return b;
        }
        public void GetValues(string path)
        {

            values = CSV.GetStringsFromFile(path, 7);
            for (int i = 1; i < values.GetLength(0); i++)
            {

                for (int j = 0; j < values.GetLength(1); j++)
                {
                    values[i, j] = values[i, j].Replace(@"""", string.Empty);
                }
            }
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


