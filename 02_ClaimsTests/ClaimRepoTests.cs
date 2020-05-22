using System;
using System.Security.Claims;
using _02_GoldBadgeChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsTests
{
    [TestClass]
    public class ClaimsRepositoryTests
    {
        public ClaimsRepository _repo = new ClaimsRepository();

        public DateTime date1 = new DateTime(2019, 4, 5);
        public DateTime date2 = new DateTime(2019, 4, 22);
        public DateTime date3 = new DateTime(2019, 7, 9);
        public DateTime date4 = new DateTime(2019, 8, 14);
        public DateTime date5 = new DateTime(2019, 11, 2);
        public DateTime date6 = new DateTime(2019, 11, 29);

        [TestInitialize]
        
        public void SeedClaimsQueue()
        {
            InsuranceClaim claimOne = new InsuranceClaim(1, ClaimType.Car, "Traffic collision", 1500, date1, date2);
            InsuranceClaim claimTwo = new InsuranceClaim(2, ClaimType.Home, "House fire", 9000, date3, date4);
            InsuranceClaim claimThree = new InsuranceClaim(3, ClaimType.Theft, "iPad stolen", 600, date5, date6);
            _repo.EnterClaim(claimOne);
            _repo.EnterClaim(claimTwo);
            _repo.EnterClaim(claimThree);

        }

        [TestMethod]
        public void AddClaimGetCount()
        {
            int expected = 3;
            int actual = _repo.SeeAllClaims().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddClaimCountShouldIncrease()
        {
            InsuranceClaim claimFour = new InsuranceClaim(4, ClaimType.Home, "Water main break", 3600, date3, date5);
            bool wasAdded = _repo.AddClaimToQueue(claimFour);
            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void RemoveClaimShouldReduceList()
        {
            _repo.Dequeue();

            int expected = 2;
            int actual = _repo.SeeAllClaims().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SeeClaimShouldShowClaim()
        {
            InsuranceClaim newClaim = new InsuranceClaim(4, ClaimType.Car, "Stolen car", 5000, date3, date6);
            _repo.AddClaimToQueue(newClaim);

            InsuranceClaim testClaim = _repo.ChooseClaimByNumber(4);

            Assert.AreEqual(testClaim, newClaim);

        }

        [TestMethod]
        public void DoesIsValidWork()
        {
            // Arrange
            InsuranceClaim testClaim = new InsuranceClaim();

            // Act
            testClaim.DateOfIncident = date3;
            testClaim.DateOfClaim = date5;

            bool expected = false;
            bool actual = testClaim.IsValid;

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
