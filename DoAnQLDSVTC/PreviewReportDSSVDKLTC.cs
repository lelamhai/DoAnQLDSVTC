using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class PreviewReportDSSVDKLTC : Form
    {
        private string _khoa;
        private string _nienkhoa;
        private int _hocky;
        private string _maMH;
        private string _tenMH;
        private int _nhom;
        
        public PreviewReportDSSVDKLTC(string khoa, string nienkhoa, int hocky,string maMH, string tenMH, int nhom)
        {
            this._khoa = khoa;
            this._nienkhoa = nienkhoa;
            this._hocky = hocky;
            this._maMH = maMH;
            this._tenMH = tenMH;
            this._nhom = nhom;
            InitializeComponent();
        }

        private void PreviewReportDSSVDKLTC_Load(object sender, EventArgs e)
        {
            try
            {
                this.SP_REPORT_LAYDS_SVDKLTCTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_REPORT_LAYDS_SVDKLTCTableAdapter.Fill(this.DS.SP_REPORT_LAYDS_SVDKLTC, _nienkhoa, _hocky, _maMH, _nhom);
                int amount = this.DS.SP_REPORT_LAYDS_SVDKLTC.Rows.Count;
                if (amount == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                reportViewer1.LocalReport.ReportEmbeddedResource = "DoAnQLDSVTC.ReportDSSVDKLTC.rdlc";
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("pKhoa", _khoa),
                    new ReportParameter("pNienKhoa", _nienkhoa),
                    new ReportParameter("pHocKy", _hocky.ToString()),
                    new ReportParameter("pTenMH", _tenMH),
                    new ReportParameter("pNhom", _nhom.ToString()),
                    new ReportParameter("pAmount", _nhom.ToString()),
                };
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LAYDS_SVDK_LTC", this.DS.SP_REPORT_LAYDS_SVDKLTC.DefaultView));
                this.reportViewer1.RefreshReport();
                this.Opacity = 100;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
        }
    }
}
