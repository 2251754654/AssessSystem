using System;
using System.Reflection;

namespace ProjectUtilsns
{
    public class UtilClass
    {
        /// <summary>
        /// 转换类的类型
        /// </summary>
        /// <typeparam name="T">将要转换的类型</typeparam>
        /// <typeparam name="E">转换后的类型</typeparam>
        /// <param name="tIn">将要转换的类型的实例</param>
        /// <param name="eOut">转换后的类型的实例</param>
        /// <returns>有没有匹配项，true为有匹配项，false为没有</returns>
        public static bool Convert<T, E>(T tIn, E eOut) where T : class where E : class
        {
            if (tIn == null)
            {
                return false;
            }
            if (eOut == null)
            {
                return false;
            }
            var inProperties = typeof(T).GetProperties();
            var outProperties = typeof(E).GetProperties();
            bool tag = false;
            foreach (var inItem in inProperties)
            {
                foreach (var outItem in outProperties)
                {
                    if (inItem.Name.ToLower() == outItem.Name.ToLower())
                    {
                        outItem.SetValue(eOut, inItem.GetValue(tIn));
                        tag = true;
                    }
                }
            }
            if (tag == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 反射获取实例
        /// </summary>
        /// <typeparam name="T">要获取实例的类型</typeparam>
        /// <param name="projectName">项目名称</param>
        /// <param name="classFullName">类的全名 namespace.classname</param>
        /// <returns>T类型的实例</returns>
        public static T GetInstance<T>(string projectName, string classFullName) where T : class
        {
            if (projectName == null || projectName.Trim(' ') == "")
            {
                return null;
            }
            if (classFullName == null || classFullName.Trim(' ') == "")
            {
                return null;
            }
            Assembly assembly = Assembly.Load(projectName);
            Type type = assembly.GetType(classFullName); //参数必须是类的全名
            var obj = Activator.CreateInstance(type, null);
            return (T)obj;
        }
        /// <summary>
        /// 反射获取实例
        /// </summary>
        /// <typeparam name="T">要获取实例的类型</typeparam>
        /// <returns>T类型的实例</returns>
        public static T GetInstance<T>() where T : class
        {
            var type = typeof(T);
            var obj = Activator.CreateInstance(type, null);
            return (T)obj;
        }
    }
}
