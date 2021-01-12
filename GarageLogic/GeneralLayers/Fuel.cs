using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Fuel : Vehicle
    {
        protected float m_CurrentFuelAmount;
        protected float m_MaxFuelAmount;
        protected Enums.eFuelType m_FuelType;

        public Fuel(string i_LicenseNumber, string i_ModelName, Wheels i_Wheels,
            float i_CurrentFuelAmount) : base(i_LicenseNumber, i_ModelName, i_Wheels)
        {
            this.m_CurrentFuelAmount = i_CurrentFuelAmount;
        }

        public float CurrentFuelAmount
        {
            get
            {
                return this.m_CurrentFuelAmount;
            }

            set
            {
                this.m_CurrentFuelAmount = value;
            }
        }

        public float MaxFuelAmount
        {
            get
            {
                return this.m_MaxFuelAmount;
            }

            set
            {
                this.m_MaxFuelAmount = value;
            }
        }

        public Enums.eFuelType FuelType
        {
            get
            {
                return this.m_FuelType;
            }

            set
            {
                this.m_FuelType = value;
            }
        }

        public void Refueling(float i_FuelToAdd, Enums.eFuelType i_FuelType)
        {
            float sumFuel = this.m_CurrentFuelAmount + i_FuelToAdd, maxToAdd;

            maxToAdd = this.m_MaxFuelAmount - this.m_CurrentFuelAmount;
            if (sumFuel <= this.m_MaxFuelAmount)
            {
                this.m_CurrentFuelAmount = sumFuel;
                this.m_EnergyPrecent = (this.m_CurrentFuelAmount / this.m_MaxFuelAmount) * 100;
            }
            else
            {
                throw new ValueOutOfRangeException("OutOfRange", 0, maxToAdd);
            }
        }

        public void MatchFuelType(Enums.eFuelType i_Type)
        {
            if (this.m_FuelType != i_Type)
            {
                throw new ArgumentException("Fuel types does not match");
            }
        }

        public override string ToString()
        {
            string print = string.Format("Current Fuel Amount: {1}{0}Max Fuel Amount: {2}{0}Fuel Type: {3}{0}{4}",
                Environment.NewLine, m_CurrentFuelAmount, m_MaxFuelAmount, m_FuelType, base.ToString());

            return print;
        }
    }
}
