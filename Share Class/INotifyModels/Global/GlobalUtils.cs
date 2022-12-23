using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Share_Class.Global
{
    public static class GlobalUtils
    {
        public static int CalculateHash(string s)
        {
            MD5 md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(s));
            return BitConverter.ToInt32(hashed, 0);
        }
    }
}
