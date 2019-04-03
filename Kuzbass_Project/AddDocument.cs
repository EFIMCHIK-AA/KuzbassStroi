using System;
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
using SimpleTCP;

namespace Kuzbass_Project
{
    public partial class AddDocument : Form
    {
        public AddDocument()
        {
            InitializeComponent();
        }

        SimpleTcpServer Server;
        
        private void AddDocument_Load(object sender, EventArgs e)
        {
            //Блокируем кнопки
            Create_B.Enabled = false;
            OK_B.Enabled = false;
            Delete_B.Enabled = false;

            //Получаем хост и  задаем порт 
            String MyHost = Dns.GetHostName();
            Host_TB.Text = Dns.GetHostByName(MyHost).AddressList[0].ToString();
            Status_TB.AppendText($"Получение хоста => Удачно" + Environment.NewLine);
            Port_TB.Text = "46700";

            //Проверяем доступен ли порт
            Int32 port = Convert.ToInt32(Port_TB.Text);

            while(true)
            {
                //Получаем список всех портов
                IPGlobalProperties iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] tcpConnectionInformation = iPGlobalProperties.GetActiveTcpConnections();

                bool isAvailable = true;

                //Перебираем и находим совпадение
                foreach (TcpConnectionInformation tcpi in tcpConnectionInformation)
                {
                    if (tcpi.LocalEndPoint.Port == port)
                    {
                        isAvailable = false;

                        if (MessageBox.Show($"Порт {port}, установленный в качестве базового порта запуска, занят." +
                                           $" Пожалуйста введите доступный порт для подлючения в программе и на устройстве для считывания QR кода", "Внимание",
                                           MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            GetPort Dialog = new GetPort();

                            if (Dialog.ShowDialog() == DialogResult.OK)
                            {
                                port = Convert.ToInt32(Dialog.Port_TB.Text);
                                Port_TB.Text = port.ToString();
                                break;
                            }
                            else
                            {
                                this.Cancel_B.PerformClick();
                                return;
                            }
                        }
                    }
                }

                //Если совпадений с нашим портом нет, то продолжаем запус сервера
                if (isAvailable == true)
                {
                    Status_TB.AppendText($"Получение порта => Удачно" + Environment.NewLine);

                    Server = new SimpleTcpServer();
                    Server.Delimiter = 0x13;
                    Server.DataReceived += Server_DataReceived;
                    Server.StringEncoder = Encoding.UTF8;
                    //Запускаем сервер
                    IPAddress ip = IPAddress.Parse(Host_TB.Text);
                    Server.Start(ip, port);
                    Status_TB.AppendText($"Запуск сервера  => Удачно" + Environment.NewLine +
                                         $"Ожидание QR" + Environment.NewLine);
                    //Выходим из цикла
                    break;
                }
            }
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
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            if(Spisok_LB.SelectedIndex >= 0)
            {
                Spisok_LB.Items.RemoveAt(Spisok_LB.SelectedIndex);
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
                }
            }
        }
    }
}
