using System;
using System.Threading.Tasks;

namespace CSharpNetUtilities.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            decimal? res = null;

            Console.WriteLine(res.Truncate(2, "0"));
        }
    }
}