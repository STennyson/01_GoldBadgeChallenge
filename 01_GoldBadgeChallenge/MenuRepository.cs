using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace _01_GoldBadgeChallenge
{
    public class MenuRepository
    {
        private List<Menu> _menuItems = new List<Menu>();

        //Create
        public bool AddItemToMenu(Menu item)
        {
            int startingCount = _menuItems.Count;

            _menuItems.Add(item);

            bool wasAdded = _menuItems.Count == startingCount + 1;

            return wasAdded;
        }
        
        //Read
        public List<Menu> ShowMenuItems()
        {
            return _menuItems;
        }

        public Menu ShowItemByMealNumber(int mealNumber)
        {
            foreach (Menu item in _menuItems)
            {
                if (item.MealNumber == mealNumber)
                {
                    return item;
                }
            }
            return null;
        }

        public Menu ShowItemByMealName(string mealName)
        {
            foreach (Menu item in _menuItems)
            {
                if (item.MealName.ToLower() == mealName.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        

        //Delete
        public bool RemoveItemByMealNumber(int mealNumber)
        {
            Menu item = ShowItemByMealNumber(mealNumber);

            if (item == null)
            {
                Console.WriteLine("There is no item on the menu with that meal number.");
                return false;
            }
            else
            {
                _menuItems.Remove(item);
                return true;
            }
        }

        public bool RemoveItemByMealName(string mealName)
        {
            Menu item = ShowItemByMealName(mealName);

            if (item == null)
            {
                Console.WriteLine("There is no item on the menu with that meal name.");
                return false;
            }
            else
            {
                _menuItems.Remove(item);
                return true;
            }
        }
    }
}
