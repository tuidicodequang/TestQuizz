using AxWMPLib;
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
    public partial class FTruyTimKhoBau : Form
    {
        Button currentBT = new Button();
        private int currentIndex = 0; // Chỉ số của câu hỏi hiện tại
        List<CauHoi> danhSachCauHoi = new List<CauHoi>();
        public int remainingSeconds = 14;
        int TongThoiGian = -4;
        CursorsCustom h = new CursorsCustom(); 
        int diem = 0;
        Timer timerDungSai = new Timer();
        Timer timerTinhGio = new Timer();
        Timer timerChuyenCanh= new Timer();
        public FTruyTimKhoBau()
        {
         
            InitializeComponent();
       
            AddBoCauHoi();
     
            timerDungSai.Interval = 1500;
            timerDungSai.Tick += TimerDungSai_Tick;
            timerTinhGio.Interval = 1000;
            timerTinhGio.Tick += timerTinhGio_Tick;
         
        }
        public void HoanThanh()
        {
            pictureBoxDungSai.Image = null;
            panel1.Visible = false;
            panel2.Visible = false;
            TextBox1.Visible = false;
            buttonDA1.Visible = false;
            buttonDA2.Visible = false;
            buttonDA3 .Visible = false;
            buttonDA4.Visible = false;
            timerTinhGio.Stop();
            timerChuyenCanh.Stop();
            timerDungSai.Stop();
            this.BackgroundImage = Properties.Resources.backgroundwin;
            panel3 .Visible = true;
            labelTimeHT.Text = TimeSpan.FromSeconds(TongThoiGian).ToString(@"mm\:ss");
            labelDiemTong.Text = diem.ToString();
           


        }
        public void DanhDauButton(Button bt)
        {
            buttonDA1.Enabled = true;
            buttonDA2.Enabled = true;
            buttonDA3.Enabled = true;
            buttonDA4.Enabled = true;
            currentBT = bt;
            bt.Enabled = false;
            panel2.Visible = false;
            panel2.Dock = DockStyle.None;
            panel2.Height = 10;
            UpdateQuestion();
            timerTinhGio.Start();
            TextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void timerTinhGio_Tick(object sender, EventArgs e)
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

      
        private void TimerDungSai_Tick(object sender, EventArgs e)
        {
          
            panel2.Visible = true;
            panel2.Dock = DockStyle.Fill;
            currentBT.Visible = true;
            timerChuyenCanh.Start();
            timerTinhGio.Stop();
            timerDungSai.Stop(); // Dừng timer sau khi thực hiện xong
            pictureBoxDungSai.Image = null;
          
        }
        private void CheckDapAn(string bt)
        {
            buttonDA1.Enabled = false;
            buttonDA2.Enabled = false;
            buttonDA3.Enabled = false;
            buttonDA4.Enabled = false;
            CauHoi currentQuestion = danhSachCauHoi[currentIndex];
            currentBT.Visible = false;
            string dapan = currentQuestion.DapAnDung;
            if (bt == dapan)
            {
                diem++;
                UpdatelabelDiem();
                pictureBoxDungSai.Image = Properties.Resources.dungroibeoi;
                currentBT.BackgroundImage = Properties.Resources.danhdau;
               

            }
            else
            {
                pictureBoxDungSai.Image = Properties.Resources.Sairoibeoi;
                currentBT.BackgroundImage = Properties.Resources.dauX;
               
            }
                timerDungSai.Start();
              
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
                buttonDA1.Text = answers[0];
                buttonDA2.Text = answers[1];
                buttonDA3.Text = answers[2];
                buttonDA4.Text = answers[3];
                // Cập nhật nội dung của TextBox1 là nội dung của câu hỏi hiện tại
                TextBox1.Text = currentQuestion.NoiDung;
            }
            else
            {

                HoanThanh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DanhDauButton(button2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DanhDauButton(button1);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DanhDauButton(button9);
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
          //  label6.Text = danhSachCauHoi.Count.ToString();

        }

        private void FTruyTimKhoBau_Load(object sender, EventArgs e)
        {
           
         TextBox1.SelectionAlignment = HorizontalAlignment.Center;
            
        }

        private void buttonDA1_Click(object sender, EventArgs e)
        {
            CheckDapAn(buttonDA1.Text);
            currentIndex++; // Tăng chỉ số của câu hỏi lên một
        }

        private void buttonDA2_Click(object sender, EventArgs e)
        {
            CheckDapAn(buttonDA2.Text);
            currentIndex++; // Tăng chỉ số của câu hỏi lên một
        }

        private void buttonDA3_Click(object sender, EventArgs e)
        {
            CheckDapAn(buttonDA3.Text);
            currentIndex++; // Tăng chỉ số của câu hỏi lên một
        }

        private void buttonDA4_Click(object sender, EventArgs e)
        {
            CheckDapAn(buttonDA4.Text);
            currentIndex++; // Tăng chỉ số của câu hỏi lên một
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DanhDauButton(button8);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DanhDauButton(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DanhDauButton(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DanhDauButton(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DanhDauButton(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DanhDauButton(button7);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DanhDauButton(button10);
        }
    }
}
