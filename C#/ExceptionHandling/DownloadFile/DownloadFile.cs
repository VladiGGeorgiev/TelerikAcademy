/*Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg)
 * and stores it the current directory. Find in Google how to download files in C#. 
 * Be sure to catch all exceptions and to free any used resources in the finally block.
*/

namespace DownloadFile
{
    using System;
    using System.Net;

    public class DownloadFile
    {
        public static void Main()
        {
            WebClient myclient = new WebClient();
            try
            {
                myclient.DownloadFile("http://www.devbg.org/index.php", @"D:\Logo.php");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Wrong arguments!");
            }
            catch (WebException)
            {
                Console.WriteLine("You have internet problem!");
            }
        }
    }
}
