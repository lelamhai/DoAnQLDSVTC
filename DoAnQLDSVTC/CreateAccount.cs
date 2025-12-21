using System;
using System.Data;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class CreateAccount : Form
    {
        private int currentKhoa;
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            LoadDatasetApdapterTeacher();
            LoadDatasetApdapterRole();
            LoadCombox();
        }

        void LoadCombox()
        {
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.MKhoa;

            Program.bds_dspm.Filter = "TENKHOA <> 'PHÒNG KẾ TOÁN'";

            string quyen = Program.mGroup;
            if (quyen == Program.quyen[1])
            {
                cmbKhoa.Enabled = false;
            }
        }

        void LoadDatasetApdapterTeacher()
        {
            this.GIANGVIENTableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.GIANGVIENTableAdapter.Fill(this.DS.GIANGVIEN);

            if (!DS.GIANGVIEN.Columns.Contains("FULLNAME"))
                DS.GIANGVIEN.Columns.Add("FULLNAME", typeof(string));

            foreach (DataRow row in DS.GIANGVIEN.Rows)
            {
                row["FULLNAME"] = row["HO"].ToString() + " " + row["TEN"].ToString();
            }

            cmbTeacher.DataSource = dbsGiaoVien;
            cmbTeacher.DisplayMember = "FULLNAME";
            cmbTeacher.ValueMember = "MAGV";
        }

        void LoadDatasetApdapterRole()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NHOM", typeof(string));
            if (Program.mGroup == Program.quyen[0])
            {
                dt.Rows.Add("PGV");
                dt.Rows.Add("KHOA");
            }
            if (Program.mGroup == Program.quyen[1])
            {
                dt.Rows.Add("KHOA");
            }
            if (Program.mGroup == Program.quyen[3])
            {
                dt.Rows.Add("PKT");
            }

            cmbRole.DataSource = dt;
            cmbRole.DisplayMember = "NHOM";
            cmbRole.ValueMember = "NHOM";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateUser()) return;
            
            if(cmbRole.SelectedValue.ToString().Trim() == Program.quyen[0])
            {
                if (RolePGV())
                {
                    MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK);
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtPasswordAgain.Text = "";
                }
                else
                {
                    MessageBox.Show("Tạo tài khoản thất bại!\nVui lòng thử lại!!", "Lỗi", MessageBoxButtons.OK);
                }
            }    

            if(cmbRole.SelectedValue.ToString().Trim() == Program.quyen[1])
            {
                Program.KetNoi();
                RoleKhoa();
            }    
        }

        private bool RolePGV()
        {
            bool resultSP = true;
            for (int i = 0; i < Program.bds_dspm.Count; i++)
            {
                Program.ServerName = ((DataRowView)Program.bds_dspm[i])["TENSERVER"].ToString().Trim();
                int result = Program.KetNoi_Goc();
                if (result == 1)
                {
                    string cmd = string.Format("EXEC SP_TAO_LOGIN N'{0}',N'{1}',N'{2}',N'{3}'", txtUserName.Text.Trim(), txtPassword.Text.Trim(), cmbTeacher.SelectedValue.ToString().Trim(), cmbRole.SelectedValue.ToString().Trim());
                    int r = Program.ExecSqlNonQuery(cmd);
                    if(r!=0)
                    {
                        resultSP = false;
                    }    
                }
            }
            Program.Conn.Close();
            return resultSP;
        }

        private void RoleKhoa()
        {
            string cmd = string.Format("EXEC SP_TAO_LOGIN N'{0}',N'{1}',N'{2}',N'{3}'", txtUserName.Text.Trim(), txtPassword.Text.Trim(), cmbTeacher.SelectedValue.ToString().Trim(), cmbRole.SelectedValue.ToString().Trim());
            int result = Program.ExecSqlNonQuery(cmd);
            if (result != 0)
            {
                MessageBox.Show("Tạo tài khoản thất bại!!\nVui lòng thử lại!!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            else
            {
                MessageBox.Show("Tạo tài khoản thành công!", "", MessageBoxButtons.OK);
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtPasswordAgain.Text = "";
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Admin parent = this.TopLevelControl as Admin;
            parent.CloseForm(this);
        }

        private bool ValidateUser()
        {
            
            if (string.IsNullOrWhiteSpace(txtUserName.Text.Trim()))
            {
                lblMessage.Text = "Vui lòng nhập Tài Khoản.";
                txtUserName.Focus();
                return false;
            }

            if (txtUserName.Text.Length < 6)
            {
                lblMessage.Text = "Tài Khoản phải từ 5 ký tự.";
                txtUserName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                lblMessage.Text = "Vui lòng nhập Mật Khẩu.";
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                lblMessage.Text = "Mật Khẩu phải từ 6 ký tự.";
                txtPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPasswordAgain.Text.Trim()))
            {
                lblMessage.Text = "Vui lòng nhập lại Mật Khẩu.";
                txtPasswordAgain.Focus();
                return false;
            }

            if (txtPasswordAgain.Text.Trim() != txtPassword.Text.Trim())
            {
                lblMessage.Text = "Mật Khẩu nhập lại không khớp.";
                txtPasswordAgain.Focus();
                return false;
            }

            lblMessage.Text = "";
            return true;
        }

        private void btnPasswordShow_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            btnPasswordShow.Visible = false;
            btnPasswordHide.Visible = true;
            btnPasswordHide.BringToFront();
            txtPassword.Focus();
        }

        private void btnPasswordHide_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            btnPasswordHide.Visible = false;
            btnPasswordShow.Visible = true;
            btnPasswordShow.BringToFront();
            txtPassword.Focus();
        }
        
        private void btnAgainPasswordShow_Click(object sender, EventArgs e)
        {
            txtPasswordAgain.UseSystemPasswordChar = false;
            btnAgainPasswordShow.Visible = false;
            btnAgainPasswordHide.Visible = true;
            btnAgainPasswordHide.BringToFront();
            txtPasswordAgain.Focus();
        }

        private void btnAgainPasswordHide_Click(object sender, EventArgs e)
        {
            txtPasswordAgain.UseSystemPasswordChar = true;
            btnAgainPasswordHide.Visible = false;
            btnAgainPasswordShow.Visible = true;
            btnAgainPasswordShow.BringToFront();
            txtPasswordAgain.Focus();
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Visible || this.IsDisposed) return;
            if (cmbKhoa.SelectedValue.ToString() == "System.Data.DataRowView") return;

            currentKhoa = cmbKhoa.SelectedIndex;
            Program.ServerName = cmbKhoa.SelectedValue.ToString();
            if (currentKhoa != Program.MKhoa)
            {
                Program.MLogin = Program.remoteLogin;
                Program.MPass = Program.remotePass;
            }
            else
            {
                Program.MLogin = Program.MLoginDN;
                Program.MPass = Program.MPassDN;
            }
            Program.KetNoi();
        }
    }
}
