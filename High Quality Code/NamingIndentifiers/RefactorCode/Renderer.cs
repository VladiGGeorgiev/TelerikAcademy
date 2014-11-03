namespace RefactorCode
{
    using System;

    /// <summary>
    ///     Print some values and variables.
    /// </summary>
    public class Renderer
    {
        /// <summary>
        ///     Constant that is useless in this code.
        /// </summary>
        public const int MaxCount = 6;

        /// <summary>
        ///     The main method.
        /// </summary>
        public static void Main()
        {
            ConsolePrinter consolePrinter = new ConsolePrinter();
            consolePrinter.PrintVariable(true);
        }

        /// <summary>
        ///     Print on console some parameters like variables.
        /// </summary>
        public class ConsolePrinter
        {
            /// <summary>
            ///     Print variable or value on console.
            /// </summary>
            /// <param name="value">Print value of variable</param>
            public void PrintVariable(bool value)
            {
                string stringValue = value.ToString();
                Console.WriteLine(stringValue);
            }
        }
    }
}
