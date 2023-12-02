using QuanLy;
using QuanLyBanHang;
using QuanLyBanHang.Class;
using QuanLyBanHang.Report;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class frm_Main : Form
    {
        private string  Quyen;

        public frm_Main()
        {
            InitializeComponent();
            customizeDesing();
        }

        public frm_Main(string Quyen)
        {
            InitializeComponent();
            customizeDesing();
            this.Quyen = Quyen;

            if (Quyen == "User")
            {
                btnQLNhanVien.Visible = false;
                btnTaiKhoan.Visible = false;
                btnNhanVien.Visible = false;
                //panelHoaDonSubMenu.Size = new Size(330, 45);
            }
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            Functions.Connect(); //Mở kết nốiư
            SqlConnection conn = new SqlConnection();
            Functions.Connect(conn);
            hideSubMenu();
            ThongKeTongDoanhThu();
            LoadPieChart();
            LoadMonthlyRevenueChart();
            ThongKeSoluong_TongDoanhThu();
        }
        private void customizeDesing()
        {
            panelQLNhanVien.Visible = false;
            panelQLThucDon.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelQLNhanVien.Visible == true)
                panelQLNhanVien.Visible = false;
            if (panelQLThucDon.Visible == true)
                panelQLThucDon.Visible = false;
            if (panelQLThongKe.Visible == true)
                panelQLThongKe.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panelLogo_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            lbTitle.Text = "QUẢN LÝ CĂNG TIN";
            ThongKeTongDoanhThu();
            LoadPieChart();
            LoadMonthlyRevenueChart();
            ThongKeSoluong_TongDoanhThu();
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQLNhanVien);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_TaiKhoan());
            hideSubMenu();
            lbTitle.Text = btnTaiKhoan.Text;
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_NguoiDung());
            hideSubMenu();
            lbTitle.Text = btnNhanVien.Text;
        }

        private void btnQLThucDon_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQLThucDon);
        }

        private void btnThucDon_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_ThucDon(Quyen));
            hideSubMenu();
            lbTitle.Text = btnThucDon.Text;
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_DMThucDon(Quyen));
            hideSubMenu();
            lbTitle.Text = btnDanhMuc.Text;
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_HoaDon());
            hideSubMenu();
            lbTitle.Text = btnHoaDon.Text;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_KhachHang());
            hideSubMenu();
            lbTitle.Text = btnKhachHang.Text;
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQLThongKe);
        }

        private void btnTKDoanhThu_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_ReportHoaDon());
            hideSubMenu();
            lbTitle.Text = btnTKDoanhThu.Text;
        }

        private void btnTKDate_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_ReportDoanhThuDate());
            hideSubMenu();
            lbTitle.Text = btnTKDate.Text;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_DangNhap frm = new frm_DangNhap();
            frm.Show();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void ThongKeTongDoanhThu()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Functions.Connect(conn);

                SqlCommand cmd = new SqlCommand("SELECT SUM(TongTien) FROM HoaDon", conn);

                double DoanhThu = (double)cmd.ExecuteScalar();

                conn.Close();

                // Áp dụng định dạng số cho tổng doanh thu
                string formattedDoanhThu = string.Format("{0:N0} VND", DoanhThu);

                lbTongDT.Text = formattedDoanhThu;
            }
        }

        private void LoadPieChart()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Functions.Connect(conn);

                string query = @"SELECT TOP 5 TD.TenMon, SUM(CTHD.ThanhTien) AS DoanhThu
                        FROM ThucDon TD
                        INNER JOIN ChiTietHD CTHD ON TD.MaMon = CTHD.MaMon
                        GROUP BY TD.TenMon
                        ORDER BY SUM(CTHD.ThanhTien) DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                chart1.Series.Clear();
                chart1.Series.Add("DoanhThu");
                chart1.Series["DoanhThu"].ChartType = SeriesChartType.Pie;

                while (reader.Read())
                {
                    string tenMon = reader.GetString(reader.GetOrdinal("TenMon"));
                    double doanhThu = reader.GetDouble(reader.GetOrdinal("DoanhThu"));

                    DataPoint dataPoint = new DataPoint();
                    dataPoint.SetValueXY(tenMon, doanhThu);
                    dataPoint.Label = string.Format("{0:N0} VND", doanhThu);
                    chart1.Series["DoanhThu"].Points.Add(dataPoint);
                }
                // Hiển thị phụ lục tên món
                chart1.Series["DoanhThu"].LegendText = "#AXISLABEL";
            }
        }
        private void LoadMonthlyRevenueChart()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Functions.Connect(conn);

                string query = @"SELECT MONTH(NgayBan) AS Thang, SUM(TongTien) AS DoanhThu
                        FROM HoaDon
                        WHERE YEAR(NgayBan) = YEAR(GETDATE()) -- Lấy dữ liệu trong năm hiện tại
                        GROUP BY MONTH(NgayBan)
                        ORDER BY Thang";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Xóa dữ liệu cũ trên biểu đồ
                chart2.Series.Clear();

                // Tạo dòng dữ liệu cho biểu đồ
                Series series = new Series("DoanhThu");
                series.ChartType = SeriesChartType.Column;

                // Thêm dữ liệu từ SqlDataReader vào dòng
                while (reader.Read())
                {
                    int thang = reader.GetInt32(reader.GetOrdinal("Thang"));
                    double doanhThu = reader.GetDouble(reader.GetOrdinal("DoanhThu"));

                    DataPoint dataPoint = new DataPoint();
                    dataPoint.SetValueXY(thang, doanhThu);
                    dataPoint.Label = string.Format("{1:N0} VND", thang, doanhThu);
                    series.Points.Add(dataPoint);
                }

                // Thêm dòng vào biểu đồ
                chart2.Series.Add(series);

                // Đặt tên trục x và trục y
                //chart2.ChartAreas[0].AxisX.Title = "Tháng";
                chart2.ChartAreas[0].AxisY.Title = "Doanh thu (VND)";

                // Cập nhật biểu đồ
                chart2.Update();
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            frm_ReportDoanhThu frm = new frm_ReportDoanhThu();
            frm.ShowDialog();
        }

        private void ThongKeSoluong_TongDoanhThu()
        {
            SqlConnection conn = new SqlConnection();
            Functions.Connect(conn);

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM NguoiDung", conn);

            // Thực thi câu truy vấn SQL và lấy kết quả
            int countND = (int)command.ExecuteScalar();
            lbTongNV.Text = countND.ToString();

            
            // Tạo đối tượng SqlCommand để thực thi câu truy vấn SQL đơn giản
            command = new SqlCommand("SELECT COUNT(*) FROM KhachHang", conn);
            // Thực thi câu truy vấn SQL và lấy kết quả
            int countKH = (int)command.ExecuteScalar();
            lbTongKH.Text = countKH.ToString();

            // Tạo đối tượng SqlCommand để thực thi câu truy vấn SQL đơn giản
            command = new SqlCommand("SELECT COUNT(*) FROM ThucDon", conn);
            // Thực thi câu truy vấn SQL và lấy kết quả
            int countTD = (int)command.ExecuteScalar();
            lbTongTD.Text = countTD.ToString();



            conn.Close();
        }
    }
}
