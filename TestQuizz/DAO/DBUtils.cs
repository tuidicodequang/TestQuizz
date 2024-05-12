using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using TestQuizz.Model;

namespace TestQuizz
{
    public class DBUtils
    {
        Database db;
        public DBUtils()
        {
            db = new Database();
        }

        public DataTable getAllTaiKhoan()
        {
            string strSQL = "select * from TaiKhoan ";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }
        public bool LoginSuccess(string username, string password)
        {
            string strSQL = "SELECT COUNT(*) FROM TaiKhoan WHERE Tendangnhap = '" + username + "' AND MatKhau ='" + password + "';";
            int count = db.ExecuteScalar(strSQL);
            return count > 0;
        }

        public DataTable getAllBaiKiemTra()
        {
            string strSQL = "select * from BaiKiemTra ";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }

        public DataTable getAllBaiKiemTraTheoLop(string tenlop)
        {
            string strSQL = "select * from BaiKiemTra where TenLop ='"+tenlop+"' ";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }

        public DataTable getBaiKiemTraTheoLich(DateTime dateTime)
        {
            string strSQL = "SELECT * FROM BaiKiemTra WHERE CAST('"+dateTime+"' AS date) BETWEEN ThoiGianBatDau AND ThoiGianKetThuc";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }

        public DataTable getThongTinHocSinhTheoTaiKhoan(string TenDangNhap)
        {
            string strSQL = "select * from HocSinh,TaiKhoan where HocSinh.IDTK=TaiKhoan.ID and Tendangnhap ='"+ TenDangNhap+ "';";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }

        public DataTable getAllHocSinhTheoLop(string TenLop)
        {
            string strSQL = "select MaHS,TenHS,GioiTinh,NgaySinh from Lop,HocSinh where Lop.TenLop=HocSinh.TenLop and Lop.TenLop= '" + TenLop + "';";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }

        public DataTable getThongTinGiaoVienTheoTaiKhoan(string TenDangNhap)
        {
            string strSQL = "select * from GiaoVien,TaiKhoan where GiaoVien.IDTK=TaiKhoan.ID and Tendangnhap ='" + TenDangNhap + "';";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }
        public DataTable getLopTheoMaGiaoVien(string MaGV)
        {
            string strSQL = "select * from GiaoVien,BangPhanCong where GiaoVien.MaGV=BangPhanCong.MaGV and GiaoVien.MaGV='" + MaGV + "';";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }


        public DataTable getCauhoiTheoBoCauHoi(string MaBoCH)
        {
            string strSQL = "select * from CauHoi,BoCauHoi,QLCauHoi where CauHoi.ID=QLCauHoi.MaCH and BoCauHoi.ID=QLCauHoi.MaBoCH and BoCauHoi.ID='"+MaBoCH+"';";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }

        public DataTable getCauHoiTrongBaiKiemTra(string maBaiKT)
        {
            string strSQL = "select CauHoi.ID, CauHoi.NoiDung, CauHoi.DapAnDung, CauHoi.Dapan1, CauHoi.Dapan2, CauHoi.Dapan3 " +
                            "from BaiKiemTra AS BK " +
                            "inner join BoCauHoi AS BCH on BK.MaBoCH = BCH.ID " +
                            "inner join QLCauHoi AS QLCH on BCH.ID = QLCH.MaBoCH " +
                            "inner join CauHoi on QLCH.MaCH = CauHoi.ID " +
                            "where BK.MaBaiKT = '" + maBaiKT + "';";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }


        public DataTable getAllBoCauHoi()
        {
            string strSQL = "select * from BoCauHoi ";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }
        public DataTable getAllCauHoi()
        {
            string strSQL = "select * from CauHoi ";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }


        public void InsertBoCauHoi(BoCauHoi boCauHoi)
        {
            string strSQL = "Insert into BoCauHoi values ('" + boCauHoi.ID + "','" + boCauHoi.TenBo + "','" + boCauHoi.Lop + "','" + boCauHoi.Mon + "')";
            db.ExcuteNonQuery(strSQL);
        }

        public void InsertCauHoiVaoBoCauHoi(string IdBoCH, string IdCH )
        {
            string strSQL = "Insert into QLCauHoi values ('" + IdBoCH + "','" + IdCH + "')";
            db.ExcuteNonQuery(strSQL);
        }

