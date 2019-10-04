using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge_Repository
{
    public enum OutingType { Golf = 1, Bowling, AmusementPark, Concert }
    public class OutingContent
    {
        public OutingContent(int numberOfAttendees, DateTime dateOfEvent, OutingType outingType, decimal costPerPerson, decimal totalCostOfOutings)
        {
            NumberOfAttendees = numberOfAttendees;
            DateOfEvent = dateOfEvent;
            OutingType = outingType;
            CostPerPerson = costPerPerson;
            TotalCostOfOutings = totalCostOfOutings;
        }

        public OutingContent()
        {

        }

        public int NumberOfAttendees { get; set; }
        public DateTime DateOfEvent { get; set; }
        public OutingType OutingType { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCostOfOutings { get; set; }


        
    }
}
