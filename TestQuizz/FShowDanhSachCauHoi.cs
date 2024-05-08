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
        DBUtils db=new DBUtils();
        public CauHoi CauHoiDuocChon { get; set; }


        public FShowDanhSachCauHoi()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.getAllCauHoi();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                /*string maBoCH = selectedRow.Cells["ID"].Value.ToString();
                MaCHDuocChon = maBoCH;
                MessageBox.Show("Bạn có muốn thêm câu hỏi này vào bộ câu hỏi không");
                this.Close();*/

                string ID = selectedRow.Cells["ID"].ToString();
                string NoiDung= selectedRow.Cells["NoiDung"].Value.ToString();
                string DapAnDung= selectedRow.Cells["NoiDung"].Value.ToString();
                string DapAn1= selectedRow.Cells["Dapan1"].Value.ToString();
                string DapAn2= selectedRow.Cells["Dapan2"].Value.ToString();
                string DapAn3 = selectedRow.Cells["Dapan3"].Value.ToString();
                string Mon= selectedRow.Cells["Mon"].Value.ToString();

                //CauHoiDuocChon=new CauHoi(ID, NoiDung,DapAnDung,DapAn1,DapAn2,DapAn3,"");



                txtNoiDung.Text = selectedRow.Cells["NoiDung"].Value.ToString();
                txtDapAnDung.Text = selectedRow.Cells["DapAnDung"].Value.ToString();
                txtDapAn1.Text = selectedRow.Cells["Dapan1"].Value.ToString();
                txtDapAn2.Text = selectedRow.Cells["Dapan2"].Value.ToString();
                txtDapAn3.Text = selectedRow.Cells["Dapan3"].Value.ToString();
                cboMon.Text = selectedRow.Cells["Mon"].Value.ToString();





            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
