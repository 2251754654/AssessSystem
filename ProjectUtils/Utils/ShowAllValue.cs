using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUtils
{
    public class ShowAllValue
    {
        public static string ShowValue<T>(T tIn) where T : class
        {
            if (tIn == null)
            {
                return null;
            }

            StringBuilder outStr = new StringBuilder();
            outStr.Append(typeof(T).Name+"\n{");

            var inProperties = typeof(T).GetProperties();
            foreach (var inItem in inProperties)
            {
                outStr.Append(inItem.Name+":"+inItem.GetValue(tIn)+", ");
            }
            outStr.Remove(outStr.Length-1,1);
            outStr.Append("}\n");
            return outStr.ToString();
        }

        public static string ShowValue<T>(List<T> tIn) where T : class
        {
            if (tIn == null)
            {
                return null;
            }
            StringBuilder outStr = new StringBuilder();
            outStr.Append(typeof(T).Name + "\n{");
            foreach (var item in tIn)
            {
                var inProperties = item.GetType().GetProperties();
                outStr.Append("[");
                foreach (var inItem in inProperties)
                {
                    
                    outStr.Append(inItem.Name + ":" + inItem.GetValue(item) + ", ");
                }
                outStr.Remove(outStr.Length - 1, 1);
                outStr.Append("]\n"); 
            }
            outStr.Append("}\n");
            return outStr.ToString();
        }
    }
}
