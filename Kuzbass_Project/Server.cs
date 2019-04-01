using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuzbass_Project
{
    static class Server
    {
        static public void Start(ListBox Temp,TextBox Temp2)
        {
            //Очистка
            Temp2.Clear();

            //ОПИСАНИЕ СЕРВЕРА
            //порт для приема сообщения
            Int32 port = 8005;

            //Адрес для запуска сокета
            IPEndPoint IpPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            //Создаем сокет
            Socket ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Вывод информационного сообщения
            Temp2.AppendText($"Создание сокета..." + Environment.NewLine);

            //связываем сокет с локальной точкой, по которой будем принимать данные
            ListenSocket.Bind(IpPoint);
            //Начинаем прослушивание
            ListenSocket.Listen(10);

            //Вывод информационного сообщения
            Temp2.AppendText("Ожидание QR кода..." + Environment.NewLine);

            Socket Handler = ListenSocket.Accept();


            //Получаем сообщение
            StringBuilder Builder = new StringBuilder();

            //Количество получаемых байтов
            Int32 Bytes = 0;
            //Буфер дял получаемых данных
            Byte[] Data = new Byte[256];

            do
            {
                Bytes = Handler.Receive(Data);
                Builder.Append(Encoding.Unicode.GetString(Data, 0, Bytes));
            }
            while (Handler.Available > 0);

            Temp.Items.Add(Builder.ToString());
            //Вывод информационного сообщения
            Temp2.AppendText($"QR {Builder.ToString()} получен" + Environment.NewLine);

            Handler.Shutdown(SocketShutdown.Both);
            Handler.Close();

            //ЗАКОНЧИЛОСЬ ОПИСАНИЕ СЕРВЕРА
        }

    }
}
