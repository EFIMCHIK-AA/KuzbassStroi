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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Confirm_B_Click(object sender, EventArgs e)
        {
            //очистка
            Status_TB.Clear();
        }

        private void ConfirmALL_B_Click(object sender, EventArgs e)
        {
            //очистка
            Status_TB.Clear();
        }

        private void OpenDocument_B_Click(object sender, EventArgs e)
        {
            //Выбирается файл, достаются с него все необходимые данные, преобразуется если необходимо <- ТВОЁ

            //Создается объект класса Document и работаем дальше с ним <- ТВОЁ

            //Необходимо вывести в окно статуса операций, что добавлен в базу данных документ 
            //Отображение текста в компоненте по структуре "Документ {ИМЯ ДОКУМЕНТА} QR: {QR КОД} успешно добавлен в обработку" <- ТВОЁ

            //Здесь отдельно описываю модуль добавлени данных в СУБД PostgreSQl <- МОЁ
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Тестовые данные
            Users_CB.Items.AddRange(new String[] {"Не задано","Марья Ивановна из продуктового отдела",
                                                   "София Петровна из отдела FBI","Кирилл Губанов - просто долбоёб",
                                                   "Алексей - бог, успешный плейбой да и просто отличный челик" });

            //Установка тестовых данных по умолчанию на "Не задано"
            Users_CB.SelectedIndex = 0;

            //Блокирование всех кнопок
            OpenDocument_B.Enabled = false;
            Confirm_B.Enabled = false;
            ConfirmALL_B.Enabled = false;
            RefreshSpisok_B.Enabled = false;
            ClearResultSpisok_B.Enabled = false;
        }

        private void ClearField()
        {
            Spisok_LB.Items.Clear();
            ResultSpisok_TB.Items.Clear();
            Status_TB.Clear();
        }

        private void Users_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Users_CB.SelectedIndex == 0)
            {
                //Блокироване и анлок кнопок
                OpenDocument_B.Enabled = false;
                Confirm_B.Enabled = false;
                ConfirmALL_B.Enabled = false;
                RefreshSpisok_B.Enabled = false;
                ClearResultSpisok_B.Enabled = false;

                //Очистка
                ClearField();
            }
            else if(Users_CB.SelectedIndex == 1)
            {
                //Блокироване и анлок кнопок
                Confirm_B.Enabled = false;
                ConfirmALL_B.Enabled = false;
                RefreshSpisok_B.Enabled = false;
                ClearResultSpisok_B.Enabled = false;
                OpenDocument_B.Enabled = true;

                //Очистка
                ClearField();
            }
            else
            {
                //Блокироване и анлок кнопок
                OpenDocument_B.Enabled = false;
                Confirm_B.Enabled = false;
                ConfirmALL_B.Enabled = false;
                RefreshSpisok_B.Enabled = true;
                ClearResultSpisok_B.Enabled = false;
                OpenDocument_B.Enabled = false;

                //Очистка
                ClearField();
            }
        }
    }
}
