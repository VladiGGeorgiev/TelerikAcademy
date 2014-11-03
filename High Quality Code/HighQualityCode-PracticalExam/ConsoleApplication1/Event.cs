namespace CalendarSystem
{
    using System;
    using System.Linq;

    public class Event : IComparable<Event>
    {
        private string title;
        private string location;

        public Event()
        {

        }

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (value != null)
                {
                    if (value.Length > 1000)
                    {
                        throw new ArgumentOutOfRangeException("The title length can not be greater than 1000 symbols");
                    }

                    if (value == null && value == string.Empty)
                    {
                        throw new ArgumentNullException("The title can not be null or empty string!");
                    }

                    if (value.Contains('|') || value.Contains('\n'))
                    {
                        throw new ArgumentException("The title can not contains '|' or '\n'");
                    }
                }

                this.title = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                if (value != null)
                {
                    if (value.Length > 1000)
                    {
                        throw new ArgumentOutOfRangeException("The location length can not be greater than 1000 symbols");
                    }

                    if (value == string.Empty)
                    {
                        throw new ArgumentNullException("The location can not be null or empty string!");
                    }

                    if (value.Contains('|') || value.Contains('\n'))
                    {
                        throw new ArgumentException("The location can not contains '|' or '\n'");
                    }
                }

                this.location = value;
            }
        }

        public override string ToString()
        {
            string resultFormat = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";
            
            if (this.Location != null)
            {
                resultFormat += " | {2}";
            }

            string eventAsString = string.Format(resultFormat, this.Date, this.Title, this.Location);
            return eventAsString;
        }

        public int CompareTo(Event ev)
        {
            int result = DateTime.Compare(this.Date, ev.Date);
            if (result == 0)
            {
                result = string.Compare(this.Title, ev.Title, StringComparison.InvariantCulture);
            }

            if (result == 0)
            {
                result = string.Compare(this.Location, ev.Location, StringComparison.InvariantCulture);
            }

            return result;
        }
    }
}
