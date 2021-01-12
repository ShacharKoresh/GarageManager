using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Fuel
    {
        private Enums.eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public FuelMotorcycle(string i_LicenseNumber, string i_ModelName, Wheels i_Wheels,
            float i_CurrentFuelAmount, Enums.eLicenseType i_LicenseType, int i_EngineCapacity) :
            base(i_LicenseNumber, i_ModelName, i_Wheels, i_CurrentFuelAmount)
        {
            this.m_FuelType = Enums.eFuelType.Octan95;
            this.m_MaxFuelAmount = 8;
            this.m_LicenseType = i_LicenseType;
            this.m_EngineCapacity = i_EngineCapacity;
            this.m_EnergyPrecent = (i_CurrentFuelAmount / this.m_MaxFuelAmount) * 100;
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

        public int EngineCapacity
        {
            get
            {
                return this.m_EngineCapacity;
            }

            set
            {
                this.m_EngineCapacity = value;
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