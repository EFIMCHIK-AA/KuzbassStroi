using System;
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
    public partial class Change : Form
    {
        public Change(String Mode, String Status)
        {
            InitializeComponent();
            this.Mode = Mode;
            this.Status = Status;
        }

        String Status;
        String Mode;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void Change_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(QR_TB.Text))
                    {
                        QR_TB.Focus();
                        throw new Exception("Необходимо ввести QR документа");
                    }

                    if (String.IsNullOrWhiteSpace(NumberDoc_TB.Text))
                    {
                        NumberDoc_TB.Focus();
                        throw new Exception("Необходимо ввести номер бланка");
                    }

                    if (Status_CB.SelectedItem.ToString() == "Не задано")
                    {
                        Status_CB.Focus();
                        throw new Exception("Необходимо выбрать статус");
                    }
                }
                catch(Exception E)
                {
                    MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void Change_Load(object sender, EventArgs e)
        {
            Status_CB.Items.Add("Не задано");
            Status_CB.SelectedIndex = 0;
            QR_TB.ReadOnly = true;

            if(Mode != "Сотрудник ПДО")
            {
                NumberDoc_TB.ReadOnly = true;
            }

            if(Mode == "Архивариус")
            {
                Status_CB.Items.AddRange(new String[] {"Нет статуса", "Передан в ПДО"});
                NumberDoc_TB.ReadOnly = true;
            }
            else if(Mode == "Сотрудник ПДО")
            {
                Status_CB.Items.AddRange(new String[] {"Передан в ПДО", "Выдан в работу"});
            }
            else if(Mode == "Разработка МК")
            {
                Status_CB.Items.AddRange(new String[] {"Выдан в работу", "МК разработаны"});
                NumberDoc_TB.ReadOnly = true;
            }
            else if(Mode == "Формирование сдельного наряда")
            {
                Status_CB.Items.AddRange(new String[] {"МК разработаны", "Сдельный наряд создан"});
                NumberDoc_TB.ReadOnly = true;
            }
            else if(Mode == "Раскрой")
            {
                Status_CB.Items.AddRange(new String[] {"Сдельный наряд создан", "Раскрой создан"});
                NumberDoc_TB.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке статусов документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(Status == Status_CB.Items[1].ToString())
            {
                Status_CB.SelectedIndex = 1;
            }
            else if(Status == Status_CB.Items[2].ToString())
            {
                Status_CB.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("Обнаружен несуществующий статус документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
