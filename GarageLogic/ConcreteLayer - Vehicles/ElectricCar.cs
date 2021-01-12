using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Electric
    {
        private Enums.eColor m_Color;
        private Enums.eNumberOfDoors m_NumberOfDoors;

        public ElectricCar(string i_LicenseNumber, string i_ModelName, Wheels i_Wheels,
            float i_RemainingChargerTime, Enums.eColor i_Color, Enums.eNumberOfDoors i_NumberOfDoors) :
            base(i_LicenseNumber, i_ModelName, i_Wheels, i_RemainingChargerTime)
        {
            this.m_MaxChargerTime = (1.8f * 60f);
            this.m_Color = i_Color;
            this.m_NumberOfDoors = i_NumberOfDoors;
            this.m_EnergyPrecent = (i_RemainingChargerTime / this.m_MaxChargerTime) * 100;
        }

        public Enums.eColor Color
        {
            get
            {
                return this.m_Color;
            }

            set
            {
                this.m_Color = value;
            }
        }

        public Enums.eNumberOfDoors NumberOfDoors
        {
            get
            {
                return this.m_NumberOfDoors;
            }

            set
            {
                this.m_NumberOfDoors = value;
            }
        }

        public override string ToString()
        {
            string print = string.Format("Color: {1}{0}Number Of Doors: {2}{0}{3}",
                Environment.NewLine, m_Color, m_NumberOfDoors, base.ToString());

            return print;
        }
    }
}
