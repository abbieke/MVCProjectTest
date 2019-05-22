using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MvcProjectTest.Services
{
    public class HashService
    {
        public static string SHA256Hash(string rawString)
        {
            StringBuilder sb;

            using (SHA256 sha256 = SHA256.Create())
            {
                //將字串轉為Byte[]
                byte[] byteArray = Encoding.UTF8.GetBytes(rawString);

                byte[] encryption = sha256.ComputeHash(byteArray);


                sb = new StringBuilder();

                for (int i = 0; i < encryption.Length; i++)
                {
                    sb.Append(encryption[i].ToString("x2"));
                }
            }

            return sb.ToString(); ;
        }
    }
}