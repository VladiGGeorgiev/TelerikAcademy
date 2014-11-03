using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem
{
    public class EventsManager : IEventsManager
    {
        private readonly List<Event> list = new List<Event>();

        public void AddEvent(Event ev)
        {
            this.list.Add(ev);
        }

        public int DeleteEventsByTitle(string title)
        {
            return this.list.RemoveAll(
                ev => ev.Title.ToLowerInvariant() == title.ToLowerInvariant());
        }

        public IEnumerable<Event> ListEvents(DateTime date, int numberOfEvents)
        {
            return (from ev in this.list
                    where ev.Date >= date
                    orderby ev.Date, ev.Title, ev.Location
                    select ev).Take(numberOfEvents);
        }
    }
}
