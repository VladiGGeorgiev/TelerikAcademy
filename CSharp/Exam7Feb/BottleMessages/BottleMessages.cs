using System;
using System.Collections.Generic;
using System.Text;

class State
{
    public string Obtained { get; set; }
    public string Left { get; set; }
}

class ElementCipher
{
    public char Letter { get; set; }
    public string Digit { get; set; }
}

class BottleMessages
{
    static void Main()
    {
        string code = Console.ReadLine();
        string cipherToDecode = Console.ReadLine();

        List<ElementCipher> cipher = BuildCipher(cipherToDecode);
        List<State> states = new List<State>();
        List<string> results = new List<string>();

        states.Add(new State()
        {
            Obtained = "",
            Left = code,
        });
        int index = 0;
        while (index < states.Count)
        {
            State currentState = states[index];
            index++;

            foreach (var cipherElement in cipher)
            {
                if (currentState.Left.StartsWith(cipherElement.Digit))
                {
                    State newState = new State();
                    newState.Obtained = currentState.Obtained + cipherElement.Letter;
                    newState.Left = currentState.Left.Remove(0, cipherElement.Digit.Length);
                    if (newState.Left == "")
                    {
                        results.Add(newState.Obtained);
                    }
                    else
                    {
                        states.Add(newState);
                    }
                }
            }
        }
        results.Sort();
        Console.WriteLine(results.Count);
        foreach (var decodedMessage in results)
        {
            Console.WriteLine(decodedMessage);
        }
    }

    private static List<ElementCipher> BuildCipher(string cipherToDecode)
    {
        List<ElementCipher> elements = new List<ElementCipher>();
        char? letter = null;
        StringBuilder digits = new StringBuilder();

        foreach (var currentChar in cipherToDecode)
        {
            if (char.IsLetter(currentChar))
            {
                if (letter != null)
                {
                    ElementCipher newElement = new ElementCipher();
                    newElement.Letter = letter.Value;
                    newElement.Digit = digits.ToString();
                    elements.Add(newElement);
                    digits.Clear();
                }
                letter = currentChar;
            }
            else
            {
                digits.Append(currentChar);
            }
        }
        ElementCipher lastElement = new ElementCipher();
        lastElement.Letter = letter.Value;
        lastElement.Digit = digits.ToString();
        elements.Add(lastElement);
        digits.Clear();

        return elements;
    }
}
