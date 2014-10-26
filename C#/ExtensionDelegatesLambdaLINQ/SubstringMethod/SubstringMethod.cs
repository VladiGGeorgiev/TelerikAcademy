/*Implement an extension method Substring(int index, int length) for the class StringBuilder
 * that returns new StringBuilder and has the same functionality as Substring in the class String.
*/

namespace SubstringMethod
{
    using System;
    using System.Text;

    public static class SubstringMethod
    {
        public static StringBuilder Substring(this StringBuilder str, int startIndex)
        {
            return Substring(str, startIndex, str.Length - startIndex);
        }

        public static StringBuilder Substring(this StringBuilder str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (startIndex <= str.Length)
                {
                    if (length >= 0)
                    {
                        if (startIndex + length <= str.Length)
                        {
                            var strTemp = new StringBuilder();
                            if (length != 0)
                            {
                                for (int i = startIndex; i < startIndex + length; i++)
                                {
        	                        strTemp.Append(str[i]);
    		                    }

                                return strTemp;
                            }
                            else
                            {
                                return strTemp;
                            }
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(string.Format("startIndex + str.Length > str.Length"));
                        }
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("length must be >= 0.");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(string.Format("startIndex must have value <= {0}", str.Length));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("startIndex must have value >= 0.");
            }
        }
    }
}
