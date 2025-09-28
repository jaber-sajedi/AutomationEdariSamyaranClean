using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.Common
{
    public class Hash_Class
    {
        // تولید MD5
        public static string GetMd5Hash(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            using (MD5 md5Hasher = MD5.Create())
            {
                byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(input.Trim()));

                StringBuilder sBuilder = new StringBuilder();
                foreach (byte b in data)
                    sBuilder.Append(b.ToString("x2")); // همیشه حروف کوچک

                return sBuilder.ToString();
            }
        }

        // بررسی برابر بودن هش
        public static bool VerifyMd5Hash(string input, string hash)
        {
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(hash))
                return false;

            string hashOfInput = GetMd5Hash(input).Trim().ToLower();
            hash = hash.Trim().ToLower();

            return hashOfInput.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
