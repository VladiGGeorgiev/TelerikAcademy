using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Counter.Model;

namespace Counter.Data
{
    public class CounterContext : DbContext
    {
        public CounterContext()
            : base("CounterLogsDb")
        {

        }

        public DbSet<Log> Logs { get; set; }
    }
}
