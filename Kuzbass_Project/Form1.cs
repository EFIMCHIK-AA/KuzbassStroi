using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuzbass_Project
{
    public partial class Form1 : Form
    {
        private string[,] values = null;
<<<<<<< HEAD
=======
        private string[] Number_Order = new string[0];
        private string[] Name_Order = new string[0];
        private string[] QR_Order = new string[0];
        private string[] NumberDoc_Order = new string[0];
>>>>>>> ec26643225f059bce3c8c4513c7ce72ba83ebfe4

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "CSV файл (*.csv)|*.csv";
            openFileDialog1.FileName = "";
        }

        private void ClearField()
        {
            Spisok_LB.Items.Clear();
            ResultSpisok_LB.Items.Clear();
            Status_TB.Clear();
        }

        //Списко для хранение документов
        List<Document> Documents = new List<Document>();

        private void Confirm_B_Click(object sender, EventArgs e)
        {
            //очистка
            Status_TB.Clear();

            Document Temp = Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as Document;

            //Везде будет прописаны свои запросы в бд
            if (Users_CB.SelectedItem.ToString() == "Сотрудник ПДО")
            {  
                Temp.Status = "Выдан в работу";
            }
            else if(Users_CB.SelectedItem.ToString() == "Разработка МК")
            {
                Temp.Status = "МК разработаны";
            }
            else if(Users_CB.SelectedItem.ToString() == "Формирование сдельного наряда")
            {
                Temp.Status = "Сдельный наряд создан";
            }
            else if(Users_CB.SelectedItem.ToString() == "Раскрой")
            {
                Temp.Status = "Раскрой создан";
            }

            if(Spisok_LB.SelectedIndex >= 0)
            {
                Document Item = Spisok_LB.Items[Spisok_LB.SelectedIndex] as Document;

<<<<<<< HEAD
=======
                //Принадлежность статуса к должности
                Item.Status=GetStatus(Users_CB.SelectedItem.ToString());

>>>>>>> ec26643225f059bce3c8c4513c7ce72ba83ebfe4
                //Запись нового статуса объекта в бд
                //Провверка на ошибки
                try
                {
                    //Строка подлючения
                    String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = askede12; Database = KuzbassTest_DB;";

                    using (var connect = new NpgsqlConnection(connString))
                    {
                        //Открытие потока
                        connect.Open();

                        //Добавление
                        using (var cmd = new NpgsqlCommand())
                        {
                            cmd.Connection = connect;

                            //Добавление бланка
                            if(Users_CB.SelectedItem.ToString() == "Должность 2")
                            {
                                if(NumberDoc_TB.Text.Trim() != "")
                                {
                                    //Присваивание номера документа
                                    Item.NumberDoc = NumberDoc_TB.Text;

                                    //Запись в бд
                                    cmd.CommandText = $"UPDATE \"Orders\" SET \"Status_Order\" = '{Item.Status}', \"NumberDoc_Order\" = '{Item.NumberDoc}'" +
                                                      $" WHERE \"Number_Order\" = '{Item.Number}'";
                                    cmd.ExecuteNonQuery();
                                    //Вывод в компонент сообщения об удачном добавлении
                                    Status_TB.AppendText($"Документ {Item.Name} QR: {Item.QR} получил статус {Item.Status} и номер бланка {Item.NumberDoc}" + Environment.NewLine);

                                    ResultSpisok_LB.Items.Add(Spisok_LB.Items[Spisok_LB.SelectedIndex]); //добавляем элемент в список обработанных данных
                                    Spisok_LB.Items.RemoveAt(Spisok_LB.SelectedIndex);//Удаляем из старого LB
                                }
                                else
                                {
                                    NumberDoc_TB.Focus();
                                    MessageBox.Show("Необходимо ввести номер бланка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    Status_TB.AppendText($"Документ {Item.Name} QR: {Item.QR} неудачная попытка получения статуса и номера бланка" + Environment.NewLine);
                                }
                            }
                            else
                            {
                                cmd.CommandText = $"UPDATE \"Orders\" SET \"Status_Order\" = '{Item.Status}' WHERE \"Number_Order\" = '{Item.Number}'";
                                cmd.ExecuteNonQuery();

                                //Вывод в компонент сообщения об удачном добавлении
                                Status_TB.AppendText($"Документ {Item.Name} QR: {Item.QR} получил статус {Item.Status}" + Environment.NewLine);

                                ResultSpisok_LB.Items.Add(Spisok_LB.Items[Spisok_LB.SelectedIndex]); //добавляем элемент в список обработанных данных
                                Spisok_LB.Items.RemoveAt(Spisok_LB.SelectedIndex);//Удаляем из старого LB
                            }
                        }

                        //Закрытие потока
                        connect.Close();
                    }

                    //Активируем кнопку
                    if(ResultSpisok_LB.Items.Count > 0)
                    {
                        ClearResultSpisok_B.Enabled = true;
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

<<<<<<< HEAD
=======
        private void ConfirmALL_B_Click(object sender, EventArgs e)
        {
            //очистка
            Status_TB.Clear();

            //Изменение статуса объекта
            for (Int32 i = Spisok_LB.Items.Count - 1; i >= 0; i--)
            {
                //Зависимость статуса от должности
                
                    Document Document = Spisok_LB.Items[i] as Document;
                Document.Status = GetStatus(Users_CB.SelectedItem.ToString());

                //Запись нового статуса объекта в бд
                //Провверка на ошибки
                try
                    {
                        //Строка подлючения
                        String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = askede12; Database = KuzbassTest_DB;";

                        using (var connect = new NpgsqlConnection(connString))
                        {
                            //Открытие потока
                            connect.Open();

                            //Добавление
                            using (var cmd = new NpgsqlCommand())
                            {
                                cmd.Connection = connect;
                                cmd.CommandText = $"UPDATE \"Orders\" SET \"Status_Order\" = '{Document.Status}' WHERE \"Number_Order\" = '{Document.Number}'";
                                cmd.ExecuteNonQuery();
                            }

                            //Закрытие потока
                            connect.Close();
                        }

                        //Вывод в компонент сообщения об удачном добавлении
                        Status_TB.AppendText($"Документ {Document.Name} QR: {Document.QR} получил статус {Document.Status}" + Environment.NewLine);

                        ResultSpisok_LB.Items.Add(Spisok_LB.Items[i]); //добавляем элемент в список обработанных данных
                        Spisok_LB.Items.RemoveAt(i);//Удаляем из старого LB

                        //Активируем кнопку
                        if (Spisok_LB.Items.Count > 0)
                        {
                            ClearResultSpisok_B.Enabled = true;
                        }
                    }
                
                catch (Exception Npgsql)
                {
                    MessageBox.Show(Npgsql.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }


>>>>>>> ec26643225f059bce3c8c4513c7ce72ba83ebfe4
        private void OpenDocument_B_Click(object sender, EventArgs e)
        {
            Status_TB.Clear();

<<<<<<< HEAD
            //Выбирается файл, достаются с него все необходимые данные, преобразуется если необходимо <- ТВОЁ
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;

            GetValues(filename);

            //Объект, дальше работай с ним
            Document Temp = new Document();// <- Передашь данные сюда

            //Добвение статуса
            Temp.Status = "Чертеж передан в ПДО";

            //Провверка на ошибки
            try
            {
                //Строка подлючения
                String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = exxttazz1; Database = KuzbassTest_DB;";

                using (var connect = new NpgsqlConnection(connString))
                {
                    //Открытие потока
                    connect.Open();

                    //Добавление
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connect;
                        cmd.CommandText = $"INSERT INTO \"Orders\"(\"QR_order\",\"executor_order\"," +
                                          $"\"status_order\", \"number_order\",\"list_order\",\"mark_order\",\"lenght_order\", \"weight_order\") " +
                                          $"VALUES('{Temp.QR}','{Temp.Executor}','{Temp.Status}','{Temp.QR}','{Temp.Number}','{Temp.List}','{Temp.Name}','{Temp.Lenght}','{Temp.Weight})'";
                    }

                    //Закрытие потока
                    connect.Close();
                }

                //Вывод в компонент сообщения об удачном добавлении
                Status_TB.AppendText($"Номер заказа {Temp.Number} Марка: {Temp.Name} Лист: {Temp.List}" + Environment.NewLine);
                //Вывод сообщения
                MessageBox.Show($"Номер заказа {Temp.Number} Марка: {Temp.Name} Лист: {Temp.List}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Npgsql)
            {
                MessageBox.Show(Npgsql.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

=======
            //Выбирается файл, достаются с него все необходимые данные, преобразуется если необходимо
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;

                GetValues(filename);
                Array.Resize(ref Number_Order, values.Length / 7);
                Array.Resize(ref Name_Order, values.Length / 7);
                Array.Resize(ref QR_Order, values.Length / 7);
                Array.Resize(ref NumberDoc_Order, values.Length / 7);
                for (int i = 1; i < values.Length / 7; i++)
                {
                    //Создается объект класса Document и работаем дальше с ним
                    //Разделение данных QR кода на составляющие
                    Number_Order[i] = values[i, 0].Remove(values[i, 0].IndexOf(" "), values[i, 0].Length - values[i, 0].IndexOf(" "));
                    values[i, 0] = values[i, 0].Remove(0, values[i, 0].IndexOf(" ") + 1);
                    Name_Order[i] = values[i, 0].Remove(values[i, 0].IndexOf(" "), values[i, 0].Length - values[i, 0].IndexOf(" "));
                    values[i, 0] = values[i, 0].Remove(0, values[i, 0].IndexOf(" ") + 1);
                    QR_Order[i] = values[i, 0];
                    //Объект, его и используй при дальнейшей работе 
                    Document Temp = new Document(Name_Order[i], Number_Order[i], "Файл загружен", QR_Order[i]);

                    //Добавление данных в таблицу Orders
                    //Провверка на ошибки
                    try
                    {
                        //Строка подлючения
                        String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = askede12; Database = KuzbassTest_DB;";

                        using (var connect = new NpgsqlConnection(connString))
                        {
                            //Открытие потока
                            connect.Open();

                            //Добавление
                            using (var cmd = new NpgsqlCommand())
                            {
                                cmd.Connection = connect;
                                cmd.CommandText = $"INSERT INTO \"Orders\" (\"Number_Order\",\"Name_Order\",\"Status_Order\",\"QR_Order\")" +
                                                  $" VALUES ('{Temp.Number}','{Temp.Name}','{Temp.Status}','{Temp.QR}')";
                                cmd.ExecuteNonQuery();
                            }

                            //Закрытие потока
                            connect.Close();
                        }

                        //Вывод в компонент сообщения об удачном добавлении
                        Status_TB.AppendText($"Документ {Temp.Name} QR: {Temp.QR} успешно добавлен в обработку" + Environment.NewLine);
                        //Вывод сообщения
                        MessageBox.Show($"Файл {Temp.Name} QR {Temp.QR} успешно добавлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception Npgsql)
                    {
                        MessageBox.Show(Npgsql.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch
            {
                MessageBox.Show("Файл поврежден или создан некорректно.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
>>>>>>> ec26643225f059bce3c8c4513c7ce72ba83ebfe4
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Добавляем по умолчанию
            Users_CB.Items.Add("Не задано");
            //Установка тестовых данных по умолчанию на "Не задано"
            Users_CB.SelectedIndex = 0;

            //Блокирование всех кнопок
            OpenDocument_B.Enabled = false;
            Confirm_B.Enabled = false;
            RefreshSpisok_B.Enabled = false;
            ClearResultSpisok_B.Enabled = false;
            NumberDoc_TB.Enabled = false;

            try
            {
                NamePosition.SetPosition();

                if(NamePosition.Positions.Count != 0)
                {
                    //Вывод всех позиций в Users_CB
                    foreach (Position Temp in NamePosition.Positions)
                    {
                        Users_CB.Items.Add(Temp.Name);
                    }
                }
                else
                {
                    MessageBox.Show("Должности для интеграции не обнаружены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception Npgsql)
            {
                MessageBox.Show(Npgsql.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Users_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Users_CB.SelectedItem.ToString() == "Не задано")
            {
                //Блокироване и анлок кнопок
                OpenDocument_B.Enabled = false;
                Confirm_B.Enabled = false;
                RefreshSpisok_B.Enabled = false;
                ClearResultSpisok_B.Enabled = false;
                NumberDoc_TB.Enabled = false;

                //Очистка
                ClearField();
            }
            else if(Users_CB.SelectedItem.ToString() == "Должность 1")
            {
                //Блокироване и анлок кнопок
                Confirm_B.Enabled = false;
                RefreshSpisok_B.Enabled = false;
                ClearResultSpisok_B.Enabled = false;
                OpenDocument_B.Enabled = true;
                NumberDoc_TB.Enabled = false;

                //Очистка
                ClearField();
            }
            else if (Users_CB.SelectedItem.ToString() == "Должность 2")
            {
                //Блокироване и анлок кнопок
                Confirm_B.Enabled = false;
                RefreshSpisok_B.Enabled = true;
                ClearResultSpisok_B.Enabled = false;
                OpenDocument_B.Enabled = false;
                NumberDoc_TB.Enabled = true;

                //Очистка
                ClearField();
            }
            else
            {
                //Блокироване и анлок кнопок
                OpenDocument_B.Enabled = false;
                Confirm_B.Enabled = false;
                RefreshSpisok_B.Enabled = true;
                ClearResultSpisok_B.Enabled = false;
                OpenDocument_B.Enabled = false;
                NumberDoc_TB.Enabled = false;

                //Очистка
                ClearField();
            }
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
                String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = exxttazz1; Database = KuzbassTest_DB;";

                using (var connect = new NpgsqlConnection(connString))
                {
                    //Открытие потока
                    connect.Open();

                    if(Users_CB.SelectedItem.ToString() == "Сотрудник ПДО")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Select \"QR_order\",\"executor_order\",\"status_order\", \"number_order\"," +
                                                           $"\"list_order\", \"mark_order\", \"lenght_order\", \"weight_order\"" +
                                                           $"from \"Orders\" where \"status_order\" = 'Чертеж передан в ПДО'; ", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1)));
                                }
                            }
                        }
                    }
                    else if(Users_CB.SelectedItem.ToString() == "Разработка МК")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Select \"QR_order\",\"executor_order\",\"status_order\", \"number_order\"," +
                                                           $"\"list_order\", \"mark_order\", \"lenght_order\", \"weight_order\"" +
                                                           $"from \"Orders\" where \"status_order\" = 'Выдан в работу'; ", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1)));
                                }
                            }
                        }
                    }
                    else if (Users_CB.SelectedItem.ToString() == "Формирование сдельного наряда")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Select \"QR_order\",\"executor_order\",\"status_order\", \"number_order\"," +
                                                           $"\"list_order\", \"mark_order\", \"lenght_order\", \"weight_order\"" +
                                                           $"from \"Orders\" where \"status_order\" = 'МК разработаны'; ", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1)));
                                }
                            }
                        }
                    }
                    else if (Users_CB.SelectedItem.ToString() == "Раскрой")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Select \"QR_order\",\"executor_order\",\"status_order\", \"number_order\"," +
                                                           $"\"list_order\", \"mark_order\", \"lenght_order\", \"weight_order\"" +
                                                           $"from \"Orders\" where \"status_order\" = 'Сдельный наряд создан'; ", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1)));
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
            }
            catch (Exception Npgsql)
            {
                MessageBox.Show(Npgsql.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Разблокировка кнопок
            if(Spisok_LB.Items.Count > 0 && Users_CB.SelectedItem.ToString() != "Сотрудник ПДО")
            {
                Confirm_B.Enabled = true;
            }
            else
            {
                Confirm_B.Enabled = true;
            }
        }

        private void ClearResultSpisok_B_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите очистить список?", "Информация", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)== DialogResult.OK)
            {
                if (ResultSpisok_LB.Items.Count > 0)
                {
                    //Очистка
                    ClearField();
                    ResultSpisok_LB.Items.Clear();
                    //блок кнопки
                    ClearResultSpisok_B.Enabled = false;
                }
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
        private string GetStatus(string id_User)
        {
            string Status = "";
            if (id_User == "Должность 2")
                Status = @"""Добавлен номер бланка""";
            else if (id_User == "Должность 3")
                Status = @"""В обработке""";
            else if (id_User == "Должность 4")
                Status = @"""На подтверждении""";
            else if (id_User == "Должность 5")
                Status = @"""Подтверждено""";
            else if (id_User == "Должность 6")
                Status = @"""В работе""";
            else if (id_User == "Должность 7")
                Status = @"""Почти выполнено""";
            else if (id_User == "Должность 8")
                Status = @"""Выполнено""";
            return Status;
        }
    }
}
