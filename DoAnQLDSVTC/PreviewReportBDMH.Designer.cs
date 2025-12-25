namespace DoAnQLDSVTC
{
    partial class PreviewReportBDMH
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
            this.dbsBDMH = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new DoAnQLDSVTC.DS();
            this.SP_REPORT_LAYDS_BDMHLTCTableAdapter = new DoAnQLDSVTC.DSTableAdapters.SP_REPORT_LAYDS_BDMHLTCTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dbsBDMH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // dbsBDMH
            // 
            this.dbsBDMH.DataMember = "SP_REPORT_LAYDS_BDMHLTC";
            this.dbsBDMH.DataSource = this.DS;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_REPORT_LAYDS_BDMHLTCTableAdapter
            // 
            this.SP_REPORT_LAYDS_BDMHLTCTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "LAYDS_BDMH_LTC";
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoAnQLDSVTC.TemplateReportBDMH.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(915, 991);
            this.reportViewer1.TabIndex = 0;
            // 
            // PreviewReportBDMH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 991);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PreviewReportBDMH";
            this.Text = "Preview Report";
            this.Load += new System.EventHandler(this.PreviewReportBDMH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbsBDMH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource dbsBDMH;
        private DS DS;
        private DSTableAdapters.SP_REPORT_LAYDS_BDMHLTCTableAdapter SP_REPORT_LAYDS_BDMHLTCTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}