namespace Abstraction
{
    /// <summary>
    ///     Abstract class that represents geometric figures.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        ///     Calculate perimeter of any geometric figure
        /// </summary>
        /// <returns>Calculated perimeter</returns>
        public abstract double CalculatePerimeter();

        /// <summary>
        ///     Calculate surface of any geometric figure
        /// </summary>
        /// <returns>Calculated surface</returns>
        public abstract double CalculateSurface();
    }
}
