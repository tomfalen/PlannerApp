using PlannerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApp.ViewModels
{
    public class DayViewModel
    {
        public int Day { get; set; }
        public List<TaskListModel> TaskList { get; set; }
        public bool Picked { get; set; }
    }
}
