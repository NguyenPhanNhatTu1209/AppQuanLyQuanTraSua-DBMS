using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Đồ_án_DBMS.BSLayer;
namespace Đồ_án_DBMS.Views
{

    public partial class FormGiaoDien : Form
    {
        public string tk;
        public string mk;
        public int chucnang;

        public FormGiaoDien(string tk,string mk,int chucnang)
        {
            this.tk = tk;
            this.mk = mk;
            this.chucnang = chucnang;
            InitializeComponent();
        }

        private void btnMuaHang_Click(object sender, EventArgs e)
        {
            ChiNhanh formMuaHang = new ChiNhanh( tk, mk,chucnang) ;
            formMuaHang.Show();
            this.Close();
            
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            FormQuanLy quanli = new FormQuanLy( tk, mk,chucnang);
            quanli.Show();
            this.Close();
            
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            if (chucnang == 3)
            {
                FormThongTinKhachHang formthongtinkhachhang = new FormThongTinKhachHang(tk, mk, chucnang);
                formthongtinkhachhang.Show();
                this.Close();
            }
            else if(chucnang==2)
            {
                FormThongTinNhanVien formthongtinnhanvien = new FormThongTinNhanVien(tk, mk, chucnang);
                formthongtinnhanvien.Show();
                this.Close();
            }
            else if(chucnang==1)
            {
                FormDoiMKQL formdoimatkhauquanli = new FormDoiMKQL(tk, mk, chucnang);
                formdoimatkhauquanli.Show();
                this.Close();
            }    

        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FormLogin formlogin = new FormLogin();
            formlogin.Show();
            this.Close();
        }
    }
}
