using Microsoft.AspNetCore.Mvc.Rendering;
using PlannerApp.Models;
using System.Collections.Generic;

namespace PlannerApp.ViewModels
{
    public class CalendarViewModel
    {
        public string Title { get; set; }
        public List<SelectListItem> AllMonths { get; set; }
        public string CurrentYear { get; set; }
        public List<TaskListModel> Tasks { get; set; }
    }
}
