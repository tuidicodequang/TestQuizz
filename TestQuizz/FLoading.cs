using doan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestQuizz.Model;

namespace TestQuizz
{
    public partial class FLoading : Form
    {
       // public int remainingSeconds { get; set; }
        public List<CauHoi> danhSachCauHoi { get; set; }
        public FVuotChuongNgaiVat f1 { get; set; }
        public FBatBong f2 { get; set; }
        public Fdapde f3 { get; set; }
        public FTruyTimKhoBau f4 { get; set; }
        public FChonCapTuongUng f5 { get; set; }
        public string Path { get; set; }
        public string maBL { get; set; }

        public int ThoiGian { get; set; }

        public HocSinh hs { get; set; }



        public FLoading(string path, List<CauHoi> cauHoiList, int ThoiGian, HocSinh hs)
        {
            InitializeComponent();
            Path = path;
            danhSachCauHoi = cauHoiList;
            this.ThoiGian = ThoiGian;
            this.hs = hs;


            timer1.Interval = 4000;
            timer1.Start();
            ChonTroChoi(path);

        }
        void ChonTroChoi(string ganme)
        {
            if (ganme == "game1")
            {
                this.BackgroundImage = Properties.Resources.loadingVCNV;
                if (f1 == null)
                {
                    f1 = new FVuotChuongNgaiVat(danhSachCauHoi, ThoiGian, hs);
                }
            }
            if (ganme == "game2")
            {
                this.BackgroundImage = Properties.Resources.Picture8;
                if (f2 == null)
                    f2 = new FBatBong(danhSachCauHoi, ThoiGian, hs);
            }
            if (ganme == "game3")
            {
                this.BackgroundImage = Properties.Resources.LoadDapDe;
                if (f3 == null)
                    f3 = new Fdapde(danhSachCauHoi, ThoiGian, hs);
            }
            if (ganme == "game4")
            {
                this.BackgroundImage = Properties.Resources.backgroudaicapload;
                if (f4 == null)
                    f4 = new FTruyTimKhoBau(danhSachCauHoi, ThoiGian, hs);
            }
            if (ganme == "game5")
            {
                this.BackgroundImage = Properties.Resources.LoadCapTuTuongUng;
                if (f5 == null)
                    f5 = new FChonCapTuongUng(danhSachCauHoi, ThoiGian, hs);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            if (f1 != null && f1.IsDisposed == false)
                f1.ShowDialog();
            if (f2 != null && f2.IsDisposed == false)
                f2.ShowDialog();
            if (f3 != null && f3.IsDisposed == false)
                f3.ShowDialog();
            if (f4 != null && f4.IsDisposed == false)
                f4.ShowDialog();
            if (f5 != null && f5.IsDisposed == false)
                f5.ShowDialog();
            this.Close();


        }

       
    }
    }

