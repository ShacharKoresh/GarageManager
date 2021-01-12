using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelTruck : Fuel
    {
        private bool m_ContainsHazardousMaterial;
        private float m_CargoVolume;

        public FuelTruck(string i_LicenseNumber, string i_ModelName, Wheels i_Wheels,
            float i_CurrentFuelAmount, bool i_ContainsHazardousMaterial, float i_CargoVolume) :
            base(i_LicenseNumber, i_ModelName, i_Wheels, i_CurrentFuelAmount)
        {
            this.m_FuelType = Enums.eFuelType.Soler;
            this.m_MaxFuelAmount = 110;
            this.m_ContainsHazardousMaterial = i_ContainsHazardousMaterial;
            this.m_CargoVolume = i_CargoVolume;
            this.m_EnergyPrecent = (i_CurrentFuelAmount / this.m_MaxFuelAmount) * 100;
        }

        public bool ContainsHazardousMaterial
        {
            get
            {
                return this.m_ContainsHazardousMaterial;
            }

            set
            {
                this.m_ContainsHazardousMaterial = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return this.m_CargoVolume;
            }

            set
            {
                this.m_CargoVolume = value;
            }
        }

        public override string ToString()
        {
            string print = string.Format("Contains Hazardous Material: {1}{0}Cargo Volume: {2}{0}{3}",
                Environment.NewLine, m_ContainsHazardousMaterial, m_CargoVolume, base.ToString());

            return print;
        }
    }
}