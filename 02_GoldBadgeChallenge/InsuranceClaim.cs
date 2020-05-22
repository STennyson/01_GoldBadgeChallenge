using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_GoldBadgeChallenge
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class InsuranceClaim
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public int TotalDays {
            get {
                TimeSpan claimSpan = (DateOfClaim - DateOfIncident);
                double unroundedDays = claimSpan.TotalDays;
                int totalDays = Convert.ToInt32(Math.Ceiling(unroundedDays));
                return totalDays;
            } }

        public bool IsValid
        {
            get
            {
                if (TotalDays <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }

        public InsuranceClaim() { }

        public InsuranceClaim(
            int claimID,
            ClaimType claimType,
            string description,
            double claimAmount,
            DateTime dateOfIncident,
            DateTime dateOfClaim
            )
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

       
    }
}

