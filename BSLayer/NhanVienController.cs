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
    class NhanVienController
    {
        public static DataSet LayNV(string tk, string mk)
        {

            DBMain db = new DBMain(tk,mk);

            return db.ExecuteQueryDataSet("select * from NhanVien", CommandType.Text);
        }
        public static bool ThemNV(string MaNV,string TenNV,string DiaChi,string Email, string SDT,string MaChiNhanh,string MatKhau,int SoLuongBan,ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.MyExecuteNonQuery("execute DangKiNV_Proc N'" + MaNV + "',N'"+MatKhau + "',N'"  + TenNV+ "',N'" + DiaChi+ "',N'" + Email+ "',N'" + SDT+ "',N'" + MaChiNhanh+ "'," +  SoLuongBan , CommandType.Text,ref err);
        }
        public static bool SuaNV(string MaNV, string TenNV, string DiaChi, string Email, string SDT, string MaChiNhanh, string MatKhau, int SoLuongBan, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.MyExecuteNonQuery("execute suaNV_proc N'" + MaNV + "',N'" + TenNV + "',N'" + DiaChi + "',N'" + Email + "',N'" + SDT + "',N'" + MaChiNhanh + "',N'" + MatKhau + "',N'" + SoLuongBan + "'", CommandType.Text, ref err);
        }
        public static bool xoaNV(string MaNV , ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.MyExecuteNonQuery("execute xoaNV_proc N'" + MaNV + "'", CommandType.Text, ref err);
        }
        public static DataSet TimNV(string search, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.ExecuteQueryDataSet("select * from timKiemNV_func(N'" + search + "')", CommandType.Text);
        }
        public static DataSet Top5NV(string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.ExecuteQueryDataSet("select * from top5NV_func()", CommandType.Text);
        }
        public static DataSet ThongTinNhanVien(string tk, string mk)
        {

            DBMain db = new DBMain(tk, mk);

            return db.ExecuteQueryDataSet("select * from NhanVien1('"+tk+"')", CommandType.Text);
        }
        
        public static bool doipasslogin(string MaNV,string mkc,string mkm, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk, mk);
            return db.MyExecuteNonQuery("execute DoiPassWord_proc N'" + MaNV + "',N'"+mkc+"',N'"+mkm+"'", CommandType.Text, ref err);
        }
    }
}
