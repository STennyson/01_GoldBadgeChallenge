using System;
using System.Collections.Generic;
using _03_GoldBadgeChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgeTests
{
    [TestClass]
    public class BadgeTests
    {
        private readonly BadgeRepository _repo = new BadgeRepository();

        [TestInitialize]

        public void SeedBadgeDictionary()
        {
            Badge badgeOne = new Badge(1357, new List<string>() { "2A", "3B", "4C" });
            Badge badgeTwo = new Badge(5803, new List<string>() { "1A", "3B", "5E" });
            Badge badgeThree = new Badge(7621, new List<string>() { "23A", "13B", "9C", "Records" });
            _repo.CreateBadge(badgeOne.BadgeID, badgeOne.DoorNames);
            _repo.CreateBadge(badgeTwo.BadgeID, badgeTwo.DoorNames);
            _repo.CreateBadge(badgeThree.BadgeID, badgeThree.DoorNames);
        }

        [TestMethod]
        public void AddBadgeGetCount()
        {
            int expected = 3;
            int actual = _repo.ShowAllBadges().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddBadgeCountShouldIncrease()
        {
            Badge badgeFour = new Badge(5813, new List<string>() { "6A", "9B", "10D" });
            bool wasAdded = _repo.CreateNewBadge(badgeFour.BadgeID, badgeFour.DoorNames);
            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void SeeClaimShouldShowClaim()
        {
            Badge badgeFour = new Badge(5813, new List<string>() { "6A", "9B", "10D" });
            _repo.CreateNewBadge(badgeFour.BadgeID, badgeFour.DoorNames);

            List<string> testBadge = _repo.ShowBadgeByID(5813);

            Assert.AreEqual(badgeFour.DoorNames, testBadge);

        }

    }
}
