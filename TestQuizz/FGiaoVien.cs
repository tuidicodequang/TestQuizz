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
    public partial class FGiaoVien : Form
    {
        DBUtils db=new DBUtils();
        public GiaoVien giaovien { get; set; }
        public FGiaoVien()
        {
            InitializeComponent();
        }

        private void FGiaoVien_Load(object sender, EventArgs e)
        {
            lbTenGV.Text="Tên Giáo Viên: "+giaovien.TenGV.ToString();
            lbBoMon.Text="Bộ Môn: "+giaovien.BoMon.ToString();

            DataTable lops = db.getLopTheoMaGiaoVien(giaovien.MaGV);
            for (int i = 0; i < lops.Rows.Count; i++)
            {
                Button button = new Button();
                button.Text ="Lớp  " + lops.Rows[i]["TenLop"].ToString(); // Sử dụng chỉ mục hàng i
                button.Width = 250;
                button.Height = 200;
                button.BackgroundImage = Properties.Resources.BackGroundLop;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.FlatStyle = FlatStyle.Flat;
                button.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular);

                button.TextAlign = ContentAlignment.BottomCenter;

                button.Click += Button_Click;

                int row = 0;
                int column = i;

                tableLayoutPanel1.Controls.Add(button, column, row);
            }
        }


        private Form currentFormChild;
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
            paneltrangcon.Controls.Add(childFrom);
            paneltrangcon.Tag = childFrom;
            childFrom.BringToFront();
            childFrom.Show();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string tenLop = button.Text;
            string[] parts = tenLop.Split(' ');
            string lop = parts[2]; // Lấy phần tử thứ 2 sau khi tách chuỗi theo khoảng trắn
            FDanhSachHocSinh f = new FDanhSachHocSinh();
            f.tenlop = lop;
            f.mon = giaovien.BoMon;
            OpenchildForm(f);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttchangePass_Click(object sender, EventArgs e)
        {
            FDoiMK f = new FDoiMK();
            f.IDTK = giaovien.IDTK;
            f.ShowDialog();
        }

      
        private void bttchangePass_MouseMove(object sender, MouseEventArgs e)
        {
            bttchangePass.ForeColor = Color.Blue;
        }

        private void bttchangePass_MouseLeave(object sender, EventArgs e)
        {
            bttchangePass.ForeColor = Color.LightGoldenrodYellow;
        }
    }
}
