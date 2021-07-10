using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployee _db;
        private ICompany _company;
        public EmployeeController(IEmployee db, ICompany company)
        {
            _db = db;
            _company = company;
        }
        public IActionResult Index(string str, int? page)
        {
            var employees = _db.GetAll();
            if (!String.IsNullOrEmpty(str))
            {
                employees = employees.Where(e => e.Name.Contains(str)
                                              || e.Email.Contains(str)
                                              || e.company.Name.Contains(str)).ToList();
            }
            return View(employees.ToPagedList(page ?? 1, 10));
        }


        public IActionResult Add()
        {
            ViewBag.cmps = new SelectList(_company.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee e)
        {
            if (ModelState.IsValid)
            {
                _db.AddItem(e);
                return RedirectToAction("index");
            }
            return View(e);
        }


    }
}

