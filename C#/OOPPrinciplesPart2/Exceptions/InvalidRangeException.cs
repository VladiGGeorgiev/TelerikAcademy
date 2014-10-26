namespace Exceptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
        where T : IComparable, IConvertible, IFormattable
    {
        public T MinValue { get; private set; }

        public T MaxValue { get; private set; }

        public InvalidRangeException(string message) : base(message)
        { 
        }

        public InvalidRangeException(string message, T minValue, T maxValue)
            : this(message)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }
    }
}
