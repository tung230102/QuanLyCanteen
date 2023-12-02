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
using Microsoft.Reporting.WinForms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang.Report
{
    public partial class frm_ReportDoanhThu : Form
    {
        public frm_ReportDoanhThu()
        {
            InitializeComponent();
        }

        private void frm_ReportDoanhThu_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                Functions.Connect(conn);
                string sql = "SELECT * FROM HoaDon";
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
                dap.Fill(ds);

                reportDoanhThu.ProcessingMode = ProcessingMode.Local;
                reportDoanhThu.LocalReport.ReportEmbeddedResource = "QuanLyBanHang.ReportRDLC.ReportDoanhThu.rdlc";


                ReportDataSource rds = new ReportDataSource();
                rds.Name = "HoaDon";
                rds.Value = ds.Tables[0];
                reportDoanhThu.LocalReport.DataSources.Clear();
                reportDoanhThu.LocalReport.DataSources.Add(rds);
                reportDoanhThu.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.reportDoanhThu.RefreshReport();
        }
    }
}
