using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeGraphControl;

namespace Oasis.Graph.Graph_Core
{
    public class TransportData : NodeGraphData
    {
        public float Value { get { return m_fValue; } set { m_fValue = value; } }
        private float m_fValue;

        public TransportData(float p_Value)
        {
            m_fValue = p_Value;
        }
    }
}
