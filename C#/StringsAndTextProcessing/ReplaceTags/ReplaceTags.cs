/*Write a program that replaces in a HTML document given as string all the tags 
 * <a href="…">…</a> with corresponding tags [URL=…]…/URL]. Sample HTML fragment:
*/

namespace ReplaceTags
{
    using System;

    class ReplaceTags
    {
        static void Main(string[] args)
        {
            string html = @"<p>Please visit <a href=""http://academy.telerik. com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";
            
            html = html.Replace(@"<a href=""", "[URL=");
            html = html.Replace(@""">", "]");
            html = html.Replace(@"</a>", "[/URL]");

            Console.WriteLine(html);
        }
    }
}
