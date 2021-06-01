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
using Đồ_án_DBMS.Views;
namespace Đồ_án_DBMS
{
    public partial class FormThongTinKhachHang : Form
    {
        
        string tk, mk;
        int chucnang;
        string err;
        public FormThongTinKhachHang(string tk,string mk,int chucnang)
        {
            InitializeComponent();
            this.tk = tk;
            this.mk = mk;
            this.chucnang = chucnang;
            panelMK.Visible = false;
            DataSet thongtincanhan = KhachHangController.ThongTinKhachHang(tk, mk);
            txbTK.Text = thongtincanhan.Tables[0].Rows[0].Field<string>("SoDienThoai");
            txbTen.Text = thongtincanhan.Tables[0].Rows[0].Field<string>("TenKH");
            txbDiaChi.Text = thongtincanhan.Tables[0].Rows[0].Field<string>("DiaChi");
            txbEmail.Text = thongtincanhan.Tables[0].Rows[0].Field<string>("Email");
            txbDaMua.Text = thongtincanhan.Tables[0].Rows[0].Field<int>("DaMua").ToString();
            
        }

        private void CheckbMK_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbMK.Checked == true)
            {
                panelMK.Visible = true;
            }
            else
            {
                panelMK.Visible = false;
            }
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

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            if (CheckbMK.Checked == true)
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
                        KhachHangController.SuaKH(txbTK.Text, txbTen.Text, txbDiaChi.Text, txbEmail.Text, txbNewMK.Text, int.Parse(txbDaMua.Text), ref err, tk, mk);
                        if (err == null)
                        {
                            NhanVienController.doipasslogin(txbTK.Text, txbMK.Text, txbNewMK.Text, ref err, null, null);
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
            else
            {


                KhachHangController.SuaKH(txbTK.Text, txbTen.Text, txbDiaChi.Text, txbEmail.Text, mk, int.Parse(txbDaMua.Text), ref err, tk, mk);
                if (err == null)
                {
                    MessageBox.Show("Đã update thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mk = txbNewMK.Text;

                }
                else
                {
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    err = null;
                }
            }
        }

        
    }
}
