using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Repository
{
    public class MenuContentRepository//<--this class will hold all of our CRUD  It will be the holder and manipulater for all data
    {
        List<MenuContent> _listOfContent; //<--creation of field is _listOfContent

        public MenuContentRepository()
        {
            _listOfContent = new List<MenuContent>();
        }

        //Create
        public void AddContentToMenu(MenuContent content) //should be public so anyone outside the class can see it but it's not returning anything so it's void
        {
            _listOfContent.Add(content);
        }

        public List<MenuContent> GetMenuContent()
        {
            return _listOfContent;
        }
      
       
        public MenuContent GetMenuContent(int mealNumber)
        {
            foreach (MenuContent content in _listOfContent)
            {
                if (mealNumber == content.MealNumber)
                {
                    return content;
                }
            }
            return null;
        }

        public bool RemoveMenuContent(int mealNumber)
        {
            foreach (MenuContent content in _listOfContent)
            {
                if (mealNumber == content.MealNumber)
                {
                    return _listOfContent.Remove(content);

                }
            }
            return false;
        }

        public bool RemoveMenuContent(string mealName)
        {
            foreach(MenuContent content in _listOfContent)
            {
                if (mealName == content.MealName)
                {
                    return _listOfContent.Remove(content);
                }
            }
            return false;
        }


    }

}

