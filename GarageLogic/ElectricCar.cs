namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System.Text;

    internal class ElectricCar : Car
    {
        private const float K_MaxBatteryHourCapacity = 2.6F;

        public ElectricCar(string i_Model, string m_iiceneceNumber, float i_RemainingEnergy, Engine i_Engine, List<Wheel> i_ListOfWheels, string i_CarColor, int i_NumberOfDoors)
            : base(i_Model, m_iiceneceNumber, i_RemainingEnergy, i_Engine, i_ListOfWheels, i_CarColor, i_NumberOfDoors)
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
