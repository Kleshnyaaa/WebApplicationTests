using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Serializable]
    public class GoalItem
    {
        public string Name { get; set; }

        public double Progress => CurrentState * 100 / GoalState;
        //calculate value
        public double CurrentState { get; set; }
        public double GoalState { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public string UnitOfMeasure { get; set; }

        public GoalItem(string name, double goalState, DateTime deadLine, string unitOfMeasure,
            double currentState = 0.0, DateTime startDate = default(DateTime))
        {
            Name = name;
            CurrentState = currentState;
            GoalState = goalState;
            StartDate = startDate == default (DateTime) ? DateTime.Now : startDate;
            DeadLine = deadLine;
            UnitOfMeasure = unitOfMeasure;
        }

        public GoalItem() //: this("no name", 0.0, DateTime.MaxValue, "N/A")
        {
            
        }
    }
}