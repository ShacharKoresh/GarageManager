using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Electric : Vehicle
    {
        protected float m_RemainingChargerTime;
        protected float m_MaxChargerTime;

        public Electric(string i_LicenseNumber, string i_ModelName, Wheels i_Wheels,
            float i_RemainingChargerTime) :
            base(i_LicenseNumber, i_ModelName, i_Wheels)
        {
            this.m_RemainingChargerTime = i_RemainingChargerTime;
        }

        public float RemainingChargerTime
        {
            get
            {
                return this.m_RemainingChargerTime;
            }

            set
            {
                this.m_RemainingChargerTime = value;
            }
        }

        public float MaxChargerTime
        {
            get
            {
                return this.m_MaxChargerTime;
            }

            set
            {
                this.m_MaxChargerTime = value;
            }
        }

        public void Recharge(float i_TimeToAdd)
        {
            float sumTime = this.m_RemainingChargerTime + i_TimeToAdd, maxToAdd;

            maxToAdd = this.m_MaxChargerTime - this.m_RemainingChargerTime;
            if (sumTime <= this.m_MaxChargerTime)
            {
                this.m_RemainingChargerTime = sumTime;
                this.m_EnergyPrecent = (this.m_RemainingChargerTime / this.m_MaxChargerTime) * 100;
            }
            else
            {
                throw new ValueOutOfRangeException("OutOfRange", 0, maxToAdd);
            }
        }

        public override string ToString()
        {
            string print = string.Format("Remaining Charger Time: {1}{0}Max Charger Time: {2}{0}{3}",
                Environment.NewLine, m_RemainingChargerTime, m_MaxChargerTime, base.ToString());
                
            return print;
        }
    }
}
