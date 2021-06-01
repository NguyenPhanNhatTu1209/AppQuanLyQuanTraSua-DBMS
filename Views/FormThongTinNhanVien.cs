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
    public partial class FormThongTinNhanVien : Form
    {
        string tk, mk;
        int chucnang;
        string err;
        public FormThongTinNhanVien(string tk,string mk,int chucnang)
        {
            InitializeComponent();
            this.tk = tk;
            this.mk = mk;
            this.chucnang = chucnang;
            panelMK.Visible = false;
            DataSet thongtincanhan = NhanVienController.ThongTinNhanVien(tk,mk);
            txbTK.Text = thongtincanhan.Tables[0].Rows[0].Field<string>("MaNV");
            txbTen.Text = thongtincanhan.Tables[0].Rows[0].Field<string>("TenNV");
            txbDiaChi.Text = thongtincanhan.Tables[0].Rows[0].Field<string>("DiaChi");
            txbEmail.Text = thongtincanhan.Tables[0].Rows[0].Field<string>("Email");
            txbDienThoai.Text = thongtincanhan.Tables[0].Rows[0].Field<string>("SDT");
            txbChiNhanh.Text = thongtincanhan.Tables[0].Rows[0].Field<string>("MaChiNhanh");
            txbDaBan.Text= thongtincanhan.Tables[0].Rows[0].Field<int>("SoLuongBan").ToString();
        }

        private void FormThongTinNhanVien_Load(object sender, EventArgs e)
        {
            
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

        private void gunaPictureBox10_Click(object sender, EventArgs e)
        {
            if(CheckbMK.Checked==true)
            {
                if(txbConfirmMK.Text!=txbNewMK.Text)
                {
                    MessageBox.Show("Mật khẩu confirm không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txbMK.Text == mk)
                    {
                        NhanVienController.SuaNV(txbTK.Text, txbTen.Text, txbDiaChi.Text, txbEmail.Text, txbDienThoai.Text, txbChiNhanh.Text, txbNewMK.Text, int.Parse(txbDaBan.Text), ref err, tk, mk);
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
               
                    
                        NhanVienController.SuaNV(txbTK.Text, txbTen.Text, txbDiaChi.Text, txbEmail.Text, txbDienThoai.Text, txbChiNhanh.Text, mk, int.Parse(txbDaBan.Text), ref err, tk, mk);
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormGiaoDien frmgiaodien = new FormGiaoDien(tk, mk, chucnang);
            frmgiaodien.Show();
            this.Close();
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
    }
}
