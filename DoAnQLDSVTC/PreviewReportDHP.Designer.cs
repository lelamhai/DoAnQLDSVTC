namespace DoAnQLDSVTC
{
    partial class PreviewReportDHP
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
            this.dbsLAYDS_DONGPHILOP = new System.Windows.Forms.BindingSource(this.components);
            this.DS1 = new DoAnQLDSVTC.DS1();
            this.SP_REPORT_LAYDS_DONGHOCPHILOPTableAdapter = new DoAnQLDSVTC.DS1TableAdapters.SP_REPORT_LAYDS_DONGHOCPHILOPTableAdapter();
            this.dbsTONGHOCPHI_DONGHOCPHILOP = new System.Windows.Forms.BindingSource(this.components);
            this.SP_REPORT_TONGHOCPHI_DONGHOCPHILOPTableAdapter = new DoAnQLDSVTC.DS1TableAdapters.SP_REPORT_TONGHOCPHI_DONGHOCPHILOPTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dbsLAYDS_DONGPHILOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsTONGHOCPHI_DONGHOCPHILOP)).BeginInit();
            this.SuspendLayout();
            // 
            // dbsLAYDS_DONGPHILOP
            // 
            this.dbsLAYDS_DONGPHILOP.DataMember = "SP_REPORT_LAYDS_DONGHOCPHILOP";
            this.dbsLAYDS_DONGPHILOP.DataSource = this.DS1;
            // 
            // DS1
            // 
            this.DS1.DataSetName = "DS1";
            this.DS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_REPORT_LAYDS_DONGHOCPHILOPTableAdapter
            // 
            this.SP_REPORT_LAYDS_DONGHOCPHILOPTableAdapter.ClearBeforeFill = true;
            // 
            // dbsTONGHOCPHI_DONGHOCPHILOP
            // 
            this.dbsTONGHOCPHI_DONGHOCPHILOP.DataMember = "SP_REPORT_TONGHOCPHI_DONGHOCPHILOP";
            this.dbsTONGHOCPHI_DONGHOCPHILOP.DataSource = this.DS1;
            // 
            // SP_REPORT_TONGHOCPHI_DONGHOCPHILOPTableAdapter
            // 
            this.SP_REPORT_TONGHOCPHI_DONGHOCPHILOPTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(695, 1013);
            this.reportViewer1.TabIndex = 0;
            // 
            // PreviewReportDHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 1013);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PreviewReportDHP";
            this.Text = "PreviewReportDHP";
            this.Load += new System.EventHandler(this.PreviewReportDHP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbsLAYDS_DONGPHILOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsTONGHOCPHI_DONGHOCPHILOP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource dbsLAYDS_DONGPHILOP;
        private DS1 DS1;
        private DS1TableAdapters.SP_REPORT_LAYDS_DONGHOCPHILOPTableAdapter SP_REPORT_LAYDS_DONGHOCPHILOPTableAdapter;
        private System.Windows.Forms.BindingSource dbsTONGHOCPHI_DONGHOCPHILOP;
        private DS1TableAdapters.SP_REPORT_TONGHOCPHI_DONGHOCPHILOPTableAdapter SP_REPORT_TONGHOCPHI_DONGHOCPHILOPTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}