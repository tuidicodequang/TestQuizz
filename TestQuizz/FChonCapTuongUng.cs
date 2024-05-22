using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TestQuizz;
using TestQuizz.Model;

namespace doan
{
    public partial class FChonCapTuongUng : Form
    {
        public int remainingSeconds { get; set; }
        public HocSinh hs { get; set; }


        List<string> danhSachDapAnDung = new List<string>();
        public List<CauHoi> danhSachCauHoi = new List<CauHoi>();
        private Button selectedButton;
        private List<Button> buttons = new List<Button>();

        private int m = 1;
        private int n = 11;

        int TongThoiGian = -4;
        public double diem = 0;
        private Button[] clickedButtons = new Button[2];
        List<string> namebt = new List<string>();
        bool firstClick = true;
        Timer timer = new Timer();



        //dung để tryền điểm về FLamBaiKiemTra
        public double Diem
        {
            get { return diem; }
        }

        private List<ChiTietCauTraLoi> dscautraloi = new List<ChiTietCauTraLoi>();
        public List<ChiTietCauTraLoi> dsCauTraLoi { get { return dscautraloi; } }





        public FChonCapTuongUng(List<CauHoi> cauhoiList, int ThoiGian, HocSinh hs)
        {
            InitializeComponent();
            this.danhSachCauHoi = cauhoiList;
            this.remainingSeconds = ThoiGian;
            label3.Text = hs.TenHS;
            this.hs = hs;
        }
        private void Timer_Tick(object sender, EventArgs e)
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
        private void HoanThanh()
        {
        
            timer.Stop();
            UpdateDiemSo();
            FShowDiem f = new FShowDiem(diem, TongThoiGian);
            this.Hide();
            f.ShowDialog();
            this.Close();
        } 
        private void UpdateDiemSo()
        {
            int d = int.Parse(lbDung.Text);
            double s = double.Parse(lbSai.Text);
            diem = (double)(d) - (s * 0.5);
            if (diem <= 0) diem = 0;
            labelDiemTong.Text = diem.ToString();

        }
        private void AttachClickEventToButtons()
        {
            for (int i = 1; i <= 20; i++)
            {
                string buttonName = "button" + i.ToString();
                Button button = Controls.Find(buttonName, true)[0] as Button;
                if (button != null)
                {
                    button.Click += Button_Click;
                    buttons.Add(button);
                }
            }
        }
        private void LoadCauhoivadapandung()
        {
            List<int> questionIndices = new List<int>();
            List<int> answerIndices = new List<int>();

           
            for (int i = 0; i < 10; i++)
            {
                questionIndices.Add(i);
                answerIndices.Add(i);
            }

            //Trộn câu 
            Shuffle(questionIndices);
            Shuffle(answerIndices);
            Random random = new Random();

            // Tạo một số ngẫu nhiên để xác định liệu chúng ta sẽ đổi giá trị hay không
            bool swap = random.Next(2) == 0;

            if (swap)
            {
                // Nếu swap = true, đổi giá trị của m và n cho nhau
                int temp = m;
                m = n;
                n = temp;
            }
            // Load Câu hỏi
            for (int i = 0; i < 10; i++)
            {
                int questionIndex = questionIndices[i];
                string buttonName = "button" + (i + m).ToString();
                Button button = Controls.Find(buttonName, true).FirstOrDefault() as Button;

                if (button != null && questionIndex < danhSachCauHoi.Count)
                {
                    button.Text = danhSachCauHoi[questionIndex].NoiDung;
                }
            }

            // Load Dấp án
            for (int i = 0; i < 10; i++)
            {
                int answerIndex = answerIndices[i];
                string buttonName = "button" + (i + n).ToString();
                Button button = Controls.Find(buttonName, true).FirstOrDefault() as Button;

                if (button != null && answerIndex < danhSachCauHoi.Count)
                {
                    button.Text = danhSachCauHoi[answerIndex].DapAnDung;
                }
            }
        }

