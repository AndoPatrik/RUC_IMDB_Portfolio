using System;
using System.Security.Cryptography;
using System.Text;

namespace IMDB.Domain.Utils
{
    public class Hashing
    {
        public static string HashToSHA256(string text)
        {  
            using (var sha256 = SHA256.Create())
            {               
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text)); 
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
