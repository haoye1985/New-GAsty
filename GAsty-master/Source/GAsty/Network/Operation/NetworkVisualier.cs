using System.Collections.Generic;
using GAsty.Network.Core;
using GAsty.Network.Visualisation;
using GeoAPI.Geometries;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Forms;
using SharpMap.Layers;
using SharpMap.Rendering.Symbolizer;
using SharpMap.Rendering.Thematics;
using GAsty.Forms;
using GAsty.Network.Service;
using GAsty.Utility;
using System.Windows.Forms;
using SharpMap.Styles;
using BruTile.Web;
using System.IO;
using System.Drawing;

namespace GAsty.Network.Operation
{
    public class NetworkVisualier
    {
        #region Private Fields

            private TileLayer m_background;
            private GeoNetwork m_network;
            private List<GeoNetwork> m_serviceNetworkCollection;

            private List<GeoNode> m_infraNodesCollection;
            private List<GeoLink> m_infraLinksCollection;
            private List<IGeometry> m_infraNodeGeometryCollection;
            private List<IGeometry> m_infraLinkGeometryCollection;
            private List<GeoService> m_gServiceCollection;

            private List<GeoNode> m_gServiceNodeCollection;
            private List<GeoLink> m_gServiceLinkCollection;
            private List<IGeometry> m_gServiceNodeGeometryCollection;
            private List<IGeometry> m_gServiceLinkGeometryCollection;
            

            public VectorLayer m_nodelayer;
            public VectorLayer m_linklayer;
            public VectorLayer m_serviceNodeLayer;
            public VectorLayer m_serviceLinkLayer;

            public VectorLayer m_servicelayer;
            public VectorLayer m_serviceLineLayer;

            public VectorLayer m_riskServiceNodeLayer;
            public VectorLayer m_riskServiceLinkLayer;

            public VectorLayer m_riskLayer;
            public readonly MapBox m_mapBox;

        #endregion

        #region Constructor

            public NetworkVisualier(GeoNetwork network)
            {
                this.m_network = network;
                m_background = new TileLayer(new GoogleTileSource(GoogleMapType.GoogleMap), "Background", new Color(), true, Path.Combine(Path.GetTempPath(), "GoogleTileCache"));
                this.m_infraNodesCollection = network.GetInfraNodeCollection();
                this.m_infraLinksCollection = network.GetInfraLinkCollection();
                this.m_infraLinkGeometryCollection = network.GeoInfraLinksGeometries();
                this.m_infraNodeGeometryCollection = network.GeoInfraNodeGeometries();

                this.m_gServiceCollection = network.GetServiceCollection;
                this.m_gServiceNodeCollection = network.GetServiceNodeCollection();
                this.m_gServiceLinkCollection = network.GetServiceLinkCollection();
                this.m_gServiceNodeGeometryCollection = network.GetServiceGeometryNode();
                this.m_gServiceLinkGeometryCollection = network.GetServiceGeometryLink();

                this.m_nodelayer = new VectorLayer("NodeInfraLayer");
                this.m_linklayer = new VectorLayer("LinkInfraLayer");
                this.m_serviceNodeLayer = new VectorLayer("ServiceNode");
                this.m_serviceLinkLayer = new VectorLayer("ServiceLink");
                this.m_riskServiceNodeLayer = new VectorLayer("RiskServiceNodeLayer");
                this.m_riskServiceLinkLayer= new VectorLayer("RiskServiceLinkLayer");

                this.m_servicelayer = new VectorLayer("ServiceLayer");
                this.m_serviceLineLayer = new VectorLayer("ServiceLineLayer");
                this.m_riskLayer = new VectorLayer("RiskLayer");
                UpdateNodeLayer();
                UpdateLinkLayer();
            }

            public NetworkVisualier(GeoNetwork network, MapBox mapbox)
            {
                m_background = new TileLayer(new GoogleTileSource(GoogleMapType.GoogleMap), "Background", new Color(), true, Path.Combine(Path.GetTempPath(), "GoogleTileCache"));
                m_infraNodesCollection = network.GetInfraNodeCollection();
                m_infraLinksCollection = network.GetInfraLinkCollection();
                m_infraLinkGeometryCollection = network.GeoInfraLinksGeometries();
                m_infraNodeGeometryCollection = network.GeoInfraNodeGeometries();

                m_gServiceCollection = network.GetServiceCollection;
                m_gServiceNodeCollection = network.GetServiceNodeCollection();

                this.m_nodelayer = new VectorLayer("NodeInfraLayer");
                this.m_linklayer = new VectorLayer("LinkInfraLayer");
                this.m_serviceNodeLayer = new VectorLayer("ServiceNode");
                this.m_serviceLinkLayer = new VectorLayer("ServiceLink");
                this.m_servicelayer = new VectorLayer("ServiceLayer");
                this.m_serviceLineLayer = new VectorLayer("ServiceLineLayer");
                this.m_riskLayer = new VectorLayer("RiskLayer");
                this.m_riskServiceNodeLayer = new VectorLayer("RiskServiceNodeLayer");
                this.m_riskServiceLinkLayer = new VectorLayer("RiskServiceLinkLayer");

                UpdateNodeLayer();
                UpdateLinkLayer();
                this.m_mapBox = mapbox;
                m_mapBox.Paint += m_mapBox_Paint;
            }

