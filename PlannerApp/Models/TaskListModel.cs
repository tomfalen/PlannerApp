using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlannerApp.Enums;

namespace PlannerApp.Models
{
    public class TaskListModel
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
    }
}
