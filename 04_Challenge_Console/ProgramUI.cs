using _04_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge_Console
{
    class ProgramUI
    {
        private OutingContentRepository _outingRepo = new OutingContentRepository();

        public void Run()
        {
            _outingRepo.SeedList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Hello!  Please select a menu option\n" +
                    "1. Add New Outing Content\n" +
                    "2. View All Outing Content\n" +
                    "3. View Outing Cost By Type\n" +
                    "4. View Total Cost For All Outings\n" +
                    "5. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewOutingContent();
                        break;
                    case "2":
                        ViewAllOutingContent();
                        break;
                    case "3":
                        ViewOutingCostByType();
                        break;

                    case "4":
                        ViewTotalOutingCostsCombined();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;

                }
                
            }
            Console.WriteLine("Please press any key to contiue..");
            Console.ReadKey();
            Console.Clear();
        }

        private void AddNewOutingContent()
        {
            Console.WriteLine("Please enter the number of attendees:");
            string NumberOfAttendeesAsString = Console.ReadLine();
           int NumberOfAttendees = int.Parse(NumberOfAttendeesAsString);

            Console.WriteLine("Please enter the date of the event (mm/dd/yyy):");
            DateTime DateOfEvent = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Outing Type Number:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n" +
                "5. Exit");

            string Type = Console.ReadLine();
            OutingType outingType = OutingType.Golf;
            if (Type == "1")
            {
                outingType = OutingType.Golf;
            }
            else if (Type == "2")
            {
                outingType  = OutingType.Bowling;
            }
            else if (Type =="3")
            {
                outingType  = OutingType.AmusementPark;
            }
            else if (Type == "4")
            {
                outingType = OutingType.Concert;
            }
            else if (Type == "5")
            {
                Console.WriteLine("Press Enter to return to the Main Menu");
                Console.ReadLine();
                Run();
            }
            else
            {
                Console.WriteLine("Please enter a valid menu option:");
            }

            Console.WriteLine("Please enter the cost per person for this event:");
            decimal CostPerPerson = decimal.Parse(Console.ReadLine());

            decimal attendees = decimal.Parse(NumberOfAttendees.ToString());
            decimal result = (attendees * CostPerPerson);
            decimal TotalCostOfOutings = result;

            OutingContent type = new OutingContent(NumberOfAttendees, DateOfEvent, outingType, CostPerPerson, TotalCostOfOutings);

            _outingRepo.AddOutingContentToList(type);

            Console.WriteLine("Your new outing content has been added to the list! Please press any key to contiue..");
            Console.ReadKey();
            Console.Clear();
            Run();
        }

        private void ViewAllOutingContent()
        {
            
            List<OutingContent> listOfOutingContent = _outingRepo.GetOutingContentList();

            foreach (OutingContent content in listOfOutingContent)
            {
                Console.WriteLine($"Number Of Attendees{content.NumberOfAttendees}\n" +
                    $"Date Of Event {content.DateOfEvent}\n" +
                    $"Type Of Event {content.OutingType}\n" +
                    $"Cost Per Person{content.CostPerPerson}\n" +
                    $"Total Cost Of Outing{content.TotalCostOfOutings}\n" +
                    $" ");
                Console.WriteLine(" ");
            }
            Console.WriteLine("Press Enter to Return to Main Menu");//Follow this pattern to return to the main menu b/t methods
            Console.ReadLine();
            Console.Clear();
            Run();
        }   

        private void ViewOutingCostByType()
        {
            
            decimal TotalBowlingCost = _outingRepo.GetOutingCostByType(OutingType.Bowling);
            Console.WriteLine("Total Bowling Cost: " + TotalBowlingCost);

            decimal TotalGolfCost = _outingRepo.GetOutingCostByType(OutingType.Golf);
            Console.WriteLine("Total Golf Cost: " + TotalGolfCost);

            decimal TotalAmusementParkCost = _outingRepo.GetOutingCostByType(OutingType.AmusementPark);
            Console.WriteLine("Total AmusementPark Cost: " + TotalAmusementParkCost);

            decimal TotalConcertCost = _outingRepo.GetOutingCostByType(OutingType.Concert);
            Console.WriteLine("Total Concert Cost: " + TotalConcertCost);
            Console.WriteLine(" ");
            Console.WriteLine("Press Enter to Return to Main Menu");
            Console.ReadLine();
            Console.Clear();
            Run();
        }

        private void ViewTotalOutingCostsCombined()
        {
            decimal cost = _outingRepo.GetTotalOutingsCost();
            Console.WriteLine(cost);

            Console.WriteLine(" ");
            Console.WriteLine("Press Enter to Return to Main Menu");
            Console.ReadLine();
            Console.Clear();
            Run();
        }

        
    }
}
