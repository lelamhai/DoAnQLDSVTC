using Microsoft.Data.SqlClient;
using System.Data;
namespace DoAnQLDSVTC
{
    internal static class Program
    {
        public static SqlConnection Conn = new SqlConnection();
        public static string Connstr = "";
        //public static string Connstr_pub = "Data Source=ADMIN\\SERVERMAIN;Initial Catalog=QLDSV_TC;Integrated Security=True;User ID=sa;Password=123";
        public static string Connstr_pub = "Server=ADMIN\\SERVERMAIN;Database=QLDSV_TC;User Id=sa;Password=123;TrustServerCertificate=True;";


        public static string remoteLogin = "HTKN";
        public static string remotePass = "123";
        public static SqlDataReader myReader;
        public static string userName = "";
        public static string mHoTen = "";
        public static string mGroup = "";
        public static string ServerName = "";
        public static string DataBase = "QLDSV_HTC";
        public static string MLogin = "";
        public static string MPass = "";
        public static int MKhoa;
        // MASV AND PASS
        public static string MUser = "";
        public static string MUserPass = "";


        public static String MLoginDN = string.Empty;
        public static String MPassDN = string.Empty;


        public static BindingSource bds_dspm = new BindingSource(); // luu ds pm


        //public static frmMain frmMain;
        //public static frmDangNhap frmDangNhap;

        public static string[] quyen = new string[4] { "PGV", "KHOA", "SINH VIEN", "PKT" };

        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myReader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.Conn);

            //xác định kiểu lệnh cho sqlcmd là kiểu text.
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandTimeout = 600;
            if (Program.Conn.State == ConnectionState.Closed) Program.Conn.Open();

            try
            {
                myReader = sqlcmd.ExecuteReader();
                return myReader;
            }
            catch (SqlException ex)
            {
                Program.Conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        // CHUA SU DUNG
        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.Conn.State == ConnectionState.Closed) Program.Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, Conn);
            da.Fill(dt);
            Conn.Close();
            return dt;
        }
        public static int ExecSqlNonQuery(string strlenh)
        {
            SqlCommand Sqlcmd = new SqlCommand(strlenh, Conn);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600; // 10 phut
            if (Conn.State == ConnectionState.Closed) Conn.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery();
                Conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(strlenh + " // " + ex.State);
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Conn.Close();
                return ex.State;
            }
        }
        public static int KetNoi()
        {
            if (Program.Conn != null && Program.Conn.State == System.Data.ConnectionState.Open)
                Program.Conn.Close();
            try
            {
                Program.Connstr = "Data Source=" + Program.ServerName + ";Initial Catalog=" + Program.DataBase
                  + ";User ID=" + Program.MLogin + ";Password=" + Program.MPass;
                Program.Conn.ConnectionString = Program.Connstr;
                // Console.WriteLine(Program.Connstr);
                Program.Conn.Open();
                return 1;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối!\n Xem lại tài khoản, mật khẩu hoặc khoa đã chọn!!!\n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }



        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}