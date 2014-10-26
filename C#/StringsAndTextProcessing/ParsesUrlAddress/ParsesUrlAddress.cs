/*Write a program that parses an URL address given in the format:

and extracts from it the [protocol], [server] and [resource] elements. 
 * For example from the URL http://www.devbg.org/forum/index.php the following information 
 * should be extracted:
[protocol] = "http"
[server] = "www.devbg.org"
[resource] = "/forum/index.php"
*/

namespace ParsesUrlAddress
{
    using System;

    class ParsesUrlAddress
    {
        static void Main()
        {
            string url = @"http://www.devbg.org/forum/index.php";

            int index = url.IndexOf(':');
            string protocol = url.Substring(0, index);
            
            int endServerIndex = url.IndexOf('/', index + 3);
            int startServerIndex = index + 3;

            string server = url.Substring(startServerIndex, endServerIndex - startServerIndex);
            string resource = url.Substring(url.IndexOf('/', index + 3));

            Console.WriteLine(protocol);
            Console.WriteLine(server);
            Console.WriteLine(resource);
        }
    }
}
