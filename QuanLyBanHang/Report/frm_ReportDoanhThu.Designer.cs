namespace QuanLyBanHang.Report
{
    partial class frm_ReportDoanhThu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportDoanhThu = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportDoanhThu
            // 
            this.reportDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.reportDoanhThu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportDoanhThu.Name = "reportDoanhThu";
            this.reportDoanhThu.ServerReport.BearerToken = null;
            this.reportDoanhThu.Size = new System.Drawing.Size(784, 461);
            this.reportDoanhThu.TabIndex = 0;
            // 
            // frm_ReportDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.reportDoanhThu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_ReportDoanhThu";
            this.Text = "frm_ReportDoanhThu";
            this.Load += new System.EventHandler(this.frm_ReportDoanhThu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportDoanhThu;
    }
}