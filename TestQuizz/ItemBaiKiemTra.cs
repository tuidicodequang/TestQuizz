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
    public partial class ItemBaiKiemTra : UserControl
    {
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
            lbThoiGianBatDau.Text = BaiKiemTra.ThoiGianBatDau.ToString();
            lbThoiGianKetThuc.Text=BaiKiemTra.ThoiGianKetThuc.ToString();

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

    }
}
