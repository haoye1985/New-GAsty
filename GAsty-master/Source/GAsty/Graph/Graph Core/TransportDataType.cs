using System.Drawing;
using NodeGraphControl;

namespace Oasis.Graph.Graph_Core
{
    public class InoperabilityDataType : NodeGraphDataType
    {
         public InoperabilityDataType()
        {
            this.m_LinkPen = new Pen(Color.FromArgb(216, 0, 255));
            this.m_LinkArrowBrush = new SolidBrush(Color.FromArgb(216, 0, 255));
            this.m_ConnectorOutlinePen = new Pen(Color.FromArgb(46, 139, 87));
            this.m_ConnectorFillBrush = new SolidBrush(Color.Red);
            this.m_TypeName = "Inoperability";
        }

        public override string ToString()
        {
            return this.m_TypeName;
        }
    }

    public class OperabilityDataType : NodeGraphDataType
    {
        public OperabilityDataType()
        {
            this.m_LinkPen = new Pen(Color.FromArgb(216, 0, 255));
            this.m_LinkArrowBrush = new SolidBrush(Color.FromArgb(216, 0, 255));
            this.m_ConnectorOutlinePen = new Pen(Color.FromArgb(46, 139, 87));
            this.m_ConnectorFillBrush = new SolidBrush(Color.LimeGreen);
            this.m_TypeName = "Operability";
        }

        public override string ToString()
        {
            return this.m_TypeName;
        }
    }

}
