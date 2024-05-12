using doan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestQuizz.Model;
using Bunifu.UI.WinForms;

namespace TestQuizz
{
    public partial class FLamBaiKiemTra : Form
    {
        double diem = 0;
        DBUtils db=new DBUtils();
        public List<CauHoi> danhSachCauhoi = new List<CauHoi>();
        public List<string> danhSachMiniGame= new List<string>();
        private int minigameIndex = 0;
     
        private BunifuImageButton[] buttons; // Thay đổi loại dữ liệu của buttons
        private int currentButtonIndex = 0;

        BaiKiemTra baikiemtra { get;set;}
        HocSinh hocsinh { get;set;}
        BaiLam bailam { get;set;}

        List<ChiTietCauTraLoi> dsCauTraLoi = new List<ChiTietCauTraLoi>();

        string MaBL;
        public FLamBaiKiemTra(BaiKiemTra baikiemtra,HocSinh hocsinh)
        {
            InitializeComponent();
            this.baikiemtra = baikiemtra;
            this.hocsinh=hocsinh;




            MaBL = TaoMaBLRandom();
            DataTable cauhois = db.getCauHoiTrongBaiKiemTra(baikiemtra.MaBaiKT);
            for (int i = 0; i < cauhois.Rows.Count; i++)
            {

                CauHoi cauhoi = new CauHoi();
                cauhoi.ID = cauhois.Rows[i]["ID"].ToString();
                cauhoi.NoiDung = cauhois.Rows[i]["NoiDung"].ToString();
                cauhoi.DapAnDung = cauhois.Rows[i]["DapAnDung"].ToString();
                cauhoi.DapAn1 = cauhois.Rows[i]["Dapan1"].ToString();
                cauhoi.DapAn2 = cauhois.Rows[i]["Dapan2"].ToString();
                cauhoi.DapAn3 = cauhois.Rows[i]["Dapan3"].ToString();

                danhSachCauhoi.Add(cauhoi);
            }

            Shuffle(danhSachCauhoi);


            DataTable minigames = db.getMiniTrongBaiKiemTra(baikiemtra.MaBaiKT);
            buttons = new BunifuImageButton[minigames.Rows.Count];

            for (int i = 0; i < minigames.Rows.Count; i++)
            {
                string miniGameName = minigames.Rows[i]["TenMiniGame"].ToString();
                buttons[i] = CreateMiniGameButton(miniGameName, i);
                panelAnhgame.Controls.Add(buttons[i]);
                danhSachMiniGame.Add(miniGameName);
            }

            ShowCurrentButton();


        }
        private void ShowCurrentButton()
        {
            foreach (BunifuImageButton button in buttons)
            {
                button.Visible = false; // Ẩn tất cả các button trước khi hiển thị button hiện tại
            }

            if (currentButtonIndex >= 0 && currentButtonIndex < buttons.Length)
            {
                buttons[currentButtonIndex].Visible = true; // Hiển thị button hiện tại
            }
        }

        private BunifuImageButton CreateMiniGameButton(string miniGameName, int index)
        {
            BunifuImageButton button = new BunifuImageButton();
            string TenGame = " ";

            button.Dock = DockStyle.Fill;
            button.Zoom = 10;
           
            if (miniGameName == "game1")
            {
                button.Image = Properties.Resources.loadingVCNV;
                TenGame = "Vượt chướng ngại vật";
            }
            if (miniGameName == "game2")
            {
                button.Image = Properties.Resources.Picture8;
                TenGame = "Thủ Môn tài ba";
            }
            if (miniGameName == "game3")
            {
                button.Image = Properties.Resources.LoadDapDe;
                TenGame = "Đập dế ";
            }
            if (miniGameName == "game4")
            {
                button.Image = Properties.Resources.backgroudaicapload;
                TenGame = "Truy Tìm Kho Báu ";
            }
            if (miniGameName == "game5")
            {
                button.Image = Properties.Resources.LoadCapTuTuongUng;
                TenGame = "Cặp Từ Tương Ứng";

            }
            button.Click += (sender, e) =>
            {
                MessageBox.Show(TenGame);
            };
            return button;
        }


