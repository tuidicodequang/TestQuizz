using System;
using System.Collections.Generic;

namespace TestQuizz.Model
{
    public class CauHoi
    {

        private string id;
        private string noiDung;
        private string dapAnDung;
        private string dapAn1;
        private string dapAn2;
        private string dapAn3;
        private string hinhAnh;
        private int maBoCH;
        private string mon;

        public string ID { get => id; set => id = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public string DapAnDung { get => dapAnDung; set => dapAnDung = value; }
        public string DapAn1 { get => dapAn1; set => dapAn1 = value; }
        public string DapAn2 { get => dapAn2; set => dapAn2 = value; }
        public string DapAn3 { get => dapAn3; set => dapAn3 = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public int MaBoCH { get => maBoCH; set => maBoCH = value; }
        public string Mon { get => mon; set => mon = value; }

        public CauHoi() { }

        public CauHoi(string id, string noiDung, string dapAnDung, string dapAn1, string dapAn2, string dapAn3, string hinhAnh, int maBoCH, string mon)
        {
            this.id = id;
            this.noiDung = noiDung;
            this.dapAnDung = dapAnDung;
            this.dapAn1 = dapAn1;
            this.dapAn2 = dapAn2;
            this.dapAn3 = dapAn3;
            this.hinhAnh = hinhAnh;
            this.maBoCH = maBoCH;
            this.mon = mon;
        }
    }
}


