using System;
using System.Text.RegularExpressions;

namespace Infrastructure
{
    public class Check
    {

        public static void IsNotZero(string name, int input)
        {
            if (input == 0)
            {
                throw new ArgumentException(string.Format("{0}不能为0", name));
            }
        }

        public static void IsNotNull(string name, object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException(string.Format("{0}不能为空", name));
            }
        }

        public static void IsNotNullOrEmpty(string name, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(string.Format("{0}不能为空", name));
            }
        }

        public static void IsNotNullOrWhiteSpace(string name, string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException(string.Format("{0}不能为空", name));
            }
        }
        /// <summary>
        /// 校验是否相等
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="errorMessageFormat"></param>
        public static void AreEqual(string id1, string id2, string errorMessageFormat)
        {
            if (id1 != id2)
            {
                throw new ArgumentException(string.Format(errorMessageFormat, id1, id2));
            }
        }

        public static void IsLengthSection(string name,string input,int min,int max)
        {
            int len =  input.Length;
            if (len < min && len > max)
            {
                throw new ArgumentException(string.Format("{0}不再要求的区间内！", name));
            }
        }

        public static void IsNotEmail(string name,string input)
        {
            var reg = new Regex(@"[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?", RegexOptions.IgnoreCase);
            if (reg.IsMatch(input))
            {
                throw new ArgumentException(string.Format("邮箱{0}不符合规范！", name));
            }
        }

        public static void IsNotPhoneNumber(string name, string input)
        {
            var reg = new Regex("[0-9]{11}");
            if (reg.IsMatch(input))
            {
                throw new ArgumentException(string.Format("电话{0}不符合规范！", name));
            }
        }

        public static void IsNotSpecialChar(string name, string input)
        {
            var reg = new Regex(@"\w*");
            if (reg.IsMatch(input))
            {
                throw new ArgumentException(string.Format("{0}含有特殊字符！", name));
            }
        }
    }
}
