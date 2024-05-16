using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestQuizz
{
    public partial class FTrangChu : Form
    {
        private int currentImageIndex = 1;
        private const int totalImages = 5;
        private Timer timer = new Timer();
        public FTrangChu()
        {
            InitializeComponent();
            

            // Thiết lập interval của Timer là 5 giây
            timer.Interval = 5000; // 5000 milliseconds = 5 seconds
            timer.Tick += Timer_Tick;

            // Bắt đầu Timer
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Gọi hàm thay đổi ảnh
            ChangeImage();
        }
        private void ChangeImage()
        {
            // Kiểm tra nếu currentImageIndex đang ở ảnh cuối cùng thì quay lại ảnh đầu tiên
            if (currentImageIndex == totalImages)
            {
                currentImageIndex = 1;
            }
            else
            {
                currentImageIndex++;
            }

            string imageName = currentImageIndex.ToString() + ".jpg";
            string imagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "TestQuizz", "Resources","AnhTrangChu", imageName);
                
            // Kiểm tra xem tệp ảnh có tồn tại không trước khi gán vào PictureBox
            if (File.Exists(imagePath))
            {
                pictureBoxTrangChu.ImageLocation = imagePath;
            }
            else
            {
                // Nếu không tìm thấy ảnh, hiển thị thông báo lỗi hoặc làm gì đó phù hợp với ứng dụng của bạn
                MessageBox.Show("Không tìm thấy ảnh!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bttDangNhap_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
