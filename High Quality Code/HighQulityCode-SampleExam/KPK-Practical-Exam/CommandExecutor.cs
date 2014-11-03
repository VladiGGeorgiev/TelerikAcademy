namespace ContentCatalog
{
    using ContentCatalog.Enumerations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        //TODO: Documentation
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder sb)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    this.ExecuteCommandAddBook(command, catalog, sb);
                    break;
                case CommandType.AddMovie:
                    this.ExecuteCommandAddMovie(command, catalog, sb);
                    break;
                case CommandType.AddSong:
                    this.ExecuteCommandAddSong(command, catalog, sb);
                    break;
                case CommandType.AddApplication:
                    this.ExecuteCommandAddApplication(command, catalog, sb);
                    break;
                case CommandType.Update:
                    this.ExecuteCommandUpdate(command, catalog, sb);
                    break;
                case CommandType.Find:
                    this.ExecuteCommandFind(command, catalog, sb);
                    break;
                default:
                    throw new InvalidCastException("Unknown command!");
            }
        }
  
        private void ExecuteCommandUpdate(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            if (command.Parameters.Length != 2)
            {
                throw new FormatException("Command parameters length must be == 2!");
            }

            int numberOfUpdatedItems = catalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
            string updatedOutputMessage = string.Format("{0} items updated", numberOfUpdatedItems);

            sb.AppendLine(updatedOutputMessage);
        }
  
        private void ExecuteCommandAddApplication(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            var application = new Content(ContentType.Application, command.Parameters);
            catalog.Add(application);
            sb.AppendLine("Application added");
        }
  
        private void ExecuteCommandAddSong(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            var song = new Content(ContentType.Song, command.Parameters);
            catalog.Add(song);
            sb.AppendLine("Song added");
        }
  
        private void ExecuteCommandAddMovie(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            var movie = new Content(ContentType.Movie, command.Parameters);
            catalog.Add(movie);
            sb.AppendLine("Movie added");
        }
  
        private void ExecuteCommandAddBook(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            var book = new Content(ContentType.Book, command.Parameters);
            catalog.Add(book);
            sb.AppendLine("Book Added");
        }
  
        private void ExecuteCommandFind(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            if (command.Parameters.Length != 2)
            {
                throw new Exception("Invalid number of parameters!");
            }

            int numberOfElementsToList = int.Parse(command.Parameters[1]);

            IEnumerable<IContent> foundContent = catalog.GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                sb.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    sb.AppendLine(content.TextRepresentation);
                }
            }
        }
    }
}
