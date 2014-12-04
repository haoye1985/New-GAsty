using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAsty.Forms;
using GAsty.Utility;

namespace GAsty
{
    public partial class fmServiceLoader : Form
    {
        private string m_nodeServiceFileName;
        private string m_linkServiceFileName;

        public fmServiceLoader()
        {
            InitializeComponent();
        }

        private void linkServiceBtn_Click(object sender, EventArgs e)
        {
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Partition-HaoYe\Projects\Oasis\ServiceTubeData";
            openFilePath.Filter = @"SHP Files (*.shp)|*.shp";
            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_nodeServiceFileName = openFilePath.FileName;
                LinkServicePath.Text = m_nodeServiceFileName;
            }
        }

        private void NodeServiceBtn_Click(object sender, EventArgs e)
        {
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Partition-HaoYe\Projects\Oasis\ServiceTubeData";
            openFilePath.Filter = @"SHP Files (*.shp)|*.shp";
            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_linkServiceFileName = openFilePath.FileName;
                NodeServicePath.Text = m_linkServiceFileName;
            }
        }

        private void BtnServiceOK_Click(object sender, EventArgs e)
        {
            if (m_nodeServiceFileName != null && m_linkServiceFileName != null)
            {
                var serviceConstructor = new ServiceBuilder(m_nodeServiceFileName, m_linkServiceFileName, OasisForms.DockMap.mapBox1);
                serviceConstructor.BuildServiceToNetwork();
                //OasisForms.DockMap.mapBox1.Map.ZoomToBox(State.ServiceRouteNodeLayer.Envelope);
                OasisForms.DockMap.UpdateLayerView();
                this.Close();
            }
        }





    }
}
