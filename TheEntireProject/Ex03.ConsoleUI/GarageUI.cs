using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    internal class GarageUI
    {
        public static string[] s_AllVehicleTypes = { null, "Electric Car", "Electric Motorcycle", "Fuel Car",
            "Fuel Motorcycle", "Fuel Truck" };
        public static Dictionary<string, object> s_AllParams = new Dictionary<string, object>();

        internal static void RunGarage()
        {
            Console.Clear();
            ReadChoiceFromUser();
            Choice();
            backToMenu();
        }

        internal static void ReadChoiceFromUser()
        {
            string inputNumberAsString, message;
            string[] options = {"Insert new vehicle", "Show list of license numbers", "Change vehicle condition",
            "Inflate vehicle wheels to maximum", "Fuel up a vehicle", "Charge an electric vehicle",
            "Show full details of a vehicle"};

            message = string.Format("Hello and welcome to Shachar & Yael's garage! These are your options:" +
                "{0}{0}1. {1}{0}2. {2}{0}3. {3}{0}4. {4}{0}5. {5}{0}6. {6}{0}7. {7}{0}8. Exit Garage{0}{0}" +
                "Please press a number according to your wanted option:",
                Environment.NewLine, options[0], options[1], options[2], options[3], options[4], options[5], options[6]);
            Console.WriteLine(message);
            inputNumberAsString = Console.ReadLine();
            Validation.CheckUserInputNumberInt(inputNumberAsString, 1, 8, "UserChoice");
        }

        private static void Choice()
        {
            int userChoice = (int)s_AllParams["UserChoice"];
            bool containsVehicle;

            Console.Clear();
            switch (userChoice)
            {
                case 1:
                    ReadLicenseNumber();
                    containsVehicle = Validation.AlreadyExists(s_AllParams["LicenseNumber"].ToString());
                    if (containsVehicle)
                    {
                        break;
                    }

                    readVehicleType();
                    typeChosen();
                    break;

                case 2:
                    getUserDecision();
                    break;

                case 3:
                    readAndChangeNewCondition();
                    break;

                case 4:
                    inflateVehicleWheels();
                    break;

                case 5:
                    Validation.IsFuel();
                    readFuelType();
                    readFuelAmount();
                    break;

                case 6:
                    Validation.IsElectric();
                    readChargerAmount();
                    break;

                case 7:
                    showAllDetails();
                    break;

                case 8:
                    Console.Clear();
                    Console.WriteLine("You are the best customer ever! Come visit us again :) GOODBYE");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
            }
        }

        private static void readVehicleType()
        {
            string vehicleType;

            Console.WriteLine("Which vehicle would you like to insert? {0}1. {1}{0}2. {2}{0}3. {3}{0}4. {4}{0}5. {5}",
                Environment.NewLine, s_AllVehicleTypes[1], s_AllVehicleTypes[2], s_AllVehicleTypes[3], s_AllVehicleTypes[4],
                s_AllVehicleTypes[5]);
            vehicleType = Console.ReadLine();
            Validation.CheckUserInputNumberInt(vehicleType, 1, 5, "VehicleType");
        }

        private static void typeChosen()
        {
            string typeChosen = s_AllVehicleTypes[(int)s_AllParams["VehicleType"]];

            switch (typeChosen)
            {
                case "Electric Car":
                    getAllParamsElectricCar();
                    break;

                case "Electric Motorcycle":
                    getAllParamsElectricMotorcycle();
                    break;

                case "Fuel Car":
                    getAllParamsFuelCar();
                    break;

                case "Fuel Motorcycle":
                    getAllParamsFuelMotorcycle();
                    break;

                case "Fuel Truck":
                    getAllParamsFuelTruck();
                    break;
            }
        }

        private static void getAllParamsElectricCar()
        {
            getOwnerName();
            getOwnerPhoneNumber();
            getModelName();
            getManufacturerName();
            getAirPressure(31f);
            getColor();
            getNumberOfDoors();
            getRemainingChargerTime((1.8f * 60f));
            GarageLogic.ElectricCar elecCar = GarageLogic.NewVehicle.MakeNewElectricCar
                (s_AllParams["LicenseNumber"].ToString(),
                s_AllParams["ModelName"].ToString(), (float)s_AllParams["RemainingChargerTime"],
                s_AllParams["ManufacturerName"].ToString(), (float)s_AllParams["AirPressure"],
                (GarageLogic.Enums.eColor)s_AllParams["Color"],
                (GarageLogic.Enums.eNumberOfDoors)s_AllParams["NumberOfDoors"]);
            GarageLogic.VehicleInGarage elecCarInGarage = GarageLogic.NewVehicle.MakeNewVehicleInGarage
                (s_AllParams["OwnerName"].ToString(), s_AllParams["OwnerPhoneNumber"].ToString(), elecCar);
            GarageLogic.Garage.m_VehiclesInGarage.Add(s_AllParams["LicenseNumber"].ToString(), elecCarInGarage);
        }

        private static void getAllParamsElectricMotorcycle()
        {
            getOwnerName();
            getOwnerPhoneNumber();
            getModelName();
            getManufacturerName();
            getAirPressure(33f);
            getLicenseType();
            getEngineCapacity();
            getRemainingChargerTime((1.4f * 60f));
            GarageLogic.ElectricMotorcycle elecMotor = GarageLogic.NewVehicle.MakeNewElectricMotorcycle
                (s_AllParams["LicenseNumber"].ToString(), s_AllParams["ModelName"].ToString(),
                (float)s_AllParams["RemainingChargerTime"], s_AllParams["ManufacturerName"].ToString(),
                (float)s_AllParams["AirPressure"], (GarageLogic.Enums.eLicenseType)s_AllParams["LicenseType"],
                (int)s_AllParams["EngineCapacity"]);
            GarageLogic.VehicleInGarage elecMotorInGarage = GarageLogic.NewVehicle.MakeNewVehicleInGarage
                (s_AllParams["OwnerName"].ToString(), s_AllParams["OwnerPhoneNumber"].ToString(), elecMotor);
            GarageLogic.Garage.m_VehiclesInGarage.Add(s_AllParams["LicenseNumber"].ToString(), elecMotorInGarage);
        }

        private static void getAllParamsFuelCar()
        {
            getOwnerName();
            getOwnerPhoneNumber();
            getModelName();
            getManufacturerName();
            getAirPressure(31f);
            getFuelAmount(55);
            getColor();
            getNumberOfDoors();
            GarageLogic.FuelCar fuelCar = GarageLogic.NewVehicle.MakeNewFuelCar
                (s_AllParams["LicenseNumber"].ToString(),
                s_AllParams["ModelName"].ToString(), s_AllParams["ManufacturerName"].ToString(),
                (float)s_AllParams["AirPressure"], (float)s_AllParams["CurrentFuelAmount"],
                (GarageLogic.Enums.eColor)s_AllParams["Color"],
                (GarageLogic.Enums.eNumberOfDoors)s_AllParams["NumberOfDoors"]);
            GarageLogic.VehicleInGarage fuelCarInGarage = GarageLogic.NewVehicle.MakeNewVehicleInGarage
                (s_AllParams["OwnerName"].ToString(), s_AllParams["OwnerPhoneNumber"].ToString(), fuelCar);
            GarageLogic.Garage.m_VehiclesInGarage.Add(s_AllParams["LicenseNumber"].ToString(), fuelCarInGarage);
        }

        private static void getAllParamsFuelMotorcycle()
        {
            getOwnerName();
            getOwnerPhoneNumber();
            getModelName();
            getManufacturerName();
            getAirPressure(33f);
            getFuelAmount(8);
            getLicenseType();
            getEngineCapacity();
            GarageLogic.FuelMotorcycle fuelMotor = GarageLogic.NewVehicle.MakeNewFuelMotorcycle(
                s_AllParams["LicenseNumber"].ToString(), s_AllParams["ModelName"].ToString(),
                s_AllParams["ManufacturerName"].ToString(), (float)s_AllParams["AirPressure"],
                (float)s_AllParams["CurrentFuelAmount"], (GarageLogic.Enums.eLicenseType)s_AllParams["LicenseType"],
                (int)s_AllParams["EngineCapacity"]);
            GarageLogic.VehicleInGarage fuelMotorInGarage = GarageLogic.NewVehicle.MakeNewVehicleInGarage
                (s_AllParams["OwnerName"].ToString(), s_AllParams["OwnerPhoneNumber"].ToString(), fuelMotor);
            GarageLogic.Garage.m_VehiclesInGarage.Add(s_AllParams["LicenseNumber"].ToString(), fuelMotorInGarage);
        }

        private static void getAllParamsFuelTruck()
        {
            getOwnerName();
            getOwnerPhoneNumber();
            getModelName();
            getManufacturerName();
            getAirPressure(26);
            getFuelAmount(110);
            getContainsHazardousMaterial();
            getCargoVolume();
            GarageLogic.FuelTruck fuelTruck = GarageLogic.NewVehicle.MakeNewFuelTruck(
               s_AllParams["LicenseNumber"].ToString(), s_AllParams["ModelName"].ToString(),
               s_AllParams["ManufacturerName"].ToString(), (float)s_AllParams["AirPressure"],
               (float)s_AllParams["CurrentFuelAmount"], (bool)s_AllParams["ContainsHazardousMaterial"],
               (float)s_AllParams["CargoVolume"]);
            GarageLogic.VehicleInGarage fuelTruckInGarage = GarageLogic.NewVehicle.MakeNewVehicleInGarage
                (s_AllParams["OwnerName"].ToString(), s_AllParams["OwnerPhoneNumber"].ToString(), fuelTruck);
            GarageLogic.Garage.m_VehiclesInGarage.Add(s_AllParams["LicenseNumber"].ToString(), fuelTruckInGarage);
        }

        private static void getOwnerName()
        {
            string ownerName;

            Console.WriteLine("Please insert the vehicle's owner name:");
            ownerName = Console.ReadLine();
            s_AllParams["OwnerName"] = ownerName;         
        }

        private static void getOwnerPhoneNumber()
        {
            string phoneNumber;

            Console.WriteLine("Please insert the owner's phone number:");
            phoneNumber = Console.ReadLine();
            s_AllParams["OwnerPhoneNumber"] = phoneNumber;
        }

        private static void getModelName()
        {
            string modelName;

            Console.WriteLine("Please insert the model of the vehicle:");
            modelName = Console.ReadLine();
            s_AllParams["ModelName"] = modelName;
        }

        private static void getManufacturerName()
        {
            string manufacturerName;

            Console.WriteLine("Please insert wheels manufacturer:");
            manufacturerName = Console.ReadLine();
            s_AllParams["ManufacturerName"] = manufacturerName;
        }

        private static void getAirPressure(float i_MaxAirPressure)
        {
            string airPressure;

            Console.WriteLine("Please insert wheels air pressure:");
            airPressure = Console.ReadLine();
            Validation.CheckUserInputNumberFloat(airPressure, 0f, i_MaxAirPressure, "AirPressure");
        }

        private static void getFuelAmount(float i_MaxFuelAmount)
        {
            string fuelAmount;

            Console.WriteLine("Please insert the fuel amount:");
            fuelAmount = Console.ReadLine();
            Validation.CheckUserInputNumberFloat(fuelAmount, 0f, i_MaxFuelAmount, "CurrentFuelAmount");
        }

        private static void getColor()
        {
            string color;

            Console.WriteLine("Please insert the color of the vehicle {0}", createStringOfColors());
            color = Console.ReadLine();
            Validation.CheckUserInputNumberInt(color, 1, 4, "EnumIndicator");
            convertIntToColor((int)s_AllParams["EnumIndicator"]);
        }

        private static void getNumberOfDoors()
        {
            string numberOfDoors;

            Console.WriteLine("Please insert the number of doors in the vehicle {0}", createStringOfNumberOfDoors());
            numberOfDoors = Console.ReadLine();
            Validation.CheckUserInputNumberInt(numberOfDoors, 2, 5, "EnumIndicator");
            convertIntToNumberOfDoors((int)s_AllParams["EnumIndicator"]);
        }

        private static void getLicenseType()
        {
            string licenseType;

            Console.WriteLine("Please insert the color of the vehicle {0}", createStringOfLicenseTypes());
            licenseType = Console.ReadLine();
            Validation.CheckUserInputNumberInt(licenseType, 1, 4, "EnumIndicator");
            convertIntToLicenseType((int)s_AllParams["EnumIndicator"]);
        }

        private static void getEngineCapacity()
        {
            string engineCapacity;

            Console.WriteLine("Please insert the engine capacity of the vehicle:");
            engineCapacity = Console.ReadLine();
            Validation.ParseInt(engineCapacity, "EngineCapacity");
        }

        private static void getContainsHazardousMaterial()
        {
            string response;

            Console.WriteLine("Please let us know is your truck contains hazardous material: <True/False>");
            response = Console.ReadLine();
            Validation.CheckBoolParam(response);
        }

        private static void getCargoVolume()
        {
            string cargoVolume;

            Console.WriteLine("Please insert the cargo volume of the vehicle:");
            cargoVolume = Console.ReadLine();
            Validation.ParseFloat(cargoVolume, "CargoVolume");
        }

        private static void getRemainingChargerTime(float i_MaxChargerTime)
        {
            string fuelAmount;

            Console.WriteLine("Please insert the remaining charger time (in minutes):");
            fuelAmount = Console.ReadLine();
            Validation.CheckUserInputNumberFloat(fuelAmount, 0f, i_MaxChargerTime, "RemainingChargerTime");
        }

        private static void getUserDecision()
        {
            string choice, condition = null;

            Console.WriteLine("Would you like to filter the list according to a Garage Condition? <Y/N>");
            choice = Console.ReadLine();
            while (choice != "Y" && choice != "N")
            {
                Console.WriteLine("Your input should be <Y/N>. Try again:");
                choice = Console.ReadLine();
            }
            
            if (choice == "Y")
            {
                Console.Clear();
                Console.WriteLine("Please enter the number representing the condition you would like to see: {0}",
                    createStringOfConditions());
                condition = Console.ReadLine();
                Validation.CheckUserInputNumberInt(condition, 1, 3, "EnumIndicator");
                convertIntToCondition((int)s_AllParams["EnumIndicator"]);
            }

            printListByCondition(condition);
        }

        private static void printListByCondition(string i_Condition)
        {
            bool v_isUserCondition, printed = false;

            if (GarageLogic.Garage.m_VehiclesInGarage.Count == 0)
            {
                Console.WriteLine("No vehicles in the garage.");
            }
            else
            {
                foreach (string licenseNumber in GarageLogic.Garage.m_VehiclesInGarage.Keys)
                {
                    if (i_Condition == null)
                    {
                        Console.WriteLine(licenseNumber);
                        printed = true;
                    }
                    else
                    {
                        v_isUserCondition = GarageLogic.Garage.m_VehiclesInGarage[licenseNumber].Condition ==
                            (GarageLogic.Enums.eGarageCondition)s_AllParams["Condition"];
                        if (v_isUserCondition)
                        {
                            Console.WriteLine(licenseNumber);
                            printed = true;
                        }
                    }
                }

                if (!printed && i_Condition != null)
                {
                    Console.Clear();
                    Console.WriteLine("No vehicles in the garage with the given condition.");
                }
            }
        }

        private static void readAndChangeNewCondition()
        {
            string newCondition, garageConditions = createStringOfConditions();
            GarageLogic.Enums.eGarageCondition parsedCondition;
            bool inGarage = false;

            while (!inGarage)
            {
                try
                {
                    Validation.IsInGarage();
                    inGarage = true;
                    Console.WriteLine("Please insert the new condition {0}:", garageConditions);
                    newCondition = Console.ReadLine();
                    Validation.CheckUserInputNumberInt(newCondition, 1, 3, "EnumIndicator");
                    convertIntToCondition((int)s_AllParams["EnumIndicator"]);
                    parsedCondition = (GarageLogic.Enums.eGarageCondition)s_AllParams["Condition"];
                    GarageLogic.Garage.ChangeCondition((s_AllParams["LicenseNumber"]).ToString(), parsedCondition);
                    Console.WriteLine("Vehicle condition was changed successfully!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("There is no vehicle in the garage corresponding to the given license number.");
                }
            }
        }

        private static void inflateVehicleWheels()
        {
            GarageLogic.VehicleInGarage vehicleInGarage;
            bool inGarage = false;

            while (!inGarage)
            {
                try
                {
                    Validation.IsInGarage();
                    inGarage = true;
                    vehicleInGarage = (GarageLogic.VehicleInGarage)s_AllParams["vehicleInGarage"];
                    vehicleInGarage.Vehicle.Wheels.AirPressure = vehicleInGarage.Vehicle.Wheels.MaxAirPressure;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("There is no vehicle in the garage corresponding to the given license number.");
                }
            }
        }

        private static void readFuelType()
        {
            string fuelType;
            GarageLogic.Enums.eFuelType parsedFuelType;
            bool matchType = false;

            while (!matchType)
                try
                {
                    Console.WriteLine("Please enter the fuel type you would like to use: {0}",
                        createStringOfFuelTypes());
                    fuelType = Console.ReadLine();
                    Validation.CheckUserInputNumberInt(fuelType, 1, 4, "EnumIndicator");
                    convertIntToFuelType((int)s_AllParams["EnumIndicator"]);
                    parsedFuelType = (GarageLogic.Enums.eFuelType)s_AllParams["FuelType"];
                    ((GarageLogic.Fuel)s_AllParams["FuelVehicle"]).MatchFuelType(parsedFuelType); 
                    matchType = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("The fuel type does not match the required fuel type for this vehicle.");
                }
        }

        private static void readFuelAmount()
        {
            bool isValidAmount = false, isParsedAmount;
            string amount;
            float maxToAdd = 0, fuelToAdd, maxFuelAmount, currentFuelAmount;
            GarageLogic.Fuel fuelVehicle;
            GarageLogic.Enums.eFuelType fuelType;

            while (!isValidAmount)
            {
                try
                {
                    Console.WriteLine("Please enter the amount of fuel to add:");
                    amount = Console.ReadLine();
                    isParsedAmount = float.TryParse(amount, out fuelToAdd);
                    while (!isParsedAmount)
                    {
                        Console.WriteLine("Fuel Amount must be a number. Try again:");
                        amount = Console.ReadLine();
                        isParsedAmount = float.TryParse(amount, out fuelToAdd);
                    }

                    fuelVehicle = (GarageLogic.Fuel)s_AllParams["FuelVehicle"];
                    maxFuelAmount = fuelVehicle.MaxFuelAmount;
                    currentFuelAmount = fuelVehicle.CurrentFuelAmount;
                    maxToAdd = (maxFuelAmount - currentFuelAmount);
                    fuelType = (GarageLogic.Enums.eFuelType)s_AllParams["FuelType"];
                    fuelVehicle.Refueling(fuelToAdd, fuelType);
                    isValidAmount = true;
                }
                catch (GarageLogic.ValueOutOfRangeException valEx)
                {
                    Console.WriteLine("Input is not valid- fuel amount can not pass {0}.", maxToAdd);
                }
            }
        }

        private static void readChargerAmount()
        {
            bool isParsedMinutes, isValidAmount = false;
            float MaxMinutesToAdd = 0, minutesToAdd, maxChargerAmount, remainingChargerAmount;
            GarageLogic.Electric electricVehicle;
            string minutes;

            while (!isValidAmount)
            {
                try
                {
                    Console.WriteLine("Please enter how many minutes to charge:");
                    minutes = Console.ReadLine();
                    isParsedMinutes = float.TryParse(minutes, out minutesToAdd);
                    while (!isParsedMinutes)
                    {
                        Console.WriteLine("Invalid Minutes Input. Try again:");
                        minutes = Console.ReadLine();
                        isParsedMinutes = float.TryParse(minutes, out minutesToAdd);
                    }

                    electricVehicle = (GarageLogic.Electric)s_AllParams["ElectricVehicle"];
                    maxChargerAmount = electricVehicle.MaxChargerTime;
                    remainingChargerAmount = electricVehicle.RemainingChargerTime;
                    MaxMinutesToAdd = maxChargerAmount - remainingChargerAmount;
                    electricVehicle.Recharge(minutesToAdd);
                    isValidAmount = true;
                }
                catch (GarageLogic.ValueOutOfRangeException ex)
                {
                    Console.WriteLine("minutes passed the maximum. Please insert at most {0}", MaxMinutesToAdd);
                }
            }
        }

        private static void showAllDetails()
        {
            Validation.IsInGarage();
            Console.WriteLine(s_AllParams["VehicleInGarage"].ToString());
        }

        internal static void ReadLicenseNumber()
        {
            string line;

            Console.WriteLine("Please insert license number:");
            line = Console.ReadLine();
            s_AllParams["LicenseNumber"] = line;
        }

        private static string createStringOfConditions()
        {
            Array conditionArr = Enum.GetValues(typeof(GarageLogic.Enums.eGarageCondition));
            string result;

            result = string.Format("{0}1. {1}{0}2. {2}{0}3. {3}{0}" +
               "Please press a number according to your wanted option:",
               Environment.NewLine, conditionArr.GetValue(0), conditionArr.GetValue(1), conditionArr.GetValue(2));

            return result;
        }

        private static string createStringOfNumberOfDoors()
        {
            Array numberOfDoorsArr = Enum.GetValues(typeof(GarageLogic.Enums.eNumberOfDoors));
            string result;

            result = string.Format("{0}2. {1}{0}3. {2}{0}4. {3}{0}5. {4}{0}" +
               "Please press a number according to your wanted option:",
               Environment.NewLine, numberOfDoorsArr.GetValue(0), numberOfDoorsArr.GetValue(1),
               numberOfDoorsArr.GetValue(2), numberOfDoorsArr.GetValue(3));

            return result;
        }

        private static string createStringOfFuelTypes()
        {
            Array fuelTypesArr = Enum.GetValues(typeof(GarageLogic.Enums.eFuelType));
            string result;

            result = string.Format("{0}1. {1}{0}2. {2}{0}3. {3}{0}4. {4}{0}" +
               "Please press a number according to your wanted option:",
               Environment.NewLine, fuelTypesArr.GetValue(0), fuelTypesArr.GetValue(1),
               fuelTypesArr.GetValue(2), fuelTypesArr.GetValue(3));

            return result;
        }

        private static string createStringOfLicenseTypes()
        {
            Array licenseTypesArr = Enum.GetValues(typeof(GarageLogic.Enums.eLicenseType));
            string result;

            result = string.Format("{0}1. {1}{0}2. {2}{0}3. {3}{0}4. {4}{0}" +
               "Please press a number according to your wanted option:",
               Environment.NewLine, licenseTypesArr.GetValue(0), licenseTypesArr.GetValue(1),
               licenseTypesArr.GetValue(2), licenseTypesArr.GetValue(3));

            return result;
        }

        private static string createStringOfColors()
        {
            Array colorsArr = Enum.GetValues(typeof(GarageLogic.Enums.eColor));
            string result;

            result = string.Format("{0}1. {1}{0}2. {2}{0}3. {3}{0}4. {4}{0}" +
               "Please press a number according to your wanted option:",
               Environment.NewLine, colorsArr.GetValue(0), colorsArr.GetValue(1),
               colorsArr.GetValue(2), colorsArr.GetValue(3));

            return result;
        }

        private static void convertIntToColor(int i_Indicator)
        {
            if (i_Indicator == 1)
            {
                s_AllParams["Color"] = GarageLogic.Enums.eColor.Red;
            }

            if (i_Indicator == 2)
            {
                s_AllParams["Color"] = GarageLogic.Enums.eColor.Blue;
            }

            if (i_Indicator == 3)
            {
                s_AllParams["Color"] = GarageLogic.Enums.eColor.Black;
            }

            if (i_Indicator == 4)
            {
                s_AllParams["Color"] = GarageLogic.Enums.eColor.Grey;
            }
        }

        private static void convertIntToNumberOfDoors(int i_Indicator)
        {
            if (i_Indicator == 2)
            {
                s_AllParams["NumberOfDoors"] = GarageLogic.Enums.eNumberOfDoors.Two;
            }

            if (i_Indicator == 3)
            {
                s_AllParams["NumberOfDoors"] = GarageLogic.Enums.eNumberOfDoors.Three;
            }

            if (i_Indicator == 4)
            {
                s_AllParams["NumberOfDoors"] = GarageLogic.Enums.eNumberOfDoors.Four;
            }

            if (i_Indicator == 5)
            {
                s_AllParams["NumberOfDoors"] = GarageLogic.Enums.eNumberOfDoors.Five;
            }
        }

        private static void convertIntToLicenseType(int i_Indicator)
        {
            if (i_Indicator == 1)
            {
                s_AllParams["LicenseType"] = GarageLogic.Enums.eLicenseType.A;
            }

            if (i_Indicator == 2)
            {
                s_AllParams["LicenseType"] = GarageLogic.Enums.eLicenseType.A1;
            }

            if (i_Indicator == 3)
            {
                s_AllParams["LicenseType"] = GarageLogic.Enums.eLicenseType.A2;
            }

            if (i_Indicator == 4)
            {
                s_AllParams["LicenseType"] = GarageLogic.Enums.eLicenseType.B;
            }
        }

        private static void convertIntToFuelType(int i_Indicator)
        {
            if (i_Indicator == 1)
            {
                s_AllParams["FuelType"] = GarageLogic.Enums.eFuelType.Soler;
            }

            if (i_Indicator == 2)
            {
                s_AllParams["FuelType"] = GarageLogic.Enums.eFuelType.Octan95;
            }

            if (i_Indicator == 3)
            {
                s_AllParams["FuelType"] = GarageLogic.Enums.eFuelType.Octan96;
            }

            if (i_Indicator == 4)
            {
                s_AllParams["FuelType"] = GarageLogic.Enums.eFuelType.Octan98;
            }
        }

        private static void convertIntToCondition(int i_Indicator)
        {
            if (i_Indicator == 1)
            {
                s_AllParams["Condition"] = GarageLogic.Enums.eGarageCondition.GettingFixed;
            }

            if (i_Indicator == 2)
            {
                s_AllParams["Condition"] = GarageLogic.Enums.eGarageCondition.Fixed;
            }

            if (i_Indicator == 3)
            {
                s_AllParams["Condition"] = GarageLogic.Enums.eGarageCondition.Paid;
            }
        }

        private static void backToMenu()
        {
            string choice;

            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Operation succeeded! Would you like to choose another one? <Y/N>");
            choice = Console.ReadLine();
            while (choice != "Y" && choice != "N")
            {
                Console.WriteLine("Your input should be <Y/N>. Try again:");
                choice = Console.ReadLine();
            }

            if (choice == "N")
            {
                Console.Clear();
                Console.WriteLine("You are the best customer ever! Come visit us again :) GOODBYE");
                Console.ReadLine();
            }

            if (choice == "Y")
            {
                RunGarage();
            }
        }
    }
}
