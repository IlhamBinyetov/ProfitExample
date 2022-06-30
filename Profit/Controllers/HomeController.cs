using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Profit.Data;
using Profit.Models;
using Profit.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Profit.Controllers
{
    public class HomeController : Controller
    {
       

        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(HomeViewModel homeVM, int page = 1)
        {
            if (page <= 0)
            {
                page = 1;
            }

            var students = _context.Students.AsQueryable();

            string search = homeVM.Pin;

            if (!string.IsNullOrWhiteSpace(search))
                students = students.Where(x => x.Pin.Equals(search));

            ViewBag.TotalPage = Math.Ceiling(students.Count() / 10m);
            ViewBag.SelectedPage = page;


            students = students.Skip((page - 1) * 10).Take(10);

           

           homeVM = new HomeViewModel
            {
                Students = students.ToList()
            };

            return View(homeVM);
        }

  
    }
}
