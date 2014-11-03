using ContactBook.Data;
using MvcContrib.UI.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcContrib.Pagination;
using MvcContrib.Sorting;

namespace ContactBook.App.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Contact> contactRepository;

        public HomeController(IRepository<Contact> contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public ActionResult Index(int? page, GridSortOptions sort)
        {
            ViewBag.Sort = sort;
            var contacts = contactRepository.All().Where(x => x.Status != Status.Deleted);
            if (sort != null && sort.Column != null)
            {
                var orderedContacts = contacts.OrderBy(sort.Column, sort.Direction);
                var pagedOrderedContacts = orderedContacts.AsPagination(page ?? 1, 10);

                return View(pagedOrderedContacts);
            }
            else
            {
                var pagedContacts = contacts.ToList().AsPagination(page ?? 1, 10);

                return View(pagedContacts);
            }
        }

        public ActionResult DeleteContact(int id)
        {
            var contact = contactRepository.GetById(id);
            contactRepository.Delete(contact);

            return RedirectToAction("Index");
        }
        
        public ActionResult ChangeStatus(int id) 
        {
            var contact = contactRepository.GetById(id);
            if (contact.Status == Status.Active)
            {
                contact.Status = Status.Inactive;
            }
            else
            {
                contact.Status = Status.Active;
            }

            contactRepository.Update(contact);
            return RedirectToAction("Index");
        }
	}
}