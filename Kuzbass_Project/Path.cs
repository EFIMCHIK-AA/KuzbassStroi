using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuzbass_Project
{
    public static class Path
    {
        public static String PathArchive;

        public static void GetPathArchive()
        {
            if (File.Exists($@"SavePath\Archive.txt"))
            {
                if (File.Exists($@"SavePath\Archive.txt"))
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(File.Open($@"SavePath\Archive.txt", FileMode.Open)))
                        {
                            PathArchive = sr.ReadLine();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("При считывании местонаждении архива произошла ошибка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Отсутствует файл Archive.txt. Введите порт в соответствующее поле и подтвердите сохранение, - файл Port.txt будет автоматически создан", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