            public NetworkVisualier(List<GeoNetwork> serviceCollection)
            {
                m_background = new TileLayer(new GoogleTileSource(GoogleMapType.GoogleMap), "Background", new Color(), true, Path.Combine(Path.GetTempPath(), "GoogleTileCache"));
                this.m_riskServiceNodeLayer = new VectorLayer("RiskServiceNodeLayer");
                this.m_riskServiceLinkLayer = new VectorLayer("RiskServiceLinkLayer");
                this.m_serviceNetworkCollection = serviceCollection;
            }

            public NetworkVisualier(GeoNetwork network, List<GeoNetwork> serviceCollection, MapBox mapbox)
            {
                m_background = new TileLayer(new GoogleTileSource(GoogleMapType.GoogleMap), "Background", new Color(), true, Path.Combine(Path.GetTempPath(), "GoogleTileCache"));
                this.m_serviceNetworkCollection = serviceCollection;

                m_infraNodesCollection = network.GetInfraNodeCollection();
                m_infraLinksCollection = network.GetInfraLinkCollection();
                m_infraLinkGeometryCollection = network.GeoInfraLinksGeometries();
                m_infraNodeGeometryCollection = network.GeoInfraNodeGeometries();

                m_gServiceCollection = network.GetServiceCollection;
                m_gServiceNodeCollection = network.GetServiceNodeCollection();


                this.m_nodelayer = new VectorLayer("NodeInfraLayer");
                this.m_linklayer = new VectorLayer("LinkInfraLayer");
                this.m_serviceNodeLayer = new VectorLayer("ServiceNode");
                this.m_serviceLinkLayer = new VectorLayer("ServiceLink");

                this.m_servicelayer = new VectorLayer("ServiceLayer");
                this.m_serviceLineLayer = new VectorLayer("ServiceLineLayer");
                this.m_riskLayer = new VectorLayer("RiskLayer");
                this.m_riskServiceNodeLayer = new VectorLayer("RiskServiceNodeLayer");
                this.m_riskServiceLinkLayer = new VectorLayer("RiskServiceLinkLayer");

                UpdateNodeLayer();
                UpdateLinkLayer();
                this.m_mapBox = mapbox;
                m_mapBox.Paint += m_mapBox_Paint;
            }

            #endregion

        #region Methods

            public void DoInfraNetworkVisualisation()
            {
                State.ServiceNodeLayer = GenerateNodeLayer();
                State.ServiceLinkLayer = GenerateLinkLayer();
                OasisForms.DockMap.mapBox1.Map.Layers.Add(State.ServiceLinkLayer);
                OasisForms.DockMap.mapBox1.Map.Layers.Add(State.ServiceNodeLayer);
                OasisForms.DockMap.mapBox1.Map.ZoomToBox(State.ServiceNodeLayer.Envelope);
                OasisForms.DockMap.mapBox1.Refresh();
                State.RenderServiceEditing = true;
            }

            public void ComputeServiceVisualisation()
            {
                if (this.m_serviceNetworkCollection.Count > 0)
                {
                    foreach (var network in State.ServiceNetworkCollection)
                    {
                        NetworkVisualier m_visualiser = new NetworkVisualier(network);
                        State.RiskServiceNodeLayer = m_visualiser.RenderRiskServiceNodeLayer();
                        State.RiskServiceLinkLayer = m_visualiser.RenderRiskServiceLinkLayer();
                    }
                }
                OasisForms.DockMap.mapBox1.Map.Layers.Add(State.RiskServiceNodeLayer);
                OasisForms.DockMap.mapBox1.Map.Layers.Add(State.RiskServiceLinkLayer);
                State.RenderServiceEditing = true;
                State.RenderRiskServiceLine = true;
                OasisForms.DockMap.mapBox1.Refresh();

            }

