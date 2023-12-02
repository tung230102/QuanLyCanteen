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
    public partial class Form1 : Form
    {
        DataTable tbl;
        string sql;
        public Form1()
        {
            InitializeComponent();
            Functions.Connect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            sql = "SELECT * FROM DanhMuc";
            tbl = Functions.GetDataToTable(sql);
            dgv.DataSource = tbl;
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            txtMaDM.Text = dgv.CurrentRow.Cells["MaDM"].Value.ToString().Trim();
            txtTenDM.Text = dgv.CurrentRow.Cells["TenDanhMuc"].Value.ToString().Trim();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            sql = "INSERT INTO DanhMuc VALUES(N'" + txtMaDM.Text.Trim() + "', N'" + txtTenDM.Text.Trim() + "')";
            Functions.RunSQL(sql);
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            sql = "DELETE DanhMuc WHERE MaDM='" + txtMaDM.Text + "'";
            Functions.RunSQL(sql);
            LoadData();
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            sql = "UPDATE DanhMuc SET TenDanhMuc=N'" + txtTenDM.Text.Trim() + "' WHERE MaDM='" + txtMaDM.Text + "'";
            Functions.RunSQL(sql);
            LoadData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            sql = "SELECT * FROM DanhMuc WHERE TenDanhMuc LIKE N'%" + txtTimKiem.Text.Trim() + "%'";
            tbl = Functions.GetDataToTable(sql);
            dgv.DataSource = tbl;
        }
    }
}
