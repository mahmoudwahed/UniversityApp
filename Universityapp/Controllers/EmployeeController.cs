using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Universityapp.Models;

namespace Universityapp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ServicesDBContext _context;
        public EmployeeController(ServicesDBContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var employees = _context.Employee.ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employee.Add(emp);
                _context.SaveChanges();
                ViewBag.result = "true";
               

            }
            else
            {
                ViewBag.result = "false";
            }
             return View();
        }
        public IActionResult Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var ExistedEmployee = _context.Employee.SingleOrDefault(e => e.EmployeeId == id);
            if(ExistedEmployee==null)
            {
                return NotFound();
            }

            return View(ExistedEmployee);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var EditedEmployee = _context.Employee.SingleOrDefault(e => e.EmployeeId == id);
            if (EditedEmployee == null)
            {
                return NotFound();
            }

            return View(EditedEmployee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee emp)
        {
           // var EditedEmployee = _context.Employee.SingleOrDefault(e => e.EmployeeId == emp.EmployeeId);
           if (ModelState.IsValid)
            {
                _context.Update(emp);
                _context.SaveChanges();
                ViewBag.result = "true";
            }
            else
            {
                ViewBag.result = "false";
            }
            
            return View();
        }

    }
}