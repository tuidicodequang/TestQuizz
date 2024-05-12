using System;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;
using TestQuizz;
using TestQuizz.Model;

namespace TestQuizz
{
    public partial class Login : Form
    {
        
        DBUtils db= new DBUtils();
        public Login()
        {
            InitializeComponent();
            this.AcceptButton=BTlogin;
        }
    
 

        private void BTlogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                string tk = textBoxDN.Text.Trim();
                string mk = textBoxMK.Text.Trim();

                if (db.LoginSuccess(tk, mk))
                {
                    DataTable gvInfo = db.getThongTinGiaoVienTheoTaiKhoan(tk);
                    DataTable hsInfo = db.getThongTinHocSinhTheoTaiKhoan(tk);

                    if (gvInfo.Rows.Count > 0)
                    {
                        GiaoVien g = new GiaoVien
                        {
                            MaGV = gvInfo.Rows[0]["MaGV"].ToString(),
                            TenGV = gvInfo.Rows[0]["TenGV"].ToString(),
                            BoMon = gvInfo.Rows[0]["BoMon"].ToString(),
                            IDTK= gvInfo.Rows[0]["IDTK"].ToString()
                        };
                        FGiaoVien f = new FGiaoVien { giaovien = g };
                        this.Hide();
                        f.ShowDialog();
                        this.Close();
                    }
                    else if (hsInfo.Rows.Count > 0)
                    {
                        HocSinh h = new HocSinh
                        {
                            MaHS = hsInfo.Rows[0]["MaHS"].ToString(),
                            Tenlop = hsInfo.Rows[0]["TenLop"].ToString(),
                            TenHS = hsInfo.Rows[0]["TenHS"].ToString(),
                            IDTK = hsInfo.Rows[0]["IDTK"].ToString(),
                        };
                        Fhocsinh f = new Fhocsinh { hocsinh = h };
                        this.Hide();
                        f.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        // Trường hợp không xác định được vai trò
                        MessageBox.Show("Tài khoản chưa có người dùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu chưa chính xác. Vui lòng nhập lại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

    }
}
