namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System.Text;
    using Ex03.GarageLogic.Enums;

    public class Truck : Vehicle
    {
        private const string k_FuelType = "Soler";

        private const float k_MaxFuelLiterCapacity = 130;

        private const int k_NumberOfTruckWheels = 16;

        private const float k_MaxWheelsAirPressure = 25;

        private float m_CargoCapacity;

        private bool m_IsCarringCooledCargo;

        public Truck(string i_Model, string i_LiceneceNumber, float i_RemainingEnergy, Engine i_Engine, List<Wheel> i_ListOfWheels, float i_CargoCapacity, bool i_IsCarringCooledCargo)
    : base(i_Model, i_LiceneceNumber, i_RemainingEnergy, i_Engine, i_ListOfWheels)
        {
            this.m_CargoCapacity = i_CargoCapacity;
            this.m_IsCarringCooledCargo = i_IsCarringCooledCargo;
            this.Engine.EnergySourceType = k_FuelType;
        }

        public static float MaxFuelLiterCapacity
        {
            get
            {
                return k_MaxFuelLiterCapacity;
            }
        }

        public static int NumberOfTruckWheels
        {
            get
            {
                return k_NumberOfTruckWheels;
            }
        }

        public static float MaxWheelsAirPressure
        {
            get
            {
                return k_MaxWheelsAirPressure;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.Append(base.ToString());
            vehicleDetails.AppendLine($"Vehicle Type: {enumVehicleType.eVehicleType.Truck.ToString()}");
            vehicleDetails.AppendLine($"Cargo Capacity: {this.m_CargoCapacity}");
            vehicleDetails.AppendLine($"Carring Cooled Cargo: {this.m_IsCarringCooledCargo}");
            vehicleDetails.AppendLine($"Fuel Type: {k_FuelType}");
            vehicleDetails.AppendLine($"Remining Fuel in liters: {this.Engine.EnergySourceType}");
            vehicleDetails.Append($"Max Fuel Capacity in liters: {k_MaxFuelLiterCapacity}");

            return vehicleDetails.ToString();
       }
    }
}
