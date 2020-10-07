using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MenuClassLibrary
{
    public class MenuRepo
    {
        protected readonly List<Menu> _menu = new List<Menu>();
        //CREATE
        public bool AddItemToMenu(Menu newMenuItem)
        {
            int startingCount = _menu.Count;
            _menu.Add(newMenuItem);
            bool wasAdded = (_menu.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //READ (all items)
        public List<Menu> GetFullMenu()
        {
            return _menu;
        }
        //READ (one item)
        public Menu GetItemByNumber(int number)
        {
            foreach (Menu menuItem in _menu)
            {
                if (menuItem.Number == number)
                {
                    return menuItem;
                }
            }
            return null;
        }
        //DELETE
        public bool DeleteItemFromMenu(Menu itemToBeDeleted)
        {
            bool deleteResult = _menu.Remove(itemToBeDeleted);
            return deleteResult;
        }
    }
}
