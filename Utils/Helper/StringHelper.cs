using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace BookWormProject.Utils.Helper
{
    public static class StringHelper
    {
        public static string ToTitleCase(this string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        public static string RemoveExtraSpaces(this string input)
        {
            return Regex.Replace(input.Trim(), @"\s+", " ");
        }

        public static string ToSlug(this string input)
        {
            input = input.RemoveExtraSpaces();
            input = input.Replace(" ", "-").ToLower();
            input = Regex.Replace(input, @"[^a-z0-9\-]", "");
            return input;
        }

        public static string Truncate(this string input, int maxLength)
        {
            if (input == null || input.Length < maxLength)
            {
                return input;
            }
            return input.Substring(0, maxLength) + "...";
        }

        public static string RemoveSpecialCharacters(string text)
        {
            return Regex.Replace(text, @"[^\w\d\s]+", "");
        }

        public static string RemoveAccents(this string str)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(str);
            return Encoding.ASCII.GetString(bytes);
        }


    }


}
