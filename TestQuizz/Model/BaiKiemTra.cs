using System;
namespace TestQuizz.Model
{
    public class BaiKiemTra
    {

        private string maBaiKT;

        private string tenBaiKT;

        private DateTime thoigianbatdau;

        private DateTime thoigianketthuc;

        private int thoigianmax;

        private string tenlop;

        private string maBoCH;

        private string mon;

        public BaiKiemTra(string maBaiKT, string tenBaiKT, DateTime thoigianbatdau, DateTime thoigianketthuc, int thoigianmax, string tenlop, string maBoCH, string mon)
        {
            this.maBaiKT = maBaiKT;
            this.tenBaiKT = tenBaiKT;
            this.thoigianbatdau = thoigianbatdau;
            this.thoigianketthuc = thoigianketthuc;
            this.thoigianmax = thoigianmax;
            this.tenlop = tenlop;
            this.maBoCH = maBoCH;
            this.mon = mon;
        }







        // Hàm khởi tạo với tham số

        BaiKiemTra() { }

        public string MaBaiKT { get => maBaiKT; set => maBaiKT = value; }
        public string TenBaiKT { get => tenBaiKT; set => tenBaiKT = value; }
        public DateTime ThoiGianBatDau { get => thoigianbatdau; set => thoigianbatdau = value; }
        public DateTime ThoiGianKetThuc { get => thoigianketthuc; set => thoigianketthuc = value; }
        public int ThoiGianMax { get => thoigianmax; set => thoigianmax = value; }
        public string TenLop { get => tenlop; set => tenlop = value; }
        public string Mon { get => mon; set => mon = value; }
        public string MaBoCH { get => maBoCH; set => maBoCH = value; }
    }
}