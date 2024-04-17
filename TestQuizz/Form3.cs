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

namespace TestQuizz
{
    public partial class Form3 : Form
    {
     
        FVuotChuongNgaiVat f1;
        FBatBong f2;
        Fdapde f3;
        FTruyTimKhoBau f4;
        FChonCapTuongUng f5;
        public string Path{ get; set; }
       
        public Form3(string path)
        {
            InitializeComponent();
           Path = path;
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
                    f1 = new FVuotChuongNgaiVat();
            }
             if (ganme == "game2")
            {
                this.BackgroundImage = Properties.Resources.Picture8;
                if (f2 == null)
                    f2 = new FBatBong();
            }
            if (ganme == "game3")
            {
                this.BackgroundImage = Properties.Resources.LoadDapDe;
                if (f3 == null)
                    f3 = new Fdapde();
            }
            if (ganme == "game4")
            {
                this.BackgroundImage = Properties.Resources.backgroudaicapload;
                if (f4 == null)
                   f4= new FTruyTimKhoBau();
            }
            if (ganme == "game5")
            {
                this.BackgroundImage = Properties.Resources.ditimkhobau;
                if (f5 == null)
                    f5 = new FChonCapTuongUng();
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

