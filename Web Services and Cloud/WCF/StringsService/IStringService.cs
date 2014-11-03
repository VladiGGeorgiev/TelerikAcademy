using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StringsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStringService" in both code and config file together.
    [ServiceContract]
    public interface IStringService
    {
        [OperationContract]
        int GetContainsCount(string substring, string text);
    }
}