            public void DoServiceVisualisation()
            {
                if (this.m_serviceNetworkCollection.Count > 0)
                {
                    foreach (var network in State.ServiceNetworkCollection)
                    {
                        NetworkVisualier m_visualiser = new NetworkVisualier(network);
                        State.NetworkServiceLinkLayer = m_visualiser.RenderServiceLineLayer();
                        //TODO
                        State.NetworkServiceNodeLayer = m_visualiser.RenderServiceNodeLayer();
                    }
                    //TODO
                    OasisForms.DockMap.mapBox1.Map.Layers.Add(State.NetworkServiceNodeLayer);
                }
                OasisForms.DockMap.mapBox1.Map.Layers.Add(State.NetworkServiceLinkLayer);
                //TODO
                State.RenderServiceEditing = true;
                OasisForms.DockMap.mapBox1.Refresh();
            }

            public void DoNetworkVisualisation()
            {
                State.ServiceNodeLayer = GenerateNodeLayer();
                State.ServiceLinkLayer = GenerateLinkLayer();

                OasisForms.DockMap.mapBox1.Map.Layers.Add(State.ServiceLinkLayer);
                OasisForms.DockMap.mapBox1.Map.Layers.Add(State.ServiceNodeLayer);

                if (this.m_serviceNetworkCollection.Count > 0)
                {
                    foreach (var network in State.ServiceNetworkCollection)
                    {
                        NetworkVisualier m_visualiser = new NetworkVisualier(network);
                        State.NetworkServiceLinkLayer = m_visualiser.GenerateLinkServiceLayer();
                        State.NetworkServiceNodeLayer = m_visualiser.RenderServiceNodeLayer();
                    }

                    OasisForms.DockMap.mapBox1.Map.Layers.Add(State.NetworkServiceLinkLayer);
                    OasisForms.DockMap.mapBox1.Map.Layers.Add(State.NetworkServiceNodeLayer);
                }
                //OasisForms.DockMap.mapBox1.Map.ZoomToBox(State.ServiceLinkLayer.Envelope);
                //this.m_map.Invalidate();
                OasisForms.DockMap.mapBox1.Refresh();
                State.RenderServiceEditing = true;
            }

            public void DoRiskVisualiation()
            {
                State.UpdateService = GenerateRiskNodeLayer();
                State.ServiceLinkLayer = GenerateLinkLayer();
                OasisForms.DockMap.mapBox1.Map.Layers.Add(this.m_riskLayer);
                OasisForms.DockMap.mapBox1.Map.Layers.Add(State.ServiceLinkLayer);
                OasisForms.DockMap.mapBox1.Map.ZoomToBox(State.ServiceLinkLayer.Envelope);
                OasisForms.DockMap.mapBox1.Refresh();
            }

            public VectorLayer GenerateNodeLayer()
            {
                this.m_nodelayer.DataSource = new GeometryFeatureProvider(m_infraNodeGeometryCollection);
                this.m_nodelayer.IsQueryEnabled = true;
                return m_nodelayer;
            }

            public VectorLayer GenerateLinkLayer()
            {
                this.m_linklayer.DataSource = new GeometryFeatureProvider(m_infraLinkGeometryCollection);
                this.m_linklayer.IsQueryEnabled = true;
                return m_linklayer;
            }

            public VectorLayer GenerateNodeServiceLayer()
            {
                this.m_serviceNodeLayer.DataSource = new GeometryFeatureProvider(m_gServiceNodeGeometryCollection);
                var table = new FeatureDataTable();
                table.Columns.Add("Service");
                foreach (var node in m_gServiceNodeCollection)
                {
                    FeatureDataRow row = table.NewRow();
                    row.Geometry = node.Geometry;
                    row["Service"] = node.RiskXi.ToString();
                    table.AddRow(row);
                }

                this.m_serviceNodeLayer.DataSource = new GeometryFeatureProvider(table);
                var theme = new CustomTheme(NetworkStyle.GetMyServiceStyle);
                this.m_serviceNodeLayer.IsQueryEnabled = true;
                this.m_serviceNodeLayer.Theme = theme;

                return m_serviceNodeLayer;
            }

            public VectorLayer GenerateLinkServiceLayer()
            {
                this.m_serviceLinkLayer.DataSource = new GeometryFeatureProvider(m_gServiceLinkGeometryCollection);
                var table = new FeatureDataTable();
                table.Columns.Add("Service");
                foreach (var link in m_infraLinksCollection)
                {
                    FeatureDataRow row = table.NewRow();
                    row.Geometry = link.Geometry;
                    row["Service"] = link.ID.ToString();
                    table.AddRow(row);
                }

                this.m_serviceLinkLayer.DataSource = new GeometryFeatureProvider(table);
                var theme = new CustomTheme(NetworkStyle.GetMyServiceStyle);
                this.m_serviceLinkLayer.IsQueryEnabled = true;
                this.m_serviceLinkLayer.Theme = theme;

                return m_servicelayer;
            }

