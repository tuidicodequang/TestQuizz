﻿using AxWMPLib;
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
    public partial class Fdapde : Form
    {
        private int currentIndex = 0; // Chỉ số của câu hỏi hiện tại
        List<CauHoi> danhSachCauHoi = new List<CauHoi>();
        public int remainingSeconds = 14;
        int TongThoiGian= -4;

        CursorsCustom h = new CursorsCustom();
     
        Timer timer = new Timer();
        Timer timer2 = new Timer(); 
        Timer timer3 = new Timer();
        Timer timer4 = new Timer();
        int diem = 0;


        public Fdapde()
        {
            InitializeComponent();
            CenterToScreen();
            UpdatelabelDiem();
            timer.Interval = 1500;
            timer.Tick += Timer_Tick;
            timer2.Interval = 1000;
            timer2.Tick += timer2_Tick;
            timer3.Interval = 2000;
            timer3.Tick += Timer3_Tick;
            timer4.Interval = 2000; // Thời gian ẩn ảnh conde và hiện lại các panel sau 2 giây
            timer4.Tick += Timer4_Tick;

            AddBoCauHoi();
            UpdateQuestion();
            timer2.Start();
        }
        public void HoanThanh()
        {
            textBox1.Visible = false;
            panel6.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel7.Visible = true;
            timer2.Stop();
            labelTimeHT.Text= TimeSpan.FromSeconds(TongThoiGian).ToString(@"mm\:ss");
            labelDiemTong.Text = diem.ToString();
        }
        private void CheckDapAn(System.Windows.Forms.Button bt, PictureBox thispic)
        {
            CauHoi currentQuestion = danhSachCauHoi[currentIndex];
            string dapan = currentQuestion.DapAnDung;
            bt.Visible = false;
            timer.Tag = thispic;

            if (bt.Text == dapan)
            {
                thispic.Image = Properties.Resources.dungdapde;
                diem++;
                UpdatelabelDiem();
            }
            else
            {
                thispic.Image = Properties.Resources.sairoidapde;
            }

            timer.Start();
        }

        private void UpdatelabelDiem()
        {
            label2.Text = diem + "/10";
        }

        private void UpdateQuestion()
        {
            if (currentIndex >= 0 && currentIndex < danhSachCauHoi.Count)
            {
                ResetButtonState();
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
                label5.Text = currentIndex < 10 ? "0" + (currentIndex + 1).ToString() : (currentIndex + 1).ToString();
            }
            else
            {
                HoanThanh();
            }
        }
        private void Timer4_Tick(object sender, EventArgs e)
        {
          
            panel2.Visible = false; 
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            timer4.Stop(); // Dừng timer sau khi thực hiện xong
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel2.Visible = true;
            timer3.Stop();
            timer2.Start(); // Bắt đầu đếm thời gian cho câu hỏi mới
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           PictureBox pictureBox = (PictureBox)timer.Tag;
            // Ẩn pictureBox
            pictureBox.Image = Properties.Resources.conde;

            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            UpdateQuestion();
            timer.Stop(); // Dừng đếm thời gian
            timer4.Start();
        
        }

        private void timer2_Tick(object sender, EventArgs e)
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


        private void button1_Click(object sender, EventArgs e)
        {
            CheckDapAn(button1, pictureBBut1);
            currentIndex++; // Tăng chỉ số của câu hỏi lên một


        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckDapAn(button2,pictureBBut2);
            currentIndex++; // Tăng chỉ số của câu hỏi lên một



        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckDapAn(button3,pictureBBut3);
        
            currentIndex++; // Tăng chỉ số của câu hỏi lên một

        }

        private void button4_Click(object sender, EventArgs e)
        {


            CheckDapAn(button4,pictureBBut4);
            currentIndex++; // Tăng chỉ số của câu hỏi lên một
        }
        private void ResetButtonState()
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
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
          

        }

      

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
          h.ChangeCursors(h.bua);
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            h.ChangeCursors(h.bua);
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            h.ChangeCursors(h.bua);
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            h.ChangeCursors(h.bua);
        }

        
    }
}
