using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_GoldBadgeChallenge
{
    public class BadgeRepository
    {
        
        private Dictionary<int, List<string>> _Badges = new Dictionary<int, List<string>>();
        
        //Create
        public void CreateBadge(int badgeID, List<string> doorNames)
        {
            Badge newBadge = new Badge(badgeID, doorNames);
            _Badges.Add(newBadge.BadgeID, newBadge.DoorNames);

        }

        public bool CreateNewBadge(int id, List<string> doorNames)
        {
            int startingCount = _Badges.Count;

            _Badges.Add(id, doorNames);

            bool wasAdded = _Badges.Count == startingCount + 1;

            return wasAdded;
        }


        //Read
        public Dictionary<int, List<string>> ShowAllBadges()
        {
            return _Badges;
        }

        public List<string> ShowBadgeByID(int badgeNumber)
        {
                if (_Badges.ContainsKey(badgeNumber))
                {
                    return _Badges[badgeNumber] ;
                }
            
            return null;

        }
        
        //Update
        public void UpdateBadge(int badgeID, List<string> doors)
        {
            _Badges[badgeID] = doors;
        }
    }
}

