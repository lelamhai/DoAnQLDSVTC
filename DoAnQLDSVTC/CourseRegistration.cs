using DoAnQLDSVTC.Models;
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
            GetInfoStudent();
        }

        void GetInfoStudent()
        {
            lblMaSV.Text = UserSession.Username;
            lblHoTen.Text = UserSession.FullName;
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
        }

        private void btnFilter_Click(object sender, System.EventArgs e)
        {
            LoadDatasetDSNIENKHOAHOCKY_DKLT();
            LoadDatasetDSSV_DKLTC();
        }

      
       

        void LoadDatasetDSSV_DKLTC()
        {
           
        }

        void LoadDatasetDSNIENKHOAHOCKY_DKLT()
        {
            
        }

        private void btnCourseRegistraction_Click(object sender, EventArgs e)
        {
           
            
        }

        private void btnCannelRegister_Click(object sender, EventArgs e)
        {
           
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
