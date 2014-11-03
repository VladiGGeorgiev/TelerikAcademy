using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem
{
    public struct Command
    {
        public string CommandName { get; set; }

        public string[] Parameters { get; set; }

        public static Command Parse(string inputCommand)
        {
            int nameArgumentsSeparatorIndex = inputCommand.IndexOf(' ');
            if (nameArgumentsSeparatorIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + inputCommand + " There aren't any whitespaces!");
            }

            string eventName = inputCommand.Substring(0, nameArgumentsSeparatorIndex);
            string arguments = inputCommand.Substring(nameArgumentsSeparatorIndex + 1);

            var commandArguments = arguments.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                commandArguments[i] = commandArguments[i].Trim();
            }

            var command = new Command { CommandName = eventName, Parameters = commandArguments };

            return command;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + ((CommandName != null) ? this.CommandName.GetHashCode() : 0);
                result = result * 23 + ((Parameters != null) ? this.Parameters.GetHashCode() : 0);
                return result;
            }
        }

        public override bool Equals(object obj)
        {
            bool isEquals = false;
            Command otherCommand = (Command)obj;
            if (this.CommandName == otherCommand.CommandName)
            {
                isEquals = true;
            }

            if (isEquals)
            {
                isEquals = this.Parameters.SequenceEqual(otherCommand.Parameters);
            }

            return isEquals;
        }
    }
}
