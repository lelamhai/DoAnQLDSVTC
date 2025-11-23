using System;
using System.Data;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            LoadDatasetApdapterTeacher();
            LoadDatasetApdapterRole();
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
            string cmd = string.Format("EXEC SP_TAO_LOGIN N'{0}',N'{1}',N'{2}',N'{3}'", txtUserName.Text.Trim(), txtPassword.Text.Trim(), cmbTeacher.SelectedValue.ToString().Trim(), cmbRole.SelectedValue.ToString().Trim());
            int kt = Program.ExecSqlNonQuery(cmd);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Admin parent = this.TopLevelControl as Admin;
            Form form = btn.FindForm();
            parent.DeleteButtonInTabBar(form);
        }
    }
}