        public DataTable getMiniTrongBaiKiemTra(string maBaiKT)
        {
            string strSQL = "select TenMiniGame from QLMiniGame, BaiKiemTra where QLMiniGame.MaBaiKT = BaiKiemTra.MaBaiKT and BaiKiemTra.MaBaiKT = '"+maBaiKT+"';";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }

        public void InsertBaiLam(string maBaiLam,float diem,int thoigian,string maBaiKT,string maHS)
        {

            string strSQL = "Insert into BaiLam values ('" + maBaiLam + "','" + diem + "','" + thoigian + "','" + maBaiKT + "','" + maHS + "')";
            db.ExcuteNonQuery(strSQL);
        }


        public void InsertCauHoiVaoThuVienCauHoi(CauHoi cauHoi)
        {
            string strSQL = "Insert into CauHoi values ('" + cauHoi.ID + "','" + cauHoi.NoiDung + "','" + cauHoi.DapAnDung + "','" + cauHoi.DapAn1 + "','" + cauHoi.DapAn2 + "','" + cauHoi.DapAn3 + "','" + cauHoi.HinhAnh  + "','" + cauHoi.Mon + "')";
            db.ExcuteNonQuery(strSQL);
        }


        public DataTable getBaiKiemTraHSChuaLam(string mon, HocSinh hs)
        {
            string strSQL = "SELECT DISTINCT MaBaiKT, TenBaiKT, ThoiGianBatDau, ThoiGianKetThuc, ThoiGianMax, BaiKiemTra.TenLop ,MaBoCH, Mon " +
                            "FROM BaiKiemTra " +
                            "INNER JOIN HocSinh ON HocSinh.TenLop = BaiKiemTra.TenLop " +
                            "WHERE BaiKiemTra.Mon = '" + mon + "' " +
                            "AND BaiKiemTra.MaBaiKT NOT IN (" +
                            "    SELECT DISTINCT MaBaiKT " +
                            "    FROM BaiLam " +
                            "    WHERE MaHS = '" + hs.MaHS + "')";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }
        public DataTable getBaiKiemTraHSDaLam(string mon, HocSinh hs)
        {
            string strSQL = "SELECT DISTINCT BaiKiemTra.MaBaiKT, BaiKiemTra.TenBaiKT, BaiKiemTra.ThoiGianBatDau, BaiKiemTra.ThoiGianKetThuc, BaiKiemTra.ThoiGianMax, BaiKiemTra.TenLop, BaiKiemTra.MaBoCH, BaiKiemTra.Mon " +
                            "FROM BaiKiemTra " +
                            "INNER JOIN HocSinh ON HocSinh.TenLop = BaiKiemTra.TenLop " +
                            "WHERE BaiKiemTra.Mon = '" + mon + "' " +
                            "AND BaiKiemTra.MaBaiKT IN (" +
                            "    SELECT DISTINCT MaBaiKT " +
                            "    FROM BaiLam " +
                            "    WHERE MaHS = '" + hs.MaHS + "')";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }


        public DataTable GetHocSinhListByKeyword(string keyword)
        {
            string query = "SELECT MaHS, TenHS, GioiTinh, NgaySinh FROM HocSinh WHERE MaHS LIKE '%" + keyword + "%' OR TenHS LIKE N'%" + keyword + "%' OR GioiTinh LIKE N'%" + keyword + "%' OR TenLop LIKE N'%" + keyword + "%' OR CONVERT(varchar(10), NgaySinh, 103) LIKE '%" + keyword + "%'";


            DataTable dt = db.Excute(query);
            return dt;
        }
        public DataTable GetBaiKiemTraListByKeyword(string keyword)
        {
            string query = "SELECT MaBaiKT, TenBaiKT, ThoiGianBatDau, ThoiGianKetThuc, ThoiGianMax, TenLop, MaBoCH, Mon " +
               "FROM BaiKiemTra " +
               "WHERE MaBaiKT LIKE '%" + keyword + "%' OR TenBaiKT LIKE N'%" + keyword + "%' OR TenLop LIKE N'%" + keyword + "%' OR Mon LIKE N'%" + keyword + "%' OR CONVERT(varchar(10), ThoiGianBatDau, 103) LIKE '%" + keyword + "%' OR CONVERT(varchar(10), ThoiGianKetThuc, 103) LIKE '%" + keyword + "%' OR ThoiGianMax LIKE '%" + keyword + "%'";


            DataTable dt = db.Excute(query);
            return dt;
        }
        public void updateTaikhoanHocSinh(string id, string mkmoi, string mkcu)
        {
                
                string strSQL = "UPDATE [dbo].[TaiKhoan] SET MatKhau = '"+mkmoi+ "' WHERE ID = '"+id+ "' AND MatKhau = '"+mkcu+"'";
                db.ExcuteNonQuery(strSQL);
            
        }
        public int CheckDoiMatKhau (string id, string mk)
        {
            string sql = "IF EXISTS (SELECT 1 FROM [dbo].[TaiKhoan] WHERE ID = '"+id+ "' AND MatKhau = '"+mk+"') SELECT 1 ELSE SELECT 0";

            int kq =   db.ExecuteScalar(sql);
            return kq ;
        }

