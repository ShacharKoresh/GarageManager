using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        protected Vehicle m_Vehicle;
        protected string m_OwnerName;
        protected string m_OwnerPhoneNumber;
        protected Enums.eGarageCondition m_Condition;

        public VehicleInGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            this.m_Vehicle = i_Vehicle;
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            this.m_Condition = Enums.eGarageCondition.GettingFixed;
        }

        public Vehicle Vehicle
        {
            get
            {
                return this.m_Vehicle;
            }

            set
            {
                this.m_Vehicle = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return this.m_OwnerName;
            }

            set
            {
                this.m_OwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return this.m_OwnerPhoneNumber;
            }

            set
            {
                this.m_OwnerPhoneNumber = value;
            }
        }

        public Enums.eGarageCondition Condition
        {
            get
            {
                return this.m_Condition;
            }

            set
            {
                this.m_Condition = value;
            }
        }

        public override string ToString()
        {
            string print = string.Format("{0}Owner's Name: {1}{0}Owner's Phone Number: {2}{0}Condition: {3}{0}" +
                "Wheels Details: {4}", Environment.NewLine, m_OwnerName, m_OwnerPhoneNumber, m_Condition,
                m_Vehicle.ToString());

            return print;
        }
    }
}
