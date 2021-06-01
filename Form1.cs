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
    public partial class Form1 : Form
    {
        DataTable bangMenu = null;
        GioHang cart = new GioHang();
        List<GioHang> listcart = new List<GioHang>();
        GunaRadioButton khongtopping;
        public int SoLuongDaChon=0;
        string tk, mk;
        int chucnang;
        string machinhanh;
        public Form1(List<GioHang> listcart, int SoLuongDaChon,string tk,string mk,int chucnang,string machinhanh)
        {
            InitializeComponent();
            this.tk = tk;
            this.machinhanh = machinhanh;
            this.mk = mk;
            this.chucnang = chucnang;
            this.listcart = listcart;
            this.SoLuongDaChon = SoLuongDaChon;
            SoLuongItem.Text = SoLuongDaChon.ToString();
            DataSet danhsachmenu = MenuController.LayMenu(machinhanh,tk, mk);
            bangMenu = danhsachmenu.Tables[0];
            int dem = 0;
            //Hiện menu
            foreach (var item in bangMenu.AsEnumerable())
            {
                //Khung của món
                Guna.UI.WinForms.GunaShadowPanel abc = new Guna.UI.WinForms.GunaShadowPanel();
                abc.Size = new System.Drawing.Size(230, 130);
                abc.ShadowDepth = 10;
                abc.ShadowShift = 25;
                
                abc.Location = new System.Drawing.Point(6,dem*120);
                abc.Visible = true;
                abc.Name = item.Field<string>("MaMon");
                //tên món
                Guna.UI.WinForms.GunaLabel ten = new Guna.UI.WinForms.GunaLabel();
                ten.Location = new System.Drawing.Point(55, 40);
                ten.Text = item.Field<string>("TenMon") + "\n" + item.Field<double>("GiaTien").ToString() + "vnđ"; 
                ten.Size= new System.Drawing.Size(150, 40);
                ten.TextAlign = ContentAlignment.MiddleLeft;
                ten.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                ten.Name = item.Field<string>("MaMon");
                ten.Click += Ten_Click;
                abc.Controls.Add(ten);
                //Ảnh món
                GunaPictureBox pic = new GunaPictureBox();
                string anh = MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<string>("AnhMinhHoa");

                pic.Image = Image.FromFile("D:/Hệ quản trị cơ sở dữ liệu/Đồ án DBMS/" + anh);               
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Size = new System.Drawing.Size(75, 40);
                pic.Location = new System.Drawing.Point(-10, 40);
                pic.Margin = new Padding(3, 3, 3, 3);
                pic.Visible = true;
                pic.Name = item.Field<string>("MaMon");
                pic.Click += Pic_Click; ;
                abc.Controls.Add(pic);
                abc.Click += Abc_Click; 
                gunaPanel1.Controls.Add(abc);
                
                dem++;
            }
            //Hiện topping
            DataSet danhsachtopping = MenuController.LayMenuTheoLoai("Topping",machinhanh, tk, mk);
            DataTable bangtopping = danhsachtopping.Tables[0];
            int count = 0;
            khongtopping = new GunaRadioButton();
            khongtopping.Location = new System.Drawing.Point(5, count * 30);
            khongtopping.Click += Khongtopping_Click;
            khongtopping.Text = "Không Topping \n 0vnđ";
            PanelTopping.Controls.Add(khongtopping);
            count++;
            foreach (var item in  bangtopping.AsEnumerable())
            {
                if(item.Field<string>("TenMon")=="Không Topping")
                {
                    continue;
                }    
                GunaRadioButton topping = new GunaRadioButton();
                topping.Location = new System.Drawing.Point(5, count*30);
                topping.Text = MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<string>("TenMon") + "\n" + MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<double>("GiaTien").ToString() + "vnđ" ;
                topping.Name = item.Field<string>("MaMon");
                topping.Click += Topping_Click;
                PanelTopping.Controls.Add(topping);
                count++;
            }
            
        }

        private void Khongtopping_Click(object sender, EventArgs e)
        {
            cart.MaTopping = "0";
        }

        private void Topping_Click(object sender, EventArgs e)
        {
            
             cart.MaTopping = ((GunaRadioButton)sender).Name;
            
        }

        private void Ten_Click(object sender, EventArgs e)
        {
            //Hiệu ứng đóng ảnh
            //gunaTransition1.HideSync(Anh);
            DataSet a = MenuController.LayMon(((GunaLabel)sender).Name, tk, mk);
            DataTable mon = a.Tables[0];
            string anh = mon.Rows[0].Field<string>("AnhMinhHoa");
            Anh.Image = Image.FromFile("D:/Hệ quản trị cơ sở dữ liệu/Đồ án DBMS/" + anh);
            cart.MaMon = ((GunaLabel)sender).Name;
            cart.TenMon = mon.Rows[0].Field<string>("TenMon");
            cart.Anh = mon.Rows[0].Field<string>("AnhMinhHoa");
            cart.Tien = mon.Rows[0].Field<double>("GiaTien");
            textMoTa.Text = cart.TenMon + "\nGiá: " + cart.Tien.ToString();
            //Hiệu ứng mở ảnh
            //gunaTransition1.ShowSync(Anh);
        }

        private void Abc_Click(object sender, EventArgs e)
        {
            //Hiệu ứng đóng ảnh
            //gunaTransition1.HideSync(Anh);
            DataSet a = MenuController.LayMon(((GunaShadowPanel)sender).Name, tk, mk);
            DataTable mon = a.Tables[0];
            string anh = mon.Rows[0].Field<string>("AnhMinhHoa");
            Anh.Image = Image.FromFile("D:/Hệ quản trị cơ sở dữ liệu/Đồ án DBMS/" + anh);
            cart.MaMon = ((GunaShadowPanel)sender).Name;
            cart.TenMon = mon.Rows[0].Field<string>("TenMon");
            cart.Anh = mon.Rows[0].Field<string>("AnhMinhHoa");
            cart.Tien = mon.Rows[0].Field<double>("GiaTien");
            textMoTa.Text = cart.TenMon + "\nGiá: " + cart.Tien.ToString();

            //Hiệu ứng mở ảnh
            //gunaTransition1.ShowSync(Anh);


        }
        //Khi click vào món
        private void Pic_Click(object sender, EventArgs e)
        {
            //gunaTransition1.HideSync(Anh);
            DataSet a = MenuController.LayMon(((GunaPictureBox)sender).Name, tk, mk);
            DataTable mon = a.Tables[0];
            string anh = mon.Rows[0].Field<string>("AnhMinhHoa");
            Anh.Image = Image.FromFile("D:/Hệ quản trị cơ sở dữ liệu/Đồ án DBMS/" + anh);
            cart.MaMon = ((GunaPictureBox)sender).Name;
            cart.TenMon = mon.Rows[0].Field<string>("TenMon");
            cart.Anh = mon.Rows[0].Field<string>("AnhMinhHoa");
            cart.Tien = mon.Rows[0].Field<double>("GiaTien");
            textMoTa.Text = cart.TenMon + "\nGiá: " + cart.Tien.ToString();


            //gunaTransition1.ShowSync(Anh);

        }


        //Click All
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            TraSua.LineColor = Color.Transparent;
            All.LineColor = Color.Indigo;
            Tra.LineColor = Color.Transparent;
            MonKhac.LineColor = Color.Transparent;
            gunaPanel1.Controls.Clear();
            DataSet danhsachmenu = MenuController.LayMenu(machinhanh,tk, mk);
            bangMenu = danhsachmenu.Tables[0];
            int dem = 0; //canh vị trí từng món được tạo

            foreach (var item in bangMenu.AsEnumerable())
            {
                //Khung của món
                Guna.UI.WinForms.GunaShadowPanel abc = new Guna.UI.WinForms.GunaShadowPanel();
                abc.Size = new System.Drawing.Size(230, 130);
                abc.ShadowDepth = 10;
                abc.ShadowShift = 25;

                abc.Location = new System.Drawing.Point(6, dem * 120);
                abc.Visible = true;
                abc.Name = item.Field<string>("MaMon");
                //tên món
                Guna.UI.WinForms.GunaLabel ten = new Guna.UI.WinForms.GunaLabel();
                ten.Location = new System.Drawing.Point(55, 40);
                ten.Text = item.Field<string>("TenMon") + "\n" + item.Field<double>("GiaTien").ToString() + "vnđ";
                ten.Size = new System.Drawing.Size(150, 40);
                ten.TextAlign = ContentAlignment.MiddleLeft;
                ten.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                ten.Name = item.Field<string>("MaMon");
                ten.Click += Ten_Click;
                abc.Controls.Add(ten);
                //Ảnh món
                GunaPictureBox pic = new GunaPictureBox();
                string anh = MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<string>("AnhMinhHoa");

                pic.Image = Image.FromFile("D:/Hệ quản trị cơ sở dữ liệu/Đồ án DBMS/" + anh);

                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Size = new System.Drawing.Size(75, 40);
                pic.Location = new System.Drawing.Point(-10, 40);
                pic.Margin = new Padding(3, 3, 3, 3);
                pic.Visible = true;
                pic.Name = item.Field<string>("MaMon");
                pic.Click += Pic_Click;
                abc.Controls.Add(pic);
                abc.Click += Abc_Click;
                gunaPanel1.Controls.Add(abc);

                dem++;
            }
        }

        private void gunaLinePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TraSua_Click(object sender, EventArgs e)
        {
            TraSua.LineColor = Color.Indigo;
            All.LineColor = Color.Transparent;
            Tra.LineColor = Color.Transparent;
            MonKhac.LineColor = Color.Transparent;
            gunaPanel1.Controls.Clear();
            DataSet danhsachmenu = MenuController.LayMenuTheoLoai("Trà Sữa",machinhanh, tk, mk);
            bangMenu = danhsachmenu.Tables[0];
            int dem = 0;

            foreach (var item in bangMenu.AsEnumerable())
            {
                //Khung của món
                Guna.UI.WinForms.GunaShadowPanel abc = new Guna.UI.WinForms.GunaShadowPanel();
                abc.Size = new System.Drawing.Size(230, 130);
                abc.ShadowDepth = 10;
                abc.ShadowShift = 25;

                abc.Location = new System.Drawing.Point(6, dem * 120);
                abc.Visible = true;
                abc.Name = item.Field<string>("MaMon");
                //tên món
                Guna.UI.WinForms.GunaLabel ten = new Guna.UI.WinForms.GunaLabel();
                ten.Location = new System.Drawing.Point(55, 40);
                ten.Text = item.Field<string>("TenMon") + "\n" + item.Field<double>("GiaTien").ToString() + "vnđ";
                ten.Size = new System.Drawing.Size(150, 40);
                ten.TextAlign = ContentAlignment.MiddleLeft;
                ten.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                ten.Name = item.Field<string>("MaMon");
                ten.Click += Ten_Click;
                abc.Controls.Add(ten);
                //Ảnh món
                GunaPictureBox pic = new GunaPictureBox();
                string anh = MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<string>("AnhMinhHoa");

                pic.Image = Image.FromFile("D:/Hệ quản trị cơ sở dữ liệu/Đồ án DBMS/" + anh);

                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Size = new System.Drawing.Size(75, 40);
                pic.Location = new System.Drawing.Point(-10, 40);
                pic.Margin = new Padding(3, 3, 3, 3);
                pic.Visible = true;
                pic.Name = item.Field<string>("MaMon");
                pic.Click += Pic_Click;
                abc.Controls.Add(pic);
                abc.Click += Abc_Click;
                gunaPanel1.Controls.Add(abc);

                dem++;
            }
        }

        private void Tra_Click(object sender, EventArgs e)
        {
            TraSua.LineColor = Color.Transparent;
            All.LineColor = Color.Transparent;
            Tra.LineColor = Color.Indigo;
            MonKhac.LineColor = Color.Transparent;
            gunaPanel1.Controls.Clear();
            DataSet danhsachmenu = MenuController.LayMenuTheoLoai("Trà",machinhanh, tk, mk);
            bangMenu = danhsachmenu.Tables[0];
            int dem = 0;

            foreach (var item in bangMenu.AsEnumerable())
            {
                //Khung của món
                Guna.UI.WinForms.GunaShadowPanel abc = new Guna.UI.WinForms.GunaShadowPanel();
                abc.Size = new System.Drawing.Size(230, 130);
                abc.ShadowDepth = 10;
                abc.ShadowShift = 25;

                abc.Location = new System.Drawing.Point(6, dem * 120);
                abc.Visible = true;
                abc.Name = item.Field<string>("MaMon");
                //tên món
                Guna.UI.WinForms.GunaLabel ten = new Guna.UI.WinForms.GunaLabel();
                ten.Location = new System.Drawing.Point(55, 40);
                ten.Text = item.Field<string>("TenMon") + "\n" + item.Field<double>("GiaTien").ToString() + "vnđ";
                ten.Size = new System.Drawing.Size(150, 40);
                ten.TextAlign = ContentAlignment.MiddleLeft;
                ten.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                ten.Name = item.Field<string>("MaMon");
                ten.Click += Ten_Click;
                abc.Controls.Add(ten);
                //Ảnh món
                GunaPictureBox pic = new GunaPictureBox();
                string anh = MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<string>("AnhMinhHoa");

                pic.Image = Image.FromFile("D:/Hệ quản trị cơ sở dữ liệu/Đồ án DBMS/" + anh);

                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Size = new System.Drawing.Size(75, 40);
                pic.Location = new System.Drawing.Point(-10, 40);
                pic.Margin = new Padding(3, 3, 3, 3);
                pic.Visible = true;
                pic.Name = item.Field<string>("MaMon");

                pic.Click += Pic_Click;
                abc.Controls.Add(pic);
                abc.Click += Abc_Click;
                gunaPanel1.Controls.Add(abc);

                dem++;
            }
        }

        private void MonKhac_Click(object sender, EventArgs e)
        {
            TraSua.LineColor = Color.Transparent;
            All.LineColor = Color.Transparent;
            Tra.LineColor = Color.Transparent;
            MonKhac.LineColor = Color.Indigo;
            gunaPanel1.Controls.Clear();
            DataSet danhsachmenu = MenuController.LayMenuTheoLoai("Món Khác",machinhanh, tk, mk);
            bangMenu = danhsachmenu.Tables[0];
            int dem = 0;

            foreach (var item in bangMenu.AsEnumerable())
            {
                //Khung của món
                Guna.UI.WinForms.GunaShadowPanel abc = new Guna.UI.WinForms.GunaShadowPanel();
                abc.Size = new System.Drawing.Size(230, 130);
                abc.ShadowDepth = 10;
                abc.ShadowShift = 25;

                abc.Location = new System.Drawing.Point(6, dem * 120);
                abc.Visible = true;
                abc.Name = item.Field<string>("MaMon");
                //tên món
                Guna.UI.WinForms.GunaLabel ten = new Guna.UI.WinForms.GunaLabel();
                ten.Location = new System.Drawing.Point(55, 40);
                ten.Text = item.Field<string>("TenMon") + "\n" + item.Field<double>("GiaTien").ToString() + "vnđ";
                ten.Size = new System.Drawing.Size(150, 40);
                ten.TextAlign = ContentAlignment.MiddleLeft;
                ten.Name = item.Field<string>("MaMon");
                ten.Click += Ten_Click;
                ten.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                abc.Controls.Add(ten);
                //Ảnh món
                GunaPictureBox pic = new GunaPictureBox();
                string anh = MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<string>("AnhMinhHoa");

                pic.Image = Image.FromFile("D:/Hệ quản trị cơ sở dữ liệu/Đồ án DBMS/" + anh);

                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Size = new System.Drawing.Size(75, 40);
                pic.Location = new System.Drawing.Point(-10, 40);
                pic.Margin = new Padding(3, 3, 3, 3);
                pic.Visible = true;
                pic.Name = item.Field<string>("MaMon");

                pic.Click += Pic_Click;
                abc.Controls.Add(pic);
                abc.Click += Abc_Click;
                gunaPanel1.Controls.Add(abc);
                dem++;
            }
        }

        private void SizeM_Click(object sender, EventArgs e)
        {
            cart.Size = "M";
            SizeM.BaseColor = Color.Blue;
            SizeL.BaseColor = Color.MediumSlateBlue;
        }

        private void SizeL_Click(object sender, EventArgs e)
        {
            cart.Size = "L";
            SizeL.BaseColor = Color.Blue;
            SizeM.BaseColor = Color.MediumSlateBlue;
        }

        private void Duong30_Click(object sender, EventArgs e)
        {
            cart.Duong = "30";
            Duong30.BaseColor = Color.Blue;
            Duong50.BaseColor = Color.MediumSlateBlue;
            Duong70.BaseColor = Color.MediumSlateBlue;
            Duong100.BaseColor = Color.MediumSlateBlue;

        }

        private void Duong50_Click(object sender, EventArgs e)
        {
            cart.Duong = "50";
            Duong30.BaseColor = Color.MediumSlateBlue;
            Duong50.BaseColor = Color.Blue;
            Duong70.BaseColor = Color.MediumSlateBlue;
            Duong100.BaseColor = Color.MediumSlateBlue;
        }

        private void Duong70_Click(object sender, EventArgs e)
        {
            cart.Duong = "70";
            Duong30.BaseColor = Color.MediumSlateBlue;
            Duong50.BaseColor = Color.MediumSlateBlue;
            Duong70.BaseColor = Color.Blue;
            Duong100.BaseColor = Color.MediumSlateBlue;

        }

        private void Duong100_Click(object sender, EventArgs e)
        {
            cart.Duong = "100";
            Duong30.BaseColor = Color.MediumSlateBlue;
            Duong50.BaseColor = Color.MediumSlateBlue;
            Duong70.BaseColor = Color.MediumSlateBlue;
            Duong100.BaseColor = Color.Blue;

        }

        private void Da30_Click(object sender, EventArgs e)
        {
            cart.Da = "30";
            Da30.BaseColor = Color.Blue;
            Da50.BaseColor = Color.MediumSlateBlue;
            Da70.BaseColor = Color.MediumSlateBlue;
            Da100.BaseColor = Color.MediumSlateBlue;
        }

        private void da50_Click(object sender, EventArgs e)
        {
            cart.Da = "50";
            Da30.BaseColor = Color.MediumSlateBlue;
            Da50.BaseColor = Color.Blue;
            Da70.BaseColor = Color.MediumSlateBlue;
            Da100.BaseColor = Color.MediumSlateBlue;
        }

        private void Da70_Click(object sender, EventArgs e)
        {
            cart.Da = "70";
            Da30.BaseColor = Color.MediumSlateBlue;
            Da50.BaseColor = Color.MediumSlateBlue;
            Da70.BaseColor = Color.Blue;
            Da100.BaseColor = Color.MediumSlateBlue;
        }

        private void Da100_Click(object sender, EventArgs e)
        {
            cart.Da = "100";
            Da30.BaseColor = Color.MediumSlateBlue;
            Da50.BaseColor = Color.MediumSlateBlue;
            Da70.BaseColor = Color.MediumSlateBlue;
            Da100.BaseColor = Color.Blue;
        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {
        }

        private void AddCart_Click(object sender, EventArgs e)
        {
            if (cart.MaMon==null)
            {
                LabelLoi.Text = "Vui lòng chọn món";
                return;
            }
            else if (cart.Size == null)
            {
                LabelLoi.Text = "Vui Lòng chọn size";
                return;
            }
            else if(cart.Duong==null)
            {
                LabelLoi.Text = "Vui Lòng chọn mức đường";
                return;
            }
            else if (cart.Da == null)
            {
                LabelLoi.Text = "Vui Lòng chọn mức Đá";
                return;
            }
            LabelLoi.Text = "";
            cart.SoLuong = (int)SoLuong.Value;
            cart.Tien = cart.Tien * cart.SoLuong;
            listcart.Add(cart);
            SoLuongDaChon += cart.SoLuong;
            SoLuongItem.Text = SoLuongDaChon.ToString();
            cart = new GioHang();
            Da30.BaseColor = Color.MediumSlateBlue;
            Da50.BaseColor = Color.MediumSlateBlue;
            Da70.BaseColor = Color.MediumSlateBlue;
            Da100.BaseColor = Color.MediumSlateBlue;
            Duong30.BaseColor = Color.MediumSlateBlue;
            Duong50.BaseColor = Color.MediumSlateBlue;
            Duong70.BaseColor = Color.MediumSlateBlue;
            Duong100.BaseColor = Color.MediumSlateBlue;
            SizeM.BaseColor = Color.MediumSlateBlue;
            SizeL.BaseColor = Color.MediumSlateBlue;
            Anh.Image = null;
            khongtopping.Checked = true;
            SoLuong.Value = 1;
            textMoTa.Text = "";
        }

        private void SoLuongItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ChiNhanh formchinhanh = new ChiNhanh(tk, mk, chucnang);
            formchinhanh.Show();
            this.Close();
        }

        

        private void gunaPanel2_Click(object sender, EventArgs e)
        {
            ThanhToan formthanhtoan = new ThanhToan(listcart,SoLuongDaChon, tk, mk,chucnang,machinhanh);
            formthanhtoan.Show();
            this.Hide();
        }
    }
}
