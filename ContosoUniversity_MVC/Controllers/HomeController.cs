using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity_MVC.Models;
using ContosoUniversity_MVC.Data;
using ContosoUniversity_MVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext context;

        public HomeController(SchoolContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            var data = from s in context.Students
                       group s by s.EnrollmentDate into dateGroup
                       select new EnrollmentDateGroup()
                       {
                           EnrollmentDate = dateGroup.Key,
                           StudentCount = dateGroup.Count()
                       };

            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
