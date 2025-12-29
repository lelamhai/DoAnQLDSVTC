namespace DoAnQLDSVTC
{
    partial class PreviewReportTK
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SP_REPORT_LAYDS_DIEMTONGKETLOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new DoAnQLDSVTC.DS();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dbsTK = new System.Windows.Forms.BindingSource(this.components);
            this.SP_REPORT_LAYDS_DIEMTONGKETLOPTableAdapter = new DoAnQLDSVTC.DSTableAdapters.SP_REPORT_LAYDS_DIEMTONGKETLOPTableAdapter();
            this.dbsLAY_THONGTIN_KHOALOP = new System.Windows.Forms.BindingSource(this.components);
            this.SP_REPORT_LAYTHONGTIN_LOPKHOA_DIEMTONGKETLOPTableAdapter = new DoAnQLDSVTC.DSTableAdapters.SP_REPORT_LAYTHONGTIN_LOPKHOA_DIEMTONGKETLOPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORT_LAYDS_DIEMTONGKETLOPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsLAY_THONGTIN_KHOALOP)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_REPORT_LAYDS_DIEMTONGKETLOPBindingSource
            // 
            this.SP_REPORT_LAYDS_DIEMTONGKETLOPBindingSource.DataMember = "SP_REPORT_LAYDS_DIEMTONGKETLOP";
            this.SP_REPORT_LAYDS_DIEMTONGKETLOPBindingSource.DataSource = this.DS;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "LAYDS_TONGKETLOP";
            reportDataSource1.Value = this.SP_REPORT_LAYDS_DIEMTONGKETLOPBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoAnQLDSVTC.TemplateReportTK.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 607);
            this.reportViewer1.TabIndex = 0;
            // 
            // dbsTK
            // 
            this.dbsTK.DataMember = "SP_REPORT_LAYDS_DIEMTONGKETLOP";
            this.dbsTK.DataSource = this.DS;
            // 
            // SP_REPORT_LAYDS_DIEMTONGKETLOPTableAdapter
            // 
            this.SP_REPORT_LAYDS_DIEMTONGKETLOPTableAdapter.ClearBeforeFill = true;
            // 
            // dbsLAY_THONGTIN_KHOALOP
            // 
            this.dbsLAY_THONGTIN_KHOALOP.DataMember = "SP_REPORT_LAYTHONGTIN_LOPKHOA_DIEMTONGKETLOP";
            this.dbsLAY_THONGTIN_KHOALOP.DataSource = this.DS;
            // 
            // SP_REPORT_LAYTHONGTIN_LOPKHOA_DIEMTONGKETLOPTableAdapter
            // 
            this.SP_REPORT_LAYTHONGTIN_LOPKHOA_DIEMTONGKETLOPTableAdapter.ClearBeforeFill = true;
            // 
            // PreviewReportTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 607);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PreviewReportTK";
            this.Text = "PreviewReportTK";
            this.Load += new System.EventHandler(this.PreviewReportTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORT_LAYDS_DIEMTONGKETLOPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsLAY_THONGTIN_KHOALOP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dbsTK;
        private DS DS;
        private DSTableAdapters.SP_REPORT_LAYDS_DIEMTONGKETLOPTableAdapter SP_REPORT_LAYDS_DIEMTONGKETLOPTableAdapter;
        private System.Windows.Forms.BindingSource SP_REPORT_LAYDS_DIEMTONGKETLOPBindingSource;
        private System.Windows.Forms.BindingSource dbsLAY_THONGTIN_KHOALOP;
        private DSTableAdapters.SP_REPORT_LAYTHONGTIN_LOPKHOA_DIEMTONGKETLOPTableAdapter SP_REPORT_LAYTHONGTIN_LOPKHOA_DIEMTONGKETLOPTableAdapter;
    }
}