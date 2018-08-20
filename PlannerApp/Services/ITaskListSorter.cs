using PlannerApp.Models;
using PlannerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApp.Services
{
    public interface ITaskListSorter
    {
        TaskListViewModel Sort(TaskListViewModel taskListView);
    }
}
