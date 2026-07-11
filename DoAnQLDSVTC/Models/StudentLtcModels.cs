using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DoAnQLDSVTC.Models
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public T Data { get; set; }
    }

    public class StudentLtcData
    {
        [JsonPropertyName("items")]
        public List<StudentLtcItem> Items { get; set; } = new List<StudentLtcItem>();

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = new Pagination();
    }

    public class StudentLtcItem
    {
        [JsonPropertyName("maLtc")]
        public int MaLtc { get; set; }

        [JsonPropertyName("maLopHp")]
        public string MaLopHp { get; set; } = string.Empty;

        [JsonPropertyName("maMh")]
        public string MaMh { get; set; } = string.Empty;

        [JsonPropertyName("tenMh")]
        public string TenMh { get; set; } = string.Empty;

        [JsonPropertyName("soTinChi")]
        public int SoTinChi { get; set; }

        [JsonPropertyName("soTietLt")]
        public int SoTietLt { get; set; }

        [JsonPropertyName("soTietTh")]
        public int SoTietTh { get; set; }

        [JsonPropertyName("maGv")]
        public string MaGv { get; set; } = string.Empty;

        [JsonPropertyName("tenGiangVien")]
        public string TenGiangVien { get; set; } = string.Empty;

        [JsonPropertyName("hocKy")]
        public int HocKy { get; set; }

        [JsonPropertyName("nienKhoa")]
        public string NienKhoa { get; set; } = string.Empty;

        [JsonPropertyName("siSoHienTai")]
        public int SiSoHienTai { get; set; }

        [JsonPropertyName("siSoToiDa")]
        public int SiSoToiDa { get; set; }

        [JsonPropertyName("siSo")]
        public string SiSo { get; set; } = string.Empty;

        [JsonPropertyName("dayThuTrongTuan")]
        public string DayThuTrongTuan { get; set; } = string.Empty;

        [JsonPropertyName("lichHoc")]
        public string LichHoc { get; set; } = string.Empty;

        [JsonPropertyName("thoiGianBatDau")]
        public DateTime ThoiGianBatDau { get; set; }

        [JsonPropertyName("thoiGianKetThuc")]
        public DateTime ThoiGianKetThuc { get; set; }

        [JsonPropertyName("thoiGianHoc")]
        public string ThoiGianHoc { get; set; } = string.Empty;

        [JsonPropertyName("huyLop")]
        public bool HuyLop { get; set; }
    }

    public class Pagination
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("hasNext")]
        public bool HasNext { get; set; }

        [JsonPropertyName("hasPrevious")]
        public bool HasPrevious { get; set; }
    }
}
