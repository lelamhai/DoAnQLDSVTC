using DoAnQLDSVTC.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class Login : Form
    {
        private const string API_LOGIN = "https://localhost:7141/api/v1/public/User/login";
        private SqlConnection Conn_pub = new SqlConnection();

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            //if (KetNoi_CSDLGOC() == 0) return;
            //label1.Focus();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateLogin())
            {
                return;
            }

            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text;

            LoginRequest loginRequest = new LoginRequest
            {
                Username = username,
                Password = password
            };

            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Đang đăng nhập...";

                string jsonRequest =
                    JsonSerializer.Serialize(loginRequest);

                using (StringContent requestContent = new StringContent(
                    jsonRequest,
                    Encoding.UTF8,
                    "application/json"))
                {
                    using (HttpClientHandler handler =
                        new HttpClientHandler())
                    {
                        /*
                         * Chỉ sử dụng khi chạy localhost.
                         * Không bỏ kiểm tra chứng chỉ SSL khi triển khai thực tế.
                         */
                        handler.ServerCertificateCustomValidationCallback =
                            HttpClientHandler
                                .DangerousAcceptAnyServerCertificateValidator;

                        using (HttpClient httpClient =
                            new HttpClient(handler))
                        {
                            httpClient.Timeout =
                                TimeSpan.FromSeconds(30);

                            using (HttpResponseMessage response =
                                await httpClient.PostAsync(
                                    API_LOGIN,
                                    requestContent))
                            {
                                string responseBody =
                                    await response.Content
                                        .ReadAsStringAsync();

                                if (response.IsSuccessStatusCode)
                                {
                                    JsonSerializerOptions options =
                                        new JsonSerializerOptions
                                        {
                                            PropertyNameCaseInsensitive = true
                                        };

                                    LoginResponse loginResponse =
                                        JsonSerializer.Deserialize<LoginResponse>(
                                            responseBody,
                                            options);

                                    if (loginResponse == null)
                                    {
                                        MessageBox.Show(
                                            "API không trả về dữ liệu đăng nhập.",
                                            "Lỗi dữ liệu",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);

                                        return;
                                    }

                                    if (loginResponse.Data == null)
                                    {
                                        MessageBox.Show(
                                            "API không trả về token đăng nhập.",
                                            "Lỗi dữ liệu",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);

                                        return;
                                    }

                                    if (string.IsNullOrWhiteSpace(
                                        loginResponse.Data.AccessToken))
                                    {
                                        MessageBox.Show(
                                            "Access Token không hợp lệ.",
                                            "Lỗi đăng nhập",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);

                                        return;
                                    }

                                    // Lưu thông tin phiên đăng nhập
                                    UserSession.Username = username;

                                    UserSession.AccessToken =
                                        loginResponse.Data.AccessToken;

                                    UserSession.RefreshToken =
                                        loginResponse.Data.RefreshToken;

                                    UserSession.Role =
                                        loginResponse.Data.Role;

                                    UserSession.ExpiredToken =
                                        loginResponse.Data.ExpiredToken;

                                    //Program.MLoginDN = username;
                                    //Program.mGroup = loginResponse.Data.Role;

                                    Admin admin = new Admin();
                                    admin.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                }
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show(
                    "Kết nối đến API quá thời gian.",
                    "Timeout",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(
                    "Không thể kết nối đến API.\n\n" +
                    "Hãy kiểm tra:\n" +
                    "1. API đã chạy hay chưa.\n" +
                    "2. Cổng API có phải 7141 không.\n" +
                    "3. URL API có chính xác không.\n\n" +
                    "Chi tiết: " + ex.Message,
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (JsonException ex)
            {
                MessageBox.Show(
                    "Không thể đọc dữ liệu JSON từ API.\n\n" +
                    ex.Message,
                    "Lỗi JSON",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi khi đăng nhập.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
            }
        }


     
        private void btnShow_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            btnShow.Visible = false;
            btnHide.Visible = true;
            btnHide.BringToFront();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;

            btnHide.Visible = false;
            btnShow.Visible = true;
            btnShow.BringToFront();
        }

        private bool ValidateLogin()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                lblMessage.Text = "Vui lòng nhập Tài Khoản.";
                txtUserName.Focus();
                return false;
            }

            if (txtUserName.Text.Length < 6)
            {
                lblMessage.Text = "Tài Khoản phải từ 6 ký tự.";
                txtUserName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblMessage.Text = "Vui lòng nhập Mật Khẩu.";
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                lblMessage.Text = "Mật Khẩu phải từ 6 ký tự.";
                txtPassword.Focus();
                return false;
            }

            lblMessage.Text = "";
            return true;
        }
    }
}
