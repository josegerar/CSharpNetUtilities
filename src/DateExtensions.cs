﻿using System;

namespace CSharpNetUtilities
{
    public static class DateExtensions
    {
#if NET6_0_OR_GREATER

public static DateOnly ToDateOnly(this DateTime source) => DateOnly.FromDateTime(source);

        public static DateOnly? ToDateOnly(this DateTime? source)
        {
            if (!source.HasValue)
            {
                return null;
            }
            try
            {
                return source.Value.ToDateOnly();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DateTime? ToDateTime(this DateOnly? source)
        {
            if (!source.HasValue)
            {
                return null;
            }
            try
            {
                return source.Value.ToDateTime();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DateTime ToDateTime(this DateOnly source) => source.ToDateTime(TimeOnly.MinValue);

#endif

        public static DateTime? ParseDatetimeForTicks(this long datatimelong)
        {
            try
            {
                return new DateTime(datatimelong);
            }
            catch
            {
                return null;
            }
        }

        public static DateTime? ParseDatetimeForSeconds(this long datatimelong)
        {
            try
            {
                return DateTimeOffset.FromUnixTimeSeconds(datatimelong).DateTime;
            }
            catch
            {
                return null;
            }
        }
    }
}