namespace Ex03.GarageLogic
{
    public class Engine
    {
        private float m_MaxEnergySourceCapacity;
        private float m_ReminingEnergySource;
        private string m_EnergySourceType;
        private string m_EngineType;

        public Engine(float i_MaxEnergyCapacity, float i_CurrentEnergyPercent, string i_EngineType)
        {
            this.m_MaxEnergySourceCapacity = i_MaxEnergyCapacity;
            this.m_ReminingEnergySource = (i_CurrentEnergyPercent / 100) * this.m_MaxEnergySourceCapacity;
            this.m_EngineType = i_EngineType;
        }

        public float MaxEnergySourceCapacity
        {
            get
            {
                return this.m_MaxEnergySourceCapacity;
            }

            set
            {
                this.m_MaxEnergySourceCapacity = value;
            }
        }

        public float ReminingEnergySource
        {
            get
            {
                return this.m_ReminingEnergySource;
            }

            set
            {
                this.m_ReminingEnergySource = value;
            }
        }

        public string EnergySourceType
        {
            get
            {
                return this.m_EnergySourceType;
            }

            set
            {
                this.m_EnergySourceType = value;
            }
        }

        public string EngineType
        {
            get
            {
                return this.m_EngineType;
            }

            set
            {
                this.m_EngineType = value;
            }
        }

        public static void RefeillEnergySource(float i_FillAmount, ref GarageVehicles io_Vehicle)
        {
            io_Vehicle.Vehicle.Engine.m_ReminingEnergySource += i_FillAmount;
            io_Vehicle.Vehicle.RemainingEnergyPercent = io_Vehicle.Vehicle.Engine.m_ReminingEnergySource /
                io_Vehicle.Vehicle.Engine.m_MaxEnergySourceCapacity * 100;
        }
    }
}
