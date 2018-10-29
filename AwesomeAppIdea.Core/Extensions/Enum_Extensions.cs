using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AwesomeAppIdea.Core.Extensions
{
    public static class Enum_Extensions<T> where T : struct
    {
        public static string GetDescription(T value)
        {
            FieldInfo field = typeof(T).GetField(value.ToString());
            return field.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().Select(x => x.Description).FirstOrDefault();
        }
    }
}