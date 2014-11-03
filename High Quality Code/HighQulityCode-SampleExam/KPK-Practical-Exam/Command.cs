namespace ContentCatalog
{
    using System;
    using System.Linq;
    using ContentCatalog.Enumerations;

    public class Command : ICommand
    {
        private readonly char[] paramsSeparators = { ';' };
        private readonly char commandEnd = ':';

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
            this.Parse();
        }

        public CommandType ParseCommandType(string commandName)
        {
            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException("Command name can not contains ';' or ':'!");
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    return CommandType.AddBook;
                case "Add movie":
                    return CommandType.AddMovie;
                case "Add song":
                    return CommandType.AddSong;
                case "Add application":
                    return CommandType.AddApplication;
                case "Update":
                    return CommandType.Update;
                case "Find":
                    return CommandType.Find;
                default:
                    throw new ArgumentException("Invalid command name!");
            }
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex + 1);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 3);

            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 3, paramsLength);

            string[] parameters = paramsOriginalForm.Split(this.paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(this.commandEnd) - 1;

            return endIndex;
        }

        public override string ToString()
        {
            string toString = this.Name + " ";

            foreach (string param in this.Parameters)
            {
                toString += param + " ";
            } 
            
            return toString;
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }
    }
}
