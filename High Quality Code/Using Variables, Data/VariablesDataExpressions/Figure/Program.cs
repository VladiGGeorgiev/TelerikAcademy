namespace Figure
{
    using System;

    /// <summary>
    ///     Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Rotates figure by input angle 
        /// </summary>
        /// <param name="figure">Rotating figure</param>
        /// <param name="rotatingAngle">Angle that you want to rotate figure</param>
        /// <returns>Rotated figure</returns>
        public static Figure GetRotatedFigure(Figure figure, double rotatingAngle)
        {
            double angleCosinus = Math.Cos(rotatingAngle);
            double angleSinus = Math.Sin(rotatingAngle);

            double rotatedWidth = (Math.Abs(angleCosinus) * figure.Width) + 
                                  (Math.Abs(angleSinus) * figure.Height);

            double rotatedHeight = (Math.Abs(angleSinus) * figure.Width) +
                                   (Math.Abs(angleCosinus) * figure.Height);

            var rotatedFigure = new Figure(rotatedWidth, rotatedHeight);
            return rotatedFigure;
        }

        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
        }
    }
}
