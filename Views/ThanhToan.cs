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
    public partial class ThanhToan : Form
    {
        GioHang cart = new GioHang();
        List<GioHang> listcart ;
        int SoLuongDaChon = 0;
        int itemdangchon = 0;
        GunaRadioButton khongtopping;
        double TongGia = 0;
        string err;
        string tk, mk;
        int chucnang;
        string machinhanh;
        public ThanhToan(List<GioHang> giohang, int SoLuongDaChon, string tk, string mk, int chucnang, string machinhanh)
        {
            InitializeComponent();
            this.tk = tk;
            this.mk = mk;
            this.chucnang = chucnang;
            listcart = giohang;
            this.machinhanh=machinhanh;
            this.SoLuongDaChon = SoLuongDaChon;
            int dem = 0;
            //Hiện menu đã chọn
            foreach (var item in giohang)
            {
                //Khung của món
                GunaPanel MonDaChon = new GunaPanel();
                MonDaChon.Size = new System.Drawing.Size(600, 120);
                
                
                MonDaChon.Location = new System.Drawing.Point(6,dem*120);
                MonDaChon.Name = dem.ToString();
                //tên thông tin món đã chọn
                Guna.UI.WinForms.GunaLabel ten = new Guna.UI.WinForms.GunaLabel();
                ten.Location = new System.Drawing.Point(130, 0);
                ten.Name = dem.ToString();
                if (item.MaTopping != null)
                {
                    ten.Text = item.TenMon + " (Size: " + item.Size + ", Đường: " + item.Duong + "%, Đá: " + item.Da + "%)" + "\n" +
                        "Topping: " + MenuController.LayMon(item.MaTopping, tk, mk).Tables[0].Rows[0].Field<string>("TenMon") + "\n" + "x" + item.SoLuong;
                }
                else
                {
                    ten.Text = item.TenMon + " (Size: " + item.Size + ", Đường: " + item.Duong + "%, Đá: " + item.Da + "%)" + "\n" +
                        "Topping: Không topping" + "\n" + "x" + item.SoLuong;
                }
                ten.Size= new System.Drawing.Size(300, 120);
                ten.TextAlign = ContentAlignment.MiddleLeft;
                ten.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                ten.Click += Ten_Click;
                MonDaChon.Controls.Add(ten);
                //Giá tiền
                Guna.UI.WinForms.GunaLabel tien = new Guna.UI.WinForms.GunaLabel();
                tien.Location = new System.Drawing.Point(500, 0);
                tien.Name = dem.ToString();
                tien.ForeColor = Color.Red;
                if (item.Size == "M")
                {
                    if (item.MaTopping != null)
                    {
                        tien.Text = (item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")
                            + MenuController.LayMon(item.MaTopping, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien"))).ToString()+"vnđ";
                    }
                    else
                    {
                        tien.Text = (item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien"))).ToString()+"vnđ";
                    }
                }
                else if (item.Size == "L")
                {
                    if (item.MaTopping != null)
                    {
                        tien.Text = (item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")
                            + MenuController.LayMon(item.MaTopping, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien") + 5000)).ToString()+"vnđ";
                    }
                    else
                    {
                        tien.Text = (item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien") + 5000)).ToString()+"vnđ";
                    }
                }
                tien.Size = new System.Drawing.Size(150, 120);
                tien.TextAlign = ContentAlignment.MiddleLeft;
                tien.Font = new Font("Times New Roman", 13, FontStyle.Bold);
                tien.Click += Ten_Click;
                MonDaChon.Controls.Add(tien);
                //Ảnh món
                GunaPictureBox pic = new GunaPictureBox();
                pic.Name = dem.ToString();
                pic.Image = Image.FromFile("D:/Hệ quản trị cơ sở dữ liệu/Đồ án DBMS/" + item.Anh);               
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Size = new System.Drawing.Size(120, 120);
                pic.Location = new System.Drawing.Point(0, 0);
                pic.Click += Pic_Click; ;
                MonDaChon.Controls.Add(pic);
                MonDaChon.Click += MonDaChon_Click; ; 
                gunaPanel1.Controls.Add(MonDaChon);
                
                dem++;

                
            }
            //Hiện topping
            DataSet danhsachtopping = MenuController.LayMenuTheoLoai("Topping",machinhanh, tk, mk);
            DataTable bangtopping = danhsachtopping.Tables[0];
            int count = 0;
            khongtopping = new GunaRadioButton();
            khongtopping.Location = new System.Drawing.Point(5, count * 30);
            khongtopping.Click += Khongtopping_Click; ;
            khongtopping.Text = "Không Topping \n 0vnđ";
            PanelTopping.Controls.Add(khongtopping);
            count++;
            foreach (var item in bangtopping.AsEnumerable())
            {
                if (item.Field<string>("TenMon") == "Không Topping")
                {
                    continue;
                }
                GunaRadioButton topping = new GunaRadioButton();
                topping.Location = new System.Drawing.Point(5, count * 30);
                topping.Text = MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<string>("TenMon") + "\n" + MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<double>("GiaTien").ToString() + "vnđ";
                topping.Name = item.Field<string>("MaMon");
                topping.Click += Topping_Click;
                PanelTopping.Controls.Add(topping);
                count++;
            }
            //Hiện tổng số tiền phải thanh toán
            if (listcart.Count != 0)
            {
                foreach (var item in listcart)
                {
                    if (item.Size == "M")
                    {
                        if (item.MaTopping != null)
                        {
                            TongGia += item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")
                                + MenuController.LayMon(item.MaTopping, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien"));
                        }
                        else
                        {
                            TongGia += item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien"));
                        }
                    }
                    else if (item.Size == "L")
                    {
                        if (item.MaTopping != null)
                        {
                            TongGia += item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")
                                + MenuController.LayMon(item.MaTopping, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien") + 5000);
                        }
                        else
                        {
                            TongGia += item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien") + 5000);
                        }
                    }
                    lblTongTien.Text = TongGia.ToString() + "vnđ";
                }
            }
            else
                lblTongTien.Text = "0vnđ";
            
            
        }

        private void MonDaChon_Click(object sender, EventArgs e)
        {
            try
            {
                itemdangchon = int.Parse(((GunaPanel)sender).Name);
                cart = listcart[int.Parse(((GunaPanel)sender).Name)];
                SoLuong.Value = cart.SoLuong;
                if (cart.Size == "M")
                {
                    SizeM.BaseColor = Color.Blue;
                    SizeL.BaseColor = Color.MediumSlateBlue;
                }
                else
                {
                    SizeM.BaseColor = Color.MediumSlateBlue;
                    SizeL.BaseColor = Color.Blue;
                }
                if (cart.Duong == "30")
                {
                    Duong30.BaseColor = Color.Blue;
                    Duong50.BaseColor = Color.MediumSlateBlue;
                    Duong70.BaseColor = Color.MediumSlateBlue;
                    Duong100.BaseColor = Color.MediumSlateBlue;


                }
                else if (cart.Duong == "70")
                {
                    Duong30.BaseColor = Color.MediumSlateBlue;
                    Duong50.BaseColor = Color.MediumSlateBlue;
                    Duong70.BaseColor = Color.Blue;
                    Duong100.BaseColor = Color.MediumSlateBlue;
                }
                else if (cart.Duong == "50")
                {
                    Duong30.BaseColor = Color.MediumSlateBlue;
                    Duong50.BaseColor = Color.Blue;
                    Duong70.BaseColor = Color.MediumSlateBlue;
                    Duong100.BaseColor = Color.MediumSlateBlue;
                }
                else if (cart.Duong == "100")
                {
                    Duong30.BaseColor = Color.MediumSlateBlue;
                    Duong50.BaseColor = Color.MediumSlateBlue;
                    Duong70.BaseColor = Color.MediumSlateBlue;
                    Duong100.BaseColor = Color.Blue;
                }
                if (cart.Da == "30")
                {
                    Da30.BaseColor = Color.Blue;
                    Da50.BaseColor = Color.MediumSlateBlue;
                    Da70.BaseColor = Color.MediumSlateBlue;
                    Da100.BaseColor = Color.MediumSlateBlue;


                }
                else if (cart.Da == "70")
                {
                    Da30.BaseColor = Color.MediumSlateBlue;
                    Da50.BaseColor = Color.MediumSlateBlue;
                    Da70.BaseColor = Color.Blue;
                    Da100.BaseColor = Color.MediumSlateBlue;
                }
                else if (cart.Da == "50")
                {
                    Da30.BaseColor = Color.MediumSlateBlue;
                    Da50.BaseColor = Color.Blue;
                    Da70.BaseColor = Color.MediumSlateBlue;
                    Da100.BaseColor = Color.MediumSlateBlue;
                }
                else if (cart.Da == "100")
                {
                    Da30.BaseColor = Color.MediumSlateBlue;
                    Da50.BaseColor = Color.MediumSlateBlue;
                    Da70.BaseColor = Color.MediumSlateBlue;
                    Da100.BaseColor = Color.Blue;
                }
                //Hiện lại topping
                PanelTopping.Controls.Clear();
                DataSet danhsachtopping = MenuController.LayMenuTheoLoai("Topping",machinhanh, tk, mk);
                DataTable bangtopping = danhsachtopping.Tables[0];
                int count = 0;
                khongtopping = new GunaRadioButton();
                khongtopping.Location = new System.Drawing.Point(5, count * 30);
                khongtopping.Click += Khongtopping_Click; ;
                khongtopping.Text = "Không Topping \n 0vnđ";
                PanelTopping.Controls.Add(khongtopping);
                if (cart.MaTopping == null) khongtopping.Checked = true;
                count++;
                foreach (var item in bangtopping.AsEnumerable())
                {
                    if (item.Field<string>("TenMon") == "Không Topping")
                    {
                        continue;
                    }
                    GunaRadioButton topping = new GunaRadioButton();
                    topping.Location = new System.Drawing.Point(5, count * 30);
                    topping.Text = MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<string>("TenMon") + "\n" + MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<double>("GiaTien").ToString() + "vnđ";
                    topping.Name = item.Field<string>("MaMon");
                    topping.Click += Topping_Click;
                    PanelTopping.Controls.Add(topping);
                    if (cart.MaTopping == topping.Name)
                        topping.Checked = true;
                    count++;
                }
                
            }
            catch { }
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
            try
            {
                //Hiệu ứng đóng ảnh
                //gunaTransition1.HideSync(Anh);
                itemdangchon = int.Parse(((GunaLabel)sender).Name);
                cart = listcart[int.Parse(((GunaLabel)sender).Name)];
                SoLuong.Value = cart.SoLuong;
                if (cart.Size == "M")
                {
                    SizeM.BaseColor = Color.Blue;
                    SizeL.BaseColor = Color.MediumSlateBlue;
                }
                else
                {
                    SizeM.BaseColor = Color.MediumSlateBlue;
                    SizeL.BaseColor = Color.Blue;
                }
                if (cart.Duong == "30")
                {
                    Duong30.BaseColor = Color.Blue;
                    Duong50.BaseColor = Color.MediumSlateBlue;
                    Duong70.BaseColor = Color.MediumSlateBlue;
                    Duong100.BaseColor = Color.MediumSlateBlue;


                }
                else if (cart.Duong == "70")
                {
                    Duong30.BaseColor = Color.MediumSlateBlue;
                    Duong50.BaseColor = Color.MediumSlateBlue;
                    Duong70.BaseColor = Color.Blue;
                    Duong100.BaseColor = Color.MediumSlateBlue;
                }
                else if (cart.Duong == "50")
                {
                    Duong30.BaseColor = Color.MediumSlateBlue;
                    Duong50.BaseColor = Color.Blue;
                    Duong70.BaseColor = Color.MediumSlateBlue;
                    Duong100.BaseColor = Color.MediumSlateBlue;
                }
                else if (cart.Duong == "100")
                {
                    Duong30.BaseColor = Color.MediumSlateBlue;
                    Duong50.BaseColor = Color.MediumSlateBlue;
                    Duong70.BaseColor = Color.MediumSlateBlue;
                    Duong100.BaseColor = Color.Blue;
                }
                if (cart.Da == "30")
                {
                    Da30.BaseColor = Color.Blue;
                    Da50.BaseColor = Color.MediumSlateBlue;
                    Da70.BaseColor = Color.MediumSlateBlue;
                    Da100.BaseColor = Color.MediumSlateBlue;


                }
                else if (cart.Da == "70")
                {
                    Da30.BaseColor = Color.MediumSlateBlue;
                    Da50.BaseColor = Color.MediumSlateBlue;
                    Da70.BaseColor = Color.Blue;
                    Da100.BaseColor = Color.MediumSlateBlue;
                }
                else if (cart.Da == "50")
                {
                    Da30.BaseColor = Color.MediumSlateBlue;
                    Da50.BaseColor = Color.Blue;
                    Da70.BaseColor = Color.MediumSlateBlue;
                    Da100.BaseColor = Color.MediumSlateBlue;
                }
                else if (cart.Da == "100")
                {
                    Da30.BaseColor = Color.MediumSlateBlue;
                    Da50.BaseColor = Color.MediumSlateBlue;
                    Da70.BaseColor = Color.MediumSlateBlue;
                    Da100.BaseColor = Color.Blue;
                }
                //Hiện lại topping
                PanelTopping.Controls.Clear();
                DataSet danhsachtopping = MenuController.LayMenuTheoLoai("Topping",machinhanh, tk, mk);
                DataTable bangtopping = danhsachtopping.Tables[0];
                int count = 0;
                khongtopping = new GunaRadioButton();
                khongtopping.Location = new System.Drawing.Point(5, count * 30);
                khongtopping.Click += Khongtopping_Click; ;
                khongtopping.Text = "Không Topping \n 0vnđ";
                PanelTopping.Controls.Add(khongtopping);
                if (cart.MaTopping == null) khongtopping.Checked = true;

                count++;
                foreach (var item in bangtopping.AsEnumerable())
                {
                    if (item.Field<string>("TenMon") == "Không Topping")
                    {
                        continue;
                    }
                    GunaRadioButton topping = new GunaRadioButton();
                    topping.Location = new System.Drawing.Point(5, count * 30);
                    topping.Text = MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<string>("TenMon") + "\n" + MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<double>("GiaTien").ToString() + "vnđ";
                    topping.Name = item.Field<string>("MaMon");
                    topping.Click += Topping_Click;
                    PanelTopping.Controls.Add(topping);
                    if (cart.MaTopping == topping.Name)
                        topping.Checked = true;
                    count++;
                }
                //Hiệu ứng mở ảnh
                //gunaTransition1.ShowSync(Anh);
            }
            catch { }
        }

       
            //Khi click vào món
        private void Pic_Click(object sender, EventArgs e)
        {
            try
            {
                //gunaTransition1.HideSync(Anh);
                //gunaTransition1.ShowSync(Anh);
                itemdangchon = int.Parse(((GunaPictureBox)sender).Name);

                cart = listcart[int.Parse(((GunaPictureBox)sender).Name)];
                SoLuong.Value = cart.SoLuong;
                if (cart.Size == "M")
                {
                    SizeM.BaseColor = Color.Blue;
                    SizeL.BaseColor = Color.MediumSlateBlue;
                }
                else
                {
                    SizeM.BaseColor = Color.MediumSlateBlue;
                    SizeL.BaseColor = Color.Blue;
                }
                if (cart.Duong == "30")
                {
                    Duong30.BaseColor = Color.Blue;
                    Duong50.BaseColor = Color.MediumSlateBlue;
                    Duong70.BaseColor = Color.MediumSlateBlue;
                    Duong100.BaseColor = Color.MediumSlateBlue;


                }
                else if (cart.Duong == "70")
                {
                    Duong30.BaseColor = Color.MediumSlateBlue;
                    Duong50.BaseColor = Color.MediumSlateBlue;
                    Duong70.BaseColor = Color.Blue;
                    Duong100.BaseColor = Color.MediumSlateBlue;
                }
                else if (cart.Duong == "50")
                {
                    Duong30.BaseColor = Color.MediumSlateBlue;
                    Duong50.BaseColor = Color.Blue;
                    Duong70.BaseColor = Color.MediumSlateBlue;
                    Duong100.BaseColor = Color.MediumSlateBlue;
                }
                else if (cart.Duong == "100")
                {
                    Duong30.BaseColor = Color.MediumSlateBlue;
                    Duong50.BaseColor = Color.MediumSlateBlue;
                    Duong70.BaseColor = Color.MediumSlateBlue;
                    Duong100.BaseColor = Color.Blue;
                }
                if (cart.Da == "30")
                {
                    Da30.BaseColor = Color.Blue;
                    Da50.BaseColor = Color.MediumSlateBlue;
                    Da70.BaseColor = Color.MediumSlateBlue;
                    Da100.BaseColor = Color.MediumSlateBlue;


                }
                else if (cart.Da == "70")
                {
                    Da30.BaseColor = Color.MediumSlateBlue;
                    Da50.BaseColor = Color.MediumSlateBlue;
                    Da70.BaseColor = Color.Blue;
                    Da100.BaseColor = Color.MediumSlateBlue;
                }
                else if (cart.Da == "50")
                {
                    Da30.BaseColor = Color.MediumSlateBlue;
                    Da50.BaseColor = Color.Blue;
                    Da70.BaseColor = Color.MediumSlateBlue;
                    Da100.BaseColor = Color.MediumSlateBlue;
                }
                else if (cart.Da == "100")
                {
                    Da30.BaseColor = Color.MediumSlateBlue;
                    Da50.BaseColor = Color.MediumSlateBlue;
                    Da70.BaseColor = Color.MediumSlateBlue;
                    Da100.BaseColor = Color.Blue;
                }
                //Hiện lại topping
                PanelTopping.Controls.Clear();
                DataSet danhsachtopping = MenuController.LayMenuTheoLoai("Topping",machinhanh, tk, mk);
                DataTable bangtopping = danhsachtopping.Tables[0];
                int count = 0;
                khongtopping = new GunaRadioButton();
                khongtopping.Location = new System.Drawing.Point(5, count * 30);
                khongtopping.Click += Khongtopping_Click; ;
                khongtopping.Text = "Không Topping \n 0vnđ";
                PanelTopping.Controls.Add(khongtopping);
                if (cart.MaTopping == null) khongtopping.Checked = true;

                count++;
                foreach (var item in bangtopping.AsEnumerable())
                {
                    if (item.Field<string>("TenMon") == "Không Topping")
                    {
                        continue;
                    }
                    GunaRadioButton topping = new GunaRadioButton();
                    topping.Location = new System.Drawing.Point(5, count * 30);
                    topping.Text = MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<string>("TenMon") + "\n" + MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<double>("GiaTien").ToString() + "vnđ";
                    topping.Name = item.Field<string>("MaMon");
                    topping.Click += Topping_Click;
                    PanelTopping.Controls.Add(topping);
                    if (cart.MaTopping == topping.Name)
                        topping.Checked = true;
                    count++;
                }
            }
            catch { }
        }




        private void gunaLinePanel1_Paint(object sender, PaintEventArgs e)
        {

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
            
            
            SoLuongDaChon = SoLuongDaChon - cart.SoLuong + (int)SoLuong.Value;
            cart.SoLuong = (int)SoLuong.Value;
            listcart[itemdangchon] = cart;
            
                foreach (var item in listcart)
                {
                    if (item.SoLuong == 0)
                        listcart.Remove(item);
                    if (listcart.Count() == 0)
                        break;
                }
            
            
            gunaPanel1.Controls.Clear();
            int dem = 0;
            
            //Hiện menu đã chọn
            foreach (var item in listcart)
            {
                //Khung của món
                GunaPanel MonDaChon = new GunaPanel();
                MonDaChon.Size = new System.Drawing.Size(600, 120);
                
                
                MonDaChon.Location = new System.Drawing.Point(6,dem*120);
                MonDaChon.Name = dem.ToString();
                //tên thông tin món đã chọn
                Guna.UI.WinForms.GunaLabel ten = new Guna.UI.WinForms.GunaLabel();
                ten.Location = new System.Drawing.Point(130, 0);
                ten.Name = dem.ToString();
                if (item.MaTopping != null)
                {
                    ten.Text = item.TenMon + " (Size: " + item.Size + ", Đường: " + item.Duong + "%, Đá: " + item.Da + "%)" + "\n" +
                        "Topping: " + MenuController.LayMon(item.MaTopping, tk, mk).Tables[0].Rows[0].Field<string>("TenMon") + "\n" + "x" + item.SoLuong;
                }
                else
                {
                    ten.Text = item.TenMon + " (Size: " + item.Size + ", Đường: " + item.Duong + "%, Đá: " + item.Da + "%)" + "\n" +
                        "Topping: Không topping" + "\n" + "x" + item.SoLuong;
                }
                ten.Size= new System.Drawing.Size(300, 120);
                ten.TextAlign = ContentAlignment.MiddleLeft;
                ten.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                ten.Click += Ten_Click;
                MonDaChon.Controls.Add(ten);
                //Giá tiền
                Guna.UI.WinForms.GunaLabel tien = new Guna.UI.WinForms.GunaLabel();
                tien.Location = new System.Drawing.Point(500, 0);
                tien.Name = dem.ToString();
                tien.ForeColor = Color.Red;
                if (item.Size == "M")
                {
                    if (item.MaTopping != null)
                    {
                        tien.Text = (item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")
                            + MenuController.LayMon(item.MaTopping, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien"))).ToString()+"vnđ";
                    }
                    else
                    {
                        tien.Text = (item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien"))).ToString()+"vnđ";
                    }
                }
                else if (item.Size == "L")
                {
                    if (item.MaTopping != null)
                    {
                        tien.Text = (item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")
                            + MenuController.LayMon(item.MaTopping, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien") + 5000)).ToString()+"vnđ";
                    }
                    else
                    {
                        tien.Text = (item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien") + 5000)).ToString()+"vnđ";
                    }
                }
                tien.Size = new System.Drawing.Size(150, 120);
                tien.TextAlign = ContentAlignment.MiddleLeft;
                tien.Font = new Font("Times New Roman", 13, FontStyle.Bold);
                tien.Click += Ten_Click;
                MonDaChon.Controls.Add(tien);
                //Ảnh món
                GunaPictureBox pic = new GunaPictureBox();
                pic.Name = dem.ToString();
                pic.Image = Image.FromFile("D:/Hệ quản trị cơ sở dữ liệu/Đồ án DBMS/" + item.Anh);               
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Size = new System.Drawing.Size(120, 120);
                pic.Location = new System.Drawing.Point(0, 0);
                pic.Click += Pic_Click; ;
                MonDaChon.Controls.Add(pic);
                MonDaChon.Click += MonDaChon_Click; ; 
                gunaPanel1.Controls.Add(MonDaChon);
                
                dem++;

                
            }
            //Hiện topping
            DataSet danhsachtopping = MenuController.LayMenuTheoLoai("Topping",machinhanh, tk, mk);
            DataTable bangtopping = danhsachtopping.Tables[0];
            int count = 0;
            khongtopping = new GunaRadioButton();
            khongtopping.Location = new System.Drawing.Point(5, count * 30);
            khongtopping.Click += Khongtopping_Click; ;
            khongtopping.Text = "Không Topping \n 0vnđ";
            PanelTopping.Controls.Add(khongtopping);
            count++;
            foreach (var item in bangtopping.AsEnumerable())
            {
                if (item.Field<string>("TenMon") == "Không Topping")
                {
                    continue;
                }
                GunaRadioButton topping = new GunaRadioButton();
                topping.Location = new System.Drawing.Point(5, count * 30);
                topping.Text = MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<string>("TenMon") + "\n" + MenuController.LayMon(item.Field<string>("MaMon"), tk, mk).Tables[0].Rows[0].Field<double>("GiaTien").ToString() + "vnđ";
                topping.Name = item.Field<string>("MaMon");
                topping.Click += Topping_Click;
                PanelTopping.Controls.Add(topping);
                count++;
            }
            //Hiện tổng số tiền phải thanh toán
            TongGia = 0;
            if (listcart.Count != 0)
            {
                foreach (var item in listcart)
                {
                    if (item.Size == "M")
                    {
                        if (item.MaTopping != null)
                        {
                            TongGia += item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")
                                + MenuController.LayMon(item.MaTopping, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien"));
                        }
                        else
                        {
                            TongGia += item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien"));
                        }
                    }
                    else if (item.Size == "L")
                    {
                        if (item.MaTopping != null)
                        {
                            TongGia += item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")
                                + MenuController.LayMon(item.MaTopping, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien") + 5000);
                        }
                        else
                        {
                            TongGia += item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien") + 5000);
                        }
                    }
                    lblTongTien.Text = TongGia.ToString() + "vnđ";
                }
            }
            else
                lblTongTien.Text = "0vnđ";

        }

        private void btnMuaTiep_Click(object sender, EventArgs e)
        {
            Form1 formmenu =new Form1(listcart, SoLuongDaChon, tk, mk,chucnang,machinhanh);
            formmenu.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormGiaoDien formgiaodien = new FormGiaoDien(tk, mk, chucnang);
            formgiaodien.Show();
            this.Close();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (listcart.Count != 0)
            {
                string hoadonmoi;
                DataSet mahoadonmoi = MenuController.LayMaHoaDon(tk, mk);
                try
                {
                     hoadonmoi = mahoadonmoi.Tables[0].Rows[0].Field<string>("MaHoaDon");
                    hoadonmoi = (int.Parse(hoadonmoi) + 1).ToString();
                }
                catch
                {
                     hoadonmoi = "0";


                }
                
                MenuController.ThemHoaDon("1", null, machinhanh, DateTime.Now, TongGia, hoadonmoi, ref err, tk, mk);
                foreach (var item in listcart)
                {
                    if (item.Size == "M")
                    {
                        if (item.MaTopping != null)
                        {
                            MenuController.ThemChiTietHoaDon(hoadonmoi, item.MaMon, item.SoLuong, item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")
                                + MenuController.LayMon(item.MaTopping, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")), item.MaTopping, item.Size, item.Da, item.Duong, ref err, tk, mk);
                        }
                        else
                        {
                            MenuController.ThemChiTietHoaDon(hoadonmoi, item.MaMon, item.SoLuong, item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")
                               ), item.MaTopping, item.Size, item.Da, item.Duong, ref err, tk, mk);
                        }
                    }
                    else if(item.Size=="L")
                    {

                        if (item.MaTopping != null)
                        {
                            MenuController.ThemChiTietHoaDon(hoadonmoi, item.MaMon, item.SoLuong, item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")
                                + MenuController.LayMon(item.MaTopping, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")+5000), item.MaTopping, item.Size, item.Da, item.Duong, ref err, tk, mk);
                        }
                        else
                        {
                            MenuController.ThemChiTietHoaDon(hoadonmoi, item.MaMon, item.SoLuong, item.SoLuong * (MenuController.LayMon(item.MaMon, tk, mk).Tables[0].Rows[0].Field<double>("GiaTien")
                             +5000  ), item.MaTopping, item.Size, item.Da, item.Duong, ref err, tk, mk);
                        }
                    }
                }
                MessageBox.Show("Thanh Toán thành công","OK");
                gunaPanel1.Controls.Clear();
                listcart.Clear();
                SoLuongDaChon = 0;
                lblTongTien.Text = "0vnđ";
                cart = new GioHang();
                Duong30.BaseColor = Color.MediumSlateBlue;
                Duong50.BaseColor = Color.MediumSlateBlue;
                Duong70.BaseColor = Color.MediumSlateBlue;
                Duong100.BaseColor = Color.MediumSlateBlue;
                Da30.BaseColor = Color.MediumSlateBlue;
                Da50.BaseColor = Color.MediumSlateBlue;
                Da70.BaseColor = Color.MediumSlateBlue;
                Da100.BaseColor = Color.MediumSlateBlue;
                SizeM.BaseColor = Color.MediumSlateBlue;
                SizeL.BaseColor = Color.MediumSlateBlue;
                
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm! Mời bạn mua sản phẩm", "OK");

            }
        }
    }
}
