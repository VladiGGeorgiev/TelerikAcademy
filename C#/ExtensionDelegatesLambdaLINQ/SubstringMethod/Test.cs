using System;
using System.Linq;
using System.Text;

namespace SubstringMethod
{
    internal class Test
    {
        internal static void Main()
        {
            var str = new StringBuilder();
            str.Append("Hello my frind. Kefish sa na sun?");
            str.Substring(5);
            Console.WriteLine(str.Substring(3, 5).ToString());
            Console.WriteLine(str.Substring(5).ToString());
        }
    }
}
