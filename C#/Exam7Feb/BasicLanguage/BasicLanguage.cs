using System;
using System.Text;

class BasicLanguage
{
    static StringBuilder result = new StringBuilder();
    static void Main()
    {
        StringBuilder buffer = new StringBuilder();
        bool isInBrackets = false;

        while (true)
        {
            int nextSymbolCode = Console.Read();
            if (nextSymbolCode == -1) break;

            char nextSymbol = (char)nextSymbolCode;

            if (nextSymbol == '(') isInBrackets = true;
            if (nextSymbol == ')') isInBrackets = false;

            if (nextSymbol == ';' && !isInBrackets)
            {
                string statement = buffer.ToString();

                if (ProccessComands(statement)) break;

                buffer.Clear();
            }
            else
            {
                if (isInBrackets)
                {
                    buffer.Append(nextSymbol);
                }
                else if (!char.IsWhiteSpace(nextSymbol))
                {
                    buffer.Append(nextSymbol);
                }
            }
        }

        Console.Write(result);
    }

    private static bool ProccessComands(string statement)
    {
        long loopCounter = 1;
        string[] comands = statement.Split(')');
        for (int i = 0; i < comands.Length; i++)
        {
            string cmd = comands[i].TrimStart();

            if (cmd.StartsWith("EXIT"))
            {
                return true;
            }
            else if (cmd.StartsWith("PRINT"))
            {
                int startIndexContent = cmd.IndexOf('(') + 1;
                string content = cmd.Substring(startIndexContent);

                if (content.Length > 0)
                {
                    for (int c = 0; c < loopCounter; c++)
                    {
                        result.Append(content);
                    }
                }
            }
            else if (cmd.StartsWith("FOR"))
            {
                int startIndex = cmd.IndexOf('(') + 1;
                int commaIndex = cmd.IndexOf(',');

                if (commaIndex == -1)
                {
                    string forCountStr = cmd.Substring(startIndex);
                    int forCount = int.Parse(forCountStr);
                    loopCounter *= forCount;
                } 
                else
                {
                    string forCount = cmd.Substring(startIndex, commaIndex - startIndex);
                    string forCount2 = cmd.Substring(commaIndex + 1);
                    int forStartCount = int.Parse(forCount);
                    int forEndCount = int.Parse(forCount2);
                    int foreCount = (forEndCount - forStartCount + 1);

                    loopCounter *= foreCount;
                }
            }
        }
        return false;
    } 
}