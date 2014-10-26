namespace Task5
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 array = new BitArray64(48584939);
            BitArray64 array2 = new BitArray64(48584932);

            int[] bits = array.NumberBits;

            Console.WriteLine("array != array2 -> " + (array != array2));
            Console.WriteLine("array == array2 -> " + (array == array2));


            Console.WriteLine("array equals array2 -> " + array.Equals(array2));

            Console.WriteLine("Fifth bit: " + array[4]);

            foreach (var bit in bits)
            {
                Console.Write(bit);
            }

        }
    }
}
