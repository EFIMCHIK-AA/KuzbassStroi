﻿namespace Kuzbass_Project
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Spisok_LB = new System.Windows.Forms.ListBox();
            this.Confirm_B = new System.Windows.Forms.Button();
            this.Spisok_GB = new System.Windows.Forms.GroupBox();
            this.RefreshSpisok_B = new System.Windows.Forms.Button();
            this.Operation_GB = new System.Windows.Forms.GroupBox();
            this.NumberDoc_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OpenDocument_B = new System.Windows.Forms.Button();
            this.Operations_B = new System.Windows.Forms.Button();
            this.Status_TB = new System.Windows.Forms.TextBox();
            this.Status_GB = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Exit_B = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChangeUser_B = new System.Windows.Forms.Button();
            this.Spisok_GB.SuspendLayout();
            this.Operation_GB.SuspendLayout();
            this.Status_GB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Spisok_LB
            // 
            this.Spisok_LB.FormattingEnabled = true;
            this.Spisok_LB.ItemHeight = 16;
            this.Spisok_LB.Location = new System.Drawing.Point(5, 21);
            this.Spisok_LB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Spisok_LB.Name = "Spisok_LB";
            this.Spisok_LB.Size = new System.Drawing.Size(424, 356);
            this.Spisok_LB.TabIndex = 2;
            this.Spisok_LB.SelectedIndexChanged += new System.EventHandler(this.Spisok_LB_SelectedIndexChanged);
            // 
            // Confirm_B
            // 
            this.Confirm_B.Location = new System.Drawing.Point(5, 21);
            this.Confirm_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Confirm_B.Name = "Confirm_B";
            this.Confirm_B.Size = new System.Drawing.Size(251, 30);
            this.Confirm_B.TabIndex = 3;
            this.Confirm_B.Text = "&Подтвердить";
            this.Confirm_B.UseVisualStyleBackColor = true;
            this.Confirm_B.Click += new System.EventHandler(this.Confirm_B_Click);
            // 
            // Spisok_GB
            // 
            this.Spisok_GB.Controls.Add(this.RefreshSpisok_B);
            this.Spisok_GB.Controls.Add(this.Spisok_LB);
            this.Spisok_GB.Location = new System.Drawing.Point(12, 11);
            this.Spisok_GB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Spisok_GB.Name = "Spisok_GB";
            this.Spisok_GB.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Spisok_GB.Size = new System.Drawing.Size(435, 422);
            this.Spisok_GB.TabIndex = 4;
            this.Spisok_GB.TabStop = false;
            this.Spisok_GB.Text = "Документы в режиме ожидания";
            // 
            // RefreshSpisok_B
            // 
            this.RefreshSpisok_B.Location = new System.Drawing.Point(5, 383);
            this.RefreshSpisok_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefreshSpisok_B.Name = "RefreshSpisok_B";
            this.RefreshSpisok_B.Size = new System.Drawing.Size(425, 30);
            this.RefreshSpisok_B.TabIndex = 1;
            this.RefreshSpisok_B.Text = "&Обновить список";
            this.RefreshSpisok_B.UseVisualStyleBackColor = true;
            this.RefreshSpisok_B.Click += new System.EventHandler(this.RefreshSpisok_B_Click);
            // 
            // Operation_GB
            // 
            this.Operation_GB.Controls.Add(this.NumberDoc_TB);
            this.Operation_GB.Controls.Add(this.label2);
            this.Operation_GB.Controls.Add(this.OpenDocument_B);
            this.Operation_GB.Controls.Add(this.Operations_B);
            this.Operation_GB.Location = new System.Drawing.Point(453, 78);
            this.Operation_GB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Operation_GB.Name = "Operation_GB";
            this.Operation_GB.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Operation_GB.Size = new System.Drawing.Size(261, 121);
            this.Operation_GB.TabIndex = 6;
            this.Operation_GB.TabStop = false;
            this.Operation_GB.Text = "Модификация файлов";
            // 
            // NumberDoc_TB
            // 
            this.NumberDoc_TB.Location = new System.Drawing.Point(115, 90);
            this.NumberDoc_TB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NumberDoc_TB.Name = "NumberDoc_TB";
            this.NumberDoc_TB.Size = new System.Drawing.Size(143, 22);
            this.NumberDoc_TB.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Номер бланка";
            // 
            // OpenDocument_B
            // 
            this.OpenDocument_B.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OpenDocument_B.Location = new System.Drawing.Point(5, 22);
            this.OpenDocument_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenDocument_B.Name = "OpenDocument_B";
            this.OpenDocument_B.Size = new System.Drawing.Size(251, 30);
            this.OpenDocument_B.TabIndex = 5;
            this.OpenDocument_B.Text = "&Добавить";
            this.OpenDocument_B.UseVisualStyleBackColor = false;
            this.OpenDocument_B.Click += new System.EventHandler(this.OpenDocument_B_Click);
            // 
            // Operations_B
            // 
            this.Operations_B.Location = new System.Drawing.Point(5, 57);
            this.Operations_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Operations_B.Name = "Operations_B";
            this.Operations_B.Size = new System.Drawing.Size(251, 30);
            this.Operations_B.TabIndex = 6;
            this.Operations_B.Text = "&Изменить файлы";
            this.Operations_B.UseVisualStyleBackColor = true;
            this.Operations_B.Click += new System.EventHandler(this.Operations_B_Click);
            // 
            // Status_TB
            // 
            this.Status_TB.Location = new System.Drawing.Point(5, 21);
            this.Status_TB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Status_TB.Multiline = true;
            this.Status_TB.Name = "Status_TB";
            this.Status_TB.ReadOnly = true;
            this.Status_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_TB.Size = new System.Drawing.Size(691, 134);
            this.Status_TB.TabIndex = 7;
            // 
            // Status_GB
            // 
            this.Status_GB.Controls.Add(this.Status_TB);
            this.Status_GB.Location = new System.Drawing.Point(13, 437);
            this.Status_GB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Status_GB.Name = "Status_GB";
            this.Status_GB.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Status_GB.Size = new System.Drawing.Size(701, 161);
            this.Status_GB.TabIndex = 8;
            this.Status_GB.TabStop = false;
            this.Status_GB.Text = "Статус операции";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Confirm_B);
            this.groupBox1.Location = new System.Drawing.Point(453, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(261, 62);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Операции с файлом из списка";
            // 
            // Exit_B
            // 
            this.Exit_B.Location = new System.Drawing.Point(5, 55);
            this.Exit_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exit_B.Name = "Exit_B";
            this.Exit_B.Size = new System.Drawing.Size(251, 30);
            this.Exit_B.TabIndex = 7;
            this.Exit_B.Text = "&Выйти";
            this.Exit_B.UseVisualStyleBackColor = true;
            this.Exit_B.Click += new System.EventHandler(this.Exit_B_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChangeUser_B);
            this.groupBox2.Controls.Add(this.Exit_B);
            this.groupBox2.Location = new System.Drawing.Point(453, 339);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(261, 93);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Завершение работы";
            // 
            // ChangeUser_B
            // 
            this.ChangeUser_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ChangeUser_B.Location = new System.Drawing.Point(5, 21);
            this.ChangeUser_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChangeUser_B.Name = "ChangeUser_B";
            this.ChangeUser_B.Size = new System.Drawing.Size(251, 30);
            this.ChangeUser_B.TabIndex = 8;
            this.ChangeUser_B.Text = "Сменить пользователя";
            this.ChangeUser_B.UseVisualStyleBackColor = true;
            this.ChangeUser_B.Click += new System.EventHandler(this.ChangeUser_B_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 613);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Operation_GB);
            this.Controls.Add(this.Status_GB);
            this.Controls.Add(this.Spisok_GB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление этапами документа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Spisok_GB.ResumeLayout(false);
            this.Operation_GB.ResumeLayout(false);
            this.Operation_GB.PerformLayout();
            this.Status_GB.ResumeLayout(false);
            this.Status_GB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Spisok_LB;
        private System.Windows.Forms.Button Confirm_B;
        private System.Windows.Forms.GroupBox Spisok_GB;
        private System.Windows.Forms.Button RefreshSpisok_B;
        private System.Windows.Forms.GroupBox Operation_GB;
        private System.Windows.Forms.TextBox Status_TB;
        private System.Windows.Forms.GroupBox Status_GB;
        private System.Windows.Forms.Button OpenDocument_B;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumberDoc_TB;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Operations_B;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Exit_B;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ChangeUser_B;
    }
}

