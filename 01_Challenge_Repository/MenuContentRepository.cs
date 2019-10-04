using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Repository
{
    public class MenuContentRepository
    {
        List<MenuContent> _listOfContent; 

        public MenuContentRepository()
        {
            _listOfContent = new List<MenuContent>();
        }

        
        public void AddContentToMenu(MenuContent content) 
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

