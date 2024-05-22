using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestQuizz.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestQuizz
{
    public partial class FBatBong : Form
    {
        public int remainingSeconds { get; set; }
        public HocSinh hs { get; set; }

       
        private int currentIndex = 0; // Chỉ số của câu hỏi hiện tại
        List<CauHoi> danhSachCauHoi = new List<CauHoi>();

        int TongThoiGian = 0;
        public string videoPath1 = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "TestQuizz", "Resources", "chup banh.mp4");
        public string videoPath2 = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "TestQuizz", "Resources", "chuphut.mp4");
        CursorsCustom h = new CursorsCustom();
        bool isVideoLoaded = false;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        int diem = 0;
        public double Diem { get { return diem; } }

        private List<ChiTietCauTraLoi> dscautraloi = new List<ChiTietCauTraLoi>();
        public List<ChiTietCauTraLoi> dsCauTraLoi { get { return dscautraloi; } }



        public FBatBong(List<CauHoi> cauhoiList, int remainingSeconds, HocSinh hs)
        {
            InitializeComponent();
            this.remainingSeconds = remainingSeconds;
            this.hs = hs;
            label1.Text = hs.TenHS;
            CenterToScreen();
            danhSachCauHoi = cauhoiList;
 
        }
        public void HoanThanh()
        {
            
            timer2.Stop();
            FShowDiem f = new FShowDiem(diem, TongThoiGian);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
 
        private string CheckDapAn(string bt)
        {
            CauHoi currentQuestion = danhSachCauHoi[currentIndex];
            string dapan = currentQuestion.DapAnDung;
            if (bt == dapan)
            {
                diem++;
                dscautraloi.Add(new ChiTietCauTraLoi(currentQuestion.NoiDung, dapan, 1));
                UpdatelabelDiem();
                return videoPath1;
            }
            else
            {
                dscautraloi.Add(new ChiTietCauTraLoi(currentQuestion.NoiDung, bt, 0));
                return videoPath2;
            }
        }
        private void UpdatelabelDiem()
        {
            label2.Text = diem + "/10";
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
                button1.Text = answers[0];
                button2.Text = answers[1];
                button3.Text = answers[2];
                button4.Text = answers[3];
                // Cập nhật nội dung của TextBox1 là nội dung của câu hỏi hiện tại
                textBox1.Text = currentQuestion.NoiDung;
            }
            else
            {
              
                HoanThanh();
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {

            axWindowsMediaPlayer1.Visible = true; // Hiển thị video sau khi đã đợi 1 giây
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            timer.Stop(); // Dừng đếm thời gian

        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            // Giảm thời gian đếm ngược mỗi lần Tick của Timer
            remainingSeconds--;
            TongThoiGian++;

            // Hiển thị thời gian đếm ngược trên Label
          labeltime.Text = TimeSpan.FromSeconds(remainingSeconds).ToString(@"mm\:ss");
          //labeltime.Text = remainingSeconds.ToString();

            // Kiểm tra nếu thời gian đếm ngược đã hết
            if (remainingSeconds == 0)
            {
               
                HoanThanh();

            }
        }

        private void InitializeMediaPlayer()
        {
            axWindowsMediaPlayer1.Visible = false;
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.stretchToFit = true;
          
            axWindowsMediaPlayer1.uiMode = "none";
           axWindowsMediaPlayer1.PlayStateChange += axWindowsMediaPlayer1_PlayStateChange;
            this.Controls.Add(axWindowsMediaPlayer1);

            
            axWindowsMediaPlayer1.settings.autoStart = false;
            axWindowsMediaPlayer1.URL = videoPath1; // Load your default video
        }
        private void PlayVideo(string path)
        {
            if (!isVideoLoaded)
            {
                axWindowsMediaPlayer1.URL = path;
                isVideoLoaded = true;
            }
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.BringToFront();
            button1.BringToFront();
            button2.BringToFront();
            button3.BringToFront();
            button4.BringToFront();
            textBox1.BringToFront();
            panel1.BringToFront();
            panel2.BringToFront();
            timer.Start();
            timer.Start(); // Bắt đầu đếm thời gian
        }

        private void button1_Click(object sender, EventArgs e)
        {
           PlayVideo( CheckDapAn(button1.Text));
          //  PlayVideo(videoPath2);
            isVideoLoaded = false;
            currentIndex++; // Tăng chỉ số của câu hỏi lên một


        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayVideo(CheckDapAn(button2.Text));
           // PlayVideo(videoPath2);
            isVideoLoaded = false;
            currentIndex++; // Tăng chỉ số của câu hỏi lên một


        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Kiểm tra nếu video đã phát xong
            if ( axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Cursor.Hide();
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                axWindowsMediaPlayer1.Visible = false; // Ẩn video khi kết thúc
                Cursor.Show();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                UpdateQuestion(); // Cập nhật câu hỏi mới
              
                label5.Text =(currentIndex + 1).ToString();
               

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlayVideo(CheckDapAn(button3.Text));
            //PlayVideo(videoPath2);
            isVideoLoaded = false;
            currentIndex++; // Tăng chỉ số của câu hỏi lên một

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PlayVideo(CheckDapAn(button4.Text));
            //PlayVideo(videoPath1);
            isVideoLoaded = false;
            currentIndex++; // Tăng chỉ số của câu hỏi lên một

        }
        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
          h.ChangeCursors(h.ball);
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            h.ChangeCursors(h.ball);
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            h.ChangeCursors(h.ball);
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            h.ChangeCursors(h.ball);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            panelGT.Visible = false;
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            panelGT.Visible=false;
            UpdatelabelDiem();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer2.Interval = 1000;
            timer2.Tick += timer2_Tick;
            InitializeMediaPlayer();
            UpdateQuestion();
            timer2.Start();
        }

       
    }
}
