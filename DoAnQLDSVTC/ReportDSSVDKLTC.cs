using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class ReportDSSVDKLTC : Form
    {
        private int currentKhoa;

        public ReportDSSVDKLTC()
        {
            InitializeComponent();
        }

        private void ReportDSSVDKLTC_Load(object sender, System.EventArgs e)
        {
            SetTitle();
            LoadDatasetApdapter();
            LoadCombox();
            SetupBeigin();
            SetupEnd();
            LoadNienKhoa();
            label1.Focus();
        }

        private void SetTitle()
        {
            label1.Text = "Chọn Điều Kiện In Danh Sách\r\nSinh Viên Đăng Ký Lớp Tín Chỉ";
        }

        void LoadDatasetApdapter()
        {
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.MONHOCTableAdapter.Fill(this.DS.MONHOC);
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

        private void cmbKhoa_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!this.Visible || this.IsDisposed) return;
            int newIndex = cmbKhoa.SelectedIndex;

            if (newIndex < 0) return;
            if (cmbKhoa.SelectedValue.ToString() == "System.Data.DataRowView") return;
            currentKhoa = newIndex;
        }
    }
}
