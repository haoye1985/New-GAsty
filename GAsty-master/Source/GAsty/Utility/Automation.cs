using System.Windows.Forms;
using GAsty.Forms;
using GAsty.Graph;
using GAsty.Network.Core;
using GAsty.Network.Operation;
using Pan.Utilities;

namespace GAsty.Utility
{
    public static class Automation
    {


        public static void MappingNetwork(string path, GeoNetwork network)
        {
            var m_visualiser = new NetworkVisualier(network);
            State.network = SerialisationHelper.DeserialiseNetwork(path);
            State.ServiceNodeLayer = m_visualiser.GenerateNodeLayer();
            State.ServiceLinkLayer = m_visualiser.GenerateLinkLayer();
            OasisForms.DockMap.mapBox1.Map.Layers.Add(State.ServiceLinkLayer);
            OasisForms.DockMap.mapBox1.Map.Layers.Add(State.ServiceNodeLayer);
            OasisForms.DockMap.mapBox1.Map.ZoomToBox(State.ServiceNodeLayer.Envelope);
        }

        public static void LoadProject()
        {
            string nodefile = @"C:\Partition-HaoYe\Projects\Oasis\Data\ProjectedStations.shp";
            string linkfile = @"C:\Partition-HaoYe\Projects\Oasis\Data\ProjectedLinks.shp";
            var constructor = new NetworkBuilder(nodefile, linkfile, OasisForms.DockMap.mapBox1);
            constructor.BuildNetworkToState();
            var graphBuilder = new GraphNetworkBuilder(State.network);
            graphBuilder.BuildGraphNode();

            OasisForms.DockMain.gISMapToolStripMenuItem.CheckState = CheckState.Checked;
            OasisForms.DockMap.UpdateLayerView();
            OasisForms.DockMap.mapBox1.Map.ZoomToBox(State.ServiceNodeLayer.Envelope);
            OasisForms.DockNode.UpdateNodeList();
            OasisForms.DockLink.UpdateLinkList();
        }


        public static void SaveProject()
        {
            if (State.network.GetInfraNodeCollection().Count == 0 && State.network.GetInfraLinkCollection().Count == 0)
            {
                MessageBox.Show("The network is empty, cannot be serialised!");
            }
        }

        public static void SettingMainWindow(DockMain pmainWindow)
        {
            pmainWindow.FormBorderStyle = FormBorderStyle.Sizable;
            pmainWindow.WindowState = FormWindowState.Maximized;
            pmainWindow.AutoScaleMode = AutoScaleMode.None;
        }

        public static void UpdateAfterModelling()
        {
            OasisForms.DockGraph.UpdateGraph();
            var degree = new NetworkDegree(State.network);
            degree.FindNodeDegree();
            OasisForms.DockNode.UpdateNodeList();
            OasisForms.DockLink.UpdateLinkList();
            OasisForms.DockService.UpdateServiceList();
            OasisForms.DockChart.UpdateCharts();
            OasisForms.DockMap.UpdateRiskMap();

        }

        public static void UpdateBeforeModelling()
        {
            OasisForms.DockMap.UpdateRiskMap();
            OasisForms.DockGraph.UpdateGraph();
            OasisForms.DockNode.UpdateNodeList();
            OasisForms.DockLink.UpdateLinkList();
            OasisForms.DockService.UpdateServiceList();
        }

        public static void LoadingUpdating()
        {
            OasisForms.DockMap.UpdateRiskMap();
            OasisForms.DockGraph.UpdateGraph();
            OasisForms.DockNode.UpdateNodeList();
            OasisForms.DockLink.UpdateLinkList();
            OasisForms.DockService.UpdateServiceList();
        }


    }
}
