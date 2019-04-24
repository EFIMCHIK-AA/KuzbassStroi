using System;
using Npgsql;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;
using SimpleTCP;
using System.Collections.Generic;
using System.Drawing;

namespace Kuzbass_Project
{
    public partial class AddDocument : Form
    {
        public AddDocument(Int32 Port, String Host, String Host_DB, String Port_DB)
        {
            InitializeComponent();
            this.port = Port;
            this.Host = Host;
            this.Host_DB = Host_DB;
            this.Port_DB = Port_DB;
        }

        String Host_DB;
        String Port_DB;
        Int32 port;
        String Host;

        SimpleTcpServer Server;

        private void AddDocument_Load(object sender, EventArgs e)
        {
            //Блокируем кнопки
            Create_B.Enabled = true;
            OK_B.Enabled = true;

            Status_TB.AppendText($"Получение хоста => Удачно" + Environment.NewLine);
            Status_TB.AppendText($"Получение порта => Удачно" + Environment.NewLine);

            Server = new SimpleTcpServer();
            Server.Delimiter = 0x13;
            Server.DataReceived += Server_DataReceived;
            Server.StringEncoder = Encoding.UTF8;
            //Запускаем сервер
            IPAddress ip = IPAddress.Parse(Host);

            try
            {
                Server.Start(ip, port);
                Status_TB.AppendText($"Запуск сервера  => Удачно" + Environment.NewLine +
                     $"Ожидание QR" + Environment.NewLine);
            }
            catch
            {
                MessageBox.Show("Порт открытия сервера занят", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Темповые массивы для сортировки данных
        List<String> UnigueYES = new List<String>();
        List<String> UnigueNO = new List<String>();
        List<String> Session = new List<String>();


        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            long Temp = 0;
            bool TempSession = true;

            if(Session.Count != 0)
            {
                //Проверка на уникальность в сессии
                foreach (String Item in Session)
                {
                    if (Item == e.MessageString)
                    {
                        TempSession = false;
                    }
                }
            }
            else
            {
                //добавляем в список сессии
                Session.Add(e.MessageString);
                TempSession = true;
            }

            //Если уникален в сессии
            if (TempSession)
            {
                Session.Add(e.MessageString);

                try
                {
                    String connString = $"Server = {Host_DB}; Port = {Port_DB}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

                    using (var connect = new NpgsqlConnection(connString))
                    {
                        connect.Open();

                        using (var cmd = new NpgsqlCommand($"SELECT Count(\"Orders\".\"QR_Order\") FROM \"Orders\" WHERE \"QR_Order\" = '{e.MessageString}'", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Temp = reader.GetInt64(0);
                                }
                            }
                        }

                        connect.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка при подключении к базе данных", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Если уникален в БД
                if (Temp == 0)
                {
                    Spisok_LB.Invoke((MethodInvoker)delegate ()
                    {
                        Status_TB.AppendText($"Получение QR..." + Environment.NewLine);
                        UnigueYES.Add(e.MessageString);
                        Spisok_LB.Items.Add(e.MessageString);
                        SpisokCheck_LB.Items.Add("Уникален").BackColor = Color.Green;
                        System.Threading.Thread.Sleep(100);
                        Status_TB.AppendText($"QR {e.MessageString} => Получен" + Environment.NewLine);
                    });
                }
                //Иначе
                else
                {
                    Spisok_LB.Invoke((MethodInvoker)delegate ()
                    {
                        Status_TB.AppendText($"Получение QR..." + Environment.NewLine);
                        UnigueNO.Add(e.MessageString);
                        Spisok_LB.Items.Add(e.MessageString);
                        SpisokCheck_LB.Items.Add("Не уникален").BackColor = Color.Red;
                        System.Threading.Thread.Sleep(100);
                        Status_TB.AppendText($"QR {e.MessageString} => Получен" + Environment.NewLine);
                    });
                }
            }      
        }

        private void Spisok_LB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddDocument_Shown(object sender, EventArgs e)
        {
            
        }

        private void OK_B_Click(object sender, EventArgs e)
        {
            //Закрытие сервера
            if (Server != null)
            {
                if (Server.IsStarted)
                {
                    Server.Stop();
                    Status_TB.AppendText("Закрытие сервера...");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        private void Cancel_B_Click(object sender, EventArgs e)
        {
                //Закрытие сервера
                if (Server != null)
                {
                    if (Server.IsStarted)
                    {
                        Server.Stop();
                        Status_TB.AppendText("Закрытие сервера...");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
        }

        private void AddDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Закрытие сервера
            if (Server != null)
            {
                if (Server.IsStarted)
                {
                    Server.Stop();
                    Status_TB.AppendText("Закрытие сервера...");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        private void Create_B_Click(object sender, EventArgs e)
        {
            if (Spisok_LB.Items.Count == 0)
            {
                MessageBox.Show("Невозможно сформировать акт, нет данных", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(File.Exists(@"Шаблоны\ШаблонАктУникальный.xlsx"))
            {
                string date = DateTime.Now.ToString();

                date = date.Replace(".", "_");
                date = date.Replace(":", "_");
                saveFileDialog1.FileName = date;
                System.IO.FileInfo fInfoSrcUnique = new System.IO.FileInfo(@"Шаблоны\ШаблонАктУникальный.xlsx");
                System.IO.FileInfo fInfoSrcNoUnique = new System.IO.FileInfo(@"Шаблоны\ШаблонАктУникальный.xlsx");

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Directory.CreateDirectory(saveFileDialog1.FileName.Replace(".xlsx", ""));
                    var wb1 = new ExcelPackage(fInfoSrcUnique).File.CopyTo(saveFileDialog1.FileName + @"\Акт от " + date + ".xlsx");
                    wb1 = new ExcelPackage(fInfoSrcNoUnique).File.CopyTo(saveFileDialog1.FileName.Replace(".xlsx", "") + @"\Акт от "+ date +" не уникальный.xlsx");

                    try
                    {
                        ExcelPackage workbook1 = new ExcelPackage(new System.IO.FileInfo(saveFileDialog1.FileName+ @"\Акт от " + date+".xlsx"));
                        ExcelWorksheet ws1 = workbook1.Workbook.Worksheets[1];
                        var rowCntAct = ws1.Dimension.End.Row;
                        Excel excel = new Excel();
                    
                        if (saveFileDialog1.FileName.IndexOf(@":\") != -1)
                        {
                            Document Temp = new Document();
                            for (Int32 i = 0; i < UnigueYES.Count; i++)
                            {
                                excel.SplitData(Temp, UnigueYES[i]);
                                ws1.Cells[i + rowCntAct + 1, 1].Value = Temp.Number;
                                ws1.Cells[i + rowCntAct + 1, 2].Value = Temp.List;
                                ws1.Cells[i + rowCntAct + 1, 3].Value = Temp.Name;
                                ws1.Cells[i + rowCntAct + 1, 4].Value = Temp.Executor;
                                ws1.Cells[i + rowCntAct + 1, 5].Value = Temp.Lenght;
                                ws1.Cells[i + rowCntAct + 1, 6].Value = Temp.Weight;
                                ws1.Cells[i + rowCntAct + 1, 7].Value = Temp.DateCreate.ToString();
                            }
                            int last = ws1.Dimension.End.Row;
                            ws1.Cells[last + 2, 4].Value = "Принял";
                            ws1.Cells[last + 3, 4].Value = "Сдал";
                            ws1.Cells[last + 2, 6].Value = "______________";
                            ws1.Cells[last + 3, 6].Value = "______________";
                            ws1.Cells[last + 2, 7].Value = "Линник О.В.";
                            ws1.Cells[last + 3, 7].Value = "/______________/";
                            workbook1.Save();
                            ExcelPackage workbook2 = new ExcelPackage(new System.IO.FileInfo(saveFileDialog1.FileName.Replace(".xlsx", "") + @"\Акт от " + date + " не уникальный.xlsx"));
                            ExcelWorksheet ws2 = workbook2.Workbook.Worksheets[1];
                            rowCntAct = ws2.Dimension.End.Row;
                        if (saveFileDialog1.FileName.IndexOf(@":\") != -1)
                        {
                            for (Int32 i = 0; i < UnigueNO.Count; i++)
                                {
                                    excel.SplitData(Temp, UnigueNO[i]);
                                    ws2.Cells[i + rowCntAct + 1, 1].Value = Temp.Number;
                                    ws2.Cells[i + rowCntAct + 1, 2].Value = Temp.List;
                                    ws2.Cells[i + rowCntAct + 1, 3].Value = Temp.Name;
                                    ws2.Cells[i + rowCntAct + 1, 4].Value = Temp.Executor;
                                    ws2.Cells[i + rowCntAct + 1, 5].Value = Temp.Lenght;
                                    ws2.Cells[i + rowCntAct + 1, 6].Value = Temp.Weight;
                                    ws2.Cells[i + rowCntAct + 1, 7].Value = Temp.DateCreate.ToString();
                                }
                                last = ws2.Dimension.End.Row;
                                ws2.Cells[last + 2, 4].Value = "Принял";
                                ws2.Cells[last + 3, 4].Value = "Сдал";
                                ws2.Cells[last + 2, 6].Value = "______________";
                                ws2.Cells[last + 3, 6].Value = "______________";
                                ws2.Cells[last + 2, 7].Value = "Линник О.В.";
                                ws2.Cells[last + 3, 7].Value = "/______________/";
                                workbook2.Save();
                        }
                    }
                }
                    catch
                {
                    MessageBox.Show("Невозможно сформировать акт, закройте все книги Excel", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            }
            else
            {
                MessageBox.Show("Шаблон акта не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
