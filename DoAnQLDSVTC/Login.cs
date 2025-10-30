using Microsoft.Data.SqlClient;
using System.Data;

namespace DoAnQLDSVTC
{
    public partial class Login : Form
    {
        private static SqlConnection Conn_pub = new SqlConnection();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (KetNoi_CSDLGOC() == 0) return;
            LayDSPM("SELECT * FROM V_GET_SUBSCRIBES");

            cmbKhoa.SelectedIndex = 1;
            cmbKhoa.SelectedIndex = 0;
        }

        private int KetNoi_CSDLGOC()
        {
            if (Conn_pub != null && Conn_pub.State == System.Data.ConnectionState.Open)
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



            //Lib.BDataToCmb(cmbKhoa, Program.bds_dspm.DataSource);
            //Program.MKhoa = 0;
            //cmbKhoa.SelectedIndex = 0;
            //Program.ServerName = "QUYNH\\SERVER1";//cmbKhoa.SelectedValue.ToString();

        }
    }
}
