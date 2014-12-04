using System;
using System.Collections.Generic;
using GAsty.Forms;
using GAsty.Network.Core;
using GAsty.Network.Visualisation;
using GAsty.Utility;
using Oasis;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Forms;
using SharpMap.Layers;

namespace GAsty.Network.Operation
{
    [Serializable]
    public class NetworkBuilder: IDisposable
    {
        private List<GeoNode> m_geoNodes;
        private List<GeoLink> m_geoLinks;
        private VectorLayer m_nodeLayer;
        private VectorLayer m_linkLayer;
        private NetworkVisualier m_visualiser;
        private MapBox m_map;
        private ShapeFile m_nodeFile;
        private ShapeFile m_linkFile;
        private GeoNetwork m_network;
        private NetworkDegree m_degreeComputer;
        private int m_NodeLayerSRID;
        private int m_LinkLayerSRID;

        private bool m_isCompleted;

        public NetworkBuilder(string pNodeFileName, string pLinkFileNam, MapBox pMapBox)
        {
            this.m_geoNodes = new List<GeoNode>();
            this.m_geoLinks = new List<GeoLink>();
            this.m_map = pMapBox;
            this.m_isCompleted = false;
            this.m_nodeFile = new ShapeFile(pNodeFileName);
            this.m_linkFile = new ShapeFile(pLinkFileNam);
            this.m_nodeLayer = new VectorLayer("Network Nodes");
            this.m_linkLayer = new VectorLayer("Network Links");
            this.m_network = new GeoNetwork();
            this.m_map.Paint += m_mapBox_Paint;
        }

        public void BuildNetworkToState()
        {
            BuildNodeNetwork();
            BuildLinkNetwork();
            BuildNetworkLayers();
            DistributeNetworkID();
            FindNetworkDegree();
        }

        public void FindNetworkDegree()
        {
            this.m_degreeComputer = new NetworkDegree(m_network);
            m_degreeComputer.FindNodeDegree();
        }

        private void DistributeNetworkID()
        {
            if (State.network.GeoNodeCollection.Count > 0 && State.network.GeoLinkCollection.Count > 0)
            {
                foreach(var node in State.network.GeoNodeCollection)
                {
                    foreach (var link in State.network.GeoLinkCollection)
                    {
                        // Here different shape layer might have different accuracy of data, therefore it need to spite the former part
                        // of the string, and the comparison o string to determine if they are in the same location
                        string[] nodeSplite = node.Coordinate.X.ToString("#0.000000000000").Split('.');
                        string[] linkSpliteFrom = link.FromNodeCoordinate.X.ToString("#0.000000000000").Split('.');
                        string[] linkSpliteTo = link.ToNodeCoordinate.X.ToString("#0.000000000000").Split('.');

                        if (nodeSplite[0].Equals(linkSpliteFrom[0])&&(nodeSplite[1].Substring(1, 4).Equals(linkSpliteFrom[1].Substring(1,4))))
                        {
                            link.FromNodeID = node.ID;
                        }

                        if (nodeSplite[0].Equals(linkSpliteTo[0]) && (nodeSplite[1].Substring(1,4).Equals(linkSpliteTo[1].Substring(1,4)))){
                            link.ToNodeID = node.ID;}
                    }

                    }
                }
        }

        private void BuildNodeNetwork()
        {
            if (m_nodeFile != null)
            {
                //m_nodeFile.FilterDelegate = delegate(FeatureDataRow row) { return row["name"] == "Action Town"; };
                m_nodeFile.Open();
                this.m_NodeLayerSRID = m_nodeFile.SRID;
                int featureCounter = m_nodeFile.GetFeatureCount();
                for (uint i = 0; i < featureCounter; i++)
                {
                    var feature = m_nodeFile.GetFeature(i);

                    // the name of the station
                    string kk = feature.ItemArray[1].ToString();
                    var node = new GeoNode(feature.ItemArray[1].ToString(), feature.Geometry.Coordinate, OasisForms.DockMap.mapBox1.Map, NodeEnum.Edge);
                    m_geoNodes.Add(node);
                    m_network.AddGeoEdgeNode(node, NodeEnum.Edge);
                }
                m_nodeFile.Close();
            }
        }
        private void BuildLinkNetwork()
        {
            if (m_linkFile != null)
            {
                m_linkFile.Open();
                this.m_LinkLayerSRID = m_linkFile.SRID;
                int featureCounter = m_linkFile.GetFeatureCount();
                for (uint i = 0; i < featureCounter; i++)
                {
                    var feature = m_linkFile.GetFeature(i);
                    var link = new GeoLink(feature.Geometry.Coordinates[0], feature.Geometry.Coordinates[1], OasisForms.DockMap.mapBox1.Map);
                    var node = new GeoNode(feature.Geometry.Centroid.Coordinate, OasisForms.DockMap.mapBox1.Map, NodeEnum.Centroid);
                    m_geoNodes.Add(node);
                    m_network.AddGeoCentroidNode(node, NodeEnum.Centroid);
                    m_geoLinks.Add(link);
                    m_network.AddGeoLink(link);
                }
                m_linkFile.Close();
            }
        }

        private void BuildNetworkLayers()
        {
            State.network = m_network;
            m_visualiser = new NetworkVisualier(State.network);
            m_nodeLayer = m_visualiser.GenerateNodeLayer();
            m_linkLayer = m_visualiser.GenerateLinkLayer();
            State.ServiceNodeLayer = m_nodeLayer;
            State.ServiceLinkLayer = m_linkLayer;
            OasisForms.DockMap.mapBox1.Map.Layers.Add(State.ServiceNodeLayer);
            m_isCompleted = true;
        }

        private void m_mapBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (State.RenderInfrastructure && State.network.GeoNodeCollection.Count > 0 || State.network.GeoLinkCollection.Count > 0 || m_isCompleted)
            {
                State.ServiceNodeLayer.Render(e.Graphics, m_map.Map);
                State.ServiceLinkLayer.Render(e.Graphics, m_map.Map);
            }

            if (State.RenderInfrastructure)
            {
                State.ServiceLinkLayer.Render(e.Graphics, m_map.Map);
                State.UpdateService = NetRiskLayer.CreateNodeRiskLayer(State.network);
                State.UpdateService.Render(e.Graphics, m_map.Map);
            }
        }

        void IDisposable.Dispose()
        {
            
        }

    }
}
