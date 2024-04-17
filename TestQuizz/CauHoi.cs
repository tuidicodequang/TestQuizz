using System;
using System.Collections.Generic;

public class CauHoi
{
    public int ID { get; set; }
    public string NoiDung { get; set; }
    public string DapAnDung { get; set; }
    public string DapAn1 { get; set; }
    public string DapAn2 { get; set; }
    public string DapAn3 { get; set; }
    public string HinhAnh { get; set; }
    public int MaBoCH { get; set; }

    // Hàm khởi tạo với tham số
    public CauHoi(int id, string noiDung, string dapAnDung, string dapAn1, string dapAn2, string dapAn3, string hinhAnh, int maBoCH)
    {
        ID = id;
        NoiDung = noiDung;
        DapAnDung = dapAnDung;
        DapAn1 = dapAn1;
        DapAn2 = dapAn2;
        DapAn3 = dapAn3;
        HinhAnh = hinhAnh;
        MaBoCH = maBoCH;
    }
    public CauHoi() { }
}


