using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream(input, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamReader _in = new StreamReader(bs))
                    {
                        using (StreamWriter _out = new StreamWriter(output))
                        {
                            string line;
                            while ((line = _in.ReadLine()) != null)
                            {
                                if (wholeWordOnly)
                                {
                                    _out.WriteLine(Regex.Replace(line, @"\bstart\b", "finish"));
                                }
                                else
                                {
                                    _out.WriteLine(line.Replace("start", "finish"));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