            public VectorLayer RenderRiskServiceNodeLayer()
            {
                this.m_riskServiceNodeLayer.DataSource = new GeometryFeatureProvider(m_gServiceNodeGeometryCollection);
                var table = new FeatureDataTable();
                table.Columns.Add("Service");
                foreach (var node in m_gServiceNodeCollection)
                {
                    FeatureDataRow row = table.NewRow();
                    row.Geometry = node.Geometry;
                    row["Service"] = State.ServiceValue.ToString();
                    table.AddRow(row);
                }

                this.m_riskServiceNodeLayer.DataSource = new GeometryFeatureProvider(table);
                var theme = new CustomTheme(NetworkStyle.GetMyServiceStyle);
                this.m_riskServiceNodeLayer.IsQueryEnabled = true;
                this.m_riskServiceNodeLayer.Theme = theme;

                return m_riskServiceNodeLayer;
            }

            public VectorLayer RenderRiskServiceLinkLayer()
            {
                this.m_riskServiceLinkLayer.DataSource = new GeometryFeatureProvider(m_gServiceLinkGeometryCollection);
                var table = new FeatureDataTable();
                table.Columns.Add("Service");
                //foreach (var node in m_gServiceCollection)
                foreach (var link in m_gServiceLinkCollection)
                {
                    FeatureDataRow row = table.NewRow();
                    row.Geometry = link.Geometry;
                    row["Service"] = State.ServiceValue;
                    table.AddRow(row);
                }

                this.m_riskServiceLinkLayer.DataSource = new GeometryFeatureProvider(table);
                var theme = new CustomTheme(ServiceStyle.GetLinkRiskServiceStyle);
                this.m_riskServiceLinkLayer.IsQueryEnabled = true;
                this.m_riskServiceLinkLayer.Theme = theme;

                return m_riskServiceLinkLayer;
            }

            public VectorLayer RenderServiceNodeLayer()
            {
                //m_infraLinkGeometryCollection = m_network.GetServiceNodeGeometries();
                this.m_servicelayer.DataSource = new GeometryFeatureProvider(m_gServiceNodeGeometryCollection);
                var table = new FeatureDataTable();
                table.Columns.Add("Service");
                //foreach (var node in m_gServiceCollection)
                foreach (var node in m_gServiceNodeCollection)
                {
                    FeatureDataRow row = table.NewRow();
                    row.Geometry = node.Geometry;
                    row["Service"] = State.ServiceValue.ToString();
                    table.AddRow(row);
                }

                this.m_servicelayer.DataSource = new GeometryFeatureProvider(table);
                var theme = new CustomTheme(NetworkStyle.GetMyServiceStyle);
                this.m_servicelayer.IsQueryEnabled = true;
                this.m_servicelayer.Theme = theme;

                return m_servicelayer;
            }

            public VectorLayer RenderServiceLineLayer()
            {
                //m_infraLinkGeometryCollection = m_network.GetServiceNodeGeometries();
                this.m_serviceLineLayer.DataSource = new GeometryFeatureProvider(m_gServiceLinkGeometryCollection);
                var table = new FeatureDataTable();
                table.Columns.Add("Service");
                foreach (var link in m_gServiceLinkCollection)
                {
                    FeatureDataRow row = table.NewRow();
                    row.Geometry = link.Geometry;
                    row["Service"] = State.ServiceValue.ToString();
                    table.AddRow(row);
                }

                this.m_serviceLineLayer.DataSource = new GeometryFeatureProvider(table);
                var theme = new CustomTheme(ServiceStyle.GetLinkServiceStyle);
                this.m_serviceLineLayer.Theme = theme;

                return m_serviceLineLayer;
            }

            public void GenerateRiskLayer()
            {
                this.m_riskLayer.DataSource = new GeometryFeatureProvider(m_infraNodeGeometryCollection);
                var table = new FeatureDataTable();
                table.Columns.Add("RiskIndex");
                foreach (var node in m_infraNodesCollection)
                {
                    FeatureDataRow row = table.NewRow();
                    row.Geometry = node.Geometry;
                    row["RiskIndex"] = node.RiskXi.ToString();
                    table.AddRow(row);
                }

                this.m_riskLayer.DataSource = new GeometryFeatureProvider(table);
                var theme = new CustomTheme(NetworkStyle.GetMyPointStyle);
                this.m_riskLayer.IsQueryEnabled = true;
                this.m_riskLayer.Theme = theme;
            }

