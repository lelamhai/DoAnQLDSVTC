using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DoAnQLDSVTC.Models
{
    public class AccountInfoResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public AccountInfoData Data { get; set; }
    }

    public class AccountInfoData
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("ho")]
        public string Ho { get; set; }

        [JsonPropertyName("ten")]
        public string Ten { get; set; }

        [JsonPropertyName("trangthai")]
        public int TrangThai { get; set; }
    }
}
