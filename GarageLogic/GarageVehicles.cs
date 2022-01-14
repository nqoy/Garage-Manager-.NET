namespace Ex03.GarageLogic
{
    using System;
    using System.Text;
    using Ex03.GarageLogic.Enums;

    public class GarageVehicles
    {
        private string m_VehicleStatus;

        private Vehicle m_Vehicle;

        private string m_VehicleOwnerName;

        private string m_VehicleOwnerPhoneNumber;

        public GarageVehicles()
        {
        }

        public GarageVehicles(Vehicle i_newVehicle, string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleStatus)
        {
            this.m_Vehicle = i_newVehicle;
            this.m_VehicleOwnerName = i_OwnerName;
            this.m_VehicleOwnerPhoneNumber = i_OwnerPhoneNumber;
            this.m_VehicleStatus = enumVehicleGarageStatus.eVehicleGarageStatus.InRepair.ToString();
        }

        public string VehicleStatus
        {
            get
            {
                return this.m_VehicleStatus;
            }

            set
            {
                this.m_VehicleStatus = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return this.m_Vehicle;
            }

            set
            {
                this.m_Vehicle = value;
            }
        }

        public string VehicleOwnerName
        {
            get
            {
                return this.m_VehicleOwnerName;
            }

            set
            {
                this.m_VehicleOwnerName = value;
            }
        }

        public string VehicleOwnerPhoneNumber
        {
            get
            {
                return this.m_VehicleOwnerPhoneNumber;
            }

            set
            {
                this.m_VehicleOwnerPhoneNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.AppendLine($"{Environment.NewLine}Vehicle Owner Name: {this.m_VehicleOwnerName}");
            vehicleDetails.AppendLine($"Vehicle Owner Phone Number: {this.m_VehicleOwnerPhoneNumber}");
            vehicleDetails.AppendLine($"Vehicle Status: {this.m_VehicleStatus}");

            return vehicleDetails.ToString();
        }
    }
}
