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
        DBUtils db=new DBUtils();
        public HocSinh hocsinh { get; set; }
        public string mon { get; set; }
        public baikiemtraHS(string mon,HocSinh hs)
        {
            InitializeComponent();
            this.hocsinh= hs;
            this.mon= mon;
            LoadBangBaiKiemTraHSChuaLam(mon,hocsinh);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        public void LoadBangBaiKiemTraHSChuaLam(string mon,HocSinh hocsinh)
        {
            tableLayoutPanel1.Controls.Clear();
            DataTable baiktChuaLam = db.getBaiKiemTraHSChuaLam(mon,hocsinh);
            foreach (DataRow row in baiktChuaLam.Rows)
            {
                string MaBaiKT= row["MaBaiKT"].ToString();
                string TenBaiKT= row["TenBaiKT"].ToString();
                DateTime ThoiGianBatDau = (DateTime)row["ThoiGianBatDau"];
                DateTime ThoiGianKetThuc = (DateTime)row["ThoiGianKetThuc"];
                int ThoiGianMax = (int)row["ThoiGianMax"];
                string TenLop= row["TenLop"].ToString();
                string MaBoCH=row["TenBaiKT"].ToString();
                string Mon= row["Mon"].ToString();

                BaiKiemTra baiKiemTra = new BaiKiemTra(MaBaiKT, TenBaiKT, ThoiGianBatDau, ThoiGianKetThuc, ThoiGianMax, TenLop, MaBoCH, Mon);


                tableLayoutPanel1.Controls.Add(new ItemBaiKiemTra(baiKiemTra,hocsinh));
            }    
                
        }

        private void baikiemtraHS_Load(object sender, EventArgs e)
        {
            
        }
    }
}
