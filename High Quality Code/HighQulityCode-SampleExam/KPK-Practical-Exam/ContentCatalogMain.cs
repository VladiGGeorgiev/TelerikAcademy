using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentCatalog
{
    public class ContentCatalogMain
    {
        public static void Main()
        {
            StringBuilder result = new StringBuilder(); 
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            List<ICommand> parsedCommands = ParseInputCommands();

            foreach (ICommand command in parsedCommands)
            {
                commandExecutor.ExecuteCommand(catalog, command, result);
            }

            Console.Write(result);
        }

        private static List<ICommand> ParseInputCommands()
        {
            List<ICommand> commands = new List<ICommand>();
            bool isFindEndCommand = false;

            do
            {
                string inputLine = Console.ReadLine();
                isFindEndCommand = inputLine.Trim() == "End";
                if (!isFindEndCommand)
                {
                    commands.Add(new Command(inputLine));
                }
            }
            while (!isFindEndCommand);

            return commands;
        }
    }
}
