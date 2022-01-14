namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;

        private float m_CurrentAirPressure;

        private float m_MaxAirPressure;

        public Wheel(float i_CurrentWheelsAirPressure, string i_WheelsManufacturer, float i_MaxAirPressure)
        {
            this.m_Manufacturer = i_WheelsManufacturer;
            this.m_CurrentAirPressure = i_CurrentWheelsAirPressure;
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public string Manufacturer
        {
            get
            {
                return this.m_Manufacturer;
            }

            set
            {
                this.m_Manufacturer = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return this.m_CurrentAirPressure;
            }

            set
            {
                this.m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return this.m_MaxAirPressure;
            }
        }
    }
}
