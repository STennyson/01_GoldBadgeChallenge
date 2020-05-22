using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using _01_GoldBadgeChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTests
{
    [TestClass]
    public class MenuTests
    {
        private MenuRepository _repo = new MenuRepository();
        [TestInitialize]
        
        public void SeedRepo()
        {
            List<string> testIngredients = new List<string> { "ingredient", "new ingredient" };
            Menu clubSandwich = new Menu(1, "Club Sandwich", "Your standard club, only better!", testIngredients, 8.99);
            Menu bLTG = new Menu(2, "BLTG", "A BLT with Gouda!", testIngredients, 7.99);
            Menu bagel = new Menu(3, "Bagel", "A Bagel with topping of your choice.", testIngredients, 3.99);

            _repo.AddItemToMenu(clubSandwich);
            _repo.AddItemToMenu(bLTG);
            _repo.AddItemToMenu(bagel);
        }

        [TestMethod]
        public void AddItemGetCount()
        { 
  
            int expected = 3;
            int actual = _repo.ShowMenuItems().Count;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void AddItemCountShouldIncrease()
        {
            List<string> testIngredients = new List<string> { "ingredient", "new ingredient" };
            Menu coffee = new Menu(24, "Coffee", "Just a cup of coffee", testIngredients, 1.99);
            bool wasAdded = _repo.AddItemToMenu(coffee);
            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void ShowMenuItemByMenuNumberShouldShowMenuItem()
        {
            List<string> testIngredients = new List<string> { "ingredient", "new ingredient" };
            Menu coffee = new Menu(24, "Coffee", "Just a cup of coffee", testIngredients, 1.99);
            _repo.AddItemToMenu(coffee);

            Menu testItem = _repo.ShowItemByMealNumber(24);

            Assert.AreEqual(coffee, testItem);

        }

        [TestMethod]
        public void ShowMenuItemByMenuNameShouldShowMenuItem()
        {
            List<string> testIngredients = new List<string> { "ingredient", "new ingredient" };
            Menu coffee = new Menu(24, "Coffee", "Just a cup of coffee", testIngredients, 1.99);
            _repo.AddItemToMenu(coffee);

            Menu testItem = _repo.ShowItemByMealName("coffee");

            Assert.AreEqual(coffee, testItem);

        }

        [TestMethod]
        public void RemoveItemByMealNameShouldReduceList()
        {
            _repo.RemoveItemByMealName("bLTG");

            int expected = 2;
            int actual = _repo.ShowMenuItems().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveItemByMealNumberShouldReduceList()
        {
            
            _repo.RemoveItemByMealNumber(1);

            int expected = 2;
            int actual = _repo.ShowMenuItems().Count;

            Assert.AreEqual(expected, actual);

        }
    }
}
