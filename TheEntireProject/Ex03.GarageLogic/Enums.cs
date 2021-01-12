using System;

namespace Ex03.GarageLogic
{
    public class Enums
    {
        public enum eLicenseType
        {
            A,
            A1,
            A2,
            B
        }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public enum eColor
        {
            Red,
            Blue,
            Black,
            Grey
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public enum eGarageCondition
        {
            GettingFixed,
            Fixed,
            Paid
        }
    }
}
