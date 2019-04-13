using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Kuzbass_Project
{
    public partial class OperationForFiles : Form
    {
        public OperationForFiles(String Mode,String Host,Int32 Port)
        {
            InitializeComponent();
            this.Mode = Mode;
            this.Port = Port;
            this.Host = Host;
        }
        String Host;
        Int32 Port;

        //Режим работы из главной формы
        String Mode;

        private void OperationForFiles_Load(object sender, EventArgs e)
        {
            Mode_CB.Items.AddRange(new String[] {"Не задано", "Не подтвержденные документы", "Подтвержденные документы" });
            Mode_CB.SelectedIndex = 0;
        }

        private void RefreshSpisok_B_Click(object sender, EventArgs e)
        {
            //Очистка от старых данных
            Spisok_LB.Items.Clear();

            Change_B.Enabled = false;
            Delete_B.Enabled = false;

            String Host = null;
            Int32 Port = 0;

            //Подгружаем параметры подключения
            if (File.Exists(@"Connect\DataBase\DateConnect.txt"))
            {
                //Считываем параметры подлючения
                try
                {
                    using (StreamReader sr = new StreamReader(File.Open(@"Connect\DataBase\DateConnect.txt", FileMode.Open)))
                    {
                        Host = sr.ReadLine();
                        Port = Convert.ToInt32(sr.ReadLine());
                    }
                }
                catch
                {
                    MessageBox.Show("При считывании параметров подлючения произошла ошибка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Файд с параметрами подлючения отсутсвует. Необходимо добавить файл DateConnect.txt", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(Host != null & Port != 0)
            {
                if (Mode_CB.SelectedItem.ToString() == "Не подтвержденные документы")
                {
                    //Заполняем список
                    GetSpisok.GetSpisokItemsNO(Spisok_LB, Mode, Host, Port);

                    //Разблокировка кнопок
                    if (Spisok_LB.Items.Count > 0)
                    {
                        ClearSpisok_B.Enabled = true;
                    }
                    else
                    {
                        ClearSpisok_B.Enabled = false;
                        MessageBox.Show("Не подтвержденные документы не обнаружены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Mode_CB.SelectedItem.ToString() == "Подтвержденные документы")
                {
                    //Заполняем список
                    GetSpisok.GetSpisokItemsYES(Spisok_LB, Mode, Host, Port);

                    //Разблокировка кнопок
                    if (Spisok_LB.Items.Count > 0)
                    {
                        ClearSpisok_B.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Подтвержденные документы не обнаружены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Mode_CB.SelectedItem.ToString() == "Не задано")
                {
                    Mode_CB.Focus();
                    MessageBox.Show("Необходимо выбрать режим отображения", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Mode_CB.Focus();
                    MessageBox.Show("Ошибка при обновлении данных", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Mode_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mode_CB.SelectedItem.ToString() == "Не задано")
            {
                Change_B.Enabled = false;
                Delete_B.Enabled = false;
                RefreshSpisok_B.Enabled = false;
                Spisok_LB.Enabled = false;
                ClearSpisok_B.Enabled = false;
                Spisok_LB.Items.Clear();
            }
            else if(Mode_CB.SelectedItem.ToString() == "Не подтвержденные документы")
            {
                RefreshSpisok_B.Enabled = true;
                Spisok_LB.Enabled = true;
                Spisok_LB.Items.Clear();
                ClearSpisok_B.Enabled = false;
                Change_B.Enabled = false;
                Delete_B.Enabled = false;
                RefreshSpisok_B.PerformClick();
            }
            else if (Mode_CB.SelectedItem.ToString() == "Подтвержденные документы")
            {
                RefreshSpisok_B.Enabled = true;
                Spisok_LB.Enabled = true;
                Spisok_LB.Items.Clear();
                ClearSpisok_B.Enabled = false;
                Change_B.Enabled = false;
                Delete_B.Enabled = false;
                RefreshSpisok_B.PerformClick();
            }
            else
            {
                Mode_CB.Focus();
                MessageBox.Show("Неизвестный режим отображения списка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Spisok_LB.Items.Clear();
            }
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            if(Spisok_LB.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить документ?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    Document Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as Document;

                    String connString = $"Server = {Host}; Port = {Port}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

                    using (var connect = new NpgsqlConnection(connString))
                    {
                        connect.Open();

                        using (var cmd = new NpgsqlCommand())
                        {
                            cmd.Connection = connect;
                            cmd.CommandText = $"DELETE FROM \"StatusOrders\" WHERE((SELECT \"id_Order\" FROM \"Orders\" WHERE \"QR_Order\" = '{Temp.QR}')= \"id_Order\");" +
                                              $"DELETE FROM \"NumberDocOrders\" WHERE((SELECT \"id_Order\" FROM \"Orders\" WHERE \"QR_Order\" = '{Temp.QR}') = \"id_Order\");" +
                                              $"DELETE FROM \"Orders\" WHERE \"QR_Order\" = '{Temp.QR}';";
                            cmd.ExecuteNonQuery();
                        }
                        connect.Close();
                    }

                    //Удаляем из списка
                    Spisok_LB.Items.RemoveAt(Spisok_LB.SelectedIndex);

                    Change_B.Enabled = false;
                    Delete_B.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать элемент", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Change_B_Click(object sender, EventArgs e)
        {
            if (Spisok_LB.SelectedIndex >= 0)
            {
                Document Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as Document;

                Change Dialog = new Change(Mode, Temp.Status);
                Dialog.QR_TB.Text = Temp.QR;
                Dialog.NumberDoc_TB.Text = Temp.NumberDoc;

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    String connString = $"Server = {Host}; Port = {Port}; User Id = postgres; Password = exxttazz1; Database = DocumentFlow_DB;";

                    using (var connect = new NpgsqlConnection(connString))
                    {
                        connect.Open();

                        using (var cmd = new NpgsqlCommand())
                        {
                            if (Mode == "Сотрудник ПДО")
                            {
                                Temp.NumberDoc = Dialog.NumberDoc_TB.Text;
                                cmd.Connection = connect;
                                cmd.CommandText = $"UPDATE \"NumberDocOrders\" SET \"NumberDoc\" = '{Temp.NumberDoc}'" +
                                                  $"WHERE((SELECT \"id_Order\" FROM \"Orders\" WHERE \"QR_Order\" = '{Temp.QR}') = \"id_Order\")";
                                cmd.ExecuteNonQuery();
                            }

                            Temp.Status = Dialog.Status_CB.SelectedItem.ToString();
                            cmd.Connection = connect;
                            cmd.CommandText = $"UPDATE \"StatusOrders\" SET \"Status_Order\" = '{Temp.Status}'" +
                                              $"WHERE((SELECT \"id_Order\" FROM \"Orders\" WHERE \"QR_Order\" = '{Temp.QR}') = \"id_Order\")";
                            cmd.ExecuteNonQuery();
                        }
                        connect.Close();
                    }

                    //Обновляем
                    RefreshSpisok_B.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать элемент", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Spisok_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Spisok_LB.SelectedIndex >= 0)
            {
                Change_B.Enabled = true;
                Delete_B.Enabled = true;
            }
            else
            {
                Change_B.Enabled = false;
                Delete_B.Enabled = false;
            }
        }

        private void ClearSpisok_B_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите очистить список?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            {
                Spisok_LB.Items.Clear();
                ClearSpisok_B.Enabled = false;
                Change_B.Enabled = false;
                Delete_B.Enabled = false;
            }
        }
    }
}
