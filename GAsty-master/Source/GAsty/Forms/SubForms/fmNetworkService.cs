using GAsty.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAsty.Network.Operation;
using GAsty.Graph;

namespace GAsty.Forms
{
    public partial class fmNetworkService : Form
    {
        private string m_serviceprojectName;
        private NetworkVisualier m_visualiser;

        public fmNetworkService()
        {
            InitializeComponent();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Partition-HaoYe\Projects\Oasis\SampleNetwork";
            openFilePath.Filter = @"NET Files (*.bin)|*.bin";
            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_serviceprojectName = openFilePath.FileName;
                txtServiceBox.Text = m_serviceprojectName;
                txtServiceBox.Text = openFilePath.InitialDirectory;
            }  
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            State.ServiceNetworkCollection = SerialisationHelper.DeserialiseServiceNetworks(m_serviceprojectName);
            m_visualiser = new NetworkVisualier(State.ServiceNetworkCollection);
            m_visualiser.DoServiceVisualisation();
            GraphHelper.UpdateGraphService(State.ServiceNetworkCollection);


           
            this.Close();
        }
    }
}
