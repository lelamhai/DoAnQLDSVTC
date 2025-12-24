using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class Admin : Form
    {
        public List<Button> listButton = new List<Button>();
        private Form currentForm;
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            LoadInfoAccount();
            LoadFormRole();
            LoadAciveMenu();
        }

        void LoadAciveMenu()
        {
            string quyen = Program.mGroup;
            if (quyen == Program.quyen[2]) // SV
            {
                btnLop.Enabled = false;
                btnStudent.Enabled = false;
                btnSubject.Enabled = false;
                btnOpenCourse.Enabled = false;
                btnInputPoint.Enabled = false;
                btnCourseRegistration.Enabled = true;
                btnPayCourse.Enabled = false;

                btnCreateAccount.Enabled = false;
                return;
            }

            if (quyen == Program.quyen[3]) // PKT
            {
                btnLop.Enabled = false;
                btnStudent.Enabled = false;
                btnSubject.Enabled = false;
                btnOpenCourse.Enabled = false;
                btnInputPoint.Enabled = false;
                btnCourseRegistration.Enabled = false;
                btnPayCourse.Enabled = true;
                return;
            }

            btnLop.Enabled = true;
            btnStudent.Enabled = true;
            btnSubject.Enabled = true;
            btnOpenCourse.Enabled = true;
            btnInputPoint.Enabled = true;
            btnCourseRegistration.Enabled = false;
            btnPayCourse.Enabled = false;
        }

        void LoadFormRole()
        {
            string quyen = Program.mGroup;

            if (quyen == Program.quyen[2]) // SV
            {
                LoadForm(new CourseRegistration());
                return;
            }

            if (quyen == Program.quyen[3]) // PKT
            {
                LoadForm(new PayCourse());
                return;
            }

            LoadForm(new NewClassroom()); // PGV, KHOA
        }

        private void LoadInfoAccount()
        {
            lblInfoAccount.Text = "Mã nhân viên: " +Program.userName + " - Họ và tên: " + Program.mHoTen + " - Nhóm: " + Program.mGroup;
            lblInfoAccount.BringToFront();
        }


        private void LoadForm(Form form)
        {
            if (currentForm != null && currentForm.GetType() == form.GetType())
            {
                return;
            }

            if (currentForm != null)
            {
                pMain.Controls.Remove(currentForm);
                currentForm.Dispose();
                currentForm = null;
                lblInfoAccount.Text = "";
                lblPageCurrent.Text = "";
            }

            currentForm = form;
            currentForm.TopLevel = false;
            currentForm.Dock = DockStyle.Fill;
            this.pMain.Controls.Add(currentForm);
            currentForm.Show();
            currentForm.BringToFront();
            lblPageCurrent.Text = currentForm.Text;
            LoadInfoAccount();
        }

        public void CloseForm(Form form)
        {
            if (currentForm != null && currentForm.GetType() == form.GetType())
            {
                currentForm.Dispose();
                currentForm = null;
                lblInfoAccount.Text = "";
                lblPageCurrent.Text = "";
                pMain.Controls.Clear();
            }    
        }

        #region TAB1
        private void btnStudent_Click(object sender, EventArgs e)
        {
            LoadForm(new Student());
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            LoadForm(new NewClassroom());
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            LoadForm(new Subject());
        }

        private void btnOpenCourse_Click(object sender, EventArgs e)
        {
            LoadForm(new OpenCourse());
        }

        private void btnCourseRegistration_Click(object sender, EventArgs e)
        {
            LoadForm(new CourseRegistration());
        }

        private void btnPayCourse_Click(object sender, EventArgs e)
        {
            LoadForm(new PayCourse());
        }

        private void btnInputPoint_Click(object sender, EventArgs e)
        {
            LoadForm(new InputPoint());
        }
        #endregion


        #region TAB2
        private void btnReportDSLTC_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportLTC());
        }
        private void btnReportDSSV_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportDSSVDKLTC());
        }

        private void btnReportBDMH_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportLTC());
        }

        private void btnReportPD_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportLTC());
        }

        private void btnReportDHP_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportLTC());
        }

        private void btnReportBDTK_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportLTC());
        }
        #endregion


        #region TAB3
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            LoadForm(new CreateAccount());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        #endregion
    }
}