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
    class ChiNhanhController
    {
        public static DataSet LayCN(string tk,string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.ExecuteQueryDataSet("select * from ChiNhanh", CommandType.Text);
        }
        public static bool ThemCN(string MaCN,string TenCN,string DiaChi, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.MyExecuteNonQuery("execute themCN_proc N'" + MaCN + "',N'" + TenCN + "',N'" + DiaChi  + "'", CommandType.Text, ref err);
        }
        public static bool SuaCN(string MaCN, string TenCN, string DiaChi, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.MyExecuteNonQuery("execute suaCN_proc N'" + MaCN + "',N'" + TenCN + "',N'" + DiaChi + "'", CommandType.Text, ref err);
        }
        public static bool xoaCN(string MaCN, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.MyExecuteNonQuery("execute xoaCN_proc N'" + MaCN + "'", CommandType.Text, ref err);
        }
        public static DataSet TimCN(string search, string tk, string mk)
        {
            DBMain db = new DBMain(tk,mk);
            return db.ExecuteQueryDataSet("select * from timKiemCN_func(N'" + search + "')", CommandType.Text);
        }
    }
}
