using System;
using GAsty.Graph;
using GAsty.Network.Core;
using GAsty.Utility;
using Oasis;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Forms;
using System.Drawing;

namespace GAsty.Forms
{
    public partial class DockGraph : DockContent
    {
        #region Private Fields

        private GraphEditor m_editor;

        #endregion

        #region Constructor

        public DockGraph()
        {
            InitializeComponent();
        }

        #endregion

        # region Method

        private void DockGraph_Load(object sender, EventArgs e)
        {
            m_editor = new GraphEditor(OasisForms.DockGraph.nodeGraphPanel1);
        }

        public void UpdateGraph()
        {
            PopulateValue();

            foreach (TransportNode nodeOnView in this.m_editor.m_graphpanel.View.NodeCollection)
            {
                nodeOnView.UpdateNode();
            }

            this.nodeGraphPanel1.Refresh();
        }

        public void PopulateValue()
        {
            foreach (GeoNode node in State.network.GeoNodeCollection)
            {
                foreach (TransportNode nodeOnView in this.m_editor.m_graphpanel.View.NodeCollection)
                {
                    if (nodeOnView.Comment == node.ID.ToString())
                    {
                        nodeOnView.Risk = node.RiskXi;
                    }
                }
            }
        }

        #endregion

        #region Events

        private void nodeGraphPanel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
        }

        private void nodeGraphPanel1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void selectLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_editor.SelectionRectangle != null)
            {
                foreach (var nodeInNetwork in State.network.GeoNodeCollection)
                {
                    if (nodeInNetwork.NodeType == NodeEnum.Centroid)
                    {
                        foreach (var nodeInGraph in OasisForms.DockGraph.nodeGraphPanel1.View.NodeCollection)
                        {
                            Point graphPointLocation = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(new Point(nodeInNetwork.X, nodeInNetwork.Y));
                            if (this.m_editor.SelectionRectangle.Contains(graphPointLocation) && nodeInGraph.m_sComment == nodeInNetwork.ID.ToString())
                            {
                                nodeInGraph.Highlighted = true;
                            }

                        }
                    }

                }
            }
        }

        private void selectNodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_editor.SelectionRectangle != null)
            {
                foreach (var nodeInNetwork in State.network.GeoNodeCollection)
                {
                        if (nodeInNetwork.NodeType == NodeEnum.Edge)
                        {
                            foreach (var nodeInGraph in OasisForms.DockGraph.nodeGraphPanel1.View.NodeCollection)
                            {
                                Point graphPointLocation = OasisForms.DockGraph.nodeGraphPanel1.ControlToView(new Point(nodeInNetwork.X, nodeInNetwork.Y));
                                if (this.m_editor.SelectionRectangle.Contains(graphPointLocation) && nodeInGraph.m_sComment == nodeInNetwork.ID.ToString())
                                {
                                    nodeInGraph.Highlighted = true;
                                }

                            }
                        }
 
                }
            }


            //if (this.Editor.SelectionRectangle != null)
            //{
            //    foreach (var link in OasisForms.DockGraph.nodeGraphPanel1.View.Links)
            //    {
            //        var HitPointLinkFrom = new Point(link.Input.Parent.X, link.Output.Parent.Y);
            //        var HitPointLinkTo = new Point(link.Input.Parent.X, link.Output.Parent.Y);

            //        if (this.Editor.SelectionRectangle.Contains(HitPointLinkFrom) || this.Editor.SelectionRectangle.Contains(HitPointLinkTo))
            //        {

            //        }
            //    }

            //    OasisForms.DockGraph.nodeGraphPanel1.Update();
            //}

            //if (this.Editor.SelectionRectangle != null)
            //{
            //    foreach (var node in OasisForms.DockGraph.nodeGraphPanel1.View.NodeCollection)
            //    {
            //        var hothit = new Point(node.X, node.Y);


            //        if (this.Editor.SelectionRectangle.Contains(hothit))
            //        {
            //            node.Highlighted = true;
            //        }
            //    }

            //    OasisForms.DockGraph.nodeGraphPanel1.Update();
            //}


        }

        #endregion 
    }
}
