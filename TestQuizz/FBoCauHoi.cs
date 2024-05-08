using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestQuizz.Model;


namespace TestQuizz
{
    public partial class FBoCauHoi : Form
    {
        DBUtils db=new DBUtils();
        public FBoCauHoi()
        {
            InitializeComponent();
        }

        private void FBoCauHoi_Load(object sender, EventArgs e)
        {
            LoadBangBoCauHoi();
            
        }
        private void LoadBangBoCauHoi()
        {
            dgvBoCauHoi.DataSource=db.getAllBoCauHoi();
        }

        private void dgvBoCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow selectedRow = dgvBoCauHoi.Rows[e.RowIndex];
                string maBoCH = selectedRow.Cells["ID"].Value.ToString();
                LoadBangCauHoiTheoBoCauHoi(maBoCH);


                txtMaBoCH.Text = selectedRow.Cells["ID"].Value.ToString();
                txtTenBo.Text = selectedRow.Cells["TenBo"].Value.ToString();
                cboLop.Text= selectedRow.Cells["Lop"].Value.ToString();
                cboMon.Text= selectedRow.Cells["Mon"].Value.ToString();

            }
        }
        private void LoadBangCauHoiTheoBoCauHoi(string maBoCH)
        {
            DataTable dt = db.getCauhoiTheoBoCauHoi(maBoCH);
            dgvCauHoi.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ID = txtMaBoCH.Text;
            string TenBoCH = txtTenBo.Text;
            string Lop=cboLop.Text;
            string Mon = cboMon.Text;
            BoCauHoi boCauHoi = new BoCauHoi();
            boCauHoi.ID = ID;
            boCauHoi.TenBo = TenBoCH;
            boCauHoi.Lop = Lop;
            boCauHoi.Mon = Mon;
            db.InsertBoCauHoi(boCauHoi);
            MessageBox.Show("Thêm mới thành công ", "Thông Báo", MessageBoxButtons.OK);
            FBoCauHoi_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FShowDanhSachCauHoi f = new FShowDanhSachCauHoi();
            f.ShowDialog();
            CauHoi CauHoiDuocChon=f.CauHoiDuocChon;
            //string MaCHDuocChon=f.MaCHDuocChon;
            //MessageBox.Show(MaCHDuocChon);

            try
            {
                //db.InsertCauHoiVaoBoCauHoi(txtMaBoCH.Text, MaCHDuocChon);
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }


        
    }
}
