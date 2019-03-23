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
        private string[] Number_Order = new string[100];
        private string[] Name_Order = new string[100];
        private string[] QR_Order = new string[100];
        private string[] NumberDoc_Order = new string[100];
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

        private void Confirm_B_Click(object sender, EventArgs e)
        {
            //очистка
            Status_TB.Clear();
            //Изменение статуса объекта
            if(Spisok_LB.SelectedIndex >= 0)
            {
                Document Item = Spisok_LB.Items[Spisok_LB.SelectedIndex] as Document;
                //Принадлежность статуса к должности
                if (Users_CB.SelectedItem.ToString() == "Должность 2")
                    Item.Status = "Введен номер бланка";
                if (Users_CB.SelectedItem.ToString() == "Должность 3")
                    Item.Status = "В обработке";
                if (Users_CB.SelectedItem.ToString() == "Должность 3")
                    Item.Status = "В обработке";
                if (Users_CB.SelectedItem.ToString() == "Должность 3")
                    Item.Status = "В обработке";
                if (Users_CB.SelectedItem.ToString() == "Должность 3")
                    Item.Status = "В обработке";
                if (Users_CB.SelectedItem.ToString() == "Должность 3")
                    Item.Status = "В обработке";
                if (Users_CB.SelectedItem.ToString() == "Должность 3")
                    Item.Status = "В обработке";

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

        private void ConfirmALL_B_Click(object sender, EventArgs e)
        {
            //очистка
            string status="";
            Status_TB.Clear();
            //Изменение статуса объекта
            for (Int32 i = Spisok_LB.Items.Count - 1; i >= 0; i--)
            {
                //Зависимость статуса от должности
                if (Users_CB.SelectedItem.ToString() == "Должность 3")
                    status = "В обработке";
                if(Users_CB.SelectedItem.ToString() == "Должность 4")
                    status = "В работе";
                if (Users_CB.SelectedItem.ToString() == "Должность 5")
                    status = "В работе";
                if (Users_CB.SelectedItem.ToString() == "Должность 6")
                    status = "В работе";
                if (Users_CB.SelectedItem.ToString() == "Должность 7")
                    status = "В работе";
                if (Users_CB.SelectedItem.ToString() == "Должность 8")
                    status = "В работе";
                    Document Document = Spisok_LB.Items[i] as Document;
                    Document.Status = status;//Тест

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

        //Перечисления

        private void OpenDocument_B_Click(object sender, EventArgs e)
        {
            //очистка
            Status_TB.Clear();

            //Выбирается файл, достаются с него все необходимые данные, преобразуется если необходимо <- ТВОЁ
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;

            GetValues(filename);
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
                Document Temp = new Document(Name_Order[i], Name_Order[i],"Файл загружен",QR_Order[i]);

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

        private void Form1_Load(object sender, EventArgs e)
        {
            //Добавляем по умолчанию
            Users_CB.Items.Add("Не задано");
            //Установка тестовых данных по умолчанию на "Не задано"
            Users_CB.SelectedIndex = 0;

            //Блокирование всех кнопок
            OpenDocument_B.Enabled = false;
            Confirm_B.Enabled = false;
            ConfirmALL_B.Enabled = false;
            RefreshSpisok_B.Enabled = false;
            ClearResultSpisok_B.Enabled = false;
            NumberDoc_TB.Enabled = false;

            //Загрузка пользователей с таблицы должностей в Users_CB
            //Провверка на ошибки
            try
            {
                //Строка подлючения
                String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = askede12; Database = KuzbassTest_DB;";

                using (var connect = new NpgsqlConnection(connString))
                {
                    //Открытие потока
                    connect.Open();

                    //Чтение
                    using (var cmd = new NpgsqlCommand($"SELECT \"NamePosition\" FROM \"Positions\"", connect))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //Вывод в компонент
                            while (reader.Read())
                            {
                                Users_CB.Items.Add(reader.GetString(0));
                            }
                        }
                    }

                    //Закрытие потока
                    connect.Close();
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
                ConfirmALL_B.Enabled = false;
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
                ConfirmALL_B.Enabled = false;
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
                ConfirmALL_B.Enabled = false;
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
                ConfirmALL_B.Enabled = false;
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

            //Загрузка пользователей с таблицы Orders в список Documents
            //Провверка на ошибки
            try
            {
                //Строка подлючения
                String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = askede12; Database = KuzbassTest_DB;";

                using (var connect = new NpgsqlConnection(connString))
                {
                    //Открытие потока
                    connect.Open();

                    //Чтение
                    using (var cmd = new NpgsqlCommand($"SELECT \"Number_Order\",\"Name_Order\",\"Status_Order\",\"QR_Order\"" +
                                                       $" FROM \"Orders\"", connect))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //Вывод в компонент
                            while (reader.Read())
                            {
                                Spisok_LB.Items.Add(new Document(reader.GetString(1), reader.GetString(0), reader.GetString(2), reader.GetString(3)));
                                Status_TB.AppendText((Spisok_LB.Items[Spisok_LB.Items.Count - 1] as Document).ToString() + " добавлен" + Environment.NewLine);
                            }
                        }
                    }

                    //Закрытие потока
                    connect.Close();
                }
            }
            catch (Exception Npgsql)
            {
                MessageBox.Show(Npgsql.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Разблокировка кнопок
            if(Spisok_LB.Items.Count > 0 && Users_CB.SelectedItem.ToString() != "Должность 2")
            {
                Confirm_B.Enabled = true;
                ConfirmALL_B.Enabled = true;
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
    }
}
