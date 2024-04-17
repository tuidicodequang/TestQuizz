using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace TestQuizz
{
    public partial class FVuotChuongNgaiVat : Form
    {
        private int remainingSeconds = 60;
        private int TongThoiGian= 0;
        private int currentIndex = 0; // Chỉ số của câu hỏi hiện tại
        List<CauHoi> danhSachCauHoi = new List<CauHoi>();
        private string videoPath = "C:\\Users\\manno\\OneDrive\\Desktop\\hoc c#\\TestQuizz\\TestQuizz\\Resources\\xechayvuotchuongngaivat.mp4";
        private int[] timePoints = { 4, 8, 14, 19, 24,29,35,40,44, 50 }; // Các thời điểm để pasue video nè
        private int currentTimePointIndex = -1;
        private Timer timer;
        private Timer timer1;
        private Timer timer2;
        private Timer timerLoad;
       
        int diem = 0;
  
        public FVuotChuongNgaiVat()
        {
            InitializeComponent();
          
            CenterToScreen();
            InitializeMediaPlayer();
            InitializeTimer();
            AddBoCauHoi();
            UpdateQuestion();

        }
       
        public void HoanThanh()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            
                timer2.Stop();
                panel3.BringToFront();
                labeltimeHT.Text = TimeSpan.FromSeconds(TongThoiGian).ToString(@"mm\:ss");
                labelDiemTong.Text = diem.ToString();
                 axWindowsMediaPlayer2.Ctlcontrols.stop();
                axWindowsMediaPlayer2.Visible = false;
            

        }
        private void CheckDapAn(string bt)
        {
            CauHoi currentQuestion = danhSachCauHoi[currentIndex];

            string dapan = currentQuestion.DapAnDung;
            if (bt == dapan)
            {
                diem++;
                labelDiem.Text = diem.ToString();
                pictureBoxDungSai.Image = Properties.Resources.raising_hands_thumbs_up; // Hiển thị ảnh 2 nếu đáp án sai
                pictureBoxDungSai.Visible = true;
            }

            else
            {

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
                labelSoCau.Text = currentIndex < 10 ? "0" + (currentIndex + 1).ToString() +"/ 10" : (currentIndex + 1).ToString()+"/ 10";
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

        public void AddBoCauHoi()
        {

            // Tạo và thêm các câu hỏi vào danh sách
            CauHoi cauHoi1 = new CauHoi(1, "1 + 1 = ?", "2", "3", "4", "5", "", 1);
            danhSachCauHoi.Add(cauHoi1);

            CauHoi cauHoi2 = new CauHoi(2, "2 + 3 = ?", "5", "6", "7", "8", "", 1);
            danhSachCauHoi.Add(cauHoi2);

            CauHoi cauHoi3 = new CauHoi(3, "4 - 2 = ?", "2", "3", "4", "5", "", 1);
            danhSachCauHoi.Add(cauHoi3);

            CauHoi cauHoi4 = new CauHoi(4, "5 - 3 = ?", "2", "3", "4", "5", "", 1);
            danhSachCauHoi.Add(cauHoi4);

            CauHoi cauHoi5 = new CauHoi(5, "3 + 4 = ?", "7", "8", "9", "10", "", 1);
            danhSachCauHoi.Add(cauHoi5);

            CauHoi cauHoi6 = new CauHoi(6, "4 + 5 = ?", "9", "10", "11", "12", "", 1);
            danhSachCauHoi.Add(cauHoi6);

            CauHoi cauHoi7 = new CauHoi(7, "2 + 6 = ?", "8", "9", "10", "11", "", 1);
            danhSachCauHoi.Add(cauHoi7);

            CauHoi cauHoi8 = new CauHoi(8, "6 - 3 = ?", "3", "4", "5", "6", "", 1);
            danhSachCauHoi.Add(cauHoi8);

            CauHoi cauHoi9 = new CauHoi(9, "8 - 4 = ?", "4", "5", "6", "7", "", 1);
            danhSachCauHoi.Add(cauHoi9);

            CauHoi cauHoi10 = new CauHoi(10, "7 + 3 = ?", "10", "11", "12", "13", "", 1);
            danhSachCauHoi.Add(cauHoi10);


            // Tạo một bộ câu hỏi mới
            BoCauHoi boCauHoi = new BoCauHoi(
                id: 1, // Mã bộ câu hỏi
                tenBo: "Bộ câu hỏi toán cấp 1", // Tên bộ câu hỏi
                lop: "Cấp 1", // Lớp học
                mon: "Toán" // Môn học
            );

            // Thêm danh sách câu hỏi vào bộ câu hỏi
            boCauHoi.DanhSachCauHoi.AddRange(danhSachCauHoi);
            //label6.Text = danhSachCauHoi.Count.ToString();

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
