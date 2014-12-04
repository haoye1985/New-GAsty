using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GAsty.Algorithm;
using GAsty.Forms.SubForms;
using GAsty.Graph;
using GAsty.Hazard.Core;
using GAsty.Helpers;
using GAsty.London_Tube_Operation;
using GAsty.London_Tube_Operation.Operation;
using GAsty.Network.Core;
using GAsty.Network.Operation;
using GAsty.Tube;
using GAsty.Tube.TubeCore;
using GAsty.Utility;
using SharpMap.Forms;
using GAsty.Geospatial;
using GAsty.Hazard.Operation;

namespace GAsty.Forms
{
    public partial class DockMain : Form
    {
        private NetworkVisualier m_visualiser;
        private ServiceEditor m_serviceEditor;

        public DockMain()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            OasisForms.FormManager.ShowDocumentDocks();
        }

        private void DockMainWin_Load(object sender, EventArgs e)
        {
            Automation.SettingMainWindow(this);
        }

        private void drawLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawNodeToolStripMenuItem.CheckState == CheckState.Checked || editServiceToolStripMenuItem.CheckState == CheckState.Checked)
            {
                drawNodeToolStripMenuItem.CheckState = CheckState.Unchecked;
            }

            drawLinkToolStripMenuItem.CheckState = CheckState.Checked;
            OasisForms.DockMap.Editor.MapEditorModes = EditMode.DrawLink;
        }

        private void drawNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawLinkToolStripMenuItem.CheckState == CheckState.Checked || editServiceToolStripMenuItem.CheckState == CheckState.Checked)
            {
                drawLinkToolStripMenuItem.CheckState = CheckState.Unchecked;
                editServiceToolStripMenuItem.CheckState = CheckState.Unchecked;
            }

            drawNodeToolStripMenuItem.CheckState = CheckState.Checked;
            OasisForms.DockMap.Editor.MapEditorModes = EditMode.DrawNode;
        }

        private void gISMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gISMapToolStripMenuItem.CheckState = CheckState.Checked;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void staticInputOutputModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoreModel.BuildStaticModel();     
            Automation.UpdateAfterModelling();
        }

        private void generateRandomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParamGenerator.GenerateRandam();
            Automation.UpdateBeforeModelling();
        }

        private void shapeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reader = new VectorLayerReader();
            reader.ReadVectorLayers("Station2012t.shp");
        }

        private void parameterGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void networkCheckerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fmNetwork = new FmNetworkCheck();
            fmNetwork.Show();
        }

        private void generateFixedParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParamGenerator.GenerateFixedSample((float) 0.1, (float) 0.2, (float) 0.5);
            Automation.UpdateBeforeModelling();
        }

        private void fromShapeFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fmPathLoader = new FmFilePath();
            fmPathLoader.Show();
        }

        private void findDegreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var degree = new NetworkDegree(State.network);
            degree.FindNodeDegree();
            OasisForms.DockNode.UpdateNodeList();
        }

        private void selectToolItem_Click(object sender, EventArgs e)
        {
            OasisForms.DockMap.mapBox1.ActiveTool = MapBox.Tools.QueryBox;
        }

        private void fromShapeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fmServiceLoader = new fmServiceLoader();
            fmServiceLoader.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Automation.LoadProject();
        }

        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SerialisationHelper.SerialiseNetwork(State.network);
        }

        private void sampleProjectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (State.network != null && State.HazardCellCollection != null && State.ServiceNetworkCollection != null)
            {
                SerialisationHelper.SerialiseNetwork(State.network);
                SerialisationHelper.SerialiseHazard(State.HazardCellCollection);
                SerialisationHelper.SerialiseNetworkService(State.ServiceNetworkCollection);
                MessageBox.Show(@"The data file is successfully perserved");
            }
            else
            {
                MessageBox.Show(@"The data file is not incompleted to be perserved");
            }

        }

        private void sampleProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"C:\Partition-HaoYe\Projects\Oasis\Binaries\network.bin";
            State.network = SerialisationHelper.DeserialiseNetwork(path);
            m_visualiser = new NetworkVisualier(State.network, GAsty.Forms.OasisForms.DockMap.mapBox1);
            m_visualiser.DoNetworkVisualisation();
            GAsty.Forms.OasisForms.DockMap.UpdateLayerView();
            GraphHelper.BuildGraph(State.network);
            Automation.LoadingUpdating();
        }

        private void projectToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fmProject = new Form_LoadProject();
            fmProject.Show();
        }

        private void runModelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tubeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Automation.LoadProject();
        }

        private void shapeFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var reader = new VectorLayerReader();
            reader.ReadVectorLayers("ProjectedHazard.shp");
        }

        private void postgreSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fromPostgreSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void buidServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void queryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OasisForms.DockMap.mapBox1.ActiveTool = MapBox.Tools.QueryGeometry;
        }

        private void editServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawNodeToolStripMenuItem.CheckState == CheckState.Checked || drawLinkToolStripMenuItem.CheckState == CheckState.Checked)
            {
                drawNodeToolStripMenuItem.CheckState = CheckState.Unchecked;
                drawLinkToolStripMenuItem.CheckState = CheckState.Unchecked;
            }

            editServiceToolStripMenuItem.CheckState = CheckState.Checked;
            OasisForms.DockMap.Editor.MapEditorModes = EditMode.None;
            m_serviceEditor = new ServiceEditor(OasisForms.DockMap.mapBox1);
        }

        private void infrastructureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void serviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void calculateServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceModel.DoServiceComputation();
            NetworkVisualier visualiser = new NetworkVisualier(State.ServiceNetworkCollection);
            visualiser.ComputeServiceVisualisation();
            OasisForms.DockMap.UpdateRiskServiceLayers();
        }

        private void connectToOasisR10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmConnector connectorForm = new fmConnector();
            connectorForm.Show();
        }

        private void outputResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmResultForm resultForm = new fmResultForm();
            resultForm.Show();
        }

        private void londonHazardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmHazardForm hazardForm = new fmHazardForm();
            hazardForm.Show();
        }

        private void doSpatialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<GeoNode> selectedNodeList = new List<GeoNode>();
            selectedNodeList = BufferAnalysis.ExecuteIntersection(State.HazardCellCollection, State.network.GeoNodeCollection);
            HazardRenderingHelper.RenderNodeLayer(selectedNodeList);     
        }

        private void importOperationDataXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void xMLTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load the geometries of transport network
            string openFilePath1 = @"D:\GAsty\GAsty\XMLData\ProjectedStations.shp";
            string openFilePath2 = @"D:\GAsty\GAsty\XMLData\ProjectedLinks.shp";

            var constructor = new NetworkBuilder(openFilePath1, openFilePath2, OasisForms.DockMap.mapBox1);
            constructor.BuildNetworkToState();

            // Dispaly road network on the layers
            OasisForms.DockMap.UpdateLayerView();
            OasisForms.DockMap.mapBox1.Map.ZoomToBox(State.ServiceLinkLayer.Envelope);
            OasisForms.DockNode.UpdateNodeList();
            OasisForms.DockLink.UpdateLinkList();

            // Load Service Data from the service data
            TfLDataParser.ParseStationData();
            TfLDataParser.ParseLineData();
     
            // Assigment of service data to the infrastructure node
            TfLDataParser.AssignServiceData();
            OasisForms.DockOperation.UpdateStatusList();

        }

        private void prepareModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modelPrepForm = new ModelPrepForm();
            modelPrepForm.Show();
        }

        private void hazardCalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Define the impact area for nodes and links
            var selectedNodeList = new List<GeoNode>();
            var selectedLinkList = new List<GeoLink>();
            var selectedHazardList = new List<GeoHazardCell>();
            
            // Implement intersect analysis for the nodes an links affected by the hazard cells
            selectedNodeList = BufferAnalysis.ExecuteIntersection(State.HazardCellCollection, State.network.GeoNodeCollection);
            selectedLinkList = BufferAnalysis.ExcuteIntersectionLink(State.HazardCellCollection,State.network.GeoLinkCollection);
            selectedHazardList = BufferAnalysis.ExcuteIntersectionHazard(State.HazardCellCollection, 0.8f);


            State.impactedNode = selectedNodeList;
            State.impactedLink = selectedLinkList;
            State.impactedHazardCells = selectedHazardList;

            HazardRenderingHelper.RenderNodeLayer(selectedNodeList);
            HazardRenderingHelper.RenderLinkLayer(selectedLinkList);

            OasisForms.DockNode.UpdateNodeList();
            OasisForms.DockLink.UpdateLinkList();
            OasisForms.DockHazard.UpdateHazardList();
        }

        private void importPassengerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PassengerHelper phelper = new PassengerHelper();
            phelper.DoDataImport();         
        }

        private void stationInfoLoaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bar = new ProgressBar();
            bar.Show();
            PassengerMode mode = new PassengerMode(@"C:\Users\hye\Desktop\GAsty\GAsty-master\Data\PassengerData\TimeSpent.csv");
            mode.GetStationModeData();
            mode.AssignDataToStation();
            bar.UpdateProgress(1);
            bar.UpdateLabel("Loading Passenger Data");

            PassengerODMatrix matrix = new PassengerODMatrix(@"C:\Users\hye\Desktop\GAsty\GAsty-master\Data\PassengerData\ODStations.csv");
            matrix.GetStationModeData();
            matrix.AssignDataToStation();
            bar.UpdateProgress(2);
            bar.UpdateLabel("Loading Passenger OD Matrix");

            OasisForms.DockService.UpdateServiceList();
            bar.UpdateProgress(3);
            bar.UpdateLabel("Loading Service Data");
            OasisForms.DockServiceChart.UpdateService();
            bar.UpdateProgress(5);
            bar.Close();
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var matrix = new IndependentMatrix(State.StationPassengerODMatrix);
            matrix.BuildMatrix();
        }

        private void modelPreparationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modelPrepForm = new ModelPrepForm();
            modelPrepForm.Show();
        }

        private void londonUndergroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fmProject = new Form_LoadProject();
            fmProject.Show();
        }

        private void projectToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var fmProject = new Form_LoadProject();
            fmProject.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generateSpatialParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParamGenerator.GenerateSpatialInterdependency();
            Automation.UpdateBeforeModelling();
        }

        private void randomParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParamGenerator.GenerateRandam();
            Automation.UpdateBeforeModelling();
        }

        private void fixedValueParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParamGenerator.GenerateFixedSample((float)0.1, (float)0.2, (float)0.5);
            Automation.UpdateBeforeModelling();
        }

        private void spatailParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParamGenerator.GenerateSpatialInterdependency();
            Automation.UpdateBeforeModelling();
        }

        private void importTimeSpentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PassengerMode mode = new PassengerMode(@"C:\Users\hye\Desktop\GAsty\GAsty-master\Data\PassengerData\TimeSpent.csv");
            mode.GetStationModeData();
            mode.AssignDataToStation();
            mode.AssignDataToNode();
            OasisForms.DockService.UpdateServiceList();
        }

        private void timeModelTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceModel.QuantifyService();
            OasisForms.DockNode.UpdateNodeList();
        }

        private void runModelFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ParamGenerator.GenerateRandam();
            Automation.UpdateBeforeModelling();
            var modelSettingForm = new Form_ModelSetting();
            modelSettingForm.Show();
        }

        private void staticInputOutputModelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CoreModel.BuildStaticModel();
            Automation.UpdateAfterModelling();
        }

        private void staticServiceModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceModel.DoServiceComputation();
            NetworkVisualier visualiser = new NetworkVisualier(State.ServiceNetworkCollection);
            visualiser.ComputeServiceVisualisation();
            OasisForms.DockMap.UpdateRiskServiceLayers();
        }

        private void serviceQuantificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceModel.QuantifyService();
            OasisForms.DockNode.UpdateNodeList();
        }


        


    }
}
    