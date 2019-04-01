using System;
using System.Net;
using System.Net.Sockets;
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
    public partial class AddDocument : Form
    {
        public AddDocument()
        {
            InitializeComponent();
        }
        
        private void AddDocument_Load(object sender, EventArgs e)
        {
            Create_B.Enabled = false;
            OK_B.Enabled = false;
            Delete_B.Enabled = false;
        }

        private void Spisok_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Spisok_LB.SelectedIndex >= 0)
            {
                Delete_B.Enabled = true;
            }
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            if(Spisok_LB.SelectedIndex >= 0)
            {
                Spisok_LB.Items.RemoveAt(Spisok_LB.SelectedIndex);
            }
        }

        private void AddDocument_Shown(object sender, EventArgs e)
        {           
        }

        private void StartScan_B_Click(object sender, EventArgs e)
        {
            StartScan_B.Enabled = false;
            Server.Start(Spisok_LB, Status_TB);
        }
    }
}
