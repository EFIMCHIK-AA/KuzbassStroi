namespace Kuzbass_Project
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
            this.Recognize_B = new System.Windows.Forms.Button();
            this.Exit_B = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChangeUser_B = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Report_CB = new System.Windows.Forms.ComboBox();
            this.CreateReport_B = new System.Windows.Forms.Button();
            this.Spisok_GB.SuspendLayout();
            this.Operation_GB.SuspendLayout();
            this.Status_GB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Spisok_LB
            // 
            this.Spisok_LB.FormattingEnabled = true;
            this.Spisok_LB.Location = new System.Drawing.Point(4, 17);
            this.Spisok_LB.Margin = new System.Windows.Forms.Padding(2);
            this.Spisok_LB.Name = "Spisok_LB";
            this.Spisok_LB.Size = new System.Drawing.Size(522, 290);
            this.Spisok_LB.TabIndex = 2;
            this.Spisok_LB.SelectedIndexChanged += new System.EventHandler(this.Spisok_LB_SelectedIndexChanged);
            // 
            // Confirm_B
            // 
            this.Confirm_B.Location = new System.Drawing.Point(4, 17);
            this.Confirm_B.Margin = new System.Windows.Forms.Padding(2);
            this.Confirm_B.Name = "Confirm_B";
            this.Confirm_B.Size = new System.Drawing.Size(240, 24);
            this.Confirm_B.TabIndex = 3;
            this.Confirm_B.Text = "&Подтвердить";
            this.Confirm_B.UseVisualStyleBackColor = true;
            this.Confirm_B.Click += new System.EventHandler(this.Confirm_B_Click);
            // 
            // Spisok_GB
            // 
            this.Spisok_GB.Controls.Add(this.RefreshSpisok_B);
            this.Spisok_GB.Controls.Add(this.Spisok_LB);
            this.Spisok_GB.Location = new System.Drawing.Point(9, 9);
            this.Spisok_GB.Margin = new System.Windows.Forms.Padding(2);
            this.Spisok_GB.Name = "Spisok_GB";
            this.Spisok_GB.Padding = new System.Windows.Forms.Padding(2);
            this.Spisok_GB.Size = new System.Drawing.Size(532, 343);
            this.Spisok_GB.TabIndex = 4;
            this.Spisok_GB.TabStop = false;
            this.Spisok_GB.Text = "Документы в режиме ожидания";
            // 
            // RefreshSpisok_B
            // 
            this.RefreshSpisok_B.Location = new System.Drawing.Point(4, 311);
            this.RefreshSpisok_B.Margin = new System.Windows.Forms.Padding(2);
            this.RefreshSpisok_B.Name = "RefreshSpisok_B";
            this.RefreshSpisok_B.Size = new System.Drawing.Size(522, 24);
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
            this.Operation_GB.Location = new System.Drawing.Point(544, 87);
            this.Operation_GB.Margin = new System.Windows.Forms.Padding(2);
            this.Operation_GB.Name = "Operation_GB";
            this.Operation_GB.Padding = new System.Windows.Forms.Padding(2);
            this.Operation_GB.Size = new System.Drawing.Size(248, 98);
            this.Operation_GB.TabIndex = 6;
            this.Operation_GB.TabStop = false;
            this.Operation_GB.Text = "Модификация файлов";
            // 
            // NumberDoc_TB
            // 
            this.NumberDoc_TB.Location = new System.Drawing.Point(86, 73);
            this.NumberDoc_TB.Margin = new System.Windows.Forms.Padding(2);
            this.NumberDoc_TB.Name = "NumberDoc_TB";
            this.NumberDoc_TB.Size = new System.Drawing.Size(158, 20);
            this.NumberDoc_TB.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Номер бланка";
            // 
            // OpenDocument_B
            // 
            this.OpenDocument_B.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OpenDocument_B.Location = new System.Drawing.Point(4, 18);
            this.OpenDocument_B.Margin = new System.Windows.Forms.Padding(2);
            this.OpenDocument_B.Name = "OpenDocument_B";
            this.OpenDocument_B.Size = new System.Drawing.Size(240, 24);
            this.OpenDocument_B.TabIndex = 5;
            this.OpenDocument_B.Text = "&Добавить";
            this.OpenDocument_B.UseVisualStyleBackColor = false;
            this.OpenDocument_B.Click += new System.EventHandler(this.OpenDocument_B_Click);
            // 
            // Operations_B
            // 
            this.Operations_B.Location = new System.Drawing.Point(4, 46);
            this.Operations_B.Margin = new System.Windows.Forms.Padding(2);
            this.Operations_B.Name = "Operations_B";
            this.Operations_B.Size = new System.Drawing.Size(240, 24);
            this.Operations_B.TabIndex = 6;
            this.Operations_B.Text = "&Изменить файлы";
            this.Operations_B.UseVisualStyleBackColor = true;
            this.Operations_B.Click += new System.EventHandler(this.Operations_B_Click);
            // 
            // Status_TB
            // 
            this.Status_TB.Location = new System.Drawing.Point(4, 17);
            this.Status_TB.Margin = new System.Windows.Forms.Padding(2);
            this.Status_TB.Multiline = true;
            this.Status_TB.Name = "Status_TB";
            this.Status_TB.ReadOnly = true;
            this.Status_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_TB.Size = new System.Drawing.Size(778, 186);
            this.Status_TB.TabIndex = 7;
            // 
            // Status_GB
            // 
            this.Status_GB.Controls.Add(this.Status_TB);
            this.Status_GB.Location = new System.Drawing.Point(10, 355);
            this.Status_GB.Margin = new System.Windows.Forms.Padding(2);
            this.Status_GB.Name = "Status_GB";
            this.Status_GB.Padding = new System.Windows.Forms.Padding(2);
            this.Status_GB.Size = new System.Drawing.Size(783, 207);
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
            this.groupBox1.Controls.Add(this.Recognize_B);
            this.groupBox1.Controls.Add(this.Confirm_B);
            this.groupBox1.Location = new System.Drawing.Point(545, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(248, 72);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Операции с файлом из списка";
            // 
            // Recognize_B
            // 
            this.Recognize_B.Location = new System.Drawing.Point(4, 44);
            this.Recognize_B.Margin = new System.Windows.Forms.Padding(2);
            this.Recognize_B.Name = "Recognize_B";
            this.Recognize_B.Size = new System.Drawing.Size(240, 24);
            this.Recognize_B.TabIndex = 4;
            this.Recognize_B.Text = "&Распознать";
            this.Recognize_B.UseVisualStyleBackColor = true;
            this.Recognize_B.Click += new System.EventHandler(this.Recognize_B_Click);
            // 
            // Exit_B
            // 
            this.Exit_B.Location = new System.Drawing.Point(4, 45);
            this.Exit_B.Margin = new System.Windows.Forms.Padding(2);
            this.Exit_B.Name = "Exit_B";
            this.Exit_B.Size = new System.Drawing.Size(240, 24);
            this.Exit_B.TabIndex = 7;
            this.Exit_B.Text = "&Выйти";
            this.Exit_B.UseVisualStyleBackColor = true;
            this.Exit_B.Click += new System.EventHandler(this.Exit_B_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChangeUser_B);
            this.groupBox2.Controls.Add(this.Exit_B);
            this.groupBox2.Location = new System.Drawing.Point(545, 277);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(248, 76);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Завершение работы";
            // 
            // ChangeUser_B
            // 
            this.ChangeUser_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ChangeUser_B.Location = new System.Drawing.Point(4, 17);
            this.ChangeUser_B.Margin = new System.Windows.Forms.Padding(2);
            this.ChangeUser_B.Name = "ChangeUser_B";
            this.ChangeUser_B.Size = new System.Drawing.Size(240, 24);
            this.ChangeUser_B.TabIndex = 8;
            this.ChangeUser_B.Text = "Сменить пользователя";
            this.ChangeUser_B.UseVisualStyleBackColor = true;
            this.ChangeUser_B.Click += new System.EventHandler(this.ChangeUser_B_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Report_CB);
            this.groupBox3.Controls.Add(this.CreateReport_B);
            this.groupBox3.Location = new System.Drawing.Point(544, 189);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(248, 87);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Формирование отчета";
            // 
            // Report_CB
            // 
            this.Report_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Report_CB.FormattingEnabled = true;
            this.Report_CB.Location = new System.Drawing.Point(6, 16);
            this.Report_CB.Margin = new System.Windows.Forms.Padding(2);
            this.Report_CB.Name = "Report_CB";
            this.Report_CB.Size = new System.Drawing.Size(238, 21);
            this.Report_CB.TabIndex = 4;
            this.Report_CB.SelectedIndexChanged += new System.EventHandler(this.Report_CB_SelectedIndexChanged);
            // 
            // CreateReport_B
            // 
            this.CreateReport_B.Location = new System.Drawing.Point(4, 45);
            this.CreateReport_B.Margin = new System.Windows.Forms.Padding(2);
            this.CreateReport_B.Name = "CreateReport_B";
            this.CreateReport_B.Size = new System.Drawing.Size(240, 24);
            this.CreateReport_B.TabIndex = 3;
            this.CreateReport_B.Text = "&Сформировать";
            this.CreateReport_B.UseVisualStyleBackColor = true;
            this.CreateReport_B.Click += new System.EventHandler(this.CreateReport_B_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 571);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Operation_GB);
            this.Controls.Add(this.Status_GB);
            this.Controls.Add(this.Spisok_GB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
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
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Spisok_LB;
        private System.Windows.Forms.Button Confirm_B;
        private System.Windows.Forms.GroupBox Spisok_GB;
        private System.Windows.Forms.Button RefreshSpisok_B;
        private System.Windows.Forms.GroupBox Operation_GB;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox Report_CB;
        private System.Windows.Forms.Button CreateReport_B;
        private System.Windows.Forms.Button Recognize_B;
        public System.Windows.Forms.TextBox Status_TB;
    }
}

