using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GAsty.Algorithm;
using GAsty.Geospatial;
using GAsty.Hazard.Core;
using GAsty.Hazard.Operation;
using GAsty.London_Tube_Operation.Operation;
using GAsty.Network.Core;
using GAsty.Network.Operation;
using GAsty.Utility;
using Microsoft.SolverFoundation.Services;

namespace GAsty.Forms.SubForms
{
    public partial class Form_ModelSetting : Form
    {
        public Form_ModelSetting()
        {
            InitializeComponent();
        }

        private void Form_ModelSetting_Load(object sender, EventArgs e)
        {
            FormSetting();
        }

        private void FormSetting()
        {
            if (State.network != null)
            {
                txtNodeNum.Text = State.network.GeoNodeCollection.Count.ToString();
                txtLinkNum.Text = State.network.GetInfraLinkCollection().Count.ToString();
                txtNetworkNum.Text = State.ServiceNetworkCollection.Count.ToString();
                txtHazard.Text = State.HazardCellCollection.Count.ToString();
                cbAij.SelectedIndex = 0;
                cbCi.SelectedIndex = 0;
                cbMax.SelectedIndex = 0;
                cbMin.SelectedIndex = 0;
            }
        }

        private void btnModelOK_Click(object sender, EventArgs e)
        {
            if (cbIOModelEnable.Enabled == true && cbIOServiceModel.Enabled == false)
            {
                CoreModel.BuildStaticModel();
                Automation.UpdateAfterModelling();
            }
            else if (cbIOModelEnable.Enabled == true && cbIOServiceModel.Enabled== true)
            {
                CoreModel.BuildStaticModel();
                ServiceModel.QuantifyService();
                ServiceModel.DoServiceComputation();
                Automation.UpdateAfterModelling();
                OasisForms.DockServiceChart.UpdateService();
                var visualiser = new NetworkVisualier(State.ServiceNetworkCollection);
                visualiser.ComputeServiceVisualisation();
                State.IsComputionCompleted = true;
                OasisForms.DockMap.UpdateRiskServiceLayers();
            }

            this.Close();
        }

        private void btnModelCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            if (State.network != null)
            {
                txtNodeNum.Text = State.network.GeoNodeCollection.Count.ToString();
                txtLinkNum.Text = State.network.GetInfraLinkCollection().Count.ToString();
                txtNetworkNum.Text = State.ServiceNetworkCollection.Count.ToString();
                txtHazard.Text = State.HazardCellCollection.Count.ToString();
                cbAij.SelectedIndex = 0;
                cbCi.SelectedIndex = 0;
                cbMax.SelectedIndex = 0;
                cbMin.SelectedIndex = 0;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LinkMatrix index = new LinkMatrix(@"C:\Users\hye\Desktop\LinkMatrix.csv");
            index.GetLinkModelData();
            index.AssignDataToLinkIndex();
            index.AssignDataToLINK();
            OasisForms.DockLink.UpdateLinkList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CoreModel.BuildStaticModel();
            Automation.UpdateAfterModelling();
        }

        private void btnHazard_Click(object sender, EventArgs e)
        {
            // Define the impact area for nodes and links
            var selectedNodeList = new List<GeoNode>();
            var selectedLinkList = new List<GeoLink>();
            var selectedHazardList = new List<GeoHazardCell>();
            // Implement intersect analysis for the nodes an links affected by the hazard cells
            selectedNodeList = BufferAnalysis.ExecuteIntersection(State.HazardCellCollection, State.network.GeoNodeCollection);
            selectedLinkList = BufferAnalysis.ExcuteIntersectionLink(State.HazardCellCollection, State.network.GeoLinkCollection);
            selectedHazardList = BufferAnalysis.ExcuteIntersectionHazard(State.HazardCellCollection, 0.8f);
            // the selected node and links
            State.impactedNode = selectedNodeList;
            State.impactedLink = selectedLinkList;
            State.impactedHazardCells = selectedHazardList;

            HazardRenderingHelper.RenderNodeLayer(selectedNodeList);
            HazardRenderingHelper.RenderLinkLayer(selectedLinkList);

            OasisForms.DockNode.UpdateNodeList();
            OasisForms.DockLink.UpdateLinkList();
            OasisForms.DockHazard.UpdateHazardList();
        }















    }
}
