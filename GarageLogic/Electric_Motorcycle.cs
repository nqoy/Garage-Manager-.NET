namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System.Text;

    public class Electric_Motorcycle : Motorcycle
    {
        private const float K_MaxBatteryHourCapacity = 2.3F;

        public Electric_Motorcycle(string i_Model, string i_LiceneceNumber, float i_RemainingEnergy, Engine i_Engine, List<Wheel> i_ListOfWheels, int i_EngineCapacity, string i_LicenseType)
            : base(i_Model, i_LiceneceNumber, i_RemainingEnergy, i_Engine, i_ListOfWheels, i_EngineCapacity, i_LicenseType)
        {
            this.Engine.EnergySourceType = "Elecricity";
        }

        public static float MaxBatteryHourCapacity
        {
            get
            {
                return K_MaxBatteryHourCapacity;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.Append(base.ToString());
            vehicleDetails.AppendLine($"Remining Battery hours: {this.Engine.ReminingEnergySource}");
            vehicleDetails.Append($"Battery max capacity in hours: {K_MaxBatteryHourCapacity}");

            return vehicleDetails.ToString();
        }
    }
}
