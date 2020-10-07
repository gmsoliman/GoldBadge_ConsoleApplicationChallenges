using System;
using System.Collections.Generic;
using System.Data.Odbc;
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
            List<string> doorAccess = badges.DoorAccess;

            int badgesCount = _badges.Count();
            badgeDictionary.Add(badgeID, doorAccess);
            bool wasAdded = badgesCount + 1 == _badges.Count();
            return wasAdded;
        }

        //Read (all items)
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badges;
        }

        //Read (one item)
        public List<string> GetBadgeByID(int badgeID)
        {
            List<string> doorAccess;
            if (_badges.TryGetValue(badgeID, out doorAccess))
            {
                return doorAccess;
            }
            else
            {
                return null;
            }
        }

        //Update
        public void UpdateAccess(int badgeID, string updatedAccess)
        {
            foreach (int badgeNumber in _badges.Keys)
            {
                if(badgeNumber == badgeID)
                {
                    _badges[badgeNumber].Add(updatedAccess);
                }
            }
        }

        //Delete (one door)
        public void RemoveAccess (int badgeID, string accessToBeRemoved)
        {
            foreach (int badgeNumber in _badges.Keys)
            {
                if(badgeNumber == badgeID)
                {
                    List<string> doorAccess = _badges[badgeNumber];
                    doorAccess.Remove(accessToBeRemoved);
                }
            }
        }

        //Delete (all doors)
        public void RemoveAllAccess (int badgeID)
        {
            foreach (int badgeNumber in _badges.Keys)
            {
                if(badgeID == badgeNumber)
                {
                    List<string> doorAccess = _badges[badgeNumber];
                    doorAccess.Clear();
                }
            }
        }
    }
}
