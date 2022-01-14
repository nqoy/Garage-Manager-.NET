namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System.Text;

    public class FuelCar : Car
    {
        private const string k_FuelType = "Octan95";

        private const float k_MaxFuelCapacity = 48;

        public FuelCar(string i_Model, string i_LiceneceNumber, float i_RemainingEnergy, Engine i_Engine, List<Wheel> s_ListOfWheels, string i_CarColor, int i_NumberOfDoors)
            : base(i_Model, i_LiceneceNumber, i_RemainingEnergy, i_Engine, s_ListOfWheels, i_CarColor, i_NumberOfDoors)
        {
            this.Engine.EnergySourceType = k_FuelType;
        }

        public static float MaxFuelCapacity
        {
            get
            {
                return k_MaxFuelCapacity;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.Append(base.ToString());
            vehicleDetails.AppendLine($"Fuel Type: {k_FuelType}");
            vehicleDetails.AppendLine($"Remining Fuel in liters: {this.Engine.ReminingEnergySource}");
            vehicleDetails.Append($"Max Fuel Capacity in liters: {k_MaxFuelCapacity}");

            return vehicleDetails.ToString();
        }
    }
}
