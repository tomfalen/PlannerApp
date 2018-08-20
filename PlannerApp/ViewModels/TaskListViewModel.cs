using PlannerApp.Models;
using System.Collections.Generic;
using PlannerApp.Enums;

namespace PlannerApp.ViewModels
{
    public class TaskListViewModel
    {
        public List<TaskListModel> TaskList { get; set; }
        public SortOrder SortOrder { get; set; }
        public SortBy SortBy { get; set; }
    }
}
