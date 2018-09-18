using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlannerApp.Data;
using PlannerApp.Enums;
using PlannerApp.Models;
using PlannerApp.Services;
using PlannerApp.ViewModels;


namespace PlannerApp.Controllers
{
    public class TaskListController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITaskListSorter _taskListSorter;

        public TaskListController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            ITaskListSorter taskListSorter
        )
        {
            _context = context;
            _userManager = userManager;
            _taskListSorter = taskListSorter;
        }

        public IActionResult Index(SortBy sortBy, SortOrder sortOrder)
        {
            var taskList = from t in _context.TaskList
                           where t.UserId == _userManager.GetUserId(User)
                           select t;
            if (taskList.Any())
            {
                TaskListViewModel taskListView = new TaskListViewModel()
                {
                    TaskList = taskList.ToList(),
                    SortBy = sortBy,
                    SortOrder = sortOrder
                };
                taskListView = _taskListSorter.Sort(taskListView);
                return View(taskListView);
            }
            else
            {
                return RedirectToAction(nameof(AddNew));
            }
        }

        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            TaskListModel task = _context.TaskList.Find(id);
            if (task != null)
            {
                _context.TaskList.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public IActionResult AddNew()
        {
            var priorityList = from Priority p in Enum.GetValues(typeof(Priority))
                               select new
                               {
                                   ID = (int)p,
                                   Name = p.ToString()
                               };
            ViewBag.EnumList = new SelectList(priorityList, "ID", "Name");
            ViewData["Title"] = "Add new task";
            ViewData["Header"] = "Create new task";
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(TaskListModel task)
        {
            if (ModelState.IsValid)
            {
                task.UserId = _userManager.GetUserId(User);
                task.CreatedDate = DateTime.Now;
                _context.Add(task);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["Title"] = "Add new task";
                ViewData["Header"] = "Create new task";
                return View(task);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TaskListModel task = _context.TaskList.Find(id);
            var priorityList = from Priority p in Enum.GetValues(typeof(Priority))
                               select new
                               {
                                   ID = (int)p,
                                   Name = p.ToString()
                               };
            ViewBag.EnumList = new SelectList(priorityList, "ID", "Name");
            ViewData["Title"] = "Edit";
            ViewData["Header"] = "Edit task";
            return View("../TaskList/AddNew", task);
        }

        [HttpPost]
        public IActionResult Edit(TaskListModel task)
        {
            var t = @ViewData["ReturnUrl"];
            if (ModelState.IsValid)
            {
                task.UserId = _userManager.GetUserId(User);
                task.CreatedDate = DateTime.Now;
                _context.Update(task);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["Title"] = "Add new task";
                ViewData["Header"] = "Create new task";
                return View(task);
            }
        }
    }
}
