using _01_MenuClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MenuProgram
{
    public class MenuUI
    {
        private readonly MenuRepo _menuRepo = new MenuRepo();
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please enter the number of the option you'd like to select: \n" +
                    "1) See all items on Menu \n" +
                    "2) Add a new item to the Menu \n" +
                    "3) Change an item on the Menu \n" +
                    "4) Delete an item from the Menu \n" +
                    "5) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeFullMenu();
                        break;
                    case "2":
                        AddToMenu();
                        break;
                    case "3":
                        DeleteFromMenu();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("The character you entered is invalid. \n" +
                   "Please enter a valid number between 1 and 5 \n" +
                   "Press any key to continue.....");
                        Console.ReadKey();
                        break;
                }
            }

        }
        private void SeeFullMenu()
        {
            Console.Clear();
            //Get items
            List<Menu> fullMenu = _menuRepo.GetFullMenu();

            //Display each item's values
            Console.WriteLine($"{"Meal#",-10}{"Name",-15}{"Description",-30}{"Ingredients",-40}{"Price",10}\n");
            foreach (Menu item in fullMenu)
            {
                Console.WriteLine($"{item.Number,-10}{item.Name,-15}{item.Description,-30}{item.Ingredients,-40}${item.Price,10}");
            }

            //Pause program
            Console.WriteLine("\nPress any key to continue.....");
            Console.ReadKey();
        }
        private void AddToMenu()
        {
            Menu itemValue = new Menu();
            //Number
            Console.WriteLine("\nPlease enter the number the item will be on the menu, then press enter");
            itemValue.Number = int.Parse(Console.ReadLine());

            //Name
            Console.WriteLine("\nPlease enter a name for this menu item, then press enter");
            itemValue.Name = Console.ReadLine();

            //Description
            Console.WriteLine("\nPlease enter a description of this menu item, then press enter");
            itemValue.Description = Console.ReadLine();

            //Ingredients
            Console.WriteLine("\nPlease enter a full list of ingredients for this menu item, then press enter");
            itemValue.Ingredients = Console.ReadLine();

            //Price
            Console.WriteLine("\nPlease enter a price for this menu item, then press enter");
            itemValue.Price = double.Parse(Console.ReadLine());

            //Add to menu
            _menuRepo.AddItemToMenu(itemValue);
            Console.WriteLine($"{itemValue.Number}. {itemValue.Name} was added to the menu!\n" +
                "Press any key to continue.....");
            Console.ReadKey();
        }
        private void DeleteFromMenu()
        {
            Console.WriteLine("Which item would you like to remove?");
            List<Menu> fullMenu = _menuRepo.GetFullMenu();
            int count = 0;
            foreach (var item in fullMenu)
            {
                count++;
                Console.WriteLine($"{count}. {item.Name}");
            }
            int targetItemID = int.Parse(Console.ReadLine());
            int correctIndex = targetItemID - 1;
            if (correctIndex >= 0 && correctIndex < fullMenu.Count)
            {
                Menu itemToBeDeleted = fullMenu[correctIndex];
                Console.WriteLine($"Are you sure you want to remove {itemToBeDeleted.Name} from the menu?\n" +
                        "Type 'y' for yes and 'n' for no");
                string userConfirmation = Console.ReadLine();
                if (userConfirmation == "y")
                {
                    _menuRepo.DeleteItemFromMenu(itemToBeDeleted);
                    Console.WriteLine($"{itemToBeDeleted.Name} was successfully removed from the menu!");
                }
                else if (userConfirmation == "n")
                {
                    Console.WriteLine($"{itemToBeDeleted.Name} was NOT removed from the menu");
                }
                else
                {
                    Console.WriteLine("INVALID ENTRY");
                }
            }
            else
            {
                Console.WriteLine("INVALID OPTION");
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
    }
}
