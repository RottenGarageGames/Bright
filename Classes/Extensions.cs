using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class Extensions
    {
        public static void CopyFrom<T>(this T obj, T copyObject)
        {
            var properties = copyObject.GetType().GetProperties();

            foreach(var property in properties)
            {
                property.SetValue(obj, property);
            }
        }
    }
}
