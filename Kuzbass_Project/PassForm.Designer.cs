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
            this.Pass_TB.Location = new System.Drawing.Point(73, 49);
            this.Pass_TB.Name = "Pass_TB";
            this.Pass_TB.Size = new System.Drawing.Size(262, 22);
            this.Pass_TB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
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
            this.groupBox1.Location = new System.Drawing.Point(30, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 150);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные инициализации";
            // 
            // Login_CB
            // 
            this.Login_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Login_CB.FormattingEnabled = true;
            this.Login_CB.Location = new System.Drawing.Point(73, 21);
            this.Login_CB.Name = "Login_CB";
            this.Login_CB.Size = new System.Drawing.Size(262, 24);
            this.Login_CB.TabIndex = 9;
            this.Login_CB.SelectedIndexChanged += new System.EventHandler(this.Login_CB_SelectedIndexChanged);
            // 
            // Cancel_B
            // 
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Location = new System.Drawing.Point(182, 104);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(153, 30);
            this.Cancel_B.TabIndex = 8;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.UseVisualStyleBackColor = true;
            // 
            // Enter_B
            // 
            this.Enter_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Enter_B.Location = new System.Drawing.Point(13, 104);
            this.Enter_B.Name = "Enter_B";
            this.Enter_B.Size = new System.Drawing.Size(153, 30);
            this.Enter_B.TabIndex = 7;
            this.Enter_B.Text = "Войти";
            this.Enter_B.UseVisualStyleBackColor = true;
            // 
            // CheckPass_CB
            // 
            this.CheckPass_CB.AutoSize = true;
            this.CheckPass_CB.Location = new System.Drawing.Point(13, 77);
            this.CheckPass_CB.Name = "CheckPass_CB";
            this.CheckPass_CB.Size = new System.Drawing.Size(143, 21);
            this.CheckPass_CB.TabIndex = 4;
            this.CheckPass_CB.Text = "Показать пароль";
            this.CheckPass_CB.UseVisualStyleBackColor = true;
            this.CheckPass_CB.CheckedChanged += new System.EventHandler(this.CheckPass_CB_CheckedChanged);
            // 
            // PassForm
            // 
            this.AcceptButton = this.Enter_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_B;
            this.ClientSize = new System.Drawing.Size(410, 198);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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