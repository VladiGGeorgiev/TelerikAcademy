namespace PrimitiveTypesPerformance
{
    public static class DevideValue
    {
        public static void DevideInteger(int devider)
        {
            int value = int.MaxValue;
            while (value > 0)
            {
                value /= devider;
            }   
        }

        public static void DevideLong(long devider)
        {
            long value = long.MaxValue;
            while (value > 0)
            {
                value /= devider;
            }
        }

        public static void DevideFloat(float devider)
        {
            float value = float.MaxValue;
            while (value > 0)
            {
                value /= devider;
            }
        }

        public static void DevideDouble(double devider)
        {
            double value = double.MaxValue;
            while (value > 0)
            {
                value /= devider;
            }
        }

        public static void DevideDecimal(decimal devider)
        {
            decimal value = decimal.MaxValue;
            while (value > 0)
            {
                value /= devider;
            }
        }
    }
}
