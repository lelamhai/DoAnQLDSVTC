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

        private void CourseRegistration_Load(object sender, EventArgs e)
        {
            SetupBeigin();
            SetupEnd();
            LoadNienKhoa();
            LoadDatasetDSNIENKHOAHOCKY_DKLT();
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
            GetInfoStudent();
        }

        private void btnFilter_Click(object sender, System.EventArgs e)
        {
            LoadDatasetDSNIENKHOAHOCKY_DKLT();
            LoadDatasetDSSV_DKLTC();
        }

        private void dtpBeigin_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.Value = new DateTime(dtpBeigin.Value.Year + 1, 1, 1);
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            dtpBeigin.Value = new DateTime(dtpEnd.Value.Year - 1, 1, 1);
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        void GetInfoStudent()
        {
            if (txtMSSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã số sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanForm();
                btnCannelRegister.Visible = false;
                return;
            }

            try
            {
                string cmd = "EXEC SP_LAYHOTENSV_DKLTC '" + txtMSSV.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(cmd);

                if (Program.myReader == null)
                {
                    CleanForm();
                    btnCannelRegister.Visible = false;
                    return;
                }

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
                btnCannelRegister.Visible = true;
                LoadDatasetDSSV_DKLTC();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        void LoadDatasetDSSV_DKLTC()
        {
            try
            {
                if (lblMaSV.Text == "") return;

                this.DS.EnforceConstraints = false;
                this.SP_LAYDSSV_DKLTCTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_LAYDSSV_DKLTCTableAdapter.Fill(this.DS.SP_LAYDSSV_DKLTC, txtNienKhoa.Text.Trim(), (int)nudHocKy.Value, lblMaSV.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void LoadDatasetDSNIENKHOAHOCKY_DKLT()
        {
            try
            {
                this.DS.EnforceConstraints = false;
                this.SP_LAYDSNIENKHOAHOCKY_DKLTCTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_LAYDSNIENKHOAHOCKY_DKLTCTableAdapter.Fill(this.DS.SP_LAYDSNIENKHOAHOCKY_DKLTC, txtNienKhoa.Text.Trim(), (int)nudHocKy.Value);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCourseRegistraction_Click(object sender, EventArgs e)
        {
            if(txtiMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng tìm kiếm sinh viên trước khi đăng ký học phần!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                string cmd = "EXEC SP_DANGKY_DKLTC N'" + txtiMaSV.Text.Trim() + "'," + txtiMaLTC.Text.Trim();
                int result = Program.ExecSqlNonQuery(cmd);
                if(result == 0)
                {
                    LoadDatasetDSNIENKHOAHOCKY_DKLT();
                    LoadDatasetDSSV_DKLTC();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void btnCannelRegister_Click(object sender, EventArgs e)
        {
            DialogResult resultMessage = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy đăng ký lớp tín chỉ này không?",
                "Xác nhận hủy đăng ký",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultMessage == DialogResult.No)
            {
                return;
            }

            if (dgvSVDK.CurrentRow != null)
            {
                try
                {
                    string maLTC = dgvSVDK.CurrentRow.Cells["MALTC"].Value?.ToString();
                    string cmd = "EXEC SP_HUYDANGKY_DKLTC N'" + txtiMaSV.Text.Trim() + "'," + maLTC.Trim();
                    int result = Program.ExecSqlNonQuery(cmd);
                    if (result == 0)
                    {
                        LoadDatasetDSNIENKHOAHOCKY_DKLT();
                        LoadDatasetDSSV_DKLTC();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        void CleanForm()
        {
            lblHoTen.Text = "";
            lblMaLop.Text = "";
            lblTenLop.Text = "";
            lblMaKhoa.Text = "";
            string title = "Chưa Có Dữ Liệu";
            lblTitle.Text = title;
            txtiMaSV.Text = "";
            lblMaSV.Text = "";
            btnCannelRegister.Visible = false;

            DS.SP_LAYDSSV_DKLTC.Clear();
        }
    }
}
