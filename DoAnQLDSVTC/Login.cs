using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class Login : Form
    {
        private SqlConnection Conn_pub = new SqlConnection();

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            if (KetNoi_CSDLGOC() == 0) return;
            LayDSPM("SELECT * FROM V_GET_SUBSCRIBES");
            LoadComboxDefult();
            label1.Focus();
        }

        void LoadComboxDefult()
        {
            int index = 0;
            DataRowView row = (DataRowView)cmbKhoa.Items[index];
            string nameServer = row["TENSERVER"].ToString().Trim();
            Program.ServerName = nameServer;
        }

        private int KetNoi_CSDLGOC()
        {
            if (Conn_pub != null && Conn_pub.State == ConnectionState.Open)
                Conn_pub.Close();
            try
            {
                Conn_pub.ConnectionString = Program.Connstr_pub;
                Conn_pub.Open();
                return 1;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi co so du lieu" + ex.ToString());
                return 0;
            }
        }

        private void LayDSPM(string cmd)
        {
            DataTable dt = new DataTable();
            if (Conn_pub.State == ConnectionState.Closed)
                Conn_pub.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, Conn_pub);
            da.Fill(dt);
            Conn_pub.Close();

            Program.bds_dspm.DataSource = dt;
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateLogin()) return;

            Program.MLogin = txtUserName.Text;
            Program.MPass = txtPassword.Text;
            if (Program.KetNoi() == 0)
            {
                lblMessage.Text = "Xem lại tài khoản, mật khẩu!";
                return;
            }    

            Program.MKhoa = cmbKhoa.SelectedIndex;
            Program.MLoginDN = Program.MLogin;
            Program.MPassDN = Program.MPass;

            string strLenh = "EXEC SP_DANGNHAP '" + Program.MLogin + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;

            Program.myReader.Read();
            Program.userName = Program.myReader.GetString(0);
            Program.mHoTen = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();

            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.ServerName = cmbKhoa.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không có chi nhánh này");
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            btnShow.Visible = false;
            btnHide.Visible = true;
            btnHide.BringToFront();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;

            btnHide.Visible = false;
            btnShow.Visible = true;
            btnShow.BringToFront();
        }

        private bool ValidateLogin()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                lblMessage.Text = "Vui lòng nhập Tài Khoản.";
                txtUserName.Focus();
                return false;
            }

            if (txtUserName.Text.Length < 6)
            {
                lblMessage.Text = "Tài Khoản phải từ 6 ký tự.";
                txtUserName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
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

            lblMessage.Text = "";
            return true;
        }
    }
}
