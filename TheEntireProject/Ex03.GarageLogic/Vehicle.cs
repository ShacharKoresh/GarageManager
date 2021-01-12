using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        protected string m_LicenseNumber;
        protected string m_ModelName;
        protected float m_EnergyPrecent;
        protected Wheels m_Wheels;

        public Vehicle(string i_LicenseNumber, string i_ModelName, Wheels i_Wheels)
        {
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_ModelName = i_ModelName;
            this.m_Wheels = i_Wheels;
        }

        public string Model
        {
            get
            {
                return this.m_ModelName;
            }

            set
            {
                this.m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }

            set
            {
                this.m_LicenseNumber = value;
            }
        }

        public float EnergyPrecent
        {
            get
            {
                return this.m_EnergyPrecent;
            }

            set
            {
                this.m_EnergyPrecent = value;
            }
        }

        public Wheels Wheels
        {
            get
            {
                return this.m_Wheels;
            }

            set
            {
                this.m_Wheels = value;
            }
        }

        public override string ToString()
        {
            string print = string.Format("License Number: {1}{0}Model Name: {2}{0}Energy Precent: {3}%{0}{4}",
                Environment.NewLine, m_LicenseNumber, m_ModelName, m_EnergyPrecent, m_Wheels.ToString());

            return print;
        }
    }
}
