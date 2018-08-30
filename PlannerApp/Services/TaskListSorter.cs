using PlannerApp.ViewModels;
using System.Linq;
using PlannerApp.Enums;

namespace PlannerApp.Services
{
    public class TaskListSorter : ITaskListSorter
    {
        public TaskListViewModel Sort(TaskListViewModel taskListView)
        {
            switch (taskListView.SortBy)
            {
                case SortBy.Description:
                    if (taskListView.SortOrder.Equals(SortOrder.Descending))
                    {
                        taskListView.TaskList = taskListView.TaskList.OrderByDescending(s => s.Description).ToList();
                    }
                    else
                    {
                        taskListView.TaskList = taskListView.TaskList.OrderBy(s => s.Description).ToList();
                    }
                    break;
                case SortBy.CreatedDate:
                    if (taskListView.SortOrder.Equals(SortOrder.Descending))
                    {
                        taskListView.TaskList = taskListView.TaskList.OrderByDescending(s => s.CreatedDate).ToList();
                    }
                    else
                    {
                        taskListView.TaskList = taskListView.TaskList.OrderBy(s => s.CreatedDate).ToList();
                    }
                    break;
                case SortBy.DueDate:
                    if (taskListView.SortOrder.Equals(SortOrder.Descending))
                    {
                        taskListView.TaskList = taskListView.TaskList.OrderByDescending(s => s.DueDate).ToList();
                    }
                    else
                    {
                        taskListView.TaskList = taskListView.TaskList.OrderBy(s => s.DueDate).ToList();
                    }
                    break;
                case SortBy.Priority:
                    if (taskListView.SortOrder.Equals(SortOrder.Descending))
                    {
                        taskListView.TaskList = taskListView.TaskList.OrderByDescending(s => s.Priority).ToList();
                    }
                    else
                    {
                        taskListView.TaskList = taskListView.TaskList.OrderBy(s => s.Priority).ToList();
                    }
                    break;
            }
            return taskListView;
        }
    }
}
