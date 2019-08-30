namespace Kuzbass_Project
{
    partial class IsOKFiles_Form
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
            this.label2 = new System.Windows.Forms.Label();
            this.Status_L = new System.Windows.Forms.Label();
            this.NameFile_L = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(308, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Обработка файлов";
            // 
            // Status_L
            // 
            this.Status_L.AutoSize = true;
            this.Status_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Status_L.Location = new System.Drawing.Point(283, 153);
            this.Status_L.Name = "Status_L";
            this.Status_L.Size = new System.Drawing.Size(213, 40);
            this.Status_L.TabIndex = 3;
            this.Status_L.Text = "Идет обработка...\r\nПожалуйста подождите";
            this.Status_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Status_L.Click += new System.EventHandler(this.label4_Click);
            // 
            // NameFile_L
            // 
            this.NameFile_L.AutoSize = true;
            this.NameFile_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameFile_L.Location = new System.Drawing.Point(198, 92);
            this.NameFile_L.Name = "NameFile_L";
            this.NameFile_L.Size = new System.Drawing.Size(157, 20);
            this.NameFile_L.TabIndex = 4;
            this.NameFile_L.Text = "Обработка файлов";
            this.NameFile_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IsOKFiles_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 211);
            this.Controls.Add(this.NameFile_L);
            this.Controls.Add(this.Status_L);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IsOKFiles_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выполнение запроса";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label Status_L;
        public System.Windows.Forms.Label NameFile_L;
    }
}