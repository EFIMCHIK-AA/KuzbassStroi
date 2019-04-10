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
        static internal void GetSpisokItemsNO (ListBox TempList, String Mode, String Host, Int32 Port)
        {
            try
            {
                //Строка подлючения
                String connString = $"Server = {Host}; Port = {Port}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

                using (var connect = new NpgsqlConnection(connString))
                {
                    //Открытие потока
                    connect.Open();

                    if (Mode == "Архивариус")
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
                                    TempList.Items.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetString(7), reader.GetString(9)));
                                }
                            }
                        }
                    }
                    else if (Mode == "Сотрудник ПДО")
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
                                    TempList.Items.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetString(7), reader.GetString(9)));
                                }
                            }
                        }
                    }
                    else if (Mode == "Разработка МК")
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
                                    TempList.Items.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
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
                                    TempList.Items.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
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
                                    TempList.Items.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetString(7), reader.GetString(9)));
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

        static internal void GetSpisokItemsYES(ListBox TempList, String Mode, String Host, Int32 Port)
        {
            try
            {
                //Строка подлючения
                String connString = $"Server = {Host}; Port = {Port}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

                using (var connect = new NpgsqlConnection(connString))
                {
                    //Открытие потока
                    connect.Open();

                    if (Mode == "Архивариус")
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
                                    TempList.Items.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetString(7), reader.GetString(9)));
                                }
                            }
                        }
                    }
                    else if (Mode == "Сотрудник ПДО")
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
                                    TempList.Items.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetString(7), reader.GetString(9)));
                                }
                            }
                        }
                    }
                    else if (Mode == "Разработка МК")
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
                                    TempList.Items.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
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
                                                           $" AND \"StatusOrders\".\"Status_Order\" = 'Сдельный наряд создан'", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    TempList.Items.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
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
                                                           $" AND \"StatusOrders\".\"Status_Order\" = 'Раскрой создан'", connect))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //Вывод в компонент
                                while (reader.Read())
                                {
                                    TempList.Items.Add(new Document(reader.GetString(4), reader.GetString(2), reader.GetString(8), reader.GetString(0), reader.GetString(5),
                                                               reader.GetString(6), reader.GetString(3), reader.GetString(1), reader.GetString(7), reader.GetString(9)));
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
