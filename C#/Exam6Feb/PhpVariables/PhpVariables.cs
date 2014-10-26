namespace PhpVariables
{
    using System;
    using System.Collections.Generic;

    public class PhpVariables
    {
        static private readonly List<string> Variables = new List<string>();

        private static void Print(List<string> variables)
        {
            Console.WriteLine(variables.Count);
            for (int i = 0; i < variables.Count; i++)
            {
                Console.WriteLine(variables[i]);
            }
        }

        private static void CountVariables(List<string> codeLines)
        {
            bool isInComment = false;
            bool isInMultilineComment = false;
            for (int i = 0; i < codeLines.Count; i++)
            {
                for (int j = 0; j < codeLines[i].Length - 1; j++)
                {
                    if (codeLines[i][j] == '#' ||
                        (codeLines[i][j] == '/' && codeLines[i][j + 1] == '/'))
                    {
                        isInComment = true;
                    }

                    if (codeLines[i][j] == '*' && codeLines[i][j + 1] == '/')
                    {
                        isInComment = false;
                    }

                    if (codeLines[i][j] == '/' && codeLines[i][j + 1] == '*')
                    {
                        isInMultilineComment = true;
                    }

                    if (codeLines[i][j] == '*' && codeLines[i][j + 1] == '/')
                    {
                        isInMultilineComment = false;
                    }

                    if (codeLines[i][j] == '$' && isInComment == false && isInMultilineComment == false)
                    {
                        if (j > 0 && codeLines[i][j - 1] == '\\')
                        {
                            continue;
                        }

                        int startVariableIndex = j + 1;

                        int endVariableIndex = startVariableIndex;
                        int index = startVariableIndex;
                        while (char.IsLetter(codeLines[i][index]) || char.IsDigit(codeLines[i][index]) || codeLines[i][index] == '_')
                        {
                            index++;
                            endVariableIndex = index;
                        }

                        string variableName =
                            codeLines[i].Substring(startVariableIndex, endVariableIndex - startVariableIndex);

                        AddVariable(variableName);
                    }
                }

                isInComment = false;
            }
        }

        private static void AddVariable(string variableName)
        {
            for (int i = 0; i < Variables.Count; i++)
            {
                if (Variables[i] == variableName)
                {
                    return;
                }
            }

            Variables.Add(variableName);
        }

        private static void ReadInput(List<string> codeLines)
        {
            int lineNumber = 0;
            string lineCode = Console.ReadLine();
            codeLines.Add(lineCode);
            while (!codeLines[lineNumber].EndsWith("?>"))
            {
                lineNumber++;
                lineCode = Console.ReadLine();
                codeLines.Add(lineCode);
            }
        }

        private static void Main()
        {
            List<string> codeLines = new List<string>();

            ReadInput(codeLines);

            CountVariables(codeLines);

            Variables.Sort();

            Print(Variables);
        }
    }
}
