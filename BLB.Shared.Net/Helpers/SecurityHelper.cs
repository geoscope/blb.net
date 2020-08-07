using System.Security.Cryptography;
using System.Text;
using BLB.Shared.Net.Interfaces;

namespace BLB.Shared.Net.Helpers
{
    public class SecurityHelper:ISecurityHelper
    {
        public string HashPassword(string password, string systemSalt, string userSalt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes($"{systemSalt}~{password}~{userSalt}"));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
