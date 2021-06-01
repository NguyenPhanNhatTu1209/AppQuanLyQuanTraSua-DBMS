using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Đồ_án_DBMS.Views;
using Đồ_án_DBMS.BSLayer;
namespace Đồ_án_DBMS
{
    public partial class FormDoiMKQL : Form
    {
        private FormLogin frm_Login;
        private string taikhoan;
        string err;
        string tk, mk;
        int chucnang;
        public FormDoiMKQL(string tk,string mk,int chucnang)
        {
            
            InitializeComponent();
            this.tk = tk;
            this.mk = mk;
            this.chucnang = chucnang;
            DataSet quanli = QuanLyController.ThongTinQuanLy(tk, mk);
            txbTK.Text = quanli.Tables[0].Rows[0].Field<string>("TaiKhoan");
        }

        private void panelMK_Paint(object sender, PaintEventArgs e)
        {

        }
        private void txbMK_Enter(object sender, EventArgs e)
        {
            if (txbMK.Text == "Mật Khẩu Cũ")
            {
                txbMK.Text = "";
                txbMK.ForeColor = Color.Black;
                txbMK.UseSystemPasswordChar = true;
            }
        }

        private void txbNewMK_Enter(object sender, EventArgs e)
        {
            if (txbNewMK.Text == "Mật Khẩu Mới")
            {
                txbNewMK.Text = "";
                txbNewMK.ForeColor = Color.Black;
                txbNewMK.UseSystemPasswordChar = true;
            }
        }

        private void txbConfirmMK_Enter(object sender, EventArgs e)
        {

            if (txbConfirmMK.Text == "Xác nhận Mật Khẩu")
            {
                txbConfirmMK.Text = "";
                txbConfirmMK.ForeColor = Color.Black;
                txbConfirmMK.UseSystemPasswordChar = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormGiaoDien formgiaodien = new FormGiaoDien(tk,mk,chucnang);
            formgiaodien.Show();
            this.Close();
        }

        private void gunaPictureBox10_Click(object sender, EventArgs e)
        {

            if (txbConfirmMK.Text != txbNewMK.Text)
            {
                MessageBox.Show("Mật khẩu confirm không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (txbMK.Text == mk)
                {
                    QuanLyController.SuaMK(txbNewMK.Text, ref err, tk, mk);
                    if (err == null)
                    {
                        NhanVienController.doipasslogin(txbTK.Text, txbMK.Text, txbNewMK.Text, ref err, tk, mk);
                        MessageBox.Show("Đã update thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mk = txbNewMK.Text;
                    }
                    else
                    {
                        MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        err = null;
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        
            
            


        }

        public void getForm(FormLogin frmLogin, string TaiKhoan)
        {
            this.frm_Login = frmLogin;
            taikhoan = TaiKhoan;
        }
    }
}
