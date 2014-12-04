using System;
using System.Windows.Forms;
using GAsty.Graph;
using GAsty.Network.Operation;
using GAsty.Utility;
using Oasis;

namespace GAsty.Forms
{
    public partial class FmFilePath : Form
    {
        private string m_nodeFileName;
        private string m_linkFileName;

        public FmFilePath()
        {
            InitializeComponent();
        }

        private void btnNodePath_Click(object sender, EventArgs e)
        {
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Partition-HaoYe\Projects\Oasis\Data";
            openFilePath.Filter = @"SHP Files (*.shp)|*.shp";

            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_nodeFileName = openFilePath.FileName;
                txtNodePath.Text = m_nodeFileName;
            }
        }
        private void BtnLinkPath_Click(object sender, EventArgs e){
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Partition-HaoYe\Projects\Oasis\Data";
            openFilePath.Filter = @"SHP Files (*.shp)|*.shp";

            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_linkFileName = openFilePath.FileName;
                txtLinkPath.Text = m_linkFileName;
            }
        }

        private void btnDialogOK_Click(object sender, EventArgs e)
        {
            if (m_nodeFileName != null && m_linkFileName != null)
            {
                var constructor = new NetworkBuilder(m_nodeFileName, m_linkFileName, OasisForms.DockMap.mapBox1);
                constructor.BuildNetworkToState();
                var graphBuilder = new GraphNetworkBuilder(State.network);
                graphBuilder.BuildGraphNode();
                OasisForms.DockMap.UpdateLayerView();
                OasisForms.DockMap.mapBox1.Map.ZoomToBox(State.ServiceNodeLayer.Envelope);
                OasisForms.DockNode.UpdateNodeList();
                OasisForms.DockLink.UpdateLinkList();
                OasisForms.DockCompoundGraph.GraphControl.UpdateComponent();
            }

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    
    }
}
