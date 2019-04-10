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
        static public void SetPosition(String Host, Int32 Port)
        {
            String connString = $"Server = {Host}; Port = {Port}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

            using (var connect = new NpgsqlConnection(connString))
            {
                connect.Open();

                using (var cmd = new NpgsqlCommand($"SELECT \"Name_Position\",\"HashPass_Position\" FROM \"Positions\";", connect))
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
