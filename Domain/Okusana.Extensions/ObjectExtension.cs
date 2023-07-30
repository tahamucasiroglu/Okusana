using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Extensions
{
    static public class ObjectExtension
    {
        static public Dictionary<string, string> GetPropertyDict(this object obj)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (PropertyInfo item in obj.GetType().GetProperties())
            {
                dict.Add(item.Name, item.PropertyType.ToString());
            }
            return dict;
        }

        static public bool IsNull(this object? obj)
        {
            return obj == null || obj == default;
        }

    }
}
