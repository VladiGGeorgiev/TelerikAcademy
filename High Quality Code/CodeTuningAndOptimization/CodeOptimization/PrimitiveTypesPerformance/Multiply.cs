namespace PrimitiveTypesPerformance
{
    public static class Multiply
    {
        public static void Int(int maxValue)
        {
            int result = 1;

            while (result < maxValue)
            {
                result *= 2;
            }
        }

        public static void Long(long maxValue)
        {
            long result = 1;

            while (result < maxValue)
            {
                result *= 2;
            }
        }

        public static void Double(double maxValue)
        {
            double result = 1;

            while (result < maxValue)
            {
                result *= 2;
            }
        }

        public static void Float(float maxValue)
        {
            float result = 1;

            while (result < maxValue)
            {
                result *= 2;
            }
        }

        public static void Decimal(decimal maxValue)
        {
            decimal result = 1;

            while (result < maxValue)
            {
                result *= 2;
            }
        }
    }
}
