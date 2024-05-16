using HarfBuzzSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestQuizz.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace TestQuizz
{
    public partial class FVuotChuongNgaiVat : Form
    {
        public int remainingSeconds { get; set; }
        public HocSinh HocSinh { get; set; }


        private int TongThoiGian = 0;
        private int currentIndex = 0; // Chỉ số của câu hỏi hiện tại
        List<CauHoi> danhSachCauHoi = new List<CauHoi>();
        private string videoPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "TestQuizz", "Resources", "xechayvuotchuongngaivat.mp4");
        private int[] timePoints = { 4, 8, 14, 19, 24, 29, 35, 40, 44, 50 }; // Các thời điểm để pasue video nè
        private int currentTimePointIndex = -1;
        private Timer timer;
        private Timer timer1;
        private Timer timer2;
        private Timer timerLoad;

        int diem = 0;
        public double Diem { get { return diem; } }

        private List<ChiTietCauTraLoi> dscautraloi = new List<ChiTietCauTraLoi>();
        public List<ChiTietCauTraLoi> dsCauTraLoi { get { return dscautraloi; } }

        public FVuotChuongNgaiVat(List<CauHoi> cauhoiList, int ThoiGian, HocSinh hs)
        {
            InitializeComponent();

            CenterToScreen();
            InitializeMediaPlayer();
            InitializeTimer();
            danhSachCauHoi = cauhoiList;
            this.remainingSeconds = ThoiGian;
            this.HocSinh = hs;
            lbTenHS.Text = hs.TenHS;
            lbLop.Text = hs.Tenlop;
            UpdateQuestion();
        }

        public void HoanThanh()
        {
          
                timer2.Stop();
                panel3.BringToFront();
                labeltimeHT.Text = TimeSpan.FromSeconds(TongThoiGian).ToString(@"mm\:ss");
                labelDiemTong.Text = diem.ToString();
                 axWindowsMediaPlayer2.Ctlcontrols.stop();
                axWindowsMediaPlayer2.Visible = false;
            
            FShowDiem f = new FShowDiem(diem, TongThoiGian);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
        private void CheckDapAn(string bt)
        {
            CauHoi currentQuestion = danhSachCauHoi[currentIndex];

            string dapan = currentQuestion.DapAnDung;
            if (bt == dapan)
            {
                diem++;
                dscautraloi.Add(new ChiTietCauTraLoi(currentQuestion.NoiDung, dapan, 1));
                labelDiem.Text = diem.ToString();
                pictureBoxDungSai.Image = Properties.Resources.raising_hands_thumbs_up; // Hiển thị ảnh 2 nếu đáp án sai
                pictureBoxDungSai.Visible = true;
            }

            else
            {
                dscautraloi.Add(new ChiTietCauTraLoi(currentQuestion.NoiDung, dapan, 0));
                pictureBoxDungSai.Image = Properties.Resources.x_no; // Hiển thị ảnh 1 nếu đáp án đúng
                pictureBoxDungSai.Visible = true;
            }

            timer1.Start(); // Bắt đầu đếm thời gian

        }
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // Cài đặt khoảng thời gian là 1 giây
            timer.Tick += Timer_Tick;
            timer.Start();
            timer1 = new Timer();
            timer1.Interval = 2000; // Cài đặt khoảng thời gian là 2 giây
            timer1.Tick += Timer1_Tick;
            timer2 = new Timer();
            timer2.Interval = 1000; // Cài đặt khoảng thời gian là 1 giây
            timer2.Tick += Timer2_Tick;
            timerLoad = new Timer();
            timerLoad.Interval = 1000;
            timerLoad.Tick += TimerLoad_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            double currentPosition = axWindowsMediaPlayer2.Ctlcontrols.currentPosition;
            if (currentTimePointIndex < timePoints.Length - 1 && currentPosition >= timePoints[currentTimePointIndex + 1])
            {
                axWindowsMediaPlayer2.Ctlcontrols.pause(); // Dừng video tại điểm thời gian được chỉ định
                timer2.Start();
                textBoxCauHoi.SelectionAlignment = HorizontalAlignment.Center;
                panel1.BringToFront();
                panel2.BringToFront();
                labelSoCau.Text = (currentIndex + 1).ToString()+"/ 10";
                currentTimePointIndex++;

            }
            if (currentPosition >=55)
            {
                panel2.BringToFront();
                axWindowsMediaPlayer2.Ctlcontrols.pause();
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); // Dừng đếm thời gian
       
            pictureBoxDungSai.Visible = false;
            axWindowsMediaPlayer2.Ctlcontrols.play(); // Tiếp tục phát video
            timer2.Stop(); // Dừng đếm thời gian
            axWindowsMediaPlayer2.BringToFront();
            currentIndex++;
            UpdateQuestion();


        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            // Giảm thời gian đếm ngược mỗi lần Tick của Timer
            remainingSeconds--;
            TongThoiGian++;
            // Hiển thị thời gian đếm ngược trên Label
            labeltime.Text = TimeSpan.FromSeconds(remainingSeconds).ToString(@"mm\:ss");


            // Kiểm tra nếu thời gian đếm ngược đã hết
            if (remainingSeconds == 0)
            {

                HoanThanh();

            }

        }
        private void TimerLoad_Tick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Visible = true;
        }
        private void InitializeMediaPlayer()
        {
            axWindowsMediaPlayer2.Dock = DockStyle.Fill;
            axWindowsMediaPlayer2.settings.volume = 0;
            axWindowsMediaPlayer2.uiMode = "none";
            axWindowsMediaPlayer2.stretchToFit = true;
            axWindowsMediaPlayer2.Visible = true;
            axWindowsMediaPlayer2.PlayStateChange += axWindowsMediaPlayer2_PlayStateChange;
            this.Controls.Add(axWindowsMediaPlayer2);
            axWindowsMediaPlayer2.settings.autoStart = false;
            axWindowsMediaPlayer2.URL = videoPath;
        }
     
        
        private void axWindowsMediaPlayer2_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelGT.Visible = false;
            timerLoad.Start();
            axWindowsMediaPlayer2.BringToFront(); // Đưa control video lên trên cùng
            axWindowsMediaPlayer2.Visible=false;
            labeltime.Text = TimeSpan.FromSeconds(remainingSeconds).ToString(@"mm\:ss");
            axWindowsMediaPlayer2.Ctlcontrols.play(); // Bắt đầu phát video
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckDapAn(buttonDA1.Text);
           
        }

       
        private void UpdateQuestion()
        {
            if (currentIndex >= 0 && currentIndex < danhSachCauHoi.Count)
            {
                CauHoi currentQuestion = danhSachCauHoi[currentIndex];
                // Tạo một danh sách mới chứa các đáp án
                List<string> answers = new List<string> { currentQuestion.DapAn1, currentQuestion.DapAn2, currentQuestion.DapAn3, currentQuestion.DapAnDung };
                // Trộn thứ tự của các đáp án trong danh sách
                answers = answers.OrderBy(x => Guid.NewGuid()).ToList();
                // Gán các đáp án vào các button
                buttonDA1.Text = answers[0];
                buttonDA2.Text = answers[1];
                buttonDA3.Text = answers[2];
                buttonDA4.Text = answers[3];
                // Cập nhật nội dung của TextBox1 là nội dung của câu hỏi hiện tại
                textBoxCauHoi.Text = currentQuestion.NoiDung;
            }
            else
            {
                HoanThanh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckDapAn(buttonDA3.Text);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            CheckDapAn(buttonDA2.Text);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            CheckDapAn(buttonDA4.Text);
            
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            Cursor= Cursors.Default;
        }

    }
}
