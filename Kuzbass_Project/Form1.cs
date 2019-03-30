﻿using System;
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
            Status_TB.Clear();
            Documents.Clear();

            if(Spisok_LB.SelectedIndex >= 0)
            {
                //Запись нового статуса объекта в бд
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

                            //Выделенный документ из списка
                            Document Temp = Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as Document;

                            //Запросы на подтверждение
                            if(Users_CB.SelectedItem.ToString() == "Архивариус")
                            {
                                Temp.Status = "\"Передан в ПДО\"";
                            }
                            else if(Users_CB.SelectedItem.ToString() == "Сотрудник ПДО")
                            {
                                Temp.Status = "\"Выдан в работу\"";

                                //Берем номер бланка
                                if (NumberDoc_TB.Text.Trim() != "")
                                {
                                    //Присваивание номера документа
                                    Temp.NumberDoc = NumberDoc_TB.Text.Trim();

                                    //Запись в бд
                                    cmd.CommandText = $"UPDATE \"Orders\" SET \"status_order\" = '{Temp.Status}' WHERE \"QR_order\" = '{Temp.QR}';" +
                                                      $"Insert into \"Doc\"(\"QR_order\",\"number_doc\") values('{Temp.QR}', '{Temp.NumberDoc}')";
                                    ;
                                    cmd.ExecuteNonQuery();

                                    Status_TB.AppendText($"Номер заказа {Temp.Number} Марка: {Temp.Name} Лист: {Temp.List} получил статус {Temp.Status} и номер бланка {Temp.NumberDoc}" + Environment.NewLine);
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
                            else if (Users_CB.SelectedItem.ToString() == "Разработка МК")
                            {
                                Temp.Status = "\"МК разработаны\"";
                            }
                            else if (Users_CB.SelectedItem.ToString() == "Формирование сдельного наряда")
                            {
                                Temp.Status = "\"Сдельный наряд создан\"";
                            }
                            else if (Users_CB.SelectedItem.ToString() == "Раскрой")
                            {
                                Temp.Status = "\"Раскрой создан\"";
                            }

                            //Вывод в компонент сообщения об удачном добавлении
                            if(Temp.Status != "\"Выдан в работу\"")
                            {
                                //Запись в бд
                                cmd.CommandText = $"UPDATE \"Orders\" SET \"status_order\" = '{Temp.Status}' WHERE \"QR_order\" = '{Temp.QR}';";
                                cmd.ExecuteNonQuery();

                                Status_TB.AppendText($"Номер заказа {Temp.Number} Марка: {Temp.Name} Лист: {Temp.List} получил статус {Temp.Status}" + Environment.NewLine);
                            }
                            
                            //Добавляем элемент в список обработанных данных
                            ResultSpisok_LB.Items.Add(Spisok_LB.Items[Spisok_LB.SelectedIndex]); 
                            Spisok_LB.Items.RemoveAt(Spisok_LB.SelectedIndex);//Удаляем из старого LB
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

        private void OpenDocument_B_Click(object sender, EventArgs e)
        {
            Status_TB.Clear();

            ////Выбирается файл, достаются с него все необходимые данные, преобразуется если необходимо <- ТВОЁ
            //if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            //    return;
            //string filename = openFileDialog1.FileName;
            ////Объект, дальше работай с ним
            Document Temp = new Document();
            //Excel value = new Excel();
            //value.GetValues(filename);
            //value.CreateHeaderReg();            

            ////Добвение статуса
            //ExcelPackage workbook = new ExcelPackage(new System.IO.FileInfo(@"C:\Users\Админ-Пк\Desktop\Реестр\Реестр.xlsx"));
            //ExcelWorksheet ws1 = workbook.Workbook.Worksheets[1];
            //var rowCnt = ws1.Dimension.End.Row;
            //int b = value.GetLeight();
            //string date = DateTime.Now.ToString();
            //date = date.Replace(".", "_");
            //date = date.Replace(":", "_");
            //saveFileDialog1.FileName = "Акт " + date;
            //saveFileDialog1.Filter = "Microsoft Excel Worksheet (*.xlsx)|*.xlsx";
            //System.IO.FileInfo fInfoSrc = new System.IO.FileInfo(@"C:\Users\Админ-Пк\Desktop\Акты\Шаблон.xlsx");
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    System.IO.FileInfo file = new System.IO.FileInfo(saveFileDialog1.FileName);
            //    try
            //    {
            //        var wb1 = new ExcelPackage(fInfoSrc).File.CopyTo(saveFileDialog1.FileName);
            //    }
            //    catch
            //    {
            //        System.IO.File.Delete(saveFileDialog1.FileName);
            //        var wb1 = new ExcelPackage(fInfoSrc).File.CopyTo(saveFileDialog1.FileName);
            //    }
            //}
            //ExcelPackage workbook1 = new ExcelPackage(new System.IO.FileInfo(saveFileDialog1.FileName));
            //ExcelWorksheet ws2 = workbook1.Workbook.Worksheets[1];
            //var rowCntAct = ws2.Dimension.End.Row;

            //for (int i = 1; i + rowCnt < b + rowCnt; i++)
            //{
            //    value.WriteReg(Temp,i,rowCnt);
            //    if (saveFileDialog1.FileName.IndexOf(@":\") != -1)
            //    {

            //        ws2.Cells[i + rowCntAct, 1].Value = Temp.Number;
            //        ws2.Cells[i + rowCntAct, 2].Value = Temp.List;
            //        ws2.Cells[i + rowCntAct, 3].Value = Temp.Name;
            //        ws2.Cells[i + rowCntAct, 4].Value = Temp.Executor;
            //        ws2.Cells[i + rowCntAct, 5].Value = Temp.Lenght;
            //        ws2.Cells[i + rowCntAct, 6].Value = Temp.Weight;
            //    }

            //Список для хранения просканированных QR
            List<String> QR_Documents = new List<String>(); //< - РАБОТАТЬ С НИМ

            //Вызываем форму
            AddDocument Dialog = new AddDocument();
            
            if(Dialog.ShowDialog() == DialogResult.OK)
            {
                for(Int32 i = 0; i < Dialog.Spisok_LB.Items.Count; i++)
                {
                    QR_Documents.Add(Dialog.Spisok_LB.Items[i] as String);
                }
            }

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
                                          $"VALUES('{Temp.QR}','{Temp.Executor}','{Temp.Status}','{Temp.Number}','{Temp.List}','{Temp.Name}','{Temp.Lenght}','{Temp.Weight}')";
                        cmd.ExecuteNonQuery();
                    }

                    //Закрытие потока
                    connect.Close();
                }

                //Вывод в компонент сообщения об удачном добавлении
                Status_TB.AppendText($"Номер заказа {Temp.Number} Марка: {Temp.Name} Лист: {Temp.List} добавлен в базу трекинга" + Environment.NewLine);

                //Обновляем данные
                RefreshSpisok_B.PerformClick();
            }
            catch (Exception)
            {
                MessageBox.Show($"QR { Temp.QR} загружен не корректно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //}

            //int last = ws2.Dimension.End.Row;
            //ws2.Cells[last + 2, 4].Value = "Принял";
            //ws2.Cells[last + 3, 4].Value = "Сдал";
            //ws2.Cells[last + 2, 6].Value = "______________";
            //ws2.Cells[last + 3, 6].Value = "______________";
            //ws2.Cells[last + 2, 7].Value = "Линник О.В.";
            //ws2.Cells[last + 3, 7].Value = "/______________/";
            //workbook1.Save();
            MessageBox.Show($"Чертежи успешно добавлены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Exit_B.Enabled = false;
            Operations_B.Enabled = false;

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
                Enter_B.Enabled = false;
            }
            else
            {
                Enter_B.Enabled = true;
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

                    if(Users_CB.SelectedItem.ToString() == "Архивариус")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand("Зарос для архивариуса", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
                            }
                        }
                    }
                    else if(Users_CB.SelectedItem.ToString() == "Сотрудник ПДО")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Select \"QR_order\",\"executor_order\",\"status_order\", \"number_order\"," +
                                                           $"\"list_order\", \"mark_order\", \"lenght_order\", \"weight_order\"" +
                                                           $"from \"Orders\" where \"status_order\" = '\"Чертеж передан в ПДО\"'; ", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
                            }
                        }
                    }
                    else if(Users_CB.SelectedItem.ToString() == "Разработка МК")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Select \"QR_order\",\"executor_order\",\"status_order\", \"number_order\"," +
                                                           $"\"list_order\", \"mark_order\", \"lenght_order\", \"weight_order\"" +
                                                           $"from \"Orders\" where \"status_order\" = '\"Выдан в работу\"'; ", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
                            }
                        }
                    }
                    else if (Users_CB.SelectedItem.ToString() == "Формирование сдельного наряда")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Select \"QR_order\",\"executor_order\",\"status_order\", \"number_order\"," +
                                                           $"\"list_order\", \"mark_order\", \"lenght_order\", \"weight_order\"" +
                                                           $"from \"Orders\" where \"status_order\" = '\"МК разработаны\"'; ", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
                            }
                        }
                    }
                    else if (Users_CB.SelectedItem.ToString() == "Раскрой")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Select \"QR_order\",\"executor_order\",\"status_order\", \"number_order\"," +
                                                           $"\"list_order\", \"mark_order\", \"lenght_order\", \"weight_order\"" +
                                                           $"from \"Orders\" where \"status_order\" = '\"Сдельный наряд создан\"'; ", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    Documents.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
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
                    MessageBox.Show("Документы не обнаружены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Npgsql)
            {
                MessageBox.Show(Npgsql.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Разблокировка кнопок
            if(Spisok_LB.Items.Count > 0)
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

        private void Exit_B_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Информация", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Users_CB.Enabled = true;
                ClearField();
                NumberDoc_TB.Text = "";
                NumberDoc_TB.Enabled = false;
                OpenDocument_B.Enabled = false;
                Confirm_B.Enabled = false;
                RefreshSpisok_B.Enabled = false;
                ClearResultSpisok_B.Enabled = false;
                OpenDocument_B.Enabled = false;
                NumberDoc_TB.Enabled = false;
                Enter_B.Enabled = true;
                Exit_B.Enabled = false;
            }
        }

        private void Enter_B_Click(object sender, EventArgs e)
        {
            if (Users_CB.SelectedIndex != 0)
            {
                String login = Users_CB.SelectedItem.ToString();

                PassForm Dialog = new PassForm();

                Dialog.Login_TB.Text = login;

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    Users_CB.Enabled = false;

                    if (login == "Архивариус")
                    {
                        //Блокироване и анлок кнопок
                        OpenDocument_B.Enabled = true;
                        Confirm_B.Enabled = false;
                        RefreshSpisok_B.Enabled = true;
                        ClearResultSpisok_B.Enabled = false;
                        NumberDoc_TB.Enabled = false;
                        Enter_B.Enabled = false;
                        Exit_B.Enabled = true;
                        Operations_B.Enabled = true;

                        //Очистка
                        ClearField();
                    }
                    else if (login == "Сотрудник ПДО")
                    {
                        //Блокироване и анлок кнопок
                        Confirm_B.Enabled = false;
                        RefreshSpisok_B.Enabled = true;
                        ClearResultSpisok_B.Enabled = false;
                        OpenDocument_B.Enabled = false;
                        NumberDoc_TB.Enabled = true;
                        Enter_B.Enabled = false;
                        Exit_B.Enabled = true;
                        Operations_B.Enabled = true;

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
                        Enter_B.Enabled = false;
                        Exit_B.Enabled = true;
                        Operations_B.Enabled = true;

                        //Очистка
                        ClearField();
                    }
                }
            }
        }

        private void Operations_B_Click(object sender, EventArgs e)
        {
            OperationForFiles Dialog = new OperationForFiles(Users_CB.SelectedItem.ToString());
            if (Dialog.ShowDialog() == DialogResult.OK) { }
        }
    }
}
