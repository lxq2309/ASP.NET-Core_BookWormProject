namespace BookWormProject.Utils.Helper
{
    public static class DateTimeHelper
    {
        public static string FormatDateTime(this DateTime datetime, string format)
        {
            return datetime.ToString(format);
        }

        public static string FormatDateTime(this DateTime? datetime, string format)
        {
            return datetime.HasValue ? datetime.Value.ToString(format) : "";
        }

        public static string ToDefaultString(this DateTime datetime)
        {
            return datetime.FormatDateTime("dd/MM/yyyy HH:mm:ss");
        }

        public static string ToDateString(this DateTime datetime)
        {
            return datetime.FormatDateTime("dd/MM/yyyy");
        }

        public static string ToTimeString(this DateTime datetime)
        {
            return datetime.FormatDateTime("HH:mm:ss");
        }

        public static string ToTimeAgo(this DateTime datetime)
        {
            var span = DateTime.UtcNow - datetime;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return string.Format("{0} năm trước", years);
            }
            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return string.Format("{0} tháng trước", months);
            }
            if (span.Days > 0)
                return string.Format("{0} ngày trước", span.Days);
            if (span.Hours > 0)
                return string.Format("{0} giờ trước", span.Hours);
            if (span.Minutes > 0)
                return string.Format("{0} phút trước", span.Minutes);
            if (span.Seconds > 5)
                return string.Format("{0} giây trước", span.Seconds);
            if (span.Seconds <= 5)
                return "vừa xong";
            return string.Empty;
        }
    }
}