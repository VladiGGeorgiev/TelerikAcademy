namespace Minesweeper.Exceptions
{
    using System;

    class CommandUnknownException : Exception
    {
        public CommandUnknownException()
            : base("Command unknown!")
        {
        }

        public CommandUnknownException(string message)
            : base(message)
        {
        }
    }
}
