namespace GUI
{
    partial class frm_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelQLThongKe = new System.Windows.Forms.Panel();
            this.btnTKDate = new System.Windows.Forms.Button();
            this.btnTKDoanhThu = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.panelQLThucDon = new System.Windows.Forms.Panel();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnThucDon = new System.Windows.Forms.Button();
            this.btnQLThucDon = new System.Windows.Forms.Button();
            this.panelQLNhanVien = new System.Windows.Forms.Panel();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnQLNhanVien = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbTongKH = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbTongDT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.database = new QuanLyBanHang.Database();
            this.thucDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.thucDonTableAdapter = new QuanLyBanHang.DatabaseTableAdapters.ThucDonTableAdapter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbTongNV = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbTongTD = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelSideMenu.SuspendLayout();
            this.panelQLThongKe.SuspendLayout();
            this.panelQLThucDon.SuspendLayout();
            this.panelQLNhanVien.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelChildForm.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.database)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thucDonBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panelSideMenu.Controls.Add(this.panelQLThongKe);
            this.panelSideMenu.Controls.Add(this.btnThongKe);
            this.panelSideMenu.Controls.Add(this.btnKhachHang);
            this.panelSideMenu.Controls.Add(this.btnHoaDon);
            this.panelSideMenu.Controls.Add(this.btnDangXuat);
            this.panelSideMenu.Controls.Add(this.panelQLThucDon);
            this.panelSideMenu.Controls.Add(this.btnQLThucDon);
            this.panelSideMenu.Controls.Add(this.panelQLNhanVien);
            this.panelSideMenu.Controls.Add(this.btnQLNhanVien);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 550);
            this.panelSideMenu.TabIndex = 0;
            // 
            // panelQLThongKe
            // 
            this.panelQLThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelQLThongKe.Controls.Add(this.btnTKDate);
            this.panelQLThongKe.Controls.Add(this.btnTKDoanhThu);
            this.panelQLThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQLThongKe.Location = new System.Drawing.Point(0, 485);
            this.panelQLThongKe.Name = "panelQLThongKe";
            this.panelQLThongKe.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelQLThongKe.Size = new System.Drawing.Size(233, 80);
            this.panelQLThongKe.TabIndex = 12;
            // 
            // btnTKDate
            // 
            this.btnTKDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnTKDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTKDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTKDate.FlatAppearance.BorderSize = 0;
            this.btnTKDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTKDate.ForeColor = System.Drawing.Color.LightGray;
            this.btnTKDate.Image = ((System.Drawing.Image)(resources.GetObject("btnTKDate.Image")));
            this.btnTKDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTKDate.Location = new System.Drawing.Point(0, 40);
            this.btnTKDate.Name = "btnTKDate";
            this.btnTKDate.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTKDate.Size = new System.Drawing.Size(233, 40);
            this.btnTKDate.TabIndex = 2;
            this.btnTKDate.Text = "        Doanh thu";
            this.btnTKDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTKDate.UseVisualStyleBackColor = false;
            this.btnTKDate.Click += new System.EventHandler(this.btnTKDate_Click);
            // 
            // btnTKDoanhThu
            // 
            this.btnTKDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnTKDoanhThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTKDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTKDoanhThu.FlatAppearance.BorderSize = 0;
            this.btnTKDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTKDoanhThu.ForeColor = System.Drawing.Color.LightGray;
            this.btnTKDoanhThu.Image = ((System.Drawing.Image)(resources.GetObject("btnTKDoanhThu.Image")));
            this.btnTKDoanhThu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTKDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.btnTKDoanhThu.Name = "btnTKDoanhThu";
            this.btnTKDoanhThu.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTKDoanhThu.Size = new System.Drawing.Size(233, 40);
            this.btnTKDoanhThu.TabIndex = 0;
            this.btnTKDoanhThu.Text = "        Hóa đơn";
            this.btnTKDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTKDoanhThu.UseVisualStyleBackColor = false;
            this.btnTKDoanhThu.Click += new System.EventHandler(this.btnTKDoanhThu_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(0, 440);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnThongKe.Size = new System.Drawing.Size(233, 45);
            this.btnThongKe.TabIndex = 11;
            this.btnThongKe.Text = "        Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.Image")));
            this.btnKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 395);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnKhachHang.Size = new System.Drawing.Size(233, 45);
            this.btnKhachHang.TabIndex = 9;
            this.btnKhachHang.Text = "        Khách hàng";
            this.btnKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.UseVisualStyleBackColor = false;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btnHoaDon.Image")));
            this.btnHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoaDon.Location = new System.Drawing.Point(0, 350);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHoaDon.Size = new System.Drawing.Size(233, 45);
            this.btnHoaDon.TabIndex = 7;
            this.btnHoaDon.Text = "        Quản lý hóa đơn";
            this.btnHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoaDon.UseVisualStyleBackColor = false;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.Image")));
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 565);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDangXuat.Size = new System.Drawing.Size(233, 45);
            this.btnDangXuat.TabIndex = 6;
            this.btnDangXuat.Text = "         Đăng xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // panelQLThucDon
            // 
            this.panelQLThucDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelQLThucDon.Controls.Add(this.btnDanhMuc);
            this.panelQLThucDon.Controls.Add(this.btnThucDon);
            this.panelQLThucDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQLThucDon.Location = new System.Drawing.Point(0, 270);
            this.panelQLThucDon.Name = "panelQLThucDon";
            this.panelQLThucDon.Size = new System.Drawing.Size(233, 80);
            this.panelQLThucDon.TabIndex = 5;
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnDanhMuc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDanhMuc.FlatAppearance.BorderSize = 0;
            this.btnDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhMuc.ForeColor = System.Drawing.Color.LightGray;
            this.btnDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhMuc.Image")));
            this.btnDanhMuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhMuc.Location = new System.Drawing.Point(0, 40);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnDanhMuc.Size = new System.Drawing.Size(233, 40);
            this.btnDanhMuc.TabIndex = 5;
            this.btnDanhMuc.Text = "        Danh mục thực đơn";
            this.btnDanhMuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhMuc.UseVisualStyleBackColor = false;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnThucDon
            // 
            this.btnThucDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnThucDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThucDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThucDon.FlatAppearance.BorderSize = 0;
            this.btnThucDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThucDon.ForeColor = System.Drawing.Color.LightGray;
            this.btnThucDon.Image = ((System.Drawing.Image)(resources.GetObject("btnThucDon.Image")));
            this.btnThucDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThucDon.Location = new System.Drawing.Point(0, 0);
            this.btnThucDon.Name = "btnThucDon";
            this.btnThucDon.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnThucDon.Size = new System.Drawing.Size(233, 40);
            this.btnThucDon.TabIndex = 4;
            this.btnThucDon.Text = "        Thực đơn";
            this.btnThucDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThucDon.UseVisualStyleBackColor = false;
            this.btnThucDon.Click += new System.EventHandler(this.btnThucDon_Click);
            // 
            // btnQLThucDon
            // 
            this.btnQLThucDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnQLThucDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLThucDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLThucDon.FlatAppearance.BorderSize = 0;
            this.btnQLThucDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLThucDon.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQLThucDon.Image = ((System.Drawing.Image)(resources.GetObject("btnQLThucDon.Image")));
            this.btnQLThucDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLThucDon.Location = new System.Drawing.Point(0, 225);
            this.btnQLThucDon.Name = "btnQLThucDon";
            this.btnQLThucDon.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQLThucDon.Size = new System.Drawing.Size(233, 45);
            this.btnQLThucDon.TabIndex = 4;
            this.btnQLThucDon.Text = "        Quản lý thực đơn";
            this.btnQLThucDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLThucDon.UseVisualStyleBackColor = false;
            this.btnQLThucDon.Click += new System.EventHandler(this.btnQLThucDon_Click);
            // 
            // panelQLNhanVien
            // 
            this.panelQLNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelQLNhanVien.Controls.Add(this.btnNhanVien);
            this.panelQLNhanVien.Controls.Add(this.btnTaiKhoan);
            this.panelQLNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQLNhanVien.Location = new System.Drawing.Point(0, 145);
            this.panelQLNhanVien.Name = "panelQLNhanVien";
            this.panelQLNhanVien.Size = new System.Drawing.Size(233, 80);
            this.panelQLNhanVien.TabIndex = 2;
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhanVien.FlatAppearance.BorderSize = 0;
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.ForeColor = System.Drawing.Color.LightGray;
            this.btnNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.Image")));
            this.btnNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.Location = new System.Drawing.Point(0, 40);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnNhanVien.Size = new System.Drawing.Size(233, 40);
            this.btnNhanVien.TabIndex = 6;
            this.btnNhanVien.Text = "        Nhân viên";
            this.btnNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.UseVisualStyleBackColor = false;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.LightGray;
            this.btnTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnTaiKhoan.Image")));
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTaiKhoan.Size = new System.Drawing.Size(233, 40);
            this.btnTaiKhoan.TabIndex = 5;
            this.btnTaiKhoan.Text = "        Tài khoản";
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.UseVisualStyleBackColor = false;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnQLNhanVien
            // 
            this.btnQLNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnQLNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLNhanVien.FlatAppearance.BorderSize = 0;
            this.btnQLNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLNhanVien.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQLNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btnQLNhanVien.Image")));
            this.btnQLNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLNhanVien.Location = new System.Drawing.Point(0, 100);
            this.btnQLNhanVien.Name = "btnQLNhanVien";
            this.btnQLNhanVien.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQLNhanVien.Size = new System.Drawing.Size(233, 45);
            this.btnQLNhanVien.TabIndex = 1;
            this.btnQLNhanVien.Text = "        Quản lý nhân viên";
            this.btnQLNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLNhanVien.UseVisualStyleBackColor = false;
            this.btnQLNhanVien.Click += new System.EventHandler(this.btnQLNhanVien_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Transparent;
            this.panelLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLogo.BackgroundImage")));
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(233, 100);
            this.panelLogo.TabIndex = 0;
            this.panelLogo.Click += new System.EventHandler(this.panelLogo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(250, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 60);
            this.panel1.TabIndex = 1;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Close.Image = global::QuanLyBanHang.Properties.Resources.icons8_close_26;
            this.btn_Close.Location = new System.Drawing.Point(791, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(26, 26);
            this.btn_Close.TabIndex = 8;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lbTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTitle.Location = new System.Drawing.Point(330, 20);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(79, 20);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "QUẢN LÝ";
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.SystemColors.Control;
            this.panelChildForm.Controls.Add(this.panel5);
            this.panelChildForm.Controls.Add(this.panel4);
            this.panelChildForm.Controls.Add(this.panel3);
            this.panelChildForm.Controls.Add(this.chart2);
            this.panelChildForm.Controls.Add(this.chart1);
            this.panelChildForm.Controls.Add(this.panel2);
            this.panelChildForm.Location = new System.Drawing.Point(260, 70);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(800, 470);
            this.panelChildForm.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel4.Controls.Add(this.lbTongKH);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(410, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(180, 100);
            this.panel4.TabIndex = 4;
            // 
            // lbTongKH
            // 
            this.lbTongKH.AutoSize = true;
            this.lbTongKH.ForeColor = System.Drawing.SystemColors.Control;
            this.lbTongKH.Location = new System.Drawing.Point(46, 60);
            this.lbTongKH.Name = "lbTongKH";
            this.lbTongKH.Size = new System.Drawing.Size(23, 17);
            this.lbTongKH.TabIndex = 1;
            this.lbTongKH.Text = "số";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(46, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tổng khách hàng";
            // 
            // chart2
            // 
            chartArea11.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chart2.Legends.Add(legend11);
            this.chart2.Location = new System.Drawing.Point(2, 170);
            this.chart2.Name = "chart2";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.chart2.Series.Add(series11);
            this.chart2.Size = new System.Drawing.Size(400, 300);
            this.chart2.TabIndex = 3;
            this.chart2.Text = "chart2";
            // 
            // chart1
            // 
            chartArea12.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.chart1.Legends.Add(legend12);
            this.chart1.Location = new System.Drawing.Point(400, 170);
            this.chart1.Name = "chart1";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.chart1.Series.Add(series12);
            this.chart1.Size = new System.Drawing.Size(400, 300);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Controls.Add(this.lbTongDT);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 100);
            this.panel2.TabIndex = 1;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // lbTongDT
            // 
            this.lbTongDT.AutoSize = true;
            this.lbTongDT.ForeColor = System.Drawing.SystemColors.Control;
            this.lbTongDT.Location = new System.Drawing.Point(46, 60);
            this.lbTongDT.Name = "lbTongDT";
            this.lbTongDT.Size = new System.Drawing.Size(23, 17);
            this.lbTongDT.TabIndex = 1;
            this.lbTongDT.Text = "số";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(46, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng doanh thu";
            // 
            // database
            // 
            this.database.DataSetName = "Database";
            this.database.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // thucDonBindingSource
            // 
            this.thucDonBindingSource.DataMember = "ThucDon";
            this.thucDonBindingSource.DataSource = this.database;
            // 
            // thucDonTableAdapter
            // 
            this.thucDonTableAdapter.ClearBeforeFill = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel3.Controls.Add(this.lbTongNV);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(205, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 100);
            this.panel3.TabIndex = 4;
            // 
            // lbTongNV
            // 
            this.lbTongNV.AutoSize = true;
            this.lbTongNV.ForeColor = System.Drawing.SystemColors.Control;
            this.lbTongNV.Location = new System.Drawing.Point(46, 60);
            this.lbTongNV.Name = "lbTongNV";
            this.lbTongNV.Size = new System.Drawing.Size(23, 17);
            this.lbTongNV.TabIndex = 1;
            this.lbTongNV.Text = "số";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(46, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng nhân viên";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel5.Controls.Add(this.lbTongTD);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel5.Location = new System.Drawing.Point(620, 30);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(180, 100);
            this.panel5.TabIndex = 5;
            // 
            // lbTongTD
            // 
            this.lbTongTD.AutoSize = true;
            this.lbTongTD.ForeColor = System.Drawing.SystemColors.Control;
            this.lbTongTD.Location = new System.Drawing.Point(46, 60);
            this.lbTongTD.Name = "lbTongTD";
            this.lbTongTD.Size = new System.Drawing.Size(23, 17);
            this.lbTongTD.TabIndex = 1;
            this.lbTongTD.Text = "số";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(46, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tổng thực đơn";
            // 
            // frm_Main
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 550);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý";
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelQLThongKe.ResumeLayout(false);
            this.panelQLThucDon.ResumeLayout(false);
            this.panelQLNhanVien.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelChildForm.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.database)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thucDonBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btnQLNhanVien;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelQLNhanVien;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panelQLThucDon;
        private System.Windows.Forms.Button btnQLThucDon;
        private System.Windows.Forms.Label lbTitle;
        private QuanLyBanHang.Database database;
        private System.Windows.Forms.BindingSource thucDonBindingSource;
        private QuanLyBanHang.DatabaseTableAdapters.ThucDonTableAdapter thucDonTableAdapter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTongDT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnThucDon;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Panel panelQLThongKe;
        private System.Windows.Forms.Button btnTKDoanhThu;
        private System.Windows.Forms.Button btnTKDate;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbTongKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbTongNV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbTongTD;
        private System.Windows.Forms.Label label7;
    }
}