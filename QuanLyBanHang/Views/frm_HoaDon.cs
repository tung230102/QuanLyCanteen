using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyBanHang.Class;
using QuanLyBanHang.Report;
using COMExcel = Microsoft.Office.Interop.Excel;
namespace GUI
{
    public partial class frm_HoaDon : Form
    {
        DataTable tbl;

        public frm_HoaDon()
        {
            InitializeComponent();
        }

        private void frm_HoaDon_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
            txtMaHD.ReadOnly = true;
            txtTenND.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtDienThoai.ReadOnly = true;
            txtTenMon.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            Functions.FillCombo("SELECT MaKH, TenKH FROM KhachHang", cboMaKH, "MaKH", "TenKH");
            cboMaKH.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaND, TenND FROM NguoiDung", cboMaND, "MaND", "TenND");
            cboMaND.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaMon, TenMon FROM ThucDon", cboMaMon, "MaMon", "TenMon");
            cboMaMon.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHD.Text != "")
            {
                LoadInfoHoaDon();
                btnXoa.Enabled = true;
                btnIn.Enabled = true;
            }
            LoadDataGridView();

        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.MaMon, b.TenMon, a.SoLuong, b.DonGia, a.GiamGia, a.ThanhTien FROM ChiTietHD AS a, ThucDon AS b WHERE a.MaHD = N'" + txtMaHD.Text + "' AND a.MaMon=b.MaMon";
            tbl = Functions.GetDataToTable(sql);
            dgvHDBanHang.DataSource = tbl;
            dgvHDBanHang.Columns[0].HeaderText = "Mã món";
            dgvHDBanHang.Columns[1].HeaderText = "Tên món";
            dgvHDBanHang.Columns[2].HeaderText = "Số lượng";
            dgvHDBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvHDBanHang.Columns[4].HeaderText = "Giảm giá";
            dgvHDBanHang.Columns[5].HeaderText = "Thành tiền";
            dgvHDBanHang.Columns[0].Width = 100;
            dgvHDBanHang.Columns[1].Width = 150;
            dgvHDBanHang.Columns[2].Width = 100;
            dgvHDBanHang.Columns[3].Width = 100;
            dgvHDBanHang.Columns[4].Width = 100;
            dgvHDBanHang.Columns[5].Width = 150;
            dgvHDBanHang.AllowUserToAddRows = false;
            dgvHDBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayBan FROM HoaDon WHERE MaHD = N'" + txtMaHD.Text + "'";
            dtpNgayBan.Value = DateTime.Parse(Functions.GetFieldValues(str));
            str = "SELECT MaND FROM HoaDon WHERE MaHD = N'" + txtMaHD.Text + "'";
            cboMaND.SelectedValue = Functions.GetFieldValues(str);
            str = "SELECT MaKH FROM HoaDon WHERE MaHD = N'" + txtMaHD.Text + "'";
            cboMaKH.SelectedValue = Functions.GetFieldValues(str);
            str = "SELECT TongTien FROM HoaDon WHERE MaHD = N'" + txtMaHD.Text + "'";
            txtTongTien.Text = Functions.GetFieldValues(str);
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(txtTongTien.Text));
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHD.Text = Functions.CreateKey("HD");
            LoadDataGridView();
        }

        private void ResetValues()
        {
            txtMaHD.Text = "";
            dtpNgayBan.Value = DateTime.Now;
            cboMaND.Text = "";
            txtTenND.Text = "";
            cboMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtTongTien.Text = "0";
            lblBangChu.Text = "Bằng chữ: ";
            cboMaMon.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
            txtTenMon.Text = "";
            txtDonGia.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                double sl, SLcon, tong, Tongmoi;
                sql = "SELECT MaHD FROM HoaDon WHERE MaHD=N'" + txtMaHD.Text + "'";
                if (!Functions.CheckKey(sql))
                {
                    // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                    // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                    if (dtpNgayBan.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtpNgayBan.Focus();
                        return;
                    }
                    if (cboMaND.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cboMaND.Focus();
                        return;
                    }
                    if (cboMaKH.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cboMaKH.Focus();
                        return;
                    }

                    string NgayBan = dtpNgayBan.Value.ToString("yyyy/MM/dd hh:mm:ss tt");

                    sql = "INSERT INTO HoaDon(MaHD, NgayBan, MaND, MaKH, TongTien) VALUES (N'" + txtMaHD.Text.Trim() + "','" +
                            NgayBan + "',N'" + cboMaND.SelectedValue + "',N'" +
                            cboMaKH.SelectedValue + "'," + txtTongTien.Text + ")";
                    Functions.RunSQL(sql);
                }
                // Lưu thông tin của các mặt hàng
                if (cboMaMon.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaMon.Focus();
                    return;
                }
                if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
                {
                    MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoLuong.Text = "";
                    txtSoLuong.Focus();
                    return;
                }
                if (txtGiamGia.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGiamGia.Focus();
                    return;
                }
                sql = "SELECT MaMon FROM ChiTietHD WHERE MaMon=N'" + cboMaMon.SelectedValue + "' AND MaHD = N'" + txtMaHD.Text.Trim() + "'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValuesHang();
                    cboMaMon.Focus();
                    return;
                }
                // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
                sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM ThucDon WHERE MaMon=N'" + cboMaMon.SelectedValue + "'"));
                if (Convert.ToDouble(txtSoLuong.Text) > sl)
                {
                    MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoLuong.Text = "";
                    txtSoLuong.Focus();
                    return;
                }
                sql = "INSERT INTO ChiTietHD(MaHD,MaMon,SoLuong,DonGia, GiamGia,ThanhTien) VALUES(N'" + txtMaHD.Text.Trim() + "',N'" + cboMaMon.SelectedValue + "'," + txtSoLuong.Text + "," + txtDonGia.Text + "," + txtGiamGia.Text + "," + txtThanhTien.Text + ")";
                Functions.RunSQL(sql);
                LoadDataGridView();
                // Cập nhật lại số lượng của mặt hàng vào bảng ThucDon
                SLcon = sl - Convert.ToDouble(txtSoLuong.Text);
                sql = "UPDATE ThucDon SET SoLuong =" + SLcon + " WHERE MaMon= N'" + cboMaMon.SelectedValue + "'";
                Functions.RunSQL(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM HoaDon WHERE MaHD = N'" + txtMaHD.Text + "'"));
                Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
                sql = "UPDATE HoaDon SET TongTien =" + Tongmoi + " WHERE MaHD = N'" + txtMaHD.Text + "'";
                Functions.RunSQL(sql);
                txtTongTien.Text = Tongmoi.ToString();
                lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(Tongmoi.ToString()));
                ResetValuesHang();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnIn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thể kết nối đến cơ sở dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetValuesHang()
        {
            cboMaMon.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
            txtTenMon.Text = "";
            txtDonGia.Text = "";
        }

        private void dgvHDBanHang_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string MaMonxoa, sql;
                Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
                if (tbl.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    //Xóa hàng và cập nhật lại số lượng hàng 
                    MaMonxoa = dgvHDBanHang.CurrentRow.Cells["MaMon"].Value.ToString();
                    SoLuongxoa = Convert.ToDouble(dgvHDBanHang.CurrentRow.Cells["SoLuong"].Value.ToString());
                    ThanhTienxoa = Convert.ToDouble(dgvHDBanHang.CurrentRow.Cells["ThanhTien"].Value.ToString());
                    sql = "DELETE ChiTietHD WHERE MaHD=N'" + txtMaHD.Text + "' AND MaMon = N'" + MaMonxoa + "'";
                    Functions.RunSQL(sql);
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM ThucDon WHERE MaMon = N'" + MaMonxoa + "'"));
                    slcon = sl + SoLuongxoa;
                    sql = "UPDATE ThucDon SET SoLuong =" + slcon + " WHERE MaMon= N'" + MaMonxoa + "'";
                    Functions.RunSQL(sql);
                    // Cập nhật lại tổng tiền cho hóa đơn bán
                    tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM HoaDon WHERE MaHD = N'" + txtMaHD.Text + "'"));
                    tongmoi = tong - ThanhTienxoa;
                    sql = "UPDATE HoaDon SET TongTien =" + tongmoi + " WHERE MaHD = N'" + txtMaHD.Text + "'";
                    Functions.RunSQL(sql);
                    txtTongTien.Text = tongmoi.ToString();
                    lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(tongmoi.ToString()));
                    LoadDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thể kết nối đến cơ sở dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                double sl, slcon, slxoa;
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "SELECT MaMon,SoLuong FROM ChiTietHD WHERE MaHD = N'" + txtMaHD.Text + "'";
                    DataTable ThucDon = Functions.GetDataToTable(sql);
                    for (int hang = 0; hang <= ThucDon.Rows.Count - 1; hang++)
                    {
                        // Cập nhật lại số lượng cho các mặt hàng
                        sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM ThucDon WHERE MaMon = N'" + ThucDon.Rows[hang][0].ToString() + "'"));
                        slxoa = Convert.ToDouble(ThucDon.Rows[hang][1].ToString());
                        slcon = sl + slxoa;
                        sql = "UPDATE ThucDon SET SoLuong =" + slcon + " WHERE MaMon= N'" + ThucDon.Rows[hang][0].ToString() + "'";
                        Functions.RunSQL(sql);
                    }

                    //Xóa chi tiết hóa đơn
                    sql = "DELETE ChiTietHD WHERE MaHD=N'" + txtMaHD.Text + "'";
                    Functions.RunSQL(sql);

                    //Xóa hóa đơn
                    sql = "DELETE HoaDon WHERE MaHD=N'" + txtMaHD.Text + "'";
                    Functions.RunSQL(sql);
                    ResetValues();
                    LoadDataGridView();
                    btnThem.Enabled = true;
                    btnXoa.Enabled = false;
                    btnIn.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thể kết nối đến cơ sở dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Quản lý căng tin";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            //exRange.Range["A2:B2"].Value = "";
            //exRange.Range["A3:B3"].MergeCells = true;
            //exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           // exRange.Range["A3:B3"].Value = "Điện thoại: ";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHD, a.NgayBan, a.TongTien, b.TenKH, b.DiaChi, b.SDT, c.TenND FROM HoaDon AS a, KhachHang AS b, NguoiDung AS c WHERE a.MaHD = N'" + txtMaHD.Text + "' AND a.MaKH = b.MaKH AND a.MaND = c.MaND";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenMon, a.SoLuong, b.DonGia, a.GiamGia, a.ThanhTien " +
                  "FROM ChiTietHD AS a , ThucDon AS b WHERE a.MaHD = N'" +
                  txtMaHD.Text + "' AND a.MaMon = b.MaMon";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(tblThongtinHD.Rows[0][2].ToString()));
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMaHD.Text == "")
                {
                    MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaHD.Focus();
                    return;
                }
                txtMaHD.Text = cboMaHD.Text;
                LoadInfoHoaDon();
                LoadDataGridView();
                btnXoa.Enabled = true;
                btnLuu.Enabled = true;
                btnIn.Enabled = true;
                cboMaHD.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thể kết nối đến cơ sở dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void frm_HoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetValues();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMaND_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaND.Text == "")
                txtTenND.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select TenND from NguoiDung where MaND =N'" + cboMaND.SelectedValue + "'";
            txtTenND.Text = Functions.GetFieldValues(str);
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaKH.Text == "")
            {
                txtTenKH.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select TenKH from KhachHang where MaKH = N'" + cboMaKH.SelectedValue + "'";
            txtTenKH.Text = Functions.GetFieldValues(str);
            str = "Select DiaChi from KhachHang where MaKH = N'" + cboMaKH.SelectedValue + "'";
            txtDiaChi.Text = Functions.GetFieldValues(str);
            str = "Select SDT from KhachHang where MaKH= N'" + cboMaKH.SelectedValue + "'";
            txtDienThoai.Text = Functions.GetFieldValues(str);
        }

        private void cboMaMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaMon.Text == "")
            {
                txtTenMon.Text = "";
                txtDonGia.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenMon FROM ThucDon WHERE MaMon =N'" + cboMaMon.SelectedValue + "'";
            txtTenMon.Text = Functions.GetFieldValues(str);
            str = "SELECT DonGia FROM ThucDon WHERE MaMon =N'" + cboMaMon.SelectedValue + "'";
            txtDonGia.Text = Functions.GetFieldValues(str);
        }

        private void cboMaHD_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaHD FROM HoaDon", cboMaHD, "MaHD", "MaHD");
            cboMaHD.SelectedIndex = -1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, tong;
            if (cboMaMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã Món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaMon.Focus();
                return;
            }
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }

            if ((txtGiamGia.Text.Trim().Length == 0))
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Text = "";
                txtGiamGia.Focus();
                return;
            }
            // Kiểm tra số lượng hàng trong kho
            sl = Functions.GetSoLuongUpdate("SELECT SoLuong FROM ThucDon WHERE MaMon = N'" + cboMaMon.SelectedValue + "'");
            if (Convert.ToDouble(txtSoLuong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }

            try
            {
                double dongia = Convert.ToDouble(txtDonGia.Text);
                double giamgia = Convert.ToDouble(txtGiamGia.Text);
                int soluong = Convert.ToInt32(txtSoLuong.Text);
                double thanhtien = dongia * soluong - (dongia * soluong * giamgia / 100);

                // Lấy số lượng mặt hàng cũ từ bảng ChiTietHD
                double sl_old = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM ChiTietHD WHERE MaHD = N'" + txtMaHD.Text + "' AND MaMon = N'" + cboMaMon.SelectedValue + "'"));

                // Cập nhật lại số lượng mặt hàng vào bảng ChiTietHD
                sql = "UPDATE ChiTietHD SET MaMon = N'" + cboMaMon.SelectedValue + "', SoLuong = " + txtSoLuong.Text +
                    ", DonGia = " + txtDonGia.Text + ", ThanhTien = " + thanhtien + ", GiamGia = " + giamgia + " WHERE MaHD = N'" + txtMaHD.Text + "' AND MaMon = N'" + cboMaMon.SelectedValue + "'";
                Functions.RunSQL(sql);

                // Cập nhật lại số lượng tồn kho của mặt hàng
                double sl_new = sl + sl_old - soluong;
                sql = "UPDATE ThucDon SET SoLuong = " + sl_new + " WHERE MaMon = N'" + cboMaMon.SelectedValue + "'";
                Functions.RunSQL(sql);

                // Lấy tổng tiền cũ từ bảng HoaDon
                tong = Convert.ToDouble(Functions.GetFieldValues("SELECT SUM(ThanhTien) FROM ChiTietHD WHERE MaHD = N'" + txtMaHD.Text + "'"));
                //lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());


                // Cập nhật lại tổng tiền cho hóa đơn bán
                sql = "UPDATE HoaDon SET TongTien = " + tong + " WHERE MaHD = N'" + txtMaHD.Text + "'";
                Functions.RunSQL(sql);

                // Cập nhật lại textbox Tổng tiền và label Bằng chữ
                txtTongTien.Text = tong.ToString();
                LoadDataGridView();
                ResetValuesHang();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnIn.Enabled = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvHDBanHang_Click(object sender, EventArgs e)
        {
            string sql, MaMon;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang chờ thêm mới, bạn không được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaMon.Focus();
                return;
            }
            if (dgvHDBanHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MaMon = dgvHDBanHang.CurrentRow.Cells["MaMon"].Value.ToString();
            sql = "SELECT TenMon FROM ThucDon WHERE MaMon=N'" + MaMon + "'";
            cboMaMon.Text = Functions.GetFieldValues(sql);
            txtSoLuong.Text = dgvHDBanHang.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtThanhTien.Text = dgvHDBanHang.CurrentRow.Cells["ThanhTien"].Value.ToString();
            txtDonGia.Text = dgvHDBanHang.CurrentRow.Cells["DonGia"].Value.ToString();
            txtGiamGia.Text = dgvHDBanHang.CurrentRow.Cells["GiamGia"].Value.ToString();
            sql = "SELECT SoLuong FROM ThucDon WHERE MaMon=N'" + MaMon + "'";
            sql = "SELECT TenMon FROM ThucDon WHERE MaMon=N'" + MaMon + "'";
            txtTenMon.Text = Functions.GetFieldValues(sql);
            btnXoa.Enabled = true;
            cboMaMon.Enabled = true;
        }
    }   
}
