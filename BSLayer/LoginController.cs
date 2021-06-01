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
    class LoginController
    {

        public static DataSet ktDangNhap(string tk, string mk,int chucnang)
        {
            DBMain db = new DBMain(null,null);
            return db.ExecuteQueryDataSet("select dbo.ktDangNhap_func('"+tk+"','"+mk+"',"+chucnang+")", CommandType.Text);
        }
    }

}
