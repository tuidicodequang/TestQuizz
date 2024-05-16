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
    public partial class FTaoBaiKiemTra : Form
    {
        public string tenlop;
        public string mon;

        DBUtils db=new DBUtils();
        public FTaoBaiKiemTra()
        {
            InitializeComponent();
        }

        public FTaoBaiKiemTra(string tenlop,string mon)
        {
            InitializeComponent();
            this.tenlop=tenlop;
            this.mon=mon;
            LoadDanhSachBoCauHoi();

        }

        private void FTaoBaiKiemTra_Load(object sender, EventArgs e)
        {
            textLop.Text=tenlop.ToString();
            textMon.Text=mon.ToString();
            textNewMon.Text= mon.ToString();


        }

        public void LoadDanhSachBoCauHoi()
        {
           
            string lop = tenlop[0].ToString();
            dgvDanhSachBoCH.Columns.Clear();
            DataTable dt = db.getAllBoCauHoiTheoMonVaLop(mon,lop);

            dgvDanhSachBoCH.DataSource = dt;
            dgvDanhSachBoCH.Columns["ID"].HeaderText = "Mã Bộ Câu Hỏi";
            dgvDanhSachBoCH.Columns["TenBo"].HeaderText = "Tên Bộ";
            dgvDanhSachBoCH.Columns["Lop"].HeaderText = "Lớp";
            dgvDanhSachBoCH.Columns["Mon"].HeaderText = "Môn";
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Xem Chi Tiết";
            btnColumn.Text = "Xem";
            btnColumn.Name = "Xem";
            btnColumn.UseColumnTextForButtonValue = true;

            dgvDanhSachBoCH.Columns.Add(btnColumn);




        }



        private void button1_Click(object sender, EventArgs e)
        {
            BoCauHoi boCauHoi = new BoCauHoi()
            {
                ID = textNewMaBoCH.Text,
                TenBo = textNewTenBo.Text,
                Lop = cboNewLop.Text,
                Mon = textMon.Text,
            };
            try
            {
                db.InsertBoCauHoi(boCauHoi);
                textNewTenBo.Text = "";
                textNewMaBoCH.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            LoadDanhSachBoCauHoi();
        }

        private void btnThemMiniGame_Click(object sender, EventArgs e)
        {
            string selectedMiniGame = cboMiniGame.Text;
            if (textMaBoCH.Text.Length == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Bộ Câu Hỏi");
            }
            else if (!string.IsNullOrEmpty(selectedMiniGame))
            {
                int totalQuestionsInBoCH = db.getCauhoiTheoBoCauHoi(textMaBoCH.Text).Rows.Count;
                bool miniGameExists = false;

                // Kiểm tra xem MiniGame đã tồn tại trong DataGridView chưa
                foreach (DataGridViewRow row in dgvMiniGame.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == selectedMiniGame)
                    {
                        miniGameExists = true;
                        break;
                    }
                }

                if (!miniGameExists)
                {
                    int totalMiniGames = dgvMiniGame.Rows.Count ;
                 

                    if (totalQuestionsInBoCH - totalMiniGames * 10 >= 10)
                    {
                        dgvMiniGame.Rows.Add(selectedMiniGame);
                    }
                    else
                    {
                        MessageBox.Show("Số lượng câu hỏi không đủ cho minigame");
                    }
                }
                else
                {
                    MessageBox.Show("MiniGame đã tồn tại");
                }
            }
        }
        private string TaoMaRandom(int Loai)
        {

            const string chars = "0123456789";
            Random random = new Random();
            char[] randomArray = new char[4];

            for (int i = 0; i < 4; i++)
            {
                randomArray[i] = chars[random.Next(chars.Length)];
            }
            string MaBaiLam = "";
            if (Loai ==0)
            {
              MaBaiLam = "KT" + new string(randomArray);
            }     
            else
            {
                MaBaiLam = "BCH" + new string(randomArray);
            }
          
            return MaBaiLam;
        }
        private void btnTaoBaiKiemTra_Click(object sender, EventArgs e)
        {
            if (dgvMiniGame.Rows.Count > 0) // Kiểm tra xem DataGridView có dữ liệu không
            {
                try
                {
                    if (string.IsNullOrEmpty(textTenKT.Text) || string.IsNullOrEmpty(textThoiGianMax.Text) ||
                        string.IsNullOrEmpty(textLop.Text) || string.IsNullOrEmpty(textMon.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin");
                    }
                    else if (dateTimePickerThoiGianBatDau.Value >= dateTimePickerThoiGianKetThuc.Value)
                    {
                        MessageBox.Show("Thời Gian Kết Thúc Phải Lớn Hơn Thời Gian Bắt Đầu");
                    }
                    else
                    {
                        BaiKiemTra baiKiemTra = new BaiKiemTra()
                        {
                            MaBaiKT = TaoMaRandom(0),
                            TenBaiKT = textTenKT.Text,
                            ThoiGianBatDau = dateTimePickerThoiGianBatDau.Value,
                            ThoiGianKetThuc = dateTimePickerThoiGianKetThuc.Value,
                            ThoiGianMax = int.Parse(textThoiGianMax.Text) * 60,
                            TenLop = textLop.Text,
                            MaBoCH = textMaBoCH.Text,
                            Mon = textMon.Text
                        };
                        db.InsertBaiKiemTra(baiKiemTra);

                        // Lặp qua từng dòng trong DataGridView để lấy thông tin MiniGame
                        foreach (DataGridViewRow row in dgvMiniGame.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                // Lấy giá trị của ô trong dòng hiện tại
                                string miniGame = row.Cells[0].Value.ToString();
                                if (!string.IsNullOrEmpty(miniGame))
                                    db.InsertMiniGameVaoBaiKiemTra(baiKiemTra, miniGame);                                                           
                            }
                            
                            
                        }

                        MessageBox.Show("Tạo Bài Kiểm Tra Thành Công");
                        textTenKT.Text = "";
                        textThoiGianMax.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Chưa có MiniGame. Hãy Thêm MiniGame");
            }
        }

  

        private void dgvDanhSachBoCH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDanhSachBoCH.Columns["Xem"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDanhSachBoCH.Rows[e.RowIndex];
                string maBoCH = selectedRow.Cells["ID"].Value.ToString();
                string tenBo = selectedRow.Cells["TenBo"].Value.ToString();
                string lop = selectedRow.Cells["Lop"].Value.ToString();
                string mon = selectedRow.Cells["Mon"].Value.ToString();

                BoCauHoi boCauHoi = new BoCauHoi()
                {
                    ID = maBoCH,
                    TenBo = tenBo,
                    Lop = lop,
                    Mon = mon,
                };

                FShowDanhSachCauHoi f = new FShowDanhSachCauHoi(boCauHoi);
                f.lop =tenlop.Substring(0, 1);
                f.mon = mon;
                f.ShowDialog();
            }
            else if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDanhSachBoCH.Rows[e.RowIndex];
                textMaBoCH.Text = selectedRow.Cells["ID"].Value.ToString();

            }
        }

        private void dgvMiniGame_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvMiniGame.Rows[e.RowIndex];
                dgvMiniGame.Rows.Remove(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttTaoBoCauHoi_Click(object sender, EventArgs e)
        {
            BoCauHoi boCauHoi = new BoCauHoi()
            {
                ID = textBoxMaBoCauNew.Text,
                TenBo = textBoxTenBoCauHoiNew.Text,
                Lop = comboBoxBoCauHoiLopNew.Text,
                Mon = txtMonBocauHoi.Text,
            };
            try
            {
                db.InsertBoCauHoi(boCauHoi);
                MessageBox.Show("Tạo bộ câu hỏi thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadDanhSachBoCauHoi();
        }

        private void btTaoBoCauHoi_Click(object sender, EventArgs e)
        {
            GroupBox1.Visible = true;
            txtMonBocauHoi.Text = mon;
            comboBoxBoCauHoiLopNew.Text= tenlop[0].ToString();
            textBoxMaBoCauNew.Text = TaoMaRandom(1);
     
        }

        private void txtTimKiemBoCauHoi_TextChanged(object sender, EventArgs e)
        {
            dgvDanhSachBoCH.Columns.Clear();
            DataTable dt = db.TimkiemBoCauHoiTheoMon(mon, txtTimKiemBoCauHoi.Text);

            dgvDanhSachBoCH.DataSource = dt;
            dgvDanhSachBoCH.Columns["ID"].HeaderText = "Mã Bộ Câu Hỏi";
            dgvDanhSachBoCH.Columns["TenBo"].HeaderText = "Tên Bộ";
            dgvDanhSachBoCH.Columns["Lop"].HeaderText = "Lớp";
            dgvDanhSachBoCH.Columns["Mon"].HeaderText = "Môn";
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Xem Chi Tiết";
            btnColumn.Text = "Xem";
            btnColumn.Name = "Xem";
            btnColumn.UseColumnTextForButtonValue = true;
            dgvDanhSachBoCH.Columns.Add(btnColumn);
        }
    }
}
