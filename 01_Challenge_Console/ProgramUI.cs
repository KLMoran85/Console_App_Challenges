using _01_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Console
{
    class ProgramUI
    {

        private MenuContentRepository _menuRepo = new MenuContentRepository(); //Calling back to our Repository

        public void Run()
        {
            SeedContentList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {



                Console.WriteLine("Select a Menu Option:\n" +
                "1. Create New Content\n" +
                "2. View All Content\n" +
                "3. Remove MenuContent\n" +
                "4. Exit");
                String Input = Console.ReadLine();

                switch (Input)
                {
                    case "1":
                        CreateNewContent();
                        break;
                    case "2":
                        ViewAllContent();
                        break;
                    case "3":
                        RemoveMenuContent();
                        break;
                    case "4":
                        Console.WriteLine("See you later!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;

                }

                Console.WriteLine("Please press any key to contiue...");
                Console.ReadKey();
            }
            Console.Clear();
        }

        private void CreateNewContent()
        {
            Console.Clear();
            MenuContent newContent = new MenuContent();

            Console.WriteLine("Enter the number for the new meal number:");
            string mealNumberAsString = Console.ReadLine();
            newContent.MealNumber = int.Parse(mealNumberAsString);

            Console.WriteLine("Enter the name for the new meal name:");
            newContent.MealName = Console.ReadLine();

            Console.WriteLine("Enter a description of this new meal:");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("Enter a list of ingredients to be indluded in this meal:");
            newContent.ListOfIngredients = Console.ReadLine();

            Console.WriteLine("Enter a price for this meal:");
            string priceAsString = Console.ReadLine();
            newContent.Price = decimal.Parse(priceAsString);

            _menuRepo.AddContentToMenu(newContent);

        }

        private void ViewAllContent()
        {
            Console.Clear();

            List<MenuContent> listOfContent = _menuRepo.GetMenuContent();

            foreach (MenuContent content in listOfContent)
            {
                Console.WriteLine($"MealName: {content.MealName}\n" +
                    $"Desc: {content.Description}");
            }
        }

        private void RemoveMenuContent()
        {
            ViewAllContent();

            Console.WriteLine("Enter the name of the meal that you would like to remove:");

            string input = Console.ReadLine();

            bool wasDeleted = _menuRepo.RemoveMenuContent(input);

            if (wasDeleted)
            {
                Console.WriteLine("The content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The content could not be delted.");
            }
        }

        private void SeedContentList()
        {
            MenuContent grilledCheese = new MenuContent(9, "Grilled Cheese Combo", "Grilled Cheese with choice of a side", "Bread, American Cheese, and butter", 6.5m);
            MenuContent chickenAndWaffles = new MenuContent(10, "Chicken and Waffles", "Battered Chicken with a Waffle", "Breaded chicken and Waffle", 9.5m);
            MenuContent brunswickStew = new MenuContent(11, "Brunswick Stew", "Pot Roast meat in a stew with vegetables", "Roast beef meat, vinegar, and beef broth", 11.5m);

            _menuRepo.AddContentToMenu(grilledCheese);
            _menuRepo.AddContentToMenu(chickenAndWaffles);
            _menuRepo.AddContentToMenu(brunswickStew);
        }
    }

}
