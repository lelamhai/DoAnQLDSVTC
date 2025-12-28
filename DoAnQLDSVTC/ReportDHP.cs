using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class ReportDHP : Form
    {
        public ReportDHP()
        {
            InitializeComponent();
        }

        private void ReportDHP_Load(object sender, EventArgs e)
        {
            SetTitle();
            SetupBeigin();
            SetupEnd();
            LoadNienKhoa();
            label1.Focus();
        }
        private void LoadNienKhoa()
        {
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        private void SetupBeigin()
        {
            dtpBeigin.Format = DateTimePickerFormat.Custom;
            dtpBeigin.CustomFormat = "yyyy";
            dtpBeigin.ShowUpDown = true;
            dtpBeigin.Value = new DateTime(dtpBeigin.Value.Year, 1, 1);
        }
        private void SetupEnd()
        {
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "yyyy";
            dtpEnd.ShowUpDown = true;
            dtpEnd.Value = new DateTime(dtpBeigin.Value.Year + 1, 1, 1);
        }


        private void SetTitle()
        {
            label1.Text = "Chọn Điều Kiện In\r\nDanh Sách Sinh Viên Đóng Học Phí";
        }

        private void dtpBeigin_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.Value = new DateTime(dtpBeigin.Value.Year + 1, 1, 1);
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            dtpBeigin.Value = new DateTime(dtpEnd.Value.Year - 1, 1, 1);
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PreviewReportDHP formReport = new PreviewReportDHP(txtMaLop.Text.Trim(), txtNienKhoa.Text.Trim(), (int)nudHocKy.Value);
            formReport.Opacity = 0;
            formReport.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Admin parent = this.TopLevelControl as Admin;
            parent.CloseForm(this);
        }
    }
}
