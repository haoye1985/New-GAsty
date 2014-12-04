using System;
using System.Windows.Forms;
using GAsty.Hazard;
using GAsty.Network.Operation;
using GAsty.Utility;

namespace GAsty.Forms
{
    public partial class ModelPrepForm : Form
    {
        private string m_TubeStationFileName = @"D:\GAsty\GAsty\Data\ProjectedStations.shp";
        private string m_TubeLinkFileName = @"D:\GAsty\GAsty\Data\ProjectedLinks.shp";
        //private string m_HazardFileName = @"D:\GAsty\GAsty\Data\ProjectedHazard.shp";
        private string m_HazardFileName = @"C:\Users\hye\Desktop\GAsty\GAsty-master\Data\ProjectedHazard.shp";
        private string m_serviceNodeFileName1 = @"D:\GAsty\GAsty\Data\ServiceTubeData\BakerlooStations.shp";
        private string m_serviceLinkFileName1 = @"D:\GAsty\GAsty\Data\ServiceTubeData\Bakerloot.shp";
        private string m_serviceLinkFileName2 = @"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork\Central.shp";
        private string m_serviceNodeFileName2 = @"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork\CentralStations.shp";


        public ModelPrepForm()
        {
            InitializeComponent();

            TubeStationTxtBox.Text = m_TubeStationFileName;
            TubeLinksTxtBox.Text = m_TubeLinkFileName;
            TubetxtHazard.Text = m_HazardFileName;

            TxtServiceBox.AppendText(m_serviceNodeFileName1 +"\r\n");
            TxtServiceBox.AppendText(m_serviceLinkFileName1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var bar = new ProgressBar();

            if (m_TubeStationFileName != null && m_TubeLinkFileName != null && m_HazardFileName!=null)
            {
                bar.Show();
                bar.UpdateLabel("Loading Data");
                var constructor = new NetworkBuilder(m_TubeStationFileName, m_TubeLinkFileName, OasisForms.DockMap.mapBox1);
                constructor.BuildNetworkToState();
                bar.UpdateProgress(1);
                bar.UpdateLabel("Loading Network Database");
                var hazardConstructor = new HazardBuilder(m_HazardFileName, OasisForms.DockMap.mapBox1);
                hazardConstructor.BuildHazard();
                bar.UpdateProgress(2);
                bar.UpdateLabel("Loading Hazard Database");
                var serviceConstructor1 = new ServiceBuilder(m_serviceNodeFileName1, m_serviceLinkFileName1, OasisForms.DockMap.mapBox1);
                serviceConstructor1.BuildServiceToNetwork();
                bar.UpdateProgress(3);
                bar.UpdateLabel("Loading Service Database");
                var serviceConstructor2 = new ServiceBuilder(m_serviceNodeFileName2, m_serviceLinkFileName2, OasisForms.DockMap.mapBox1);
                serviceConstructor2.BuildServiceToNetwork();
                OasisForms.DockMap.UpdateLayerView();
                bar.UpdateProgress(4);
                bar.UpdateLabel("Loading Map Layers");
                OasisForms.DockMap.mapBox1.Map.ZoomToBox(State.ServiceNodeLayer.Envelope);
                OasisForms.DockNode.UpdateNodeList();
                OasisForms.DockLink.UpdateLinkList();
                bar.UpdateProgress(5);
            }

            this.Close();
            bar.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


    }
}
