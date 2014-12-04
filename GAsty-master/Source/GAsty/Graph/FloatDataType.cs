using System.Drawing;
using NodeGraphControl;

namespace GAsty.Graph
{
    public class FloatDataType : NodeGraphDataType
    {
        public FloatDataType()
        {
            this.m_LinkPen = new Pen(Color.FromArgb(216, 0, 255));
            this.m_LinkArrowBrush = new SolidBrush(Color.FromArgb(216, 0, 255));
            this.m_ConnectorOutlinePen = new Pen(Color.Gray);
            this.m_ConnectorFillBrush = new SolidBrush(Color.Orange);
            this.m_TypeName = "Boolean";
        }

        public override string ToString()
        {
            return this.m_TypeName;
        }


    }
}
