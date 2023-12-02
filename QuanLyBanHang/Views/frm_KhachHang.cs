using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Sử dụng thư viện để làm việc SQL server
using QuanLyBanHang.Class; //Sử dụng class Functions.cs
using System.Collections;

namespace GUI
{
    public partial class frm_KhachHang : Form
    {
        DataTable tbl;    //Chứa dữ liệu
        public frm_KhachHang()
        {
            InitializeComponent();
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM KhachHang";
            tbl = Functions.GetDataToTable(sql);
            dgv.DataSource = tbl;
            dgv.Columns[0].HeaderText = "Mã khách";
            dgv.Columns[1].HeaderText = "Tên khách";
            dgv.Columns[2].HeaderText = "Địa chỉ";
            dgv.Columns[3].HeaderText = "Điện thoại";
            dgv.Columns[0].Width = 100;
            dgv.Columns[1].Width = 150;
            dgv.Columns[2].Width = 150;
            dgv.Columns[3].Width = 100;
            dgv.AllowUserToAddRows = false;
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKH.Text = dgv.CurrentRow.Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dgv.CurrentRow.Cells["TenKH"].Value.ToString();
            txtDiaChi.Text = dgv.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSDT.Text = dgv.CurrentRow.Cells["SDT"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaKH.Enabled = true;
            txtMaKH.Focus();
        }

        private void ResetValues()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                if (txtMaKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaKH.Focus();
                    return;
                }
                if (txtTenKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenKH.Focus();
                    return;
                }
                if (txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDiaChi.Focus();
                    return;
                }
                if (txtSDT.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Số điện thoại phải có đúng 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSDT.Focus();
                    return;
                }
                //Kiểm tra đã tồn tại mã khách chưa
                sql = "SELECT MaKH FROM KhachHang WHERE MaKH=N'" + txtMaKH.Text.Trim() + "'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã khách này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaKH.Focus();
                    txtMaKH.Text = "";
                    return;
                }
                //Chèn thêm
                sql = "INSERT INTO KhachHang VALUES (N'" + txtMaKH.Text.Trim() + "',N'" + txtTenKH.Text.Trim() + "',N'" + txtDiaChi.Text.Trim() + "','" + txtSDT.Text + "')";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();

                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
                txtMaKH.Enabled = false;
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
                string sql;
                if (tbl.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtMaKH.Text == "")
                {
                    MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtTenKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenKH.Focus();
                    return;
                }
                if (txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDiaChi.Focus();
                    return;
                }
                if (txtSDT.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Số điện thoại phải có đúng 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSDT.Focus();
                    return;
                }
                sql = "UPDATE KhachHang SET TenKH=N'" + txtTenKH.Text.Trim().ToString() + "',DiaChi=N'" + txtDiaChi.Text.Trim().ToString() + "',SDT='" + txtSDT.Text.ToString() + "' WHERE MaKH=N'" + txtMaKH.Text + "'";
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
                sql = "SELECT COUNT(*) FROM HoaDon WHERE MaKH=N'" + txtMaKH.Text + "'";
                if (Functions.CheckKeyDelete(sql))
                {
                    MessageBox.Show("Bản ghi đang được sử dụng ở bảng hóa đơn, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tbl.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtMaKH.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "DELETE KhachHang WHERE MaKH=N'" + txtMaKH.Text + "'";
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
            txtMaKH.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtMaKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
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
                    sql = "SELECT * FROM KhachHang WHERE TenKH LIKE N'%" + txtTimKiem.Text + "%' OR MaKH LIKE '%" + txtTimKiem.Text + "%'";
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
