using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerApp.Data;
using PlannerApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlannerApp.Controllers
{
    public class TaskListController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TaskListController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
                    //if (sortOrder.Equals(CurrentSort))  
                    //    employees = db.Employees.OrderByDescending
                    //            (m => m.Name).ToPagedList(pageIndex, pageSize);  
                    //else  
                    //    employees = db.Employees.OrderBy
                    //            (m => m.Name).ToPagedList(pageIndex, pageSize);  
                    //break;  
        public IActionResult Index(string sortOrder, string currentSort)
        {
            var taskList = from t in _context.TaskList
                           select t;
            if (taskList.Any())
            {
                ViewBag.CurrentSort = sortOrder;
                sortOrder = String.IsNullOrEmpty(sortOrder) ? "Description" : sortOrder;
                switch (sortOrder)
                {
                    case "Description":
                        if (sortOrder.Equals(currentSort))
                        {
                            taskList = taskList.OrderByDescending(s => s.Description);
                        }
                        else
                        {
                            taskList = taskList.OrderBy(s => s.Description);
                        }
                        break;
                    case "CreatedDate":
                        if (sortOrder.Equals(currentSort))
                        {
                            taskList = taskList.OrderByDescending(s => s.CreatedDate);
                        }
                        else
                        {
                            taskList = taskList.OrderBy(s => s.CreatedDate);
                        }
                        break;
                    case "DueDate":
                        if (sortOrder.Equals(currentSort))
                        {
                            taskList = taskList.OrderByDescending(s => s.DueDate);
                        }
                        else
                        {
                            taskList = taskList.OrderBy(s => s.DueDate);
                        }
                        break;
                    case "Priority":
                        if (sortOrder.Equals(currentSort))
                        {
                            taskList = taskList.OrderByDescending(s => s.Priority);
                        }
                        else
                        {
                            taskList = taskList.OrderBy(s => s.Priority);
                        }
                        break;
                }
                return View(taskList.ToList());
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
                return View(task);
            }
        }
    }
}
