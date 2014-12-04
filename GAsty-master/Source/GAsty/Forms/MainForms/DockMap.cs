using System;
using System.Windows.Forms;
using GAsty.Helpers;
using GAsty.Network.Operation;
using GAsty.Network.Visualisation;
using GAsty.Utility;
using Oasis;
using SharpMap.Data;
using System.Threading;
using SharpMap.Layers;
using WeifenLuo.WinFormsUI.Docking;
using System.Drawing.Drawing2D;

namespace GAsty.Forms
{
    public partial class DockMap : DockContent
    {
        // add the editor to process data
        public NetworkEditor Editor;
        public NetworkVisualier m_visualiser;


        public DockMap()
        {
            InitializeComponent();

            Editor = new NetworkEditor(mapBox1);
            this.mapBox1.MapQueried += mapBox1_mapQueried;
            this.mapBox1.MapQueryDone += mapBox1_mapGeometryQuery;
        }


        private void mapBox1_mapGeometryQuery(object sender, EventArgs e)
        {
            
        }

        private void mapBox1_mapQueried(FeatureDataTable data)
        {
            //var queryWindow = new fmQueryWindow(data);
            //queryWindow.ShowDialog();
        }

        private void DockMap_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        #region Methods

        private void AddLayerToView(TreeNode pNode, Layer layer)
        {
            pNode.Nodes.Add(new TreeNode(layer.LayerName) { Tag = layer });
        }

        public void UpdateRiskMap()
        {
            State.UpdateService = NetRiskLayer.CreateNodeRiskLayer(State.network);
            GAsty.Forms.OasisForms.DockMap.mapBox1.Map.Layers.Add(State.UpdateService);
            //GAsty.Forms.OasisForms.DockMap.mapBox1.Map.ZoomToExtents();
            GAsty.Forms.OasisForms.DockMap.mapBox1.Refresh();
            UpdateLayerView();
        }

        public void UpdateRiskServiceLayers()
        {
            //OasisForms.DockMap.mapBox1.Map.Layers.Add(State.RiskServiceNodeLayer);
            //OasisForms.DockMap.mapBox1.Map.Layers.Add(State.RiskServiceLinkLayer);
            UpdateLayerView();
        }

        public void UpdateServiceMap()
        {
            GAsty.Forms.OasisForms.DockMap.mapBox1.Map.Layers.Add(State.NetworkServiceNodeLayer);
            GAsty.Forms.OasisForms.DockMap.mapBox1.Refresh();
            UpdateLayerView();
        }

        public void UpdateLayerView()
        {
            LayerView.Nodes.Clear();
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();
            LayerView.Nodes.Add("layers", "All Network Layers");
            treeView1.Nodes.Add("Nodes", "Nodes");
            treeView2.Nodes.Add("Links", "Links");
            AddLayerToView(LayerView.Nodes["layers"], State.NetworkNodeLayer);
            AddLayerToView(LayerView.Nodes["layers"], State.NetworkLinkLayer);
            AddLayerToView(LayerView.Nodes["layers"], State.ServiceRouteNodeLayer);
            AddLayerToView(LayerView.Nodes["layers"], State.ServiceRouteLinkLayer);

            if (State.network.GeoNodeCollection.Count > 0)
            {
                ListViewHelper.UpdateNodeListView(treeView1.Nodes["Nodes"], State.network);
            }

            if (State.network.GeoLinkCollection.Count > 0)
            {
                ListViewHelper.UpdateLinkListView(treeView2.Nodes["Links"], State.network);
            }

        }
        #endregion

        #region Button and Mouse Events

        private void mapBox1_MouseMove(GeoAPI.Geometries.Coordinate worldPos, MouseEventArgs imagePos)
        {

            if (TSEarth.CheckState == CheckState.Unchecked)
            {
                TSCoordValue.Text = " Lat: " + worldPos.CoordinateValue.X.ToString("N2") + " Long: " +
                               worldPos.CoordinateValue.Y.ToString("N2");
            }
            else
            {
                TSCoordValue.Text = " X: " + imagePos.X.ToString("N2") + " Y: " +
              imagePos.Y.ToString("N2");
            }
        }

        private void TSScreenToWorld_Click(object sender, EventArgs e)
        {
            if (TSEarth.CheckState == CheckState.Unchecked)
            {
                TSEarth.CheckState = CheckState.Checked;}
            else
            {
                TSEarth.CheckState = CheckState.Unchecked;
            }
        }

        private void TSEarth_Click(object sender, EventArgs e)
        {
            if (TSEarth.CheckState == CheckState.Unchecked)
            {
                TSEarth.CheckState = CheckState.Checked;
            }
            else
            {
                TSEarth.CheckState = CheckState.Unchecked;
            }
        }

        private void mapBox1_MapZoomChanged(double zoom)
        {

                TSScaleValue.Text = zoom.ToString("N2");        
        }

        
        #endregion

        private void mapBox1_Paint(object sender, PaintEventArgs e)
        {
            if (State.RenderRiskServiceLine)
            {
                State.RiskServiceNodeLayer.Render(e.Graphics, this.mapBox1.Map);
                State.RiskServiceLinkLayer.Render(e.Graphics, this.mapBox1.Map);
            }

            if (State.RenderInfrastructure&&State.IsProjectModeled)
            {
                State.UpdateService.Render(e.Graphics, this.mapBox1.Map);
            }

            if (State.network.GeoNodeCollection.Count > 0 && State.RenderInfrastructure == false)
            {
                State.ServiceNodeLayer.Render(e.Graphics, this.mapBox1.Map);
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }







        }
}
