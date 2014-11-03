using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace CalendarSystem
{
    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionary<string, Event> eventsByTitle =
            new MultiDictionary<string, Event>(true);

        private readonly OrderedMultiDictionary<DateTime, Event> eventsByDate =
            new OrderedMultiDictionary<DateTime, Event>(true);

        public int EventsByDateCount
        {
            get
            {
                return this.eventsByDate.Count;
            }
        }

        public int EventsByTitleCount
        {
            get
            {
                return this.eventsByTitle.Count;
            }
        }

        public void AddEvent(Event ev)
        {
            string eventTitleLowerCase = ev.Title.ToLowerInvariant();
            this.eventsByTitle.Add(eventTitleLowerCase, ev);
            this.eventsByDate.Add(ev.Date, ev);
        }

        public int DeleteEventsByTitle(string title)
        {
            string titleLowerCase = title.ToLowerInvariant();
            var deletedItems = this.eventsByTitle[titleLowerCase];
            int deletedItemsCount = deletedItems.Count;

            foreach (var item in deletedItems)
            {
                this.eventsByDate.Remove(item.Date, item);
            }

            this.eventsByTitle.Remove(titleLowerCase);

            return deletedItemsCount;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            if (count < 1 || count > 100)
            {
                throw new ArgumentOutOfRangeException("The number of evets that listed can not be greater than 100 and smaller than 1!");
            }

            var eventsAfterDate = this.eventsByDate.RangeFrom(date, true).Values;
            var events = eventsAfterDate.Take(count);

            return events;
        }
    }
}
