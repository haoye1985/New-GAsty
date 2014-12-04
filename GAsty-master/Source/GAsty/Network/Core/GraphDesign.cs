using System;
using System.Drawing;
using System.Windows.Forms;
using GAsty.Graph;
using NodeGraphControl;
using Oasis.Graph.Graph_Core;

namespace GAsty.Network.Core
{
    [Serializable]
    public class GraphDesign
    {
        public Point m_MouseLoc;
        public NodeGraphPanel _graphpanel;
        public NodeGraphConnector m_inputLinkConnector;
        public NodeGraphConnector m_outputLinkConnector;

        public GraphDesign(NodeGraphPanel pgraphPanel)
        {
            m_MouseLoc = Point.Empty;
            _graphpanel = pgraphPanel;
            _graphpanel.View.RegisterDataType(new InoperabilityDataType());
            _graphpanel.View.RegisterDataType(new OperabilityDataType());
            _graphpanel.View.RegisterDataType(new FloatDataType());
            _graphpanel.MouseDown += GraphMouseDown;
            _graphpanel.MouseMove += GraphMouseMove;
            _graphpanel.MouseUp += GraphMouseUp;
            _graphpanel.MouseWheel += GraphMouseWheel;
        }

        private void GraphMouseDown(object sender, MouseEventArgs e)
        {

        }

        private void GraphMouseMove(object sender, MouseEventArgs e)
        {

        }

        private void GraphMouseUp(object sender, MouseEventArgs e)
        {

        }

        private void GraphMouseWheel(object sender, MouseEventArgs e)
        {

        }


    }
}
