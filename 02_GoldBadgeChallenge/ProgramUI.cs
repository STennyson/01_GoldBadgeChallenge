using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_GoldBadgeChallenge
{
    public class ProgramUI
    {
        private readonly ClaimsRepository _repo = new ClaimsRepository();
        DateTime date1 = new DateTime(2019, 4, 5);
        DateTime date2 = new DateTime(2019, 4, 22);
        DateTime date3 = new DateTime(2019, 7, 9);
        DateTime date4 = new DateTime(2019, 8, 14);
        DateTime date5 = new DateTime(2019, 11, 2);
        DateTime date6 = new DateTime(2019, 11, 29);

        public void Run()
        {
            SeedClaimsQueue();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine(
                    "What would you like to do?\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit"
                    );

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        //Show all claims
                        ShowAllClaims();
                        Console.ReadKey();
                        break;
                    case "2":
                        //Take care of next claim
                        TakeCareOfNextClaim();
                        Console.ReadKey();
                        break;
                    case "3":
                        //Enter new claim
                        EnterNewClaim();
                        Console.ReadKey();
                        break;
                    case "4":
                        //Exit
                        continueToRun = false;
                        Console.WriteLine("Thank you. Goodbye.");
                        Thread.Sleep(3000);
                        break;

                    default:
                        //Invalid input
                        Console.WriteLine("Please enter a valid option.\n");
                        Console.ReadKey();
                        break;

                }

            }
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Console.WriteLine("Enter a new Claim ID number:");
            int claimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What type of claim is this:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n"
                );
            string typeInput = Console.ReadLine();
            int typeNumber = Convert.ToInt32(typeInput);

            ClaimType type = (ClaimType)typeNumber;

            Console.WriteLine("Enter a description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter a claim amount:");
            double claimAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the date of the incident:");
            DateTime incidentDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter the date of the claim:");
            DateTime claimDate = Convert.ToDateTime(Console.ReadLine());

            InsuranceClaim newClaim = new InsuranceClaim(claimID, type, description, claimAmount, incidentDate, claimDate);
            _repo.AddClaimToQueue(newClaim);
            Console.WriteLine("New claim added!");
            Console.ReadKey();
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here is the next claim in the queue:");

            _repo.ProcessClaim();

            Thread.Sleep(2000);
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "y":
                case "yes":
                case "Yes":
                case "Y":
                case "YES":
                    _repo.Dequeue();
                    break;
                case "n":
                case "no":
                case "No":
                case "N":
                case "NO":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.\n");
                    Console.ReadKey();
                    break;
            }
        }

        public void ShowAllClaims()
        {
            Console.Clear();
            Console.WriteLine($"{ "ID", -4} {"Type", -5} {"Description", -20} {"Amount", -6} {"Incident Date", -10} {"Claim Date", -10} {"IsValid"}");
            
            Queue<InsuranceClaim> claimsQueue = _repo.SeeAllClaims();
            foreach (InsuranceClaim claim in claimsQueue)
            {
                ShowClaim(claim);
            }
        }

        public void ShowClaim(InsuranceClaim claim)
        {
            Console.WriteLine($"{claim.ClaimID, -3}  {claim.ClaimType, -5} {claim.Description, -19}  ${claim.ClaimAmount, -4}  {claim.DateOfIncident.ToString("MM/dd/yyyy"), -13} {claim.DateOfClaim.ToString("MM/dd/yyyy"), -10} {claim.IsValid}");
        }

        private void SeedClaimsQueue()
        {
            InsuranceClaim claimOne = new InsuranceClaim(1, ClaimType.Car, "Traffic collision", 1500, date1, date2);
            InsuranceClaim claimTwo = new InsuranceClaim(2, ClaimType.Home, "House fire", 9000, date3, date4);
            InsuranceClaim claimThree = new InsuranceClaim(3, ClaimType.Theft, "iPad stolen", 600, date5, date6);
            _repo.EnterClaim(claimOne);
            _repo.EnterClaim(claimTwo);
            _repo.EnterClaim(claimThree);

        }
    }
}
