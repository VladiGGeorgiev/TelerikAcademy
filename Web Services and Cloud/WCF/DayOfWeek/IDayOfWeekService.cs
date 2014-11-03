using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DayOfWeek
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDayOfWeekService" in both code and config file together.
    [ServiceContract]
    public interface IDayOfWeekService
    {
        [OperationContract]
        string GetDay(DateTime date);
        
        // TODO: Add your service operations here
    }
}
