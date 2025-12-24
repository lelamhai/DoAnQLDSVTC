using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
namespace DoAnQLDSVTC
{
    public partial class PreviewReportDSLTC : Form
    {
        private string _khoa;
        private string _nienkhoa;
        private int _hocky;

        public PreviewReportDSLTC(string khoa, string nienkhoa, int hocky)
        {
            this._khoa = khoa;
            this._nienkhoa = nienkhoa;
            this._hocky = hocky;
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.SP_REPORT_LAYDS_LTCTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_REPORT_LAYDS_LTCTableAdapter.Fill(this.DS.SP_REPORT_LAYDS_LTC, _nienkhoa, _hocky);

                int amount = this.DS.SP_REPORT_LAYDS_LTC.Rows.Count;

                if(amount == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }    

                reportViewer1.LocalReport.ReportEmbeddedResource = "DoAnQLDSVTC.ReportDSLTC.rdlc";
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("pKhoa", _khoa),
                    new ReportParameter("pNienKhoa", _nienkhoa),
                    new ReportParameter("pHocKy", _hocky.ToString()),
                    new ReportParameter("pAmount", amount.ToString())
                };
                reportViewer1.LocalReport.SetParameters(parameters);

                
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSLTC", this.DS.SP_REPORT_LAYDS_LTC.DefaultView));
                this.reportViewer1.RefreshReport();
                this.Opacity = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo. " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
