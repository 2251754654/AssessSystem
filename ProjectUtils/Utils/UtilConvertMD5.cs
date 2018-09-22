using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUtils
{
   public class UtilConvertMD5
    {
        public static string MD5(string md5String)
        {
            if (md5String == null || md5String.Trim(' ') == "")
            {
                return null;
            }
            MD5 mD5 = new MD5CryptoServiceProvider();
            md5String = BitConverter.ToString((mD5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(md5String))));
            return md5String;
        }
    }
}
