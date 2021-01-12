using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float m_MinValue;
        public float m_MaxValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : base()
        {
            this.m_MinValue = i_MinValue;
            this.m_MaxValue = i_MaxValue;
        }

        public ValueOutOfRangeException(string i_UserMessage, float i_MinValue, float i_MaxValue) :
            base (i_UserMessage)
        {
            this.m_MinValue = i_MinValue;
            this.m_MaxValue = i_MaxValue;
        }

        public ValueOutOfRangeException(Exception i_InnerError, string i_UserMessage,
            float i_MinValue, float i_MaxValue) : base(i_UserMessage, i_InnerError)
        {
            this.m_MinValue = i_MinValue;
            this.m_MaxValue = i_MaxValue;
        }

        public float MinValue
        {
            get
            {
                return this.m_MinValue;
            }
        }

        public float MaxValue
        {
            get
            {
                return this.m_MaxValue;
            }
        }
    }
}
