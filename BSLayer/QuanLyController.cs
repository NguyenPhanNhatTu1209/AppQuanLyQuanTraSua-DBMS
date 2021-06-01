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
    class QuanLyController
    {
        public static bool SuaMK(string matkhaumoi, ref string err, string tk, string mk)
        {
            DBMain db = new DBMain(tk, mk);
            return db.MyExecuteNonQuery("update QuanLy set MatKhau=N'"+matkhaumoi+"' where TaiKhoan=N'"+tk+"'" , CommandType.Text, ref err);
        }
        public static DataSet ThongTinQuanLy(string tk, string mk)
        {

            DBMain db = new DBMain(tk, mk);

            return db.ExecuteQueryDataSet("select * from QuanLy where TaiKhoan=N'"+tk+"'", CommandType.Text);
        }
    }
}
