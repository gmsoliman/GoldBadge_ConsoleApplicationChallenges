﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesClassLibrary
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; }

        public Badges() { }
        public Badges(int badgeID, List<string> doorAccess)
        {
            BadgeID = badgeID;
            DoorAccess = doorAccess;
        }
    }
}
