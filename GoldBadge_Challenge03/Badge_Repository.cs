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

        protected Dictionary<string, Badges> BadgesAndAccessDoors = new Dictionary<string, Badges>();

        //CRUD
        //CREATE
        public bool AddToBadgeDictionary(string badgeId, Badges accessDoors)
        {


            int startingDictCount = BadgesAndAccessDoors.Count;
            BadgesAndAccessDoors.Add(badgeId, accessDoors);
            bool wasAddedToDict = (BadgesAndAccessDoors.Count > startingDictCount) ? true : false;
            return wasAddedToDict;

        }

 
        
        //READ
        public Dictionary<string, Badges> GetBadgesList()
        {
            return BadgesAndAccessDoors;
        }
        public Badges GetABadgeByID(string badgeID)
        {
            foreach(KeyValuePair<string, Badges> badge in BadgesAndAccessDoors)
            {
                if (badge.Key == badgeID)
                {
                    return badge.Value;
                }
            }
                return default;
        }
        //UPDATE

        //DELETE
    }
}
