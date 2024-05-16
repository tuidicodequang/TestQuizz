﻿using System;
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
    public partial class ItemBaiKiemTra : UserControl
    {

        DBUtils db = new DBUtils();
        public BaiKiemTra BaiKiemTra { get; set; }
        public HocSinh HocSinh { get; set; }
       
        public ItemBaiKiemTra(BaiKiemTra baiKiemTra,HocSinh hocsinh)
        {
            InitializeComponent();
            this.BaiKiemTra = baiKiemTra;
            this.HocSinh=hocsinh;
        }

        private void ItemBaiKiemTra_Load(object sender, EventArgs e)
        {
            lbTenBaiKT.Text = BaiKiemTra.TenBaiKT.ToString();
            lbThoiGianBatDau.Text = BaiKiemTra.ThoiGianBatDau.ToString("dd/MM/yyyy HH:mm");
            lbThoiGianKetThuc.Text = BaiKiemTra.ThoiGianKetThuc.ToString("dd/MM/yyyy HH:mm");

        }
        public void ChuyenButton(int TrangThai)
        {
            if (TrangThai == 0) { BTbatDau.BringToFront(); }
            if (TrangThai == 1) { btnXemChiTiet.BringToFront(); }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn bắt đầu làm bài không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                FLamBaiKiemTra f=new FLamBaiKiemTra(BaiKiemTra,HocSinh);
                f.ShowDialog();
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            DataTable BL = db.getBaiLamHSTheoBaiKiemTra(HocSinh, BaiKiemTra);

            BaiLam BaiLam = new BaiLam();
            BaiLam.MaBL = BL.Rows[0]["MaBL"].ToString();
            BaiLam.Diem = (double)BL.Rows[0]["Diem"];
            BaiLam.Thoigian = (int)BL.Rows[0]["ThoiGian"];
            BaiLam.MaBaiKT = BL.Rows[0]["MaBaiKT"].ToString();
            BaiLam.MaHS = BL.Rows[0]["MaHS"].ToString();
            FLamBaiKiemTra f = new FLamBaiKiemTra(BaiKiemTra, BaiLam, HocSinh);
          
            f.ShowDialog();
        }
    }
}
