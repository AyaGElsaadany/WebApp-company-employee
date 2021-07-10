using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;
using PagedList;
using PagedList.Mvc;

namespace WebApp.Controllers
{
    public class CompanyController : Controller
    {
        private ICompany _db;
        public CompanyController(ICompany db)
        {
            _db = db;
        }
        public IActionResult Index(string str, int? page)
        {
            var companies = _db.GetAll();
            if (!String.IsNullOrEmpty(str))
            {
                companies = companies.Where(c => c.Name.Contains(str)
                                                     || c.Website.Contains(str)
                                                     || c.Address.Contains(str)).ToList();
            }
            return View(companies.ToPagedList(page ?? 1, 10));
        }

        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Company c)
        {
            if (ModelState.IsValid)
            {
                _db.AddItem(c);
                return RedirectToAction("index");
            }
            return View(c);
        }

        
    }
}
