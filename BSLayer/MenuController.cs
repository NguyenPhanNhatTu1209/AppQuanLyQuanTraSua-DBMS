using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Đồ_án_DBMS.DBLayer;
using System.Data;
using System.Data.SqlClient;

namespace Đồ_án_DBMS.BSLayer
{
    class MenuController
    {
        public static DataSet LayMenu(string chinhanh,string tk, string mk)
        {
            
            DBMain db = new DBMain(tk,mk);
            
            return db.ExecuteQueryDataSet("select * from MenuMon,Menu_CN where MenuMon.MaMon=Menu_CN.MaMon and Menu_CN.MaChiNhanh=N'"+chinhanh+"'", CommandType.Text);
        }
        public static DataSet ToanBoMenu(string tk, string mk)
        {

            DBMain db = new DBMain(tk,mk);

            return db.ExecuteQueryDataSet("select * from LayMenu()", CommandType.Text);
        }
        public static DataSet LayMon(string x, string tk, string mk)
        {

            DBMain db = new DBMain(tk,mk);

            return db.ExecuteQueryDataSet("select * from Mon_func(N'" + x +"')", CommandType.Text);
        }
        public static DataSet LayMenuTheoLoai(string loai,string chinhanh, string tk, string mk)
        {

            DBMain db = new DBMain(tk,mk);

            return db.ExecuteQueryDataSet("execute Menu_Loai N'"+loai+"',N'"+chinhanh+"'", CommandType.Text);
        }
        public static bool ThemHoaDon(string SDT, string MaNV, string MaChiNhanh,DateTime NgayBan,double TongGia,string MaHoaDon, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            string sodienthoai;
            string nhanvien;
            if (SDT == null)
            {
                sodienthoai = "null";
            }
            else
            {
                sodienthoai = "N'" + SDT + "'";
            }
            if (MaNV==null)
            {
                nhanvien = "null";
            }
            else
            {
                nhanvien = "N'" + MaNV + "'";
            }
            string sqlString = "execute ThemHoaDon_proce "+sodienthoai+ ","+nhanvien+ ",N'" + MaChiNhanh + "',N'" + NgayBan + "'," + TongGia + ",N'" + MaHoaDon + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public static bool ThemChiTietHoaDon(string MaHoaDon, string MaMon, int SoLuong, double Gia, string MaTopping, string Size, string Da, string Duong, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
           

            string sqlString = "execute ThemChiTietHD_proce " + "N'" + MaHoaDon + "',N'" + MaMon + "'," + SoLuong + "," + Gia + ",N'" + MaTopping + "',N'" + Size + "',N'" + Da + "',N'" + Duong + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public static DataSet LayMaHoaDon(string tk, string mk)
        {

            DBMain db = new DBMain(tk,mk);
            return db.ExecuteQueryDataSet("select * from LayHoaDonTruoc_func()", CommandType.Text);
        }
        public static bool ThemMon(string MaMon, string TenMon, string Loai, float GiaTien, string MaChiNhanh, string AnhMinhHoa, int DaBan, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.MyExecuteNonQuery("execute themMon_proc N'" + MaMon + "',N'" + TenMon + "',N'" + Loai + "',N'" + GiaTien + "',N'" + MaChiNhanh + "',N'" + AnhMinhHoa + "',N'" + DaBan + "'", CommandType.Text, ref err);
        }
        public static bool SuaMon(string MaMon, string TenMon, string Loai, double GiaTien,string MaChiNhanhm,string MaChiNhanhc, string AnhMinhHoa, int DaBan, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.MyExecuteNonQuery("execute suaMon_proc N'" + MaMon + "',N'" + TenMon + "',N'" + Loai + "',N'" + GiaTien+"',N'"+MaChiNhanhm+"',N'"+MaChiNhanhc  + "',N'" + AnhMinhHoa + "',N'" + DaBan + "'", CommandType.Text, ref err);
        }
        public static bool xoaMon(string MaMon,string MaChiNhanh, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.MyExecuteNonQuery("execute xoaMon_proc N'" + MaMon + "',N'"+MaChiNhanh+"'", CommandType.Text, ref err);
        }
        public static DataSet TimMon(string search, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.ExecuteQueryDataSet("select * from timKiemMon_func(N'" + search + "')", CommandType.Text);
        }
        public static DataSet Top5Mon(string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.ExecuteQueryDataSet("select * from top5Mon_func()", CommandType.Text);
        }
    }
}
