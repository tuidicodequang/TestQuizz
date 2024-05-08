using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuizz.Model
{
    public class BoCauHoi
    {
        private string id;
        private string tenBo;
        private string lop;
        private string mon;
        private List<CauHoi> danhSachCauHoi;

        public BoCauHoi() { }
        public string ID { get => id; set => id = value; }
        public string TenBo { get => tenBo; set => tenBo = value; }
        public string Lop { get => lop; set => lop = value; }
        public string Mon { get => mon; set => mon = value; }
        public List<CauHoi> DanhSachCauHoi { get => danhSachCauHoi; set => danhSachCauHoi = value; }


        public BoCauHoi(string id, string tenBo, string lop, string mon, List<CauHoi> danhSachCauHoi)
        {
            this.id = id;
            this.tenBo = tenBo;
            this.lop = lop;
            this.mon = mon;
            this.danhSachCauHoi = danhSachCauHoi;
        }
    }
}
