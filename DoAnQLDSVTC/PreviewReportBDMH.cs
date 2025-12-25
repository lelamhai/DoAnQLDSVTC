using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class PreviewReportBDMH : Form
    {
        private string _khoa;
        private string _nienkhoa;
        private int _hocky;
        private string _maMH;
        private string _tenMH;
        private int _nhom;

        public PreviewReportBDMH(string khoa, string nienkhoa, int hocky, string maMH, string tenMH, int nhom)
        {
            this._khoa = khoa;
            this._nienkhoa = nienkhoa;
            this._hocky = hocky;
            this._maMH = maMH;
            this._tenMH = tenMH;
            this._nhom = nhom;
            InitializeComponent();
        }

        private void PreviewReportBDMH_Load(object sender, EventArgs e)
        {
            try
            {
                this.SP_REPORT_LAYDS_BDMHLTCTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_REPORT_LAYDS_BDMHLTCTableAdapter.Fill(this.DS.SP_REPORT_LAYDS_BDMHLTC, _nienkhoa, _hocky, _maMH, _nhom);
                int amount = this.DS.SP_REPORT_LAYDS_BDMHLTC.Rows.Count;
                if (amount == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                reportViewer1.LocalReport.ReportEmbeddedResource = "DoAnQLDSVTC.TemplateReportBDMH.rdlc";
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("pKhoa", _khoa),
                    new ReportParameter("pNienKhoa", _nienkhoa),
                    new ReportParameter("pHocKy", _hocky.ToString()),
                    new ReportParameter("pTenMH", _tenMH),
                    new ReportParameter("pNhom", _nhom.ToString()),
                    new ReportParameter("pAmount", amount.ToString())
                };
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LAYDS_BDMH_LTC", this.DS.SP_REPORT_LAYDS_BDMHLTC.DefaultView));
                this.reportViewer1.RefreshReport();
                this.Opacity = 100;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
