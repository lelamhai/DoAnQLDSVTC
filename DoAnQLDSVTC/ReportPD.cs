using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class ReportPD : Form
    {
        public ReportPD()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMaSV.Text.Trim().Length < 10)
            {
                MessageBox.Show("Mã sinh viên phải đủ 10 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PreviewReportPD formReport = new PreviewReportPD(txtMaSV.Text.Trim());
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
