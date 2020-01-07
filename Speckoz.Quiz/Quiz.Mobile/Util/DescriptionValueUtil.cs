using Quiz.Dependencies.Enums;

using System.ComponentModel;
using System.Linq;

namespace Quiz.Mobile.Util
{
    internal class DescriptionValueUtil
    {
        public static string Get(UserTypeEnum type)
        {
            object[] valueAttributes = type.GetType().GetMember(type.ToString())
                .FirstOrDefault(i => i.DeclaringType == type.GetType()).GetCustomAttributes(typeof(DescriptionAttribute), false);

            return valueAttributes.Length > 0 ? ((DescriptionAttribute)valueAttributes[0]).Description : string.Empty;
        }
    }
}