using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StringsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StringService" in both code and config file together.
    public class StringService : IStringService
    {
        public int GetContainsCount(string substring, string text)
        {
            int index = text.IndexOf(substring);
            int containsCounter = 0;
            while (index >= 0)
            {
                containsCounter++;
                index = text.IndexOf(substring, index + 1);
            }

            return containsCounter;
        }
    }
}
