using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenge03
{
    public class Badge_Repository
    {
        //DICTIONARY field
        protected Dictionary<string, List<string>> BadgesAndAccessDoors = new Dictionary<string, List<string>>();

        public void AddToDictionary()
        {
            List<string> accessDoors = new List<string>()
            {
                "A1", "A2", "A3", "B1", "B2", "B3"
            };

            BadgesAndAccessDoors.Add("12345", accessDoors);

            BadgesAndAccessDoors["12345"].Add("B4");
        }
        //CRUD
        //CREATE
        public bool AddBadge
        //READ
        //UPDATE
        //DELETE
    }
}
