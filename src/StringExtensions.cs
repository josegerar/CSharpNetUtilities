using System;

namespace CSharpNetUtilities
{
    public static class StringExtensions
    {
        /// <summary>
        /// Joins two text strings if the input condition of the parameter is met.
        /// </summary>
        /// <param name="source">Main text</param>
        /// <param name="condition">Condition to be met</param>
        /// <param name="second">Text to concatenate</param>
        /// <param name="joinConcat">Text to be used for concatenation. By default a space (" ")</param>
        /// <returns>Concatenated text</returns>
        public static string ConcatIf(this string source, bool condition, string second, string joinConcat = " ")
        {
            return condition ? source.Concat(second, joinConcat) : source;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">Main text</param>
        /// <param name="second">Text to concatenate</param>
        /// <param name="joinConcat">Text to be used for concatenation. By default a space (" ")</param>
        /// <returns>Concatenated text</returns>
        public static string Concat(this string source, string second, string joinConcat = " ")
        {
            return source + joinConcat + second;
        }

        /// <summary>
        /// Extracts all the information contained in an Exception, extracting the information of the current exception and its internal exceptions.
        /// </summary>
        /// <param name="exception">Exception to be extracted</param>
        /// <returns>Returns a text string with all the information contained in the exception</returns>
        public static string GetMessageComplete(this Exception exception)
        {
            if (exception is not null)
            {
                return $"{exception.Message} {exception.InnerException?.GetMessageComplete()}";
            }
            return "";
        }

        /// <summary>
        /// Converts a text string in base 64 to bytes
        /// </summary>
        /// <param name="base64">Text to convert</param>
        /// <returns>Returns the bytes representing the text string in base 64</returns>
        public static byte[] ParseBase64WithoutPadding(this string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        /// <summary>
        /// Convert the first letter of a text string to uppercase
        /// </summary>
        /// <param name="input">Text to convert</param>
        /// <returns>Returns text with the first letter capitalized.</returns>
        public static string? ToTitleCase(this string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            char[] chars = input.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            return new string(chars);
        }
    }
}

