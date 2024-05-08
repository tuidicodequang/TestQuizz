namespace TestQuizz
{
    partial class FShowDanhSachCauHoi
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDapAn3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDapAn2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDapAn1 = new System.Windows.Forms.TextBox();
            this.cboMon = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDapAnDung = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(137, 214);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(784, 350);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(595, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Môn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Đáp án 3";
            // 
            // txtDapAn3
            // 
            this.txtDapAn3.Location = new System.Drawing.Point(701, 126);
            this.txtDapAn3.Name = "txtDapAn3";
            this.txtDapAn3.Size = new System.Drawing.Size(194, 22);
            this.txtDapAn3.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(592, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Đáp án 2";
            // 
            // txtDapAn2
            // 
            this.txtDapAn2.Location = new System.Drawing.Point(701, 80);
            this.txtDapAn2.Name = "txtDapAn2";
            this.txtDapAn2.Size = new System.Drawing.Size(194, 22);
            this.txtDapAn2.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Đáp án 1";
            // 
            // txtDapAn1
            // 
            this.txtDapAn1.Location = new System.Drawing.Point(242, 152);
            this.txtDapAn1.Name = "txtDapAn1";
            this.txtDapAn1.Size = new System.Drawing.Size(194, 22);
            this.txtDapAn1.TabIndex = 18;
            // 
            // cboMon
            // 
            this.cboMon.FormattingEnabled = true;
            this.cboMon.Items.AddRange(new object[] {
            "Toán",
            "Tiếng Anh",
            "Văn",
            "Lịch Sử "});
            this.cboMon.Location = new System.Drawing.Point(701, 40);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(187, 24);
            this.cboMon.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Đáp án đúng";
            // 
            // txtDapAnDung
            // 
            this.txtDapAnDung.Location = new System.Drawing.Point(242, 96);
            this.txtDapAnDung.Name = "txtDapAnDung";
            this.txtDapAnDung.Size = new System.Drawing.Size(188, 22);
            this.txtDapAnDung.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nội dung";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(242, 40);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(194, 22);
            this.txtNoiDung.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(888, 629);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 64);
            this.button1.TabIndex = 25;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FShowDanhSachCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 733);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDapAn3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDapAn2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDapAn1);
            this.Controls.Add(this.cboMon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDapAnDung);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FShowDanhSachCauHoi";
            this.Text = "FShowDanhSachCauHoi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDapAn3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDapAn2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDapAn1;
        private System.Windows.Forms.ComboBox cboMon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDapAnDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Button button1;
    }
}