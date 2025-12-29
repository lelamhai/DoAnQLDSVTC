using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class ReportTK : Form
    {
        public ReportTK()
        {
            InitializeComponent();
        }

        private void ReportTK_Load(object sender, EventArgs e)
        {
            SetTitle();
            LoadDatasetApdapter();
            LoadCombox();
            
        }

        void SetTitle()
        {
            label1.Text = "Chọn Điều Kiện In\r\nBảng Điểm Tổng Kết Cuối Khóa";
        }   

        private void LoadDatasetApdapter()
        {
            this.LOPTableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.LOPTableAdapter.Fill(this.DS.LOP);
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PreviewReportTK formReport = new PreviewReportTK(cmbLop.SelectedValue.ToString().Trim());
            formReport.Opacity = 0;
            formReport.ShowDialog();
        }
    }
}
