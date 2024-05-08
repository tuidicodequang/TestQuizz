namespace TestQuizz
{
    partial class ItemBaiKiemTra
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.lbTenBaiKT = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbThoiGianBatDau = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbThoiGianKetThuc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Bắt đầu làm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbTenBaiKT
            // 
            this.lbTenBaiKT.AutoSize = true;
            this.lbTenBaiKT.Location = new System.Drawing.Point(57, 42);
            this.lbTenBaiKT.Name = "lbTenBaiKT";
            this.lbTenBaiKT.Size = new System.Drawing.Size(104, 17);
            this.lbTenBaiKT.TabIndex = 1;
            this.lbTenBaiKT.Text = "Tên Bài Kiểm Tra";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 24);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Location = new System.Drawing.Point(0, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 21);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel3.Location = new System.Drawing.Point(0, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(22, 147);
            this.panel3.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel4.Location = new System.Drawing.Point(508, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(22, 147);
            this.panel4.TabIndex = 5;
            // 
            // lbThoiGianBatDau
            // 
            this.lbThoiGianBatDau.AutoSize = true;
            this.lbThoiGianBatDau.Location = new System.Drawing.Point(207, 80);
            this.lbThoiGianBatDau.Name = "lbThoiGianBatDau";
            this.lbThoiGianBatDau.Size = new System.Drawing.Size(43, 17);
            this.lbThoiGianBatDau.TabIndex = 9;
            this.lbThoiGianBatDau.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Thời Gian Bắt Đầu";
            // 
            // lbThoiGianKetThuc
            // 
            this.lbThoiGianKetThuc.AutoSize = true;
            this.lbThoiGianKetThuc.Location = new System.Drawing.Point(207, 115);
            this.lbThoiGianKetThuc.Name = "lbThoiGianKetThuc";
            this.lbThoiGianKetThuc.Size = new System.Drawing.Size(43, 17);
            this.lbThoiGianKetThuc.TabIndex = 11;
            this.lbThoiGianKetThuc.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Thời Gian Bắt Đầu";
            // 
            // ItemBaiKiemTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.lbThoiGianKetThuc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbThoiGianBatDau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTenBaiKT);
            this.Controls.Add(this.button1);
            this.Name = "ItemBaiKiemTra";
            this.Size = new System.Drawing.Size(530, 183);
            this.Load += new System.EventHandler(this.ItemBaiKiemTra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbTenBaiKT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbThoiGianBatDau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbThoiGianKetThuc;
        private System.Windows.Forms.Label label4;
    }
}
