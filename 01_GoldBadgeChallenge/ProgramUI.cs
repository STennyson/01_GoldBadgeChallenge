using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_GoldBadgeChallenge
{
    public class ProgramUI
    {
        private readonly MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            SeedMenuList();
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
                    "1. Receive a list of all items on the menu\n" +
                    "2. Find a menu item by meal number\n" +
                    "3. Find a menu item by meal name\n" +
                    "4. Add an item to the menu\n" +
                    "5. Remove an item from the menu by meal name\n" +
                    "6. Remove an item from the menu by meal number\n" +
                    "7. Exit"
                    );

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        //Show all items
                        ShowAllItems();
                        Console.ReadKey();
                        break;
                    case "2":
                        //Find by number
                        ShowItemByMealNumber();
                        Console.ReadKey();
                        break;
                    case "3":
                        //Find by name
                        ShowItemByMealName();
                        Console.ReadKey();
                        break;
                    case "4":
                        //Add an item
                        AddNewItemToMenu();
                        break;
                    case "5":
                        //Remove an item by name
                        RemoveItemFromMenuByName();
                        break;
                    case "6":
                        //Remove an item by number
                        RemoveItemFromMenuByNumber();
                        break;
                    case "7":
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

        private bool RemoveItemFromMenuByName()
        {
            Console.Clear();
            Console.WriteLine("Which item would you like to remove? Enter a meal name:");
            string mealName = Console.ReadLine();

            Menu item = _repo.ShowItemByMealName(mealName);

            if (item == null)
            {
                Console.WriteLine("There are no menu items under that name.");
                return false;
            }
            else
            {
                _repo.RemoveItemByMealName(mealName);
                Console.WriteLine("Item deleted.");
                Console.ReadKey();
                return true;
            }
            
        }

        private bool RemoveItemFromMenuByNumber()
        {
            Console.Clear();
            Console.WriteLine("Which item would you like to remove? Enter a meal number:");
            int mealNumber = Convert.ToInt32(Console.ReadLine());

            Menu item = _repo.ShowItemByMealNumber(mealNumber);

            if (item == null)
            {
                Console.WriteLine("There are no menu items under that number.");
                return false;
            }
            else
            {
                _repo.RemoveItemByMealNumber(mealNumber);
                Console.WriteLine("Item deleted.");
                Console.ReadKey();
                return true;
            }

        }

        private void AddNewItemToMenu()
        {
            Console.Clear();
            Console.WriteLine("Enter a meal number:");
            int mealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a meal name:");
            string mealName = Console.ReadLine();

            Console.WriteLine("Enter a description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the ingredients:");
            string ingredient = Console.ReadLine();
            List<string> ingredientList = new List<string>();
            ingredientList.Add(ingredient);

            Console.WriteLine("Enter a price:");
            double price = Convert.ToDouble(Console.ReadLine());

            Menu newItem = new Menu(mealNumber, mealName, description, ingredientList, price);
            _repo.AddItemToMenu(newItem);
            Console.WriteLine("New item added!");
            Console.ReadKey();

        }

        public void ShowItemByMealNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter a meal number");
            int mealNumber = Convert.ToInt32(Console.ReadLine());

            Menu item = _repo.ShowItemByMealNumber(mealNumber);

            if (item == null)
            {
                Console.WriteLine("No item found with that number.");
            }
            else
            {
                ShowItem(item);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        public void ShowItemByMealName()
        {
            Console.Clear();
            Console.WriteLine("Enter a meal name");
            string mealName = Console.ReadLine();

            Menu item = _repo.ShowItemByMealName(mealName);

            if (item == null)
            {
                Console.WriteLine("No item found with that name.");
            }
            else
            {
                ShowItem(item);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void ShowAllItems()
        {
            Console.Clear();
            List<Menu> listOfItems = _repo.ShowMenuItems();

            foreach (Menu item in listOfItems)
            {
                ShowItem(item);
            }
        }

        public void ShowItem(Menu item)
        {
            Console.WriteLine($"{item.MealNumber} - {item.MealName} - {item.Description} - ${item.Price}");
        }

        private void SeedMenuList()
        {
            List<string> testIngredients = new List<string> { "ingredient", "new ingredient" };
            Menu hotTea = new Menu(5, "Hot Tea", "Tea leaves steeped in hot water.", testIngredients, 1.99);
            Menu oatmeal = new Menu(6, "Oatmeal", "Steel cut oats served with strawberries and warm milk.", testIngredients, 4.99);
            Menu granola = new Menu(7, "Granola", "Housemade granola with fruit and milk.", testIngredients, 4.99);
            Menu frenchToast = new Menu(8, "French Toast", "Delicious French Toast with fresh berries and syrup.", testIngredients, 7.99);
            _repo.AddItemToMenu(hotTea);
            _repo.AddItemToMenu(oatmeal);
            _repo.AddItemToMenu(granola);
            _repo.AddItemToMenu(frenchToast);

        }
    }
}
