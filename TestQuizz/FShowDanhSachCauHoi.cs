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
    public partial class FShowDanhSachCauHoi : Form
    {
        public string lop {  get; set; }
        public string mon {  get; set; }
        DBUtils db=new DBUtils();
        public BoCauHoi boCauHoi { get;set;}

        CauHoi CauHoiDuocChon =new CauHoi();


        public FShowDanhSachCauHoi()
        {
            InitializeComponent();

        }
        public FShowDanhSachCauHoi(BoCauHoi boCauHoi)
        {
            InitializeComponent();
            this.boCauHoi = boCauHoi;
            LoadCauHoiTrongBoCauHoi();
            LoadBangAllCauHoi();
        }

        public void LoadBangAllCauHoi()
        {
            DataTable ds = db.getAllCauHoiTheoMonvaLop(boCauHoi.Mon,boCauHoi.Lop);
            dgvDanhSachTatCaCauHoi.DataSource=ds;
        }

        public void LoadCauHoiTrongBoCauHoi()
        {
            dataGridView1.DataSource = db.getCauhoiTheoBoCauHoi(boCauHoi.ID);
        }

        private void btnThemVaoBoCH_Click(object sender, EventArgs e)
        {
            try
            {
                CauHoiDuocChon.ID = txtMaCH.Text;
                CauHoiDuocChon.NoiDung = txtDapAnDung.Text;
                CauHoiDuocChon.DapAnDung = txtDapAnDung.Text;
                CauHoiDuocChon.DapAn1 = txtDapAn1.Text;
                CauHoiDuocChon.DapAn2 = txtDapAn2.Text;
                CauHoiDuocChon.DapAn3 = txtDapAn3.Text;
                CauHoiDuocChon.HinhAnh = "";
                CauHoiDuocChon.Mon = txtMon.Text;

                if (!db.KiemTraCauHoiDaTonTaiTrongBoCauHoi(boCauHoi.ID,CauHoiDuocChon.ID))
                {
                    db.InsertCauHoiVaoBoCauHoi(boCauHoi.ID, CauHoiDuocChon.ID);
                    MessageBox.Show("Đã thêm câu hỏi vào bộ câu hỏi");
                }  
                else
                {
                    MessageBox.Show("Đã tồn tại câu hỏi trong bộ câu hỏi");
                }    
                
                LoadCauHoiTrongBoCauHoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private string TaoMaCHRandom()
        {

            const string chars = "0123456789";
            Random random = new Random();
            char[] randomArray = new char[4];

            for (int i = 0; i < 4; i++)
            {
                randomArray[i] = chars[random.Next(chars.Length)];
            }
            string MaBaiLam = "CH" + new string(randomArray);
            return MaBaiLam;
        }

        private void btnThemCauHoi_Click(object sender, EventArgs e)
        {
            try
            {
                CauHoi cauhoi = new CauHoi()
                {
                    ID = txtMaCH.Text,
                    NoiDung = txtNoiDung.Text,
                    DapAnDung = txtDapAnDung.Text,
                    DapAn1 = txtDapAn1.Text,
                    DapAn2 = txtDapAn2.Text,
                    DapAn3 = txtDapAn3.Text,
                    HinhAnh = "",
                    Mon = txtMon.Text


                };
                if (db.KiemTraCauHoiDaTonTai(cauhoi.ID))
                {
                    MessageBox.Show("Câu hỏi đã tồn tại");
                }
                else
                {
                    db.InsertCauHoiVaoThuVienCauHoi(cauhoi,lop);
                    MessageBox.Show("Thêm câu hỏi thành công");
                    LoadBangAllCauHoi();
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        private void dgvDanhSachTatCaCauHoi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDanhSachTatCaCauHoi.Rows[e.RowIndex];
                txtMaCH.Text = selectedRow.Cells["ID"].Value.ToString();
                txtNoiDung.Text = selectedRow.Cells["NoiDung"].Value.ToString();
                txtDapAnDung.Text = selectedRow.Cells["DapAnDung"].Value.ToString();
                txtDapAn1.Text = selectedRow.Cells["Dapan1"].Value.ToString();
                txtDapAn2.Text = selectedRow.Cells["Dapan2"].Value.ToString();
                txtDapAn3.Text = selectedRow.Cells["Dapan3"].Value.ToString();
                txtMon.Text = selectedRow.Cells["Mon"].Value.ToString();



            }
        }

        private void bttThemTuFile_Click(object sender, EventArgs e)
        {
            FThemCauHoiTufile f = new FThemCauHoiTufile();
            f.lop = lop;
            f.mon = mon;
            f.Owner =this;
            f.ShowDialog();
        }

        private void txtTimKiemCauHoi_TextChanged(object sender, EventArgs e)
        {
            DataTable ds = db.TimKiemCauHoi(boCauHoi.Mon, boCauHoi.Lop, txtTimKiemCauHoi.Text);
            dgvDanhSachTatCaCauHoi.DataSource = ds;
        }
    }
}
