namespace QuanLyBanHang.Report
{
    partial class frm_ReportThucDonDate
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
            this.btnBCNgay = new System.Windows.Forms.Button();
            this.reportTDDate = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.btnBCThang = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textNam = new System.Windows.Forms.TextBox();
            this.btnBCNam = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBCNgay
            // 
            this.btnBCNgay.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBCNgay.Location = new System.Drawing.Point(97, 55);
            this.btnBCNgay.Margin = new System.Windows.Forms.Padding(2);
            this.btnBCNgay.Name = "btnBCNgay";
            this.btnBCNgay.Size = new System.Drawing.Size(75, 30);
            this.btnBCNgay.TabIndex = 4;
            this.btnBCNgay.Text = "Báo cáo";
            this.btnBCNgay.UseVisualStyleBackColor = true;
            this.btnBCNgay.Click += new System.EventHandler(this.btnBCNgay_Click);
            // 
            // reportTDDate
            // 
            this.reportTDDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportTDDate.Location = new System.Drawing.Point(0, 0);
            this.reportTDDate.Margin = new System.Windows.Forms.Padding(2);
            this.reportTDDate.Name = "reportTDDate";
            this.reportTDDate.ServerReport.BearerToken = null;
            this.reportTDDate.Size = new System.Drawing.Size(784, 361);
            this.reportTDDate.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtNam);
            this.groupBox2.Controls.Add(this.txtThang);
            this.groupBox2.Controls.Add(this.btnBCThang);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(261, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(260, 100);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Doanh Thu Tháng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "/";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(140, 25);
            this.txtNam.Margin = new System.Windows.Forms.Padding(2);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(50, 22);
            this.txtNam.TabIndex = 6;
            this.txtNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNam_KeyPress);
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(70, 25);
            this.txtThang.Margin = new System.Windows.Forms.Padding(2);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(50, 22);
            this.txtThang.TabIndex = 5;
            this.txtThang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThang_KeyPress);
            // 
            // btnBCThang
            // 
            this.btnBCThang.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBCThang.Location = new System.Drawing.Point(93, 55);
            this.btnBCThang.Margin = new System.Windows.Forms.Padding(2);
            this.btnBCThang.Name = "btnBCThang";
            this.btnBCThang.Size = new System.Drawing.Size(75, 30);
            this.btnBCThang.TabIndex = 4;
            this.btnBCThang.Text = "Báo cáo";
            this.btnBCThang.UseVisualStyleBackColor = true;
            this.btnBCThang.Click += new System.EventHandler(this.btnBCThang_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtNgay);
            this.groupBox1.Controls.Add(this.btnBCNgay);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(260, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doanh Thu Ngày";
            // 
            // dtNgay
            // 
            this.dtNgay.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgay.Location = new System.Drawing.Point(84, 25);
            this.dtNgay.Margin = new System.Windows.Forms.Padding(2);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(100, 22);
            this.dtNgay.TabIndex = 1;
            this.dtNgay.Value = new System.DateTime(2023, 5, 23, 16, 44, 0, 0);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textNam);
            this.groupBox3.Controls.Add(this.btnBCNam);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(522, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(260, 100);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Doanh Thu Năm";
            // 
            // textNam
            // 
            this.textNam.Location = new System.Drawing.Point(105, 25);
            this.textNam.Margin = new System.Windows.Forms.Padding(2);
            this.textNam.Name = "textNam";
            this.textNam.Size = new System.Drawing.Size(50, 22);
            this.textNam.TabIndex = 5;
            this.textNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNam_KeyPress);
            // 
            // btnBCNam
            // 
            this.btnBCNam.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBCNam.Location = new System.Drawing.Point(93, 55);
            this.btnBCNam.Margin = new System.Windows.Forms.Padding(2);
            this.btnBCNam.Name = "btnBCNam";
            this.btnBCNam.Size = new System.Drawing.Size(75, 30);
            this.btnBCNam.TabIndex = 4;
            this.btnBCNam.Text = "Báo cáo";
            this.btnBCNam.UseVisualStyleBackColor = true;
            this.btnBCNam.Click += new System.EventHandler(this.btnBCNam_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportTDDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 361);
            this.panel2.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 100);
            this.panel1.TabIndex = 18;
            // 
            // frm_ReportThucDonDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_ReportThucDonDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBCNgay;
        private Microsoft.Reporting.WinForms.ReportViewer reportTDDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.Button btnBCThang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textNam;
        private System.Windows.Forms.Button btnBCNam;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}