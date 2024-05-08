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

namespace TestQuizz
{
    public partial class FLamBaiKiemTra : Form
    {
        double diem = 0;
        DBUtils db=new DBUtils();
        public List<CauHoi> danhSachCauhoi = new List<CauHoi>();
        public List<string> danhSachMiniGame= new List<string>();
        private int minigameIndex = 0;

        BaiKiemTra baikiemtra { get;set;}
        HocSinh hocsinh { get;set;}

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
            DataTable minigames = db.getMiniTrongBaiKiemTra(baikiemtra.MaBaiKT);
            dataGridView1.DataSource = minigames;
            for (int i = 0; i < minigames.Rows.Count; i++)
            {

                string minigame= minigames.Rows[i]["TenMiniGame"].ToString();
                danhSachMiniGame.Add(minigame);
            }

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
        private void buttonLam_Click(object sender, EventArgs e)
        {
            buttonLamAction_Click(sender, e);
            diem = (diem*1.0) / (danhSachMiniGame.Count*1.0);
            //MessageBox.Show("Điểm:"+diem.ToString());

            try
            {
                db.InsertBaiLam(MaBL, (float)diem, 0, baikiemtra.MaBaiKT, hocsinh.MaHS);
                buttonLam.Text = diem.ToString();
                buttonLam.Enabled = false;
                
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                MessageBox.Show("Lỗi khi chèn dữ liệu: " + ex.Message);
            }
        }
        private void buttonLamAction_Click(object sender, EventArgs e)
        {
            if (minigameIndex < danhSachMiniGame.Count)
            {
                string MiniGame = danhSachMiniGame[minigameIndex];
                minigameIndex++;

                
                this.Hide();
                FLoading f = new FLoading(MiniGame, danhSachCauhoi,MaBL);
                f.FormClosed += (s, args) =>
                {
                    if (s is FLoading form3)
                    {
                       
                        switch (MiniGame)
                        {
                            case "game1":
                                diem += f.f1.Diem;
                                break;
                            case "game2":
                                diem += f.f2.Diem;
                                break;
                            case "game3":
                                diem += f.f3.Diem;
                                break;
                            case "game4":
                                diem += f.f4.Diem;
                                break;
                            case "game5":
                                diem += f.f5.Diem;
                                break;

                        }



                        //danhSachCauhoi = danhSachCauhoi.Skip(10).ToList();
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

    }
}
