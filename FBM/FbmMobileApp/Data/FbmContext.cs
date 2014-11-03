using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FbmMobileApp.Models;

namespace FbmMobileApp.Data
{
    public class FbmContext : DbContext
    {
        public IDbSet<Studio> Studios { get; set; }

        public IDbSet<Town> Towns { get; set; }

        public IDbSet<Comment> Comments { get; set; }
    }
}