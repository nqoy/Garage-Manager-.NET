namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System.Text;

    public class FuelMotorcycle : Motorcycle
    {
        private const string k_FuelType = "Octan98";

        private const float k_MaxFuelCapacity = 5.8F;

        public FuelMotorcycle(string i_Model, string i_LiceneceNumber, float i_RemainingEnergy, Engine i_Engine, List<Wheel> i_ListOfWheels, int i_EngineCapacity, string i_LicenseType)
            : base(i_Model, i_LiceneceNumber, i_RemainingEnergy, i_Engine, i_ListOfWheels, i_EngineCapacity, i_LicenseType)
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
