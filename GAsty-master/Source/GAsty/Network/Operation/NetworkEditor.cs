using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using BruTile.Web;
using GAsty.Forms;
using GAsty.Graph;
using GAsty.Network.Core;
using GAsty.Network.Visualisation;
using GAsty.Utility;
using GeoAPI.Geometries;
using NodeGraphControl;
using Oasis;
using Oasis.Graph.Graph_Core;
using SharpMap.Forms;
using SharpMap.Layers;

namespace GAsty.Network.Operation
{
    [Serializable]
    public class NetworkEditor
    {
        public readonly MapBox m_mapBox;
        public Graphics gGraph;
        public VectorLayer m_nodeLayer;
        public VectorLayer m_linkLayer;
        public VectorLayer m_serviceLayer;
        private TileLayer m_background;
        private Coordinate m_drawStart;
        private Coordinate m_drawCentral;
        private Coordinate m_drawEnd;
        private Point m_imageStartPoint;
        private Point m_imageEndPoint;
        private Point m_imageCentrolPoint;

        private bool m_isDrawing;
        private EditMode m_sEditorMode;

        public NetworkVisualier Visualier;

        public NodeGraphConnector InputLinkConnector;
        public NodeGraphConnector CentrolLinkConnector;
        public NodeGraphConnector OutputLinkConnector;

        public NetworkEditor(MapBox pmapBox)
        {
            this.m_mapBox = pmapBox;
            m_background = new TileLayer(new GoogleTileSource(GoogleMapType.GoogleMap), "Background", new Color(), true, Path.Combine(Path.GetTempPath(), "GoogleTileCache"));
            NetworkProjector.ProjectTileLayer(this.m_mapBox);
            m_nodeLayer = new VectorLayer("NodeLayer");
            m_linkLayer = new VectorLayer("LinkLayer");
            m_serviceLayer = new VectorLayer("ServiceLayer");

            this.m_isDrawing = false;
            this.m_drawStart = new Coordinate();
            this.m_drawCentral = new Coordinate();
            this.m_drawEnd = new Coordinate();
            this.m_imageStartPoint = new Point();
            this.m_imageEndPoint = new Point();
            this.m_imageCentrolPoint = new Point();

            m_mapBox.MouseDown += m_mapBox_MouseDown;
            m_mapBox.MouseMove += m_mapBox_MouseMove;
            m_mapBox.MouseUp += m_mapBox_MouseUp;
            m_mapBox.MouseWheel += m_mapBox_MouseWheel;
            m_mapBox.Paint += m_mapBox_Paint;
            m_mapBox.MapQueried += m_mapBox_Query;
        }

        private void m_mapBox_Query(SharpMap.Data.FeatureDataTable data)
        {
            
        }

        void m_mapBox_MouseWheel(object sender, MouseEventArgs e)
        {
            m_mapBox.Refresh();
        }

