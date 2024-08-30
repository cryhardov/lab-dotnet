using cryhardov.TaskPlanner.Domain.Models;
using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryhardov.TaskPlanner.Domain.Logic
{
public class SimpleTaskPlanner
{
public WorkItem[] CreatePlan(WorkItem[] workItems)
        {
            return workItems
                .OrderByDescending(w => w.Priority)
                .ThenBy(w => w.DueDate)              
                .ThenBy(w => w.Title)                
                .ToArray();
        }
}
}