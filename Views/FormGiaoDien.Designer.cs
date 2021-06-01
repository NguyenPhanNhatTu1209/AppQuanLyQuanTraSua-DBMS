namespace Đồ_án_DBMS.Views
{
    partial class FormGiaoDien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGiaoDien));
            this.gunaLinePanel1 = new Guna.UI.WinForms.GunaLinePanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.btnThongTinCaNhan = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btnQuanLy = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btnMuaHang = new Guna.UI.WinForms.GunaAdvenceButton();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.btnLogOut = new Guna.UI.WinForms.GunaAdvenceButton();
            this.gunaLinePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gunaPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaLinePanel1
            // 
            this.gunaLinePanel1.AutoScroll = true;
            this.gunaLinePanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.gunaLinePanel1.Controls.Add(this.pictureBox1);
            this.gunaLinePanel1.Controls.Add(this.gunaPanel1);
            this.gunaLinePanel1.Controls.Add(this.gunaControlBox2);
            this.gunaLinePanel1.Controls.Add(this.gunaControlBox1);
            this.gunaLinePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaLinePanel1.LineBottom = 3;
            this.gunaLinePanel1.LineColor = System.Drawing.Color.Black;
            this.gunaLinePanel1.LineLeft = 3;
            this.gunaLinePanel1.LineRight = 3;
            this.gunaLinePanel1.LineStyle = System.Windows.Forms.BorderStyle.None;
            this.gunaLinePanel1.LineTop = 3;
            this.gunaLinePanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaLinePanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gunaLinePanel1.Name = "gunaLinePanel1";
            this.gunaLinePanel1.Size = new System.Drawing.Size(699, 748);
            this.gunaLinePanel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(53, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(592, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.AutoScroll = true;
            this.gunaPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gunaPanel1.Controls.Add(this.btnLogOut);
            this.gunaPanel1.Controls.Add(this.btnThongTinCaNhan);
            this.gunaPanel1.Controls.Add(this.btnQuanLy);
            this.gunaPanel1.Controls.Add(this.btnMuaHang);
            this.gunaPanel1.Location = new System.Drawing.Point(53, 260);
            this.gunaPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(592, 446);
            this.gunaPanel1.TabIndex = 10;
            this.gunaPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gunaPanel1_Paint);
            // 
            // btnThongTinCaNhan
            // 
            this.btnThongTinCaNhan.AnimationHoverSpeed = 0.07F;
            this.btnThongTinCaNhan.AnimationSpeed = 0.03F;
            this.btnThongTinCaNhan.BackColor = System.Drawing.Color.Transparent;
            this.btnThongTinCaNhan.BaseColor = System.Drawing.Color.Transparent;
            this.btnThongTinCaNhan.BorderColor = System.Drawing.Color.Black;
            this.btnThongTinCaNhan.BorderSize = 3;
            this.btnThongTinCaNhan.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnThongTinCaNhan.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnThongTinCaNhan.CheckedForeColor = System.Drawing.Color.White;
            this.btnThongTinCaNhan.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnThongTinCaNhan.CheckedImage")));
            this.btnThongTinCaNhan.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnThongTinCaNhan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnThongTinCaNhan.FocusedColor = System.Drawing.Color.Empty;
            this.btnThongTinCaNhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongTinCaNhan.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnThongTinCaNhan.Image = null;
            this.btnThongTinCaNhan.ImageSize = new System.Drawing.Size(20, 20);
            this.btnThongTinCaNhan.LineColor = System.Drawing.Color.Transparent;
            this.btnThongTinCaNhan.Location = new System.Drawing.Point(169, 255);
            this.btnThongTinCaNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThongTinCaNhan.Name = "btnThongTinCaNhan";
            this.btnThongTinCaNhan.OnHoverBaseColor = System.Drawing.Color.Transparent;
            this.btnThongTinCaNhan.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnThongTinCaNhan.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnThongTinCaNhan.OnHoverImage = null;
            this.btnThongTinCaNhan.OnHoverLineColor = System.Drawing.Color.Indigo;
            this.btnThongTinCaNhan.OnPressedColor = System.Drawing.Color.Black;
            this.btnThongTinCaNhan.Radius = 6;
            this.btnThongTinCaNhan.Size = new System.Drawing.Size(249, 69);
            this.btnThongTinCaNhan.TabIndex = 26;
            this.btnThongTinCaNhan.Text = "Thông tin cá nhân";
            this.btnThongTinCaNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnThongTinCaNhan.Click += new System.EventHandler(this.btnThongTinCaNhan_Click);
            // 
            // btnQuanLy
            // 
            this.btnQuanLy.AnimationHoverSpeed = 0.07F;
            this.btnQuanLy.AnimationSpeed = 0.03F;
            this.btnQuanLy.BackColor = System.Drawing.Color.Transparent;
            this.btnQuanLy.BaseColor = System.Drawing.Color.Transparent;
            this.btnQuanLy.BorderColor = System.Drawing.Color.Black;
            this.btnQuanLy.BorderSize = 3;
            this.btnQuanLy.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnQuanLy.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnQuanLy.CheckedForeColor = System.Drawing.Color.White;
            this.btnQuanLy.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnQuanLy.CheckedImage")));
            this.btnQuanLy.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnQuanLy.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnQuanLy.FocusedColor = System.Drawing.Color.Empty;
            this.btnQuanLy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLy.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnQuanLy.Image = null;
            this.btnQuanLy.ImageSize = new System.Drawing.Size(20, 20);
            this.btnQuanLy.LineColor = System.Drawing.Color.Transparent;
            this.btnQuanLy.Location = new System.Drawing.Point(169, 150);
            this.btnQuanLy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLy.Name = "btnQuanLy";
            this.btnQuanLy.OnHoverBaseColor = System.Drawing.Color.Transparent;
            this.btnQuanLy.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnQuanLy.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnQuanLy.OnHoverImage = null;
            this.btnQuanLy.OnHoverLineColor = System.Drawing.Color.Indigo;
            this.btnQuanLy.OnPressedColor = System.Drawing.Color.Black;
            this.btnQuanLy.Radius = 6;
            this.btnQuanLy.Size = new System.Drawing.Size(249, 69);
            this.btnQuanLy.TabIndex = 25;
            this.btnQuanLy.Text = "Quản lý";
            this.btnQuanLy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnQuanLy.Click += new System.EventHandler(this.btnQuanLy_Click);
            // 
            // btnMuaHang
            // 
            this.btnMuaHang.AnimationHoverSpeed = 0.07F;
            this.btnMuaHang.AnimationSpeed = 0.03F;
            this.btnMuaHang.BackColor = System.Drawing.Color.Transparent;
            this.btnMuaHang.BaseColor = System.Drawing.Color.Transparent;
            this.btnMuaHang.BorderColor = System.Drawing.Color.Black;
            this.btnMuaHang.BorderSize = 3;
            this.btnMuaHang.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnMuaHang.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnMuaHang.CheckedForeColor = System.Drawing.Color.White;
            this.btnMuaHang.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnMuaHang.CheckedImage")));
            this.btnMuaHang.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnMuaHang.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMuaHang.FocusedColor = System.Drawing.Color.Empty;
            this.btnMuaHang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuaHang.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnMuaHang.Image = null;
            this.btnMuaHang.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMuaHang.LineColor = System.Drawing.Color.Transparent;
            this.btnMuaHang.Location = new System.Drawing.Point(169, 54);
            this.btnMuaHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMuaHang.Name = "btnMuaHang";
            this.btnMuaHang.OnHoverBaseColor = System.Drawing.Color.Transparent;
            this.btnMuaHang.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMuaHang.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnMuaHang.OnHoverImage = null;
            this.btnMuaHang.OnHoverLineColor = System.Drawing.Color.Indigo;
            this.btnMuaHang.OnPressedColor = System.Drawing.Color.Black;
            this.btnMuaHang.Radius = 6;
            this.btnMuaHang.Size = new System.Drawing.Size(249, 69);
            this.btnMuaHang.TabIndex = 24;
            this.btnMuaHang.Text = "Mua hàng";
            this.btnMuaHang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnMuaHang.Click += new System.EventHandler(this.btnMuaHang_Click);
            // 
            // gunaControlBox2
            // 
            this.gunaControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox2.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox2.AnimationSpeed = 0.03F;
            this.gunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox2.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox2.IconSize = 15F;
            this.gunaControlBox2.Location = new System.Drawing.Point(600, 2);
            this.gunaControlBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gunaControlBox2.Name = "gunaControlBox2";
            this.gunaControlBox2.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBox2.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox2.Size = new System.Drawing.Size(45, 30);
            this.gunaControlBox2.TabIndex = 1;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(651, 2);
            this.gunaControlBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 30);
            this.gunaControlBox1.TabIndex = 0;
            // 
            // btnLogOut
            // 
            this.btnLogOut.AnimationHoverSpeed = 0.07F;
            this.btnLogOut.AnimationSpeed = 0.03F;
            this.btnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.BaseColor = System.Drawing.Color.Transparent;
            this.btnLogOut.BorderColor = System.Drawing.Color.Black;
            this.btnLogOut.BorderSize = 3;
            this.btnLogOut.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnLogOut.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnLogOut.CheckedForeColor = System.Drawing.Color.White;
            this.btnLogOut.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnLogOut.CheckedImage")));
            this.btnLogOut.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnLogOut.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogOut.FocusedColor = System.Drawing.Color.Empty;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnLogOut.Image = null;
            this.btnLogOut.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLogOut.LineColor = System.Drawing.Color.Transparent;
            this.btnLogOut.Location = new System.Drawing.Point(14, 359);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.OnHoverBaseColor = System.Drawing.Color.Transparent;
            this.btnLogOut.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLogOut.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnLogOut.OnHoverImage = null;
            this.btnLogOut.OnHoverLineColor = System.Drawing.Color.Indigo;
            this.btnLogOut.OnPressedColor = System.Drawing.Color.Black;
            this.btnLogOut.Radius = 6;
            this.btnLogOut.Size = new System.Drawing.Size(115, 59);
            this.btnLogOut.TabIndex = 48;
            this.btnLogOut.Text = "Đăng Xuất";
            this.btnLogOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // FormGiaoDien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 748);
            this.Controls.Add(this.gunaLinePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormGiaoDien";
            this.Text = "FormGiaoDien";
            this.gunaLinePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gunaPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaLinePanel gunaLinePanel1;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Guna.UI.WinForms.GunaAdvenceButton btnThongTinCaNhan;
        private Guna.UI.WinForms.GunaAdvenceButton btnQuanLy;
        private Guna.UI.WinForms.GunaAdvenceButton btnMuaHang;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI.WinForms.GunaAdvenceButton btnLogOut;
    }
}