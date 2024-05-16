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
using System.Threading;


namespace TestQuizz
{
    public partial class FChiTietBaiLam : Form
    {
        DataTable chitietBL;
        DBUtils db=new DBUtils();
     
        int CauDung=0;
        int CauSai=0;
        BaiLam baiLam=new BaiLam();
        public FChiTietBaiLam()
        {
            InitializeComponent();
        }

        public FChiTietBaiLam(BaiLam baiLam)
        {
            InitializeComponent();
            this.baiLam = baiLam;
            chitietBL = db.getChiTietBaiLam(baiLam);
            LoadBangChiTietBaiLam();
            DelayedLoadChart();
        }

        private async void DelayedLoadChart()
        {
            await Task.Delay(1000); // Chờ 1 giây
            LoadChart();
        }

        public void LoadBangChiTietBaiLam()
        {
          
            dataGridView1.DataSource=chitietBL;
            dataGridView1.Columns["Cauhoi"].HeaderText = "Câu Hỏi";
            dataGridView1.Columns["CauTraLoi"].HeaderText = "Câu Trả Lời";
            dataGridView1.Columns["TrangThai"].HeaderText = "Trạng Thái";
          


        }
        private void LoadChart()
        {
          
            foreach (DataRow row in chitietBL.Rows)
            {
                // Kiểm tra giá trị của cột "Trạng Thái"
                if (row["TrangThai"] != null && row["TrangThai"] != DBNull.Value)
                {
                    int trangThaiValue = Convert.ToInt32(row["TrangThai"]);
                    // Nếu giá trị là 1, tăng biến CauDung lên 1
                    if (trangThaiValue == 1)
                    {
                        CauDung++;
                    }
                    // Nếu giá trị là 0, tăng biến CauSai lên 1
                    else if (trangThaiValue == 0)
                    {
                        CauSai++;
                    }
                }
            }

            // Cập nhật giao diện người dùng sau khi quét xong DataTable
            TxtSai.Text = CauSai.ToString();        
            TxtDung.Text = CauDung.ToString();
            for (int i = 1; i <= baiLam.Diem * 10; i++)
            {
                Thread.Sleep(1);
                CharThongKe.Value = i;
                CharThongKe.Update();
            }
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                // Chuyển giá trị sang kiểu int
                int trangThaiValue = Convert.ToInt32(e.Value);

                // Thiết lập giá trị hiển thị dựa trên giá trị của trạng thái
                if (trangThaiValue == 0)
                {
                    e.Value = "Sai";

                }
                else if (trangThaiValue == 1)
                {
                    e.Value = "Đúng";
                }                
            }
        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
