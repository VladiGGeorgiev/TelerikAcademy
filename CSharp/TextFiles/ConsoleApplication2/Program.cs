using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = "start";
            string finish = "finish";
            StreamReader read = new StreamReader("../../input.txt");
            StreamWriter write = new StreamWriter("../../input2.txt");
            string line = "";

            using (read)
            {
                using (write)
                {
                    line = read.ReadLine().ToLower();
                    while (line != null)
                    {
                        line = line.Replace(start, finish);
                        write.WriteLine(line);
                        line = read.ReadLine();
                    }
                }
            }
            File.Replace("../../input2.txt", "../../input.txt", "../../backup.txt");
            // if you want to delete backup file uncomment next row
            //File.Delete("../../backup.txt");
        }
    }
}
