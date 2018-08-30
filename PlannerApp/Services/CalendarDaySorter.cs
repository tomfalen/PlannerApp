using System;
using System.Collections.Generic;
using System.Linq;
using PlannerApp.ViewModels;

namespace PlannerApp.Services
{
    public class CalendarDaySorter : ICalendarDaySorter
    {
        public CalendarViewModel Sort(CalendarViewModel calendarView)
        {
            //int currentMonth = calendarView.SelectedMonthId != null ? int.Parse(calendarView.SelectedMonthId) : 1;
            int weeks = 0;
            int firstDay = (int)calendarView.DayOfWeek;
            int lastDay = 0;
            int previousDay = 0;
            int currentMonthDay = 0;
            int currentMonthDays = DateTime.DaysInMonth(calendarView.CurrentYear, calendarView.CurrentMonth);
            int furtherMonthDay = 0;
            while (weeks != 5)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (weeks == 0)
                    {
                        if(previousDay != calendarView.PreviousMonthDays)
                        {
                            if (firstDay == 0)
                            {
                                if (i != 6)
                                {
                                    previousDay = calendarView.PreviousMonthDays - 5 + i;
                                }
                                else
                                {
                                    previousDay = 1;
                                }
                            }
                            else if (firstDay == 1)
                            {
                                previousDay = i + 1;
                            }
                            else
                            {
                                previousDay = calendarView.PreviousMonthDays - firstDay + i + 2;
                            }
                            AddDaysWithTasks(calendarView, previousDay, calendarView.PreviousMonth,calendarView.PreviousYear);
                        }
                        else
                        {
                            AddDaysWithTasks(calendarView, ++currentMonthDay, calendarView.CurrentMonth, calendarView.CurrentYear);
                        }
                    }
                    else if(lastDay < currentMonthDays)
                    {
                        AddDaysWithTasks(calendarView, ++lastDay, calendarView.CurrentMonth, calendarView.CurrentYear);
                    }
                    else
                    {
                        AddDaysWithTasks(calendarView, ++furtherMonthDay, calendarView.FurtherMonth, calendarView.FurtherMonth);
                    }

                    lastDay = calendarView.DaysNTasksList.Last().Day;
                }
                weeks++;
            }

            return calendarView;
        }

        private static void AddDaysWithTasks(CalendarViewModel calendarView, int day, int month, int year)
        {
                DateTime currentDate = new DateTime(year, month, day);
                var tasks = calendarView.Tasks.Where(x => x.DueDate.Date == currentDate.Date).ToList();
                calendarView.DaysNTasksList.Add(new DayViewModel { Day = day, TaskList = tasks });
        }
    }
}
