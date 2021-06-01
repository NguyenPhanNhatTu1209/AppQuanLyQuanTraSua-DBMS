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
    public partial class FormQuanLy : Form
    {
        DataTable bangnhanvien = null;
        DataTable bangmenu = null;
        DataTable bangkhachhang = null;
        DataTable bangchinhanh = null;
        string err;
        string cnc;
        string luukhoachinh;
        string tk, mk;
        int chucnang;
        public FormQuanLy(string tk, string mk, int chucnang)
        {
            this.tk = tk;
            this.mk = mk;
            this.chucnang = chucnang;
            InitializeComponent();
            panelNV.Visible = false;
            PanelDataNV.Visible = false;
            PanelMenu.Visible = false;
            PanelDataMenu.Visible = false;
            panelKH.Visible = false;
            PanelDataKH.Visible = false;
            panelChiNhanh.Visible = false;
            PanelDataChiNhanh.Visible = false;
            btnSuaNV.Enabled = false;
            btnXoaNV.Enabled = false;
            btnSuaMon.Enabled = false;
            btnXoaMon.Enabled = false;
            btnSuaKH.Enabled = false;
            btnXoaKH.Enabled = false;
            btnSuaCN.Enabled = false;
            btnXoaCN.Enabled = false;
        }

        private void gunaControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {

            btnMenu.LineColor = Color.Transparent;
            btnNhanVien.LineColor = Color.Indigo;
            btnKhachHang.LineColor = Color.Transparent;
            btnChiNhanh.LineColor = Color.Transparent;
            panelNV.Visible = true;
            PanelDataNV.Visible = true;
            PanelMenu.Visible = false;
            PanelDataMenu.Visible = false;
            panelKH.Visible = false;
            PanelDataKH.Visible = false;
            panelChiNhanh.Visible = false;
            PanelDataChiNhanh.Visible = false;
            try
            {
                DataSet danhsachnhanvien = NhanVienController.LayNV(tk, mk);
                bangnhanvien = danhsachnhanvien.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvNV.DataSource = bangnhanvien;
                dgvNV.AutoResizeColumns();
            }
            catch
            {
                MessageBox.Show("Bạn Không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSuaNV.Enabled = true;
            btnXoaNV.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvNV.CurrentCell.RowIndex;
            txbTK.Text = dgvNV.Rows[r].Cells[0].Value.ToString();
            luukhoachinh = txbTK.Text;
            txbTen.Text = dgvNV.Rows[r].Cells[1].Value.ToString();
            txbDiaChi.Text = dgvNV.Rows[r].Cells[2].Value.ToString();
            txbEmail.Text = dgvNV.Rows[r].Cells[3].Value.ToString();
            txbDienThoai.Text = dgvNV.Rows[r].Cells[4].Value.ToString();
            txbChiNhanh.Text = dgvNV.Rows[r].Cells[5].Value.ToString();
            txbSoLuongNVBan.Text = dgvNV.Rows[r].Cells[7].Value.ToString();
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            btnMenu.LineColor = Color.Indigo;
            btnNhanVien.LineColor = Color.Transparent;
            btnKhachHang.LineColor = Color.Transparent;
            btnChiNhanh.LineColor = Color.Transparent;
            dgvMenu.Controls.Clear();
            panelNV.Visible = false;
            PanelDataNV.Visible = false;
            PanelMenu.Visible = true;
            PanelDataMenu.Visible = true;
            panelKH.Visible = false;
            PanelDataKH.Visible = false;
            panelChiNhanh.Visible = false;
            PanelDataChiNhanh.Visible = false;
            DataSet danhsachmenu = MenuController.ToanBoMenu(tk, mk);
            bangmenu = danhsachmenu.Tables[0];
            // Đưa dữ liệu lên DataGridView
            dgvMenu.DataSource = bangmenu;
            dgvMenu.AutoResizeColumns();
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSuaMon.Enabled = true;
            btnXoaMon.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvMenu.CurrentCell.RowIndex;
            txbMaMon.Text = dgvMenu.Rows[r].Cells[0].Value.ToString();
            txbTenMon.Text = dgvMenu.Rows[r].Cells[1].Value.ToString();
            txbLoai.Text = dgvMenu.Rows[r].Cells[2].Value.ToString();
            txbGiaTien.Text = dgvMenu.Rows[r].Cells[3].Value.ToString();
            txbMaChiNhanhMenu.Text = dgvMenu.Rows[r].Cells[6].Value.ToString();
            txbAnhMinhHoa.Text = dgvMenu.Rows[r].Cells[4].Value.ToString();
            txbSoLuongMonBan.Text = dgvMenu.Rows[r].Cells[5].Value.ToString();
            cnc = txbMaChiNhanhMenu.Text;

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {

            btnMenu.LineColor = Color.Transparent;
            btnNhanVien.LineColor = Color.Transparent;
            btnKhachHang.LineColor = Color.Indigo;
            btnChiNhanh.LineColor = Color.Transparent;
            panelNV.Visible = false;
            PanelDataNV.Visible = false;
            PanelMenu.Visible = false;
            PanelDataMenu.Visible = false;
            panelKH.Visible = true;
            PanelDataKH.Visible = true;
            panelChiNhanh.Visible = false;
            PanelDataChiNhanh.Visible = false;
            try
            {
                DataSet danhsachkhachhang = KhachHangController.LayKH(tk, mk);
                bangkhachhang = danhsachkhachhang.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvKH.DataSource = bangkhachhang;
                dgvKH.AutoResizeColumns();
            }
            catch
            {
                MessageBox.Show("Bạn Không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSuaKH.Enabled = true;
            btnXoaKH.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvKH.CurrentCell.RowIndex;
            txbSDTKH.Text = dgvKH.Rows[r].Cells[0].Value.ToString();
            luukhoachinh = txbSDTKH.Text;
            txbTenKH.Text = dgvKH.Rows[r].Cells[1].Value.ToString();
            txbDiaChiKH.Text = dgvKH.Rows[r].Cells[2].Value.ToString();
            txbEmailKH.Text = dgvKH.Rows[r].Cells[3].Value.ToString();
            txbSoLuongKHMua.Text = dgvKH.Rows[r].Cells[5].Value.ToString();
        }

        private void btnChiNhanh_Click(object sender, EventArgs e)
        {

            btnMenu.LineColor = Color.Transparent;
            btnNhanVien.LineColor = Color.Transparent;
            btnKhachHang.LineColor = Color.Transparent;
            btnChiNhanh.LineColor = Color.Indigo;
            panelChiNhanh.Visible = true;
            PanelDataChiNhanh.Visible = true;
            panelNV.Visible = false;
            PanelDataNV.Visible = false;
            PanelMenu.Visible = false;
            PanelDataMenu.Visible = false;
            panelKH.Visible = false;
            PanelDataKH.Visible = false;

            DataSet danhsachchinhanh = ChiNhanhController.LayCN(tk, mk);
            bangchinhanh = danhsachchinhanh.Tables[0];
            // Đưa dữ liệu lên DataGridView
            dgvChiNhanh.DataSource = bangchinhanh;



        }

        private void dgvChiNhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSuaCN.Enabled = true;
            btnXoaCN.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvChiNhanh.CurrentCell.RowIndex;
            txbMaCN.Text = dgvChiNhanh.Rows[r].Cells[0].Value.ToString();
            txbTenCN.Text = dgvChiNhanh.Rows[r].Cells[1].Value.ToString();
            txbDiaChiCN.Text = dgvChiNhanh.Rows[r].Cells[2].Value.ToString();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            NhanVienController.ThemNV(txbTK.Text, txbTen.Text, txbDiaChi.Text, txbEmail.Text, txbDienThoai.Text, txbChiNhanh.Text, "1", 0, ref err, tk, mk);
            if (err == null)
            {
                MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    DataSet danhsachnhanvien = NhanVienController.LayNV(tk, mk);
                    bangnhanvien = danhsachnhanvien.Tables[0];
                    // Đưa dữ liệu lên DataGridView
                    dgvNV.DataSource = bangnhanvien;
                    dgvNV.AutoResizeColumns();
                }
                catch
                {
                    MessageBox.Show("Bạn Không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                KhachHangController.XoaLogin(txbTK.Text, ref err, null, null);

                MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                err = null;

            }
        }



        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (txbTK.Text == luukhoachinh)
            {
                NhanVienController.SuaNV(txbTK.Text, txbTen.Text, txbDiaChi.Text, txbEmail.Text, txbDienThoai.Text, txbChiNhanh.Text, "1", int.Parse(txbSoLuongNVBan.Text), ref err, tk, mk);
                try
                {
                    DataSet danhsachnhanvien = NhanVienController.LayNV(tk, mk);
                    bangnhanvien = danhsachnhanvien.Tables[0];
                    // Đưa dữ liệu lên DataGridView
                    dgvNV.DataSource = bangnhanvien;
                    dgvNV.AutoResizeColumns();
                }
                catch
                {
                    MessageBox.Show("Bạn Không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không được sửa tài khoản(Mã nhân viên)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (err == null)
            {
                MessageBox.Show("Sửa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                err = null;
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                NhanVienController.xoaNV(txbTK.Text, ref err, tk, mk);
                try
                {
                    DataSet danhsachnhanvien = NhanVienController.LayNV(tk, mk);
                    bangnhanvien = danhsachnhanvien.Tables[0];
                    // Đưa dữ liệu lên DataGridView
                    dgvNV.DataSource = bangnhanvien;
                    dgvNV.AutoResizeColumns();
                }
                catch
                {
                    MessageBox.Show("Bạn Không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (err == null)
                {
                    KhachHangController.XoaLogin(txbTK.Text,ref err,tk,mk);
                    MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    err = null;
                }
            }
        }



        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable bangTimKiemNhanVien = new DataTable();

                bangTimKiemNhanVien.Clear();
                DataSet danhsachTimKiemNhanVien = NhanVienController.TimNV(txbTimKiemNV.Text, tk, mk);
                bangTimKiemNhanVien = danhsachTimKiemNhanVien.Tables[0];
                if (bangTimKiemNhanVien.Rows.Count == 0) MessageBox.Show("Không có nhân viên cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // Đưa dữ liệu lên DataGridView
                    dgvNV.DataSource = bangTimKiemNhanVien;
                    // Thay đổi độ rộng cột
                    dgvNV.AutoResizeColumns();

                    dgvNV_CellClick(null, null);
                }

            }
            catch
            {

                MessageBox.Show("Bạn Không có quyền truy cập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            try
            {
                txbSoLuongMonBan.Text = "0";
                MenuController.ThemMon(txbMaMon.Text, txbTenMon.Text, txbLoai.Text, float.Parse(txbGiaTien.Text), txbMaChiNhanhMenu.Text, txbAnhMinhHoa.Text, 0, ref err, tk, mk);
                if (err == null)
                {
                    MessageBox.Show("Thêm món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataSet danhsachmenu = MenuController.ToanBoMenu(tk, mk);
                    bangmenu = danhsachmenu.Tables[0];
                    // Đưa dữ liệu lên DataGridView
                    dgvMenu.DataSource = bangmenu;
                    dgvMenu.AutoResizeColumns();
                }
                else
                {
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    err = null;
                }
            }
            catch
            {
                MessageBox.Show("Phải nhập đầy đủ thông tin trừ Ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnSuaMon_Click(object sender, EventArgs e)
        {
            try
            {
                MenuController.SuaMon(txbMaMon.Text, txbTenMon.Text, txbLoai.Text, double.Parse(txbGiaTien.Text),txbMaChiNhanhMenu.Text,cnc, txbAnhMinhHoa.Text, int.Parse(txbSoLuongMonBan.Text), ref err, tk, mk);
                if (err == null)
                {
                    MessageBox.Show("Sửa món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataSet danhsachmenu = MenuController.ToanBoMenu(tk, mk);
                    bangmenu = danhsachmenu.Tables[0];
                    // Đưa dữ liệu lên DataGridView
                    dgvMenu.DataSource = bangmenu;
                    dgvMenu.AutoResizeColumns();
                }
                else
                {

                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    err = null;
                }
            }
            catch
            {
                MessageBox.Show("Phải nhập đầy đủ thông tin trừ Ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa món này!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                MenuController.xoaMon(txbMaMon.Text,txbMaChiNhanhMenu.Text, ref err, tk, mk);
                if (err == null)
                {
                    MessageBox.Show("Xóa món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataSet danhsachmenu = MenuController.ToanBoMenu(tk, mk);
                    bangmenu = danhsachmenu.Tables[0];
                    // Đưa dữ liệu lên DataGridView
                    dgvMenu.DataSource = bangmenu;
                    dgvMenu.AutoResizeColumns();
                }
                else
                {

                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    err = null;
                }
            }
        }

        private void btnTimKiemMonAn_Click(object sender, EventArgs e)
        {
            
                DataTable bangtimkiemMonAn = new DataTable();

                bangtimkiemMonAn.Clear();
                DataSet danhsachtimkiemMonAn = MenuController.TimMon(txbTimKiemMenu.Text, tk, mk);
                bangtimkiemMonAn = danhsachtimkiemMonAn.Tables[0];
                if (bangtimkiemMonAn.Rows.Count == 0) MessageBox.Show("Không có món ăn cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // Đưa dữ liệu lên DataGridView
                    dgvMenu.DataSource = bangtimkiemMonAn;
                    // Thay đổi độ rộng cột
                    dgvMenu.AutoResizeColumns();

                    dgvMenu_CellClick(null, null);
                }
            
            
            
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            

            KhachHangController.ThemKH(txbSDTKH.Text, txbTenKH.Text, txbDiaChiKH.Text, txbEmailKH.Text, "1",0, ref err, tk, mk);
            if (err == null)
            {
                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    DataSet danhsachkhachhang = KhachHangController.LayKH(tk, mk);
                    bangkhachhang = danhsachkhachhang.Tables[0];
                    // Đưa dữ liệu lên DataGridView
                    dgvKH.DataSource = bangkhachhang;
                    dgvKH.AutoResizeColumns();
                }
                catch
                {
                    MessageBox.Show("Bạn Không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                err = null;
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (txbSDTKH.Text == luukhoachinh)
            {
                KhachHangController.SuaKH(txbSDTKH.Text, txbTenKH.Text, txbDiaChiKH.Text, txbEmailKH.Text, "1", int.Parse(txbSoLuongKHMua.Text), ref err, tk, mk);
                try
                {
                    DataSet danhsachkhachhang = KhachHangController.LayKH(tk, mk);
                    bangkhachhang = danhsachkhachhang.Tables[0];
                    // Đưa dữ liệu lên DataGridView
                    dgvKH.DataSource = bangkhachhang;
                    dgvKH.AutoResizeColumns();
                }
                catch
                {
                    MessageBox.Show("Bạn Không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Không được sửa tài khoản (số điện thoại)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (err == null)
            {
                MessageBox.Show("Sửa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                err = null;
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                KhachHangController.xoaKH(txbSDTKH.Text, ref err, tk, mk);
                if (err == null)
                {
                    KhachHangController.XoaLogin(txbSDTKH.Text, ref err, tk, mk);
                    MessageBox.Show("Xóa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        DataSet danhsachkhachhang = KhachHangController.LayKH(tk, mk);
                        bangkhachhang = danhsachkhachhang.Tables[0];
                        // Đưa dữ liệu lên DataGridView
                        dgvKH.DataSource = bangkhachhang;
                        dgvKH.AutoResizeColumns();
                    }
                    catch
                    {
                        MessageBox.Show("Bạn Không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    err = null;
                }
            }
        }

        private void btnTimKiemKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable bangTimKiemKhachHang = new DataTable();

                bangTimKiemKhachHang.Clear();
                DataSet danhsachTimKiemKhachHang = KhachHangController.TimKH(txbTimKiemKH.Text, tk, mk);
                bangTimKiemKhachHang = danhsachTimKiemKhachHang.Tables[0];
                if (bangTimKiemKhachHang.Rows.Count == 0) MessageBox.Show("Không có nhân viên cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // Đưa dữ liệu lên DataGridView
                    dgvKH.DataSource = bangTimKiemKhachHang;
                    // Thay đổi độ rộng cột
                    dgvKH.AutoResizeColumns();

                    dgvKH_CellClick(null, null);
                }
            }
            catch
            {
                
                    MessageBox.Show("Bạn không có quyền truy cập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 
            }
        }

        private void btnThemCN_Click(object sender, EventArgs e)
        {

            if (txbMaCN.Text == "" || txbTenCN.Text=="" || txbDiaChiCN.Text=="")
            {
                MessageBox.Show("Phải nhập đủ thông tin chi nhánh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                ChiNhanhController.ThemCN(txbMaCN.Text, txbTenCN.Text, txbDiaChiCN.Text, ref err, tk, mk);
                if (err == null)
                {
                    MessageBox.Show("Thêm chi nhánh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataSet danhsachchinhanh = ChiNhanhController.LayCN(tk, mk);
                    bangchinhanh = danhsachchinhanh.Tables[0];
                    // Đưa dữ liệu lên DataGridView
                    dgvChiNhanh.DataSource = bangchinhanh;
                }
                else
                {
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    err = null;
                }
            }
        }

        private void btnSuaCN_Click(object sender, EventArgs e)
        {
            if (txbMaCN.Text == "" || txbTenCN.Text == "" || txbDiaChiCN.Text == "")
            {
                MessageBox.Show("Phải nhập đủ thông tin chi nhánh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                ChiNhanhController.SuaCN(txbMaCN.Text, txbTenCN.Text, txbDiaChiCN.Text, ref err, tk, mk);
                if (err == null)
                {
                    MessageBox.Show("Sửa chi nhánh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataSet danhsachchinhanh = ChiNhanhController.LayCN(tk, mk);
                    bangchinhanh = danhsachchinhanh.Tables[0];
                    // Đưa dữ liệu lên DataGridView
                    dgvChiNhanh.DataSource = bangchinhanh;

                }
                else
                {
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    err = null;
                }
            }
        
        }

        private void btnXoaCN_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa chi nhánh này!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                ChiNhanhController.xoaCN(txbMaCN.Text, ref err, tk, mk);
                if (err == null)
                {
                    MessageBox.Show("Xóa chi nhánh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataSet danhsachchinhanh = ChiNhanhController.LayCN(tk, mk);
                    bangchinhanh = danhsachchinhanh.Tables[0];
                    // Đưa dữ liệu lên DataGridView
                    dgvChiNhanh.DataSource = bangchinhanh;
                }
                else
                {
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    err = null;
                }
            }
        }

        private void btnTimKiemChiNhanh_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable bangTimKiemChiNhanh = new DataTable();

                bangTimKiemChiNhanh.Clear();
                DataSet danhsachTimKiemChiNhanh = ChiNhanhController.TimCN(txbTimKiemChiNhanh.Text, tk, mk);
                bangTimKiemChiNhanh = danhsachTimKiemChiNhanh.Tables[0];
                if (bangTimKiemChiNhanh.Rows.Count == 0) MessageBox.Show("Không có chi nhánh cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // Đưa dữ liệu lên DataGridView
                    dgvChiNhanh.DataSource = bangTimKiemChiNhanh;
                    // Thay đổi độ rộng cột
                    dgvChiNhanh.AutoResizeColumns();

                    dgvChiNhanh_CellClick(null, null);
                }
            }
            catch
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnTop5_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable bangTimKiemTop5 = new DataTable();

                bangTimKiemTop5.Clear();
                DataSet danhsachTimKiemMon = MenuController.Top5Mon(tk, mk);
                bangTimKiemTop5 = danhsachTimKiemMon.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvMenu.DataSource = bangTimKiemTop5;
                // Thay đổi độ rộng cột
                dgvMenu.AutoResizeColumns();
                dgvMenu_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnTop5KH_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable bangTimKiemTop5KH = new DataTable();

                bangTimKiemTop5KH.Clear();
                DataSet danhsachTimKiemMon = KhachHangController.Top5KH(tk, mk);
                bangTimKiemTop5KH = danhsachTimKiemMon.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvKH.DataSource = bangTimKiemTop5KH;
                // Thay đổi độ rộng cột
                dgvKH.AutoResizeColumns();
                dgvKH_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnTop5NV_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable bangTimKiemTop5NV = new DataTable();

                bangTimKiemTop5NV.Clear();
                DataSet danhsachTimKiemMon = NhanVienController.Top5NV(tk, mk);
                bangTimKiemTop5NV = danhsachTimKiemMon.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvNV.DataSource = bangTimKiemTop5NV;
                // Thay đổi độ rộng cột
                dgvNV.AutoResizeColumns();
                dgvNV_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txbTimKiemNV_Enter(object sender, EventArgs e)
        {
            if(txbTimKiemNV.Text== "Họ và Tên")
            {
                txbTimKiemNV.Text = "";
                txbTimKiemNV.ForeColor = Color.Black;
            }    
        }

        private void txbTimKiemKH_Enter(object sender, EventArgs e)
        {
            if (txbTimKiemKH.Text == "Họ và Tên")
            {
                txbTimKiemKH.Text = "";
                txbTimKiemKH.ForeColor = Color.Black;
            }
        }

        private void txbTimKiemChiNhanh_Enter(object sender, EventArgs e)
        {
            if (txbTimKiemChiNhanh.Text == "Tên Chi Nhánh")
            {
                txbTimKiemChiNhanh.Text = "";
                txbTimKiemChiNhanh.ForeColor = Color.Black;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormGiaoDien formgiaodien = new FormGiaoDien(tk, mk, chucnang);
            formgiaodien.Show();
            this.Close();
        }

        private void txbTimKiemMenu_Enter(object sender, EventArgs e)
        {
            if (txbTimKiemMenu.Text == "Tên Món")
            {
                txbTimKiemMenu.Text = "";
                txbTimKiemMenu.ForeColor = Color.Black;
            }
            
        }
    }
}