        // hàm trộn câu hỏi
        private void Shuffle(List<int> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                for (int i = 0; i < clickedButtons.Length; i++)
                {
                    if (clickedButtons[i] == null)
                    {
                        clickedButtons[i] = clickedButton;
                        break;
                    }
                }
                clickedButton.BackColor = Color.LightGreen;
                if (clickedButton == selectedButton)
                {
                    // Nếu nút được bấm lại là nút đang được chọn, đặt trạng thái của nút này về bình thường
                    selectedButton.FlatStyle = FlatStyle.Flat;
                    selectedButton = null;
                    clickedButton.BackColor = Color.LightSteelBlue;
                    firstClick = true;

                }
                else
                {
                    // Nếu nút được bấm lại không phải là nút đang được chọn, thay đổi trạng thái của các nút
                    ToggleButtonStyle(clickedButton);

                    // Kiểm tra và xử lý nếu selectedButton khác null
                    if (selectedButton != null)
                    {

                       
                        string selectedButtonText = selectedButton.Text;

                        // Biến để kiểm soát việc tìm kiếm
                        bool found = false;

                        // Tìm kiếm nội dung của selectedButton trong danhSachCauHoi
                        foreach (CauHoi cau in danhSachCauHoi)
                        {
                            if (cau.NoiDung == selectedButtonText)
                            {
                                // Nếu tìm thấy, lưu đáp án đúng vào danh sách và đặt found thành true
                                danhSachDapAnDung.Add(cau.DapAnDung);
                                found = true;
                              
                                break; // Thoát khỏi vòng lặp khi đã tìm thấy
                            }
                        }

                        // Nếu không cần tiếp tục tìm kiếm do đã tìm thấy nội dung câu hỏi
                        if (!found)
                        {
                         
                            // Tìm các câu hỏi có đáp án giống và thêm vào danh sách
                            foreach (CauHoi cau in danhSachCauHoi)
                            {
                                if (cau.DapAnDung == selectedButtonText)
                                {
                                    danhSachDapAnDung.Add(cau.NoiDung);
                                }
                            }
                        }
                        if (firstClick)
                        {
                            firstClick = false; // Đánh dấu là đã nhấp lần đầu
                        }
                        else
                        {
                            // Đã nhấp lần thứ hai
                            if (danhSachDapAnDung.Contains(selectedButtonText))
                            {
                                // Xoá các phần tử ở đầu danh sách namebt nếu nó có hơn 2 phần tử
                                while (namebt.Count > 2)
                                {
                                    namebt.RemoveAt(0);
                                }

                                // Ẩn các nút có tên trong danh sách namebt
                                foreach (string name in namebt)
                                {
                                    Button button = Controls.Find(name, true).FirstOrDefault() as Button;
                                    if (button != null)
                                    {
                                        button.Visible = false;
                                    }
                                }
                                dscautraloi.Add(new ChiTietCauTraLoi(clickedButtons[0].Text.ToString(), clickedButtons[1].Text.ToString(), 1)); 
                                Array.Clear(clickedButtons, 0, clickedButtons.Length);
                                int d = int.Parse(lbDung.Text) + 1;
                                lbDung.Text = d.ToString();
                                danhSachDapAnDung.Clear();
                                namebt.Clear();
                                if (d == 10) HoanThanh();

                            }
                            else
                            {
                                foreach (Button button in clickedButtons)
                                {
                                    if (button != null)
                                    {
                                        button.BackColor = Color.LightSteelBlue;
                                    }
                                }

                                // Xóa tất cả các button khỏi mảng
                                dscautraloi.Add(new ChiTietCauTraLoi(clickedButtons[0].Text.ToString(), clickedButtons[1].Text.ToString(), 0));
                                Array.Clear(clickedButtons, 0, clickedButtons.Length);
                                selectedButton = null;
                                int s = int.Parse(lbSai.Text) + 1;
                                lbSai.Text = s.ToString();
                                if (s==20) HoanThanh() ;
                                
                              


                            }

                            // Đặt lại biến firstClick để chuẩn bị cho lượt tiếp theo
                            firstClick = true;
                        }
                    }
                }
            }
        }



        private void ToggleButtonStyle(Button button)
        {
            if (selectedButton != null)
            {
                selectedButton.FlatStyle = FlatStyle.Flat;
             
            }
            selectedButton = button;
            selectedButton.FlatStyle = FlatStyle.Flat;
            namebt.Add(button.Name);
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            panelGT.Visible = false;
            timer.Interval = 1500;
            timer.Tick += Timer_Tick;
            timer.Start();
            AttachClickEventToButtons();
            LoadCauhoivadapandung();
        }
    }
}
