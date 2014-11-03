namespace Minesweeper.Exceptions
{
    using System;

    class IllegalMoveException : Exception
    {
        public IllegalMoveException()
            : base("Illegal move!")
        {
        }

        public IllegalMoveException(string message)
            : base(message)
        {
        }
    }
}
