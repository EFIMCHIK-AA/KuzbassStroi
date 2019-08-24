using System;
using OfficeOpenXml;
using System.IO;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Kuzbass_Project
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            this.confirm = false;
        }
        bool confirm;

        private void Exit_B_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (confirm == true)
            {
                return;
            }

            Application.Exit();
        }

        private void ChangeUser_B_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите сменить пользователя?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                confirm = true;
                this.Close();
                Program.InitializationForm.Pass_TB.Clear();
                Program.InitializationForm.Show();
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            String MyHost = Dns.GetHostName();
            Host_TB.Text = Dns.GetHostByName(MyHost).AddressList[0].ToString();

            if (File.Exists($@"SavePath\Archive.txt"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(File.Open($@"SavePath\Archive.txt", FileMode.Open)))
                    {
                        PathArchive_TB.Text = sr.ReadLine();
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

            if (File.Exists(@"Connect\Port.txt"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(File.Open(@"Connect\Port.txt", FileMode.Open)))
                    {
                        Port_TB.Text = sr.ReadLine();
                    }
                }
                catch
                {
                    MessageBox.Show("При считывании порта произошла ошибка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Отсутствует файл Port.txt. Введите порт в соответствующее поле и подтвердите сохранение, - файл Port.txt будет автоматически создан", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (File.Exists(@"SavePath\Registry.txt"))
            {

                try
                {
                    using (StreamReader sr = new StreamReader(File.Open(@"SavePath\Registry.txt", FileMode.Open)))
                    {
                        Path_TB.Text = sr.ReadLine();
                    }

                }
                catch
                {
                    MessageBox.Show("При считывании места реестра произошла ошибка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Отсутствует файл Registry.txt. Введите порт в соответствующее поле и подтвердите сохранение, - файл Registry.txt будет автоматически создан", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (File.Exists(@"Connect\DataBase\DateConnect.txt"))
            {

                try
                {
                    using (StreamReader sr = new StreamReader(File.Open(@"Connect\DataBase\DateConnect.txt", FileMode.Open)))
                    {
                        HostDB_TB.Text = sr.ReadLine();
                        PortDB_TB.Text = sr.ReadLine();
                    }

                }
                catch
                {
                    MessageBox.Show("При считывании параметров подлючения произошла ошибка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Отсутствует файл DateConnect.txt. Введите данные подключения в соответствующие поля и подтвердите сохранение, - файл DateConnect.txt. будет автоматически создан", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Генерация QR
            Zen.Barcode.CodeQrBarcodeDraw QrCode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            QR_PB.Image = QrCode.Draw($"{Host_TB.Text.Trim()}_{Port_TB.Text.Trim()}", 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Port_TB.Text))
            {
                MessageBox.Show("Необходимо ввести порт для подлючения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Int32 port = Convert.ToInt32(Port_TB.Text);

                    if (port <= 48654 || port > 65535)
                    {
                        Port_TB.Focus();
                        throw new Exception("Использование портов в диапазоне [0..48654] не предусмотрено. Рекомендуется использовать порты в диапазоне [48654..48999] или [49152..65535]");
                    }

                    if (File.Exists(@"Connect\Port.txt"))
                    {
                        //Удаляем старый файл
                        File.Delete(@"Connect\Port.txt");
                    }

                    //Записываем новый порт
                    using (StreamWriter sw = new StreamWriter(File.Open(@"Connect\Port.txt", FileMode.Create)))
                    {
                        sw.WriteLine(Port_TB.Text.Trim());
                    }

                    //Пересобираем QR
                    Zen.Barcode.CodeQrBarcodeDraw QrCode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                    QR_PB.Image = QrCode.Draw($"{Host_TB.Text.Trim()}_{Port_TB.Text.Trim()}", 100);

                    MessageBox.Show("Порт успешно обновлен", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (FormatException)
                {
                    Port_TB.Focus();
                    MessageBox.Show("Порт подключения должен состоять из целых цифр", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception E)
                {
                    Port_TB.Focus();
                    Port_TB.Clear();
                    MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ChangePath_B_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Path_TB.Text))
            {
                MessageBox.Show("Необходимо указать путь сохранения реестра", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (File.Exists(@"SavePath\Registry.txt"))
                {
                    //Удаляем старый файл
                    File.Delete(@"SavePath\Registry.txt");
                }

                //Записываем новый порт
                using (StreamWriter sw = new StreamWriter(File.Open(@"SavePath\Registry.txt", FileMode.Create)))
                {
                    if (Path_TB.Text.LastIndexOf(@"\Реестр.xlsx") == -1)
                    {
                        sw.WriteLine(Path_TB.Text.Trim() + @"\Реестр.xlsx");
                    }
                    else
                    {
                        sw.WriteLine(Path_TB.Text.Trim());
                    }
                }

                MessageBox.Show("Путь реестра успешно обновлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(@"Шаблоны\ШаблонРеестр.xlsx"))
            {
                //Считываем место создания реестра из файла
                String path = null;

                //Считываем место реестра
                try
                {
                    using (StreamReader sr = new StreamReader(File.Open(@"SavePath\Registry.txt", FileMode.Open)))
                    {
                        path = sr.ReadLine();
                    }

                    if (File.Exists(path))
                    {
                        MessageBox.Show("Файл реестра уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        FileInfo fInfoSrc = new FileInfo(@"Шаблоны\ШаблонРеестр.xlsx");
                        var wb1 = new ExcelPackage(fInfoSrc).File.CopyTo(path);

                        MessageBox.Show("Файл реестра успешно создан", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка при создании реестра", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Создание реестра невозможно. Шаблон реестра отсутствует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveBD_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(HostDB_TB.Text))
                {
                    throw new Exception("Необходимо ввести хост базы данных");
                }

                if (String.IsNullOrWhiteSpace(PortDB_TB.Text))
                {
                    throw new Exception("Необходимо ввести порт базы данных");
                }

                if (File.Exists(@"Connect\DataBase\DateConnect.txt"))
                {
                    //Удаляем старый файл
                    File.Delete(@"Connect\DataBase\DateConnect.txt");
                }

                //Записываем новый порт
                using (StreamWriter sw = new StreamWriter(File.Open(@"Connect\DataBase\DateConnect.txt", FileMode.Create)))
                {
                    sw.WriteLine(HostDB_TB.Text.Trim());
                    sw.WriteLine(PortDB_TB.Text.Trim());
                }

                MessageBox.Show("Параметры подлючения успешно обновлены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(PathArchive_TB.Text))
                {
                    throw new Exception("Необходимо ввести местонаждение архива");
                }

                if (File.Exists($@"SavePath\Archive.txt"))
                {
                    //Удаляем старый файл
                    File.Delete($@"SavePath\Archive.txt");
                }

                //Записываем новый
                using (StreamWriter sw = new StreamWriter(File.Open($@"SavePath\Archive.txt", FileMode.Create)))
                {
                    sw.WriteLine(PathArchive_TB.Text.Trim());
                }

                MessageBox.Show("Параметры подлючения успешно обновлены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
