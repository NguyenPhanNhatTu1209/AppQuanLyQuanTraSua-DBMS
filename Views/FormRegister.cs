using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Đồ_án_DBMS.BSLayer;
namespace Đồ_án_DBMS
{
    public partial class FormRegister : Form
    {

        string err;
        public FormRegister()
        {
            InitializeComponent();
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbTK_Enter(object sender, EventArgs e)
        {
            if (txbTK.Text == "Số điện thoại (Tài Khoản)")
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

        private void txbTen_Enter(object sender, EventArgs e)
        {
            if (txbTen.Text == "Họ và Tên")
            {
                txbTen.Text = "";
                txbTen.ForeColor = Color.Black;
            }
        }

        private void txbEmail_Enter(object sender, EventArgs e)
        {
            if (txbEmail.Text == "Email")
            {
                txbEmail.Text = "";
                txbEmail.ForeColor = Color.Black;
            }
        }

        private void txbDiaChi_Enter(object sender, EventArgs e)
        {
            if (txbDiaChi.Text == "Địa Chỉ")
            {
                txbDiaChi.Text = "";
                txbDiaChi.ForeColor = Color.Black;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
                if (this.txbTK.Text.Trim().Length <= 0 )
                {
                    this.errorProvider1.SetError(this.txbTK, "Phải nhập tài khoản (số điện thoại)");
                    return;
                }
                else this.errorProvider1.Clear();
                if (this.txbMK.Text.Trim().Length <= 0)
                {
                    this.errorProvider1.SetError(this.txbMK, "Phải nhập mật khẩu");
                    return;
                }
                else this.errorProvider1.Clear();
                if (this.txbTen.Text.Trim().Length <= 0)
                {
                    this.errorProvider1.SetError(this.txbTen, "Phải nhập Tên");
                    return;
                }
                else this.errorProvider1.Clear();
                if (this.txbDiaChi.Text.Trim().Length <= 0)
                {
                    this.errorProvider1.SetError(this.txbDiaChi, "Phải nhập Địa Chỉ");
                    return;
                }
                else this.errorProvider1.Clear();
                if (this.txbEmail.Text.Trim().Length <= 0)
                {
                    this.errorProvider1.SetError(this.txbEmail, "Phải nhập Email có kí tự @");
                    return;
                }
                else this.errorProvider1.Clear();

            bool kt=   KhachHangController.ThemKH(txbTK.Text, txbTen.Text, txbDiaChi.Text, txbEmail.Text, txbMK.Text,0, ref err, null,null);
            // Thông báo
            if (kt == true)
            {
                
                MessageBox.Show("Bạn đã tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                if (IsNumber(txbTK.Text) == false)
                {
                    KhachHangController.XoaLogin(txbTK.Text, ref err, null, null);
                    MessageBox.Show("Tên đăng nhập phải là số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (IsEmail(txbEmail.Text) == false)
                {
                    KhachHangController.XoaLogin(txbTK.Text, ref err, null, null);

                    MessageBox.Show("Email của bạn phải là có kí tự @", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    MessageBox.Show("Tên đăng nhập (số điện thoại) đã được sử dụng, vui lòng nhập số khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool IsEmail(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (c == '@') return true;
            }
            return false;
        }
    }
}
