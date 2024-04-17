using System;

public class BaiKiemTra
{
    public int MaBaiKT { get; set; }
    public string TenBaiKT { get; set; }
    public DateTime ThoiGianBatDau { get; set; }
    public DateTime ThoiGianKetThuc { get; set; }
    public int ThoiGianMax { get; set; }
    public string TenLop { get; set; }

    // Hàm khởi tạo với tham số
    public BaiKiemTra(int maBaiKT, string tenBaiKT, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, int thoiGianMax, string tenLop)
    {
        MaBaiKT = maBaiKT;
        TenBaiKT = tenBaiKT;
        ThoiGianBatDau = thoiGianBatDau;
        ThoiGianKetThuc = thoiGianKetThuc;
        ThoiGianMax = thoiGianMax;
        TenLop = tenLop;
    }
    BaiKiemTra() { }
}