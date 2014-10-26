using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Model
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        public string IpAddres { get; set; }

        public DateTime VisitingDate { get; set; }
    }
}
