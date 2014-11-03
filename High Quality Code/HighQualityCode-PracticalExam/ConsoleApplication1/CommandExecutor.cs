using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem
{
    public class CommandExecutor
    {
        private readonly IEventsManager eventManager;

        public CommandExecutor(IEventsManager eventManager)
        {
            this.eventManager = eventManager;
        }

        public IEventsManager EventsProcessor
        {
            get
            {
                return this.eventManager;
            }
        }

        public string ProcessCommand(Command command)
        {
            string result = string.Empty;
            switch (command.CommandName)
            {
                case "AddEvent":
                    result = ProcessAddEventCommand(command);
                    break;
                case "DeleteEvents":
                    result = ProcessDeleteEventsCommand(command);
                    break;
                case "ListEvents":
                    result = ProcessListEventsCommand(command);
                    break;
                default: 
                    throw new Exception("WTF " + command.CommandName + " is?");
            }

            return result;
        }
  
        /// <summary>
        /// Processes the list events command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Output result</returns>
        private string ProcessListEventsCommand(Command command)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("The number of parameters in DeleteEvents command must be 2!");
            }

            var date = DateTime.ParseExact(command.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var numberOfEvents = int.Parse(command.Parameters[1]);
            var events = this.eventManager.ListEvents(date, numberOfEvents).ToList();
            var result = new StringBuilder();

            if (!events.Any())
            {
                return "No events found";
            }

            foreach (var ev in events)
            {
                result.AppendLine(ev.ToString());
            }

            return result.ToString().Trim();
        }
  
        /// <summary>
        /// Processes the delete events command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Output result</returns>
        private string ProcessDeleteEventsCommand(Command command)
        {
            if (command.Parameters.Length != 1)
            {
                throw new ArgumentException("The number of parameters in DeleteEvents command must be 1");
            }

            int deletedEventsCount = this.eventManager.DeleteEventsByTitle(command.Parameters[0]);

            if (deletedEventsCount == 0)
            {
                return "No events found";
            }

            return deletedEventsCount + " events deleted";
        }

        /// <summary>
        /// Processes the Add events command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Output result</returns>
        private string ProcessAddEventCommand(Command command)
        {

            string result = string.Empty;
            var date = DateTime.ParseExact(command.Parameters[0], 
                "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

            var e = new Event
            {
                Date = date,
                Title = command.Parameters[1],
                Location = null,
            };

            if (command.Parameters.Length == 3)
            {
                e.Location = command.Parameters[2];
            }

            this.eventManager.AddEvent(e);
            result = "Event added";

            return result;
        }
    }
}
