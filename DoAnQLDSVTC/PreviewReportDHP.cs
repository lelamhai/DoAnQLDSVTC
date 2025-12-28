using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class PreviewReportDHP : Form
    {
        string _maLop;
        string _nienKhoa;
        int _hocKy;
        public PreviewReportDHP(string maLop, string nienKhoa, int hocKy)
        {
            this._maLop = maLop;
            this._nienKhoa = nienKhoa;
            this._hocKy = hocKy;
            InitializeComponent();
        }

        private void PreviewReportDHP_Load(object sender, EventArgs e)
        {
            try
            {
                this.SP_REPORT_TONGHOCPHI_DONGHOCPHILOPTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_REPORT_TONGHOCPHI_DONGHOCPHILOPTableAdapter.Fill(this.DS1.SP_REPORT_TONGHOCPHI_DONGHOCPHILOP, _maLop, _nienKhoa, _hocKy);

                this.SP_REPORT_LAYDS_DONGHOCPHILOPTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_REPORT_LAYDS_DONGHOCPHILOPTableAdapter.Fill(this.DS1.SP_REPORT_LAYDS_DONGHOCPHILOP, _maLop, _nienKhoa, _hocKy);
                int amount = this.DS1.SP_REPORT_LAYDS_DONGHOCPHILOP.Rows.Count;
                if (amount == 0)
                {
                    MessageBox.Show("Sinh viên chưa có điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
                reportViewer1.LocalReport.ReportEmbeddedResource = "DoAnQLDSVTC.TemplateReportDHP.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LAYDS_DONGHOCPHILOP", this.DS1.SP_REPORT_LAYDS_DONGHOCPHILOP.DefaultView));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("TONGHOCPHI_DONGHOCPHILOP", this.DS1.SP_REPORT_TONGHOCPHI_DONGHOCPHILOP.DefaultView));
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
