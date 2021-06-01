using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Đồ_án_DBMS.DBLayer
{
    class DBMain
    {
        string ConnStr = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=DoanDBMS;Integrated Security=True";
        //string ConnStr = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=DoanDBMS;User ID=duynao4;Password=123456AsZx;";
        //Tạo kết nối
        SqlConnection conn = null;
        //Tạo lệnh
        SqlCommand comm = null;
        //Bộ chuyển đổi
        SqlDataAdapter da = null;
        //Hàm main
        public DBMain(string tk,string mk)
        {
            if (tk != null && mk != null)
            {
                ConnStr = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=DoanDBMS;User ID="+tk+";Password="+mk+";";
            }
            //Gán chuỗi kết nối để kết nối với SQL sever
            conn = new SqlConnection(ConnStr);
            //Lệnh gọi để tạo các câu lệnh truy xuất
            comm = conn.CreateCommand();
        }


        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct)
        {
            //Nếu đã có kết nối thì đóng nó lại
            if (conn.State == ConnectionState.Open)
                conn.Close();
            //Mở kết nối
            conn.Open();
            //Gán câu lệnh  
            comm.CommandText = strSQL;
            //Chọn loại lệnh 
            comm.CommandType = ct;
            //Tạo bộ chuyển đổi
            da = new SqlDataAdapter(comm);
            
            //Tạo Dataset
            DataSet ds = new DataSet();
            //Đổ dữ liệu vào da
            da.Fill(ds);
            return ds;
        }

        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error)
        {
            //Cờ lỗi
            bool f = false;
            //Nếu đã có kết nối thì đóng nó lại
            if (conn.State == ConnectionState.Open)
                conn.Close();
            //Mở kết nối
            conn.Open();
            //Gán câu lệnh 
            comm.CommandText = strSQL;
            //Chọn loại lệnh 
            comm.CommandType = ct;
            try
            {
                //Nếu chương trình chạy bình thường thì cờ được gán là True
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                //Trường hợp lỗi sẽ bắt lỗi
                error = ex.Message;
            }
            finally
            {
                //Đóng kết nối
                conn.Close();
            }
            return f;
        }
    }
}