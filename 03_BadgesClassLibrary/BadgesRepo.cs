using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesClassLibrary
{
    public class BadgesRepo
    {
        protected readonly Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();
        //Create
        public bool AddBadgeToDictionary(Badges badges)
        {
            Dictionary<int, List<string>> badgeDictionary = GetAllBadges();
            int badgeID = badges.BadgeID;
        }
    }
}
