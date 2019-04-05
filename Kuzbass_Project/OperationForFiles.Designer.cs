namespace Kuzbass_Project
{
    partial class OperationForFiles
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
            this.Change_B = new System.Windows.Forms.Button();
            this.Delete_B = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClearSpisok_B = new System.Windows.Forms.Button();
            this.RefreshSpisok_B = new System.Windows.Forms.Button();
            this.ResultSpisok_GB = new System.Windows.Forms.GroupBox();
            this.Spisok_LB = new System.Windows.Forms.ListBox();
            this.Mode_CB = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OK_B = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.ResultSpisok_GB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Change_B
            // 
            this.Change_B.Location = new System.Drawing.Point(4, 72);
            this.Change_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Change_B.Name = "Change_B";
            this.Change_B.Size = new System.Drawing.Size(206, 24);
            this.Change_B.TabIndex = 4;
            this.Change_B.Text = "&Изменить";
            this.Change_B.UseVisualStyleBackColor = true;
            this.Change_B.Click += new System.EventHandler(this.Change_B_Click);
            // 
            // Delete_B
            // 
            this.Delete_B.Location = new System.Drawing.Point(4, 100);
            this.Delete_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Delete_B.Name = "Delete_B";
            this.Delete_B.Size = new System.Drawing.Size(206, 24);
            this.Delete_B.TabIndex = 5;
            this.Delete_B.Text = "&Удалить";
            this.Delete_B.UseVisualStyleBackColor = true;
            this.Delete_B.Click += new System.EventHandler(this.Delete_B_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ClearSpisok_B);
            this.groupBox1.Controls.Add(this.Change_B);
            this.groupBox1.Controls.Add(this.Delete_B);
            this.groupBox1.Controls.Add(this.RefreshSpisok_B);
            this.groupBox1.Location = new System.Drawing.Point(341, 57);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(214, 132);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Операции";
            // 
            // ClearSpisok_B
            // 
            this.ClearSpisok_B.Location = new System.Drawing.Point(4, 45);
            this.ClearSpisok_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ClearSpisok_B.Name = "ClearSpisok_B";
            this.ClearSpisok_B.Size = new System.Drawing.Size(206, 24);
            this.ClearSpisok_B.TabIndex = 6;
            this.ClearSpisok_B.Text = "О&чистить список";
            this.ClearSpisok_B.UseVisualStyleBackColor = true;
            this.ClearSpisok_B.Click += new System.EventHandler(this.ClearSpisok_B_Click);
            // 
            // RefreshSpisok_B
            // 
            this.RefreshSpisok_B.Location = new System.Drawing.Point(4, 17);
            this.RefreshSpisok_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RefreshSpisok_B.Name = "RefreshSpisok_B";
            this.RefreshSpisok_B.Size = new System.Drawing.Size(206, 24);
            this.RefreshSpisok_B.TabIndex = 2;
            this.RefreshSpisok_B.Text = "&Обновить список";
            this.RefreshSpisok_B.UseVisualStyleBackColor = true;
            this.RefreshSpisok_B.Click += new System.EventHandler(this.RefreshSpisok_B_Click);
            // 
            // ResultSpisok_GB
            // 
            this.ResultSpisok_GB.Controls.Add(this.Spisok_LB);
            this.ResultSpisok_GB.Location = new System.Drawing.Point(9, 7);
            this.ResultSpisok_GB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ResultSpisok_GB.Name = "ResultSpisok_GB";
            this.ResultSpisok_GB.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ResultSpisok_GB.Size = new System.Drawing.Size(328, 391);
            this.ResultSpisok_GB.TabIndex = 8;
            this.ResultSpisok_GB.TabStop = false;
            this.ResultSpisok_GB.Text = "Список документов";
            // 
            // Spisok_LB
            // 
            this.Spisok_LB.FormattingEnabled = true;
            this.Spisok_LB.Location = new System.Drawing.Point(5, 19);
            this.Spisok_LB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Spisok_LB.Name = "Spisok_LB";
            this.Spisok_LB.Size = new System.Drawing.Size(319, 368);
            this.Spisok_LB.TabIndex = 3;
            this.Spisok_LB.SelectedIndexChanged += new System.EventHandler(this.Spisok_LB_SelectedIndexChanged);
            // 
            // Mode_CB
            // 
            this.Mode_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mode_CB.FormattingEnabled = true;
            this.Mode_CB.Location = new System.Drawing.Point(4, 16);
            this.Mode_CB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Mode_CB.Name = "Mode_CB";
            this.Mode_CB.Size = new System.Drawing.Size(206, 21);
            this.Mode_CB.TabIndex = 1;
            this.Mode_CB.SelectedIndexChanged += new System.EventHandler(this.Mode_CB_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OK_B);
            this.groupBox2.Location = new System.Drawing.Point(341, 351);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(214, 47);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Завершение модификации";
            // 
            // OK_B
            // 
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_B.Location = new System.Drawing.Point(4, 16);
            this.OK_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(206, 24);
            this.OK_B.TabIndex = 7;
            this.OK_B.Text = "&Готово";
            this.OK_B.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Mode_CB);
            this.groupBox3.Location = new System.Drawing.Point(341, 7);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(214, 45);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Режим отображения";
            // 
            // OperationForFiles
            // 
            this.AcceptButton = this.OK_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 408);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ResultSpisok_GB);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperationForFiles";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение данных файлов";
            this.Load += new System.EventHandler(this.OperationForFiles_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResultSpisok_GB.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Change_B;
        private System.Windows.Forms.Button Delete_B;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox ResultSpisok_GB;
        private System.Windows.Forms.ComboBox Mode_CB;
        private System.Windows.Forms.Button RefreshSpisok_B;
        private System.Windows.Forms.ListBox Spisok_LB;
        private System.Windows.Forms.Button ClearSpisok_B;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button OK_B;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}