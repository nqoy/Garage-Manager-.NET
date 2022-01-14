namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Vehicle
    {
        private string m_Model;

        private string m_LiceneceNumber;

        private float m_RemainingEnergyPercent;

        private Engine m_Engine;

        private List<Wheel> s_ListOfWheels;

        protected Vehicle(string i_Model, string i_LiceneceNumber, float i_RemainingEnergyPercent, Engine i_Engine, List<Wheel> i_ListOfWheels)
        {
            this.m_Model = i_Model;
            this.m_LiceneceNumber = i_LiceneceNumber;
            this.m_RemainingEnergyPercent = i_RemainingEnergyPercent;
            this.m_Engine = i_Engine;
            this.s_ListOfWheels = i_ListOfWheels;
        }

        public string Model
        {
            get
            {
                return this.m_Model;
            }

            set
            {
                this.m_Model = value;
            }
        }

        public string LiceneceNumber
        {
            get
            {
                return this.m_LiceneceNumber;
            }

            set
            {
                this.m_LiceneceNumber = value;
            }
        }

        public float RemainingEnergyPercent
        {
            get
            {
                return this.m_RemainingEnergyPercent;
            }

            set
            {
                this.m_RemainingEnergyPercent = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return this.m_Engine;
            }

            set
            {
                this.m_Engine = value;
            }
        }

        public List<Wheel> ListOfWheels
        {
            get
            {
                return this.s_ListOfWheels;
            }

            set
            {
                this.s_ListOfWheels = value;
            }
        }

        public static void InflateWheels(float i_amount, ref GarageVehicles io_Vehicle)
        {
            foreach (Wheel wheel in io_Vehicle.Vehicle.s_ListOfWheels)
            {
                wheel.CurrentAirPressure += i_amount;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.AppendLine($"Model: {this.m_Model}");
            vehicleDetails.AppendLine($"Licenece Number: {this.m_LiceneceNumber}");
            vehicleDetails.AppendLine($"Remaining Energy: {this.m_RemainingEnergyPercent}%");
            Wheel wheelRef = this.s_ListOfWheels.ElementAt(0);
            vehicleDetails.AppendLine($"Wheels manufacturer: {wheelRef.Manufacturer}");
            vehicleDetails.AppendLine($"Current wheels Air Pressure: {wheelRef.CurrentAirPressure}");

            return vehicleDetails.ToString();
        }
    }
}
