using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuizz.Model
{
    public class HocSinh
    {
        private string mahs;
        private string tenhs;
        private string gioitinh;
        private DateTime ngaysinh;
        private string tenlop;
        private string idtk;

        public string MaHS { get => mahs; set => mahs = value; }
        public string TenHS { get => tenhs; set => tenhs = value; }
        public string GioiTinh { get => gioitinh; set => gioitinh = value; }
        public DateTime NgaySinh { get => ngaysinh; set => ngaysinh = value; }
        public string Tenlop { get => tenlop; set => tenlop = value; }
        public string IDTK { get => idtk; set => idtk = value; }
        public HocSinh() { }

        public HocSinh(string mahs, string tenhs, string gioitinh, DateTime ngaysinh, string tenlop, string idtk)
        {
            this.mahs = mahs;
            this.tenhs = tenhs;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.tenlop = tenlop;
            this.idtk = idtk;
        }
    }
}
