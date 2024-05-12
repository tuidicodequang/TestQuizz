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
    public partial class Fhocsinh : Form
    {
       
        DBUtils db = new DBUtils();
        public HocSinh hocsinh { get; set; }
        public Fhocsinh()
        {
            InitializeComponent();
            buttonAnh.Click += Button_Click;
            buttonDaoD.Click += Button_Click;
            buttonKHTN.Click += Button_Click;
            buttonlichsuDL.Click += Button_Click;
            buttonToan.Click += Button_Click;
            buttonTV.Click += Button_Click;
        }
        private void Fhocsinh_Load(object sender, EventArgs e)
        {
            labelTenhs.Text = hocsinh.TenHS.ToString()+ "   --   "+ hocsinh.Tenlop.ToString(); ;
           
        }
       
        private void Button_Click(object sender, EventArgs e)
        {
            // Ép kiểu sender về Button
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string buttonText = clickedButton.Text;
                // Hiển thị form và truyền vào văn bản của nút
              baikiemtraHS f=new baikiemtraHS(buttonText,hocsinh);
                  this.Hide();
                f.ShowDialog();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelTenhs_Click(object sender, EventArgs e)
        {

        }

        private void bttchangePass_MouseMove(object sender, MouseEventArgs e)
        {
            bttchangePass.ForeColor = Color.Blue;
        }

        private void bttchangePass_MouseLeave(object sender, EventArgs e)
        {
            bttchangePass.ForeColor = Color.SlateGray;
        }

  

      
        private void bttchangePass_Click(object sender, EventArgs e)
        {
            FDoiMK f = new FDoiMK();
            f.IDTK = hocsinh.IDTK;
        
            f.ShowDialog();
      
        }

        private void BTlogin_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
