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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.StartScan_B = new System.Windows.Forms.Button();
            this.Status_TB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Status_GB.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Spisok_LB
            // 
            this.Spisok_LB.FormattingEnabled = true;
            this.Spisok_LB.ItemHeight = 16;
            this.Spisok_LB.Location = new System.Drawing.Point(6, 21);
            this.Spisok_LB.Name = "Spisok_LB";
            this.Spisok_LB.Size = new System.Drawing.Size(340, 276);
            this.Spisok_LB.TabIndex = 0;
            this.Spisok_LB.SelectedIndexChanged += new System.EventHandler(this.Spisok_LB_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Delete_B);
            this.groupBox1.Controls.Add(this.Spisok_LB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 342);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Полученные документы";
            // 
            // Delete_B
            // 
            this.Delete_B.Location = new System.Drawing.Point(6, 302);
            this.Delete_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Delete_B.Name = "Delete_B";
            this.Delete_B.Size = new System.Drawing.Size(340, 30);
            this.Delete_B.TabIndex = 5;
            this.Delete_B.Text = "Удалить документ";
            this.Delete_B.UseVisualStyleBackColor = true;
            this.Delete_B.Click += new System.EventHandler(this.Delete_B_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Create_B);
            this.groupBox2.Location = new System.Drawing.Point(372, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 63);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Создание отчета";
            // 
            // Create_B
            // 
            this.Create_B.Location = new System.Drawing.Point(6, 21);
            this.Create_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Create_B.Name = "Create_B";
            this.Create_B.Size = new System.Drawing.Size(191, 30);
            this.Create_B.TabIndex = 4;
            this.Create_B.Text = "Сформировать";
            this.Create_B.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.OK_B);
            this.groupBox3.Controls.Add(this.Cancel_B);
            this.groupBox3.Location = new System.Drawing.Point(372, 253);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(205, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Действия";
            // 
            // OK_B
            // 
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_B.Location = new System.Drawing.Point(6, 20);
            this.OK_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(191, 30);
            this.OK_B.TabIndex = 5;
            this.OK_B.Text = "Добавить";
            this.OK_B.UseVisualStyleBackColor = true;
            // 
            // Cancel_B
            // 
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Location = new System.Drawing.Point(6, 58);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(191, 30);
            this.Cancel_B.TabIndex = 4;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.UseVisualStyleBackColor = true;
            // 
            // Status_GB
            // 
            this.Status_GB.Controls.Add(this.Status_TB);
            this.Status_GB.Location = new System.Drawing.Point(12, 359);
            this.Status_GB.Name = "Status_GB";
            this.Status_GB.Size = new System.Drawing.Size(565, 145);
            this.Status_GB.TabIndex = 4;
            this.Status_GB.TabStop = false;
            this.Status_GB.Text = "Статус операции";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.StartScan_B);
            this.groupBox5.Location = new System.Drawing.Point(372, 81);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(205, 63);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Считывание QR";
            // 
            // StartScan_B
            // 
            this.StartScan_B.Location = new System.Drawing.Point(6, 21);
            this.StartScan_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartScan_B.Name = "StartScan_B";
            this.StartScan_B.Size = new System.Drawing.Size(191, 30);
            this.StartScan_B.TabIndex = 4;
            this.StartScan_B.Text = "Начать сканирование";
            this.StartScan_B.UseVisualStyleBackColor = true;
            this.StartScan_B.Click += new System.EventHandler(this.StartScan_B_Click);
            // 
            // Status_TB
            // 
            this.Status_TB.Location = new System.Drawing.Point(6, 21);
            this.Status_TB.Multiline = true;
            this.Status_TB.Name = "Status_TB";
            this.Status_TB.ReadOnly = true;
            this.Status_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_TB.Size = new System.Drawing.Size(551, 113);
            this.Status_TB.TabIndex = 0;
            // 
            // AddDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 518);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.Status_GB);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDocument";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Получение документов";
            this.Load += new System.EventHandler(this.AddDocument_Load);
            this.Shown += new System.EventHandler(this.AddDocument_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.Status_GB.ResumeLayout(false);
            this.Status_GB.PerformLayout();
            this.groupBox5.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button StartScan_B;
        private System.Windows.Forms.TextBox Status_TB;
    }
}