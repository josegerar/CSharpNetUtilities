using System;

namespace CSharpNetUtilities
{
    public static class DateExtensions
    {
#if NET6_0_OR_GREATER

        public static DateOnly ToDateOnly(this DateTime source) => DateOnly.FromDateTime(source);

        public static DateTime ToDateTime(this DateOnly source) => source.ToDateTime(TimeOnly.MinValue);

        public static DateOnly? ToDateOnly(this DateTime? source) => !source.HasValue ? null : source.Value.ToDateOnly();

        public static DateTime? ToDateTime(this DateOnly? source) => !source.HasValue ? null : source.Value.ToDateTime();

        

#endif

        public static DateTime? ParseDatetimeForTicks(this long ticks)
        {
            try
            {
                return new DateTime(ticks);
            }
            catch
            {
                return null;
            }
        }

        public static DateTime? ParseDatetimeForSeconds(this long seconds)
        {
            try
            {
                return DateTimeOffset.FromUnixTimeSeconds(seconds).DateTime;
            }
            catch
            {
                return null;
            }
        }
    }
}