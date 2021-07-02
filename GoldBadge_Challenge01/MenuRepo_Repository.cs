using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenge01
{
    public class MenuRepo_Repository
    {
        //Field
        protected readonly List<MenuItems> _listOfMenuItems = new List<MenuItems>();

        //CRUD 
        //CREATE
        public bool AddAMenuItemToList(MenuItems item)
        {
            int startingCount = _listOfMenuItems.Count;
            _listOfMenuItems.Add(item);
            bool itemAdded = (_listOfMenuItems.Count > startingCount) ? true : false;
            return itemAdded;
        }
        //READ
        public List<MenuItems> GetMenuItems()
        {
            return _listOfMenuItems; 
        }
        public MenuItems GetItemByName(string name)
        {
            //get the directory
            //sort through all items using title to find a match
            foreach (MenuItems item in _listOfMenuItems)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }

            }
            return null;
        }
        public MenuItems GetItemByNumber(int number)
        {
            foreach (MenuItems item in _listOfMenuItems)
            {
                if(item.Number.Equals(_listOfMenuItems.Count) == number.Equals(_listOfMenuItems.Count))
                {
                    return item;
                }
            }
            return null;
        }

        //UPDATE
        //DELETE
        public bool RemoveMenuItem(MenuItems existingItems)
        {
            bool removeResult = _listOfMenuItems.Remove(existingItems);
            return removeResult;
        }

    }
}
