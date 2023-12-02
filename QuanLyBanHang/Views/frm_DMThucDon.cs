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

namespace GUI
{
    public partial class frm_DMThucDon : Form
    {
        DataTable tbl;    //Chứa dữ liệu

        public frm_DMThucDon()
        {
            InitializeComponent();
            Functions.Connect();
        }
        string Quyen = "";
        public frm_DMThucDon(String Quyen)
        {
            InitializeComponent();
            this.Quyen = Quyen;
            if (Quyen == "User")
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnLuu.Visible = false;
                btnBoQua.Visible = false;
            }
        }

        private void frm_DMThucDon_Load(object sender, EventArgs e)
        {
            txtMaDM.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaDM, TenDanhMuc FROM DanhMuc";
            tbl = Functions.GetDataToTable(sql);
            dgv.DataSource = tbl;
            dgv.Columns[0].HeaderText = "Mã danh mục";
            dgv.Columns[1].HeaderText = "Tên danh mục";
            dgv.Columns[0].Width = 200;
            dgv.Columns[1].Width = 200;
            dgv.AllowUserToAddRows = false;
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDM.Focus();
                return;
            }
            if (tbl.Rows.Count == 0)      //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữu liệu!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaDM.Text = dgv.CurrentRow.Cells["MaDM"].Value.ToString();
            txtTenDM.Text = dgv.CurrentRow.Cells["TenDanhMuc"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void ResetValue()
        {
            txtMaDM.Text = "";
            txtTenDM.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();   //Xoá trắng các textbox
            txtMaDM.Enabled = true;
            txtTenDM.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;     //Lưu lệnh sql
                if (txtMaDM.Text.Trim().Length == 0)      //Nếu chưa nhập mã danh mục
                {
                    MessageBox.Show("Bạn phải nhập mã danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaDM.Focus();
                    return;
                }
                if (txtTenDM.Text.Trim().Length == 0)     //Nếu chưa nhập tên danh mục
                {
                    MessageBox.Show("Bạn phải nhập tên danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenDM.Focus();
                    return;
                }

                sql = "SELECT MaDM FROM DanhMuc WHERE MaDM = N'" + txtMaDM.Text.Trim() + "'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã danh mục này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaDM.Focus();
                    txtMaDM.Text = "";
                    return;
                }
                sql = "SELECT TenDanhMuc FROM DanhMuc WHERE TenDanhMuc = N'" + txtTenDM.Text.Trim() + "'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Tên danh mục này đã có, bạn phải nhập tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDM.Focus();
                    txtTenDM.Text = "";
                    return;
                }
                sql = "INSERT INTO DanhMuc VALUES('" + txtMaDM.Text + "', N'" + txtTenDM.Text + "')";
                Functions.RunSQL(sql);      //Thực hiện câu lệnh sql
                LoadDataGridView();         //Nạp lại DataGridView
                ResetValue();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
                txtMaDM.Enabled = false;
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
                if (txtMaDM.Text == "")    //nếu chưa chọn bản ghi nào
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtTenDM.Text.Trim().Length == 0)      //nếu chưa nhập tên chất liệu
                {
                    MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                sql = "UPDATE DanhMuc SET MaDM = N'" + txtMaDM.Text + "', TenDanhMuc = N'" + txtTenDM.Text.ToString() + "' WHERE MaDM = N'" + txtMaDM.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValue();

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
                sql = "SELECT COUNT(*) FROM ThucDon WHERE MaDM=N'" + txtMaDM.Text + "'";
                if (Functions.CheckKeyDelete(sql))
                {
                    MessageBox.Show("Bản ghi đang được sử dụng ở bảng thực đơn, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tbl.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtMaDM.Text == "")       //nếu chưa chọn bản ghi nào
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "DELETE DanhMuc WHERE MaDM = N'" + txtMaDM.Text + "'";
                    Functions.RunSQL(sql);
                    LoadDataGridView();
                    ResetValue();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thể kết nối đến cơ sở dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaDM.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaDM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
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
                    sql = "SELECT * FROM DanhMuc WHERE TenDanhMuc LIKE N'%" + txtTimKiem.Text + "%' OR MaDM LIKE '%" + txtTimKiem.Text + "%'";
                    tbl = Functions.GetDataToTable(sql);
                    if (tbl.Rows.Count == 0)
                        MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Có " + tbl.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv.DataSource = tbl;
                    ResetValue();
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
