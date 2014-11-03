using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DayOfWeek
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DayOfWeek" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DayOfWeek.svc or DayOfWeek.svc.cs at the Solution Explorer and start debugging.
    public class DayOfWeek : IDayOfWeekService
    {
        public string GetDay(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case System.DayOfWeek.Sunday:
                    return "Неделя";
                case System.DayOfWeek.Monday:
                    return "Понеделник";
                case System.DayOfWeek.Tuesday:
                    return "Вторник";
                case System.DayOfWeek.Wednesday:
                    return "Сряда";
                case System.DayOfWeek.Thursday:
                    return "Четвъртък";
                case System.DayOfWeek.Friday:
                    return "Петък";
                case System.DayOfWeek.Saturday:
                    return "Събота";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
