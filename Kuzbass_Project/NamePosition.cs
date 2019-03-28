using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuzbass_Project
{
    static class NamePosition
    {
        //Храним список должностей
        public static List<Position> Positions = new List<Position>();

        //Запись с бд в массив
        static public void SetPosition()
        {
            String connString = "Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = askede12; Database = KuzbassTest_DB;";

            using (var connect = new NpgsqlConnection(connString))
            {
                connect.Open();

                using (var cmd = new NpgsqlCommand($"Select \"name_position\",\"hashPass_postion\" from \"Positions\";", connect))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Positions.Add(new Position(reader.GetString(0), reader.GetString(1)));
                        }
                    }
                }

                connect.Close();
            }
        }

        //Получение пароля по текущему режиму работы
        public static String GetHashPass(String NamePosition) // <- Передаем пароль
        {
            foreach(Position Temp in Positions)
            {
                if(Temp.Name == NamePosition)
                {
                    return Temp.HashPass;
                }
            }

            return "Заданной должности не существует";
        }
    }
}
