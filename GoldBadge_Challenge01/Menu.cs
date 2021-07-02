using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenge01
{
    public class MenuItems
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public double ItemPrice { get; set; }
        public string Ingredients { get; set; }
        public MenuItems() { }
        public MenuItems(string name, int number, string description, double itemPrice, string ingredients)
        {
            Name = name;
            Number = number;
            Description = description;
            ItemPrice = itemPrice;
            Ingredients = ingredients;

        }
    }
}
