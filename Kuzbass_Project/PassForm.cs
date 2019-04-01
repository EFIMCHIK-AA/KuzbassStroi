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
            if(DialogResult == DialogResult.OK)
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

                    if (NamePosition.GetHashPass(Login_CB.SelectedItem.ToString()) != Pass_TB.Text)
                    {
                        Pass_TB.Focus();
                        throw new Exception("Неправильно введен пароль");
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void PassForm_Load(object sender, EventArgs e)
        {
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
    }
}
