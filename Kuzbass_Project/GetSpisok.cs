using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Kuzbass_Project
{
    static class GetSpisok
    {
        static internal void GetSpisokItemsNO (ListBox TempList, String Mode)
        {
            try
            {
                //Строка подлючения
                String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = exxttazz1; Database = KuzbassTest_DB;";

                using (var connect = new NpgsqlConnection(connString))
                {
                    //Открытие потока
                    connect.Open();

                    if (Mode == "Архивариус")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand("Зарос для архивариуса", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    TempList.Items.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
                            }
                        }
                    }
                    else if (Mode == "Сотрудник ПДО")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Ззапрос для ПДО", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    TempList.Items.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
                            }
                        }
                    }
                    else if (Mode == "Разработка МК")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Запрос для МК", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    TempList.Items.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
                            }
                        }
                    }
                    else if (Mode == "Формирование сдельного наряда")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Запрос для формирования", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    TempList.Items.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
                            }
                        }
                    }
                    else if (Mode == "Раскрой")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Запрос для раскроя ", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    TempList.Items.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
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
        }

        static internal void GetSpisokItemsYES(ListBox TempList, String Mode)
        {
            try
            {
                //Строка подлючения
                String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = exxttazz1; Database = KuzbassTest_DB;";

                using (var connect = new NpgsqlConnection(connString))
                {
                    //Открытие потока
                    connect.Open();

                    if (Mode == "Архивариус")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand("Зарос для архивариуса", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    TempList.Items.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
                            }
                        }
                    }
                    else if (Mode == "Сотрудник ПДО")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Ззапрос для ПДО", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    TempList.Items.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
                            }
                        }
                    }
                    else if (Mode == "Разработка МК")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Запрос для МК", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    TempList.Items.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
                            }
                        }
                    }
                    else if (Mode == "Формирование сдельного наряда")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Запрос для формирования", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    TempList.Items.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
                            }
                        }
                    }
                    else if (Mode == "Раскрой")
                    {
                        //Чтение
                        using (var cmd = new NpgsqlCommand($"Запрос для раскроя ", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    TempList.Items.Add(new Document(reader.GetString(5), reader.GetString(3), reader.GetString(2), reader.GetString(0),
                                                                     reader.GetString(6), reader.GetString(7), reader.GetString(4), reader.GetString(1), "Нет даты"));
                                }
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
        }
    }
}
