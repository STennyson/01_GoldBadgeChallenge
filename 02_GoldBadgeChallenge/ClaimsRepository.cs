using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _02_GoldBadgeChallenge
{
    public class ClaimsRepository
    {
        
        public Queue<InsuranceClaim> _claimsQueue = new Queue<InsuranceClaim>();
        
        //Create
        public bool AddClaimToQueue(InsuranceClaim oneClaim)
        {
            int startingCount = _claimsQueue.Count;

            _claimsQueue.Enqueue(oneClaim);

            bool wasAdded = _claimsQueue.Count == startingCount + 1;

            return wasAdded;
        }
        
        //Read
        public Queue<InsuranceClaim> SeeAllClaims() 
        {
            return _claimsQueue;
        }


        public InsuranceClaim ChooseClaimByNumber(int claimNumber)
        {
            foreach (InsuranceClaim claim in _claimsQueue)
            {
                if (claim.ClaimID == claimNumber)
                {
                    return claim;
                }

            }
            return null;
        }

        

        public void ProcessClaim()
        {
            InsuranceClaim peek = _claimsQueue.Peek();
            Console.WriteLine(
                $"ClaimID:{peek.ClaimID}\n" +
                $"Type:{peek.ClaimType}\n" +
                $"Description:{peek.Description}\n" +
                $"Amount:${peek.ClaimAmount}\n" +
                $"DateOfIncident:{peek.DateOfIncident.ToString("MM/dd/yyyy")}\n" +
                $"DateOfClaim:{peek.DateOfClaim.ToString("MM/dd/yyyy")}\n" +
                $"IsValid:{peek.IsValid}" );
        }

        //Delete
        public void Dequeue()
        {
            _claimsQueue.Dequeue();
        }
        
        public void EnterClaim(InsuranceClaim newClaim)
        {
            _claimsQueue.Enqueue(newClaim);
        }

        





    }
}
