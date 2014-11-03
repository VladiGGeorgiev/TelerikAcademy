using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLogs.Data
{
    public class LogsContext : DbContext
    {
        public LogsContext()
            : base("LogsContext")
        {
        }

        public DbSet<Log> Logs { get; set; }
    }
}
