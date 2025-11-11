using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class ucLop : UserControl
    {
        public ucLop()
        {
            InitializeComponent();
        }

        private void UCLOP_Load(object sender, EventArgs e)
        {
            if (Program.KetNoi() == 0) return;
            string strQuery = "SELECT * FROM V_FILL_LOP";
            SqlConnection Conn_pub = new SqlConnection(Program.Connstr);
            DataTable dt = new DataTable();
            if (Conn_pub.State == ConnectionState.Closed)
                Conn_pub.Open();
            SqlDataAdapter da = new SqlDataAdapter(strQuery, Conn_pub);
            da.Fill(dt);
            Conn_pub.Close();
            dgvLop.DataSource = dt;
            dgvLop.Columns["rowguid"].Visible = false;


            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.MKhoa;

            btnAdd.BackColor = ColorTranslator.FromHtml("#20bf55");
        }
    }
}
