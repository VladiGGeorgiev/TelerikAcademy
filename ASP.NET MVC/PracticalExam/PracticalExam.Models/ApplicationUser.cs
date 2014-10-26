using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;

namespace PracticalExam.Models
{
    public class ApplicationUser : User
    {
        [DefaultValue(10)]
        public int Points { get; set; }
    }
}
