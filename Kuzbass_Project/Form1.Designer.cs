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
            this.OpenDocument_B = new System.Windows.Forms.Button();
            this.ConfirmALL_B = new System.Windows.Forms.Button();
            this.Status_TB = new System.Windows.Forms.TextBox();
            this.Status_GB = new System.Windows.Forms.GroupBox();
            this.Users_CB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Spisok_GB.SuspendLayout();
            this.ResultSpisok_GB.SuspendLayout();
            this.Operation_GB.SuspendLayout();
            this.Status_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // Spisok_LB
            // 
            this.Spisok_LB.FormattingEnabled = true;
            this.Spisok_LB.ItemHeight = 16;
            this.Spisok_LB.Location = new System.Drawing.Point(6, 21);
            this.Spisok_LB.Name = "Spisok_LB";
            this.Spisok_LB.Size = new System.Drawing.Size(339, 356);
            this.Spisok_LB.TabIndex = 0;
            // 
            // Confirm_B
            // 
            this.Confirm_B.Location = new System.Drawing.Point(6, 21);
            this.Confirm_B.Name = "Confirm_B";
            this.Confirm_B.Size = new System.Drawing.Size(216, 30);
            this.Confirm_B.TabIndex = 3;
            this.Confirm_B.Text = "Подтвердить";
            this.Confirm_B.UseVisualStyleBackColor = true;
            this.Confirm_B.Click += new System.EventHandler(this.Confirm_B_Click);
            // 
            // Spisok_GB
            // 
            this.Spisok_GB.Controls.Add(this.RefreshSpisok_B);
            this.Spisok_GB.Controls.Add(this.Spisok_LB);
            this.Spisok_GB.Location = new System.Drawing.Point(11, 42);
            this.Spisok_GB.Name = "Spisok_GB";
            this.Spisok_GB.Size = new System.Drawing.Size(351, 422);
            this.Spisok_GB.TabIndex = 4;
            this.Spisok_GB.TabStop = false;
            this.Spisok_GB.Text = "Документы в режиме ожидания";
            // 
            // RefreshSpisok_B
            // 
            this.RefreshSpisok_B.Location = new System.Drawing.Point(6, 383);
            this.RefreshSpisok_B.Name = "RefreshSpisok_B";
            this.RefreshSpisok_B.Size = new System.Drawing.Size(339, 30);
            this.RefreshSpisok_B.TabIndex = 2;
            this.RefreshSpisok_B.Text = "Обновить список";
            this.RefreshSpisok_B.UseVisualStyleBackColor = true;
            this.RefreshSpisok_B.Click += new System.EventHandler(this.RefreshSpisok_B_Click);
            // 
            // ResultSpisok_GB
            // 
            this.ResultSpisok_GB.Controls.Add(this.ClearResultSpisok_B);
            this.ResultSpisok_GB.Controls.Add(this.ResultSpisok_LB);
            this.ResultSpisok_GB.Location = new System.Drawing.Point(368, 42);
            this.ResultSpisok_GB.Name = "ResultSpisok_GB";
            this.ResultSpisok_GB.Size = new System.Drawing.Size(351, 422);
            this.ResultSpisok_GB.TabIndex = 5;
            this.ResultSpisok_GB.TabStop = false;
            this.ResultSpisok_GB.Text = "Обработанные документы";
            // 
            // ClearResultSpisok_B
            // 
            this.ClearResultSpisok_B.Location = new System.Drawing.Point(6, 383);
            this.ClearResultSpisok_B.Name = "ClearResultSpisok_B";
            this.ClearResultSpisok_B.Size = new System.Drawing.Size(339, 30);
            this.ClearResultSpisok_B.TabIndex = 4;
            this.ClearResultSpisok_B.Text = "Очистить список";
            this.ClearResultSpisok_B.UseVisualStyleBackColor = true;
            this.ClearResultSpisok_B.Click += new System.EventHandler(this.ClearResultSpisok_B_Click);
            // 
            // ResultSpisok_LB
            // 
            this.ResultSpisok_LB.FormattingEnabled = true;
            this.ResultSpisok_LB.ItemHeight = 16;
            this.ResultSpisok_LB.Location = new System.Drawing.Point(6, 21);
            this.ResultSpisok_LB.Name = "ResultSpisok_LB";
            this.ResultSpisok_LB.Size = new System.Drawing.Size(339, 356);
            this.ResultSpisok_LB.TabIndex = 0;
            // 
            // Operation_GB
            // 
            this.Operation_GB.Controls.Add(this.OpenDocument_B);
            this.Operation_GB.Controls.Add(this.ConfirmALL_B);
            this.Operation_GB.Controls.Add(this.Confirm_B);
            this.Operation_GB.Location = new System.Drawing.Point(725, 42);
            this.Operation_GB.Name = "Operation_GB";
            this.Operation_GB.Size = new System.Drawing.Size(228, 134);
            this.Operation_GB.TabIndex = 6;
            this.Operation_GB.TabStop = false;
            this.Operation_GB.Text = "Операции";
            // 
            // OpenDocument_B
            // 
            this.OpenDocument_B.Location = new System.Drawing.Point(6, 93);
            this.OpenDocument_B.Name = "OpenDocument_B";
            this.OpenDocument_B.Size = new System.Drawing.Size(216, 30);
            this.OpenDocument_B.TabIndex = 6;
            this.OpenDocument_B.Text = "Добавить";
            this.OpenDocument_B.UseVisualStyleBackColor = true;
            this.OpenDocument_B.Click += new System.EventHandler(this.OpenDocument_B_Click);
            // 
            // ConfirmALL_B
            // 
            this.ConfirmALL_B.Location = new System.Drawing.Point(6, 57);
            this.ConfirmALL_B.Name = "ConfirmALL_B";
            this.ConfirmALL_B.Size = new System.Drawing.Size(216, 30);
            this.ConfirmALL_B.TabIndex = 5;
            this.ConfirmALL_B.Text = "Подтвердить все";
            this.ConfirmALL_B.UseVisualStyleBackColor = true;
            this.ConfirmALL_B.Click += new System.EventHandler(this.ConfirmALL_B_Click);
            // 
            // Status_TB
            // 
            this.Status_TB.Location = new System.Drawing.Point(6, 21);
            this.Status_TB.Multiline = true;
            this.Status_TB.Name = "Status_TB";
            this.Status_TB.ReadOnly = true;
            this.Status_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_TB.Size = new System.Drawing.Size(695, 134);
            this.Status_TB.TabIndex = 7;
            // 
            // Status_GB
            // 
            this.Status_GB.Controls.Add(this.Status_TB);
            this.Status_GB.Location = new System.Drawing.Point(12, 470);
            this.Status_GB.Name = "Status_GB";
            this.Status_GB.Size = new System.Drawing.Size(707, 161);
            this.Status_GB.TabIndex = 8;
            this.Status_GB.TabStop = false;
            this.Status_GB.Text = "Статус операции";
            // 
            // Users_CB
            // 
            this.Users_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Users_CB.FormattingEnabled = true;
            this.Users_CB.Location = new System.Drawing.Point(191, 12);
            this.Users_CB.Name = "Users_CB";
            this.Users_CB.Size = new System.Drawing.Size(761, 24);
            this.Users_CB.TabIndex = 1;
            this.Users_CB.SelectedIndexChanged += new System.EventHandler(this.Users_CB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Выберите пользователя";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 645);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Users_CB);
            this.Controls.Add(this.Operation_GB);
            this.Controls.Add(this.Status_GB);
            this.Controls.Add(this.ResultSpisok_GB);
            this.Controls.Add(this.Spisok_GB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление этапами документа";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Spisok_GB.ResumeLayout(false);
            this.ResultSpisok_GB.ResumeLayout(false);
            this.Operation_GB.ResumeLayout(false);
            this.Status_GB.ResumeLayout(false);
            this.Status_GB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button ConfirmALL_B;
        private System.Windows.Forms.TextBox Status_TB;
        private System.Windows.Forms.GroupBox Status_GB;
        private System.Windows.Forms.Button OpenDocument_B;
        private System.Windows.Forms.ComboBox Users_CB;
        private System.Windows.Forms.Label label1;
    }
}

