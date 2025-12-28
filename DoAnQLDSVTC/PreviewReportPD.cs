using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class PreviewReportPD : Form
    {
        string _maSV;
        public PreviewReportPD(string maSV)
        {
            this._maSV = maSV;
            InitializeComponent();
        }

        private void PreviewReportPD_Load(object sender, EventArgs e)
        {
            try
            {
                this.SP_REPORT_LAYTHONGTINSV_PHIEUDIEMTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_REPORT_LAYTHONGTINSV_PHIEUDIEMTableAdapter.Fill(this.DS.SP_REPORT_LAYTHONGTINSV_PHIEUDIEM, _maSV);

                this.SP_REPORT_PHIEUDIEMTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_REPORT_PHIEUDIEMTableAdapter.Fill(this.DS.SP_REPORT_PHIEUDIEM, _maSV);
                int amount = this.DS.SP_REPORT_PHIEUDIEM.Rows.Count;
                if (amount == 0)
                {
                    MessageBox.Show("Sinh viên chưa có điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
                reportViewer1.LocalReport.ReportEmbeddedResource = "DoAnQLDSVTC.TemplateReportPD.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LAY_THONGTINSV", this.DS.SP_REPORT_LAYTHONGTINSV_PHIEUDIEM.DefaultView));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LAY_PHIEUDIEM", this.DS.SP_REPORT_PHIEUDIEM.DefaultView));
                this.reportViewer1.RefreshReport();
                this.Opacity = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
        }
    }
}
