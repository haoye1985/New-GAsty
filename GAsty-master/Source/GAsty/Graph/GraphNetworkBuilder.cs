using System.Collections.Generic;
using System.Drawing;
using GAsty.Forms;
using GAsty.Network.Core;
using Oasis;
using SharpMap;
using SharpMap.Forms;
using ZedGraph;

namespace GAsty.Graph
{
    public class GraphNetworkBuilder
    {
        private List<GeoNode> m_nodeCollection;
        private List<GeoLink> m_linkCollection; 

        public GraphNetworkBuilder(GeoNetwork network)
        {
            this.m_nodeCollection = network.GetInfraNodeCollection();
            this.m_linkCollection = network.GetInfraLinkCollection();
        }

        public void BuildGraphNode()
        {
            foreach (var node in m_nodeCollection)
            {           
                //PointF mapscreenPoint = OasisForms.DockMap.mapBox1.Map.WorldToImage(node.Coordinate);   
                //float distanceX = (float)(node.Coordinate.X - OasisForms.DockMap.mapBox1.Map.Center.X)/1000;
                //float distanceY = (float)(node.Coordinate.Y - OasisForms.DockMap.mapBox1.Map.Center.Y)/1000;
                PointF screenPoint1 = new PointF(node.X/1000, node.Y/1000);  
      
                //PointF screenPoint1 = new PointF(mapscreenPoint.X / 70, mapscreenPoint.Y / 70);
                //Point graphPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(Point.Ceiling(screenPoint1));

                //var nodeItem1 = new TransportNode((int)screenPoint1.X, (int)screenPoint1.Y, OasisForms.DockGraph.nodeGraphPanel1.View, true);
                //var nodeItem1 = new TransportNode((int)screenPoint1.X, (int)screenPoint1.Y, OasisForms.DockGraph.nodeGraphPanel1.View, true);
                Point graphPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(Point.Ceiling(screenPoint1));
                var nodeItem1 = new TransportNode(graphPoint.X, graphPoint.Y, OasisForms.DockGraph.nodeGraphPanel1.View, true, NodeEnum.Edge);
                GraphHelper.AddGraphNode(OasisForms.DockGraph.nodeGraphPanel1, nodeItem1);

                //PointF screenPoint = OasisForms.DockMap.mapBox1.Map.WorldToImage(node.Coordinate);
                //PointF screenPoint1 = new PointF(screenPoint.X / 70, screenPoint.Y / 70);
                //Point graphPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(Point.Ceiling(screenPoint1));
                //var nodeItem1 = new TransportNode(graphPoint.X, graphPoint.Y, OasisForms.DockGraph.nodeGraphPanel1.View, true);
                //GraphHelper.AddGraphNode(OasisForms.DockGraph.nodeGraphPanel1, nodeItem1);
            }

            //Point clickPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(imagePos.Location);
            //var nodeItem = new TransportNode(clickPoint.X, clickPoint.Y, OasisForms.DockGraph.nodeGraphPanel1.View, true);
            //GraphHelper.AddGraphNode(OasisForms.DockGraph.nodeGraphPanel1, nodeItem);
        }


    }
}
