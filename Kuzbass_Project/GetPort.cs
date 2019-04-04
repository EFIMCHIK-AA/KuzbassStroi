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
    public partial class GetPort : Form
    {
        public GetPort()
        {
            InitializeComponent();
        }

        private void GetPort_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(Port_TB.Text))
                    {
                        Port_TB.Focus();
                        throw new Exception("Необходимо ввести порт подключения");
                    }

                    Int32 port = Convert.ToInt32(Port_TB.Text);

                    if(port <= 1023 || port > 65535)
                    {
                        Port_TB.Focus();
                        throw new Exception("Использование системных портов в диапазоне [0..1023] не предусмотрено. Рекомендуется использовать порты в диапазоне [48654..48999] или [49152..65535]");
                    }
                }
                catch (FormatException)
                {
                    Port_TB.Focus();
                    e.Cancel = true;
                    MessageBox.Show("Порт подключения должен состоять из целых цифр", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch(Exception E)
                {
                    e.Cancel = true;
                    MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
