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

namespace Kuzbass_Project
{
    public partial class Form1 : Form
    {
        private String[,] values = null;
        private String Mode;
        private String Host;
        private Int32 Port;

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
                    String connString = $"Server = {Host}; Port = {Port}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

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
            Status_TB.Clear();
            Documents.Clear();

            //Получаем хост и  задаем порт 
            String MyHost = Dns.GetHostName();
            String Host = Dns.GetHostByName(MyHost).AddressList[0].ToString();

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
                Int32 port = Convert.ToInt32(strPort);

                //Получаем список всех портов
                IPGlobalProperties iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] tcpConnectionInformation = iPGlobalProperties.GetActiveTcpConnections();

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
                        AddDocument Dialog = new AddDocument(port, Host);

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
                            String connString = $"Server = {Host}; Port = {Port}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

                            using (var connect = new NpgsqlConnection(connString))
                            {
                                //Открытие потока
                                connect.Open();

                                //Для хранения не уникальных QR
                                List<String> CheckUnigueQR = new List<String>();
                                    
                                //Считываем все QR
                                for (Int32 i = 0; i < Dialog.Spisok_LB.Items.Count; i++)
                                {
                                    CheckUnigueQR.Clear();

                                    //Чтение
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

                                    if(CheckUnigueQR.Count == 0)
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
                                        excel.WriteReg(Temp, i + 1, rowCnt, workbook, ws1);

                                        //Вывод в компонент сообщения об удачном добавлении
                                        Status_TB.AppendText($"Номер заказа {Temp.Number} Марка: {Temp.Name} Лист: {Temp.List} => Добавлен в базу отслеживания" + Environment.NewLine);
                                    }
                                    else
                                    {
                                        Status_TB.AppendText($"QR {Spisok_LB.Items[i]} существует => Добавление не произведено" + Environment.NewLine);
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

            if (Mode == "Архивариус")
            {
                //Блокироване и анлок кнопок
                Confirm_B.Enabled = false;
                OpenDocument_B.Enabled = true;
                RefreshSpisok_B.Enabled = true;
                NumberDoc_TB.Enabled = false;
                Exit_B.Enabled = true;
                Operations_B.Enabled = true;
            }
            else if (Mode == "Сотрудник ПДО")
            {
                //Блокироване и анлок кнопок
                Confirm_B.Enabled = false;
                RefreshSpisok_B.Enabled = true;
                OpenDocument_B.Enabled = false;
                Exit_B.Enabled = true;
                Operations_B.Enabled = true;
                NumberDoc_TB.Enabled = false;
            }
            else
            {
                //Блокироване и анлок кнопок
                OpenDocument_B.Enabled = false;
                Confirm_B.Enabled = false;
                RefreshSpisok_B.Enabled = true;
                OpenDocument_B.Enabled = false;
                NumberDoc_TB.Enabled = false;
                Exit_B.Enabled = true;
                Operations_B.Enabled = true;
            }

            //Подгружаем параметры подключения
            if(File.Exists(@"Connect\DataBase\DateConnect.txt"))
            {
                //Считываем параметры подлючения
                try
                {
                    using (StreamReader sr = new StreamReader(File.Open(@"Connect\DataBase\DateConnect.txt", FileMode.Open)))
                    {
                        Host = sr.ReadLine();
                        Port = Convert.ToInt32(sr.ReadLine());
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
                String connString = $"Server = {Host}; Port = {Port}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

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
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetString(7),reader.GetString(9)));
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
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetString(7), reader.GetString(9)));
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
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetString(7), reader.GetString(9)));
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
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetString(7), reader.GetString(9)));
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
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetString(7), reader.GetString(9)));
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
                }
            }
            catch (Exception Npgsql)
            {
                MessageBox.Show(Npgsql.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GetValues(string path)
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

        private void Exit_B_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Operations_B_Click(object sender, EventArgs e)
        {
            OperationForFiles Dialog = new OperationForFiles(Mode);
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
                Program.InitializationForm.Show();
            }
        }
    }
}
