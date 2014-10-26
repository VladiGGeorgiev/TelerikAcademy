namespace Task5
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class BitArray64 : IEnumerable<int>
    {
        private ulong number;

        public BitArray64(ulong number)
        {
            this.number = number;
        }

        public int[] NumberBits 
        {
            get 
            {
                return this.ConvertNumberToBitArray(); 
            }
        }

        public int[] ConvertNumberToBitArray()
        {
            int[] result = new int[64];
            ulong tempNumber = this.number;

            for (int i = result.Length - 1; i >= 0; i--)
            {
                if (tempNumber <= 0)
                {
                    result[i] = 0;
                    continue;
                }

                result[i] = (int)tempNumber % 2;
                tempNumber /= 2;
            }

            return result;
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException();
                }

                int bit = (int)(this.number & (1u << index));

                return bit >> index;
            }

            set
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException();
                }

                if (value != 0 || value != 1)
                {
                    throw new ArgumentOutOfRangeException("Value must be 1 or 0!");
                }

                if (value == 1)
                {
                    this.number |= (ulong)(1 << index);
                }
                else
                {
                    this.number &= (ulong)(~(1 << index));
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        public override bool Equals(object obj)
        {
            BitArray64 bitArray = obj as BitArray64;
            if (bitArray == null)
            {
                return false;
            }

            return object.Equals(this.number, bitArray.number);
        }

        public override int GetHashCode()
        {
            return this.number.GetHashCode() ^ 69;
        }

        public static bool operator ==(BitArray64 array, BitArray64 array2)
        {
            return BitArray64.Equals(array, array2);
        }

        public static bool operator !=(BitArray64 array, BitArray64 array2)
        {
            return !BitArray64.Equals(array, array2);
        }
    }
}
