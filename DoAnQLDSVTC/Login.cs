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

            cmbKhoa.SelectedIndex = 2;
            cmbKhoa.SelectedIndex = 1;
            cmbKhoa.SelectedIndex = 0;

            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.UseVisualStyleBackColor = false;
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
            Program.MLogin = txtUserName.Text;
            Program.MPass = txtPassword.Text;
            if (Program.KetNoi() == 0) return;

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

            // Di chuyển tới form chính
            Admin admin = new Admin();
            admin.Show();       // mở Form2
            this.Hide();     // ẩn Form1
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.ServerName = cmbKhoa.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khong co chi nhanh nay" + ex.ToString());
            }
        }
    }
}
