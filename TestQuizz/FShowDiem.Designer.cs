namespace TestQuizz
{
    partial class FShowDiem
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
            this.panelGameChonCap = new System.Windows.Forms.Panel();
            this.labelthoiGian = new System.Windows.Forms.Label();
            this.labelDiem = new System.Windows.Forms.Label();
            this.bttOK = new System.Windows.Forms.Button();
            this.panelGameChonCap.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGameChonCap
            // 
            this.panelGameChonCap.BackColor = System.Drawing.Color.Transparent;
            this.panelGameChonCap.Controls.Add(this.labelthoiGian);
            this.panelGameChonCap.Controls.Add(this.labelDiem);
            this.panelGameChonCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.panelGameChonCap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelGameChonCap.Location = new System.Drawing.Point(595, 195);
            this.panelGameChonCap.Name = "panelGameChonCap";
            this.panelGameChonCap.Size = new System.Drawing.Size(479, 445);
            this.panelGameChonCap.TabIndex = 24;
            // 
            // labelthoiGian
            // 
            this.labelthoiGian.AutoSize = true;
            this.labelthoiGian.BackColor = System.Drawing.Color.Transparent;
            this.labelthoiGian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelthoiGian.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelthoiGian.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelthoiGian.Location = new System.Drawing.Point(131, 327);
            this.labelthoiGian.Name = "labelthoiGian";
            this.labelthoiGian.Size = new System.Drawing.Size(243, 93);
            this.labelthoiGian.TabIndex = 16;
            this.labelthoiGian.Text = "00:00";
            // 
            // labelDiem
            // 
            this.labelDiem.AutoSize = true;
            this.labelDiem.BackColor = System.Drawing.Color.Transparent;
            this.labelDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDiem.Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelDiem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelDiem.Location = new System.Drawing.Point(175, 67);
            this.labelDiem.Name = "labelDiem";
            this.labelDiem.Size = new System.Drawing.Size(126, 139);
            this.labelDiem.TabIndex = 15;
            this.labelDiem.Text = "0";
            // 
            // bttOK
            // 
            this.bttOK.BackgroundImage = global::TestQuizz.Properties.Resources.z5418767400682_08c4373207d871aeacdaadbd0b97428e1;
            this.bttOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bttOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bttOK.Location = new System.Drawing.Point(692, 692);
            this.bttOK.Name = "bttOK";
            this.bttOK.Size = new System.Drawing.Size(290, 81);
            this.bttOK.TabIndex = 25;
            this.bttOK.Text = "Xác nhận !";
            this.bttOK.UseVisualStyleBackColor = true;
            this.bttOK.Click += new System.EventHandler(this.bttOK_Click);
            // 
            // FShowDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TestQuizz.Properties.Resources.BackgroundHoanThanh1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1685, 785);
            this.Controls.Add(this.bttOK);
            this.Controls.Add(this.panelGameChonCap);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FShowDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FShowDiem";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(48)))), ((int)(((byte)(160)))));
            this.panelGameChonCap.ResumeLayout(false);
            this.panelGameChonCap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelGameChonCap;
        private System.Windows.Forms.Label labelthoiGian;
        private System.Windows.Forms.Label labelDiem;
        private System.Windows.Forms.Button bttOK;
    }
}