using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticalExam.Models;

namespace PracticalExam.Data
{
    public interface IUnitOfWork
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
