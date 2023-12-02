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

namespace QuanLyBanHang
{
    public partial class Form2 : Form
    {
        DataTable tbl;
        string str, sql;
        //double sl, SLcon, tong, Tongmoi;
        public Form2()
        {
            InitializeComponent();
            txtMaHD.Enabled = true;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            Functions.FillCombo("SELECT * FROM KhachHang", cboMaKH, "MaKH", "TenKH");
            cboMaKH.SelectedIndex = -1;
            Functions.FillCombo("SELECT * FROM NguoiDung", cboMaND, "MaND", "TenND");
            cboMaND.SelectedIndex = -1;
            Functions.FillCombo("SELECT * FROM ThucDon", cboMaMon, "MaMon", "TenMon");
            cboMaMon.SelectedIndex = -1;
            LoadInfo();
            LoadData();
        }

        private void LoadInfo()
        {
            str = "SELECT NgayBan FROM HoaDonCT WHERE MaHD=N'" + txtMaHD + "'";
            dtpNgayBan.Text = Functions.GetFieldValues(str);
            str = "SELECT MaND FROM HoaDonCT WHERE MaHD=N'" + txtMaHD + "'";
            cboMaND.SelectedValue = Functions.GetFieldValues(str);
            str = "SELECT MaKH FROM HoaDonCT WHERE MaHD=N'" + txtMaHD + "'";
            cboMaKH.SelectedValue = Functions.GetFieldValues(str);
            str = "SELECT TongTien FROM HoaDonCT WHERE MaHD=N'" + txtMaHD + "'";
            txtTongTien.Text = Functions.GetFieldValues(str);

        }

        private void LoadData()
        {
            sql = "SELECT * FROM HoaDonCT";
            tbl = Functions.GetDataToTable(sql);
            dgvHDBanHang.DataSource = tbl;
            dgvHDBanHang.Columns[0].HeaderText = "";

            dgvHDBanHang.Columns[0].HeaderText = "Mã món";
            dgvHDBanHang.Columns[1].HeaderText = "Tên món";
            dgvHDBanHang.Columns[2].HeaderText = "Số lượng";
            dgvHDBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvHDBanHang.Columns[4].HeaderText = "Thành tiền";
            dgvHDBanHang.Columns[0].Width = 100;
            dgvHDBanHang.Columns[1].Width = 150;
            dgvHDBanHang.Columns[2].Width = 100;
            dgvHDBanHang.Columns[3].Width = 100;
            dgvHDBanHang.Columns[4].Width = 150;
            dgvHDBanHang.AllowUserToAddRows = false;
            dgvHDBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void cboMaND_SelectedIndexChanged(object sender, EventArgs e)
        {
            str = "SELECT TenND FROM NguoiDung WHERE MaND=N'" + cboMaND.SelectedValue + "'";
            txtTenND.Text = Functions.GetFieldValues(str);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dongia;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtDonGia.Text == "")
                dongia = 0;
            else
                dongia = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dongia - sl * dongia / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            str = "SELECT TenKH FROM KhachHang WHERE MaKH=N'" + cboMaKH.SelectedValue + "'";
            txtTenKH.Text = Functions.GetFieldValues(str);
            str = "SELECT DiaChi FROM KhachHang WHERE MaKH=N'" + cboMaKH.SelectedValue + "'";
            txtDiaChi.Text = Functions.GetFieldValues(str);
            str = "SELECT SDT FROM KhachHang WHERE MaKH=N'" + cboMaKH.SelectedValue + "'";
            txtDienThoai.Text = Functions.GetFieldValues(str);
        }

        private void cboMaMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            str = "SELECT TenMon FROM ThucDon WHERE MaMon =N'" + cboMaMon.SelectedValue + "'";
            txtTenMon.Text = Functions.GetFieldValues(str);
            str = "SELECT DonGia FROM ThucDon WHERE MaMon =N'" + cboMaMon.SelectedValue + "'";
            txtDonGia.Text = Functions.GetFieldValues(str);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaHD.Text =Functions.CreateKey("HD");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO HoaDonCT VALUES(N'" + txtMaHD.Text + "'" +
                                ",N'" + cboMaND.SelectedValue + "'" +
                                ",N'" + cboMaKH.SelectedValue + "'" +
                                ",N'" + dtpNgayBan.Value.ToString("yyyy-MM-dd") + "'" +
                                ",'" + txtTongTien.Text + "'" +
                                ",N'" + cboMaMon.SelectedValue + "'" +
                                ",N'" + txtSoLuong.Text + "'" +
                                ",N'" + txtDonGia.Text + "'" +
                                ",N'" + txtThanhTien.Text + "')";

                Functions.RunSQL(sql);

                // Thực hiện thành công, hiển thị thông báo thành công cho người dùng
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Xảy ra lỗi, hiển thị thông báo lỗi cho người dùng
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
