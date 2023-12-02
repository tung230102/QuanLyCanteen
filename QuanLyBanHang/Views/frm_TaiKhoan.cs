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
using QuanLyBanHang.Class;
using System.Text.RegularExpressions;
namespace GUI
{
    public partial class frm_TaiKhoan : Form
    {
        DataTable tbl;

        public frm_TaiKhoan()
        {
            InitializeComponent();
        }

        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from NguoiDung";
            txtTenDangNhap.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
            Functions.FillCombo(sql, cbMaND, "MaND", "TenND");
            cbMaND.SelectedIndex = -1;
            ResetValues();
        }

        private void ResetValues()
        {
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            cbQuyen.Text = "";
            cbMaND.Text = "";
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from TaiKhoan";
            tbl = Functions.GetDataToTable(sql);
            dgv.DataSource = tbl;
            dgv.Columns[0].HeaderText = "Tên đăng nhập";
            dgv.Columns[1].HeaderText = "Mật khẩu";
            dgv.Columns[2].HeaderText = "Quyền";
            dgv.Columns[3].HeaderText = "Người dùng";
            dgv.Columns[0].Width = 200;
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].Width = 80;
            dgv.Columns[3].Width = 150;
            dgv.AllowUserToAddRows = false;
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            string MaND;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDangNhap.Focus();
                return;
            }
            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtTenDangNhap.Text = dgv.CurrentRow.Cells["TenDangNhap"].Value.ToString();
            txtMatKhau.Text = dgv.CurrentRow.Cells["MatKhau"].Value.ToString();
            cbQuyen.Text = dgv.CurrentRow.Cells["Quyen"].Value.ToString();
            MaND = dgv.CurrentRow.Cells["MaND"].Value.ToString();
            sql = "SELECT TenND FROM NguoiDung WHERE MaND=N'" + MaND + "'";
            cbMaND.Text = Functions.GetFieldValues(sql);
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
            txtTenDangNhap.Enabled = true;
            txtMatKhau.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                if (txtTenDangNhap.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenDangNhap.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhau.Focus();
                    return;
                }

                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z]){1,}(?=.*\d){1,}(?=.*[\W_]).{8,}$");
                if (!regex.IsMatch(txtMatKhau.Text))
                {
                    MessageBox.Show("Mật khẩu của bạn phải chứa ít nhất một kí tự đặc biệt, một chữ hoa, một chữ thường và một số và độ dài tối thiểu 8 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhau.Focus();
                    return;
                }
                if (cbQuyen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn quyền đăng nhâp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbQuyen.Focus();
                    return;
                }
                if (cbMaND.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaND.Focus();
                    return;
                }

                sql = "SELECT TenDangNhap FROM TaiKhoan WHERE TenDangNhap=N'" + txtTenDangNhap.Text.Trim() + "'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại, bạn phải chọn tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenDangNhap.Focus();
                    txtTenDangNhap.Text = "";
                    return;
                }
                sql = "INSERT INTO TaiKhoan(TenDangNhap,MatKhau,MaND,Quyen) VALUES(N'"
                    + txtTenDangNhap.Text.Trim() + "',N'" + txtMatKhau.Text.Trim() +
                    "',N'" + cbMaND.SelectedValue.ToString() +
                    "',N'" + cbQuyen.Text.Trim() + "')";

                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
                txtTenDangNhap.Enabled = false;
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
                if (txtTenDangNhap.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenDangNhap.Focus();
                    return;
                }
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z]){1,}(?=.*\d){1,}(?=.*[\W_]).{8,}$");
                if (!regex.IsMatch(txtMatKhau.Text))
                {
                    MessageBox.Show("Mật khẩu của bạn phải chứa ít nhất một kí tự đặc biệt, một chữ hoa, một chữ thường và một số và độ dài tối thiểu 8 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhau.Focus();
                    return;
                }
                if (cbQuyen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn quyền đăng nhâp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaND.Focus();
                    return;
                }
                if (cbMaND.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaND.Focus();
                    return;
                }
                sql = "UPDATE TaiKhoan SET MatKhau=N'" + txtMatKhau.Text.Trim().ToString() +
                    "',MaND=N'" + cbMaND.SelectedValue.ToString() +
                    "',Quyen=N'" + cbQuyen.Text +
                    "' WHERE TenDangNhap=N'" + txtTenDangNhap.Text + "'";
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
                if (tbl.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtTenDangNhap.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "DELETE TaiKhoan WHERE TenDangNhap=N'" + txtTenDangNhap.Text + "'";
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
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtTenDangNhap.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap LIKE N'%" + txtTimKiem.Text + "%'";
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
    }
}
