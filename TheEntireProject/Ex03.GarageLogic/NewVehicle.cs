using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class NewVehicle
    {
        public static FuelMotorcycle MakeNewFuelMotorcycle(string i_LicenseNumber,
            string i_ModelName, string i_ManufacturerName, float i_AirPressure,
            float i_CurrentFuelAmount, Enums.eLicenseType i_LicenseType, int i_EngineCapacity)
        {
            Wheels wheels = new Wheels(2, i_ManufacturerName, i_AirPressure, 33);
            FuelMotorcycle fuelMotorcycle = new FuelMotorcycle(i_LicenseNumber, i_ModelName,
                wheels, i_CurrentFuelAmount, i_LicenseType, i_EngineCapacity);

            return fuelMotorcycle;
        }

        public static ElectricMotorcycle MakeNewElectricMotorcycle(string i_LicenseNumber,
            string i_ModelName, float i_RemainingChargerTime, string i_ManufacturerName, float i_AirPressure,
            Enums.eLicenseType i_LicenseType, int i_EngineCapacity)
        {
            Wheels wheels = new Wheels(2, i_ManufacturerName, i_AirPressure, 33);
            ElectricMotorcycle electricMotorcycle = new ElectricMotorcycle(i_LicenseNumber, i_ModelName,
                wheels, i_RemainingChargerTime, i_LicenseType, i_EngineCapacity);

            return electricMotorcycle;
        }

        public static FuelCar MakeNewFuelCar(string i_LicenseNumber, string i_ModelName,
            string i_ManufacturerName, float i_AirPressure, float i_CurrentFuelAmount,
            Enums.eColor i_Color, Enums.eNumberOfDoors i_NumberOfDoors)
        {
            Wheels wheels = new Wheels(4, i_ManufacturerName, i_AirPressure, 31);
            FuelCar fuelCar = new FuelCar(i_LicenseNumber, i_ModelName, wheels, i_CurrentFuelAmount,
                i_Color, i_NumberOfDoors);

            return fuelCar;
        }

        public static ElectricCar MakeNewElectricCar(string i_LicenseNumber,
            string i_ModelName, float i_RemainingChargerTime, string i_ManufacturerName,
            float i_AirPressure, Enums.eColor i_Color, Enums.eNumberOfDoors i_NumberOfDoors)
        {
            Wheels wheels = new Wheels(4, i_ManufacturerName, i_AirPressure, 31);
            ElectricCar electricCar = new ElectricCar(i_LicenseNumber, i_ModelName,
                wheels, i_RemainingChargerTime, i_Color, i_NumberOfDoors);

            return electricCar;
        }

        public static FuelTruck MakeNewFuelTruck(string i_LicenseNumber, string i_ModelName,
            string i_ManufacturerName, float i_AirPressure, float i_CurrentFuelAmount,
            bool i_ContainsHazardousMaterial, float i_CargoVolume)
        {
            Wheels wheels = new Wheels(12, i_ManufacturerName, i_AirPressure, 26);
            FuelTruck fuelTruck = new FuelTruck(i_LicenseNumber, i_ModelName, wheels,
                i_CurrentFuelAmount, i_ContainsHazardousMaterial, i_CargoVolume);

            return fuelTruck;
        }

        public static VehicleInGarage MakeNewVehicleInGarage(string i_OwnerName,
            string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            VehicleInGarage vehicleInGarage = new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber,
                i_Vehicle);

            return vehicleInGarage;
        }
    }
}
