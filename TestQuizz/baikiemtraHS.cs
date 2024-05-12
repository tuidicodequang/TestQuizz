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
    public partial class baikiemtraHS : Form
    {
        DBUtils db = new DBUtils();
        public HocSinh hocsinh { get; set; }
        public string mon { get; set; }
        public baikiemtraHS(string mon, HocSinh hs)
        {
            InitializeComponent();
            this.hocsinh = hs;
            this.mon = mon;
            LoadBangBaiKiemTraHSChuaLam(mon, hocsinh);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        public void LoadBangBaiKiemTraHSChuaLam(string mon, HocSinh hocsinh)
        {
            tableLayoutPanel1.Controls.Clear();
            DataTable baiktChuaLam = db.getBaiKiemTraHSChuaLam(mon, hocsinh);
            foreach (DataRow row in baiktChuaLam.Rows)
            {
                string MaBaiKT = row["MaBaiKT"].ToString();
                string TenBaiKT = row["TenBaiKT"].ToString();
                DateTime ThoiGianBatDau = (DateTime)row["ThoiGianBatDau"];
                DateTime ThoiGianKetThuc = (DateTime)row["ThoiGianKetThuc"];
                int ThoiGianMax = (int)row["ThoiGianMax"];
                string TenLop = row["TenLop"].ToString();
                string MaBoCH = row["TenBaiKT"].ToString();
                string Mon = row["Mon"].ToString();

                BaiKiemTra baiKiemTra = new BaiKiemTra(MaBaiKT, TenBaiKT, ThoiGianBatDau, ThoiGianKetThuc, ThoiGianMax, TenLop, MaBoCH, Mon);
                tableLayoutPanel1.Controls.Add(new ItemBaiKiemTra(baiKiemTra, hocsinh));
            }

        }

        private void baikiemtraHS_Load(object sender, EventArgs e)
        {

        }
        public void LoadBangBaiKiemTraHSDaLam(string mon, HocSinh hocsinh)
        {
            tableLayoutPanel1.Controls.Clear();
            DataTable baiktChuaLam = db.getBaiKiemTraHSDaLam(mon, hocsinh);
            foreach (DataRow row in baiktChuaLam.Rows)
            {
                string MaBaiKT = row["MaBaiKT"].ToString();
                string TenBaiKT = row["TenBaiKT"].ToString();
                DateTime ThoiGianBatDau = (DateTime)row["ThoiGianBatDau"];
                DateTime ThoiGianKetThuc = (DateTime)row["ThoiGianKetThuc"];
                int ThoiGianMax = (int)row["ThoiGianMax"];
                string TenLop = row["TenLop"].ToString();
                string MaBoCH = row["TenBaiKT"].ToString();
                string Mon = row["Mon"].ToString();

                BaiKiemTra baiKiemTra = new BaiKiemTra(MaBaiKT, TenBaiKT, ThoiGianBatDau, ThoiGianKetThuc, ThoiGianMax, TenLop, MaBoCH, Mon);
                ItemBaiKiemTra itemBaikiemTra = new ItemBaiKiemTra(baiKiemTra, hocsinh);
                itemBaikiemTra.ChuyenButton(1);
                tableLayoutPanel1.Controls.Add(itemBaikiemTra);
            }
        }

        private void BttDalam_Click(object sender, EventArgs e)
        {
            LoadBangBaiKiemTraHSDaLam(mon, hocsinh);
            buttonTimDalam.BringToFront();
           
            BttDalam.IdleFillColor = Color.DodgerBlue;
            BttDalam.ForeColor = Color.White;
            BttChuaLam.IdleFillColor = Color.White;
            BttChuaLam.ForeColor = Color.DodgerBlue;
        }

        private void BttChuaLam_Click(object sender, EventArgs e)
        {
            LoadBangBaiKiemTraHSChuaLam(mon, hocsinh);
            bttTimChualam.BringToFront();
            BttChuaLam.IdleFillColor = Color.DodgerBlue;
            BttChuaLam.ForeColor = Color.White;
            BttDalam.IdleFillColor = Color.White;
            BttDalam.ForeColor = Color.DodgerBlue;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fhocsinh f = new Fhocsinh();
            f.hocsinh = hocsinh;
            this.Hide();
            f.ShowDialog();
            this.Close();

        }

        private void buttonTimChlam_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            DataTable TimKiem = db.TimKiemBaiDaLam(textBox1.Text, dateTimePicker1.Value, hocsinh, mon);
            foreach (DataRow row in TimKiem.Rows)
            {
                string MaBaiKT = row["MaBaiKT"].ToString();
                string TenBaiKT = row["TenBaiKT"].ToString();
                DateTime ThoiGianBatDau = (DateTime)row["ThoiGianBatDau"];
                DateTime ThoiGianKetThuc = (DateTime)row["ThoiGianKetThuc"];
                int ThoiGianMax = (int)row["ThoiGianMax"];
                string TenLop = row["TenLop"].ToString();
                string MaBoCH = row["TenBaiKT"].ToString();
                string Mon = row["Mon"].ToString();

                BaiKiemTra baiKiemTra = new BaiKiemTra(MaBaiKT, TenBaiKT, ThoiGianBatDau, ThoiGianKetThuc, ThoiGianMax, TenLop, MaBoCH, Mon);
                ItemBaiKiemTra itemBaikiemTra = new ItemBaiKiemTra(baiKiemTra, hocsinh);
                itemBaikiemTra.ChuyenButton(1);
                tableLayoutPanel1.Controls.Add(itemBaikiemTra);
            }


        }

        private void bttTimChuaLam_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            DataTable TimKiem = db.TimKiemBaiChuaLam(textBox1.Text, dateTimePicker1.Value, hocsinh, mon);
            foreach (DataRow row in TimKiem.Rows)
            {
                string MaBaiKT = row["MaBaiKT"].ToString();
                string TenBaiKT = row["TenBaiKT"].ToString();
                DateTime ThoiGianBatDau = (DateTime)row["ThoiGianBatDau"];
                DateTime ThoiGianKetThuc = (DateTime)row["ThoiGianKetThuc"];
                int ThoiGianMax = (int)row["ThoiGianMax"];
                string TenLop = row["TenLop"].ToString();
                string MaBoCH = row["TenBaiKT"].ToString();
                string Mon = row["Mon"].ToString();

                BaiKiemTra baiKiemTra = new BaiKiemTra(MaBaiKT, TenBaiKT, ThoiGianBatDau, ThoiGianKetThuc, ThoiGianMax, TenLop, MaBoCH, Mon);
                tableLayoutPanel1.Controls.Add(new ItemBaiKiemTra(baiKiemTra, hocsinh));
            }
        }
    }
}
