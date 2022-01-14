namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System.Text;
    using Ex03.GarageLogic.Enums;

    public abstract class Car : Vehicle
    {
        private const int k_NumberOfCarWheels = 4;

        private const float k_MaxWheelsAirPressure = 29;

        private string m_CarColor;

        private int m_NumberOfDoors;

        public Car(string i_Model, string i_LiceneceNumber, float i_RemainingEnergy, Engine i_Engine, List<Wheel> i_ListOfWheels, string i_CarColor, int i_NumberOfDoors)
            : base(i_Model, i_LiceneceNumber, i_RemainingEnergy, i_Engine, i_ListOfWheels)
        {
            this.m_CarColor = i_CarColor;
            this.m_NumberOfDoors = i_NumberOfDoors;
        }

        public static int NumberOfCarWheels
        {
            get
            {
                return k_NumberOfCarWheels;
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
            vehicleDetails.AppendLine($"Max Wheels Air Pressure: {k_MaxWheelsAirPressure}");
            vehicleDetails.AppendLine($"Vehicle Type: {enumVehicleType.eVehicleType.Car.ToString()}");
            vehicleDetails.AppendLine($"Car Color: {this.m_CarColor}");
            vehicleDetails.AppendLine($"Number Of Doors: {this.m_NumberOfDoors}");

            return vehicleDetails.ToString();
        }
    }
}
