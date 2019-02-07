using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Enums
{
    public static class Extensions
    {
        public static string GetDescription<T>(this T scope)
        {
            FieldInfo fieldInfo = scope.GetType().GetField(scope.ToString());
            if (fieldInfo == null) return null;
            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute.Description;
        }
    }
}