        //Hàm trộn danh sách câu hỏi
        private void Shuffle(List<CauHoi> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                CauHoi value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public FLamBaiKiemTra(BaiKiemTra baikiemtra, BaiLam bailam,HocSinh hocsinh)
        {
            InitializeComponent();
            this.baikiemtra = baikiemtra;
            this.hocsinh = hocsinh;
            this.bailam=bailam;
            panel1.Visible=true;
            buttonLam.Visible = false;
            buttonLam.Enabled = false;

            this.bailam = bailam;
            lbDiem.Text=bailam.Diem.ToString();
            lbThoiGian.Text=bailam.Thoigian.ToString();

            

        }


        private string TaoMaBLRandom()
        {
           
            const string chars = "0123456789";
            Random random = new Random();
            char[] randomArray = new char[4];

            for (int i = 0; i < 4; i++)
            {
                randomArray[i] = chars[random.Next(chars.Length)];
            }
            string MaBaiLam = "BL" + new string(randomArray);
            return MaBaiLam;
        }

        private void buttonLamAction_Click(object sender, EventArgs e)
        {
            if (minigameIndex < danhSachMiniGame.Count)
            {
                string MiniGame = danhSachMiniGame[minigameIndex];
                minigameIndex++;

                List<CauHoi> dsCauHoi = danhSachCauhoi.Take(10).ToList();
                danhSachCauhoi.RemoveRange(0, 10);

                this.Hide();
                FLoading f = new FLoading(MiniGame, dsCauHoi,baikiemtra.ThoiGianMax,hocsinh);
                f.ThoiGian = baikiemtra.ThoiGianMax;
                
                f.FormClosed += (s, args) =>
                {
                    if (s is FLoading form3)
                    {
                        switch (MiniGame)
                        {
                            case "game1":
                                diem += f.f1.Diem;
                                foreach (var cautraloi in f.f1.dsCauTraLoi)
                                {
                                    dsCauTraLoi.Add(cautraloi);
                                }
                                baikiemtra.ThoiGianMax -= f.f1.remainingSeconds;

                                break;
                            case "game2":
                                diem += f.f2.Diem;
                                foreach (var cautraloi in f.f2.dsCauTraLoi)
                                {
                                    dsCauTraLoi.Add(cautraloi);
                                }
                                baikiemtra.ThoiGianMax -= f.f2.remainingSeconds;

                                break;
                            case "game3":
                                diem += f.f3.Diem;
                                foreach (var cautraloi in f.f3.dsCauTraLoi)
                                {
                                    dsCauTraLoi.Add(cautraloi);
                                }
                                baikiemtra.ThoiGianMax -= f.f3.remainingSeconds;
                                break;
                            case "game4":
                                diem += f.f4.Diem;
                                foreach (var cautraloi in f.f4.dsCauTraLoi)
                                {
                                    dsCauTraLoi.Add(cautraloi);
                                }
                                baikiemtra.ThoiGianMax -= f.f4.remainingSeconds;


                                break;
                            case "game5":
                                diem += f.f5.Diem;
                                // Chưa thêm được chi tiết bài làm FChonDapAnTuongDuong
                                foreach (var cautraloi in f.f5.dsCauTraLoi)
                                {
                                    dsCauTraLoi.Add(cautraloi);
                                }
                                baikiemtra.ThoiGianMax -= f.f5.remainingSeconds;
                                break;

                        }
                        MessageBox.Show("Kết thúc làm " + MiniGame);
                    }
                    if (minigameIndex >= danhSachMiniGame.Count)
                    {
                        this.Show();

                    }
                    else
                        buttonLamAction_Click(sender, e);
                };
                f.ShowDialog();
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            FChiTietBaiLam f = new FChiTietBaiLam(bailam);
            f.ShowDialog();
        }

        private void FLamBaiKiemTra_Load(object sender, EventArgs e)
        {
            lbTenBaiKiemTra.Text = baikiemtra.TenBaiKT.ToString();
            lbThoiGianBatDau.Text = "Thời Gian Bắt Đầu: "+baikiemtra.ThoiGianBatDau.ToString();
            lbThoiGianKetThuc.Text = "Thời Gian Kết Thúc: "+baikiemtra.ThoiGianKetThuc.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentButtonIndex++;
            if (currentButtonIndex >= buttons.Length)
            {
                currentButtonIndex = 0;
            }
            ShowCurrentButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentButtonIndex++;
            if (currentButtonIndex >= buttons.Length)
            {
                currentButtonIndex = 0;
            }
            ShowCurrentButton();
        }

    

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLam_Click(object sender, EventArgs e)
        {
            buttonLamAction_Click(sender, e);
            diem = (diem * 1.0) / (danhSachMiniGame.Count * 1.0);
            bailam = new BaiLam();
            try
            {
                bailam.MaBL = MaBL;
                bailam.Diem = diem;
                bailam.Thoigian = baikiemtra.ThoiGianMax;
                bailam.MaBaiKT = baikiemtra.MaBaiKT;
                bailam.MaHS = hocsinh.MaHS;

                db.InsertBaiLam(bailam);

                //Them chi tiet bai lam
                foreach (var cautraloi in dsCauTraLoi)
                {
                    db.InsertChiTietBaiLam(MaBL, cautraloi.CauHoi, cautraloi.CauTraLoi, cautraloi.TrangThai);
                }



                buttonLam.Visible = false;
                buttonLam.Enabled = false;
                panel3.Visible = false;
                panel1.Visible = true;

                lbThoiGian.Text = bailam.Thoigian.ToString();
                lbDiem.Text = bailam.Diem.ToString();


            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                MessageBox.Show("Lỗi khi chèn dữ liệu: " + ex.Message);
            }
        }
    }
}
