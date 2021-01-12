using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    internal class Validation
    {
        internal static bool AlreadyExists(string i_LicenseNumber)
        {
            bool containsVehicle = GarageLogic.Garage.m_VehiclesInGarage.ContainsKey(i_LicenseNumber);

            if (containsVehicle)
            {
                Console.WriteLine("Vehicle is already in garage- No more details needed.");
                GarageLogic.Garage.m_VehiclesInGarage[i_LicenseNumber].Condition =
                    GarageLogic.Enums.eGarageCondition.GettingFixed;
            }

            return containsVehicle;
        }

        internal static void CheckUserInputNumberInt(string i_UserChoice, int i_MinValue,
            int i_MaxValue, string i_Key)
        {
            bool validNumber, inRange;
            string newChoice = "";
            int parsedNumber;

            validNumber = int.TryParse(i_UserChoice, out parsedNumber);
            inRange = parsedNumber <= i_MaxValue && parsedNumber >= i_MinValue;
            while (!validNumber || !inRange)
            {
                if (!validNumber)
                {
                    Console.WriteLine("Your input should be a number. Try again:");
                }
                else if (!inRange)
                {
                    Console.WriteLine("Invalid range. Number should be between {0} and {1}. Try again:",
                        i_MinValue, i_MaxValue);
                }

                newChoice = Console.ReadLine();
                validNumber = int.TryParse(newChoice, out parsedNumber);
                inRange = parsedNumber <= i_MaxValue && parsedNumber >= i_MinValue;
            }

            GarageUI.s_AllParams[i_Key] = parsedNumber;
        }

        internal static void CheckUserInputNumberFloat(string i_UserChoice, float i_MinValue,
            float i_MaxValue, string i_Key)
        {
            bool validNumber, inRange;
            string newChoice = "";
            float parsedNumber;

            validNumber = float.TryParse(i_UserChoice, out parsedNumber);
            inRange = parsedNumber <= i_MaxValue && parsedNumber >= i_MinValue;
            while (!validNumber || !inRange)
            {
                if (!validNumber)
                {
                    Console.WriteLine("Your input should be a number. Try again:");
                }
                else if (!inRange)
                {
                    Console.WriteLine("Invalid range. Number should be between {0} and {1}. Try again:",
                        i_MinValue, i_MaxValue);
                }

                newChoice = Console.ReadLine();
                validNumber = float.TryParse(newChoice, out parsedNumber);
                inRange = parsedNumber <= i_MaxValue && parsedNumber >= i_MinValue;
            }

            GarageUI.s_AllParams[i_Key] = parsedNumber;
        }

        internal static void ParseFloat(string i_Response, string i_Key)
        {
            bool isParsed;
            float parsedNumber;

            isParsed = float.TryParse(i_Response, out parsedNumber);
            while (!isParsed)
            {
                Console.WriteLine("Your input must be a valid number. Try again:");
                i_Response = Console.ReadLine();
                isParsed = float.TryParse(i_Response, out parsedNumber);
            }

            GarageUI.s_AllParams[i_Key] = parsedNumber;
        }

        internal static void ParseInt(string i_Response, string i_Key)
        {
            bool isParsed;
            int parsedNumber;

            isParsed = int.TryParse(i_Response, out parsedNumber);
            while (!isParsed)
            {
                Console.WriteLine("Your input must be a valid number. Try again:");
                i_Response = Console.ReadLine();
                isParsed = int.TryParse(i_Response, out parsedNumber);
            }

            GarageUI.s_AllParams[i_Key] = parsedNumber;
        }

        internal static void IsFuel()
        {
            GarageLogic.VehicleInGarage vehicleInGarage;
            bool isFuel = false;

            while (!isFuel)
            {
                IsInGarage();
                try
                {
                    vehicleInGarage = (GarageLogic.VehicleInGarage)GarageUI.s_AllParams["VehicleInGarage"];
                    GarageLogic.Garage.CheckIfFuelVehicle(vehicleInGarage.Vehicle);
                    isFuel = true;
                    GarageUI.s_AllParams["FuelVehicle"] = (GarageLogic.Fuel)(((GarageLogic.VehicleInGarage)
                        GarageUI.s_AllParams["VehicleInGarage"]).Vehicle);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Invalid input- vehicle must be fuel based.");
                }
            }
        }

        internal static void IsElectric()
        {
            GarageLogic.VehicleInGarage vehicleInGarage;
            GarageLogic.Electric electricVehicle;
            bool isElectric = false;

            while (!isElectric)
            {
                IsInGarage();
                try
                {
                    vehicleInGarage = (GarageLogic.VehicleInGarage)GarageUI.s_AllParams["VehicleInGarage"];
                    GarageLogic.Garage.CheckIfElectricVehicle(vehicleInGarage.Vehicle);
                    isElectric = true;
                    electricVehicle = (GarageLogic.Electric)vehicleInGarage.Vehicle;
                    GarageUI.s_AllParams["ElectricVehicle"] = electricVehicle;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Invalid input- vehicle must be electric.");
                }
            }
        }

        internal static void IsInGarage()
        {
            string choice;
            bool inGarage = false;

            while (!inGarage)
            {
                Console.Clear();
                GarageUI.ReadLicenseNumber();
                try
                {
                    GarageUI.s_AllParams["VehicleInGarage"] = GarageLogic.Garage.CheckIfInGarage
                        (GarageUI.s_AllParams["LicenseNumber"].ToString());
                    inGarage = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("There is no vehicle in the garage" +
                        " corresponding to the given license number.{0}Would you like to:{0}1. Go back{0}2. Insert license number",
                        Environment.NewLine);
                    choice = Console.ReadLine();
                    CheckUserInputNumberInt(choice, 1, 2, "UserChoice");
                    if ((int)GarageUI.s_AllParams["UserChoice"] == 1)
                    {
                        GarageUI.RunGarage();
                        break;
                    }
                }
            }
        }

        internal static void CheckBoolParam(string i_Response)
        {
            bool contains = false;

            while (!i_Response.Equals("True") && !i_Response.Equals("False"))
            {
                Console.WriteLine("Your input is not valid. Please enter one of the following: <True/False>");
                i_Response = Console.ReadLine();
            }

            if (i_Response == "True")
            {
                contains = true;
            }

            GarageUI.s_AllParams["ContainsHazardousMaterial"] = contains;
        }
    }
}
