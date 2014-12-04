using System.Runtime.InteropServices;
using GAsty.Graph;
using GAsty.Hazard.Operation;
using GAsty.Network.Operation;
using GAsty.Tube;
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

namespace GAsty.Forms
{
    public partial class Form_LoadProject : Form
    {
        private string m_infrastructureNetwork;
        private string m_hazardMapDatabase;
        private string m_serviceprojectName;
        private string m_BankerlooStations;
        private string m_BankerlooLinkes;
        private string m_CentralStations;
        private string m_CentralLinks;
        private string m_serviceNodeFileName3;
        private string m_serviceLinkFileName3;
        private string m_lineStatusFile;
        private string m_timeSpentOnStationFile;

        private string m_serviceTimeSpentFileName;
        private string m_servicePassengerFile;

        private NetworkVisualier m_visualiser;
        private HazardVisualiser m_hazardVisualiser;

        public Form_LoadProject()
        {
            InitializeComponent();

            // all default data file paths
            this.m_infrastructureNetwork = @"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork\LondonUnderground.bin";
            this.m_hazardMapDatabase = @"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork\LondonHazard.bin";
            this.m_BankerlooStations = @"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork\BakerlooStations.shp";
            this.m_BankerlooLinkes = @"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork\Bakerloot.shp";
            this.m_CentralStations = @"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork\CentralStations.shp";
            this.m_CentralLinks = @"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork\Central.shp";
            this.m_lineStatusFile = @"D:\GAsty\GAsty\XMLData\StationStatus.xml";
            this.m_timeSpentOnStationFile = @"C:\Users\hye\Desktop\GAsty\GAsty-master\Data\PassengerData\TimeSpent.csv";

        }

        private void Form_LoadProject_Load(object sender, EventArgs e)
        {
            if (cbAllData.Checked)
            {
                txtInfraPath.Text = m_infrastructureNetwork;
                txtHazardPath.Text = m_hazardMapDatabase;
                txtServiceNodePath.Text = m_BankerlooStations;
                txtServiceLinkPath.Text = m_BankerlooLinkes;
                textLineStatusPath.Text = m_lineStatusFile;
                txtPassengerPath.Text = m_timeSpentOnStationFile;

                // alll network and sample data are required to run model
                cbInfrastructure.CheckState = CheckState.Checked;
                cbHazard.Checked = true;
                cbService.Checked = true;
                cbJourney.Checked = true;
                cbPassenger.Checked = true;
            }
            else
            {
                cbInfrastructure.CheckState = CheckState.Unchecked;
                cbHazard.CheckState = CheckState.Unchecked;
                cbService.CheckState = CheckState.Unchecked;
                cbJourney.CheckState = CheckState.Unchecked;
                cbPassenger.CheckState = CheckState.Unchecked;
            }
        }

        private void btnProjectPath_Click(object sender, EventArgs e)
        {
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork";
            openFilePath.Filter = @"NET Files (*.bin)|*.bin";
            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_infrastructureNetwork = openFilePath.FileName;
                txtInfraPath.Text = openFilePath.InitialDirectory;
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Partition-HaoYe\Projects\Oasis\SampleNetwork";
            openFilePath.Filter = @"NET Files (*.bin)|*.bin";
            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_serviceprojectName = openFilePath.FileName;
            }  

        }

        private void btnProjectOk_Click(object sender, EventArgs e)
        {
            // Load background map
            if (cbAllData.Checked)
            {
                OasisForms.DockMain.gISMapToolStripMenuItem.CheckState = CheckState.Checked;
            }

            // Load infrastructure tube network
            if (m_infrastructureNetwork != null)
            {
                State.network = SerialisationHelper.DeserialiseNetwork(m_infrastructureNetwork);
                m_visualiser = new NetworkVisualier(State.network);
                m_visualiser.DoInfraNetworkVisualisation();
            }

            // Load hazard map
            if (m_hazardMapDatabase != null)
            {
                State.HazardCellCollection = SerialisationHelper.DeserialiseHazard(m_hazardMapDatabase);
                m_hazardVisualiser = new HazardVisualiser(State.HazardCellCollection, OasisForms.DockMap.mapBox1);
            }

            // Load service lines and map
            if (m_BankerlooStations != null && m_BankerlooLinkes != null)
            {

                var serviceConstructor1 = new ServiceBuilder("1", "Bakerloo", m_BankerlooStations, m_BankerlooLinkes, OasisForms.DockMap.mapBox1);
                serviceConstructor1.BuildServiceToNetwork();
                var serviceConstructor2 = new ServiceBuilder("2", "Central", m_CentralStations, m_CentralLinks, OasisForms.DockMap.mapBox1);
                serviceConstructor2.BuildServiceToNetwork();
            }

            if (cbJourney.Checked)
            {
                PassengerMode mode = new PassengerMode(m_timeSpentOnStationFile);
                mode.GetStationModeData();
                mode.AssignDataToStation();
                mode.AssignDataToNode();
                OasisForms.DockService.UpdateServiceList();
            }

            // parsing service data
            if (cbService.Checked)
            {
                // Load Service Data from the service data
                TfLDataParser.ParseStationData();
                TfLDataParser.ParseLineData();
                // Assigment of service data to the infrastructure node
                TfLDataParser.AssignServiceData();
                //OasisForms.DockOperation.UpdateStatusList();
            }

            OasisForms.DockMap.UpdateLayerView();
            OasisForms.DockMap.mapBox1.Refresh();
            OasisForms.DockHazard.UpdateHazardList();

            // This step is really time-comsumping
            //GraphHelper.BuildGraph(State.network);
            //OasisForms.DockCompoundGraph.GraphControl.UpdateComponent();
            //OasisForms.DockMain.gISMapToolStripMenuItem.CheckState = CheckState.Checked;
            // Not the following one
            //GraphHelper.BuildTransportGraph(State.network);

            Automation.LoadingUpdating();
            this.Close();
        }

        private void btnProjectCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHazardPath_Click(object sender, EventArgs e)
        {
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork";
            openFilePath.Filter = @"NET Files (*.bin)|*.bin";
            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_hazardMapDatabase = openFilePath.FileName;
                txtHazardPath.Text = openFilePath.InitialDirectory;
            }  
        }

        private void btnServiceLoader_Click(object sender, EventArgs e)
        {
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork";
            openFilePath.Filter = @"NET Files (*.shp)|*.shp";
            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_BankerlooStations = openFilePath.FileName;
                txtServiceNodePath.Text = openFilePath.InitialDirectory;
            }  
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork";
            openFilePath.Filter = @"NET Files (*.shp)|*.shp";
            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_BankerlooLinkes = openFilePath.FileName;
                txtServiceLinkPath.Text = openFilePath.InitialDirectory;
            }  

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Users\hye\Desktop\GAsty\GAsty-master\Data\PassengerData";
            openFilePath.Filter = @"NET Files (*.cvs)|*.csv";
            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_serviceTimeSpentFileName = openFilePath.FileName;
                textLineStatusPath.Text = openFilePath.InitialDirectory;
            }  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var openFilePath = new OpenFileDialog();
            openFilePath.InitialDirectory = @"C:\Users\hye\Desktop\GAsty\GAsty-master\Data\PassengerData";
            openFilePath.Filter = @"NET Files (*.cvs)|*.csv";
            if (openFilePath.ShowDialog() == DialogResult.OK)
            {
                m_servicePassengerFile = openFilePath.FileName;
                txtPassengerPath.Text = openFilePath.InitialDirectory;
            } 
        }


    }
}
