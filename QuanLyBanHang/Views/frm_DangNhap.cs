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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using QuanLyBanHang.Class;
using GUI;

namespace QuanLy
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text;
            string Quyen = "";

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password) || username.Contains(" ") && password.Contains(" "))
            {
                MessageBox.Show("Bạn chưa đăng nhập tài khoản và mật khẩu! Vui lòng nhập lại");
                txtTaiKhoan.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Tài khoản không được để trống! Vui lòng nhập lại.");
                txtTaiKhoan.Focus();
                return;
            }

            else if (username.Contains(" "))
            {
                MessageBox.Show("Tài khoản không được chứa khoảng trắng! Vui lòng nhập lại.");
                txtTaiKhoan.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Mật khẩu không được để trống! Vui lòng nhập lại.");
                txtMatKhau.Focus();
                return;
            }

            else if (password.Contains(" "))
            {
                MessageBox.Show("Mật khẩu không được chứa khoảng trắng! Vui lòng nhập lại.");
                txtMatKhau.Focus();
                return;
            }

            else if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 6 ký tự");
                txtMatKhau.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection())
            {
                Functions.Connect(conn);

                string query = $"SELECT Quyen FROM TaiKhoan WHERE TenDangNhap COLLATE SQL_Latin1_General_CP1_CS_AS = '{username}' AND MatKhau = '{password}'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Quyen = reader.GetString(0);
                            //MessageBox.Show("Xin chúc mừng bạn đã đăng nhập thành công hệ thống!");
                            frm_Main frm = new frm_Main(Quyen);
                            frm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không đúng! Vui lòng nhập lại.");
                            txtTaiKhoan.Focus();
                        }
                    }
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frm_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            if (MessageBox.Show("Bạn có thật sự muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
            */
        }

        private bool isPasswordVisible = false;

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                txtMatKhau.PasswordChar = '●';
                isPasswordVisible = false;
            }
            else
            {
                txtMatKhau.PasswordChar = char.MinValue;
                isPasswordVisible = true;
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '●';
        }
    }
}
