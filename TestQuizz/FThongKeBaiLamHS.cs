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
    public partial class FThongKeBaiLamHS : Form
    {
        DBUtils db=new DBUtils();
        BaiKiemTra baikiemtra { get; set; }
       
        public FThongKeBaiLamHS()
        {
            InitializeComponent();
        }
        public FThongKeBaiLamHS(BaiKiemTra baikiemtra)
        {
            InitializeComponent();
            this.baikiemtra=baikiemtra;
            LoadDanhSachBaiLamHSTheoBaiKiemTra(baikiemtra);
            KhoiTaoChitiet();


        }
        private Form currentFormChild;
        private void  KhoiTaoChitiet()
        {
            FChiTietBaiLam f =new FChiTietBaiLam();
            OpenchildForm(f);
        }
        private void OpenchildForm(Form childFrom)
        {
            if (currentFormChild != null)
            {

                currentFormChild.Close();

            }
            currentFormChild = childFrom;
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None;
            childFrom.Dock = DockStyle.Fill;
            panelchitietBL.Controls.Add(childFrom);
            panelchitietBL.Tag = childFrom;
            childFrom.BringToFront();
            childFrom.Show();
        }

        public void LoadDanhSachBaiLamHSTheoBaiKiemTra(BaiKiemTra baikiemtra)
        {
            DataTable dt = db.getDanhSachBaiLamHSTheoBaiKiemTra(baikiemtra);
            dgvDanhSachBaiLamHS.DataSource = dt;

            dgvDanhSachBaiLamHS.Columns["MaBL"].HeaderText = "Mã Bài Làm";
            dgvDanhSachBaiLamHS.Columns["TenHS"].HeaderText = "Tên Học Sinh";
            dgvDanhSachBaiLamHS.Columns["Diem"].HeaderText = "Điểm";
            dgvDanhSachBaiLamHS.Columns["ThoiGian"].HeaderText = "Thời Gian Làm Bài";



        }
       
        private void dgvDanhSachBaiLamHS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy thông tin từ ô được chọn
                string maBL = dgvDanhSachBaiLamHS.Rows[e.RowIndex].Cells["MaBL"].Value.ToString();
                double diem= (double)dgvDanhSachBaiLamHS.Rows[e.RowIndex].Cells["Diem"].Value;



                // Khởi tạo đối tượng BaiKiemTra với các thông tin cần thiết
                BaiLam bailam = new BaiLam()
                {
                    MaBL = maBL,
                    Diem = diem,

                };

                // Chuyển đối tượng BaiKiemTra vào form FThongKeBaiLamHS
                FChiTietBaiLam f = new FChiTietBaiLam(bailam);
                OpenchildForm(f);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
