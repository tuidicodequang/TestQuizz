using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuizz.Model
{
    public class ChiTietBaiLam
    {
        private string maBL;
        private string cauhoi;
        private string cautraloi;
        private int trangthai;

        public ChiTietBaiLam(string maBL, string cauhoi, string cautraloi, int trangthai)
        {
            this.maBL = maBL;
            this.cauhoi = cauhoi;
            this.cautraloi = cautraloi;
            this.trangthai = trangthai;
        }

        public string MaBL { get => maBL; set => maBL = value; }
        public string CauHoi { get => cauhoi; set => cauhoi = value; }
        public string CauTraLoi { get => cautraloi; set => cautraloi = value; }
        public int TrangThai { get => trangthai; set => trangthai = value; }
    }
}
