using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Linq;

namespace NorthwindEntity.Data
{
    public partial class Employee
    {
        public DbSet<Territory> Teritories { get; set; }
    }
}
