using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class ClassRoom : Form
    {
        public ClassRoom()
        {
            InitializeComponent();
        }

        private void ClassRoom_Load(object sender, EventArgs e)
        {
            LoadDatasetApdapter();
            LoadCombox();
            LoadNameLogin();
            CleanTextBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            string khoaHoc = txtKhoaHoc.Text.Trim();
            string maKhoa = txtMaKhoa.Text.Trim();

            LOPTableAdapter.Insert(maLop, tenLop, khoaHoc, maKhoa);
            LOPTableAdapter.Fill(DS.LOP);
            CleanTextBox();
        }
        
        void LoadDatasetApdapter()
        {
            this.LOPTableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.LOPTableAdapter.Fill(this.DS.LOP);
        }

        void LoadCombox()
        {
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.MKhoa;

            Program.bds_dspm.Filter = "TENKHOA <> 'PHÒNG KẾ TOÁN'";
        }

        void LoadNameLogin()
        {
            lblLogin.Text = "Xin chào " + Program.MLogin + "!";
        }

        void CleanTextBox()
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            txtKhoaHoc.Text = "";
            txtMaKhoa.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanTextBox();
        }
    }
}
