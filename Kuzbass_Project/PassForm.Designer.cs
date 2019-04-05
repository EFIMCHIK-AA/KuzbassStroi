namespace Kuzbass_Project
{
    partial class PassForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassForm));
            this.Pass_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Login_CB = new System.Windows.Forms.ComboBox();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.Enter_B = new System.Windows.Forms.Button();
            this.CheckPass_CB = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pass_TB
            // 
            this.Pass_TB.Location = new System.Drawing.Point(55, 40);
            this.Pass_TB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Pass_TB.Name = "Pass_TB";
            this.Pass_TB.Size = new System.Drawing.Size(198, 20);
            this.Pass_TB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Логин";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Login_CB);
            this.groupBox1.Controls.Add(this.Cancel_B);
            this.groupBox1.Controls.Add(this.Enter_B);
            this.groupBox1.Controls.Add(this.CheckPass_CB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Pass_TB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(262, 122);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные инициализации";
            // 
            // Login_CB
            // 
            this.Login_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Login_CB.FormattingEnabled = true;
            this.Login_CB.Location = new System.Drawing.Point(55, 17);
            this.Login_CB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Login_CB.Name = "Login_CB";
            this.Login_CB.Size = new System.Drawing.Size(198, 21);
            this.Login_CB.TabIndex = 1;
            this.Login_CB.SelectedIndexChanged += new System.EventHandler(this.Login_CB_SelectedIndexChanged);
            // 
            // Cancel_B
            // 
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Location = new System.Drawing.Point(136, 84);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(115, 24);
            this.Cancel_B.TabIndex = 5;
            this.Cancel_B.Text = "&Отмена";
            this.Cancel_B.UseVisualStyleBackColor = true;
            // 
            // Enter_B
            // 
            this.Enter_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Enter_B.Location = new System.Drawing.Point(10, 84);
            this.Enter_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Enter_B.Name = "Enter_B";
            this.Enter_B.Size = new System.Drawing.Size(115, 24);
            this.Enter_B.TabIndex = 4;
            this.Enter_B.Text = "&Войти";
            this.Enter_B.UseVisualStyleBackColor = true;
            // 
            // CheckPass_CB
            // 
            this.CheckPass_CB.AutoSize = true;
            this.CheckPass_CB.Location = new System.Drawing.Point(10, 63);
            this.CheckPass_CB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheckPass_CB.Name = "CheckPass_CB";
            this.CheckPass_CB.Size = new System.Drawing.Size(114, 17);
            this.CheckPass_CB.TabIndex = 3;
            this.CheckPass_CB.Text = "&Показать пароль";
            this.CheckPass_CB.UseVisualStyleBackColor = true;
            this.CheckPass_CB.CheckedChanged += new System.EventHandler(this.CheckPass_CB_CheckedChanged);
            // 
            // PassForm
            // 
            this.AcceptButton = this.Enter_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_B;
            this.ClientSize = new System.Drawing.Size(308, 161);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PassForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Инициализация пользователя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PassForm_FormClosing);
            this.Load += new System.EventHandler(this.PassForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CheckPass_CB;
        private System.Windows.Forms.Button Cancel_B;
        private System.Windows.Forms.Button Enter_B;
        public System.Windows.Forms.TextBox Pass_TB;
        public System.Windows.Forms.ComboBox Login_CB;
    }
}