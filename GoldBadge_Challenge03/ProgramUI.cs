using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenge03
{
    public class ProgramUI
    {
        protected readonly Badge_Repository _badgeRepo = new Badge_Repository();

        public void Run()
        {
            SeedBadges(); 

            DisplayMenu();
        }
        private void DisplayMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit");
                string adminInput = Console.ReadLine();

                switch (adminInput)
                {
                    case "1":
                        AddABadge();

                        break;
                    case "2":
                        UpdateABadge();

                        break;
                    case "3":
                        DisplayAllBadges();

                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Number");
                        break;
                }

            }

        }
        private void AddABadge()
        {
            Console.Clear();

            Badges newBadge = new Badges();

            Console.WriteLine("What is the Badge Number?");
            string userInput = Console.ReadLine();
            newBadge.BadgeID = userInput;

            Console.WriteLine("List a door it needs access to:");
            string userInput2 = Console.ReadLine();
            newBadge.AccessDoorsAvailable.Add(userInput2); 
            
            Console.WriteLine("Any other doors (y/n)?");
            string userInput3 = Console.ReadLine().ToLower();
            List<string> userChoices = new List<string> { "y", "n" };
            while (!userChoices.Any(userInput3.Contains))
            {
                Console.WriteLine("y or n");
                userInput3 = Console.ReadLine();
            }
            if (userInput3 == "y")
            {
                Console.WriteLine("List a door it needs access to:");
                userInput2 = Console.ReadLine();
            }
            else if (userInput3 == "n")
            {
                ReduceCode();
            }
            Console.Clear();

           _badgeRepo.AddToBadgeDictionary(newBadge.BadgeID, newBadge);
        }
        private void UpdateABadge()
        {
            Console.Clear();
            
            Badges updatedBadge = new Badges();
            

            Console.WriteLine("What is the Badge number to update?");
            string userInput = Console.ReadLine();
           Badges selectedBadge = _badgeRepo.GetABadgeByID(userInput);


            Console.WriteLine($"{selectedBadge.BadgeID} has access to doors");
            foreach (string accessDoorsAssigned in selectedBadge.AccessDoorsAvailable)
            {
                Console.WriteLine(accessDoorsAssigned);
            }

            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a Door\n" +
                "2. Add a Door");
            string userInput2 = Console.ReadLine();
            switch (userInput2)
            {
                case "1":
                    Console.WriteLine("Which door would you like to remove?");
                    string userInput3 = Console.ReadLine();
                    selectedBadge.AccessDoorsAvailable.Remove(userInput3);
                    Console.WriteLine($"{selectedBadge.BadgeID} has access to {selectedBadge.AccessDoorsAvailable}");
                    break;
                case "2":
                    Console.WriteLine("Which door would you like to add?");
                    string userInput4 = Console.ReadLine();
                    selectedBadge.AccessDoorsAvailable.Add(userInput4);
                    Console.WriteLine($"{selectedBadge.BadgeID} has access to {selectedBadge.AccessDoorsAvailable}");
                    break;
            }

        }
        private void DisplayAllBadges()
        {
            Console.Clear();

            Dictionary<string, Badges> listOfBadges = _badgeRepo.GetBadgesList();
            foreach (KeyValuePair<string, Badges> badges in listOfBadges)
            {
                DisplayBadge(badges);
            }
            ReduceCode(); 
        }
        //Helper Methods
        private void DisplayBadge(KeyValuePair<string, Badges> badges)
        {
            Console.WriteLine($" Badge #\n {badges.Key}\n Door Access");
            foreach (string accessDoorsAssigned in badges.Value.AccessDoorsAvailable)
            {
                Console.WriteLine(accessDoorsAssigned);
            }
        }

        private void SeedBadges()
        {
            Badges exampleBadge1 = new Badges("12345", new List<string>() { "A1", "A2", "A3" });
            Badges exampleBadge2 = new Badges("22345", new List<string>() { "A1", "A2", "A3" });
            Badges exampleBadge3 = new Badges("32345", new List<string>() { "B1", "B2", "B3" });

            _badgeRepo.AddToBadgeDictionary(exampleBadge1.BadgeID, exampleBadge1);
            _badgeRepo.AddToBadgeDictionary(exampleBadge2.BadgeID, exampleBadge2);
            _badgeRepo.AddToBadgeDictionary(exampleBadge3.BadgeID, exampleBadge3);

        }
        private void ReduceCode()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
