using System;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Serialization;
using BruTile.Web.Wms;
using GAsty.Forms;
using GAsty.Network.Core;
using GAsty.Network.Operation;
using GAsty.Network.Service;
using GAsty.Network.Visualisation;
using GAsty.Utility;
using System.Collections.Generic;
using SharpMap.Data.Providers;
using SharpMap.Forms;
using SharpMap.Layers;

namespace GAsty
{
    public class ServiceBuilder
    {
        #region Private Field

        private MapBox m_map;
        private List<GeoNode> m_geoNodes;
        private List<GeoLink> m_geoLinks;
        private ShapeFile m_nodeServiceFile;
        private ShapeFile m_linkServiceFile;
        private VectorLayer m_nodeServiceLayer;
        private VectorLayer m_linkServiceLayer;
        private NetworkVisualier m_visualiser;
        private GeoNetwork m_serviceNetwork;
        private int m_NodeServiceLayerSRID;
        private int m_LinkServiceLayerSRID;
        private bool m_isCompleted;

        #endregion

        # region Constructors

        public ServiceBuilder(string pNodeFileName, string pLinkFileNam, MapBox pMapBox)
        {
            this.m_geoNodes = new List<GeoNode>();
            this.m_geoLinks = new List<GeoLink>();
            this.m_serviceNetwork = new GeoNetwork();
            this.m_nodeServiceFile = new ShapeFile(pNodeFileName);
            this.m_linkServiceFile = new ShapeFile(pLinkFileNam);
            this.m_nodeServiceLayer = new VectorLayer("NodeService");
            this.m_linkServiceLayer = new VectorLayer("LinkService");
            this.m_map = pMapBox;
            this.m_map.Paint += m_mapBox_Paint;
        }

        public ServiceBuilder(string pID, string pName, string pNodeFileName, string pLinkFileNam, MapBox pMapBox)
        {
            this.m_geoNodes = new List<GeoNode>();
            this.m_geoLinks = new List<GeoLink>();
            this.m_serviceNetwork = new GeoNetwork();
            this.m_serviceNetwork.NetworkID = pID;
            this.m_serviceNetwork.NetworkName = pName;

            this.m_nodeServiceFile = new ShapeFile(pNodeFileName);
            this.m_linkServiceFile = new ShapeFile(pLinkFileNam);
            this.m_nodeServiceLayer = new VectorLayer("NodeService");
            this.m_linkServiceLayer = new VectorLayer("LinkService");
            this.m_map = pMapBox;
            this.m_map.Paint += m_mapBox_Paint;
        }

        #endregion

        #region Methods

        public void BuildServiceToNetwork()
        {
            BuildNodeService();
            BuildLinkService();
            BuildServiceLayers();
        }

        public void BuildNodeService()
        {
            if (m_nodeServiceFile != null)
            {
                m_nodeServiceFile.Open();
                this.m_NodeServiceLayerSRID = m_nodeServiceFile.SRID;
                int featureCounter = m_nodeServiceFile.GetFeatureCount();
                for (uint i = 0; i < featureCounter; i++)
                {
                    var feature = m_nodeServiceFile.GetFeature(i);
                    var node = new GeoNode(feature.Geometry.Coordinate, OasisForms.DockMap.mapBox1.Map, NodeEnum.Edge);
                    m_geoNodes.Add(node);
                    m_serviceNetwork.AddGeoEdgeNode(node, NodeEnum.Edge);
                }
                m_nodeServiceFile.Close();
            }
        }

        public void BuildLinkService()
        {
            if (m_linkServiceFile != null)
            {
                m_linkServiceFile.Open();
                this.m_LinkServiceLayerSRID = m_linkServiceFile.SRID;
                int featureCounter = m_linkServiceFile.GetFeatureCount();
                for (uint i = 0; i < featureCounter; i++)
                {
                    var feature = m_linkServiceFile.GetFeature(i);
                    var link = new GeoLink(feature.Geometry.Coordinates[0], feature.Geometry.Coordinates[1],OasisForms.DockMap.mapBox1.Map);
                    m_geoLinks.Add(link);
                    m_serviceNetwork.AddGeoLink(link);
                }

                m_linkServiceFile.Close();
            }
        }

        public void BuildServiceLayers()
        {
                State.ServiceNetworkCollection.Add(m_serviceNetwork);
                foreach (var network in State.ServiceNetworkCollection)
                {
                    m_visualiser = new NetworkVisualier(network);
                    var nodeServiceFile = m_visualiser.GenerateNodeLayer();
                    var linkServiceFile = m_visualiser.GenerateLinkLayer();
                    State.ServiceLayersCollection.Add(nodeServiceFile);
                    State.ServiceLayersCollection.Add(linkServiceFile);
                }

                foreach (var layer in State.ServiceLayersCollection)
                {
                    OasisForms.DockMap.mapBox1.Map.Layers.Add(layer);
                }
                m_isCompleted = true;
                State.RenderService = true;
        }

        #endregion

        #region Events

        private void m_mapBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (State.RenderService)
            {
                foreach (var network in State.ServiceNetworkCollection)
                {
                    State.ServiceRouteNodeLayer = ServiceRender.RenderServiceNodeLayer(network);
                    State.ServiceRouteLinkLayer = ServiceRender.RenderServiceLinkLayer(network);
                    State.ServiceRouteNodeLayer.Render(e.Graphics, m_map.Map);
                    State.ServiceRouteLinkLayer.Render(e.Graphics, m_map.Map);
                }
            }
        }

        #endregion

    }
}
