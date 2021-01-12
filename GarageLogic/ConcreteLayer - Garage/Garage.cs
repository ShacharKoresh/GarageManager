using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public static Dictionary<string, VehicleInGarage> m_VehiclesInGarage =
            new Dictionary<string, VehicleInGarage>();

        public static void ChangeCondition(string i_LicenseNumber, Enums.eGarageCondition i_NewCondition)
        {
            VehicleInGarage vehicle;
            
            vehicle = CheckIfInGarage(i_LicenseNumber);
            vehicle.Condition = i_NewCondition;
        }

        public static GarageLogic.VehicleInGarage CheckIfInGarage(string i_LicenseNumber)
        {
            bool containsVehicle = m_VehiclesInGarage.ContainsKey(i_LicenseNumber);
            GarageLogic.VehicleInGarage vehicleInGarage = null;

            if (containsVehicle)
            {
                vehicleInGarage = m_VehiclesInGarage[i_LicenseNumber];
            }
            else
            {
                throw new ArgumentException("Vehicle is not in garage");
            }

            return vehicleInGarage;
        }

        public static void CheckIfFuelVehicle(Vehicle i_Vehicle)
        {
            bool isFuel = true;

            isFuel = i_Vehicle is GarageLogic.Fuel;
            if (!isFuel)
            {
                throw new ArgumentException("Vehicle is not fuel based");
            }
        }

        public static void CheckIfElectricVehicle(Vehicle i_Vehicle)
        {
            bool isFuel = true;

            isFuel = i_Vehicle is GarageLogic.Electric;
            if (!isFuel)
            {
                throw new ArgumentException("Vehicle is not electric based");
            }
        }
    }
}
