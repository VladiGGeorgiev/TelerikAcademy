using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem;
using System.Globalization;
using System.Collections.Generic;

namespace TestCalendarSystem
{
    [TestClass]
    public class TestEventsManagerFast
    {
        [TestMethod]
        public void TestAddSingleEvent()
        {
            EventsManagerFast eventManager = new EventsManagerFast();
            Event ev = new Event();
            ev.Title = "Rock party - 407026";
            ev.Date = DateTime.ParseExact("2012-03-31T23:59:57", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "home - 681328";
            eventManager.AddEvent(ev);

            Assert.AreEqual(1, eventManager.EventsByTitleCount);
        }

        [TestMethod]
        public void TestAddMultipleEvents()
        {
            EventsManagerFast eventManager = new EventsManagerFast();

            Event ev = new Event();
            ev.Title = "Rock party - 407026";
            ev.Date = DateTime.ParseExact("2012-03-31T23:59:57", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "home - 681328";
            eventManager.AddEvent(ev);

            Event ev2 = new Event();
            ev2.Title = "party Lora - 198672";
            ev2.Date = DateTime.ParseExact("2001-01-01T10:30:03", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev2.Location = "- 235165";
            eventManager.AddEvent(ev2);

            Event ev3 = new Event();
            ev3.Title = "Chalga party - 974464";
            ev3.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev3.Location = "at school - 4795";
            eventManager.AddEvent(ev3);

            Assert.AreEqual(3, eventManager.EventsByTitleCount);
        }

        [TestMethod]
        public void TestAddMultipleSameTitleEvents()
        {
            EventsManagerFast eventManager = new EventsManagerFast();

            Event ev = new Event();
            ev.Title = "Rock party - 407026";
            ev.Date = DateTime.ParseExact("2012-03-31T23:59:57", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "home - 681328";
            eventManager.AddEvent(ev);

            Event ev2 = new Event();
            ev2.Title = "Rock party - 407026";
            ev2.Date = DateTime.ParseExact("2001-01-01T10:30:03", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev2.Location = "- 235165";
            eventManager.AddEvent(ev2);

            Event ev3 = new Event();
            ev3.Title = "Rock party - 407026";
            ev3.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev3.Location = "at school - 4795";
            eventManager.AddEvent(ev3);

            Assert.AreEqual(3, eventManager.EventsByDateCount);
            Assert.AreEqual(1, eventManager.EventsByTitleCount);
        }

        [TestMethod]
        public void TestAddMultipleSameDateEvents()
        {
            EventsManagerFast eventManager = new EventsManagerFast();

            Event ev = new Event();
            ev.Title = "Rock party - 407026";
            ev.Date = DateTime.ParseExact("2001-01-01T08:30:03", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "home - 681328";
            eventManager.AddEvent(ev);

            Event ev2 = new Event();
            ev2.Title = "Chalga party";
            ev2.Date = DateTime.ParseExact("2001-01-01T08:30:03", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev2.Location = "- 235165";
            eventManager.AddEvent(ev2);

            Event ev3 = new Event();
            ev3.Title = "Party LORA";
            ev3.Date = DateTime.ParseExact("2001-01-01T08:30:03", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev3.Location = "at school - 4795";
            eventManager.AddEvent(ev3);

            Assert.AreEqual(1, eventManager.EventsByDateCount);
            Assert.AreEqual(3, eventManager.EventsByTitleCount);
        }

        [TestMethod]
        public void TestDeleteExistingEvent()
        {
            EventsManagerFast eventManager = new EventsManagerFast();

            Event ev = new Event();
            ev.Title = "C# course - 756828";
            ev.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "Telerik academy";
            eventManager.AddEvent(ev);

            Event ev2 = new Event();
            ev2.Title = "EXAM - 564705";
            ev2.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev2.Location = "Sofia - 230340";
            eventManager.AddEvent(ev2);

            var deletedEventsCount = eventManager.DeleteEventsByTitle("C# course - 756828");

            Assert.AreEqual(1, deletedEventsCount);
            Assert.AreEqual(1, eventManager.EventsByTitleCount);
            Assert.AreEqual(1, eventManager.EventsByDateCount);
        }

        [TestMethod]
        public void TestDeleteNonExistingEvent()
        {
            EventsManagerFast eventManager = new EventsManagerFast();

            Event ev = new Event();
            ev.Title = "C# course - 756828";
            ev.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "Telerik academy";
            eventManager.AddEvent(ev);

            Event ev2 = new Event();
            ev2.Title = "EXAM - 564705";
            ev2.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev2.Location = "Sofia - 230340";
            eventManager.AddEvent(ev2);

            var deletedEventsCount = eventManager.DeleteEventsByTitle("Non existing event");

            Assert.AreEqual(0, deletedEventsCount);
        }

        [TestMethod]
        public void TestDeleteMultipleEventsWithSameTitle()
        {
            EventsManagerFast eventManager = new EventsManagerFast();

            Event ev = new Event();
            ev.Title = "C# course - 756828";
            ev.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "Telerik academy";
            eventManager.AddEvent(ev);

            Event ev2 = new Event();
            ev2.Title = "Chalga party";
            ev2.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev2.Location = "Sofia - 230340";
            eventManager.AddEvent(ev2);

            Event ev3 = new Event();
            ev3.Title = "C# course - 756828";
            ev3.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev3.Location = "Sofia - 230340";
            eventManager.AddEvent(ev3);

            Event ev4 = new Event();
            ev4.Title = "party Kiro";
            ev4.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev4.Location = "Sofia - 230340";
            eventManager.AddEvent(ev4);

            var deletedEventsCount = eventManager.DeleteEventsByTitle("C# course - 756828");

            Assert.AreEqual(2, deletedEventsCount);
            Assert.AreEqual(1, eventManager.EventsByDateCount);
            Assert.AreEqual(2, eventManager.EventsByTitleCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListEventsOutOfRangeCount()
        {
            EventsManagerFast eventManager = new EventsManagerFast();

            Event ev = new Event();
            ev.Title = "C# course - 756828";
            ev.Date = DateTime.ParseExact("2000-01-01T00:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "Telerik academy";
            eventManager.AddEvent(ev);

            eventManager.ListEvents(new DateTime(1999, 5, 20, 5, 20, 30), 9999);
        }

        [TestMethod]
        public void TestListEventsWithGreaterCountFromDateBetweenEvents()
        {
            EventsManagerFast eventManager = new EventsManagerFast();

            Event ev = new Event();
            ev.Title = "C# course - 756828";
            ev.Date = DateTime.ParseExact("2000-01-01T00:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "Telerik academy";
            eventManager.AddEvent(ev);

            Event ev2 = new Event();
            ev2.Title = "Chalga party";
            ev2.Date = DateTime.ParseExact("2012-03-31T23:59:57", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev2.Location = "Sofia - 230340";
            eventManager.AddEvent(ev2);

            Event ev3 = new Event();
            ev3.Title = "C# course - 756828";
            ev3.Date = DateTime.ParseExact("2019-01-01T00:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev3.Location = "Sofia - 230340";
            eventManager.AddEvent(ev3);

            Event ev4 = new Event();
            ev4.Title = "party Kiro";
            ev4.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev4.Location = "Sofia - 230340";
            eventManager.AddEvent(ev4);

            IEnumerable<Event> events = eventManager.ListEvents(new DateTime(2002, 1, 1), 10);

            var counter = 0;
            foreach (var currentEvent in events)
            {
                counter++;
            }

            Assert.AreEqual(2, counter);
        }

        [TestMethod]
        public void TestListEventsWithGreaterCountFromDateBeforeEvents()
        {
            EventsManagerFast eventManager = new EventsManagerFast();

            Event ev = new Event();
            ev.Title = "C# course - 756828";
            ev.Date = DateTime.ParseExact("2000-01-01T00:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "Telerik academy";
            eventManager.AddEvent(ev);

            Event ev2 = new Event();
            ev2.Title = "Chalga party";
            ev2.Date = DateTime.ParseExact("2012-03-31T23:59:57", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev2.Location = "Sofia - 230340";
            eventManager.AddEvent(ev2);

            Event ev3 = new Event();
            ev3.Title = "C# course - 756828";
            ev3.Date = DateTime.ParseExact("2019-01-01T00:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev3.Location = "Sofia - 230340";
            eventManager.AddEvent(ev3);

            Event ev4 = new Event();
            ev4.Title = "party Kiro";
            ev4.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev4.Location = "Sofia - 230340";
            eventManager.AddEvent(ev4);

            IEnumerable<Event> events = eventManager.ListEvents(new DateTime(1999, 1, 1), 20);

            var counter = 0;
            foreach (var currentEvent in events)
            {
                counter++;
            }

            Assert.AreEqual(4, counter);
        }

        [TestMethod]
        public void TestListEventsWithSmallerCountFromDateBeforeEvents()
        {
            EventsManagerFast eventManager = new EventsManagerFast();

            Event ev = new Event();
            ev.Title = "C# course - 756828";
            ev.Date = DateTime.ParseExact("2000-01-01T00:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "Telerik academy";
            eventManager.AddEvent(ev);

            Event ev2 = new Event();
            ev2.Title = "Chalga party";
            ev2.Date = DateTime.ParseExact("2012-03-31T23:59:57", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev2.Location = "Sofia - 230340";
            eventManager.AddEvent(ev2);

            Event ev3 = new Event();
            ev3.Title = "C# course - 756828";
            ev3.Date = DateTime.ParseExact("2019-01-01T00:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev3.Location = "Sofia - 230340";
            eventManager.AddEvent(ev3);

            Event ev4 = new Event();
            ev4.Title = "party Kiro";
            ev4.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev4.Location = "Sofia - 230340";
            eventManager.AddEvent(ev4);

            IEnumerable<Event> events = eventManager.ListEvents(new DateTime(1999, 1, 1), 3);

            var counter = 0;
            foreach (var currentEvent in events)
            {
                counter++;
            }

            Assert.AreEqual(3, counter);
        }

        [TestMethod]
        public void TestListEventsWithSmallerCountFromDateBetweenEvents()
        {
            EventsManagerFast eventManager = new EventsManagerFast();

            Event ev = new Event();
            ev.Title = "C# course - 756828";
            ev.Date = DateTime.ParseExact("2000-01-01T00:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "Telerik academy";
            eventManager.AddEvent(ev);

            Event ev2 = new Event();
            ev2.Title = "Chalga party";
            ev2.Date = DateTime.ParseExact("2012-03-31T23:59:57", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev2.Location = "Sofia - 230340";
            eventManager.AddEvent(ev2);

            Event ev3 = new Event();
            ev3.Title = "C# course - 756828";
            ev3.Date = DateTime.ParseExact("2019-01-01T00:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev3.Location = "Sofia - 230340";
            eventManager.AddEvent(ev3);

            Event ev4 = new Event();
            ev4.Title = "party Kiro";
            ev4.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev4.Location = "Sofia - 230340";
            eventManager.AddEvent(ev4);

            IEnumerable<Event> events = eventManager.ListEvents(new DateTime(2001, 1, 1, 9, 30, 20), 2);

            var counter = 0;
            foreach (var currentEvent in events)
            {
                counter++;
            }

            Assert.AreEqual(2, counter);
        }

        [TestMethod]
        public void TestListEventsWithDateAfterEvents()
        {
            EventsManagerFast eventManager = new EventsManagerFast();

            Event ev = new Event();
            ev.Title = "C# course - 756828";
            ev.Date = DateTime.ParseExact("2000-01-01T00:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev.Location = "Telerik academy";
            eventManager.AddEvent(ev);

            Event ev2 = new Event();
            ev2.Title = "Chalga party";
            ev2.Date = DateTime.ParseExact("2012-03-31T23:59:57", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev2.Location = "Sofia - 230340";
            eventManager.AddEvent(ev2);

            Event ev3 = new Event();
            ev3.Title = "C# course - 756828";
            ev3.Date = DateTime.ParseExact("2019-01-01T00:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev3.Location = "Sofia - 230340";
            eventManager.AddEvent(ev3);

            Event ev4 = new Event();
            ev4.Title = "party Kiro";
            ev4.Date = DateTime.ParseExact("2001-01-01T10:30:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            ev4.Location = "Sofia - 230340";
            eventManager.AddEvent(ev4);

            IEnumerable<Event> events = eventManager.ListEvents(new DateTime(2050, 1, 1), 3);

            var counter = 0;
            foreach (var currentEvent in events)
            {
                counter++;
            }

            Assert.AreEqual(0, counter);
        }
    }
}
