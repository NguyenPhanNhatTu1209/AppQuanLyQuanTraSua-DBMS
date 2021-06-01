using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.Lib;
using System.Data.SqlClient;
using Đồ_án_DBMS.BSLayer;
using Guna.UI.WinForms;
using Đồ_án_DBMS.Views;
namespace Đồ_án_DBMS
{
    public partial class FormLogin : Form
    {
        DataTable dataKH = null;
        DataTable dataNV = null;
        DataTable dataQL = null;
        int chucnang=-1;
        KhachHangController danhSachKhachHang = new KhachHangController();
        NhanVienController danhsachNhanVien = new NhanVienController();
        public FormLogin()
        {
            InitializeComponent();
        }

        
        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        private void txbTK_Enter(object sender, EventArgs e)
        {
            if(txbTK.Text=="Tài Khoản")
            {
                txbTK.Text = "";
                txbTK.ForeColor = Color.Black;
            }
        }

        private void txbMK_Enter(object sender, EventArgs e)
        {
            if (txbMK.Text == "Mật Khẩu")
            {
                txbMK.Text = "";
                txbMK.ForeColor = Color.Black;
                txbMK.UseSystemPasswordChar = true;
            }

        }

        private void CheckBoxQL_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckBoxQL.Checked==true)
            {
                chucnang = 1;
                CheckBoxKH.Checked = false;
                CheckBoxNV.Checked = false;
            }
        }

        private void CheckBoxNV_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxNV.Checked == true)
            {
                chucnang = 2;
                CheckBoxQL.Checked = false;
                CheckBoxKH.Checked = false;
            }
        }

        private void CheckBoxKH_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxKH.Checked == true)
            {
                chucnang = 3;
                CheckBoxQL.Checked = false;
                CheckBoxNV.Checked = false;
            }
        }

        private void btLogin_Click(object ender, EventArgs e)
        {
            try
            {
                if (this.txbTK.Text.Trim().Length <= 0)
                {
                    this.errorProvider1.SetError(this.txbTK, "Phải nhập tài khoản");
                    return;
                }
                else this.errorProvider1.Clear();
                if (this.txbMK.Text.Trim().Length <= 0)
                {
                    this.errorProvider1.SetError(this.txbMK, "Phải nhập mật khẩu");
                    return;
                }
                else this.errorProvider1.Clear();
                if (chucnang==-1)
                {
                    this.errorProvider1.SetError(this.CheckBoxQL, "Phải chọn chức năng");
                    return;
                }    
                DataTable ktra = LoginController.ktDangNhap(txbTK.Text, txbMK.Text, chucnang).Tables[0];
                if (int.Parse(ktra.Rows[0][0].ToString())==1)
                {
                    FormGiaoDien formgiaodien = new FormGiaoDien( txbTK.Text,  txbMK.Text,chucnang);
                    formgiaodien.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gunaPictureBox6_Click(object sender, EventArgs e)
        {
            FormRegister formregister = new FormRegister();
            formregister.Show();
            this.Hide();
        }
    }
}
