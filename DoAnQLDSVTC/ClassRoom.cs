using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class ClassRoom : Form
    {
        enum STATE_ACTION
        {
            ADD,
            EDIT
        }
        private STATE_ACTION currentAction = STATE_ACTION.ADD;

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
            ActionForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            string khoaHoc = txtKhoaHoc.Text.Trim();
            string maKhoa = txtMaKhoa.Text.Trim();


            switch(currentAction)
            {
                case STATE_ACTION.ADD:
                    LOPTableAdapter.Insert(maLop, tenLop, khoaHoc, maKhoa);
                    LOPTableAdapter.Fill(DS.LOP);
                    CleanTextBox();
                    break;

                case STATE_ACTION.EDIT:
                    DS.LOPRow row = DS.LOP.FindByMALOP(txtMaLop.Text.Trim());
                    if (row == null)
                    {
                        MessageBox.Show("Không tìm thấy lớp");
                        return;
                    }

                    row.TENLOP = txtTenLop.Text.Trim();
                    row.KHOAHOC = txtKhoaHoc.Text.Trim();
                    row.MAKHOA = txtMaKhoa.Text.Trim();

                    LOPTableAdapter.Update(DS.LOP);
                    break;
            }    
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanTextBox();
            currentAction = STATE_ACTION.ADD;
            ActionForm();
        }

        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            switch (dgvLop.Columns[e.ColumnIndex].Name)
            {
                case "Edit":
                    MessageBox.Show("Edit");
                    DataGridViewRow row = dgvLop.Rows[e.RowIndex];
                    txtMaLop.Enabled = false;

                    txtMaLop.Text = row.Cells["MALOP"].Value?.ToString();
                    txtTenLop.Text = row.Cells["TENLOP"].Value?.ToString();
                    txtKhoaHoc.Text = row.Cells["KHOAHOC"].Value?.ToString();
                    currentAction = STATE_ACTION.EDIT;
                    ActionForm();

                    break;

                case "Delete":
                    MessageBox.Show("Delete");
                    bdsLop.RemoveCurrent();
                    LOPTableAdapter.Update(DS.LOP);
                    break;
            }

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
        }

        void ActionForm()
        {
            string strTitle = "";
            string strClear = "";

            switch (currentAction)
            {
                case STATE_ACTION.ADD:
                    strTitle = "Thêm Mới Dữ Liệu";
                    strClear = "Làm Mới";
                    txtMaLop.Enabled = true;
                    lblTitleForm.Text = strTitle;
                    btnClear.Text = strClear;
                    break;

                case STATE_ACTION.EDIT:
                    strTitle = "Chỉnh Sửa Dữ Liệu";
                    strClear = "Hủy";
                    txtMaLop.Enabled = false;
                    lblTitleForm.Text = strTitle;
                    btnClear.Text = strClear;
                    break;
            }
        }
    }
}
