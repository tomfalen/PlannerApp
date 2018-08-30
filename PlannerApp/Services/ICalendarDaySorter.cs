using PlannerApp.ViewModels;

namespace PlannerApp.Services
{
    public interface ICalendarDaySorter
    {
        CalendarViewModel Sort (CalendarViewModel calendarView);
    }
}
