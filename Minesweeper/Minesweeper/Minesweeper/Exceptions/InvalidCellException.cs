namespace Minesweeper.Exceptions
{
    using System;

    class InvalidCellException : Exception
    {
        public InvalidCellException()
            : base("Invalid cell!")
        {
        }
        public InvalidCellException(string message)
            : base(message)
        {
        }
    }
}
