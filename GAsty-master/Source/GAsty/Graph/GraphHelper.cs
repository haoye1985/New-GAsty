using System.Drawing;
using System.Collections.Generic;
using GAsty.Utility;
using NodeGraphControl;
using Oasis;
using Oasis.Graph.Graph_Core;
using GAsty.Network.Core;
using GAsty.Forms;

namespace GAsty.Graph
{
    public static class GraphHelper
    {

        public static void BuildTransportGraph(GeoNetwork pNetwork)
        {
            OasisForms.DockGraph.nodeGraphPanel1.View.NodeCollection.Clear();
            foreach (var node in pNetwork.GeoNodeCollection)
            {
                Point graphPointLocation = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(new Point(node.X, node.Y));
                var nodeInGraph = new TransportNode(graphPointLocation.X, graphPointLocation.Y, OasisForms.DockGraph.nodeGraphPanel1.View, true, NodeEnum.Edge);
                nodeInGraph.Comment = node.ID.ToString();
                GraphHelper.AddGraphNode(OasisForms.DockGraph.nodeGraphPanel1, nodeInGraph); 
            }

            foreach (var link in pNetwork.GeoLinkCollection)
            {
                //Point screenPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(link.CentrolPoint);
                //var centroidInGraph = new TransportNode(screenPoint.X, screenPoint.Y, OasisForms.DockGraph.nodeGraphPanel1.View, true);
                //GraphHelper.AddGraphNode(OasisForms.DockGraph.nodeGraphPanel1, centroidInGraph);

                NodeGraphConnector InputLinkConnector = null;
                NodeGraphConnector CentralLinkConnector = null;
                NodeGraphConnector OutputLinkConnector = null;

                foreach (var node in OasisForms.DockGraph.nodeGraphPanel1.View.NodeCollection)
                {

                    Point FromPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(link.FromPoint);
                    Point CentrolPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(link.CentrolPoint);
                    Point ToPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(link.ToPoint);        

                    if (link.FromNode.X == node.X)
                    {
                        InputLinkConnector = node.Connectors[0];
                    }
                    //
                    if (link.CentrolPoint.X == node.X)
                    {
                        CentralLinkConnector = node.Connectors[0];
                    }

                    if (link.ToNode.X== node.X)
                    {
                        OutputLinkConnector = node.Connectors[0];
                    }

                    //if (InputLinkConnector != null && OutputLinkConnector != null && CentralLinkConnector != null)
                    if (InputLinkConnector != null && OutputLinkConnector != null)
                    {
                        var link1 = new TransLink(InputLinkConnector, CentralLinkConnector, OutputLinkConnector.DataType);
                        var link2 = new TransLink(CentralLinkConnector, OutputLinkConnector, OutputLinkConnector.DataType);
                        GraphHelper.AddGraphLink(OasisForms.DockGraph.nodeGraphPanel1, link1);
                        GraphHelper.AddGraphLink(OasisForms.DockGraph.nodeGraphPanel1, link2);
                    }
                }
            }

        }

        public static void UpdateGraphService(List<GeoNetwork> networkCollection)
        {
            if (networkCollection.Count > 0)
            {
                foreach (var network in State.ServiceNetworkCollection)
                {
                    foreach (var node in network.GetServiceNodeCollection())
                    {
                        foreach (var nodepattern in OasisForms.DockGraph.nodeGraphPanel1.View.NodeCollection)
                        {
                            if (nodepattern.Comment == node.ID.ToString())
                            {
                                nodepattern.Highlighted = true;
                            }
                        }
 
                    }

                }
            }
 
        }

