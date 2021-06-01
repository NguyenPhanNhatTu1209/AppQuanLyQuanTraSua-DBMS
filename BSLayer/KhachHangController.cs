using Đồ_án_DBMS.DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Đồ_án_DBMS.BSLayer
{
    class KhachHangController
    {

        public static DataSet LayKH(string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.ExecuteQueryDataSet("select * from KhachHang", CommandType.Text);
        }
        public static bool ThemKH(string SDT, string TenKH, string DiaChi, string Email, string MatKhau,int DaMua, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.MyExecuteNonQuery("execute DangKiKH_Proc N'" + SDT + "',N'" + MatKhau + "',N'" + TenKH + "',N'" + DiaChi + "',N'" + Email + "',N'" + DaMua + "'", CommandType.Text, ref err);
        }
        public static bool XoaLogin(string taikhoan, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk, mk);
            return db.MyExecuteNonQuery("execute XoaLogin '"+ taikhoan +"'", CommandType.Text, ref err);
        }

        public static bool SuaKH(string SDT, string TenKH, string DiaChi, string Email, string MatKhau,int DaMua, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.MyExecuteNonQuery("execute suaKH_proc N'" + SDT + "',N'" + TenKH + "',N'" + DiaChi + "',N'" + Email  + "',N'" + MatKhau + "',N'" + DaMua + "'", CommandType.Text, ref err);
        }
        public static bool xoaKH(string SDT, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.MyExecuteNonQuery("execute xoaKH_proc N'" + SDT + "'", CommandType.Text, ref err);
        }
        public static DataSet TimKH(string search, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.ExecuteQueryDataSet("select * from timKiemKH_func(N'" + search + "')", CommandType.Text);
        }
        public static DataSet Top5KH(string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.ExecuteQueryDataSet("select * from top5KH_func()", CommandType.Text);
        }
        public static DataSet ThongTinKhachHang(string tk, string mk)
        {

            DBMain db = new DBMain(tk, mk);

            return db.ExecuteQueryDataSet("select * from KhachHang1('" + tk + "')", CommandType.Text);
        }
    }
}
