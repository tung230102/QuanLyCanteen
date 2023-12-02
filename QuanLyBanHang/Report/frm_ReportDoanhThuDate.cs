using Microsoft.Reporting.WinForms;
using QuanLyBanHang.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Report
{
    public partial class frm_ReportDoanhThuDate : Form
    {
        public frm_ReportDoanhThuDate()
        {
            InitializeComponent();
        }

        private void btnBCNgay_Click(object sender, EventArgs e)
        {
            // Lấy ngày được chọn từ DateTimePicker
            DateTime selectedDate = dtNgay.Value.Date;

            // Xóa báo cáo cũ và danh sách nguồn dữ liệu của nó khỏi ReportViewer
            reportDTTN.Reset();
            reportDTTN.LocalReport.DataSources.Clear();

            // Kết nối đến cơ sở dữ liệu
            SqlConnection conn = new SqlConnection();
            Functions.Connect(conn);

            // Tạo câu truy vấn để lấy dữ liệu cho ngày được chọn
            string query = "SELECT MaHD, CONVERT(date, NgayBan) NgayBan, TongTien FROM HoaDon WHERE CONVERT(date, NgayBan) = @NgayBan";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@NgayBan", selectedDate);

            // Tạo một SqlDataAdapter để lấy dữ liệu từ câu truy vấn và đưa vào một DataTable
            DataTable tbNgay = new DataTable();
            SqlDataAdapter daNgay = new SqlDataAdapter(cmd);
            daNgay.Fill(tbNgay);

            // Đóng kết nối
            conn.Close();

            // Tạo một báo cáo mới
            reportDTTN.LocalReport.ReportEmbeddedResource = "QuanLyBanHang.ReportRDLC.ReportDoanhThuDate.rdlc";

            // Tạo một ReportDataSource để lưu trữ dữ liệu của bạn
            ReportDataSource dataSource = new ReportDataSource();
            dataSource.Name = "HoaDon";
            dataSource.Value = tbNgay;

            // Thêm ReportDataSource vào báo cáo
            reportDTTN.LocalReport.DataSources.Add(dataSource);

            // Hiển thị báo cáo trong ReportViewer control
            //this.Controls.Add(reportDTTN);
            reportDTTN.RefreshReport();
        }

        private void btnBCThang_Click(object sender, EventArgs e)
        {
            int selectedMonth, selectedYear;
            if (!int.TryParse(txtThang.Text.Trim(), out selectedMonth) || !int.TryParse(txtNam.Text.Trim(), out selectedYear))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng tháng và năm (VD: 1/2022).");
                return;
            }
            try
            {
                // Lấy ngày tháng hiện tại
                DateTime currentDate = DateTime.Now;

                // Lấy giá trị người dùng nhập vào textbox
                int month = int.Parse(txtThang.Text);
                int year = int.Parse(txtNam.Text);

                // Kiểm tra nếu năm của người dùng lớn hơn năm hiện tại, hoặc năm bằng năm hiện tại và tháng của người dùng lớn hơn tháng hiện tại
                if (year == currentDate.Year && month > currentDate.Month)
                {
                    // Hiển thị thông báo lỗi và xóa giá trị trong textbox
                    MessageBox.Show("Bạn không được phép nhập tháng của tương lai!");
                    txtThang.Text = "";
                    txtThang.Focus();
                }
                if (year > currentDate.Year)
                {
                    // Hiển thị thông báo lỗi và xóa giá trị trong textbox
                    MessageBox.Show("Bạn không được phép nhập năm của tương lai!");
                    txtNam.Text = "";
                    txtNam.Focus();
                }
                else if (month < 1 || month > 12)
                {
                    // Hiển thị thông báo lỗi và xóa giá trị trong textbox
                    MessageBox.Show("Tháng không hợp lệ!");
                    txtThang.Text = "";
                    txtThang.Focus();
                }
                else if (year < 1900 || year > currentDate.Year)
                {
                    // Hiển thị thông báo lỗi và xóa giá trị trong textbox
                    MessageBox.Show("Năm không hợp lệ!");
                    txtNam.Text = "";
                    txtNam.Focus();
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi khác xảy ra
                // Hiển thị thông báo lỗi và in ra thông tin lỗi
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            reportDTTN.Reset();
            reportDTTN.LocalReport.DataSources.Clear();

            // Kết nối đến cơ sở dữ liệu
            SqlConnection conn = new SqlConnection();
            Functions.Connect(conn);


            // Tạo câu truy vấn để lấy dữ liệu cho tháng được chọn
            string query = "SELECT MaHD, NgayBan, TongTien FROM HoaDon WHERE MONTH(NgayBan)=@Thang AND YEAR(NgayBan)=@Nam GROUP BY MaHD, NgayBan, TongTien";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Thang", selectedMonth);
            cmd.Parameters.AddWithValue("@Nam", selectedYear);

            // Tạo một SqlDataAdapter để lấy dữ liệu từ câu truy vấn và đưa vào một DataTable
            DataTable tbThang = new DataTable();
            SqlDataAdapter daThang = new SqlDataAdapter(cmd);
            daThang.Fill(tbThang);

            // Đóng kết nối
            conn.Close();

            // Tạo một báo cáo mới
            reportDTTN.LocalReport.ReportEmbeddedResource = "QuanLyBanHang.ReportRDLC.ReportDoanhThuDate.rdlc";

            // Tạo một ReportDataSource để lưu trữ dữ liệu của bạn
            ReportDataSource dataSource = new ReportDataSource();
            dataSource.Name = "HoaDon";
            dataSource.Value = tbThang;

            // Thêm ReportDataSource vào báo cáo
            reportDTTN.LocalReport.DataSources.Add(dataSource);

            // Hiển thị báo cáo trong ReportViewer control
            //this.Controls.Add(reportDTTN);
            reportDTTN.RefreshReport();
        }

        private void btnBCNam_Click(object sender, EventArgs e)
        {
            // Lấy năm được chọn từ TextBox
            int selectedYear = int.Parse(textNam.Text.Trim());
            if (textNam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Chưa nhập thông tin, vui lòng nhập");
                textNam.Focus();
                return;
            }
            try
            {
                // Lấy ngày tháng hiện tại
                DateTime currentDate = DateTime.Now;
                // Lấy giá trị người dùng nhập vào textbox
                int year = int.Parse(textNam.Text);
                // Kiểm tra nếu năm của người dùng lớn hơn năm hiện tại, hoặc năm bằng năm hiện tại và tháng của người dùng lớn hơn tháng hiện tại
                if (year > currentDate.Year)
                {
                    // Hiển thị thông báo lỗi và xóa giá trị trong textbox
                    MessageBox.Show("Bạn không được phép nhập năm của tương lai!");
                    textNam.Text = "";
                    textNam.Focus();
                }
                else if (year < 1900 || year > currentDate.Year)
                {
                    // Hiển thị thông báo lỗi và xóa giá trị trong textbox
                    MessageBox.Show("Năm không hợp lệ!");
                    textNam.Text = "";
                    textNam.Focus();
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi khác xảy ra
                // Hiển thị thông báo lỗi và in ra thông tin lỗi
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            reportDTTN.Reset();
            reportDTTN.LocalReport.DataSources.Clear();

            // Kết nối đến cơ sở dữ liệu
            SqlConnection conn = new SqlConnection();
            Functions.Connect(conn);

            // Tạo câu truy vấn để lấy dữ liệu cho năm được chọn
            string query = "SELECT MaHD, NgayBan, TongTien FROM HoaDon WHERE YEAR(NgayBan)=@Nam GROUP BY MaHD, NgayBan, TongTien"; ;
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nam", selectedYear);

            // Tạo một SqlDataAdapter để lấy dữ liệu từ câu truy vấn và đưa vào một DataTable
            DataTable tbNam = new DataTable();
            SqlDataAdapter daNam = new SqlDataAdapter(cmd);
            daNam.Fill(tbNam);

            // Đóng kết nối
            conn.Close();

            // Tạo một báo cáo mới
            reportDTTN.LocalReport.ReportEmbeddedResource = "QuanLyBanHang.ReportRDLC.ReportDoanhThuDate.rdlc";

            // Tạo một ReportDataSource để lưu trữ dữ liệu của bạn
            ReportDataSource dataSource = new ReportDataSource();
            dataSource.Name = "HoaDon";
            dataSource.Value = tbNam;

            // Thêm ReportDataSource vào báo cáo
            reportDTTN.LocalReport.DataSources.Add(dataSource);

            // Hiển thị báo cáo trong ReportViewer control
            //this.Controls.Add(reportDTTN);
            reportDTTN.RefreshReport();
        }
    }
}
