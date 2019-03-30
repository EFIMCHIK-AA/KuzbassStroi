namespace Kuzbass_Project
{
    partial class Change
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.OK_B = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Status_CB = new System.Windows.Forms.ComboBox();
            this.NumberDoc_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QR_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cancel_B);
            this.groupBox1.Controls.Add(this.OK_B);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Status_CB);
            this.groupBox1.Controls.Add(this.NumberDoc_TB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.QR_TB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(28, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные документа";
            // 
            // Cancel_B
            // 
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Location = new System.Drawing.Point(183, 115);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(156, 30);
            this.Cancel_B.TabIndex = 7;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.UseVisualStyleBackColor = true;
            // 
            // OK_B
            // 
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_B.Location = new System.Drawing.Point(17, 115);
            this.OK_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(156, 30);
            this.OK_B.TabIndex = 5;
            this.OK_B.Text = "OK";
            this.OK_B.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Статус";
            // 
            // Status_CB
            // 
            this.Status_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Status_CB.FormattingEnabled = true;
            this.Status_CB.Location = new System.Drawing.Point(122, 86);
            this.Status_CB.Name = "Status_CB";
            this.Status_CB.Size = new System.Drawing.Size(217, 24);
            this.Status_CB.TabIndex = 5;
            // 
            // NumberDoc_TB
            // 
            this.NumberDoc_TB.Location = new System.Drawing.Point(122, 58);
            this.NumberDoc_TB.Name = "NumberDoc_TB";
            this.NumberDoc_TB.Size = new System.Drawing.Size(217, 22);
            this.NumberDoc_TB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Номер бланка";
            // 
            // QR_TB
            // 
            this.QR_TB.Location = new System.Drawing.Point(122, 30);
            this.QR_TB.Name = "QR_TB";
            this.QR_TB.Size = new System.Drawing.Size(217, 22);
            this.QR_TB.TabIndex = 1;
            this.QR_TB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "QR документа";
            // 
            // Change
            // 
            this.AcceptButton = this.OK_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_B;
            this.ClientSize = new System.Drawing.Size(412, 204);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Change";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение документа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Change_FormClosing);
            this.Load += new System.EventHandler(this.Change_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox QR_TB;
        public System.Windows.Forms.ComboBox Status_CB;
        public System.Windows.Forms.TextBox NumberDoc_TB;
        public System.Windows.Forms.Button Cancel_B;
        public System.Windows.Forms.Button OK_B;
    }
}