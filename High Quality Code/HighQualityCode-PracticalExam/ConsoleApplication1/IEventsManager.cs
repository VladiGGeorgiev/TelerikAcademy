using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem
{
    public interface IEventsManager
    {
        /// <summary>
        ///     Add event to list of events. Duplicated events are accepted
        /// </summary>
        /// <param name="ev">Event that you want do add in list of events.</param>
        void AddEvent(Event ev);

        /// <summary>
        ///     Delete events by inserted title.
        /// </summary>
        /// <param name="title">Title of event you want to delete</param>
        /// <returns>Number of deleted events</returns>
        int DeleteEventsByTitle(string title);

        /// <summary>
        ///     Returns list of events after input date and with input number
        /// </summary>
        /// <param name="date">Start date</param>
        /// <param name="count">Number of events</param>
        /// <returns>List of events</returns>
        IEnumerable<Event> ListEvents(DateTime date, int count);
    }
}
