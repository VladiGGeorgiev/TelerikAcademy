using System;
using System.Linq;
using System.Text;
using ContentCatalog;
using ContentCatalog.Enumerations;

namespace ContentCatalog
{
    public interface ICommand
    {
        CommandType Type { get; set; }

        string OriginalForm { get; set; }

        string Name { get; set; }

        string[] Parameters { get; set; }

        CommandType ParseCommandType(string commandName);

        string ParseName();

        string[] ParseParameters();
    }
}
