using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Table;
using SimpleTCP;

namespace Kuzbass_Project
{
    public partial class AddDocument : Form
    {
        public AddDocument(Int32 Port, String Host)
        {
            InitializeComponent();
            this.port = Port;
            this.Host = Host;
        }

        Int32 port;
        String Host;
        SimpleTcpServer Server;



        private void AddDocument_Load(object sender, EventArgs e)
        {
            //Блокируем кнопки
            Create_B.Enabled = true;
            OK_B.Enabled = true;
            Delete_B.Enabled = false;

            Status_TB.AppendText($"Получение хоста => Удачно" + Environment.NewLine);
            Status_TB.AppendText($"Получение порта => Удачно" + Environment.NewLine);

            Server = new SimpleTcpServer();
            Server.Delimiter = 0x13;
            Server.DataReceived += Server_DataReceived;
            Server.StringEncoder = Encoding.UTF8;
            //Запускаем сервер
            IPAddress ip = IPAddress.Parse(Host);
            Server.Start(ip, port);
            Status_TB.AppendText($"Запуск сервера  => Удачно" + Environment.NewLine +
                                 $"Ожидание QR" + Environment.NewLine);
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            Spisok_LB.Invoke((MethodInvoker)delegate ()
            {
                Spisok_LB.Items.Add(e.MessageString);
                Status_TB.AppendText($"QR {e.MessageString} получен" + Environment.NewLine);
                e.ReplyLine(e.MessageString);
            });
        }

        private void Spisok_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Spisok_LB.SelectedIndex >= 0)
            {
                Delete_B.Enabled = true;
            }
            else
            {
                Delete_B.Enabled = false;
            }

        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            if(Spisok_LB.SelectedIndex >= 0)
            {
                Spisok_LB.Items.RemoveAt(Spisok_LB.SelectedIndex);
            }
            if(Spisok_LB.Items.Count == 0)
            {
                Delete_B.Enabled = false;
            }
        }

        private void AddDocument_Shown(object sender, EventArgs e)
        {           
        }

        private void StartScan_B_Click(object sender, EventArgs e)
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

            if(File.Exists(@"Шаблоны\ШаблонАкт.xlsx"))
            {
                string date = DateTime.Now.ToString();

                date = date.Replace(".", "_");
                date = date.Replace(":", "_");
                saveFileDialog1.FileName = "Акт " + date;
                saveFileDialog1.Filter = "Microsoft Excel Worksheet (*.xlsx)|*.xlsx";

                System.IO.FileInfo fInfoSrc = new System.IO.FileInfo(@"Шаблоны\ШаблонАкт.xlsx");

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(saveFileDialog1.FileName);
                    var wb1 = new ExcelPackage(fInfoSrc).File.CopyTo(saveFileDialog1.FileName);

                    try
                    {
                        ExcelPackage workbook1 = new ExcelPackage(new System.IO.FileInfo(saveFileDialog1.FileName));
                        ExcelWorksheet ws2 = workbook1.Workbook.Worksheets[1];
                        var rowCntAct = ws2.Dimension.End.Row;
                        Excel excel = new Excel();
                        Document Temp = new Document();
                        if (saveFileDialog1.FileName.IndexOf(@":\") != -1)
                        {
                            for (Int32 i = 0; i < Spisok_LB.Items.Count; i++)
                            {
                                excel.SplitData(Temp, Spisok_LB.Items[i] as String);
                                ws2.Cells[i + rowCntAct + 1, 1].Value = Temp.Number;
                                ws2.Cells[i + rowCntAct + 1, 2].Value = Temp.List;
                                ws2.Cells[i + rowCntAct + 1, 3].Value = Temp.Name;
                                ws2.Cells[i + rowCntAct + 1, 4].Value = Temp.Executor;
                                ws2.Cells[i + rowCntAct + 1, 5].Value = Temp.Lenght;
                                ws2.Cells[i + rowCntAct + 1, 6].Value = Temp.Weight;
                                ws2.Cells[i + rowCntAct + 1, 7].Value = Temp.DateCreate;
                            }
                            int last = ws2.Dimension.End.Row;
                            ws2.Cells[last + 2, 4].Value = "Принял";
                            ws2.Cells[last + 3, 4].Value = "Сдал";
                            ws2.Cells[last + 2, 6].Value = "______________";
                            ws2.Cells[last + 3, 6].Value = "______________";
                            ws2.Cells[last + 2, 7].Value = "Линник О.В.";
                            ws2.Cells[last + 3, 7].Value = "/______________/";
                            workbook1.Save();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сформировать акт, закройте все книги Excel", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    return;
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
