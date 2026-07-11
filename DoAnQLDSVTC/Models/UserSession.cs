using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQLDSVTC.Models
{
    public static class UserSession
    {
        public static string Username { get; set; }

        public static string AccessToken { get; set; }

        public static string RefreshToken { get; set; }

        public static string Role { get; set; }

        public static DateTime ExpiredToken { get; set; }

        public static string FullName { get; set; }

        public static bool IsLoggedIn
        {
            get
            {
                return !string.IsNullOrWhiteSpace(AccessToken);
            }
        }
        public static string[] role = new string[3] { "SV", "GV", "NV" };
        public static void Clear()
        {
            Username = string.Empty;
            AccessToken = string.Empty;
            RefreshToken = string.Empty;
            Role = string.Empty;
            ExpiredToken = DateTime.MinValue;
            FullName = string.Empty;
        }
    }
}
