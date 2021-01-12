using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Electric
    {
        private Enums.eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public ElectricMotorcycle(string i_LicenseNumber, string i_ModelName,
            Wheels i_Wheels, float i_RemainingChargerTime, Enums.eLicenseType i_LicenseType,
            int i_EngineCapacity) :
            base(i_LicenseNumber, i_ModelName, i_Wheels, i_RemainingChargerTime)
        {
            this.m_MaxChargerTime = (1.4f * 60f);
            this.m_LicenseType = i_LicenseType;
            this.m_EngineCapacity = i_EngineCapacity;
            this.m_EnergyPrecent = (i_RemainingChargerTime / this.m_MaxChargerTime) * 100;
        }

        public Enums.eLicenseType LicenseType
        {
            get
            {
                return this.m_LicenseType;
            }

            set
            {
                this.m_LicenseType = value;
            }
        }

        public override string ToString()
        {
            string print = string.Format("License Type: {1}{0}Engine Capacity: {2}{0}{3}",
                Environment.NewLine, m_LicenseType, m_EngineCapacity, base.ToString());

            return print;
        }
    }
}