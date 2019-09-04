namespace Kuzbass_Project
{
    partial class Report
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
            this.Text_TB = new System.Windows.Forms.TextBox();
            this.OK_B = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Text_TB
            // 
            this.Text_TB.Location = new System.Drawing.Point(12, 51);
            this.Text_TB.Multiline = true;
            this.Text_TB.Name = "Text_TB";
            this.Text_TB.ReadOnly = true;
            this.Text_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Text_TB.Size = new System.Drawing.Size(776, 354);
            this.Text_TB.TabIndex = 9;
            // 
            // OK_B
            // 
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_B.Location = new System.Drawing.Point(13, 410);
            this.OK_B.Margin = new System.Windows.Forms.Padding(2);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(776, 24);
            this.OK_B.TabIndex = 8;
            this.OK_B.Text = "&OK";
            this.OK_B.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(226, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Отчет по перемещению файлов";
            // 
            // Report
            // 
            this.AcceptButton = this.OK_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 447);
            this.Controls.Add(this.Text_TB);
            this.Controls.Add(this.OK_B);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Text_TB;
        private System.Windows.Forms.Button OK_B;
        private System.Windows.Forms.Label label1;
    }
}