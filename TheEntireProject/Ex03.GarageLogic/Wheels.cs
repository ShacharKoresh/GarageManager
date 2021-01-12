using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Wheels
    {
        private int m_NumberOfWeels;
        private string m_ManufacturerName;
        private float m_AirPressure;
        private float m_MaxAirPressure;

        public Wheels(int i_NumberOfWeels, string i_ManufacturerName, float i_AirPressure, float i_MaxAirPressure)
        {
            this.m_NumberOfWeels = i_NumberOfWeels;
            this.m_ManufacturerName = i_ManufacturerName;
            this.m_AirPressure = i_AirPressure;
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public int NumberOfWheels
        {
            get
            {
                return this.m_NumberOfWeels;
            }

            set
            {
                this.m_NumberOfWeels = value;
            }
        }

        public string ManufacturerName
        {
            get
            {
                return this.m_ManufacturerName;
            }

            set
            {
                this.m_ManufacturerName = value;
            }
        }

        public float AirPressure
        {
            get
            {
                return this.m_AirPressure;
            }

            set
            {
                this.m_AirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return this.m_MaxAirPressure;
            }

            set
            {
                this.m_MaxAirPressure = value;
            }
        }

        public override string ToString()
        {
            string print = string.Format("Wheels Details: Number Of Wheels- {0}, Manufacturer Name- {1}, " +
                "Air Pressure- {2}, Maximum Air Pressure- {3}", m_NumberOfWeels, m_ManufacturerName, m_AirPressure,
                m_MaxAirPressure);

            return print;
        }
    }
}
