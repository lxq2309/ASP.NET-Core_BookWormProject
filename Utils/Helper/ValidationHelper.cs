using System.Text.RegularExpressions;

namespace BookWormProject.Utils.Helper
{
    public static class ValidationHelper
    {
        public static bool IsEmail(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(input);
                return addr.Address == input;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPhone(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^\+?[0-9]{9,15}$");
        }

        public static bool IsUrl(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            Uri uriResult;
            return Uri.TryCreate(input, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }

}
