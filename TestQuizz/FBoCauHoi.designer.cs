namespace TestQuizz
{
    partial class FBoCauHoi
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvBoCauHoi = new System.Windows.Forms.DataGridView();
            this.dgvCauHoi = new System.Windows.Forms.DataGridView();
            this.txtMaBoCH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenBo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.cboMon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoCauHoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Location = new System.Drawing.Point(104, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 55);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvBoCauHoi
            // 
            this.dgvBoCauHoi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBoCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoCauHoi.Location = new System.Drawing.Point(305, 24);
            this.dgvBoCauHoi.Name = "dgvBoCauHoi";
            this.dgvBoCauHoi.RowHeadersWidth = 51;
            this.dgvBoCauHoi.RowTemplate.Height = 27;
            this.dgvBoCauHoi.Size = new System.Drawing.Size(309, 656);
            this.dgvBoCauHoi.TabIndex = 1;
            this.dgvBoCauHoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBoCauHoi_CellClick);
            // 
            // dgvCauHoi
            // 
            this.dgvCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCauHoi.Location = new System.Drawing.Point(632, 24);
            this.dgvCauHoi.Name = "dgvCauHoi";
            this.dgvCauHoi.RowHeadersWidth = 51;
            this.dgvCauHoi.RowTemplate.Height = 27;
            this.dgvCauHoi.Size = new System.Drawing.Size(583, 656);
            this.dgvCauHoi.TabIndex = 2;
            // 
            // txtMaBoCH
            // 
            this.txtMaBoCH.Location = new System.Drawing.Point(11, 163);
            this.txtMaBoCH.Name = "txtMaBoCH";
            this.txtMaBoCH.Size = new System.Drawing.Size(237, 25);
            this.txtMaBoCH.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tên Bộ Câu Hỏi";
            // 
            // txtTenBo
            // 
            this.txtTenBo.Location = new System.Drawing.Point(20, 252);
            this.txtTenBo.Name = "txtTenBo";
            this.txtTenBo.Size = new System.Drawing.Size(237, 25);
            this.txtTenBo.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Tên Bộ Câu Hỏi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Lớp";
            // 
            // cboLop
            // 
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Items.AddRange(new object[] {
            "Lớp 1",
            "Lớp 2",
            "Lớp 3",
            "Lớp 4",
            "Lớp 5 "});
            this.cboLop.Location = new System.Drawing.Point(72, 361);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(147, 25);
            this.cboLop.TabIndex = 26;
            // 
            // cboMon
            // 
            this.cboMon.FormattingEnabled = true;
            this.cboMon.Items.AddRange(new object[] {
            "Toán",
            "Văn",
            "Khoa Học và Lịch Sử",
            "Tiếng Anh"});
            this.cboMon.Location = new System.Drawing.Point(72, 459);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(147, 25);
            this.cboMon.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Môn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 545);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 50);
            this.button1.TabIndex = 29;
            this.button1.Text = "Thêm câu hỏi từ danh sách";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FBoCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 692);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboMon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenBo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMaBoCH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCauHoi);
            this.Controls.Add(this.dgvBoCauHoi);
            this.Controls.Add(this.btnAdd);
            this.Name = "FBoCauHoi";
            this.Text = "FBoCauHoi";
            this.Load += new System.EventHandler(this.FBoCauHoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoCauHoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvBoCauHoi;
        private System.Windows.Forms.DataGridView dgvCauHoi;
        private System.Windows.Forms.TextBox txtMaBoCH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenBo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboMon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}