using System;
using System.Collections.Generic;
using _01_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge_Tests
{
    [TestClass]
    public class MenuRepository_Tests
   {
        MenuContentRepository _menuRepo;
        List<MenuContent> _content;


        [TestInitialize]
         public void Arrange()
        {   
        _menuRepo = new MenuContentRepository();
        _content = _menuRepo.GetMenuContent();

        MenuContent content = new MenuContent(1, "Tuna Salad Sandwich", "Tuna salad on Wheat Bread with a side", "Wheat bread and tuna salad", 7.50m);
        MenuContent contentTwo = new MenuContent(2, "Hamburger and fries Combo", "Beef burger on bun with fries", "All beef patty and bun", 9.0m);
        MenuContent contentThree = new MenuContent(3, "Spinach salad with dressing choice", "Spinach salad with choice of dressing", "spinach and veggies", 10.0m);
        MenuContent contentFour = new MenuContent(4, "Soup of the Day combo", "Daily soup with choice of side", "Broth with veeggies", 6.50m);
        MenuContent contentFive = new MenuContent(5, "Slice of Pizza combo", "Daily slice of pizza with choice of side", "Cheese with toppings and crust", 7.50m);

           
            _menuRepo.AddContentToMenu(content);
            _menuRepo.AddContentToMenu(contentTwo);
            _menuRepo.AddContentToMenu(contentThree);
            _menuRepo.AddContentToMenu(contentFour);
            _menuRepo.AddContentToMenu(contentFive);

        }

        [TestMethod]
        public void AddContentToMenu()
        {
            Arrange();

            int actual = _content.Count;
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveMenuContent()
        {
            Arrange();

            bool actual = _menuRepo.RemoveMenuContent(4);
            bool expected = true;

            int actualCount = _menuRepo.GetMenuContent().Count;
            int expectedCount = 4;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedCount, actualCount);

        }
   }
}   
    
