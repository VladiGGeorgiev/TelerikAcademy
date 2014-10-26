/*Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
 * reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…).
 * Be sure to catch all possible exceptions and print user-friendly error messages.
*/

namespace FileName
{
    using System;
    using System.IO;
    using System.Text;

    public class FileName
    {
        public static void Main()
        {
            string path = @"D:\Quotes, Notes, Picz\Recepti.txt";
            string fileText = ReadFile(path);

            Console.WriteLine(fileText);
        }

        private static string ReadFile(string path)
        {
            string fileText = string.Empty;
            try
            {
                fileText = File.ReadAllText(path, Encoding.UTF8);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Some argument have null value!");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("To long path!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You have no access to file!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file was not found!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Missing some directory!");
            }

            return fileText;
        }
    }
}
