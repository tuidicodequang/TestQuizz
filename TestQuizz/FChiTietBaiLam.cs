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
    public partial class FChiTietBaiLam : Form
    {
        DBUtils db=new DBUtils();

        BaiLam baiLam=new BaiLam();
        public FChiTietBaiLam()
        {
            InitializeComponent();
        }

        public FChiTietBaiLam(BaiLam baiLam)
        {
            InitializeComponent();
            this.baiLam = baiLam;
            LoadBangChiTietBaiLam();
        }


        public void LoadBangChiTietBaiLam()
        {
            DataTable chitietBL = db.getChiTietBaiLam(baiLam);
            dataGridView1.DataSource=chitietBL;
        }
    }
}
