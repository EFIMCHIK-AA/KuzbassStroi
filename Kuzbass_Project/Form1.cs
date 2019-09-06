using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Npgsql;
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
using System.Net.NetworkInformation;
using System.Threading;

namespace Kuzbass_Project
{
    public partial class Form1 : Form
    {
        private String Mode;
        private String Host_BD;
        private Int32 Port_BD;
        private String Host_server;

        public Form1(String Mode)
        {
            InitializeComponent();
            this.Mode = Mode;
            this.confirm = false;
            openFileDialog1.Filter = "CSV файл (*.csv)|*.csv";
            openFileDialog1.FileName = "";
        }
        bool confirm;

        private void ClearField()
        {
            Spisok_LB.Items.Clear();
            Status_TB.Clear();
        }

        //Темповый лист для работы
        List<Document> Documents = new List<Document>();

        private void Confirm_B_Click(object sender, EventArgs e)
        {
            Status_TB.Clear();
            Documents.Clear();

            if(Spisok_LB.SelectedIndex >= 0)
            {
                //Запись нового статуса объекта в бд
                try
                {
                    //Строка подлючения
                    String connString = $"Server = {Host_BD}; Port = {Port_BD}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

                    using (var connect = new NpgsqlConnection(connString))
                    {
                        //Открытие потока
                        connect.Open();

                        //Добавление
                        using (var cmd = new NpgsqlCommand())
                        {
                            cmd.Connection = connect;

                            //Выделенный документ из списка
                            Document Temp = Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as Document;

                            //Запросы на подтверждение
                            if(Mode == "Архивариус")
                            {
                                Temp.Status = "Передан в ПДО";
                            }
                            else if(Mode == "Сотрудник ПДО")
                            {
                                Temp.Status = "Выдан в работу";

                                //Берем номер бланка
                                if (NumberDoc_TB.Text.Trim() != "")
                                {
                                    //Присваивание номера документа
                                    Temp.NumberDoc = NumberDoc_TB.Text.Trim();

                                    //Запись в бд
                                    cmd.CommandText = $"UPDATE \"StatusOrders\" SET \"Status_Order\" = '{Temp.Status}'" +
                                                      $"WHERE((SELECT \"id_Order\" FROM \"Orders\" WHERE \"QR_Order\" = '{Temp.QR}') = \"id_Order\");" +
                                                      $"UPDATE \"NumberDocOrders\" SET \"NumberDoc\" = '{Temp.NumberDoc}'" +
                                                      $"WHERE((SELECT \"id_Order\" FROM \"Orders\" WHERE \"QR_Order\" = '{Temp.QR}') = \"id_Order\"); ";
                                    cmd.ExecuteNonQuery();

                                    Status_TB.AppendText($"Номер заказа {Temp.Number} Марка: {Temp.Name} Лист: {Temp.List} получил статус \"{Temp.Status}\" и номер бланка \"{Temp.NumberDoc}\"" + Environment.NewLine);
                                }
                                else
                                {
                                    NumberDoc_TB.Focus();
                                    MessageBox.Show("Необходимо ввести номер бланка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    Status_TB.AppendText($"Номер заказа {Temp.Number} Марка: {Temp.Name} Лист: {Temp.List} " +
                                                         $"неудачная попытка получения статуса и номера бланка" + Environment.NewLine);
                                    return;
                                }
                            }
                            else if (Mode == "Разработка МК")
                            {
                                Temp.Status = "МК разработаны";
                            }
                            else if (Mode == "Формирование сдельного наряда")
                            {
                                Temp.Status = "Сдельный наряд создан";
                            }
                            else if (Mode == "Раскрой")
                            {
                                Temp.Status = "Раскрой создан";
                            }

                            //Вывод в компонент сообщения об удачном добавлении
                            if(Temp.Status != "Выдан в работу")
                            {
                                //Запись в бд
                                cmd.CommandText = $"UPDATE \"StatusOrders\" SET \"Status_Order\" = '{Temp.Status}'" +
                                                  $"WHERE((SELECT \"id_Order\" FROM \"Orders\" WHERE \"QR_Order\" = '{Temp.QR}') = \"id_Order\")";
                                cmd.ExecuteNonQuery();

                                Status_TB.AppendText($"Номер заказа {Temp.Number} Марка: {Temp.Name} Лист: {Temp.List} получил статус \"{Temp.Status}\"" + Environment.NewLine);
                            }
                            
                            Spisok_LB.Items.RemoveAt(Spisok_LB.SelectedIndex);//Удаляем из старого LB
                        }

                        //Закрытие потока
                        connect.Close();
                    }
                }
                catch (Exception Npgsql)
                {
                    MessageBox.Show(Npgsql.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать объект", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OpenDocument_B_Click(object sender, EventArgs e)
        {
            String MyHost = Dns.GetHostName();
            Host_server = Dns.GetHostByName(MyHost).AddressList[0].ToString();
            Status_TB.Clear();
            Documents.Clear();


            if (File.Exists(@"Connect\Port.txt"))
            {
                //Считываем порт из файла
                String strPort = null;

                //Считываем стандартный порт
                try
                {
                    using (StreamReader sr = new StreamReader(File.Open(@"Connect\Port.txt", FileMode.Open)))
                    {
                        strPort = sr.ReadLine();
                    }
                }
                catch
                {
                    MessageBox.Show("При считывании порта произошла ошибка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Проверяем доступен ли порт
                Int32 port_server = Convert.ToInt32(strPort);

                //Получаем список всех портов
                //IPGlobalProperties iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                //TcpConnectionInformation[] tcpConnectionInformation = iPGlobalProperties.GetActiveTcpConnections();

                //Перебираем и находим совпадение
                //foreach (TcpConnectionInformation tcpi in tcpConnectionInformation)
                //{
                //    if (tcpi.LocalEndPoint.Port == port)
                //    {
                //        MessageBox.Show($"Порт {port}, установленный в качестве базового порта запуска, занят." +
                //                        $"Необходимо установить свободный порт для подлючения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}

                String PathRegistry = null;

                if (File.Exists(@"SavePath\Registry.txt"))
                {

                    try
                    {
                        using (StreamReader sr = new StreamReader(File.Open(@"SavePath\Registry.txt", FileMode.Open)))
                        {
                            PathRegistry = sr.ReadLine();
                        }

                    }
                    catch
                    {
                        MessageBox.Show("При считывании места реестра произошла ошибка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Отсутствует файл Registry.txt. Введите порт в соответствующее поле и подтвердите сохранение, - файл Registry.txt будет автоматически создан", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Метка для возврата
                Tag:

                if (File.Exists(PathRegistry))
                {


                    ExcelPackage workbook = new ExcelPackage(new System.IO.FileInfo(PathRegistry));
                    ExcelWorksheet ws1 = workbook.Workbook.Worksheets[1];

                    try
                    {
                        workbook.Save();

                        //Вызываем форму
                        AddDocument Dialog = new AddDocument(port_server, Host_server, Host_BD, Port_BD.ToString());

                        if (Dialog.ShowDialog() == DialogResult.OK)
                        {
                            if (Dialog.Spisok_LB.Items.Count == 0)
                            {
                                MessageBox.Show("Данные для добавления не обнаружены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            //Документ для работы
                            Excel excel = new Excel();

                            workbook.Save();
                            var rowCnt = ws1.Dimension.End.Row;

                            //Строка подлючения
                            String connString = $"Server = {Host_BD}; Port = {Port_BD}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

                            using (var connect = new NpgsqlConnection(connString))
                            {
                                //Открытие потока
                                connect.Open();

                                //Для хранения не уникальных QR
                                List<String> CheckUnigueQR = new List<String>();
                                    
                                //Считываем все QR
                                for (Int32 i = 0,j=0; i < Dialog.Spisok_LB.Items.Count; i++)
                                {
                                    CheckUnigueQR.Clear();

                                    if (SystemArgs.AddedDocument)
                                    {
                                        using (var cmd = new NpgsqlCommand($"SELECT \"QR_Order\" FROM \"Orders\"" +
                                                           $"WHERE \"QR_Order\" = '{Dialog.Spisok_LB.Items[i]}'", connect))
                                        {
                                            using (var reader = cmd.ExecuteReader())
                                            {
                                                //Вывод в компонент
                                                while (reader.Read())
                                                {
                                                    CheckUnigueQR.Add(reader.GetString(0));
                                                }
                                            }
                                        }
                                        if (CheckUnigueQR.Count == 0)
                                        {
                                            //Вытаскиваешь данные с документа
                                            Document Temp = new Document();

                                            //Заполнение данных
                                            excel.SplitData(Temp, Dialog.Spisok_LB.Items[i] as String);

                                            //Добавление
                                            using (var cmd = new NpgsqlCommand())
                                            {
                                                cmd.Connection = connect;
                                                cmd.CommandText = $"INSERT INTO \"Orders\"(\"QR_Order\", \"Executor_Order\", \"Number_Order\", \"List_Order\", \"Mark_Order\"," +
                                                                  $"\"Lenght_Order\",\"Weight_Order\",\"DateCreate_Order\")" +
                                                                  $"VALUES('{Temp.QR}', '{Temp.Executor}', '{Temp.Number}', '{Temp.List}', '{Temp.Name}', '{Temp.Lenght}', '{Temp.Weight}', '{Temp.DateCreate}');" +
                                                                  $"INSERT INTO \"StatusOrders\"(\"id_Order\", \"Status_Order\")" +
                                                                  $"VALUES((SELECT \"id_Order\" FROM \"Orders\" WHERE \"QR_Order\" = '{Temp.QR}'),'{Temp.Status}');" +
                                                                  $"INSERT INTO \"NumberDocOrders\"(\"id_Order\", \"NumberDoc\")" +
                                                                  $"VALUES((SELECT \"id_Order\" FROM \"Orders\" WHERE \"QR_Order\" = '{Temp.QR}'),'{Temp.NumberDoc}');";
                                                cmd.ExecuteNonQuery();
                                            }

                                            //Запись реестра
                                            excel.WriteReg(Temp, j + 1, rowCnt, workbook, ws1);
                                            j++;

                                            //Вывод в компонент сообщения об удачном добавлении
                                            Status_TB.AppendText($"Номер заказа {Temp.Number} Марка: {Temp.Name} Лист: {Temp.List} => Добавлен в базу отслеживания" + Environment.NewLine);
                                        }
                                        else
                                        {
                                            Status_TB.AppendText($"QR {Dialog.Spisok_LB.Items[i]} существует => Добавление не произведено" + Environment.NewLine);
                                        }
                                    }
                                    else
                                    {
                                        using (var cmd = new NpgsqlCommand($"SELECT \"QR_Order\" FROM \"Orders\", \"StatusOrders\"" +
                                                                            $"WHERE \"QR_Order\" = '{Dialog.Spisok_LB.Items[i]}' AND \"StatusOrders\".\"Status_Order\"='{SystemArgs.SearchStatus}' AND \"Orders\".\"id_Order\"=\"StatusOrders\".\"id_Order\"", connect))
                                        {
                                            using (var reader = cmd.ExecuteReader())
                                            {
                                                //Вывод в компонент
                                                while (reader.Read())
                                                {
                                                    CheckUnigueQR.Add(reader.GetString(0));
                                                }
                                            }
                                        }
                                        if (CheckUnigueQR.Count == 1)
                                        {  
                                            using (var cmd = new NpgsqlCommand())
                                            {
                                                cmd.Connection = connect;
                                                cmd.CommandText = $"UPDATE \"StatusOrders\" SET \"Status_Order\" = '{SystemArgs.Status}'" +
                                                      $"WHERE((SELECT \"id_Order\" FROM \"Orders\" WHERE \"QR_Order\" = '{Dialog.Spisok_LB.Items[i] as String}') = \"id_Order\");";
                                                cmd.ExecuteNonQuery();
                                            }
                                            Status_TB.AppendText($"У чертежа {Dialog.Spisok_LB.Items[i] as String} был изменен статус на {SystemArgs.Status}" + Environment.NewLine);
                                        }
                                        else
                                        {
                                            Status_TB.AppendText($"QR {Dialog.Spisok_LB.Items[i] as String} не существует => Изменение статуса не произведено" + Environment.NewLine);
                                        }
                                    }
                                }

                                //Закрытие потока
                                connect.Close();
                            }

                            //Обновляем данные
                            RefreshSpisok_B.PerformClick();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Перед добавлением чертежей, закройте все книги Excel", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if(File.Exists(@"Шаблоны\ШаблонРеестр.xlsx"))
                    {
                        //Считываем порт из файла
                        String path = null;

                        //Считываем место реестра
                        try
                        {
                            using (StreamReader sr = new StreamReader(File.Open(@"SavePath\Registry.txt", FileMode.Open)))
                            {
                                path = sr.ReadLine();
                            }

                            System.IO.FileInfo fInfoSrc = new System.IO.FileInfo(@"Шаблоны\ШаблонРеестр.xlsx");
                            var wb1 = new ExcelPackage(fInfoSrc).File.CopyTo(path);
                            goto Tag;
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка при создании реестра", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Создание реестра невозможно. Шаблон реестра отсутствует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Отсутствует файл Port.txt. Введите порт в соответствующее поле и подтвердите сохранение, - файл Port.txt будет автоматически создан", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Блокирование всех компонентов
            OpenDocument_B.Enabled = false;
            Confirm_B.Enabled = false;
            RefreshSpisok_B.Enabled = false;
            NumberDoc_TB.Enabled = false;
            Exit_B.Enabled = false;

            Operations_B.Enabled = false;


            Report_CB.Items.AddRange(new String[] { "Нет задано", "За текущий день", "За текущий месяц", "За предыдущий месяц"});
            Report_CB.SelectedIndex = 0;

            if (Mode == "Архивариус")
            {
                //Блокироване и анлок кнопок
                SystemArgs.AddedDocument = true;
                Confirm_B.Enabled = false;
                OpenDocument_B.Enabled = true;
                RefreshSpisok_B.Enabled = true;
                NumberDoc_TB.Enabled = false;
                Exit_B.Enabled = true;
                Operations_B.Enabled = true;
                SystemArgs.SearchStatus = "";
            }
            else if (Mode == "Сотрудник ПДО")
            {
                SystemArgs.AddedDocument = false;
                OpenDocument_B.Text="Подтвердить чертежи";
                //Блокироване и анлок кнопок
                Confirm_B.Enabled = false;
                RefreshSpisok_B.Enabled = true;
                OpenDocument_B.Enabled = true;
                Exit_B.Enabled = true;
                Operations_B.Enabled = true;
                NumberDoc_TB.Enabled = false;
                SystemArgs.SearchStatus = "Нет статуса";
                SystemArgs.Status = "Передан в ПДО";
                Recognize_B.Enabled = false;
            }
            else if (Mode == "Разработка МК")
            {
                SystemArgs.SearchStatus = "Выдан в работу";
                SystemArgs.Status = "МК разработаны";
                OpenDocument_B.Text = "Подтвердить чертежи";
                SystemArgs.AddedDocument = false;
                //Блокироване и анлок кнопок
                OpenDocument_B.Enabled = false;
                Confirm_B.Enabled = false;
                RefreshSpisok_B.Enabled = true;
                OpenDocument_B.Enabled = true;
                NumberDoc_TB.Enabled = false;
                Exit_B.Enabled = true;
                Operations_B.Enabled = true;
                Recognize_B.Enabled = false;
            }
            else if (Mode == "Формирование сдельного наряда")
            {
                SystemArgs.SearchStatus = "МК разработаны";
                SystemArgs.Status = "Сдельный наряд создан";
                OpenDocument_B.Text = "Подтвердить чертежи";
                SystemArgs.AddedDocument = false;
                //Блокироване и анлок кнопок
                OpenDocument_B.Enabled = false;
                Confirm_B.Enabled = false;
                RefreshSpisok_B.Enabled = true;
                OpenDocument_B.Enabled = true;
                NumberDoc_TB.Enabled = false;
                Exit_B.Enabled = true;
                Operations_B.Enabled = true;
                Recognize_B.Enabled = false;
            }
            else if (Mode == "Раскрой")
            {
                SystemArgs.SearchStatus = "Сдельный наряд создан";
                SystemArgs.Status = "Раскрой создан";
                OpenDocument_B.Text = "Подтвердить чертежи";
                SystemArgs.AddedDocument = false;
                //Блокироване и анлок кнопок
                OpenDocument_B.Enabled = false;
                Confirm_B.Enabled = false;
                RefreshSpisok_B.Enabled = true;
                OpenDocument_B.Enabled = true;
                NumberDoc_TB.Enabled = false;
                Exit_B.Enabled = true;
                Operations_B.Enabled = true;
                Recognize_B.Enabled = false;
            }

            //Подгружаем параметры подключения
            if(File.Exists(@"Connect\DataBase\DateConnect.txt"))
            {
                //Считываем параметры подлючения
                try
                {
                    using (StreamReader sr = new StreamReader(File.Open(@"Connect\DataBase\DateConnect.txt", FileMode.Open)))
                    {
                        Host_BD = sr.ReadLine();
                        Port_BD = Convert.ToInt32(sr.ReadLine());
                    }
                }
                catch
                {
                    MessageBox.Show("При считывании параметров подлючения произошла ошибка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Файд с параметрами подлючения отсутсвует. Необходимо добавить файл DateConnect.txt", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshSpisok_B.PerformClick();
        }

        private void RefreshSpisok_B_Click(object sender, EventArgs e)
        {
            //Очистка
            //ClearField();
            Spisok_LB.Items.Clear();
            Documents.Clear();

            //Загрузка пользователей с таблицы Orders в список Documents
            //Провверка на ошибки
            try
            {
                //Строка подлючения
                String connString = $"Server = {Host_BD}; Port = {Port_BD}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

                using (var connect = new NpgsqlConnection(connString))
                {
                    //Открытие потока
                    connect.Open();

                    if(Mode == "Архивариус")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"SELECT \"Orders\".\"QR_Order\",\"Orders\".\"Executor_Order\",\"Orders\".\"Number_Order\"," +
                                                           $"\"Orders\".\"List_Order\",\"Orders\".\"Mark_Order\",\"Orders\".\"Lenght_Order\", \"Orders\".\"Weight_Order\"," +
                                                           $"\"Orders\".\"DateCreate_Order\", \"StatusOrders\".\"Status_Order\", \"NumberDocOrders\".\"NumberDoc\" FROM \"Orders\"," +
                                                           $" \"NumberDocOrders\", \"StatusOrders\"" +
                                                           $"WHERE(\"Orders\".\"id_Order\" = \"NumberDocOrders\".\"id_Order\" AND \"Orders\".\"id_Order\" = \"StatusOrders\".\"id_Order\")" +
                                                           $" AND \"StatusOrders\".\"Status_Order\" = 'Нет статуса'", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetDateTime(7),reader.GetString(9)));
                                }
                            }
                        }
                    }
                    else if(Mode == "Сотрудник ПДО")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"SELECT \"Orders\".\"QR_Order\",\"Orders\".\"Executor_Order\",\"Orders\".\"Number_Order\"," +
                                                           $"\"Orders\".\"List_Order\",\"Orders\".\"Mark_Order\",\"Orders\".\"Lenght_Order\", \"Orders\".\"Weight_Order\"," +
                                                           $"\"Orders\".\"DateCreate_Order\", \"StatusOrders\".\"Status_Order\", \"NumberDocOrders\".\"NumberDoc\" FROM \"Orders\"," +
                                                           $" \"NumberDocOrders\", \"StatusOrders\"" +
                                                           $"WHERE(\"Orders\".\"id_Order\" = \"NumberDocOrders\".\"id_Order\" AND \"Orders\".\"id_Order\" = \"StatusOrders\".\"id_Order\")" +
                                                           $" AND \"StatusOrders\".\"Status_Order\" = 'Передан в ПДО'", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetDateTime(7), reader.GetString(9)));
                                }
                            }
                        }
                    }
                    else if(Mode == "Разработка МК")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"SELECT \"Orders\".\"QR_Order\",\"Orders\".\"Executor_Order\",\"Orders\".\"Number_Order\"," +
                                                           $"\"Orders\".\"List_Order\",\"Orders\".\"Mark_Order\",\"Orders\".\"Lenght_Order\", \"Orders\".\"Weight_Order\"," +
                                                           $"\"Orders\".\"DateCreate_Order\", \"StatusOrders\".\"Status_Order\", \"NumberDocOrders\".\"NumberDoc\" FROM \"Orders\"," +
                                                           $" \"NumberDocOrders\", \"StatusOrders\"" +
                                                           $"WHERE(\"Orders\".\"id_Order\" = \"NumberDocOrders\".\"id_Order\" AND \"Orders\".\"id_Order\" = \"StatusOrders\".\"id_Order\")" +
                                                           $" AND \"StatusOrders\".\"Status_Order\" = 'Выдан в работу'", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetDateTime(7), reader.GetString(9)));
                                }
                            }
                        }
                    }
                    else if (Mode == "Формирование сдельного наряда")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"SELECT \"Orders\".\"QR_Order\",\"Orders\".\"Executor_Order\",\"Orders\".\"Number_Order\"," +
                                                           $"\"Orders\".\"List_Order\",\"Orders\".\"Mark_Order\",\"Orders\".\"Lenght_Order\", \"Orders\".\"Weight_Order\"," +
                                                           $"\"Orders\".\"DateCreate_Order\", \"StatusOrders\".\"Status_Order\", \"NumberDocOrders\".\"NumberDoc\" FROM \"Orders\"," +
                                                           $" \"NumberDocOrders\", \"StatusOrders\"" +
                                                           $"WHERE(\"Orders\".\"id_Order\" = \"NumberDocOrders\".\"id_Order\" AND \"Orders\".\"id_Order\" = \"StatusOrders\".\"id_Order\")" +
                                                           $" AND \"StatusOrders\".\"Status_Order\" = 'МК разработаны'", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetDateTime(7), reader.GetString(9)));
                                }
                            }
                        }
                    }
                    else if (Mode == "Раскрой")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"SELECT \"Orders\".\"QR_Order\",\"Orders\".\"Executor_Order\",\"Orders\".\"Number_Order\"," +
                                                           $"\"Orders\".\"List_Order\",\"Orders\".\"Mark_Order\",\"Orders\".\"Lenght_Order\", \"Orders\".\"Weight_Order\"," +
                                                           $"\"Orders\".\"DateCreate_Order\", \"StatusOrders\".\"Status_Order\", \"NumberDocOrders\".\"NumberDoc\" FROM \"Orders\"," +
                                                           $" \"NumberDocOrders\", \"StatusOrders\"" +
                                                           $"WHERE(\"Orders\".\"id_Order\" = \"NumberDocOrders\".\"id_Order\" AND \"Orders\".\"id_Order\" = \"StatusOrders\".\"id_Order\")" +
                                                           $" AND \"StatusOrders\".\"Status_Order\" = 'Сдельный наряд создан'", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetDateTime(7), reader.GetString(9)));
                                }
                            }
                        }
                    }

                    //Закрытие потока
                    connect.Close();
                }

                //Вывод в компонент отображения
                if(Documents.Count > 0)
                {
                    foreach(Document Temp in Documents)
                    {
                        Spisok_LB.Items.Add(Temp);
                    }
                }
                else
                {
                    Status_TB.AppendText("Документы для подтвердения не обнаружены" + Environment.NewLine);
                    Confirm_B.Enabled = false; //Блокируем кнопку
                }
            }
            catch (Exception Npgsql)
            {
                MessageBox.Show(Npgsql.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Exit_B_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Operations_B_Click(object sender, EventArgs e)
        {
            OperationForFiles Dialog = new OperationForFiles(Mode,Host_BD,Port_BD);

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                RefreshSpisok_B.PerformClick();
            }
        }

        private void Spisok_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Spisok_LB.SelectedIndex >= 0)
            {
                Confirm_B.Enabled = true;
                if(Mode == "Сотрудник ПДО")
                {
                    NumberDoc_TB.Enabled = true;
                }
            }
            else
            {
                Confirm_B.Enabled = false;
                NumberDoc_TB.Enabled = false;
                NumberDoc_TB.Clear();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (confirm == true)
            {
                return;
            }

            Application.Exit();
        }

        private void ChangeUser_B_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите сменить пользователя?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                confirm = true;
                this.Close();
                Program.InitializationForm.Pass_TB.Clear();
                Program.InitializationForm.Show();
                
            }
        }

        private void Report_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Report_CB.SelectedIndex != 0)
            {
                CreateReport_B.Enabled = true;
            }
            else
            {
                CreateReport_B.Enabled = false;
            }
        }

        private void CreateReport_B_Click(object sender, EventArgs e)
        {
            List<Document> Temp = new List<Document>();

            String connString = $"Server = {Host_BD}; Port = {Port_BD}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

            if (Report_CB.SelectedIndex == 1)
            {
                DateTime TodayDate = DateTime.Now;

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand($"SELECT * FROM \"Orders\"" +
                                                       $"WHERE \"DateCreate_Order\" = '{TodayDate}'" +
                                                       $"ORDER BY \"Number_Order\"", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Document Item = new Document();
                                Item.Name = reader.GetString(5);
                                Item.Lenght = reader.GetString(6);
                                Item.Number = reader.GetString(3);
                                Item.Weight = reader.GetString(7);
                                Item.List = reader.GetString(4);
                                Item.Executor = reader.GetString(2);
                                Item.DateCreate = reader.GetDateTime(8);

                                Temp.Add(Item);
                            }
                        }
                    }

                    conn.Close();
                }
            }
            else if(Report_CB.SelectedIndex == 2)
            {
                Int32 Month = DateTime.Now.Month;
                Int32 Year = DateTime.Now.Year;

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand($"SELECT * FROM \"Orders\"" +
                                                       $"WHERE EXTRACT(year from \"DateCreate_Order\") = {Year} AND EXTRACT(month from \"DateCreate_Order\") = {Month}" +
                                                       $"ORDER BY \"Number_Order\"", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Document Item = new Document();
                                Item.Name = reader.GetString(5);
                                Item.Lenght = reader.GetString(6);
                                Item.Number = reader.GetString(3);
                                Item.Weight = reader.GetString(7);
                                Item.List = reader.GetString(4);
                                Item.Executor = reader.GetString(2);
                                Item.DateCreate = reader.GetDateTime(8);

                                Temp.Add(Item);
                            }
                        }
                    }

                    conn.Close();
                }
            }
            else
            {
                Int32 Month = DateTime.Now.Month - 1;
                Int32 Year = DateTime.Now.Year;

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand($"SELECT * FROM \"Orders\"" +
                                                       $"WHERE EXTRACT(year from \"DateCreate_Order\") = {Year} AND EXTRACT(month from \"DateCreate_Order\") = {Month}" +
                                                       $"ORDER BY \"Number_Order\"", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Document Item = new Document();
                                Item.Name = reader.GetString(5);
                                Item.Lenght = reader.GetString(6);
                                Item.Number = reader.GetString(3);
                                Item.Weight = reader.GetString(7);
                                Item.List = reader.GetString(4);
                                Item.Executor = reader.GetString(2);
                                Item.DateCreate = reader.GetDateTime(8);

                                Temp.Add(Item);
                            }
                        }
                    }

                    conn.Close();
                }
            }
            if (File.Exists(@"Шаблоны\ШаблонОтчет.xlsx"))
            {
                string date = DateTime.Now.ToString();

                date = date.Replace(".", "_");
                date = date.Replace(":", "_");
                string NameReport = "";
                if (Report_CB.SelectedIndex == 1)
                    NameReport = "Отчет от ";
                else if (Report_CB.SelectedIndex == 2)
                    NameReport = "Отчет за текущий месяц ";
                else if (Report_CB.SelectedIndex == 3)
                    NameReport = "Отчет за прошедший месяц ";
                saveFileDialog1.FileName = NameReport+date;
                saveFileDialog1.Filter= "Excel Files .xlsx|*.xlsx";
                System.IO.FileInfo fInfoSrcUnique = new System.IO.FileInfo(@"Шаблоны\ШаблонОтчет.xlsx");

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                        var wb1 = new ExcelPackage(fInfoSrcUnique).File.CopyTo(saveFileDialog1.FileName);

                    try
                    {
                        ExcelPackage workbook1 = new ExcelPackage(new System.IO.FileInfo(saveFileDialog1.FileName));
                        ExcelWorksheet ws1 = workbook1.Workbook.Worksheets[1];
                        var rowCntAct = ws1.Dimension.End.Row;
                        Excel excel = new Excel();

                        if (saveFileDialog1.FileName.IndexOf(@":\") != -1)
                        {
                            for (Int32 i = 0; i < Temp.Count; i++)
                            {
                                ws1.Cells[i + rowCntAct + 1, 1].Value = Temp[i].Number;
                                ws1.Cells[i + rowCntAct + 1, 2].Value = Temp[i].List;
                                ws1.Cells[i + rowCntAct + 1, 3].Value = Temp[i].Name;
                                ws1.Cells[i + rowCntAct + 1, 4].Value = Temp[i].Executor;
                                ws1.Cells[i + rowCntAct + 1, 5].Value = Temp[i].Lenght;
                                ws1.Cells[i + rowCntAct + 1, 6].Value = Temp[i].Weight;
                                ws1.Cells[i + rowCntAct + 1, 7].Value = Temp[i].DateCreate.ToShortDateString().ToString();
                            }
                            int last = ws1.Dimension.End.Row;
                            ws1.Cells[last + 2, 4].Value = "Принял";
                            ws1.Cells[last + 3, 4].Value = "Сдал";
                            ws1.Cells[last + 2, 6].Value = "______________";
                            ws1.Cells[last + 3, 6].Value = "______________";
                            ws1.Cells[last + 2, 7].Value = "Линник О.В.";
                            ws1.Cells[last + 3, 7].Value = "/______________/";
                            workbook1.Save();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сформировать отчет, закройте все книги Excel", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Шаблон отчета не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Recognize_B_Click(object sender, EventArgs e)
        {
            string Text_Report = null;
            OpenFileDialog Opd = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Выберите сканы чертежей",
                Filter = "TIF|*.tif|TIFF|*.tiff"
            };

            string date = DateTime.Now.ToString();

            date = date.Replace(".", "_").Replace(":", "_");

            if (Opd.ShowDialog() == DialogResult.OK)
            {
                if (Opd.FileName == String.Empty)
                {
                    return;
                }

                Directory.CreateDirectory("Temp");

                Int32 CountFile = Opd.FileNames.Length;

                Int32 i = 0;

                foreach (String NameFile in Opd.FileNames)
                {
                    Status_TB.AppendText($"Файл {NameFile} обрабатывается, пожалуйста подождите..." + Environment.NewLine);

                    Status_TB.AppendText($"------------------------------------------------------------------------------------------------------------------------->{i + 1}|{CountFile}<--------------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);

                    String CurrentInfoDataMatrix = "";

                    Decode_tiff decode_Tiff = new Decode_tiff();

                    CurrentInfoDataMatrix = decode_Tiff.Decode(NameFile,i);

                    String[] Temp = CurrentInfoDataMatrix.Split('_');

                    Status_TB.AppendText($"Файл {NameFile} обработка завершена" + Environment.NewLine);

                    

                    if (Temp.Length == 6)
                    {
                        Status_TB.AppendText($"Файл {NameFile} проверка QR, пожалуйста подождите..." + Environment.NewLine);

                        Int32 j = 0;
                        Document CurrentDocument = new Document(Temp[2], Temp[0], "Нет статуса", CurrentInfoDataMatrix, Temp[4], Temp[5], Temp[1], Temp[3], DateTime.Now, "Нет номера");
                        String MyHost = Dns.GetHostName();
                        Host_server = Dns.GetHostByName(MyHost).AddressList[0].ToString();

                        Status_TB.Clear();
                        Documents.Clear();

                        if (File.Exists(@"Connect\Port.txt"))
                        {
                            String strPort = null;

                            try
                            {
                                using (StreamReader sr = new StreamReader(File.Open(@"Connect\Port.txt", FileMode.Open)))
                                {
                                    strPort = sr.ReadLine();
                                }
                            }
                            catch
                            {
                                MessageBox.Show("При считывании порта произошла ошибка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            Int32 port_server = Convert.ToInt32(strPort);

                            String PathRegistry = null;

                            if (File.Exists(@"SavePath\Registry.txt"))
                            {

                                try
                                {
                                    using (StreamReader sr = new StreamReader(File.Open(@"SavePath\Registry.txt", FileMode.Open)))
                                    {
                                        PathRegistry = sr.ReadLine();
                                    }

                                }
                                catch
                                {
                                    MessageBox.Show("При считывании места реестра произошла ошибка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Отсутствует файл Registry.txt. Введите порт в соответствующее поле и подтвердите сохранение, - файл Registry.txt будет автоматически создан", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                        //Метка для возврата
                        Tag:

                            if (File.Exists(PathRegistry))
                            {
                                ExcelPackage workbook = new ExcelPackage(new System.IO.FileInfo(PathRegistry));
                                ExcelWorksheet ws1 = workbook.Workbook.Worksheets[1];

                                try
                                {
                                    workbook.Save();

                                    //Документ для работы
                                    Excel excel = new Excel();

                                    workbook.Save();
                                    var rowCnt = ws1.Dimension.End.Row;

                                    String connString = $"Server = {Host_BD}; Port = {Port_BD}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

                                    using (var connect = new NpgsqlConnection(connString))
                                    {
                                        connect.Open();

                                        List<String> CheckUnigueQR = new List<String>();

                                        CheckUnigueQR.Clear();

                                        using (var cmd = new NpgsqlCommand($"SELECT \"QR_Order\" FROM \"Orders\"" +
                                                                           $"WHERE \"QR_Order\" = '{CurrentDocument.QR}'", connect))
                                        {
                                            using (var reader = cmd.ExecuteReader())
                                            {
                                                while (reader.Read())
                                                {
                                                    CheckUnigueQR.Add(reader.GetString(0));
                                                }
                                            }
                                        }

                                        Document Temp2 = new Document();

                                        if (CheckUnigueQR.Count == 0)
                                        {
                                            excel.SplitData(Temp2, CurrentDocument.QR);

                                            using (var cmd = new NpgsqlCommand())
                                            {
                                                cmd.Connection = connect;
                                                cmd.CommandText = $"INSERT INTO \"Orders\"(\"QR_Order\", \"Executor_Order\", \"Number_Order\", \"List_Order\", \"Mark_Order\"," +
                                                                  $"\"Lenght_Order\",\"Weight_Order\",\"DateCreate_Order\")" +
                                                                  $"VALUES('{Temp2.QR}', '{Temp2.Executor}', '{Temp2.Number}', '{Temp2.List}', '{Temp2.Name}', '{Temp2.Lenght}', '{Temp2.Weight}', '{Temp2.DateCreate}');" +
                                                                  $"INSERT INTO \"StatusOrders\"(\"id_Order\", \"Status_Order\")" +
                                                                  $"VALUES((SELECT \"id_Order\" FROM \"Orders\" WHERE \"QR_Order\" = '{Temp2.QR}'),'{Temp2.Status}');" +
                                                                  $"INSERT INTO \"NumberDocOrders\"(\"id_Order\", \"NumberDoc\")" +
                                                                  $"VALUES((SELECT \"id_Order\" FROM \"Orders\" WHERE \"QR_Order\" = '{Temp2.QR}'),'{Temp2.NumberDoc}');";
                                                cmd.ExecuteNonQuery();
                                            }

                                            Spisok_LB.Items.Add(CurrentDocument);

                                            String TempName = $"{CurrentDocument.Number}_{CurrentDocument.List}_{CurrentDocument.Name}_{CurrentDocument.DateCreate.ToString().Replace(" ", "T").Replace(":", "")}";

                                            Path.GetPathArchive();

                                            if (Directory.Exists($@"{Path.PathArchive}\{CurrentDocument.Number}"))
                                            {
                                                if (!File.Exists($@"{Path.PathArchive}\{CurrentDocument.Number}\{TempName}.tiff"))
                                                {
                                                    File.Copy(NameFile, $@"{Path.PathArchive}\{CurrentDocument.Number}\{TempName}.tiff");
                                                    Status_TB.AppendText($"Файл {TempName}.tiff помещен в директорию {CurrentDocument.Number}" + Environment.NewLine);
                                                    Text_Report += $"Файл {TempName}.tiff помещен в директорию {CurrentDocument.Number}" + Environment.NewLine;
                                                    File.Delete(NameFile);

                                                }
                                            }
                                            else
                                            {
                                                Directory.CreateDirectory($@"{Path.PathArchive}\{CurrentDocument.Number}");

                                                if (!File.Exists($@"{Path.PathArchive}\{CurrentDocument.Number}\{TempName}.tiff"))
                                                {
                                                    File.Copy(NameFile, $@"{Path.PathArchive}\{CurrentDocument.Number}\{TempName}.tiff");
                                                    Status_TB.AppendText($"Директория {CurrentDocument.Number} создана. Файл {TempName}.tiff помещен в директорию" + Environment.NewLine);
                                                    Text_Report += $"Директория {CurrentDocument.Number} создана. Файл {TempName}.tiff помещен в директорию" + Environment.NewLine;
                                                    File.Delete(NameFile);
                                                }
                                            }

                                            //Запись реестра
                                            excel.WriteReg(Temp2, j + 1, rowCnt, workbook, ws1);
                                            j++;

                                            //Вывод в компонент сообщения об удачном добавлении
                                            Status_TB.AppendText($"Номер заказа {Temp2.Number} Марка: {Temp2.Name} Лист: {Temp2.List} => Добавлен в базу отслеживания" + Environment.NewLine);

                                            Status_TB.AppendText($"Файл {NameFile} проверка QR завершена" + Environment.NewLine);
                                        }
                                        else
                                        {
                                            Status_TB.AppendText($"QR {CurrentDocument.QR} существует => Добавление не произведено" + Environment.NewLine);
                                            Text_Report += $"QR {CurrentDocument.QR} существует => Добавление не произведено. Файл не был перемещен" + Environment.NewLine;
                                        }

                                        //Закрытие потока
                                        connect.Close();
                                    }

                                    //Обновляем данные
                                    RefreshSpisok_B.PerformClick();
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Перед добавлением чертежей, закройте все книги Excel", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                if (File.Exists(@"Шаблоны\ШаблонРеестр.xlsx"))
                                {
                                    String path = null;

                                    try
                                    {
                                        using (StreamReader sr = new StreamReader(File.Open(@"SavePath\Registry.txt", FileMode.Open)))
                                        {
                                            path = sr.ReadLine();
                                        }

                                        System.IO.FileInfo fInfoSrc = new System.IO.FileInfo(@"Шаблоны\ШаблонРеестр.xlsx");

                                        var wb1 = new ExcelPackage(fInfoSrc).File.CopyTo(path);

                                        goto Tag;
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Ошибка при создании реестра", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Создание реестра невозможно. Шаблон реестра отсутствует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Отсутствует файл Port.txt. Введите порт в соответствующее поле и подтвердите сохранение, - файл Port.txt будет автоматически создан", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Обнаружен DataMatrix неправильного формата", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Status_TB.AppendText($"Файл {NameFile} обнаружен некорректный формат DataMatrix" + Environment.NewLine);
                        Text_Report += $"QR {CurrentInfoDataMatrix} неправильного формата => Добавление не произведено. Файл не был перемещен" + Environment.NewLine;
                        i++;
                        continue;
                    }

                    i++;
                    
                }
               
                System.IO.DirectoryInfo di = new DirectoryInfo("Temp");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                Directory.Delete("Temp");

                Status_TB.AppendText($"ОБРАБОТКА ЗАВЕРШЕНА!" + Environment.NewLine);
                Status_TB.AppendText($"-------------------------------------------------------------------------------------------------------------------------->{i}|{CountFile}<-------------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                Report Dialog = new Report();
                Dialog.Text_TB.Text = Text_Report;
                if (Dialog.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void Addnumber_B_Click(object sender, EventArgs e)
        {
            SystemArgs.AddedBlank = true;

            String MyHost = Dns.GetHostName();
            Host_server = Dns.GetHostByName(MyHost).AddressList[0].ToString();
            Status_TB.Clear();
            Documents.Clear();


            if (File.Exists(@"Connect\Port.txt"))
            {
                //Считываем порт из файла
                String strPort = null;

                //Считываем стандартный порт
                try
                {
                    using (StreamReader sr = new StreamReader(File.Open(@"Connect\Port.txt", FileMode.Open)))
                    {
                        strPort = sr.ReadLine();
                    }
                }
                catch
                {
                    MessageBox.Show("При считывании порта произошла ошибка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Проверяем доступен ли порт
                Int32 port_server = Convert.ToInt32(strPort);

                String PathRegistry = null;

                if (File.Exists(@"SavePath\Registry.txt"))
                {

                    try
                    {
                        using (StreamReader sr = new StreamReader(File.Open(@"SavePath\Registry.txt", FileMode.Open)))
                        {
                            PathRegistry = sr.ReadLine();
                        }

                    }
                    catch
                    {
                        MessageBox.Show("При считывании места реестра произошла ошибка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Отсутствует файл Registry.txt. Введите порт в соответствующее поле и подтвердите сохранение, - файл Registry.txt будет автоматически создан", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Вызываем форму
                AddDocument Dialog = new AddDocument(port_server, Host_server, Host_BD, Port_BD.ToString());

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    if (Dialog.Spisok_LB.Items.Count == 0)
                    {
                        MessageBox.Show("Данные для добавления не обнаружены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //Строка подлючения
                    String connString = $"Server = {Host_BD}; Port = {Port_BD}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

                    using (var connect = new NpgsqlConnection(connString))
                    {
                        //Открытие потока
                        connect.Open();

                        for (Int32 i = 0; i < Dialog.Spisok_LB.Items.Count; i++)
                        {
                            //Присваивание номера запрос БД
                            using (var cmd = new NpgsqlCommand())
                            {
                                cmd.Connection = connect;
                                cmd.CommandText = $"UPDATE \"NumberDocOrders\" SET \"NumberDoc\" = '{Dialog.Spisok_LB.Items[i]}'" +
                                                  $"WHERE \"NumberDocOrders\".\"id_Order\" = (SELECT \"id_Order\" FROM \"Orders\" WHERE \"Orders\".\"QR_Order\" = '{Dialog.Spisok_LB.Items[i]}');" +
                                                  $"UPDATE \"StatusOrders\" SET \"Status_Order\" = 'Выдан в работу'" +
                                                  $"WHERE \"StatusOrders\".\"id_Order\" = (SELECT \"id_Order\" FROM \"Orders\" WHERE \"Orders\".\"QR_Order\" = '{Dialog.Spisok_LB.Items[i]}')";
                                cmd.ExecuteNonQuery();
                            }
                        }

                        //Закрытие потока
                        connect.Close();
                    }

                    //Обновляем данные
                    RefreshSpisok_B.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Отсутствует файл Port.txt. Введите порт в соответствующее поле и подтвердите сохранение, - файл Port.txt будет автоматически создан", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
