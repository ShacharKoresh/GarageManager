# Garage Manager
A Console application that is used to manage a vehicle garage using OOP design, including "Factory Method" design pattern.
The implementation of this project is separated into two parts: 
- The first part is GarageLogic which responsibale for the object model and for the logical entities of the system.
- The second part is GrageUI which responsibale for the user interface of this app on the console.

The system supplies the following functionality to the user:

- Insert a new vehicle into the garage. The user will be asked to select a vehicle type out of the supported vehicle types and to input the license number of the vehicle. If the vehicle is already in the garage (based on license number) the system will display an appropriate message and will use the vehicle that is already in the garage (in addition, the system will change the vehicle status to “In Repair”). Otherwise, a new object of that vehicle type will be created and the user will be prompted to input the values for the properties of his vehicle, according to the type of vehicle he wishes to add.
- Display a list of license numbers of all vehicles that are currently in the garage, with a filtering option based on the status of each vehicle.
- Change a certain vehicle’s status (according to a given license number and the new desired status).
- Inflate tires of certain vehicle to maximum (according to a given license number).
- Refuel a fuel-based vehicle (according to the given details: license number, fuel type and amount to fill).
- Charge an electric-based vehicle (according to the given details: license number and number of minutes to charge).
- Display all information about a certain vehicle (License number, Model name, Owner name, Status in the garage, Tire specifications (manufacturer and air pressure), Fuel status + Fuel type / Battery status, other relevant information based on vehicle type).
