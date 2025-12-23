using System;
using System.Data;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class ReportLTC : Form
    {
        private int currentKhoa;

        public ReportLTC()
        {
            InitializeComponent();
        }

        private void ReportLTC_Load(object sender, EventArgs e)
        {
            LoadCombox();
            SetupBeigin();
            SetupEnd();
            LoadNienKhoa();
        }

        void LoadCombox()
        {
            Program.bds_dspm.Filter = "TENKHOA <> 'PHÒNG KẾ TOÁN'";
         
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.MKhoa;

            string quyen = Program.mGroup;
            if (quyen == Program.quyen[1])
            {
                cmbKhoa.Enabled = false;
            }
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

        private void LoadNienKhoa()
        {
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
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

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Visible || this.IsDisposed) return;
            int newIndex = cmbKhoa.SelectedIndex;

            if (newIndex < 0) return;
            if (cmbKhoa.SelectedValue.ToString() == "System.Data.DataRowView") return;
            currentKhoa = newIndex;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)cmbKhoa.Items[currentKhoa];
            string nameServer = row["TENKHOA"].ToString().Trim();

            FormReportDSLTC formReport = new FormReportDSLTC(nameServer.ToUpper(), txtNienKhoa.Text, (int)nudHocKy.Value);
            formReport.Opacity = 0;
            formReport.ShowDialog();
        }
    }
}
