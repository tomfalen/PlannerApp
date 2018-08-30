using PlannerApp.ViewModels;

namespace PlannerApp.Services
{
    public interface ITaskListSorter
    {
        TaskListViewModel Sort(TaskListViewModel taskListView);
    }
}
