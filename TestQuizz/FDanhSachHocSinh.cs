using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestQuizz
{
    public partial class FDanhSachHocSinh : Form
    {
        public string tenlop { get; set; }
        DBUtils db=new DBUtils();
        public FDanhSachHocSinh()
        {
            InitializeComponent();
        }

        private void FDanhSachHocSinh_Load(object sender, EventArgs e)
        {
            LoadDanhSachHocSinh();
            LoadDanhSachBaiKiemTraTheoLop();
        }

        public void LoadDanhSachHocSinh() 
        {
            DataTable danhsachhocsinh = db.getAllHocSinhTheoLop(tenlop);
            dgvDanhSachHocSinh.DataSource=danhsachhocsinh;
   
            // Đặt tên cho các cột trong DataGridView
            dgvDanhSachHocSinh.Columns["MaHS"].HeaderText = "Mã Học Sinh";
            dgvDanhSachHocSinh.Columns["TenHS"].HeaderText = "Tên Học Sinh";
            dgvDanhSachHocSinh.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvDanhSachHocSinh.Columns["NgaySinh"].HeaderText = "Ngày Sinh";

        }


        public void LoadDanhSachBaiKiemTraTheoLop()
        {
            DataTable dsBaiKtTheoLop= db.getAllBaiKiemTraTheoLop(tenlop);
            dgvDanhSachBaiKT.DataSource = dsBaiKtTheoLop;
            dgvDanhSachBaiKT.Columns["MaBaiKT"].HeaderText = "Mã Bài Kiểm Tra";
            dgvDanhSachBaiKT.Columns["TenBaiKT"].HeaderText = "Tên Bài Kiểm Tra";
            dgvDanhSachBaiKT.Columns["ThoiGianBatDau"].HeaderText = "Thời gian bắt đầu";
            dgvDanhSachBaiKT.Columns["ThoiGianKetThuc"].HeaderText = "Thời gian kết thúc";
            dgvDanhSachBaiKT.Columns["ThoiGianMax"].HeaderText = "Thời gian làm bài";
            dgvDanhSachBaiKT.Columns["TenLop"].HeaderText = "Tên Lớp";
            dgvDanhSachBaiKT.Columns["MaBoCH"].HeaderText = "Mã bộ câu hỏi";
            dgvDanhSachBaiKT.Columns["Mon"].HeaderText = "Môn";

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            FBoCauHoi f = new FBoCauHoi();
            f.ShowDialog();
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            string keyword = TextTimbaiKT.Text.Trim(); // Lấy từ khóa từ TextBox và loại bỏ khoảng trắng ở đầu và cuối
            DataTable baiktrlist = db.GetBaiKiemTraListByKeyword( keyword);
            dgvDanhSachBaiKT.DataSource = baiktrlist;
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = TextTimHS.Text.Trim(); // Lấy từ khóa từ TextBox và loại bỏ khoảng trắng ở đầu và cuối
            DataTable hocSinhList = db.GetHocSinhListByKeyword(keyword);
            dgvDanhSachHocSinh.DataSource = hocSinhList;
        }
    }
}
