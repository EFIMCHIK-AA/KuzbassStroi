using System;
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
        public OperationForFiles(String Mode)
        {
            InitializeComponent();
            this.Mode = Mode;
        }

        //Режим работы из главной формы
        String Mode;

        private void OperationForFiles_Load(object sender, EventArgs e)
        {
            Mode_CB.Items.AddRange(new String[] {"Не задано", "Не подтвержденные документы", "Подтвержденные документы" });
            Mode_CB.SelectedIndex = 0;
        }

        private void RefreshSpisok_B_Click(object sender, EventArgs e)
        {
            if(Mode_CB.SelectedItem.ToString() == "Не подтвержденные документы")
            {
                //Очистка от старых данных
                Spisok_LB.Items.Clear();

                //Заполняем список
                GetSpisok.GetSpisokItemsNO(Spisok_LB, Mode);

                //Разблокировка кнопок
                if (Spisok_LB.Items.Count > 0)
                {
                    Delete_B.Enabled = true;
                    ClearSpisok_B.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Документы не обнаружены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (Mode_CB.SelectedItem.ToString() == "Подтвержденные документы")
            {
                //Очистка от старых данных
                Spisok_LB.Items.Clear();

                //Заполняем список
                GetSpisok.GetSpisokItemsNO(Spisok_LB, Mode);

                //Разблокировка кнопок
                if (Spisok_LB.Items.Count > 0)
                {
                    Delete_B.Enabled = true;
                    ClearSpisok_B.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Документы не обнаружены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if(Mode_CB.SelectedItem.ToString() == "Не задано")
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

        private void Mode_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mode_CB.SelectedItem.ToString() == "Не задано")
            {
                Change_B.Enabled = false;
                Delete_B.Enabled = false;
                RefreshSpisok_B.Enabled = false;
                Spisok_LB.Enabled = false;
                ClearSpisok_B.Enabled = false;
            }
            else if(Mode_CB.SelectedItem.ToString() == "Не подтвержденные документы")
            {
                RefreshSpisok_B.Enabled = true;
                Spisok_LB.Enabled = true;
            }
            else if (Mode_CB.SelectedItem.ToString() == "Подтвержденные документы")
            {
                RefreshSpisok_B.Enabled = true;
                Spisok_LB.Enabled = true;
            }
            else
            {
                Mode_CB.Focus();
                MessageBox.Show("Неизвестный режим отображения списка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {

            if(Spisok_LB.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить документ?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    Document Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as Document;

                    //Запрос на удаление объекта из базы данных <- Сделать

                    //Удаляем из списка
                    Spisok_LB.Items.RemoveAt(Spisok_LB.SelectedIndex);
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

                if(Dialog.DialogResult == DialogResult.OK)
                {
                    Temp.NumberDoc = Dialog.NumberDoc_TB.Text;
                    Temp.Status = Dialog.Status_CB.SelectedItem.ToString();

                    //Запрос на обновление данных в БД <- Написать

                    RefreshSpisok_B.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать элемент", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
