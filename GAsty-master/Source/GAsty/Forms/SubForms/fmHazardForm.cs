using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAsty.Hazard;
using GAsty.Utility;

namespace GAsty.Forms
{
    public partial class fmHazardForm : Form
    {
        private string m_hazardFileName;

        public fmHazardForm()
        {
            InitializeComponent();
        }

        private void btnHazardOK_Click(object sender, EventArgs e)
        {
            if (m_hazardFileName != null)
            {
                var hazardConstructor = new HazardBuilder(m_hazardFileName, OasisForms.DockMap.mapBox1);
                hazardConstructor.BuildHazard();

                //TODO add hazard List
                //var constructor = new NetworkBuilder(m_nodeFileName, m_linkFileName, OasisForms.DockMap.mapBox1);
                //constructor.BuildNetworkToState();
                //var graphBuilder = new GraphNetworkBuilder(State.network);
                //graphBuilder.BuildGraphNode();
                //OasisForms.DockMap.UpdateLayerView();
                //OasisForms.DockMap.mapBox1.Map.ZoomToBox(State.ServiceNodeLayer.Envelope);
                //OasisForms.DockNode.UpdateNodeList();
                //OasisForms.DockLink.UpdateLinkList();
            }

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Partition-HaoYe\Projects\Oasis\Data";
            openFilePath.Filter = @"SHP Files (*.shp)|*.shp";

            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_hazardFileName = openFilePath.FileName;
                TxtHazardFilePath.Text = m_hazardFileName;
            }
        }
    }
}
