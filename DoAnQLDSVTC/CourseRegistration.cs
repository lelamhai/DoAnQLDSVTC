using System;
using System.Collections.Generic;
using System.Data;
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
            LoadDatasetDSLTC_NK();
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
            //dtpBeigin.Value = new DateTime(dtpBeigin.Value.Year, 1, 1);
            dtpBeigin.Value = new DateTime(2021, 1, 1);
        }
        private void SetupEnd()
        {
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "yyyy";
            dtpEnd.ShowUpDown = true;
            //dtpEnd.Value = new DateTime(dtpBeigin.Value.Year + 1, 1, 1);
            dtpEnd.Value = new DateTime(2022, 1, 1);
        }


        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            GetInfoStudent();
            LoadDatasetDSSV_DKLTC();
        }

        private void btnFilter_Click(object sender, System.EventArgs e)
        {
            LoadDatasetDSLTC_NK();
            LoadDatasetDSSV_DKLTC();
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

        void GetInfoStudent()
        {
            if (txtMSSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã số sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string cmd = "EXEC SP_LAY_HOTENSV '" + txtMSSV.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(cmd);
                Program.myReader.Read();
                lblHoTen.Text = Program.myReader.GetString(0);
                lblMaLop.Text = Program.myReader.GetString(1);
                lblTenLop.Text = Program.myReader.GetString(2);
                lblMaKhoa.Text = Program.myReader.GetString(3);
                string title = "Danh Sách Đăng Ký Học Phần Của " + lblHoTen.Text;
                lblTitle.Text = title;
                txtiMaSV.Text = txtMSSV.Text.Trim();
                lblMaSV.Text = txtMSSV.Text.Trim();
                Program.myReader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi mã sinh viên không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
        }


        void LoadDatasetDSLTC_NK()
        {
            this.DS.EnforceConstraints = false;
            this.SP_DSLTC_NIENKHOAHOCKYTableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.SP_DSLTC_NIENKHOAHOCKYTableAdapter.Fill(this.DS.SP_DSLTC_NIENKHOAHOCKY, txtNienKhoa.Text.Trim(), (int)nudHocKy.Value);
        }

        void LoadDatasetDSSV_DKLTC()
        {
            this.DS.EnforceConstraints = false;
            this.SP_DSLTC_DSSVDKLTCTableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.SP_DSLTC_DSSVDKLTCTableAdapter.Fill(this.DS.SP_DSLTC_DSSVDKLTC, txtNienKhoa.Text.Trim(), (int)nudHocKy.Value, txtMSSV.Text.Trim());
        }

        private void btnCourseRegistraction_Click(object sender, EventArgs e)
        {
            if(txtiMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng tìm kiếm sinh viên trước khi đăng ký học phần!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            string cmd = "EXEC SP_DANGKY_LTC '" + txtiMaSV.Text.Trim() + "'," + txtiMaLTC.Text.Trim();
            Program.ExecSqlNonQuery(cmd);
            LoadDatasetDSLTC_NK();
            LoadDatasetDSSV_DKLTC();
        }

        private void btnCannelRegister_Click(object sender, EventArgs e)
        {
            if (dgvSVDK.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvSVDK.SelectedRows)
                {
                    string maLTC = row.Cells["MALTC"].Value?.ToString();
                    string cmd = "EXEC SP_HUYDANGKY_LTC '" + txtiMaSV.Text.Trim() + "'," + maLTC.Trim();
                    Program.ExecSqlNonQuery(cmd);
                    LoadDatasetDSLTC_NK();
                    LoadDatasetDSSV_DKLTC();
                }
            }
        }
    }
}
