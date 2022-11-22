using System.Text.RegularExpressions;

namespace executiveWeb
{

    public enum Roles
    {
        Administrators, Employees, Members
    }
    public static class AppExtentions
    {

        public static string ToSafeUrlString(this string text) => Regex.Replace(string.Concat(text.Where(p => char.IsLetterOrDigit(p) || char.IsWhiteSpace(p))), @"\s+", "-").ToLower();

    }
}
