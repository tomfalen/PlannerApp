using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlannerApp.Models;
using PlannerApp.Data;
using PlannerApp.ViewModels;

namespace PlannerApp.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CalendarController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewBag.Date = DateTime.Now;
            return View();
        }
        [HttpPost]
        public IActionResult Index(int month, int year)
        {
            ViewBag.Date = new DateTime(year, month, 1);
            ViewBag.DayOfWeek = ViewBag.Date.DayOfWeek;
            ViewBag.Days = DateTime.DaysInMonth(ViewBag.Date.Year, ViewBag.Date.Month);
            ViewBag.PreviousMonthDays = DateTime.DaysInMonth(ViewBag.Date.Year, ViewBag.Date.Month - 1);
            var viewModel = new CalendarViewModel
            {
                
            };
            return View();
        }
    }
}
