using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopSystem.Data;

namespace LaptopSystem.App.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork Db;

        public BaseController()
        {
            this.Db = new UnitOfWork();
        }

        public BaseController(IUnitOfWork db)
        {
            this.Db = db;
        }
    }
}