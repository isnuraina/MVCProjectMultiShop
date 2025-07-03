using System.Text.RegularExpressions;

namespace Bigon.WebUI.AppCode.Extensions
{
    public static partial class Extension
    {
        public static bool IsEmail(this string value)
        {
            return Regex.IsMatch(value, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
