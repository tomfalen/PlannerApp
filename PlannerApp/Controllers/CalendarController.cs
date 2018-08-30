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
            int year = DateTime.Now.Year, month = DateTime.Now.Month;
            CalendarViewModel calendarView = new CalendarViewModel()
            {
                CurrentYear = year,
                DayOfWeek = new DateTime(year, month, 1).DayOfWeek,
                Tasks = _context.TaskList.Where(x => x.UserId == _userManager.GetUserId(User)).ToList(),
                DaysNTasksList = new List<DayViewModel>()
            };
            _calendarDaySorter.Sort(calendarView);
            return View(calendarView);
        }
        [HttpPost]
        public IActionResult Index(CalendarViewModel calendarView)
        {
            int selectedMonthId = int.Parse(calendarView.SelectedMonthId);
            calendarView.DayOfWeek = new DateTime(calendarView.CurrentYear, selectedMonthId, 1).DayOfWeek;
            calendarView.Tasks = _context.TaskList.Where(x => x.UserId == _userManager.GetUserId(User)).ToList();
            calendarView.DaysNTasksList = new List<DayViewModel>();
            _calendarDaySorter.Sort(calendarView);
            return View(calendarView);
        }
    }
}
