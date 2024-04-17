using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuizz
{
    public class BoCauHoi
    {
        public int ID { get; set; }
        public string TenBo { get; set; }
        public string Lop { get; set; }
        public string Mon { get; set; }
        public List<CauHoi> DanhSachCauHoi { get; set; }

        // Hàm khởi tạo với tham số
        public BoCauHoi(int id, string tenBo, string lop, string mon)
        {
            ID = id;
            TenBo = tenBo;
            Lop = lop;
            Mon = mon;
            DanhSachCauHoi = new List<CauHoi>(); // Khởi tạo danh sách câu hỏi
        }
        public BoCauHoi() { }
    }
}
