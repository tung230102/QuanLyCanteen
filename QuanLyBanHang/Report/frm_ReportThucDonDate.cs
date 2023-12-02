using Microsoft.Reporting.WinForms;
using QuanLyBanHang.Class;
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

namespace QuanLyBanHang.Report
{
    public partial class frm_ReportThucDonDate : Form
    {
        public frm_ReportThucDonDate()
        {
            InitializeComponent();
        }

        private void btnBCNgay_Click(object sender, EventArgs e)
        {
            // Lấy ngày được chọn từ DateTimePicker
            DateTime selectedDate = dtNgay.Value;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");

            // Xóa báo cáo cũ và danh sách nguồn dữ liệu của nó khỏi ReportViewer
            reportTDDate.Reset();
            reportTDDate.LocalReport.DataSources.Clear();

            // Kết nối đến cơ sở dữ liệu
            SqlConnection conn = new SqlConnection();
            Functions.Connect(conn);

            // Tạo câu truy vấn để lấy dữ liệu cho ngày được chọn
            string query = "SELECT ChiTietHD.MaMon, ThucDon.TenMon, ChiTietHD.SoLuong, HoaDon.NgayBan FROM ChiTietHD INNER JOIN ThucDon ON ChiTietHD.MaMon = ThucDon.MaMon INNER JOIN HoaDon ON ChiTietHD.MaHD = HoaDon.MaHD WHERE CONVERT(date, HoaDon.NgayBan) = @Ngay GROUP BY ChiTietHD.MaMon, ThucDon.TenMon, ChiTietHD.SoLuong, HoaDon.NgayBan";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Ngay", formattedDate);

            // Tạo một SqlDataAdapter để lấy dữ liệu từ câu truy vấn và đưa vào một DataTable
            DataTable tbCTHD = new DataTable();
            SqlDataAdapter daCTHD = new SqlDataAdapter(cmd);
            daCTHD.Fill(tbCTHD);

            string query1 = "Select * from ThucDon";
            SqlCommand cmd1 = new SqlCommand(query1, conn);

            // Tạo một SqlDataAdapter để lấy dữ liệu từ câu truy vấn và đưa vào một DataTable
            DataTable tbThucDon = new DataTable();
            SqlDataAdapter daThucDon = new SqlDataAdapter(cmd1);
            daThucDon.Fill(tbThucDon);

            //Hóa đơn
            SqlCommand cmd2 = new SqlCommand(query, conn);
            cmd2.Parameters.AddWithValue("@Ngay", formattedDate);

            // Tạo một SqlDataAdapter để lấy dữ liệu từ câu truy vấn và đưa vào một DataTable
            DataTable tbHoaDon = new DataTable();
            SqlDataAdapter daHoaDon = new SqlDataAdapter(cmd2);
            daHoaDon.Fill(tbHoaDon);
            // Đóng kết nối
            conn.Close();

            // Tạo một báo cáo mới
            reportTDDate.LocalReport.ReportEmbeddedResource = "QuanLyBanHang.ReportRDLC.ReportThucDonDate.rdlc";

            // Tạo một ReportDataSource để lưu trữ dữ liệu của bạn
            ReportDataSource dataSource = new ReportDataSource();
            dataSource.Name = "ChiTietHD";
            dataSource.Value = tbCTHD;

            ReportDataSource dataSource1 = new ReportDataSource();
            dataSource1.Name = "ThucDon";
            dataSource1.Value = tbThucDon.DefaultView; // chuyển DataTable thành DataView để tránh lỗi trùng tên cột

            ReportDataSource dataSource2 = new ReportDataSource();
            dataSource2.Name = "HoaDon";
            dataSource2.Value = tbHoaDon;

            // Thêm ReportDataSource vào báo cáo
            reportTDDate.LocalReport.DataSources.Add(dataSource);
            reportTDDate.LocalReport.DataSources.Add(dataSource1);
            reportTDDate.LocalReport.DataSources.Add(dataSource2);

            // Hiển thị báo cáo trong ReportViewer control
            this.Controls.Add(reportTDDate);
            reportTDDate.RefreshReport();
        }

        private void btnBCThang_Click(object sender, EventArgs e)
        {

        }

        private void btnBCNam_Click(object sender, EventArgs e)
        {

        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textNam_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
