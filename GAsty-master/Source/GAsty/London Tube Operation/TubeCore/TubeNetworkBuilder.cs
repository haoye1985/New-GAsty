using System;
using System.Collections.Generic;
using GAsty.Forms;
using GAsty.Network.Core;
using GAsty.Network.Operation;
using SharpMap.Data.Providers;
using SharpMap.Forms;
using SharpMap.Layers;

namespace GAsty.Tube
{
    public class TubeNetworkBuilder
    {
        private ShapeFile m_nodeFile;
        private ShapeFile m_linkFile;
        private List<GeoNode> m_geoNodes;
        private List<GeoLink> m_geoLinks;
        private VectorLayer m_lineNodeLayer;
        private VectorLayer m_lineLinkLayer;
        private MapBox m_map;

        private NetworkVisualier m_visualiser;
        private GeoNetwork m_Line;
        private List<GeoNetwork> m_mutipleLines;


        public TubeNetworkBuilder(MapBox pMapBox)
        {
            this.m_geoNodes = new List<GeoNode>();
            this.m_geoLinks = new List<GeoLink>();
            this.m_lineNodeLayer = new VectorLayer("NodeService");
            this.m_lineLinkLayer = new VectorLayer("LinkService");
            this.m_map = pMapBox;
            this.m_map.Paint += m_mapBox_Paint;
        }

        public void BuildTubeLinesFromShape(string pNodeFileName, string pLinkFileNam)
        {
            this.m_nodeFile = new ShapeFile(pNodeFileName);
            this.m_linkFile = new ShapeFile(pLinkFileNam);
            BuildTubeStations();
            BuildTubeLinks();
        }

        private void BuildTubeStations()
        {
            if (m_nodeFile != null)
            {
                m_nodeFile.Open();
                int featureCounter = m_nodeFile.GetFeatureCount();
                for (uint i = 0; i < featureCounter; i++)
                {
                    var feature = m_nodeFile.GetFeature(i);
                    var node = new GeoNode(feature.Geometry.Coordinate, OasisForms.DockMap.mapBox1.Map, NodeEnum.Edge);
                    m_geoNodes.Add(node);
                    m_Line.AddGeoEdgeNode(node, NodeEnum.Edge);
                }
                m_Line.NetworkName = m_nodeFile.Filename;
                m_mutipleLines.Add(m_Line);
                m_nodeFile.Close();
            }
        }

        private void BuildTubeLinks()
        {
            if (m_linkFile!= null)
            {
                m_linkFile.Open();
                int featureCounter = m_linkFile.GetFeatureCount();
                for (uint i = 0; i < featureCounter; i++)
                {
                    var feature = m_linkFile.GetFeature(i);
                    var link = new GeoLink(feature.Geometry.Coordinates[0], feature.Geometry.Coordinates[1], OasisForms.DockMap.mapBox1.Map);
                    m_geoLinks.Add(link);
                    m_Line.AddGeoLink(link);
                }
                m_mutipleLines.Add(m_Line);
                m_linkFile.Close();
            }
        }

        private void m_mapBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            
        }







    }
}
