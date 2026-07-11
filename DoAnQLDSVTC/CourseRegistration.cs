using DoAnQLDSVTC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DoAnQLDSVTC
{
    public partial class CourseRegistration : Form
    {
        private const string API_GET_STUDENT_LTC = "https://localhost:7141/api/v1/private/StudentLTC/get-ltc";
        private const string API_GET_LTC = "https://localhost:7141/api/LTC/get-ltc";

        public CourseRegistration()
        {
            InitializeComponent();
        }

        private void CourseRegistration_Load(object sender, EventArgs e)
        {
            GetInfoStudent();
            LoadDatasetDSSV_DKLTC();
            LoadDatasetDSNIENKHOAHOCKY_DKLT();
        }

        void GetInfoStudent()
        {
            lblMaSV.Text = UserSession.Username;
            lblHoTen.Text = UserSession.FullName;
        }

        private async Task LoadDatasetDSSV_DKLTC()
        {
            string maSinhVien = UserSession.Username;
            int page = -1;

            string url = API_GET_STUDENT_LTC + $"?maSv={Uri.EscapeDataString(maSinhVien)}&page={page}";

            try
            {
                dgvSVDK.Enabled = false;
                Cursor = Cursors.WaitCursor;

                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    
                    HttpResponseMessage response = await client.GetAsync(url);

                    string json = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(
                            $"Gọi API không thành công.\n" +
                            $"Mã lỗi: {(int)response.StatusCode}\n\n{json}",
                            "Lỗi API",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        dbsDSSV_DKLTC.DataSource = null;
                        return;
                    }

                    JObject jsonObject = JObject.Parse(json);

                    JArray items = jsonObject["data"]?["items"] as JArray;

                    if (items == null)
                    {
                        MessageBox.Show(
                            "API không trả về dữ liệu data.items.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        dbsDSSV_DKLTC.DataSource = null;
                        return;
                    }

                    DataTable dt =
                        JsonConvert.DeserializeObject<DataTable>(items.ToString())
                        ?? new DataTable();

                    // Cho phép DataGridView tự sinh cột từ DataTable
                    dgvSVDK.AutoGenerateColumns = true;

                    // Xóa các cột cũ nếu trước đó đã tạo cột bằng Designer
                    dgvSVDK.Columns.Clear();

                    // Gán dữ liệu vào BindingSource
                    dbsDSSV_DKLTC.DataSource = dt;

                    // DataGridView của bạn đã chọn DataSource là dbsDSSV_DKLTC
                    // Tuy nhiên vẫn có thể gán lại để chắc chắn
                    dgvSVDK.DataSource = dbsDSSV_DKLTC;

                    // Đổi tên tiêu đề cột sang tiếng Việt
                    SetHeaderDgvSVDK();

                    // Định dạng DataGridView
                    dgvSVDK.AllowUserToAddRows = false;
                    dgvSVDK.AllowUserToDeleteRows = false;
                    dgvSVDK.ReadOnly = true;
                    dgvSVDK.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;
                    dgvSVDK.MultiSelect = false;
                    dgvSVDK.RowHeadersVisible = false;

                    dgvSVDK.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.DisplayedCells;

                    dgvSVDK.AutoSizeRowsMode =
                        DataGridViewAutoSizeRowsMode.AllCells;

                    dgvSVDK.DefaultCellStyle.WrapMode =
                        DataGridViewTriState.False;

                    dgvSVDK.ColumnHeadersDefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;

                    dgvSVDK.Refresh();
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(
                    $"Không kết nối được tới API.\n\n{ex.Message}",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show(
                    "API phản hồi quá thời gian cho phép.",
                    "Timeout",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (System.Text.Json.JsonException ex)
            {
                MessageBox.Show(
                    $"Dữ liệu JSON không hợp lệ.\n\n{ex.Message}",
                    "Lỗi JSON",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Có lỗi xảy ra.\n\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dgvSVDK.Enabled = true;
                Cursor = Cursors.Default;
            }
        }


        async void LoadDatasetDSNIENKHOAHOCKY_DKLT()
        {
            int page = -1;

            string url = API_GET_LTC + $"?page={page}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));



                    HttpResponseMessage response = await client.GetAsync(url);

                    string json = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(
                            $"Gọi API không thành công.\n" +
                            $"Mã lỗi: {(int)response.StatusCode}\n\n{json}",
                            "Lỗi API",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        dbsDSSV_DKLTC.DataSource = null;
                        return;
                    }

                    JObject jsonObject = JObject.Parse(json);

                    JArray items = jsonObject["data"]?["items"] as JArray;

                    DataTable dt =
               JsonConvert.DeserializeObject<DataTable>(items.ToString())
               ?? new DataTable();

                    // Cho phép DataGridView tự sinh cột từ DataTable
                    dgvDSLTC.AutoGenerateColumns = true;

                    // Xóa các cột cũ nếu trước đó đã tạo cột bằng Designer
                    dgvDSLTC.Columns.Clear();

                    // Gán dữ liệu vào BindingSource
                    dbsDSNIENKHOAHOCKY_DKLTC.DataSource = dt;

                    // DataGridView của bạn đã chọn DataSource là dbsDSSV_DKLTC
                    // Tuy nhiên vẫn có thể gán lại để chắc chắn
                    dgvDSLTC.DataSource = dbsDSNIENKHOAHOCKY_DKLTC;

                    // Đổi tên tiêu đề cột sang tiếng Việt
                    SetHeaderDSLTC();

                    // Định dạng DataGridView
                    dgvDSLTC.AllowUserToAddRows = false;
                    dgvDSLTC.AllowUserToDeleteRows = false;
                    dgvDSLTC.ReadOnly = true;
                    dgvDSLTC.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;
                    dgvDSLTC.MultiSelect = false;
                    dgvDSLTC.RowHeadersVisible = false;

                    dgvDSLTC.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.DisplayedCells;

                    dgvDSLTC.AutoSizeRowsMode =
                        DataGridViewAutoSizeRowsMode.AllCells;

                    dgvDSLTC.DefaultCellStyle.WrapMode =
                        DataGridViewTriState.False;

                    dgvDSLTC.ColumnHeadersDefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;

                    dgvDSLTC.Refresh();
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(
                    $"Không kết nối được đến API:\n{ex.Message}",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show(
                    "API phản hồi quá thời gian cho phép.",
                    "Timeout",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (System.Text.Json.JsonException ex)
            {
                MessageBox.Show(
                    $"Dữ liệu JSON không hợp lệ:\n{ex.Message}",
                    "Lỗi JSON",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã xảy ra lỗi:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
            //lblMaLop.Text = "";
            //lblTenLop.Text = "";
            //lblMaKhoa.Text = "";
            string title = "Chưa Có Dữ Liệu";
            lblTitle.Text = title;
            txtiMaSV.Text = "";
            lblMaSV.Text = "";
            btnCannelRegister.Visible = false;

            DS.SP_LAYDSSV_DKLTC.Clear();
        }

        private void SetHeaderDSLTC()
        {
            Dictionary<string, string> columnHeaders =
                new Dictionary<string, string>
                {
            { "maLtc", "Mã lớp tín chỉ" },
            //{ "maLopHp", "Mã lớp học phần" },
            { "maMh", "Mã môn học" },
            { "tenMh", "Tên môn học" },
            { "soTinChi", "Số tín chỉ" },
            { "soTietLt", "Số tiết lý thuyết" },
            { "soTietTh", "Số tiết thực hành" },
            { "maGv", "Mã giảng viên" },
            { "tenGiangVien", "Tên giảng viên" },
            { "hocKy", "Học kỳ" },
            { "nienKhoa", "Niên khóa" },
            { "siSoHienTai", "Sĩ số hiện tại" },
            { "siSoToiDa", "Sĩ số tối đa" },
            { "siSo", "Sĩ số" },
            { "dayThuTrongTuan", "Ngày học trong tuần" },
            { "lichHoc", "Lịch học" },
            { "thoiGianBatDau", "Ngày bắt đầu" },
            { "thoiGianKetThuc", "Ngày kết thúc" },
            { "thoiGianHoc", "Thời gian học" },
            { "huyLop", "Hủy lớp" }
                };

            foreach (DataGridViewColumn column in dgvDSLTC.Columns)
            {
                if (columnHeaders.TryGetValue(
                    column.DataPropertyName,
                    out string headerText))
                {
                    column.HeaderText = headerText;
                }
                else if (columnHeaders.TryGetValue(
                    column.Name,
                    out headerText))
                {
                    column.HeaderText = headerText;
                }
            }

            if (dgvDSLTC.Columns["maLopHp"] != null)
            {
                dgvDSLTC.Columns["maLopHp"].Visible = false;
            }
        }

        private void SetHeaderDgvSVDK()
        {
            Dictionary<string, string> columnHeaders =
                new Dictionary<string, string>
                {
            { "maLtc", "Mã lớp tín chỉ" },
            //{ "maLopHp", "Mã lớp học phần" },
            { "maMh", "Mã môn học" },
            { "tenMh", "Tên môn học" },
            { "soTinChi", "Số tín chỉ" },
            { "soTietLt", "Số tiết lý thuyết" },
            { "soTietTh", "Số tiết thực hành" },
            { "maGv", "Mã giảng viên" },
            { "tenGiangVien", "Tên giảng viên" },
            { "hocKy", "Học kỳ" },
            { "nienKhoa", "Niên khóa" },
            { "siSoHienTai", "Sĩ số hiện tại" },
            { "siSoToiDa", "Sĩ số tối đa" },
            { "siSo", "Sĩ số" },
            { "dayThuTrongTuan", "Ngày học trong tuần" },
            { "lichHoc", "Lịch học" },
            { "thoiGianBatDau", "Ngày bắt đầu" },
            { "thoiGianKetThuc", "Ngày kết thúc" },
            { "thoiGianHoc", "Thời gian học" },
            { "huyLop", "Hủy lớp" }
                };

            foreach (DataGridViewColumn column in dgvSVDK.Columns)
            {
                if (columnHeaders.TryGetValue(
                    column.DataPropertyName,
                    out string headerText))
                {
                    column.HeaderText = headerText;
                }
                else if (columnHeaders.TryGetValue(
                    column.Name,
                    out headerText))
                {
                    column.HeaderText = headerText;
                }
            }

            if (dgvSVDK.Columns["maLopHp"] != null)
            {
                dgvSVDK.Columns["maLopHp"].Visible = false;
            }
        }
    }
}
