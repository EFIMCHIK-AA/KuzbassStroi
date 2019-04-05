using System;
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

namespace Kuzbass_Project
{
    public partial class Form1 : Form
    {
        private String[,] values = null;
        private String Mode;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "CSV файл (*.csv)|*.csv";
            openFileDialog1.FileName = "";
        }

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
                    String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

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
            //Вызываем форму
            AddDocument Dialog = new AddDocument();
            try
            {
                ExcelPackage workbook = new ExcelPackage(new System.IO.FileInfo(@"Реестр.xlsx"));
                ExcelWorksheet ws1 = workbook.Workbook.Worksheets[1];
                try
                {
                    workbook.Save();
                }
                catch
                {
                    MessageBox.Show("Перед добавлением чертежей, закройте все книги Excel", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    if (Dialog.Spisok_LB.Items.Count == 0)
                    {
                        MessageBox.Show("Нет данных для добавление в БД", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //Документ для работы
                    Excel excel = new Excel();
                    try
                    {
                        workbook.Save();
                        var rowCnt = ws1.Dimension.End.Row;

                        //Добавляю в базу данных и вывожу статус
                        try
                        {
                            //Строка подлючения
                            String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

                            using (var connect = new NpgsqlConnection(connString))
                            {
                                //Открытие потока
                                connect.Open();

                                //Считываем все QR
                                for (Int32 i = 0; i < Dialog.Spisok_LB.Items.Count; i++)
                                {
                                    //Вытаскиваешь данные с документа
                                    Document Temp = new Document();
                                    //Заполнение данных
                                    excel.SplitData(Temp, Dialog.Spisok_LB.Items[i] as String);
                                    try
                                    {
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
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                    //Запись реестра
                                    excel.WriteReg(Temp, i + 1, rowCnt, workbook, ws1);

                                    //Вывод в компонент сообщения об удачном добавлении
                                    Status_TB.AppendText($"Номер заказа {Temp.Number} Марка: {Temp.Name} Лист: {Temp.List} добавлен в базу трекинга" + Environment.NewLine);
                                }

                                //Закрытие потока
                                connect.Close();
                            }

                            //Обновляем данные
                            RefreshSpisok_B.PerformClick();

                            //Вывод инорфмационного окна
                            MessageBox.Show($"Чертежи успешно добавлены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show($"Попытка добавление некорректного QR", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    catch
                    {
                        MessageBox.Show("Закройте все книги Excel и повторите попытку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Файл реестра отсутсвует и будет создан автоматически", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    System.IO.FileInfo fInfoSrc = new System.IO.FileInfo(@"Шаблоны\ШаблонРеестр.xlsx");
                    var wb1 = new ExcelPackage(fInfoSrc).File.CopyTo(@"Реестр.xlsx");
                }
                catch
                {
                    MessageBox.Show("Шаблон реестра отсутствует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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


            PassForm Dialog = new PassForm();
            //Добавляем по умолчанию
            Dialog.Login_CB.Items.Add("Не задано");
            //Установка тестовых данных по умолчанию на "Не задано"
            Dialog.Login_CB.SelectedIndex = 0;

            //Подгрузка должностей из БД
            try
            {
                NamePosition.SetPosition();

                if (NamePosition.Positions.Count != 0)
                {
                    //Вывод всех позиций в Login_CB
                    foreach (Position Temp in NamePosition.Positions)
                    {
                        Dialog.Login_CB.Items.Add(Temp.Name);
                    }
                }
                else
                {
                    MessageBox.Show("Должности для интеграции не обнаружены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Npgsql)
            {
                MessageBox.Show(Npgsql.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                //Получение режима
                Mode = Dialog.Login_CB.SelectedItem.ToString();

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
            }
            else
            {
                //Сначла свернем окно, чтобы не было видно отображение текущего объект формы при нажатие на кнопку Cancel
                this.WindowState = FormWindowState.Minimized;
                //Закроем
                Application.Exit();
            }

            RefreshSpisok_B.PerformClick();
        }

        private void RefreshSpisok_B_Click(object sender, EventArgs e)
        {
            //Очистка
            ClearField();
            Documents.Clear();

            //Загрузка пользователей с таблицы Orders в список Documents
            //Провверка на ошибки
            try
            {
                //Строка подлючения
                String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

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
            if (MessageBox.Show("Вы действительно хотите выйти?", "Информация", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
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
    }
}
