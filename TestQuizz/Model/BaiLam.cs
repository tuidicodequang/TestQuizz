using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuizz.Model
{
    public class BaiLam
    {
        private string maBL;
        private double diem;
        private int thoigian;
        private string maBaiKT;
        private string maHS;
        public BaiLam() { }

        public BaiLam(string maBL, double diem, int thoigian, string maBaiKT, string maHS)
        {
            this.maBL = maBL;
            this.diem = diem;
            this.thoigian = thoigian;
            this.maBaiKT = maBaiKT;
            this.maHS = maHS;
        }

        public string MaBL { get => maBL; set => maBL = value; }
        public double Diem { get => diem; set => diem = value; }
        public int Thoigian { get => thoigian; set => thoigian = value; }
        public string MaBaiKT { get => maBaiKT; set => maBaiKT = value; }
        public string MaHS { get => maHS; set => maHS = value; }
    }
}
