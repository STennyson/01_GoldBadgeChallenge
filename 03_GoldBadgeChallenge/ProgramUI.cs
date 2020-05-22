using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_GoldBadgeChallenge
{
    public class ProgramUI
    {

        private readonly BadgeRepository _repo = new BadgeRepository();


        public void Run()
        {
            SeedBadgeDictionary();
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
                    "1. Create a new badge:\n" +
                    "2. Update doors for a specific badge:\n" +
                    "3. Show all badge numbers and door access:\n" +
                    "4. Exit"
                    );

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        //Create a new badge
                        CreateANewBadge();
                        Console.ReadKey();
                        break;
                    case "2":
                        //Update doors on an existing badge
                        UpdateDoors();
                        Console.ReadKey();
                        break;
                    case "3":
                        //Show all doors and access
                        ShowAll();
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

        private void CreateANewBadge()
        {
            List<string> newDoors = new List<string>();
            Console.Clear();
            Console.WriteLine("Enter a new Badge ID number:");
            int badgeID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What door will it have access to?");
            bool doorSelection = true;
            while (doorSelection)
            {
                    string newDoor = Console.ReadLine();
                    newDoors.Add(newDoor);

                    Console.WriteLine("Would you like to add another door? y/n");
                    string addAnother = Console.ReadLine().ToLower();
                    if (addAnother == "y")
                {
                    Console.WriteLine("What door will it have access to?");
                    string anotherDoor = Console.ReadLine();
                    newDoors.Add(anotherDoor);
                }
                    else
                {
                    Console.WriteLine("All finished.");
                    doorSelection = false;
                }
                
            }
            Badge newBadge = new Badge(badgeID, newDoors);
            _repo.CreateBadge(newBadge.BadgeID, newBadge.DoorNames);
            Console.WriteLine("New badge added!");
            Console.ReadKey();

        }

        private void UpdateDoors()
        {
            Console.Clear();
            Console.WriteLine("What badge number would you like to update?");
            Console.WriteLine($"{ "Badge ID", -8} \nAccessible Doors\n");
            Dictionary<int, List<string>> listOfBadges = _repo.ShowAllBadges();
            foreach (int badgeID in listOfBadges.Keys)
            {
                DisplayContent(badgeID, listOfBadges[badgeID]);
            }

            int selectedBadgeID = Convert.ToInt32(Console.ReadLine());
            List<string> doors = _repo.ShowBadgeByID(selectedBadgeID);
            if (doors == null)
            {
                Console.WriteLine("Try again.");
                RunMenu();
            }
            else if (doors.Count == 0)
            {
                Console.WriteLine("Returning to main menu..");
                Thread.Sleep(2500);
                RunMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"#{selectedBadgeID,-8}");

                foreach (string doorcode in doors)
                {
                    Console.WriteLine($"{doorcode}  ");
                }

                Console.WriteLine("Select an option:\n" +
                    "1. Add a door.\n" +
                    "2. Remove a door.\n");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        AddDoor(selectedBadgeID, doors);
                        break;
                    case "2":
                        DeleteDoor(selectedBadgeID, doors);
                        break;
                    default:
                        Console.WriteLine("That's not an option.");
                        Thread.Sleep(2000);
                        RunMenu();
                        break;
                }
            }
        }

        private void AddDoor(int selectedBadgeID, List<string> doors)
        {
            Console.WriteLine("Enter a door to add:");
            string doorInput = Console.ReadLine();
            doors.Add(doorInput);
            _repo.UpdateBadge(selectedBadgeID, doors);
        }

        private void DeleteDoor(int selectedBadgeID, List<string> doors)
        {
            Console.WriteLine("Enter a door to remove:");
            string doorInput = Console.ReadLine();
            doors.Remove(doorInput);
            _repo.UpdateBadge(selectedBadgeID, doors);
        }
        private void ShowAll()
        {
            Console.Clear();
            Console.WriteLine("Badge#\nDoor Access\n");

            Dictionary<int, List<string>> badgeList = _repo.ShowAllBadges();
            foreach (int badgeID in badgeList.Keys)
            {
                DisplayContent(badgeID, badgeList[badgeID]);
            }

        }

        private void DisplayContent(int badgeID, List<string> doors)
        {
            Console.WriteLine($"#{badgeID, -8}");
            foreach (string doorCode in doors)
            {
                Console.WriteLine($"{doorCode}  ");
            }
        }


        private void SeedBadgeDictionary()
        {
            Badge badgeOne = new Badge(1357, new List<string>() { "2A", "3B", "4C" } );
            Badge badgeTwo = new Badge(5803, new List<string>() { "1A", "3B", "5E" });
            Badge badgeThree = new Badge(7621, new List<string>() { "23A", "13B", "9C", "Records" });
            _repo.CreateBadge(badgeOne.BadgeID, badgeOne.DoorNames);
            _repo.CreateBadge(badgeTwo.BadgeID, badgeTwo.DoorNames);
            _repo.CreateBadge(badgeThree.BadgeID, badgeThree.DoorNames);
        }
    }
}

