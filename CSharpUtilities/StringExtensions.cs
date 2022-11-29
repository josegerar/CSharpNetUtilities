using System.Text.Json;

namespace BibliotecaClasesPrincipal.Extensions;

public static class StringExtensions
{
    public static string ConcatIf(this string source, bool condition, string second, string joinConcat = " ")
    {
        return condition ? source.Concat(second, joinConcat) : source;
    }

    public static string Concat(this string source, string second, string joinConcat = " ")
    {
        return source + joinConcat + second;
    }

    public static string GetMessageComplete(this Exception exception)
    {
        if (exception is not null)
        {
            return $"{exception.Message} {exception.InnerException?.GetMessageComplete()}";
        }
        return "";
    }

    public static byte[] ParseBase64WithoutPadding(this string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}
