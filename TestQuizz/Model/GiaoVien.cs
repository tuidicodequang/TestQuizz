using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestQuizz.Model
{
    public class GiaoVien
    {
        private string maGV;
        private string tenGV;
        private string gioitinh;
        private string sdt;
        private DateTime ngaysinh;
        private string boMon;
        private string idTK;

        public GiaoVien(string maGV, string tenGV, string gioitinh, string sdt, DateTime ngaysinh, string boMon, string idTK)
        {
            this.maGV = maGV;
            this.tenGV = tenGV;
            this.gioitinh = gioitinh;
            this.sdt = sdt;
            this.ngaysinh = ngaysinh;
            this.boMon = boMon;
            this.idTK = idTK;
        }

        public GiaoVien() { }

        public string MaGV { get => maGV; set => maGV = value; }
        public string TenGV { get => tenGV; set => tenGV = value; }
        public string GioiTinh { get => gioitinh; set => gioitinh = value; }
        public string SDT { get => sdt; set => sdt = value; }
        public DateTime NgaySinh { get => ngaysinh; set => ngaysinh = value; }
        public string BoMon { get => boMon; set => boMon = value; }
        public string IDTK { get => idTK; set => idTK = value; }
    }
}
