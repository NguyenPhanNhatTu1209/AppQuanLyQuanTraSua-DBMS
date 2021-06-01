using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Đồ_án_DBMS.BSLayer;
using Đồ_án_DBMS.Views;
namespace Đồ_án_DBMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //List<GioHang> a = new List<GioHang>();
            //Form1 formbatdau = new Form1(a, 0) ;
            //Application.Run(formbatdau);
            Application.Run(new FormLogin());

        }
    }
}
