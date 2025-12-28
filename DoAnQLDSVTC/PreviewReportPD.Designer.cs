namespace DoAnQLDSVTC
{
    partial class PreviewReportPD
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
            this.dbsREPORT_PD = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new DoAnQLDSVTC.DS();
            this.SP_REPORT_PHIEUDIEMTableAdapter = new DoAnQLDSVTC.DSTableAdapters.SP_REPORT_PHIEUDIEMTableAdapter();
            this.dbsREPORT_THONGTINSV = new System.Windows.Forms.BindingSource(this.components);
            this.SP_REPORT_LAYTHONGTINSV_PHIEUDIEMTableAdapter = new DoAnQLDSVTC.DSTableAdapters.SP_REPORT_LAYTHONGTINSV_PHIEUDIEMTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dbsREPORT_PD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsREPORT_THONGTINSV)).BeginInit();
            this.SuspendLayout();
            // 
            // dbsREPORT_PD
            // 
            this.dbsREPORT_PD.DataMember = "SP_REPORT_PHIEUDIEM";
            this.dbsREPORT_PD.DataSource = this.DS;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_REPORT_PHIEUDIEMTableAdapter
            // 
            this.SP_REPORT_PHIEUDIEMTableAdapter.ClearBeforeFill = true;
            // 
            // dbsREPORT_THONGTINSV
            // 
            this.dbsREPORT_THONGTINSV.DataMember = "SP_REPORT_LAYTHONGTINSV_PHIEUDIEM";
            this.dbsREPORT_THONGTINSV.DataSource = this.DS;
            // 
            // SP_REPORT_LAYTHONGTINSV_PHIEUDIEMTableAdapter
            // 
            this.SP_REPORT_LAYTHONGTINSV_PHIEUDIEMTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoAnQLDSVTC.TemplateReportPD.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 568);
            this.reportViewer1.TabIndex = 0;
            // 
            // PreviewReportPD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 568);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PreviewReportPD";
            this.Text = "Báo Cáo";
            this.Load += new System.EventHandler(this.PreviewReportPD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbsREPORT_PD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsREPORT_THONGTINSV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource dbsREPORT_PD;
        private DS DS;
        private DSTableAdapters.SP_REPORT_PHIEUDIEMTableAdapter SP_REPORT_PHIEUDIEMTableAdapter;
        private System.Windows.Forms.BindingSource dbsREPORT_THONGTINSV;
        private DSTableAdapters.SP_REPORT_LAYTHONGTINSV_PHIEUDIEMTableAdapter SP_REPORT_LAYTHONGTINSV_PHIEUDIEMTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}