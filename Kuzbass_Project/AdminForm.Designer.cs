namespace Kuzbass_Project
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SavePort_B = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Port_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Host_TB = new System.Windows.Forms.TextBox();
            this.ChangePath_B = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Path_TB = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Exit_B = new System.Windows.Forms.Button();
            this.ChangeUser_B = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.QR_PB = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.HostDB_TB = new System.Windows.Forms.TextBox();
            this.SaveBD_B = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.PortDB_TB = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QR_PB)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SavePort_B);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.Port_TB);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.Host_TB);
            this.groupBox4.Location = new System.Drawing.Point(12, 11);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(341, 115);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Параметры подключения";
            // 
            // SavePort_B
            // 
            this.SavePort_B.Location = new System.Drawing.Point(8, 76);
            this.SavePort_B.Name = "SavePort_B";
            this.SavePort_B.Size = new System.Drawing.Size(324, 30);
            this.SavePort_B.TabIndex = 9;
            this.SavePort_B.Text = "Сохранить";
            this.SavePort_B.UseVisualStyleBackColor = true;
            this.SavePort_B.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Порт";
            // 
            // Port_TB
            // 
            this.Port_TB.Location = new System.Drawing.Point(51, 49);
            this.Port_TB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Port_TB.Name = "Port_TB";
            this.Port_TB.Size = new System.Drawing.Size(281, 22);
            this.Port_TB.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Хост";
            // 
            // Host_TB
            // 
            this.Host_TB.Location = new System.Drawing.Point(51, 21);
            this.Host_TB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Host_TB.Name = "Host_TB";
            this.Host_TB.ReadOnly = true;
            this.Host_TB.Size = new System.Drawing.Size(281, 22);
            this.Host_TB.TabIndex = 6;
            // 
            // ChangePath_B
            // 
            this.ChangePath_B.Location = new System.Drawing.Point(8, 47);
            this.ChangePath_B.Name = "ChangePath_B";
            this.ChangePath_B.Size = new System.Drawing.Size(324, 30);
            this.ChangePath_B.TabIndex = 8;
            this.ChangePath_B.Text = "Сохранить";
            this.ChangePath_B.UseVisualStyleBackColor = true;
            this.ChangePath_B.Click += new System.EventHandler(this.ChangePath_B_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Path_TB);
            this.groupBox1.Controls.Add(this.ChangePath_B);
            this.groupBox1.Location = new System.Drawing.Point(12, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 119);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Реестр";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(324, 30);
            this.button1.TabIndex = 11;
            this.button1.Text = "Создать файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Путь";
            // 
            // Path_TB
            // 
            this.Path_TB.Location = new System.Drawing.Point(51, 20);
            this.Path_TB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Path_TB.Name = "Path_TB";
            this.Path_TB.Size = new System.Drawing.Size(281, 22);
            this.Path_TB.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Exit_B);
            this.groupBox3.Controls.Add(this.ChangeUser_B);
            this.groupBox3.Location = new System.Drawing.Point(12, 402);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(341, 90);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Завершение работы";
            // 
            // Exit_B
            // 
            this.Exit_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Exit_B.Location = new System.Drawing.Point(9, 53);
            this.Exit_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exit_B.Name = "Exit_B";
            this.Exit_B.Size = new System.Drawing.Size(323, 30);
            this.Exit_B.TabIndex = 4;
            this.Exit_B.Text = "Выйти";
            this.Exit_B.UseVisualStyleBackColor = true;
            this.Exit_B.Click += new System.EventHandler(this.Exit_B_Click);
            // 
            // ChangeUser_B
            // 
            this.ChangeUser_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ChangeUser_B.Location = new System.Drawing.Point(9, 19);
            this.ChangeUser_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChangeUser_B.Name = "ChangeUser_B";
            this.ChangeUser_B.Size = new System.Drawing.Size(323, 30);
            this.ChangeUser_B.TabIndex = 5;
            this.ChangeUser_B.Text = "Сменить пользователя";
            this.ChangeUser_B.UseVisualStyleBackColor = true;
            this.ChangeUser_B.Click += new System.EventHandler(this.ChangeUser_B_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.QR_PB);
            this.groupBox2.Location = new System.Drawing.Point(359, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 254);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "QR";
            // 
            // QR_PB
            // 
            this.QR_PB.Location = new System.Drawing.Point(6, 21);
            this.QR_PB.Name = "QR_PB";
            this.QR_PB.Size = new System.Drawing.Size(241, 227);
            this.QR_PB.TabIndex = 0;
            this.QR_PB.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(361, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 96);
            this.label4.TabIndex = 12;
            this.label4.Text = "Используйте QR сканер\r\nдля определения\r\nпараметров подлючения\r\nна устройстве";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.PortDB_TB);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.HostDB_TB);
            this.groupBox5.Controls.Add(this.SaveBD_B);
            this.groupBox5.Location = new System.Drawing.Point(12, 256);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(341, 119);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "База данных";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Хост";
            // 
            // HostDB_TB
            // 
            this.HostDB_TB.Location = new System.Drawing.Point(51, 20);
            this.HostDB_TB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HostDB_TB.Name = "HostDB_TB";
            this.HostDB_TB.Size = new System.Drawing.Size(281, 22);
            this.HostDB_TB.TabIndex = 10;
            // 
            // SaveBD_B
            // 
            this.SaveBD_B.Location = new System.Drawing.Point(6, 78);
            this.SaveBD_B.Name = "SaveBD_B";
            this.SaveBD_B.Size = new System.Drawing.Size(324, 30);
            this.SaveBD_B.TabIndex = 8;
            this.SaveBD_B.Text = "Сохранить";
            this.SaveBD_B.UseVisualStyleBackColor = true;
            this.SaveBD_B.Click += new System.EventHandler(this.SaveBD_B_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Порт";
            // 
            // PortDB_TB
            // 
            this.PortDB_TB.Location = new System.Drawing.Point(51, 46);
            this.PortDB_TB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PortDB_TB.Name = "PortDB_TB";
            this.PortDB_TB.Size = new System.Drawing.Size(281, 22);
            this.PortDB_TB.TabIndex = 12;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 503);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администратор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QR_PB)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Port_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Host_TB;
        private System.Windows.Forms.Button ChangePath_B;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Exit_B;
        private System.Windows.Forms.Button ChangeUser_B;
        private System.Windows.Forms.Button SavePort_B;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Path_TB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox QR_PB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PortDB_TB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox HostDB_TB;
        private System.Windows.Forms.Button SaveBD_B;
    }
}