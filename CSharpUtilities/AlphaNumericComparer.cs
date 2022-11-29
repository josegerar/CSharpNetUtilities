using System.Globalization;
using System.Text;

namespace BibliotecaClasesPrincipal;

public class AlphaNumericComparer : IComparer<object>
{
    private enum ChunkType { Alphanumeric, Numeric };
    private static bool InChunk(char ch, char otherCh)
    {
        ChunkType type = ChunkType.Alphanumeric;

        if (char.IsDigit(otherCh))
        {
            type = ChunkType.Numeric;
        }

        if (type == ChunkType.Alphanumeric && char.IsDigit(ch)
            || type == ChunkType.Numeric && !char.IsDigit(ch))
        {
            return false;
        }

        return true;
    }

    public int Compare(object? x, object? y)
    {
        string? s1 = Convert.ToString(x);
        if (s1 == null)
        {
            return 0;
        }
        string? s2 = Convert.ToString(y);
        if (s2 == null)
        {
            return 0;
        }

        if (DateTime.TryParse(s1, out var result1) && DateTime.TryParse(s2, out var result2))
        {
            if (result1 == result2)
            {
                return 0;
            }
            else if (result1 > result2)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        if (double.TryParse(s1, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out var resultN1)
            && double.TryParse(s2, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out var resultN2))
        {
            if (resultN1 == resultN2)
            {
                return 0;
            }
            else if (resultN1 > resultN2)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        int thisMarker = 0;
        int thatMarker = 0;

        while (thisMarker < s1.Length || thatMarker < s2.Length)
        {
            if (thisMarker >= s1.Length)
            {
                return -1;
            }
            else if (thatMarker >= s2.Length)
            {
                return 1;
            }
            char thisCh = s1[thisMarker];
            char thatCh = s2[thatMarker];

            StringBuilder thisChunk = new();
            StringBuilder thatChunk = new();

            while (thisMarker < s1.Length && (thisChunk.Length == 0 || InChunk(thisCh, thisChunk[0])))
            {
                thisChunk.Append(thisCh);
                thisMarker++;

                if (thisMarker < s1.Length)
                {
                    thisCh = s1[thisMarker];
                }
            }

            while (thatMarker < s2.Length && (thatChunk.Length == 0 || InChunk(thatCh, thatChunk[0])))
            {
                thatChunk.Append(thatCh);
                thatMarker++;

                if (thatMarker < s2.Length)
                {
                    thatCh = s2[thatMarker];
                }
            }

            int result = 0;
            // If both chunks contain numeric characters, sort them numerically
            if (char.IsDigit(thisChunk[0]) && char.IsDigit(thatChunk[0]))
            {
                int thisNumericChunk = Convert.ToInt32(thisChunk.ToString());
                int thatNumericChunk = Convert.ToInt32(thatChunk.ToString());

                if (thisNumericChunk < thatNumericChunk)
                {
                    result = -1;
                }

                if (thisNumericChunk > thatNumericChunk)
                {
                    result = 1;
                }
            }
            else
            {
                result = thisChunk.ToString().CompareTo(thatChunk.ToString());
            }

            if (result != 0)
            {
                return result;
            }
        }

        return 0;
    }
}