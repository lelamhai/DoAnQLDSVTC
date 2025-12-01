using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class CourseRegistration : Form
    {
        public CourseRegistration()
        {
            InitializeComponent();
        }

        private void CourseRegistration_Load(object sender, System.EventArgs e)
        {
            SetupBeigin();
            SetupEnd();
            LoadNienKhoa();
        }

        private void LoadNienKhoa()
        {
            int year = new DateTime(dtpBeigin.Value.Year, 1, 1).Year;
            txtNienKhoa.Text = year.ToString() + "-" + (year + 1);
        }

        private void SetupBeigin()
        {
            dtpBeigin.Format = DateTimePickerFormat.Custom;
            dtpBeigin.CustomFormat = "yyyy";
            dtpBeigin.ShowUpDown = true;
            dtpBeigin.Value = new DateTime(dtpBeigin.Value.Year, 1, 1);
        }
        private void SetupEnd()
        {
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "yyyy";
            dtpEnd.ShowUpDown = true;
            dtpEnd.Value = new DateTime(dtpBeigin.Value.Year + 1, 1, 1);
        }


        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            if(txtMSSV.Text.Trim() == "")
            {
                lblMessage.Text = "Vui lòng nhập mã sinh viên!";
                return;
            }
            string cmd = "EXEC SP_LAY_HOTENSV '" + txtMSSV.Text.Trim() + "'";
            Program.myReader = Program.ExecSqlDataReader(cmd);
            Program.myReader.Read();
            txtMaSV.Text = txtMSSV.Text.Trim();
            txtHoTen.Text = Program.myReader.GetString(0);
            txtTenLop.Text = Program.myReader.GetString(1);
            txtMaLop.Text = Program.myReader.GetString(2);
            Program.myReader.Close();

            string title = "Danh Sách Đăng Ký Học Phần Của " + txtHoTen.Text;
            lblTitle.Text = title;

        }

        private void btnFilter_Click(object sender, System.EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, System.EventArgs e)
        {

        }

        private void dtpBeigin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBeigin.Value.Year >= dtpEnd.Value.Year)
            {
                dtpEnd.Value = new DateTime(dtpBeigin.Value.Year + 1, 1, 1);
            }
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnd.Value.Year <= dtpBeigin.Value.Year)
            {
                dtpBeigin.Value = new DateTime(dtpEnd.Value.Year - 1, 1, 1);
            }
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }
    }
}
