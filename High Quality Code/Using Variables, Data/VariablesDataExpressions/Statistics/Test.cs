namespace Statistics
{
    /// <summary>
    ///     Test class for SequenceStatistics
    /// </summary>
    public class Test
    {
        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
            var array = new double[] { 3, 5, 2.12, 4, 23.1, 12, 3.32, 32, 14 };
            SequenceStatistics stat = new SequenceStatistics(array);

            stat.PrintAverageValue();
            stat.PrintMaxElement();
            stat.PrintMinElement();
        }
    }
}
