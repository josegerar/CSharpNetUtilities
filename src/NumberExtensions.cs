using System.Globalization;

namespace CSharpNetUtilities
{
    public static class NumberExtensions
    {
        public static int ToInt(this object source)
        {
            return int.Parse(source.ToString()!);
        }
        public static decimal ToDecimal(this object source)
        {
            return decimal.Parse(source.ToString()!);
        }
        public static double ToDouble(this object source)
        {
            return double.Parse(source.ToString()!);
        }
        public static float ToFloat(this object source)
        {
            return float.Parse(source.ToString()!);
        }
        public static decimal PercentMaximun(this long value, int maximun)
        {
            return value.ToDecimal().PercentMaximun(maximun.ToDecimal());
        }
        public static decimal PercentMaximun(this int value, int maximun)
        {
            return value.ToDecimal().PercentMaximun(maximun.ToDecimal());
        }
        public static decimal PercentMaximun(this double value, double maximun)
        {
            return value.ToDecimal().PercentMaximun(maximun.ToDecimal());
        }
        public static decimal PercentMaximun(this float value, double maximun)
        {
            return value.ToDecimal().PercentMaximun(maximun.ToDecimal());
        }
        public static decimal PercentMaximun(this float value, decimal maximun)
        {
            return value.ToDecimal().PercentMaximun(maximun);
        }
        public static decimal PercentMaximun(this decimal value, decimal maximun)
        {
            return maximun == 0 ? 0 : value / maximun * 100;
        }
        public static decimal PercentMaximun(this decimal? value, decimal? maximun)
        {
            if (!value.HasValue)
            {
                value = 0;
            }
            if (!maximun.HasValue)
            {
                maximun = 0;
            }
            return value.Value.PercentMaximun(maximun.Value);
        }
        public static decimal Percent(this double value, double percent)
        {
            return value.ToDecimal().Percent(percent.ToDecimal());
        }
        public static decimal Percent(this double? value, double percent)
        {
            if (!value.HasValue)
            {
                value = 0;
            }
            return value.Value.ToDecimal().Percent(percent.ToDecimal());
        }
        public static decimal Percent(this decimal value, decimal percent)
        {
            return percent == 0 ? 0 : ((value * percent) / 100);
        }
        public static decimal Percent(this decimal value, float percent)
        {
            return value.Percent(percent.ToDecimal());
        }
        public static decimal Percent(this decimal value, double percent)
        {
            return value.Percent(percent.ToDecimal());
        }
        public static decimal Percent(this decimal? value, decimal percent)
        {
            if (!value.HasValue)
            {
                value = 0;
            }
            return value.Value.Percent(percent);
        }
        public static decimal Percent(this decimal? value, double percent)
        {
            return value.Percent(percent.ToDecimal());
        }
        public static decimal Percent(this decimal? value, float percent)
        {
            return value.Percent(percent.ToDecimal());
        }
        public static string? Truncate(this double value, int decimales, string? defaultValue = null)
        {
            return ((decimal)value).Truncate(decimales, defaultValue);
        }
        public static string? Truncate(this double? value, int decimales, string? defaultValue = null)
        {
            if (!value.HasValue)
            {
                return defaultValue;
            }
            return ((decimal)value.Value).Truncate(decimales, defaultValue);
        }
        public static string? Truncate(this decimal? value, int decimales, string? defaultValue = null)
        {
            if (!value.HasValue)
            {
                return defaultValue;
            }
            return value.Value.Truncate(decimales, defaultValue);
        }
        public static string? Truncate(this decimal value, int decimales, string? defaultValue = null)
        {
            return value == 0
                ? defaultValue
                : decimal.Round(value, decimales).ToString($"F{decimales}", CultureInfo.InvariantCulture);
        }
        public static string? Truncate(this float? value, int decimales, string? defaultValue = null)
        {
            if (!value.HasValue)
            {
                return defaultValue;
            }
            return value.Value.Truncate(decimales, defaultValue);
        }
        public static string? Truncate(this float value, int decimales, string? defaultValue = null)
        {
            return ((decimal)value).Truncate(decimales, defaultValue);
        }
    }
}


