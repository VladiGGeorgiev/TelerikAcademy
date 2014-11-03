namespace CalendarSystem
{
    using System;
    using System.Text;

    public class CalendarSystemMain
    {
        internal static void Main()
        {
            var eventsManager = new EventsManagerFast();
            var commandExecutor = new CommandExecutor(eventsManager);
            StringBuilder resultOutput = new StringBuilder();

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "End" || inputLine == null)
                {
                    break;
                }

                try
                {
                    Command parsedCommand = Command.Parse(inputLine);
                    string outputCommandResult = commandExecutor.ProcessCommand(parsedCommand);
                    resultOutput.AppendLine(outputCommandResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(resultOutput);
        }
    }
}