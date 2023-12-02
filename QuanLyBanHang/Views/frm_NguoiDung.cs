using QuanLyBanHang.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace GUI
{
    public partial class frm_NguoiDung : Form
    {
        DataTable tbl; //Lưu dữ liệu bảng

        public frm_NguoiDung()
        {
            InitializeComponent();
        }

        private void frm_NguoiDung_Load(object sender, EventArgs e)
        {
            txtMaND.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }

        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM NguoiDung";
            tbl = Functions.GetDataToTable(sql); //lấy dữ liệu
            dgv.DataSource = tbl;
            dgv.Columns[0].HeaderText = "Mã người dùng";
            dgv.Columns[1].HeaderText = "Tên người dùng";
            dgv.Columns[2].HeaderText = "Giới tính";
            dgv.Columns[3].HeaderText = "Ngày sinh";
            dgv.Columns[4].HeaderText = "Địa chỉ";
            dgv.Columns[5].HeaderText = "Điện thoại";
            dgv.Columns[0].Width = 150;
            dgv.Columns[1].Width = 150;
            dgv.Columns[2].Width = 90;
            dgv.Columns[3].Width = 90;
            dgv.Columns[4].Width = 150;
            dgv.Columns[5].Width = 100;
            dgv.AllowUserToAddRows = false;
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaND.Focus();
                return;
            }
            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaND.Text = dgv.CurrentRow.Cells["MaND"].Value.ToString();
            txtTen.Text = dgv.CurrentRow.Cells["TenND"].Value.ToString();
            if (dgv.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam")
                chkGioiTinh.Checked = true;
            else
                chkGioiTinh.Checked = false;
            txtDiaChi.Text = dgv.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSDT.Text = dgv.CurrentRow.Cells["SDT"].Value.ToString();
            dtpNgaySinh.Value = (DateTime)dgv.CurrentRow.Cells["NgaySinh"].Value;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaND.Enabled = true;
            txtMaND.Focus();
        }

        private void ResetValues()
        {
            txtMaND.Text = "";
            txtTen.Text = "";
            chkGioiTinh.Checked = false;
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            dtpNgaySinh.Text = "1/1/1900";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string sql, gt;
                if (txtMaND.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập mã người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaND.Focus();
                    return;
                }
                if (txtTen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTen.Focus();
                    return;
                }

                if (txtSDT.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Số điện thoại phải có đúng 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSDT.Focus();
                    return;
                }

                if (txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                    return;
                }
                if (chkGioiTinh.Checked == true)
                    gt = "Nam";
                else
                    gt = "Nữ";
                sql = "SELECT MaND FROM NguoiDung WHERE MaND=N'" + txtMaND.Text.Trim() + "'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã người dùng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaND.Focus();
                    txtMaND.Text = "";
                    return;
                }
                string NgaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
                sql = "INSERT INTO NguoiDung(MAND, TenND, GioiTinh, DiaChi, SDT, NgaySinh) VALUES (N'" + txtMaND.Text.Trim() + "',N'"
                    + txtTen.Text.Trim() + "',N'" + gt + "',N'" + txtDiaChi.Text.Trim() + "','" + txtSDT.Text + "','" + NgaySinh + "')";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
                txtMaND.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thể kết nối đến cơ sở dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string sql, gt;
                if (tbl.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtMaND.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtTen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTen.Focus();
                    return;
                }
                if (txtSDT.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Số điện thoại phải có đúng 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSDT.Focus();
                    return;
                }
                if (txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                    return;
                }
                if (chkGioiTinh.Checked == true)
                    gt = "Nam";
                else
                    gt = "Nữ";
                string NgaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
                sql = "UPDATE NguoiDung SET  TenND=N'" + txtTen.Text.Trim().ToString() +
                        "',DiaChi=N'" + txtDiaChi.Text.Trim().ToString() +
                        "',SDT='" + txtSDT.Text.ToString() + "',GioiTinh=N'" + gt +
                        "',NgaySinh='" + NgaySinh +
                        "' WHERE MaND=N'" + txtMaND.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
                btnBoQua.Enabled = false;
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
                string sql;
                sql = "SELECT COUNT(*) FROM HoaDon WHERE MaND=N'" + txtMaND.Text + "'";
                if (Functions.CheckKeyDelete(sql))
                {
                    MessageBox.Show("Bản ghi đang được sử dụng ở bảng hóa đơn, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sql = "SELECT COUNT(*) FROM TaiKhoan WHERE MaND=N'" + txtMaND.Text + "'";
                if (Functions.CheckKeyDelete(sql))
                {
                    MessageBox.Show("Bản ghi đang được sử dụng ở bảng tài khoản, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tbl.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtMaND.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    sql = "DELETE NguoiDung WHERE MaND=N'" + txtMaND.Text + "'";
                    Functions.RunSQL(sql);
                    LoadDataGridView();
                    ResetValues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thể kết nối đến cơ sở dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaND.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaND_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                if (txtTimKiem.Text == "")
                {
                    LoadDataGridView();
                }
                else
                {
                    sql = "SELECT * FROM NguoiDung WHERE TenND LIKE N'%" + txtTimKiem.Text + "%' OR MaND LIKE '%" + txtTimKiem.Text + "%'";
                    tbl = Functions.GetDataToTable(sql);
                    if (tbl.Rows.Count == 0)
                        MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Có " + tbl.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv.DataSource = tbl;
                    ResetValues();
                }
                txtTimKiem.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thể kết nối đến cơ sở dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) && txtSDT.Text.Length >= 10)
            {
                e.Handled = true;
            }
        }
    }
}
