using DoAnQLDSVTC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class Admin : Form
    {
        private const string API_USERINFO = "https://localhost:7141/api/v1/private/Account/info-account";
        public List<Button> listButton = new List<Button>();
        private Form currentForm;
        public Admin()
        {
            InitializeComponent();
            LoadUserInfoAsync();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            //LoadAciveMenu();
        }

        private async void LoadUserInfoAsync()
        {
            if (string.IsNullOrWhiteSpace(UserSession.Username))
            {
                MessageBox.Show(
                    "Không tìm thấy username. Vui lòng đăng nhập lại.",
                    "Thiếu thông tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(UserSession.AccessToken))
            {
                MessageBox.Show(
                    "Không tìm thấy Access Token. Vui lòng đăng nhập lại.",
                    "Phiên đăng nhập không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                string apiUrl =
                    API_USERINFO +
                    "?username=" +
                    Uri.EscapeDataString(UserSession.Username);

                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    // Chỉ sử dụng cho localhost
                    handler.ServerCertificateCustomValidationCallback =
                        HttpClientHandler
                            .DangerousAcceptAnyServerCertificateValidator;

                    using (HttpClient httpClient = new HttpClient(handler))
                    {
                        httpClient.Timeout = TimeSpan.FromSeconds(30);

                        httpClient.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue(
                                "Bearer",
                                UserSession.AccessToken);

                        httpClient.DefaultRequestHeaders.Accept.Clear();

                        httpClient.DefaultRequestHeaders.Accept.Add(
                            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(
                                "application/json"));

                        using (HttpResponseMessage response = await httpClient.GetAsync(apiUrl))
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();

                            if (response.IsSuccessStatusCode)
                            {
                                JsonSerializerOptions options =
                                    new JsonSerializerOptions
                                    {
                                        PropertyNameCaseInsensitive = true
                                    };

                                AccountInfoResponse accountResponse =
                                    JsonSerializer.Deserialize<AccountInfoResponse>(
                                        responseBody,
                                        options);

                                if (accountResponse == null ||
                                    accountResponse.Data == null)
                                {
                                    MessageBox.Show(
                                        "API không trả về thông tin tài khoản.",
                                        "Lỗi dữ liệu",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                    return;
                                }
                                UserSession.FullName = accountResponse.Data.Ho + " " + accountResponse.Data.Ten;
                                LoadInfoAccount();
                                LoadFormRole();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Gọi API thất bại.\n" +
                                    "HTTP: " +
                                    (int)response.StatusCode +
                                    "\n\nChi tiết:\n" +
                                    responseBody,
                                    "Lỗi API",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show(
                    "Kết nối API quá thời gian.",
                    "Timeout",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(
                    "Không thể kết nối API.\n\n" + ex.Message,
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (JsonException ex)
            {
                MessageBox.Show(
                    "Dữ liệu JSON không hợp lệ.\n\n" + ex.Message,
                    "Lỗi JSON",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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

                btnReportDSLTC.Enabled = false;
                btnReportDSSV.Enabled = false;
                btnReportBDMH.Enabled = false;
                btnReportBDTK.Enabled = false;
                btnReportDHP.Enabled = false;
                btnReportPD.Enabled = true;
                                

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


                btnReportDSLTC.Enabled = false;
                btnReportDSSV.Enabled = false;
                btnReportBDMH.Enabled = false;
                btnReportBDTK.Enabled = false;
                btnReportDHP.Enabled = true;
                btnReportPD.Enabled = false;

                return;
            }

            btnLop.Enabled = true;
            btnStudent.Enabled = true;
            btnSubject.Enabled = true;
            btnOpenCourse.Enabled = true;
            btnInputPoint.Enabled = true;
            btnCourseRegistration.Enabled = false;
            btnPayCourse.Enabled = false;

            btnReportPD.Enabled = false;
            btnReportDHP.Enabled = false;
        }

        void LoadFormRole()
        {
            string quyen = UserSession.Role;

            if (quyen == UserSession.role[0]) // SV
            {
                LoadForm(new CourseRegistration());
                return;
            }

            //if (quyen == Program.quyen[3]) // PKT
            //{
            //    LoadForm(new PayCourse());
            //    return;
            //}

            //LoadForm(new NewClassroom()); // PGV, KHOA
        }

        private void LoadInfoAccount()
        {
            lblInfoAccount.Text = "Username: " + UserSession.Username + " - Họ và tên: " + UserSession.FullName + " - Nhóm: " + UserSession.role;
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
            LoadForm(new ReportBDMN());
        }

        private void btnReportPD_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportPD());
        }

        private void btnReportDHP_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportDHP());
        }

        private void btnReportBDTK_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportTK());
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