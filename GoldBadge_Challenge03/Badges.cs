using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenge03
{
    public class Badges
    {
        public string BadgeID { get; set; }
        public List<string> AccessDoorsAvailable { get; set; }
        
        public Badges() { }
        
        public Badges(string badgeID, List<string> accessibleDoors)
        {
            BadgeID = badgeID;
            AccessDoorsAvailable = accessibleDoors;
        }
    }
}
