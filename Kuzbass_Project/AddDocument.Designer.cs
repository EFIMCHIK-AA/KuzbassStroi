﻿namespace Kuzbass_Project
{
    partial class AddDocument
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
            this.Spisok_LB = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Delete_B = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Create_B = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.OK_B = new System.Windows.Forms.Button();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.Status_GB = new System.Windows.Forms.GroupBox();
            this.Status_TB = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Port_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Host_TB = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Status_GB.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Spisok_LB
            // 
            this.Spisok_LB.FormattingEnabled = true;
            this.Spisok_LB.Location = new System.Drawing.Point(4, 17);
            this.Spisok_LB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Spisok_LB.Name = "Spisok_LB";
            this.Spisok_LB.Size = new System.Drawing.Size(256, 225);
            this.Spisok_LB.TabIndex = 0;
            this.Spisok_LB.SelectedIndexChanged += new System.EventHandler(this.Spisok_LB_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Delete_B);
            this.groupBox1.Controls.Add(this.Spisok_LB);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(266, 278);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Полученные документы";
            // 
            // Delete_B
            // 
            this.Delete_B.Location = new System.Drawing.Point(4, 245);
            this.Delete_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Delete_B.Name = "Delete_B";
            this.Delete_B.Size = new System.Drawing.Size(255, 24);
            this.Delete_B.TabIndex = 5;
            this.Delete_B.Text = "Удалить документ";
            this.Delete_B.UseVisualStyleBackColor = true;
            this.Delete_B.Click += new System.EventHandler(this.Delete_B_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Create_B);
            this.groupBox2.Location = new System.Drawing.Point(279, 78);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(154, 51);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Создание акта";
            // 
            // Create_B
            // 
            this.Create_B.Location = new System.Drawing.Point(4, 17);
            this.Create_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Create_B.Name = "Create_B";
            this.Create_B.Size = new System.Drawing.Size(145, 24);
            this.Create_B.TabIndex = 4;
            this.Create_B.Text = "Сформировать";
            this.Create_B.UseVisualStyleBackColor = true;
            this.Create_B.Click += new System.EventHandler(this.Create_B_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.OK_B);
            this.groupBox3.Controls.Add(this.Cancel_B);
            this.groupBox3.Location = new System.Drawing.Point(279, 206);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(154, 81);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Действия";
            // 
            // OK_B
            // 
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_B.Location = new System.Drawing.Point(4, 16);
            this.OK_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(145, 24);
            this.OK_B.TabIndex = 5;
            this.OK_B.Text = "Добавить";
            this.OK_B.UseVisualStyleBackColor = true;
            this.OK_B.Click += new System.EventHandler(this.OK_B_Click);
            // 
            // Cancel_B
            // 
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Location = new System.Drawing.Point(4, 47);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(145, 24);
            this.Cancel_B.TabIndex = 4;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.UseVisualStyleBackColor = true;
            this.Cancel_B.Click += new System.EventHandler(this.Cancel_B_Click);
            // 
            // Status_GB
            // 
            this.Status_GB.Controls.Add(this.Status_TB);
            this.Status_GB.Location = new System.Drawing.Point(9, 292);
            this.Status_GB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Status_GB.Name = "Status_GB";
            this.Status_GB.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Status_GB.Size = new System.Drawing.Size(424, 118);
            this.Status_GB.TabIndex = 4;
            this.Status_GB.TabStop = false;
            this.Status_GB.Text = "Статус операции";
            // 
            // Status_TB
            // 
            this.Status_TB.Location = new System.Drawing.Point(4, 17);
            this.Status_TB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Status_TB.Multiline = true;
            this.Status_TB.Name = "Status_TB";
            this.Status_TB.ReadOnly = true;
            this.Status_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_TB.Size = new System.Drawing.Size(414, 93);
            this.Status_TB.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.Port_TB);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.Host_TB);
            this.groupBox4.Location = new System.Drawing.Point(279, 10);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(154, 63);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Параметры подключения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Порт";
            // 
            // Port_TB
            // 
            this.Port_TB.Location = new System.Drawing.Point(38, 40);
            this.Port_TB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Port_TB.Name = "Port_TB";
            this.Port_TB.ReadOnly = true;
            this.Port_TB.Size = new System.Drawing.Size(112, 20);
            this.Port_TB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Хост";
            // 
            // Host_TB
            // 
            this.Host_TB.Location = new System.Drawing.Point(38, 17);
            this.Host_TB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Host_TB.Name = "Host_TB";
            this.Host_TB.ReadOnly = true;
            this.Host_TB.Size = new System.Drawing.Size(112, 20);
            this.Host_TB.TabIndex = 0;
            // 
            // AddDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 421);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Status_GB);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDocument";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Получение документов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddDocument_FormClosing);
            this.Load += new System.EventHandler(this.AddDocument_Load);
            this.Shown += new System.EventHandler(this.AddDocument_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.Status_GB.ResumeLayout(false);
            this.Status_GB.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Create_B;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button OK_B;
        private System.Windows.Forms.Button Cancel_B;
        public System.Windows.Forms.ListBox Spisok_LB;
        public System.Windows.Forms.Button Delete_B;
        private System.Windows.Forms.GroupBox Status_GB;
        private System.Windows.Forms.TextBox Status_TB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Port_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Host_TB;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}