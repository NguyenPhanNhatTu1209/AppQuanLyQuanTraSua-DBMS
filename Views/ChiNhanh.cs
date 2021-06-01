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
    public partial class ChiNhanh : Form
    {
        string tk, mk;
        int chucnang;

        private void gunaLinePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public ChiNhanh(string tk, string mk, int chucnang)
        {
            InitializeComponent();
            this.tk = tk;
            this.mk = mk;
            this.chucnang = chucnang;
            DataSet chinhanh = ChiNhanhController.LayCN(tk, mk);
            int dem = 0;
            foreach (var item in chinhanh.Tables[0].AsEnumerable())
            {
                //Khung của món
                Guna.UI.WinForms.GunaAdvenceButton abc = new Guna.UI.WinForms.GunaAdvenceButton();
                abc.TextAlign = HorizontalAlignment.Center;
                abc.BaseColor = Color.Transparent;
                abc.BorderColor = Color.Black;
                abc.BorderSize = 3;
                abc.Radius = 4;
                abc.ForeColor = Color.Black;
                abc.Visible = true;
                abc.Size = new System.Drawing.Size(180, 80);
                abc.Text = item.Field<string>("TenChiNhanh");
                abc.Location = new System.Drawing.Point(6, dem * 90);
                abc.Name = item.Field<string>("MaChiNhanh");
                abc.Click += Abc_Click;
                labelChiNhanh.Controls.Add(abc);
                dem++;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormGiaoDien formgiaodien = new FormGiaoDien(tk, mk, chucnang);
            formgiaodien.Show();
            this.Close();
        }

        private void Abc_Click(object sender, EventArgs e)
        {
            List<GioHang> a = new List<GioHang>();
            Form1 formmuahang = new Form1(a, 0, tk, mk, chucnang, ((Guna.UI.WinForms.GunaAdvenceButton)sender).Name);
            formmuahang.Show();
            this.Close();
        }
    }

       
    }
