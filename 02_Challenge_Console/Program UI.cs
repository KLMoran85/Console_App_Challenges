using _02_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Console
{
    class Program_UI
    {
        private ClaimContentRepository _queueRepo = new ClaimContentRepository();
        public void Run()
        {
            _queueRepo.SeedList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello! Please select a Menu Option\n" +
                    "1. See All Claims\n" +
                    "2. Take Care Of Next Claim\n" +
                    "3. Enter A New Claim\n" +
                    "4. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to contiue..");
                Console.ReadKey();
                Console.Clear();
            }

        }   
        private void ViewAllClaims()
        {
            Queue<ClaimContent> _queueOfClaimContent = _queueRepo.GetClaimContentQueue();

            foreach (ClaimContent content in _queueOfClaimContent)
            {
                Console.WriteLine($"Type Of Claim{content.ClaimType}\n" +
                    $"Claim ID{ content.ClaimID}\n" +
                    $"Description{ content.Description}\n" +
                    $"Claim Amount{content.ClaimAmount}\n" +
                    $"Date Of Incident{content.DateOfIncident}\n" +
                    $"Date Of Claim{content.DateOfClaim}\n" +
                    $"Is Valid{content.IsValid}\n" +
                    $"");
                Console.WriteLine("");
                    
            }
            Console.WriteLine("Press Enter to Return to the Main Menu");
            Console.ReadLine();
            Console.Clear();
            Run();
        }

        private void TakeCareOfNextClaim()
        {
            Console.WriteLine("Would you like to take care of the next claim y/n");

            string userAnswer = Console.ReadLine();

            if (userAnswer == "y")
            {
                _queueRepo.TakeCareOfNextClaim();
            }
             else
            {
                _queueRepo.RemoveNextClaim();
            }   
        }

        private void EnterANewClaim()
        {
            Console.WriteLine("Please enter a Claim ID");
            string claimIDAsString = Console.ReadLine();
            int claimID = int.Parse(claimIDAsString);

            Console.WriteLine("Please select a Claim Type\n" +

                    "1 Car\n" + 
                    "2 Home\n" +
                    "3 Theft\n" +
                    "4 Exit");
            string input = Console.ReadLine();

            ClaimType typeofclaim = (ClaimType)int.Parse(input);

            Console.WriteLine("Please enter a description of this claim");
            string description = Console.ReadLine();

            Console.WriteLine("Please enter a claim amount");
            string claimAmountAsString = Console.ReadLine();
            decimal claimAmount = decimal.Parse(claimAmountAsString);

            Console.WriteLine("Please enter the date of the incident(yyyy/mm/dd");

            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of the claim (yyyy/mm/dd");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            ClaimContent newClaimContent = new ClaimContent(typeofclaim, claimID, description, claimAmount, dateOfIncident, dateOfClaim);
            _queueRepo.AddContentToQueue(newClaimContent);
        }
    }  

}
