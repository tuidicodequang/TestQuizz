using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestQuizz
{
    public partial class FShowDiem : Form
    {
        private Timer timer;

      
        public int Diem;
        public int TongThoigian;
        public FShowDiem(double diem, int TongThoiGian)
        {
            InitializeComponent();
           
            TongThoigian = TongThoiGian;
            labelDiem.Text = diem.ToString();
            labelthoiGian.Text = TimeSpan.FromSeconds(TongThoigian).ToString(@"mm\:ss");
            timer = new Timer();
            timer.Interval = 5000; // 5000 milliseconds = 5 seconds
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        public FShowDiem(int diem, int TongThoiGian)
        {
            InitializeComponent();
            Diem = diem;
            TongThoigian = TongThoiGian;
            labelDiem.Text = Diem.ToString();
            labelthoiGian.Text = TimeSpan.FromSeconds(TongThoigian).ToString(@"mm\:ss");
            timer = new Timer();
            timer.Interval = 5000; // 5000 milliseconds = 5 seconds
            timer.Tick += Timer_Tick;
            timer.Start();
        }
     
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Dừng Timer để không lặp lại
            timer.Stop();
            // Đóng form
            this.Close();
        }

      

        private void bttOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
