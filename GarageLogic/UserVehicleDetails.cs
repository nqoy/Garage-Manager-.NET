namespace Ex03.GarageLogic
{
    public class UserVehicleDetails
    {
        private string m_License_Number;

        private string m_Engine_Type;

        private string m_Model;

        private int m_Vehicle_Type;

        private string m_Car_Color;

        private int m_Number_Of_Doors;

        private string m_License_Type;

        private int m_Engine_Volume;

        private float m_Cargo_Capacity;

        private bool m_Carring_Cold_Cargo;

        private float m_Remaining_Energy;

        private string m_Status;

        private string m_Wheels_Manufacturer;

        private float m_Current_Wheels_Air_Pressure;

        private string m_Owner_Name;

        private string m_Owner_Phone_Number;

        public string License
        {
            get
            {
                return this.m_License_Number;
            }

            set
            {
                this.m_License_Number = value;
            }
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

        public int VehicleType
        {
            get
            {
                return this.m_Vehicle_Type;
            }

            set
            {
                this.m_Vehicle_Type = value;
            }
        }

        public string EngineType
        {
            get
            {
                return this.m_Engine_Type;
            }

            set
            {
                this.m_Engine_Type = value;
            }
        }

        public string CarColor
        {
            get
            {
                return this.m_Car_Color;
            }

            set
            {
                this.m_Car_Color = value;
            }
        }

        public int NumberOfDoors
        {
            get
            {
                return this.m_Number_Of_Doors;
            }

            set
            {
                this.m_Number_Of_Doors = value;
            }
        }

        public string LicenseType
        {
            get
            {
                return this.m_License_Type;
            }

            set
            {
                this.m_License_Type = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return this.m_Engine_Volume;
            }

            set
            {
                this.m_Engine_Volume = value;
            }
        }

        public float CargoCapacity
        {
            get
            {
                return this.m_Cargo_Capacity;
            }

            set
            {
                this.m_Cargo_Capacity = value;
            }
        }

        public bool CarringColdCargo
        {
            get
            {
                return this.m_Carring_Cold_Cargo;
            }

            set
            {
                this.m_Carring_Cold_Cargo = value;
            }
        }

        public float RemainingEnergy
        {
            get
            {
                return this.m_Remaining_Energy;
            }

            set
            {
                this.m_Remaining_Energy = value;
            }
        }

        public string Status
        {
            get
            {
                return this.m_Status;
            }

            set
            {
                this.m_Status = value;
            }
        }

        public string WheelsManufacturer
        {
            get
            {
                return this.m_Wheels_Manufacturer;
            }

            set
            {
                this.m_Wheels_Manufacturer = value;
            }
        }

        public float CurrentWheelsAirPressure
        {
            get
            {
                return this.m_Current_Wheels_Air_Pressure;
            }

            set
            {
                this.m_Current_Wheels_Air_Pressure = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return this.m_Owner_Name;
            }

            set
            {
                this.m_Owner_Name = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return this.m_Owner_Phone_Number;
            }

            set
            {
                this.m_Owner_Phone_Number = value;
            }
        }
    }
}
