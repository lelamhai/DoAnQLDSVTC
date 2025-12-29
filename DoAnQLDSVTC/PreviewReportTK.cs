using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class PreviewReportTK : Form
    {
        string _maLop;
        public PreviewReportTK(string maLop)
        {
            this._maLop = maLop;
            InitializeComponent();
        }

        private void PreviewReportTK_Load(object sender, System.EventArgs e)
        {
            try
            {
                DS.EnforceConstraints = false;
                

                this.SP_REPORT_LAYDS_DIEMTONGKETLOPTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_REPORT_LAYDS_DIEMTONGKETLOPTableAdapter.Fill(this.DS.SP_REPORT_LAYDS_DIEMTONGKETLOP, _maLop);
                int amount = this.DS.SP_REPORT_LAYDS_DIEMTONGKETLOP.Rows.Count;
                if (amount == 0)
                {
                    MessageBox.Show("Chưa có dữ liệu để tổng kết cuối khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
                this.SP_REPORT_LAYTHONGTIN_LOPKHOA_DIEMTONGKETLOPTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_REPORT_LAYTHONGTIN_LOPKHOA_DIEMTONGKETLOPTableAdapter.Fill(this.DS.SP_REPORT_LAYTHONGTIN_LOPKHOA_DIEMTONGKETLOP, _maLop);

                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LAYDS_TONGKETLOP", this.DS.SP_REPORT_LAYDS_DIEMTONGKETLOP.DefaultView));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LAY_THONGTIN_KHOALOP", this.DS.SP_REPORT_LAYTHONGTIN_LOPKHOA_DIEMTONGKETLOP.DefaultView));
                
                this.reportViewer1.RefreshReport();
                this.Opacity = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
