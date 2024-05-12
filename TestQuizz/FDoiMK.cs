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
    public partial class FDoiMK : Form
    {
         public string IDTK;
        DBUtils db =new DBUtils();
      
        public FDoiMK()
        {
            InitializeComponent();
        

        }

        private void bttThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttDoiMK_Click(object sender, EventArgs e)
        {
            if (TBmkMoi.Text == TbXacnhanMK.Text && TBmkMoi.Text != TbMKcu.Text)
            {
                if (db.CheckDoiMatKhau(IDTK, TbMKcu.Text) == 1)
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn lưu mật khẩu không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    // Nếu người dùng chọn OK
                    if (result == DialogResult.OK)
                    {
                       // db.updateTaikhoanHocSinh(IDTK, TBmkMoi.Text, TbMKcu.Text);
                        MessageBox.Show("Đổi Mật khẩu thành công, Vui lòng đăng nhập lại");
                        this.Close();
                        db.updateTaikhoanHocSinh(IDTK, TBmkMoi.Text, TbMKcu.Text);
                    }
                }


                else
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu chính xác");
                }


            }
            else
            {
                MessageBox.Show("Mật khẩu không khùng khớp");
            }
        }
    }
}
