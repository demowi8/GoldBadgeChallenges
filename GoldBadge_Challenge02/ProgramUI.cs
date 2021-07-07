using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenge02
{
    public class ProgramUI
    {
        protected readonly ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            SeedClaimQueue();

            DisplayMenu();
        }
        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose a MENU item:\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. EXIT");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        LookAtNextClaim();
                        break;
                    case "3":
                        AddANewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Number");
                        break;
                }
            }
        }
        private void ShowAllClaims()
        {
            Console.Clear();
            //showtime
            Queue<Claims> claimsQueue = _claimRepo.GetClaimQueue();

            foreach (Claims claim in claimsQueue)
            {
                DisplayClaims(claim);
            }
            ReduceCode();
        }
        private void LookAtNextClaim()
        {
            Console.Clear();
            Claims nextClaimUp = _claimRepo.GetNextClaim();

            DisplayClaims(nextClaimUp);

            Console.WriteLine("\nDo you want to deal with this claim now(Y/N)?");
            string userChoice = Console.ReadLine().ToLower();
            List<string> userChoices = new List<string> { "y", "n" };
            while (!userChoices.Any(userChoice.Contains))
            {
                Console.WriteLine("Y or N");
                userChoice = Console.ReadLine();
            }
            if (userChoice == "y")
            {
                Console.Clear();
                DisplayClaims(nextClaimUp);
                _claimRepo.PullFromTopOfQueue();
                ReduceCode();
            }
            else if (userChoice == "n")
            {
                ReduceCode();
            }


        }

        private void AddANewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();
            //claimID
            Console.WriteLine("Enter the Claim's ID#:");
            string claimIdAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimIdAsString);

            //claimtype
            Console.WriteLine("Enter the Claim's Type:\n" +
                "Type 1 for Car\n" +
                "Type 2 for Home\n" +
                "Type 3 for Theft");
            string stringClaimType = Console.ReadLine();
            newClaim.TypeOfClaim = (ClaimType)int.Parse(stringClaimType);
            while (!stringClaimType.Any(stringClaimType.Contains))
            {
                Console.WriteLine("Invalid Input");
                stringClaimType = Console.ReadLine();
            }

            //claim description
            Console.WriteLine("Enter a Description of Claim:");
            newClaim.Description = Console.ReadLine();

            //claim amount
            Console.WriteLine("Enter Amount of Damage:");
            string amountAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(amountAsString);

            //date of incident
            Console.WriteLine("Enter the Date of Incident:");
            string incidentDateString = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(incidentDateString);

            //date of claim
            Console.WriteLine("Enter the Date of Claim:");
            string claimDateString = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(claimDateString);

            //Claim is valid or invalid
            Console.WriteLine("Is Claim Valid?");
            Console.WriteLine(newClaim.IsValid.ToString());

            _claimRepo.AddClaimToQueue(newClaim);
            Console.Clear();

            DisplayClaims(newClaim);
            ReduceCode();

        }
        //Helper Methods
        private void DisplayClaims(Claims claim)
        {
            Console.WriteLine($"\nClaimID: {claim.ClaimID}\n" +
                $"Type: {claim.TypeOfClaim}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: ${claim.ClaimAmount}\n" +
                $"Date of Accident: {claim.DateOfIncident}\n" +
                $"Date of Claim: {claim.DateOfClaim}\n" +
                $"ValidClaim(t/f): {claim.IsValid}");
        }
        private void ReduceCode()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedClaimQueue()
        {
            Claims claimExample1 = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2020, 2, 24), new DateTime(2020, 3, 11));
            Claims claimExample2 = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2020, 1, 4), new DateTime(2020, 2, 1));
            Claims claimExample3 = new Claims(3, ClaimType.Theft, "Stolen Pancakes.", 4.00m, new DateTime(2020, 4, 24), new DateTime(2020, 5, 28));

            _claimRepo.AddClaimToQueue(claimExample1);
            _claimRepo.AddClaimToQueue(claimExample2);
            _claimRepo.AddClaimToQueue(claimExample3);
        }
    }
}
