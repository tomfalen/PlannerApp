using Microsoft.AspNetCore.Mvc.Rendering;
using PlannerApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PlannerApp.ViewModels
{
    public class CalendarViewModel
    {
        public string Title { get; set; }
        public DateTime PickedDate { get; set; }
        public int SelectedMonthDay { get; set; }
        public int PreviousMonthDays
        {
            get
            {
                return DateTime.DaysInMonth(PreviousYear, PreviousMonth);
            }
        }
        public DayOfWeek DayOfWeek { get; set; }
        public List<TaskListModel> Tasks { get; set; }
        public List<DayViewModel> DaysNTasksList { get; set; }
        public int PreviousMonth
        {
            get
            {
                return CurrentMonth == 1 ? 12 : CurrentMonth - 1;
            }
        }
        public int CurrentMonth
        {
            get
            {
                return PickedDate.Month;
            }
        }
        public int FurtherMonth
        {
            get
            {
                return CurrentMonth == 12 ? 1 : CurrentMonth + 1;
            }
        }
        public int PreviousYear
        {
            get
            {
                return CurrentMonth == 1 ? CurrentYear - 1 : CurrentYear;
            }
        }
        public int CurrentYear { get; set; }
        public int FurtherYear
        {
            get
            {
                return CurrentMonth == 12 ? CurrentYear + 1 : CurrentYear;
            }
        }
    }
}
