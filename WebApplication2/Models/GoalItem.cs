using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    [Serializable]
    public class GoalItem
    {
        [Required(ErrorMessage = "Please, enter the name")]
        [MinLength(3, ErrorMessage = "Minimum length is 3")]
        public string Name { get; set; }

        public double? Progress => CurrentState * 100 / GoalState;
        //calculate value

        [Range(0, double.PositiveInfinity)]
        public double? CurrentState { get; set; }

        [Required(ErrorMessage = "Please enter value for your fucking goal")]
        [Range(0, double.PositiveInfinity)]
        public double? GoalState { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Anhy goal requers the deadline, else this is a fucking useless dream")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DeadLine { get; set; }

        [Required(ErrorMessage = "Do you collect elephants?")]
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