        public static void BuildGraph(GeoNetwork pNetwork)
        {
            OasisForms.DockGraph.nodeGraphPanel1.View.NodeCollection.Clear();
            foreach (var node in pNetwork.GeoNodeCollection)
            {
                Point graphPointLocation = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(new Point(node.X, node.Y));

                if (node.NodeType == NodeEnum.Edge)
                {
                    TransportNode nodeInGraph1 = new TransportNode(graphPointLocation.X, graphPointLocation.Y, OasisForms.DockGraph.nodeGraphPanel1.View, true, NodeEnum.Node);
                    nodeInGraph1.Comment = node.ID.ToString();
                    GraphHelper.AddGraphID(OasisForms.DockGraph.nodeGraphPanel1, nodeInGraph1);
                }
                else if (node.NodeType == NodeEnum.Centroid)
                {
                    TransportNode nodeInGraph2 = new TransportNode(graphPointLocation.X, graphPointLocation.Y, OasisForms.DockGraph.nodeGraphPanel1.View, true, NodeEnum.Link);
                    nodeInGraph2.Comment = node.ID.ToString();
                    GraphHelper.AddGraphID(OasisForms.DockGraph.nodeGraphPanel1, nodeInGraph2);
                }
            }

            foreach (var link in pNetwork.GeoLinkCollection)
            {
                NodeGraphConnector InputLinkConnector = null;
                NodeGraphConnector CentralLinkConnector = null;
                NodeGraphConnector OutputLinkConnector = null;

                foreach (var node in OasisForms.DockGraph.nodeGraphPanel1.View.NodeCollection)
                //foreach (var node in pNetwork.GeoNodeCollection)
                {

                    Point FromPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(link.FromPoint);
                    Point CentrolPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(link.CentrolPoint);
                    Point ToPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(link.ToPoint);

                    if (System.Math.Abs(FromPoint.X - node.X) < 10 && System.Math.Abs(FromPoint.Y - node.Y) < 10)
                    {
                        InputLinkConnector = node.Connectors[0];
                    }

                    if (System.Math.Abs(CentrolPoint.X - node.X) < 10 && System.Math.Abs(CentrolPoint.Y - node.Y) < 10)
                    {
                        CentralLinkConnector = node.Connectors[0];
                    }

                    if (System.Math.Abs(ToPoint.X - node.X) < 10 && System.Math.Abs(ToPoint.Y - node.Y) < 10)
                    {
                        OutputLinkConnector = node.Connectors[0];
                    }

                    if (InputLinkConnector != null && OutputLinkConnector != null && CentralLinkConnector != null)
                    {
                        var link1 = new TransLink(InputLinkConnector, CentralLinkConnector, OutputLinkConnector.DataType);
                        var link2 = new TransLink(CentralLinkConnector, OutputLinkConnector, OutputLinkConnector.DataType);
                        var link3 = new TransLink(CentralLinkConnector, InputLinkConnector, OutputLinkConnector.DataType);
                        var link4 = new TransLink(OutputLinkConnector, CentralLinkConnector, OutputLinkConnector.DataType);
                        GraphHelper.AddGraphLink(OasisForms.DockGraph.nodeGraphPanel1, link1);
                        GraphHelper.AddGraphLink(OasisForms.DockGraph.nodeGraphPanel1, link2);
                        GraphHelper.AddGraphLink(OasisForms.DockGraph.nodeGraphPanel1, link3);
                        GraphHelper.AddGraphLink(OasisForms.DockGraph.nodeGraphPanel1, link4);
                    }
                }
            }
        }

        public static void AddGraphNode(NodeGraphPanel pPanel, TransportNode pNode)
        {
            pNode.ID = State.network.GeoNodeCollection.Count;
            //pNode.Comment = State.network.GeoNodeCollection.Count.ToString();
            pNode.Comment = pNode.ID.ToString();
            pPanel.AddNode(pNode);
        }

        public static void AddGraphID(NodeGraphPanel pPanel, TransportNode pNode)
        {
            pPanel.AddNode(pNode);
        }

        public static void AddGraphLink(NodeGraphPanel pPanel, TransLink pLink)
        {
            pPanel.LinkVisualStyle = LinkVisualStyle.Curve;
            pPanel.View.Links.Add(pLink);
        }

        public static Rectangle GraphNodeHitRect(Point pViewPoint)
        {
            var size = new Size(10, 10);
            var hitTestReg = new Rectangle(pViewPoint, size);
            return hitTestReg;
        }

        public static Point MapToGraphView(NodeGraphPanel pPanel, Point pLocation)
        {
            Point ViewPoint = pPanel.ControlToView(pLocation);
            return ViewPoint;
        }

    }
}
