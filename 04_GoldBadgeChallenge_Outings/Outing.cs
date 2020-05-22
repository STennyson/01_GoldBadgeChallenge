using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_GoldBadgeChallenge_Outings
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert }
    public class Outing
    {
        public EventType EventType { get; set; }
        public int NumberOfAttendees { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double TotalCostPerPerson { get; set; }
        public double TotalCostOfEvent { get; set; }

        public Outing() { }

        public Outing(
            EventType eventType,
            int numberOfAttendees,
            DateTime dateOfEvent,
            double totalCostPerPerson,
            double totalCostOfEvent
            )
        {
            EventType = eventType;
            NumberOfAttendees = numberOfAttendees;
            DateOfEvent = dateOfEvent;
            TotalCostPerPerson = totalCostPerPerson;
            TotalCostOfEvent = totalCostOfEvent;
        }
    }
}
