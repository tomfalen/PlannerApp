using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlannerApp.Models;
using PlannerApp.Data;
using PlannerApp.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using PlannerApp.Services;

namespace PlannerApp.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICalendarDaySorter _calendarDaySorter;

        public CalendarController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ICalendarDaySorter calendarDaySorter)
        {
            _context = context;
            _userManager = userManager;
            _calendarDaySorter = calendarDaySorter;
            
        }
        public IActionResult Index()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            CalendarViewModel calendarView = new CalendarViewModel()
            {
                CurrentYear = year,
                DayOfWeek = new DateTime(year, month, 1).DayOfWeek,
                Tasks = _context.TaskList.Where(x => x.UserId == _userManager.GetUserId(User)).ToList(),
                DaysNTasksList = new List<DayViewModel>(),
                PickedDate = new DateTime(year, month, 1)
            };
            _calendarDaySorter.Sort(calendarView);
            ViewData["Title"] = "Calendar";
            return View(calendarView);
        }

        [HttpGet]
        public IActionResult ChangeDate(int month, int year)
        {
            CalendarViewModel calendarView = new CalendarViewModel()
            {
                CurrentYear = year,
                DayOfWeek = new DateTime(year, month, 1).DayOfWeek,
                Tasks = _context.TaskList.Where(x => x.UserId == _userManager.GetUserId(User)).ToList(),
                DaysNTasksList = new List<DayViewModel>(),
                PickedDate = new DateTime(year, month, 1),
            };
            _calendarDaySorter.Sort(calendarView);
            ViewData["Title"] = "Calendar";
            return View("Index", calendarView);
        }

        public IActionResult GetCalendarDay(int year, int month, int day)
        {
            DateTime pickedDate = new DateTime(year, month, day);
            var taskList = _context.TaskList.Where(x => x.DueDate.Date == pickedDate.Date && x.UserId == _userManager.GetUserId(User)).ToList();
            return PartialView("CalendarDay", taskList);
        }
    }
}