            public VectorLayer GenerateRiskNodeLayer()
            {
                this.m_riskLayer.DataSource = new GeometryFeatureProvider(m_infraNodeGeometryCollection);
                var table = new FeatureDataTable();
                table.Columns.Add("RiskIndex");
                foreach (var node in m_infraNodesCollection)
                {
                    FeatureDataRow row = table.NewRow();
                    row.Geometry = node.Geometry;
                    row["RiskIndex"] = node.RiskXi.ToString();
                    table.AddRow(row);
                }
                this.m_riskLayer.DataSource = new GeometryFeatureProvider(table);
                var theme = new CustomTheme(NetworkStyle.GetMyPointStyle);
                this.m_riskLayer.IsQueryEnabled = true;
                this.m_riskLayer.Theme = theme;
                return m_riskLayer;
            }

            public void UpdateRiskNodeLayer()
            {
                this.m_nodelayer.DataSource = new GeometryFeatureProvider(m_infraNodeGeometryCollection);
                var table = new FeatureDataTable();
                table.Columns.Add("RiskIndex");
                foreach (var node in m_infraNodesCollection)
                {
                    FeatureDataRow row = table.NewRow();
                    row.Geometry = node.Geometry;
                    row["RiskIndex"] = node.RiskXi.ToString();
                    table.AddRow(row);
                }
                m_nodelayer.DataSource = new GeometryFeatureProvider(table);
                var theme = new CustomTheme(NetworkStyle.GetMyPointStyle);
                m_nodelayer.IsQueryEnabled = true;
                m_nodelayer.Theme = theme;
            }

            public void UpdateNodeLayer()
            {
                this.m_nodelayer.DataSource = new GeometryFeatureProvider(m_infraNodeGeometryCollection);
                this.m_nodelayer.IsQueryEnabled = true;
            }

            public void UpdateLinkLayer()
            {
                this.m_linklayer.DataSource = new GeometryFeatureProvider(m_infraLinkGeometryCollection);
                this.m_linklayer.IsQueryEnabled = true;
            }

            public void DrawNodeLayer(MapBox mapBox)
            {
                mapBox.Map.Layers.Add(this.m_nodelayer);
                mapBox.Refresh();
            }

            public void DrawLinkLayer(MapBox mapBox)
            {
                mapBox.Map.Layers.Add(this.m_linklayer);
                mapBox.Refresh();
            }

        #endregion

            void m_mapBox_Paint(object sender, PaintEventArgs e)
            {
                if (State.RenderServiceEditing == true)
                {
                    if (State.NetworkNodeLayer.DataSource != null && State.NetworkLinkLayer.DataSource != null)
                    {
                        State.NetworkServiceNodeLayer.Style.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.BlueViolet), Brushes.Brown, 15);
                        State.NetworkServiceNodeLayer.Render(e.Graphics, m_mapBox.Map);
                        State.NetworkServiceLinkLayer.Render(e.Graphics, m_mapBox.Map);
                    }

                    if (State.RenderRiskServiceLine == true)
                    {
                        State.RiskServiceNodeLayer.Render(e.Graphics, m_mapBox.Map);
                        State.RiskServiceLinkLayer.Render(e.Graphics, m_mapBox.Map);

                    }

                    if (State.RenderServiceEditing && OasisForms.DockMain.gISMapToolStripMenuItem.Checked && State.ServiceNodeLayer.DataSource!=null && State.ServiceLinkLayer.DataSource!=null)
                    {
                        //TODO
                        this.m_background.Render(e.Graphics, m_mapBox.Map);
                        State.NetworkServiceNodeLayer.Render(e.Graphics, m_mapBox.Map);
                        State.NetworkServiceLinkLayer.Render(e.Graphics, m_mapBox.Map);
                        State.ServiceNodeLayer.Render(e.Graphics, m_mapBox.Map);
                        State.ServiceLinkLayer.Render(e.Graphics, m_mapBox.Map);
                    }

                    State.ServiceNodeLayer.Render(e.Graphics, m_mapBox.Map);
                    State.ServiceLinkLayer.Render(e.Graphics, m_mapBox.Map);
                }

                if (State.RenderInfrastructure == true)
                {
                    State.UpdateService.Render(e.Graphics, m_mapBox.Map);
                }

                if (State.RenderInfrastructure && State.IsProjectModeled)
                {
                    State.UpdateService.Render(e.Graphics, m_mapBox.Map);
                }

            }

        #region Properties

        public List<IGeometry> NodeCollection
        {
            get { return m_infraNodeGeometryCollection; }
        }

        #endregion
    }
}
