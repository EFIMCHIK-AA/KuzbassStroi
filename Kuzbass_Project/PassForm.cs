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
    public partial class PassForm : Form
    {
        public PassForm()
        {
            InitializeComponent();
        }

        private void PassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void PassForm_Load(object sender, EventArgs e)
        {
            //Добавляем по умолчанию
            Login_CB.Items.Add("Не задано");
            //Установка тестовых данных по умолчанию на "Не задано"
            Login_CB.SelectedIndex = 0;

            //Подгрузка должностей из БД
            try
            {
                NamePosition.SetPosition();

                if (NamePosition.Positions.Count != 0)
                {
                    //Вывод всех позиций в Login_CB
                    foreach (Position Temp in NamePosition.Positions)
                    {
                        Login_CB.Items.Add(Temp.Name);
                    }
                }
                else
                {
                    MessageBox.Show("Должности для интеграции не обнаружены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Npgsql)
            {
                MessageBox.Show(Npgsql.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Скрываем пароль
            Pass_TB.UseSystemPasswordChar = true;
        }

        private void CheckPass_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Pass_TB.UseSystemPasswordChar == true)
            {
                Pass_TB.UseSystemPasswordChar = false;
            }
            else
            {
                Pass_TB.UseSystemPasswordChar = true;
            }
        }


        private void Login_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Login_CB.SelectedItem.ToString() == "Не задано")
            {
                Enter_B.Enabled = false;
                CheckPass_CB.Enabled = false;
                Pass_TB.Enabled = false;
            }
            else
            {
                Pass_TB.Clear();
                Enter_B.Enabled = true;
                CheckPass_CB.Enabled = true;
                Pass_TB.Enabled = true;
            }
        }

        private void Enter_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(Pass_TB.Text))
                {
                    Pass_TB.Focus();
                    throw new Exception("В поле \"Пароль\" должно быть значение");
                }

                if (Login_CB.SelectedIndex == 0)
                {
                    Login_CB.Focus();
                    throw new Exception("Необходимо выбрать пользователя");
                }

                String Mode = Login_CB.SelectedItem.ToString();

                if (Mode == "Администратор")
                {
                    if (NamePosition.GetHashPass(Mode) != Pass_TB.Text)
                    {
                        Pass_TB.Focus();
                        throw new Exception("Неправильно введен пароль");
                    }
                    else
                    {
                        this.Hide();
                        Form Dialog = new AdminForm();
                        Dialog.Show();
                    }
                }
                else
                {
                    if (NamePosition.GetHashPass(Mode) != Pass_TB.Text)
                    {
                        Pass_TB.Focus();
                        throw new Exception("Неправильно введен пароль");
                    }
                    else
                    {
                        this.Hide();
                        Form Dialog = new Form1(Mode);
                        Dialog.Show();
                    }
                }
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Cancel_B_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
