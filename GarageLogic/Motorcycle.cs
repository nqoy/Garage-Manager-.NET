namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System.Text;
    using Ex03.GarageLogic.Enums;

    public abstract class Motorcycle : Vehicle
    {
        private const int k_NumberOfMotorcycleWheels = 2;

        private const float k_MaxWheelsAirPressure = 25;

        private int m_EngineVolume;

        private string m_LicenseType;

        protected Motorcycle(string i_Model, string i_LiceneceNumber, float i_RemainingEnergy, Engine i_Engine, List<Wheel> i_ListOfWheels, int i_EngineCapacity, string i_LicenseType)
            : base(i_Model, i_LiceneceNumber, i_RemainingEnergy, i_Engine, i_ListOfWheels)
        {
            this.m_EngineVolume = i_EngineCapacity;
            this.m_LicenseType = i_LicenseType;
        }

        public static int NumberOfMotorcycleWheels
        {
            get
            {
                return k_NumberOfMotorcycleWheels;
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
            vehicleDetails.AppendLine($"Vehicle Type: {enumVehicleType.eVehicleType.Motorcycle.ToString()}");
            vehicleDetails.AppendLine($"Engine Volume: {this.m_EngineVolume}");
            vehicleDetails.AppendLine($"License Type: {this.m_LicenseType}");

            return vehicleDetails.ToString();
        }
    }
}
