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
            this.ResultSpisok_GB = new System.Windows.Forms.GroupBox();
            this.ClearResultSpisok_B = new System.Windows.Forms.Button();
            this.ResultSpisok_LB = new System.Windows.Forms.ListBox();
            this.Operation_GB = new System.Windows.Forms.GroupBox();
            this.Operations_B = new System.Windows.Forms.Button();
            this.OpenDocument_B = new System.Windows.Forms.Button();
            this.Status_TB = new System.Windows.Forms.TextBox();
            this.Status_GB = new System.Windows.Forms.GroupBox();
            this.Users_CB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NumberDoc_TB = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Enter_B = new System.Windows.Forms.Button();
            this.Exit_B = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Spisok_GB.SuspendLayout();
            this.ResultSpisok_GB.SuspendLayout();
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
            this.Spisok_LB.TabIndex = 0;
            // 
            // Confirm_B
            // 
            this.Confirm_B.Location = new System.Drawing.Point(6, 21);
            this.Confirm_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Confirm_B.Name = "Confirm_B";
            this.Confirm_B.Size = new System.Drawing.Size(250, 30);
            this.Confirm_B.TabIndex = 3;
            this.Confirm_B.Text = "Подтвердить";
            this.Confirm_B.UseVisualStyleBackColor = true;
            this.Confirm_B.Click += new System.EventHandler(this.Confirm_B_Click);
            // 
            // Spisok_GB
            // 
            this.Spisok_GB.Controls.Add(this.RefreshSpisok_B);
            this.Spisok_GB.Controls.Add(this.Spisok_LB);
            this.Spisok_GB.Location = new System.Drawing.Point(9, 74);
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
            this.RefreshSpisok_B.TabIndex = 2;
            this.RefreshSpisok_B.Text = "Обновить список";
            this.RefreshSpisok_B.UseVisualStyleBackColor = true;
            this.RefreshSpisok_B.Click += new System.EventHandler(this.RefreshSpisok_B_Click);
            // 
            // ResultSpisok_GB
            // 
            this.ResultSpisok_GB.Controls.Add(this.ClearResultSpisok_B);
            this.ResultSpisok_GB.Controls.Add(this.ResultSpisok_LB);
            this.ResultSpisok_GB.Location = new System.Drawing.Point(718, 74);
            this.ResultSpisok_GB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResultSpisok_GB.Name = "ResultSpisok_GB";
            this.ResultSpisok_GB.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResultSpisok_GB.Size = new System.Drawing.Size(435, 422);
            this.ResultSpisok_GB.TabIndex = 5;
            this.ResultSpisok_GB.TabStop = false;
            this.ResultSpisok_GB.Text = "Обработанные документы";
            // 
            // ClearResultSpisok_B
            // 
            this.ClearResultSpisok_B.Location = new System.Drawing.Point(5, 383);
            this.ClearResultSpisok_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClearResultSpisok_B.Name = "ClearResultSpisok_B";
            this.ClearResultSpisok_B.Size = new System.Drawing.Size(425, 30);
            this.ClearResultSpisok_B.TabIndex = 4;
            this.ClearResultSpisok_B.Text = "Очистить список";
            this.ClearResultSpisok_B.UseVisualStyleBackColor = true;
            this.ClearResultSpisok_B.Click += new System.EventHandler(this.ClearResultSpisok_B_Click);
            // 
            // ResultSpisok_LB
            // 
            this.ResultSpisok_LB.FormattingEnabled = true;
            this.ResultSpisok_LB.ItemHeight = 16;
            this.ResultSpisok_LB.Location = new System.Drawing.Point(5, 21);
            this.ResultSpisok_LB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResultSpisok_LB.Name = "ResultSpisok_LB";
            this.ResultSpisok_LB.Size = new System.Drawing.Size(424, 356);
            this.ResultSpisok_LB.TabIndex = 0;
            // 
            // Operation_GB
            // 
            this.Operation_GB.Controls.Add(this.NumberDoc_TB);
            this.Operation_GB.Controls.Add(this.label2);
            this.Operation_GB.Controls.Add(this.OpenDocument_B);
            this.Operation_GB.Controls.Add(this.Operations_B);
            this.Operation_GB.Location = new System.Drawing.Point(450, 141);
            this.Operation_GB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Operation_GB.Name = "Operation_GB";
            this.Operation_GB.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Operation_GB.Size = new System.Drawing.Size(262, 121);
            this.Operation_GB.TabIndex = 6;
            this.Operation_GB.TabStop = false;
            this.Operation_GB.Text = "Модификация файлов";
            // 
            // Operations_B
            // 
            this.Operations_B.Location = new System.Drawing.Point(6, 56);
            this.Operations_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Operations_B.Name = "Operations_B";
            this.Operations_B.Size = new System.Drawing.Size(250, 30);
            this.Operations_B.TabIndex = 7;
            this.Operations_B.Text = "Изменить файлы";
            this.Operations_B.UseVisualStyleBackColor = true;
            this.Operations_B.Click += new System.EventHandler(this.Operations_B_Click);
            // 
            // OpenDocument_B
            // 
            this.OpenDocument_B.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OpenDocument_B.Location = new System.Drawing.Point(6, 22);
            this.OpenDocument_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenDocument_B.Name = "OpenDocument_B";
            this.OpenDocument_B.Size = new System.Drawing.Size(250, 30);
            this.OpenDocument_B.TabIndex = 6;
            this.OpenDocument_B.Text = "Добавить";
            this.OpenDocument_B.UseVisualStyleBackColor = false;
            this.OpenDocument_B.Click += new System.EventHandler(this.OpenDocument_B_Click);
            // 
            // Status_TB
            // 
            this.Status_TB.Location = new System.Drawing.Point(5, 21);
            this.Status_TB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Status_TB.Multiline = true;
            this.Status_TB.Name = "Status_TB";
            this.Status_TB.ReadOnly = true;
            this.Status_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_TB.Size = new System.Drawing.Size(1132, 134);
            this.Status_TB.TabIndex = 7;
            // 
            // Status_GB
            // 
            this.Status_GB.Controls.Add(this.Status_TB);
            this.Status_GB.Location = new System.Drawing.Point(10, 500);
            this.Status_GB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Status_GB.Name = "Status_GB";
            this.Status_GB.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Status_GB.Size = new System.Drawing.Size(1143, 161);
            this.Status_GB.TabIndex = 8;
            this.Status_GB.TabStop = false;
            this.Status_GB.Text = "Статус операции";
            // 
            // Users_CB
            // 
            this.Users_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Users_CB.FormattingEnabled = true;
            this.Users_CB.Location = new System.Drawing.Point(184, 20);
            this.Users_CB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Users_CB.Name = "Users_CB";
            this.Users_CB.Size = new System.Drawing.Size(628, 24);
            this.Users_CB.TabIndex = 1;
            this.Users_CB.SelectedIndexChanged += new System.EventHandler(this.Users_CB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Выберите пользователя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Номер бланка";
            // 
            // NumberDoc_TB
            // 
            this.NumberDoc_TB.Location = new System.Drawing.Point(114, 90);
            this.NumberDoc_TB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NumberDoc_TB.Name = "NumberDoc_TB";
            this.NumberDoc_TB.Size = new System.Drawing.Size(142, 22);
            this.NumberDoc_TB.TabIndex = 12;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Enter_B
            // 
            this.Enter_B.Location = new System.Drawing.Point(818, 16);
            this.Enter_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Enter_B.Name = "Enter_B";
            this.Enter_B.Size = new System.Drawing.Size(157, 30);
            this.Enter_B.TabIndex = 14;
            this.Enter_B.Text = "Войти";
            this.Enter_B.UseVisualStyleBackColor = true;
            this.Enter_B.Click += new System.EventHandler(this.Enter_B_Click);
            // 
            // Exit_B
            // 
            this.Exit_B.Location = new System.Drawing.Point(981, 16);
            this.Exit_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exit_B.Name = "Exit_B";
            this.Exit_B.Size = new System.Drawing.Size(157, 30);
            this.Exit_B.TabIndex = 15;
            this.Exit_B.Text = "Выйти";
            this.Exit_B.UseVisualStyleBackColor = true;
            this.Exit_B.Click += new System.EventHandler(this.Exit_B_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Confirm_B);
            this.groupBox1.Location = new System.Drawing.Point(450, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 62);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Операции с файлом из списка";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Users_CB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Exit_B);
            this.groupBox2.Controls.Add(this.Enter_B);
            this.groupBox2.Location = new System.Drawing.Point(9, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1144, 57);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Инициализация";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 673);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Operation_GB);
            this.Controls.Add(this.Status_GB);
            this.Controls.Add(this.ResultSpisok_GB);
            this.Controls.Add(this.Spisok_GB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление этапами документа";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Spisok_GB.ResumeLayout(false);
            this.ResultSpisok_GB.ResumeLayout(false);
            this.Operation_GB.ResumeLayout(false);
            this.Operation_GB.PerformLayout();
            this.Status_GB.ResumeLayout(false);
            this.Status_GB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Spisok_LB;
        private System.Windows.Forms.Button Confirm_B;
        private System.Windows.Forms.GroupBox Spisok_GB;
        private System.Windows.Forms.Button RefreshSpisok_B;
        private System.Windows.Forms.GroupBox ResultSpisok_GB;
        private System.Windows.Forms.Button ClearResultSpisok_B;
        private System.Windows.Forms.ListBox ResultSpisok_LB;
        private System.Windows.Forms.GroupBox Operation_GB;
        private System.Windows.Forms.TextBox Status_TB;
        private System.Windows.Forms.GroupBox Status_GB;
        private System.Windows.Forms.Button OpenDocument_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumberDoc_TB;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.ComboBox Users_CB;
        private System.Windows.Forms.Button Enter_B;
        private System.Windows.Forms.Button Exit_B;
        private System.Windows.Forms.Button Operations_B;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

