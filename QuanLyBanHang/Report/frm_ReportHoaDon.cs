using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang.Report
{
    public partial class frm_ReportHoaDon : Form
    {
        public frm_ReportHoaDon()
        {
            InitializeComponent();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            Functions.Connect(conn);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BCMHDTheoNgay";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@Ngay", dtpBaoCao.Value.Date));
            //Khai bao dateset de chua du lieu
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(ds);
            //Thiet lap bao cao
            rpvBaoCao.ProcessingMode = ProcessingMode.Local;
            rpvBaoCao.LocalReport.ReportPath = "D:\\QuanLy\\QuanLyBanHang\\ReportRDLC\\ReportHoaDon.rdlc";

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsBCMHDTheoNgay";
            rds.Value = ds.Tables[0];
            //Gan len mau bao cao
            rpvBaoCao.LocalReport.DataSources.Clear();
            rpvBaoCao.LocalReport.DataSources.Add(rds);
            rpvBaoCao.RefreshReport();

        }

        private void frm_ReportBaoCao_Load(object sender, EventArgs e)
        {
            this.rpvBaoCao.RefreshReport();
        }
    }
}