        void m_mapBox_MouseDown(Coordinate worldPos, MouseEventArgs imagePos)
        {
            switch (this.MapEditorModes)
            {
                case EditMode.DrawNode:
                        var mapNode = new GeoNode(imagePos.X, imagePos.Y, m_mapBox.Map, NodeEnum.Edge);
                        State.network.AddGeoEdgeNode(mapNode, NodeEnum.Edge);                  
                        Visualier = new NetworkVisualier(State.network);


                        m_nodeLayer = Visualier.GenerateNodeLayer();
                        State.ServiceNodeLayer = NetRiskLayer.CreateNodeRiskLayer(State.network);
                        //State.ServiceNodeLayer = NetRiskLayer.CreateInfraLayer(State.network, NodeEnum.Link);
                        Point clickPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(imagePos.Location);
                        var nodeItem = new TransportNode(clickPoint.X, clickPoint.Y, OasisForms.DockGraph.nodeGraphPanel1.View, true, NodeEnum.Node);
                        GraphHelper.AddGraphNode(OasisForms.DockGraph.nodeGraphPanel1, nodeItem); 
                        OasisForms.DockCompoundGraph.GraphControl.UpdateComponent();
                        //OasisForms.DockCompoundGraph.GraphControl.layout.UpdateLayout();



                        OasisForms.DockNode.UpdateNodeList();
                        OasisForms.DockService.UpdateServiceList();
                        break;

                case EditMode.DrawLink:
                        m_isDrawing = true;
                        if (State.network.GeoNodeCollection.Count!= 0)
                        {
                            for (int i = 0; i < State.network.GeoNodeCollection.Count; i++)
                            {
                                if (State.network.GeoNodeCollection[i].ScreenPointContain(imagePos.Location))
                                {
                                    this.m_drawStart = State.network.GeoNodeCollection[i].Coordinate;
                                    this.m_drawEnd = State.network.GeoNodeCollection[i].Coordinate;
                                    this.m_imageStartPoint = imagePos.Location;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot build a network-based link without network nodes!");
                            return;
                        }

                        Point point = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(imagePos.Location);
                        Rectangle hitRectangle = GraphHelper.GraphNodeHitRect(point);
                        foreach (var graphNode in OasisForms.DockGraph.nodeGraphPanel1.View.NodeCollection)
                        {
                            if (hitRectangle.IntersectsWith(graphNode.HitRectangle))
                            {
                                InputLinkConnector = graphNode.Connectors[0];
                                CentrolLinkConnector = null;
                                OutputLinkConnector = null;
                            }
                        }
                    break;
                default:
                    break;
            }

            m_mapBox.Invalidate();
        }

        void m_mapBox_MouseMove(Coordinate worldPos, MouseEventArgs imagePos)
        {
            switch(this.MapEditorModes)
            {
                case EditMode.None:
                    break;

                case EditMode.DrawLink:
                        if (m_isDrawing)
                        {
                            this.m_drawEnd = worldPos;
                        }
                    break;

                default:
                    break;    
            }

            m_mapBox.Invalidate();
        }

        void m_mapBox_MouseUp(Coordinate worldPos, MouseEventArgs imagePos)
        {
            switch (MapEditorModes)
            {
                case EditMode.DrawLink:
                    if (State.network.GeoNodeCollection.Count != 0)
                    {
                        for (int i = 0; i < State.network.GeoNodeCollection.Count; i++)
                        {
                            if (State.network.GeoNodeCollection[i].ScreenPointContain(imagePos.Location))
                            {
                                this.m_drawEnd = State.network.GeoNodeCollection[i].Coordinate;
                                this.m_imageEndPoint = imagePos.Location;
                                var link = new GeoLink(m_imageStartPoint, m_imageEndPoint, m_drawStart, m_drawEnd, m_mapBox.Map);
                                var centrol = new GeoNode(link.CentrolPoint.X, link.CentrolPoint.Y, m_mapBox.Map, NodeEnum.Centroid);
                                this.m_drawCentral = link.Geometry.Centroid.Coordinate;
                                this.m_imageCentrolPoint = link.CentrolPoint;
                                State.network.AddGeoLink(link);
                                var centrolNode = new GeoNode(this.m_drawCentral, m_mapBox.Map, NodeEnum.Centroid);
                                centrolNode.NodeType = NodeEnum.Centroid;
                                State.network.AddGeoCentroidNode(centrolNode, NodeEnum.Centroid);
                                //State.network.AddLinkService(link, new GeoService(Service.InfraEnum.link), Service.ServiceEnum.Good);
                                Point clickPoint = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(link.CentrolPoint);
                                var nodeItem = new TransportNode(clickPoint.X, clickPoint.Y, OasisForms.DockGraph.nodeGraphPanel1.View, true, NodeEnum.Link);
                                GraphHelper.AddGraphNode(OasisForms.DockGraph.nodeGraphPanel1, nodeItem);

                                CentrolLinkConnector = nodeItem.Connectors[0];
                                Visualier = new NetworkVisualier(State.network);
                                m_nodeLayer = Visualier.GenerateNodeLayer();
                                m_linkLayer = Visualier.GenerateLinkLayer();

                                //TODO
                                State.ServiceNodeLayer = NetRiskLayer.CreateNodeRiskLayer(State.network);
                                //State.ServiceNodeLayer = NetRiskLayer.CreateInfraLayer(State.network);
                                State.ServiceLinkLayer = m_linkLayer;
                                break;
                            }
                        }
                    }

                    //
                    // Create graph infrastructure link on the graph control
                    Point point = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(imagePos.Location);
                    Rectangle hitRectangle = GraphHelper.GraphNodeHitRect(point);

                    foreach (var graphNode in OasisForms.DockGraph.nodeGraphPanel1.View.NodeCollection)
                    {
                        if (hitRectangle.IntersectsWith(graphNode.HitRectangle))
                        {
                            OutputLinkConnector = graphNode.Connectors[0];
                        }
                    }

                    if (InputLinkConnector != null && OutputLinkConnector != null)
                    {
                        //GraphHelper.AddGraphLink(OasisForms.DockGraph.nodeGraphPanel1, link);
                        var link1 = new TransLink(InputLinkConnector, CentrolLinkConnector, OutputLinkConnector.DataType);
                        var link2 = new TransLink(CentrolLinkConnector, OutputLinkConnector, OutputLinkConnector.DataType);
                        var link3 = new TransLink(CentrolLinkConnector, InputLinkConnector, OutputLinkConnector.DataType);
                        var link4 = new TransLink(OutputLinkConnector, CentrolLinkConnector, OutputLinkConnector.DataType);
                        GraphHelper.AddGraphLink(OasisForms.DockGraph.nodeGraphPanel1, link1);
                        GraphHelper.AddGraphLink(OasisForms.DockGraph.nodeGraphPanel1, link2);
                        GraphHelper.AddGraphLink(OasisForms.DockGraph.nodeGraphPanel1, link3);
                        GraphHelper.AddGraphLink(OasisForms.DockGraph.nodeGraphPanel1, link4);

                        // Update the DataGrid
                        OasisForms.DockLink.UpdateLinkList();
                        OasisForms.DockNode.UpdateNodeList();
                        OasisForms.DockService.UpdateServiceList();
                        OasisForms.DockMap.UpdateLayerView();
                    }

                    this.InputLinkConnector = null;
                    this.OutputLinkConnector = null;
                    this.m_drawStart = null;
                    this.m_drawEnd = null;
                    this.m_drawCentral = null;
                    this.m_isDrawing = false;
                    break;

                default:
                    break;
                }
            m_mapBox.Invalidate();
        }

        void m_mapBox_Paint(object sender, PaintEventArgs e)
        {
            gGraph = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (OasisForms.DockMain.gISMapToolStripMenuItem.Checked)
            {
                this.m_background.Render(e.Graphics, m_mapBox.Map);

                if (State.ServiceNodeLayer.DataSource != null && State.ServiceLinkLayer.DataSource != null)
                {
                    State.ServiceNodeLayer.Render(e.Graphics, m_mapBox.Map);
                    State.ServiceLinkLayer.Render(e.Graphics, m_mapBox.Map);
                }

                if (State.NetworkServiceNodeLayer.DataSource != null && State.NetworkServiceLinkLayer.DataSource != null)
                {
                    State.NetworkServiceNodeLayer.Render(e.Graphics, m_mapBox.Map);
                    State.NetworkServiceLinkLayer.Render(e.Graphics, m_mapBox.Map);
                }

                if (State.ServiceLinkLayer.DataSource != null && State.UpdateService.DataSource!=null)
                {
                }

                if ((State.RiskServiceNodeLayer.DataSource != null) && (State.RiskServiceLinkLayer.DataSource != null))
                {
                    State.RiskServiceNodeLayer.Render(e.Graphics, m_mapBox.Map);
                    State.RiskServiceLinkLayer.Render(e.Graphics, m_mapBox.Map);
                }
            }

            if (State.network.GeoNodeCollection.Count > 0 && State.RenderInfrastructure == false)
            {
                State.ServiceNodeLayer.Render(e.Graphics, m_mapBox.Map);
            }

            if (State.network.GeoLinkCollection.Count > 0 && State.RenderInfrastructure == false)
            {
                State.ServiceLinkLayer.Render(e.Graphics, m_mapBox.Map);
            }

            if (State.network.GeoLinkCollection.Count > 0 && MapEditorModes == EditMode.DrawLink)
            {
                m_nodeLayer.Render(e.Graphics, m_mapBox.Map);
                m_linkLayer.Render(e.Graphics, m_mapBox.Map);
            }

            if (State.network.GetServiceCollection.Count > 0 && MapEditorModes == EditMode.DrawService)
            {
                m_serviceLayer.Render(e.Graphics, m_mapBox.Map);
                OasisForms.DockMap.mapBox1.Map.Layers.Clear();
            }

            if (State.RenderInfrastructure)
            {
                State.UpdateService = NetRiskLayer.CreateNodeRiskLayer(State.network);
                State.UpdateService.Render(e.Graphics, m_mapBox.Map);
                State.ServiceLinkLayer.Render(e.Graphics, m_mapBox.Map);
            }

            if (m_isDrawing && m_drawStart!=null && m_drawEnd!=null)
            {               
                var pStart = m_mapBox.Map.WorldToImage(m_drawStart);
                var pEnd = m_mapBox.Map.WorldToImage(m_drawEnd);
                e.Graphics.DrawLine(new Pen(Color.Green, 2F), pStart, pEnd);
            }
        }

        #region Properties

        public EditMode MapEditorModes
        {
            get { return m_sEditorMode; }
            set { m_sEditorMode = value; }
        }

        #endregion


    }
}
