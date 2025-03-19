namespace Services.Shared.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly TimeZoneInfo BrazilTimeZone =
            TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        public static DateTime ToBrazilTime(this DateTime utcDateTime)
            => TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, BrazilTimeZone);
    }
}