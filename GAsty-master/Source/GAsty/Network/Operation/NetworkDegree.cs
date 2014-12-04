using System;
using System.Collections.Generic;
using GAsty.Network.Core;
using Oasis;

namespace GAsty.Network.Operation
{
    public class NetworkDegree
    {
        private GeoNetwork m_network;
        private List<GeoLink> m_nodeLinkedEdges;

        public NetworkDegree(GeoNetwork pNetwork)
        {
            this.m_network = pNetwork;
            this.m_nodeLinkedEdges = new List<GeoLink>();
        }

        public void FindNodeDegree()
        {
            if (this.m_network.GetInfraNodeCollection().Count > 0 && this.m_network.GetInfraLinkCollection().Count> 0)
            {
                foreach (var node in m_network.GetInfraNodeCollection())
                {
                    int nodeDegree = 0;
                    foreach (var link in m_network.GetInfraLinkCollection())
                    {
                        string[] nodeSplite = node.Coordinate.X.ToString("#0.000000000000").Split('.');
                        string[] linkSpliteFrom = link.FromNodeCoordinate.X.ToString("#0.000000000000").Split('.');
                        string[] linkSpliteTo = link.ToNodeCoordinate.X.ToString("#0.000000000000").Split('.');

                        if (nodeSplite[0].Equals(linkSpliteFrom[0]) && (nodeSplite[1].Substring(1, 3).Equals(linkSpliteFrom[1].Substring(1, 3))) || nodeSplite[0].Equals(linkSpliteTo[0]) && (nodeSplite[1].Substring(1, 3).Equals(linkSpliteTo[1].Substring(1, 3))))
                        {
                            nodeDegree++;
                            m_nodeLinkedEdges.Add(link);
                        }
                    }

                    node.Degree = nodeDegree;
                    node.ConnectedGeoLinks = m_nodeLinkedEdges;
                }
            }
            else
            {
                throw new Exception("The network is an empty network, please check the availability of the network!");
            }
        }

        public GeoNetwork Network
        {
            get { return m_network; }
            set { m_network = value; }
        }

        public List<GeoLink> NodeLinkedEdges
        {
            get { return m_nodeLinkedEdges; }
            set { m_nodeLinkedEdges = value; }
        }   
    }
}
