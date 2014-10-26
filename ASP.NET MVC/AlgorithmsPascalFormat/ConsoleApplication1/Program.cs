using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class C18
    {

        public static void Main()
        {

            String filePath = "C:\\Users\\Tisho\\Desktop\\";
            String fileName = "Unit5 - singleLine.txt";
            String sourceCode = "";
            String singleLine = "";
            String[] tabs = {"", "\t", "\t\t", "\t\t\t", "\t\t\t\t", "\t\t\t\t\t",
				 "\t\t\t\t\t\t", "\t\t\t\t\t\t\t", "\t\t\t\t\t\t\t\t", "\t\t\t\t\t\t\t\t\t", "\t\t\t\t\t\t\t\t\t\t",
				"\t\t\t\t\t\t\t\t\t\t\t", "\t\t\t\t\t\t\t\t\t\t\t\t", "\t\t\t\t\t\t\t\t\t\t\t\t\t", "\t\t\t\t\t\t\t\t\t\t\t\t\t\t",
				 "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t"};
            int tab = 0;
            Boolean nextIsServiceWord = false;
            Boolean end = false;
            String[] serviceWords = {	"interface", "uses", "type", "Type",
									"FUNCTION",	"PROCEDURE", "procedure", "private",
									 "public", "var", "VAR", "implementation",
									 "BEGIN", "begin", "end", "end;", "END", "END;",
									 "if", "IF", "else", "ELSE", "case", "CASE",
									 "for", "FOR", "end."};
            Boolean hasEnd = false;
            Boolean hasBegin = false;
            Boolean varCase = false;
            Boolean typeCase = false;
            Boolean beginCase = false;

            StringBuilder code = new StringBuilder();
            string inputLine = Console.ReadLine();
            while (inputLine != null)
            {
                if (inputLine.Trim() == "end.")
                {
                    break;
                }

                code.Append(inputLine + " ");
                inputLine = Console.ReadLine();
            }

            // Razdelqne na Source Code v masiv ot stringove

            string[] splitedCode = code.ToString().Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // proverka za begin end

            for (int i = 0; i < splitedCode.Length; i++)
            {
                for (int j = 0; j < serviceWords.Length; j++)
                {
                    if (splitedCode[i].Equals(serviceWords[j]))
                    {
                    }
                }
                if (splitedCode[i].Equals("end."))
                {
                    hasEnd = true;
                }
                if (splitedCode[i].Equals("begin"))
                {
                    hasBegin = true;
                }
            }

            //Podrejdane na sintaksisa

            String arrangedCode = "";
            for (int i = 0; i < splitedCode.Length; i++)
            {
                for (int j = 0; j < serviceWords.Length; )
                {
                    if (serviceWords[j].Equals(splitedCode[i]))
                    {


                        switch (serviceWords[j])
                        {

                            case "interface": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n";
                                beginCase = true;
                                tab++;
                                break;

                            case "type": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n" + tabs[tab + 1];
                                typeCase = true;
                                tab++;
                                break;

                            case "Type": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n" + tabs[tab + 1];
                                typeCase = true;
                                tab++;
                                break;

                            case "var": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n" + tabs[tab + 1];
                                varCase = true;
                                tab++;
                                break;

                            case "VAR": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n" + tabs[tab + 1];
                                varCase = true;
                                tab++;
                                break;

                            case "BEGIN": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n" + tabs[tab + 1];
                                beginCase = true;
                                tab++;
                                break;

                            case "begin": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n" + tabs[tab + 1];
                                beginCase = true;
                                tab++;
                                break;

                            case "uses": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n" + tabs[tab];
                                break;

                            case "FUNCTION": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + " "; break;

                            case "PROCEDURE": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + " "; break;


                            case "procedure": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + " "; break;

                            case "private": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n" + tabs[tab]; break;

                            case "public": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n" + tabs[tab]; break;

                            case "implementation": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n" + tabs[tab]; break;

                            case "end": if (beginCase == true)
                                {
                                    tab--;
                                    arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n";
                                }
                                break;

                            case "end;": if (beginCase == true)
                                {
                                    tab--;
                                    arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n";
                                }
                                break;

                            case "END": if (beginCase == true)
                                {
                                    tab--;
                                    arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n";
                                }
                                break;

                            case "END;": if (beginCase == true)
                                {
                                    tab--;
                                    arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n" + tabs[tab];
                                }
                                break;

                            case "end.": if (beginCase == true)
                                {
                                    tab--;
                                    arrangedCode += "\n" + tabs[tab] + splitedCode[i] + "\n" + tabs[tab];
                                }
                                break;

                            case "if": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + " "; break;

                            case "IF": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + " "; break;

                            case "else": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + " "; break;

                            case "ELSE": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + " "; break;

                            case "case": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + " "; break;

                            case "CASE": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + " "; break;

                            case "for": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + " " + splitedCode[i + 1]; i++; break;

                            case "FOR": arrangedCode += "\n" + tabs[tab] + splitedCode[i] + " " + splitedCode[i + 1]; i++; break;

                            default: nextIsServiceWord = false;
                                break;
                        }
                    }
                    else
                    {
                        j++;
                    }

                    // cikyl za i + 1 element

                    if (i < splitedCode.Length - 1)
                    {
                        if (splitedCode[i + 1].Contains("//"))
                        {
                            arrangedCode += splitedCode[i] + "\n\n" + tabs[tab]; break;
                        }
                        if (splitedCode[i + 1].Equals(":="))
                        {
                            arrangedCode += "\n" + tabs[tab] + splitedCode[i]; break;
                        }
                    }

                    // rabota s neslujebni dumi				

                    if (j == serviceWords.Length)
                    {
                        arrangedCode += splitedCode[i] + " ";
                        if (splitedCode[i].Contains(";"))
                        {
                            arrangedCode += "\n" + tabs[tab];
                        }
                        if (splitedCode[i].Contains("}"))
                        {
                            arrangedCode += "\n" + tabs[tab];
                        }
                    }
                }
                if (splitedCode[i].Equals("end."))
                {
                    end = true;
                    break;
                }
            }

            Console.WriteLine("\nPodreden kod: \n" + arrangedCode);
            if (end == true)
            {
                Console.WriteLine("\nKrai na programata! \"end.\" e slujebna duma za krai na" +
                                    "\nprograma v Pascal! Ako ste vyveli drug kod, sled \"end.\"," +
                                    "\nnegoviq sintaksis nqma da byde popraven i programata 6te spre!");
            }

            if (!(hasBegin == true && hasEnd == true))
            {
                Console.WriteLine("\nVnimanie! Lipsva slujebnata duma \"end.\" i/ili \"begin\"\n" +
                                    "i programata vi nqma da moje da se kompilira!!!");
            }
        }
    }

}
