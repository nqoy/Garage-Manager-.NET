namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using Ex03.GarageLogic.Enums;

    public class ObjectFactory
    {
        public static GarageVehicles CreateVehicle(ref UserVehicleDetails i_VehicleDetails)
        {
            Vehicle newVehicle = null;
            List<Wheel> s_ListOfWheels = new List<Wheel>();

            switch (i_VehicleDetails.VehicleType.ToString())
            {
                case "1":
                    for (int i = 0; i < Car.NumberOfCarWheels; i++)
                    {
                        Wheel wheel = new Wheel(i_VehicleDetails.CurrentWheelsAirPressure, i_VehicleDetails.WheelsManufacturer, Car.MaxWheelsAirPressure);

                        s_ListOfWheels.Add(wheel);
                    }

                    if (i_VehicleDetails.EngineType.Equals(enumEngineTypes.eEngineTypes.Electric.ToString()))
                    {
                        Engine electricCarEngine = new Engine(ElectricCar.MaxBatteryHourCapacity, i_VehicleDetails.RemainingEnergy, i_VehicleDetails.EngineType);

                        newVehicle = new ElectricCar(i_VehicleDetails.Model, i_VehicleDetails.License, i_VehicleDetails.RemainingEnergy, electricCarEngine, s_ListOfWheels, i_VehicleDetails.CarColor.ToString(), i_VehicleDetails.NumberOfDoors);
                    }
                    else
                    {
                        Engine fuelCarEngine = new Engine(FuelCar.MaxFuelCapacity, i_VehicleDetails.RemainingEnergy, i_VehicleDetails.EngineType);

                        newVehicle = new FuelCar(i_VehicleDetails.Model, i_VehicleDetails.License, i_VehicleDetails.RemainingEnergy, fuelCarEngine, s_ListOfWheels, i_VehicleDetails.CarColor.ToString(), i_VehicleDetails.NumberOfDoors);
                    }

                    break;

                case "2":
                    for (int i = 0; i < Motorcycle.NumberOfMotorcycleWheels; i++)
                    {
                        Wheel wheel = new Wheel(i_VehicleDetails.CurrentWheelsAirPressure, i_VehicleDetails.WheelsManufacturer, Motorcycle.MaxWheelsAirPressure);

                        s_ListOfWheels.Add(wheel);
                    }

                    if (i_VehicleDetails.EngineType.Equals(enumEngineTypes.eEngineTypes.Electric.ToString()))
                    {
                        Engine electricMotorcycleEngine = new Engine(Electric_Motorcycle.MaxBatteryHourCapacity, i_VehicleDetails.RemainingEnergy, i_VehicleDetails.EngineType);

                        newVehicle = new Electric_Motorcycle(i_VehicleDetails.Model, i_VehicleDetails.License, i_VehicleDetails.RemainingEnergy, electricMotorcycleEngine, s_ListOfWheels, i_VehicleDetails.EngineVolume, i_VehicleDetails.LicenseType);
                    }
                    else
                    {
                        Engine fuelMotorcycleEngine = new Engine(FuelMotorcycle.MaxFuelCapacity, i_VehicleDetails.RemainingEnergy, i_VehicleDetails.EngineType);

                        newVehicle = new FuelMotorcycle(i_VehicleDetails.Model, i_VehicleDetails.License, i_VehicleDetails.RemainingEnergy, fuelMotorcycleEngine, s_ListOfWheels, i_VehicleDetails.EngineVolume, i_VehicleDetails.LicenseType);
                    }

                    break;

                case "3":
                    for (int i = 0; i < Truck.NumberOfTruckWheels; i++)
                    {
                        Wheel wheel = new Wheel(i_VehicleDetails.CurrentWheelsAirPressure, i_VehicleDetails.WheelsManufacturer, Car.MaxWheelsAirPressure);

                        s_ListOfWheels.Add(wheel);
                    }

                    Engine fuelTruckEngine = new Engine(Truck.MaxFuelLiterCapacity, i_VehicleDetails.RemainingEnergy, i_VehicleDetails.EngineType);

                    newVehicle = new Truck(i_VehicleDetails.Model, i_VehicleDetails.License, i_VehicleDetails.RemainingEnergy, fuelTruckEngine, s_ListOfWheels, i_VehicleDetails.CargoCapacity, i_VehicleDetails.CarringColdCargo);
                    break;
            }

            GarageVehicles vehicleToGarage = new GarageVehicles(newVehicle, i_VehicleDetails.OwnerName, i_VehicleDetails.OwnerPhoneNumber, i_VehicleDetails.Status.ToString());

            return vehicleToGarage;
        }
    }
}
