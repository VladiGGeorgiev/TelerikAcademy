namespace PrimitiveTypesPerformance
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();

            #region Chech Add value with primitive types.
            watch.Start();
            AddValue.AddInt(10000000);
            watch.Stop();
            Console.WriteLine("AddInt: " + watch.Elapsed.Milliseconds);
            watch.Reset();

            watch.Start();
            AddValue.AddLong(10000000);
            watch.Stop();
            Console.WriteLine("AddLong: " + watch.Elapsed.Milliseconds);
            watch.Reset();

            watch.Start();
            AddValue.AddDouble(10000000);
            watch.Stop();
            Console.WriteLine("AddDouble: " + watch.Elapsed.Milliseconds);
            watch.Reset();

            watch.Start();
            AddValue.AddFloat(10000000);
            watch.Stop();
            Console.WriteLine("AddFloat: " + watch.Elapsed.Milliseconds);
            watch.Reset();

            watch.Start();
            AddValue.AddDecimal(10000000);
            watch.Stop();
            Console.WriteLine("AddDecimal: " + watch.Elapsed.Milliseconds);
            watch.Reset();
            #endregion

            #region Check Devide with primitive types
            watch.Start();
            DevideValue.DevideInteger(2);
            watch.Stop();
            Console.WriteLine("DevideInteger: " + watch.ElapsedMilliseconds);
            watch.Reset();

            watch.Start();
            DevideValue.DevideFloat(2);
            watch.Stop();
            Console.WriteLine("DevideFloat: " + watch.ElapsedMilliseconds);
            watch.Reset();

            watch.Start();
            DevideValue.DevideDouble(2);
            watch.Stop();
            Console.WriteLine("DevideDouble: " + watch.ElapsedMilliseconds);
            watch.Reset();

            watch.Start();
            DevideValue.DevideLong(2);
            watch.Stop();
            Console.WriteLine("DevideLong: " + watch.ElapsedMilliseconds);
            watch.Reset();

            watch.Start();
            DevideValue.DevideDecimal(2);
            watch.Stop();
            Console.WriteLine("DevideDecimal: " + watch.ElapsedMilliseconds);
            watch.Reset();
            #endregion

            #region Check Devide with primitive types
            watch.Start();
            Multiply.Int(999999999);
            watch.Stop();
            Console.WriteLine("Int: " + watch.ElapsedMilliseconds);
            watch.Reset();

            watch.Start();
            Multiply.Long(999999999);
            watch.Stop();
            Console.WriteLine("Long: " + watch.ElapsedMilliseconds);
            watch.Reset();

            watch.Start();
            Multiply.Double(999999999);
            watch.Stop();
            Console.WriteLine("Double: " + watch.ElapsedMilliseconds);
            watch.Reset();

            watch.Start();
            Multiply.Float(999999999);
            watch.Stop();
            Console.WriteLine("Float: " + watch.ElapsedMilliseconds);
            watch.Reset();

            watch.Start();
            Multiply.Decimal(999999999);
            watch.Stop();
            Console.WriteLine("Decimal: " + watch.ElapsedMilliseconds);
            watch.Reset();
            #endregion
        }
    }
}
