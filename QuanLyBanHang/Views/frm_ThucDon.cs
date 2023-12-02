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
namespace GUI
{
    public partial class frm_ThucDon : Form
    {
        DataTable tbl; //Bảng hàng

        public frm_ThucDon()
        {
            InitializeComponent();
        }

        string Quyen = "";
        public frm_ThucDon(String Quyen)
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

        private void frm_ThucDon_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from DanhMuc";
            txtMaMon.Enabled = false;
            txtAnh.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
            Functions.FillCombo(sql, cbMaDM, "MaDM", "TenDanhMuc");
            cbMaDM.SelectedIndex = -1;
            ResetValues();
        }

        private void ResetValues()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            cbMaDM.Text = "";
            txtSoLuong.Text = "0";
            txtDonGia.Text = "0";
            txtSoLuong.Enabled = true;
            txtAnh.Enabled = false;
            //txtDonGia.Enabled = false;
            txtAnh.Text = "";
            picAnh.Image = null;
            txtGhiChu.Text = "";
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from ThucDon";
            tbl = Functions.GetDataToTable(sql);
            dgv.DataSource = tbl;
            dgv.Columns[0].HeaderText = "Mã món";
            dgv.Columns[1].HeaderText = "Tên món";
            dgv.Columns[2].HeaderText = "Danh mục";
            dgv.Columns[3].HeaderText = "Số lượng";
            dgv.Columns[4].HeaderText = "Đơn giá ";
            dgv.Columns[5].HeaderText = "Ảnh";
            dgv.Columns[6].HeaderText = "Ghi chú";
            dgv.Columns[0].Width = 90;
            dgv.Columns[1].Width = 120;
            dgv.Columns[2].Width = 100;
            dgv.Columns[3].Width = 90;
            dgv.Columns[4].Width = 90;
            dgv.Columns[5].Width = 90;
            dgv.Columns[6].Width = 150;
            dgv.AllowUserToAddRows = false;
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            string MaDM;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaMon.Focus();
                return;
            }
            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaMon.Text = dgv.CurrentRow.Cells["MaMon"].Value.ToString();
            txtTenMon.Text = dgv.CurrentRow.Cells["TenMon"].Value.ToString();
            MaDM = dgv.CurrentRow.Cells["MaDM"].Value.ToString();
            sql = "SELECT TenDanhMuc FROM DanhMuc WHERE MaDM=N'" + MaDM + "'";
            cbMaDM.Text = Functions.GetFieldValues(sql);
            txtSoLuong.Text = dgv.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGia.Text = dgv.CurrentRow.Cells["DonGia"].Value.ToString();
            sql = "SELECT Anh FROM ThucDon WHERE MaMon=N'" + txtMaMon.Text + "'";
            txtAnh.Text = Functions.GetFieldValues(sql);
            picAnh.Image = Image.FromFile(txtAnh.Text);
            sql = "SELECT Ghichu FROM ThucDon WHERE MaMon = N'" + txtMaMon.Text + "'";
            txtGhiChu.Text = Functions.GetFieldValues(sql);
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
            txtMaMon.Enabled = true;
            txtMaMon.Focus();
            txtAnh.Enabled = false;

            txtSoLuong.Enabled = true;
            txtDonGia.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                if (txtMaMon.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaMon.Focus();
                    return;
                }
                if (txtTenMon.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenMon.Focus();
                    return;
                }
                if (cbMaDM.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaDM.Focus();
                    return;
                }
                if (txtAnh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnMo.Focus();
                    return;
                }
                sql = "SELECT MaMon FROM ThucDon WHERE MaMon=N'" + txtMaMon.Text.Trim() + "'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã món này đã tồn tại, bạn phải chọn mã món khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaMon.Focus();
                    txtMaMon.Text = "";
                    return;
                }
                sql = "SELECT TenMon FROM ThucDon WHERE TenMon=N'" + txtTenMon.Text.Trim() + "'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Tên món này đã tồn tại, bạn phải chọn tên món khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenMon.Focus();
                    txtTenMon.Text = "";
                    return;
                }
                sql = "INSERT INTO ThucDon(MaMon,TenMon,MaDM,SoLuong,DonGia,Anh,Ghichu) VALUES(N'"
                    + txtMaMon.Text.Trim() + "',N'" + txtTenMon.Text.Trim() +
                    "',N'" + cbMaDM.SelectedValue.ToString() +
                    "'," + txtSoLuong.Text.Trim() + "," + txtDonGia.Text +
                    ",'" + txtAnh.Text + "',N'" + txtGhiChu.Text.Trim() + "')";

                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
                txtMaMon.Enabled = false;
                txtAnh.Enabled = false;
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
                if (txtMaMon.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaMon.Focus();
                    return;
                }
                if (txtTenMon.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenMon.Focus();
                    return;
                }
                if (cbMaDM.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaDM.Focus();
                    return;
                }
                if (txtAnh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho món ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAnh.Focus();
                    return;
                }
                sql = "UPDATE ThucDon SET TenMon=N'" + txtTenMon.Text.Trim().ToString() +
                    "',MaDM=N'" + cbMaDM.SelectedValue.ToString() +
                    "',SoLuong=" + txtSoLuong.Text +
                    ",DonGia=" + txtDonGia.Text +
                    ",Anh='" + txtAnh.Text + "',Ghichu=N'" + txtGhiChu.Text + "' WHERE MaMon=N'" + txtMaMon.Text + "'";
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
                sql = "SELECT COUNT(*) FROM ChiTietHD WHERE MaMon=N'" + txtMaMon.Text + "'";
                if (Functions.CheckKeyDelete(sql))
                {
                    MessageBox.Show("Bản ghi đang được sử dụng tại bảng hóa đơn, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tbl.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtMaMon.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "DELETE ThucDon WHERE MaMon=N'" + txtMaMon.Text + "'";
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
            txtMaMon.Enabled = false;
            txtAnh.Enabled = false;
        }

        private void btnMo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
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
                    sql = "SELECT * FROM ThucDon WHERE TenMon LIKE N'%" + txtTimKiem.Text + "%' OR MaMon LIKE '%" + txtTimKiem.Text + "%'";
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

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaMon,TenMon, MaDM, SoLuong, DonGia, Anh, Ghichu FROM ThucDon";
            tbl = Functions.GetDataToTable(sql);
            dgv.DataSource = tbl;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
