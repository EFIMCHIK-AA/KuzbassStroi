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
                        throw new Exception("В поле \"Пароль\" должно быть значение");
                    }

                    if (String.IsNullOrWhiteSpace(Login_TB.Text))
                    {
                        throw new Exception("В поле \"Логин\" должно быть значение");
                    }

                    String login = Login_TB.Text;

                    if (NamePosition.GetHashPass(login) != Pass_TB.Text)
                    {
                        throw new Exception("Неправильно введен пароль");
                    }
                }
                catch (Exception E)
                {
                    Pass_TB.Focus();
                    MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void Enter_B_Click(object sender, EventArgs e)
        {
            
        }

        private void PassForm_Load(object sender, EventArgs e)
        {
            Pass_TB.UseSystemPasswordChar = true;
        }

        private void CheckPass_CB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckPass_CB_CheckStateChanged(object sender, EventArgs e)
        {
            if (CheckPass_CB.Enabled)
            {
                Pass_TB.UseSystemPasswordChar = false;
            }
            else
            {
                Pass_TB.UseSystemPasswordChar = true;
            }
        }
    }
}