        public void InsertChiTietBaiLam(string maBL, string cauhoi, string cautraloi, int trangthai)
        {
            string strSQL = "Insert into ChiTietBaiLam values ('" + maBL + "','" + cauhoi + "','" + cautraloi + "','" + trangthai + "')";
            db.ExcuteNonQuery(strSQL);
        }

        public DataTable getChiTietBaiLam(BaiLam bailam)
        {
            string strSQL = "select CauHoi,CauTraLoi,TrangThai from ChiTietBaiLam where MaBL='" + bailam.MaBL + "'";
            DataTable dt = db.Excute(strSQL);
            return dt;
        }
        public void InsertBaiLam(BaiLam bailam)
        {

            string strSQL = "Insert into BaiLam values ('" + bailam.MaBL + "','" + bailam.Diem + "','" + bailam.Thoigian + "','" + bailam.MaBaiKT + "','" + bailam.MaHS + "')";
            db.ExcuteNonQuery(strSQL);
        }
        public DataTable TimKiemBaiDaLam(string tenBaiLam, DateTime ngayThang, HocSinh hs, string mon)
        {
            // Chuyển ngày tháng thành chuỗi đúng định dạng SQL (YYYY-MM-DD)

            // Tạo câu truy vấn SQL
            string strSQL = "SELECT DISTINCT MaBaiKT, TenBaiKT, ThoiGianBatDau, ThoiGianKetThuc, ThoiGianMax, BaiKiemTra.TenLop, MaBoCH, Mon " +
                            "FROM BaiKiemTra " +
                            "INNER JOIN HocSinh ON HocSinh.TenLop = BaiKiemTra.TenLop " +
                            "WHERE (TenBaiKT LIKE '%" + tenBaiLam + "%' OR '" + tenBaiLam + "' IS NULL) " +
                            "AND BaiKiemTra.Mon = '" + mon + "' " +
                            "AND BaiKiemTra.MaBaiKT IN (" +
                            "   SELECT DISTINCT MaBaiKT " +
                            "   FROM BaiLam " +
                            "   WHERE MaHS = '" + hs.MaHS + "')" +
                            "AND '" + ngayThang.ToString("yyyy-MM-dd") + "' BETWEEN ThoiGianBatDau AND ThoiGianKetThuc";

            // Thực hiện truy vấn và lấy dữ liệu
            DataTable dt = db.Excute(strSQL);
            return dt;
        }
        public DataTable TimKiemBaiChuaLam(string tenBaiLam, DateTime ngayThang, HocSinh hs, string mon)
        {
            // Chuyển ngày tháng thành chuỗi đúng định dạng SQL (YYYY-MM-DD)

            // Tạo câu truy vấn SQL
            string strSQL = "SELECT DISTINCT MaBaiKT, TenBaiKT, ThoiGianBatDau, ThoiGianKetThuc, ThoiGianMax, BaiKiemTra.TenLop, MaBoCH, Mon " +
                            "FROM BaiKiemTra " +
                            "INNER JOIN HocSinh ON HocSinh.TenLop = BaiKiemTra.TenLop " +
                            "WHERE (TenBaiKT LIKE '%" + tenBaiLam + "%' OR '" + tenBaiLam + "' IS NULL) " +
                            "AND BaiKiemTra.Mon = '" + mon + "' " +
                            "AND BaiKiemTra.MaBaiKT NOT IN (" +
                            "   SELECT DISTINCT MaBaiKT " +
                            "   FROM BaiLam " +
                            "   WHERE MaHS = '" + hs.MaHS + "')" +
                            "AND '" + ngayThang.ToString("yyyy-MM-dd") + "' BETWEEN ThoiGianBatDau AND ThoiGianKetThuc";

            // Thực hiện truy vấn và lấy dữ liệu
            DataTable dt = db.Excute(strSQL);
            return dt;
        }

    }
}
