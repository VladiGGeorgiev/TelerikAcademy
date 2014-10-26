using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticalExam.Data;

namespace PractialExam.App.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork Db;

        public BaseController(IUnitOfWork db)
        {
            this.Db = db;
        }

        public BaseController()
            : this(new UnitOfWork())
        {
        }
    }
}