namespace TestQuizz
{
    partial class FGiaoVien
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTenGV = new System.Windows.Forms.Label();
            this.lbBoMon = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.paneltrangcon = new System.Windows.Forms.Panel();
            this.bttchangePass = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.paneltrangcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 285);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1244, 300);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbTenGV
            // 
            this.lbTenGV.AutoSize = true;
            this.lbTenGV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(0)))));
            this.lbTenGV.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTenGV.Location = new System.Drawing.Point(83, 52);
            this.lbTenGV.Name = "lbTenGV";
            this.lbTenGV.Size = new System.Drawing.Size(182, 27);
            this.lbTenGV.TabIndex = 1;
            this.lbTenGV.Text = "Tên Giáo Viên: ";
            // 
            // lbBoMon
            // 
            this.lbBoMon.AutoSize = true;
            this.lbBoMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lbBoMon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbBoMon.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbBoMon.Location = new System.Drawing.Point(289, 100);
            this.lbBoMon.Name = "lbBoMon";
            this.lbBoMon.Size = new System.Drawing.Size(90, 24);
            this.lbBoMon.TabIndex = 2;
            this.lbBoMon.Text = "Bộ Môn:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lbBoMon);
            this.panel1.Controls.Add(this.lbTenGV);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(24, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 144);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TestQuizz.Properties.Resources.LabelTenGV;
            this.pictureBox1.Location = new System.Drawing.Point(3, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(576, 126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // paneltrangcon
            // 
            this.paneltrangcon.BackColor = System.Drawing.Color.Gainsboro;
            this.paneltrangcon.BackgroundImage = global::TestQuizz.Properties.Resources.backgroundFGV;
            this.paneltrangcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paneltrangcon.Controls.Add(this.bttchangePass);
            this.paneltrangcon.Controls.Add(this.tableLayoutPanel1);
            this.paneltrangcon.Controls.Add(this.panel1);
            this.paneltrangcon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paneltrangcon.Location = new System.Drawing.Point(0, 39);
            this.paneltrangcon.Name = "paneltrangcon";
            this.paneltrangcon.Size = new System.Drawing.Size(1299, 680);
            this.paneltrangcon.TabIndex = 4;
            // 
            // bttchangePass
            // 
            this.bttchangePass.BackColor = System.Drawing.Color.Transparent;
            this.bttchangePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttchangePass.FlatAppearance.BorderSize = 0;
            this.bttchangePass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bttchangePass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bttchangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttchangePass.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.bttchangePass.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.bttchangePass.Location = new System.Drawing.Point(1142, 625);
            this.bttchangePass.Name = "bttchangePass";
            this.bttchangePass.Size = new System.Drawing.Size(157, 55);
            this.bttchangePass.TabIndex = 4;
            this.bttchangePass.Text = "Đổi mật khẩu";
            this.bttchangePass.UseVisualStyleBackColor = false;
            this.bttchangePass.Click += new System.EventHandler(this.bttchangePass_Click);
            this.bttchangePass.MouseLeave += new System.EventHandler(this.bttchangePass_MouseLeave);
            this.bttchangePass.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bttchangePass_MouseMove);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Modern No. 20", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(1241, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1299, 719);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.paneltrangcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FGiaoVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FGiaoVien";
            this.Load += new System.EventHandler(this.FGiaoVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.paneltrangcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbTenGV;
        private System.Windows.Forms.Label lbBoMon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel paneltrangcon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bttchangePass;
    }
}