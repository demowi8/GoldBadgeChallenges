using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenge01
{
    public class ProgramUI
    {
        protected readonly MenuRepo_Repository _menuRepo = new MenuRepo_Repository();
        public void Run()
        {
            DisplayMenu();
        }
        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you would like to select:\n" +
                    "1. Add food to MENU \n" +
                    "2. Remove food from MENU\n" +
                    "3. Display MENU\n" +
                    "4. EXIT");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddAMenuItemToList();
                        break;
                    case "2":
                        RemoveMenuItem();
                        break;
                    case "3":
                        ShowAllMenuItems();
                        break;
                    case "4":
                        //Exit
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 3");
                        break;
                }

            }
        }
        private void AddAMenuItemToList()
        {
            Console.Clear();
            MenuItems newItem = new MenuItems();

            //Name
            Console.WriteLine("Please enter the food's name:");
            newItem.Name = Console.ReadLine();

            //number?
            Console.WriteLine("Please enter the items number:");
            string numberAsString = Console.ReadLine();
            newItem.Number = int.Parse(numberAsString);

            //Description
            Console.WriteLine("Please enter the description of your food item:\n" +
                "Next we will do it's ingredients...");
            newItem.Description = Console.ReadLine();

            //Ingredients
            Console.WriteLine("Please enter the item's ingredients");
            newItem.Ingredients = Console.ReadLine();

            //Price
            Console.WriteLine("Please enter the item's price:");
            string stringItemPrice = Console.ReadLine();
            newItem.ItemPrice = double.Parse(stringItemPrice);

            MenuItems item = new MenuItems(newItem.Name, newItem.Number, newItem.Description, newItem.ItemPrice, newItem.Ingredients);

            _menuRepo.AddAMenuItemToList(item);
            ReduceCode();

        }
        private void RemoveMenuItem()
        {
            Console.Clear();
            //Select item to delete
            Console.WriteLine("Which item would you like to remove?");
            int count = 0;
            //display all items
            List<MenuItems> menuItemList = _menuRepo.GetMenuItems();
            foreach (MenuItems item in menuItemList)
            {
                count++;
                Console.WriteLine($"{count}. {item.Name}");
            }
        }
        private void ShowAllMenuItems()
        {
            Console.Clear();
            //Show items
            List<MenuItems> menuItemsList = _menuRepo.GetMenuItems();

            foreach (MenuItems item in menuItemsList)
            {
                DisplayItems(item);
            }
            ReduceCode();
        }
        private void DisplayItems(MenuItems item)
        {
            Console.WriteLine($"Name: {item.Name}\n" +
                    $"Number: {item.Number}\n" +
                    $"Description: {item.Description}\n" +
                    $"Item's Price: {item.ItemPrice}\n" +
                    $"Ingredients: {item.Ingredients}\n");
        }
        private void ReduceCode()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
