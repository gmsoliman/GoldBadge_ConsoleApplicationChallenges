using _03_BadgesClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesProgram
{
    public class BadgesUI
    {
        private readonly BadgesRepo _badgesRepo = new BadgesRepo();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        private void SeedContent()
        {
            Badges badgeOne = new Badges(12345, new List<string> { "A5", "A7" });
            Badges badgeTwo = new Badges(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badges badgeThree = new Badges(32345, new List<string> { "A4", "A5" });

            _badgesRepo.AddBadgeToDictionary(badgeOne);
            _badgesRepo.AddBadgeToDictionary(badgeTwo);
            _badgesRepo.AddBadgeToDictionary(badgeThree);
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do? \n" +
                    "1) Add a badge \n" +
                    "2) Edit a badge \n" +
                    "3) List all badges \n" +
                    "4) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    default:
                        break;
                }
            }
        }
        private void AddBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge?");
            int badgeID = int.Parse(Console.ReadLine());

            List<string> doorAccess = new List<string>();
            Console.WriteLine($"\nList a door that Badge #{badgeID} needs access to:");
            doorAccess.Add(Console.ReadLine());
            bool continueDoorAdd = true;
            while (continueDoorAdd)
            {
                Console.WriteLine("\nAny other doors(y/n)?");
                var userResponse = Console.ReadLine();
                switch (userResponse)
                {
                    case "y":
                        Console.WriteLine($"\nList another door that Badge #{badgeID} needs access to:");
                        doorAccess.Add(Console.ReadLine());
                        break;
                    case "n":
                        continueDoorAdd = false;
                        break;
                    default:
                        break;
                }
            }
            Badges newBadge = new Badges(badgeID, doorAccess);
            _badgesRepo.AddBadgeToDictionary(newBadge);
        }
        private void AddDoorAccess(int badgeID)
        {
            Dictionary<int, List<string>> badgeDictionary = _badgesRepo.GetAllBadges();
            foreach (KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                if (badge.Key == badgeID)
                {
                    Console.WriteLine("Which door would you like to add?");
                    string doorToBeAdded = Console.ReadLine();
                    badge.Value.Add(doorToBeAdded);
                    Console.WriteLine($"Door {doorToBeAdded} was added to Badge #{badgeID}\n" +
                        "Press any key to continue.....");
                    Console.ReadKey();
                }
            }
        }
        private void RevokeDoorAccess(int badgeID)
        {
            Console.WriteLine("Which door would you like to remove?");
            string doorToBeRemoved = Console.ReadLine();
            _badgesRepo.RemoveAccess(badgeID, doorToBeRemoved);
            Console.WriteLine($"Door {doorToBeRemoved} was removed from Badge #{badgeID}\n" +
                "Press any key to continue.....");
            Console.ReadKey();
        }
        private void RevokeFullAccess(int badgeID)
        {
            Console.WriteLine($"Are you sure you would like to remove access to all doors for Badge #{badgeID} (y/n)?");
            var userResponse = Console.ReadLine();
            switch (userResponse)
            {
                case "y":
                    _badgesRepo.RemoveAllAccess(badgeID);
                    Console.WriteLine($"Access to all doors has been removed from Badge #{badgeID}\n" +
                        "Press any key to continue.....");
                    Console.ReadKey();
                    break;
                case "n":
                    EditBadge();
                    break;
                default:
                    break;
            }
        }
        private void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");
            int userInput = int.Parse(Console.ReadLine());
            List<string> currentAccess = _badgesRepo.GetAllBadges()[userInput];
            var listOfDoors = string.Join(",", currentAccess);

            Console.WriteLine($"\nBadge #{userInput} has access to doors {listOfDoors}\n" +
                "\nWhat would you like to do?\n" +
                "1) Remove a door\n" +
                "2) Add a door\n" +
                "3) Remove access to all doors");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    RevokeDoorAccess(userInput);
                    break;
                case "2":
                    AddDoorAccess(userInput);
                    break;
                case "3":
                    RevokeFullAccess(userInput);
                    break;
                default:
                    break;
            }
        }
        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> allBadges = _badgesRepo.GetAllBadges();
            Console.WriteLine($"{"Badge #",-15}{"Door Access",15}\n");
            foreach (int badgeID in allBadges.Keys)
            {
                var doorAccess = string.Join(",", allBadges[badgeID]);
                Console.WriteLine($"{badgeID,-15}{doorAccess,15}");
            }
            Console.WriteLine("\nPress any key to continue.....");
            Console.ReadKey();
        }
    }
}
