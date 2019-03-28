using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kuzbass_Project
{
    class CSV
    {
        public static string[,] GetStringsFromFile(string filePath)
        {

            string[] rows = File.ReadAllLines(filePath);
            string[,] cells = null;

            int rowSize = rows.Length;
            int colSize = rows[0].Split('^').Length;

            cells = new string[rowSize, colSize];

            for (int i = 0; i < rowSize; i++)
            {
                colSize = rows[i].Split('^').Length;

                for (int j = 0; j < colSize; j++)
                {
                    cells[i, j] = rows[i].Split('^')[j];
                }
            }

            return cells;

        }
        public static string[,] GetStringsFromFile(string filePath, int colSize)
        {

            string[] rows = File.ReadAllLines(filePath);
            string[,] cells = null;

            int rowSize = rows.Length;

            cells = new string[rowSize, colSize];

            for (int i = 0; i < rowSize; i++)
            {
                //colSize = rows[i].Split('_').Length;

                for (int j = 0; j < colSize; j++)
                {
                    if (j >= rows[i].Split('^').Length)
                    {
                        cells[i, j] = "";
                    }
                    else
                    {
                        cells[i, j] = rows[i].Split('^')[j];
                    }
                }
            }

            return cells;

        }
    }
}
