namespace Ex03.GarageLogic
{
    using System;

    public class ValueOutOfRangeException : Exception
    {
        private float m_minValue;
        private float m_maxValue;

        public ValueOutOfRangeException(
            float i_MinValue,
            float i_MaxValue)
            : base(string.Format("Error in value range for current choice: Min: {0} Max: {1}", i_MinValue, i_MaxValue))
        {
            this.m_minValue = i_MinValue;
            this.m_maxValue = i_MaxValue;
        }
    }
}
