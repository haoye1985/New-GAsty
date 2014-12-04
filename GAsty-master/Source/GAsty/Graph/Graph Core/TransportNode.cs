using System;
using System.Collections.Generic;
using System.Drawing;
using NodeGraphControl;
using NodeGraphControl.Xml;
using GAsty.Network.Core;

namespace Oasis
{
    public class TransportNode : NodeGraphNode
    {
        private int _ID;
        private float _Risk;
        private NodeEnum m_NodeType;
        private OPConnector connect1;
        private IOPConnector connect2;
        public List<OPConnector> m_OPConnectors;
        public List<IOPConnector> m_IOPConnectors;

        public TransportNode(int p_X, int p_Y, NodeGraphView p_View, bool p_CanBeSelected, NodeEnum pNodeType)
            : base(p_X, p_Y, p_View, p_CanBeSelected)
        {
            this.ID = 0;
            this.m_NodeType = pNodeType;
            this.m_sName = m_NodeType.ToString();
            this.m_OPConnectors = new List<OPConnector>();
            this.m_IOPConnectors = new List<IOPConnector>();
            this.connect1 = new OPConnector("OP", this, ConnectorType.OutputConnector, 0, "Operability");
            this.connect2 = new IOPConnector("IOP", this, ConnectorType.OutputConnector, 1, "Inoperability");
            this.connect2.Length = this.RiskIndexToLength(_Risk);
            this.connect1.Length = 60 - connect2.Length;
            this.m_OPConnectors.Add(connect1);
            this.m_IOPConnectors.Add(connect2);
            this.m_Connectors.Add(new NodeGraphConnector("Connector", this, ConnectorType.InputConnector, 0, "Boolean"));
            this.Height = 80;
        }

        public TransportNode(int p_X, int p_Y, NodeGraphView p_View, bool p_CanBeSelected, float Risk, NodeEnum pNodeType)
            : base(p_X, p_Y, p_View, p_CanBeSelected)
        {
            this.ID = 0;
            this.m_NodeType = pNodeType;
            this.m_sName = m_NodeType.ToString();
            this.m_OPConnectors = new List<OPConnector>();
            this.m_IOPConnectors = new List<IOPConnector>();
            OPConnector connect1 = new OPConnector("OP", this, ConnectorType.OutputConnector, 0, "Operability");
            IOPConnector connect2 = new IOPConnector("IOP", this, ConnectorType.OutputConnector, 1, "Inoperability");
            connect2.Length = this.RiskIndexToLength(Risk);
            connect1.Length = 60 - connect2.Length;
            this.m_OPConnectors.Add(connect1);
            this.m_IOPConnectors.Add(connect2);
            this.m_Connectors.Add(new NodeGraphConnector("Connect", this, ConnectorType.InputConnector, 0, "Boolean"));
            this.Height = 80;
        }

        public void UpdateNode()
        {
            connect2.Length = this.RiskIndexToLength(_Risk);
            connect1.Length = 60 - connect2.Length;
        }

        private int RiskIndexToLength(float index)
        {
            int Length;
            return Length = (int)(index * 60);
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            Point CtrlPos = m_oView.ParentPanel.ViewToControl(new Point(X, Y));
            int ScaledX = CtrlPos.X;
            int ScaledY = CtrlPos.Y;

            Rectangle ViewRectangle = new Rectangle(
                                                        CtrlPos.X,
                                                        CtrlPos.Y,
                                                        (int)(this.HitRectangle.Width * m_oView.CurrentViewZoom),
                                                        (int)(this.HitRectangle.Height * m_oView.CurrentViewZoom)
                                                    );
            // NODE SHADOW
            if (this.ParentView.ParentPanel.DrawShadow)
            {
                if (this.m_NodeType == NodeEnum.Node)
                {
                    e.Graphics.DrawImage(NodeGraphResources.NodeShadow, ParentView.ParentPanel.ViewToControl(new Rectangle(this.X - (int)(0.1f * this.Width) + 4,
                                                                                                                            this.Y - (int)(0.1f * this.Height) + 4,
                                                                                                                            this.Width + (int)(0.2f * this.Width) - 4,
                                                                                                                            this.Height + (int)(0.2f * this.Height) - 4)
                                                                                                             ));
                }
                else if (this.m_NodeType == NodeEnum.Link)
                {
                    e.Graphics.DrawImage(NodeGraphResources.NodeShadow, ParentView.ParentPanel.ViewToControl(new Rectangle(this.X - (int)(0.1f * this.Width) + 8,
                                                                                                        this.Y - (int)(0.1f * this.Height) + 8,
                                                                                                        this.Width + (int)(0.2f * this.Width) - 4,
                                                                                                        this.Height + (int)(0.2f * this.Height) - 4)
                                                                                         ));
                }
            }

            // NODE
            if (this.m_NodeType == NodeEnum.Node)
            {
                if (!this.Highlighted)
                {
                    e.Graphics.FillRectangle(m_oView.ParentPanel.NodeFill, ViewRectangle);
                    e.Graphics.FillRectangle(m_oView.ParentPanel.NodeHeaderFill, new Rectangle(ViewRectangle.X, ViewRectangle.Y, ViewRectangle.Width, (int)(m_oView.ParentPanel.NodeHeaderSize * m_oView.CurrentViewZoom)));
                    e.Graphics.DrawRectangle(m_oView.ParentPanel.NodeOutline, ViewRectangle);
                }
                else
                {
                    Pen outline = new System.Drawing.Pen(Color.Red, 2);
                    e.Graphics.FillRectangle(m_oView.ParentPanel.NodeFillSelected, ViewRectangle);
                    e.Graphics.FillRectangle(m_oView.ParentPanel.NodeHeaderFill, new Rectangle(ViewRectangle.X, ViewRectangle.Y, ViewRectangle.Width, (int)(m_oView.ParentPanel.NodeHeaderSize * m_oView.CurrentViewZoom)));
                    //e.Graphics.DrawRectangle(m_oView.ParentPanel.NodeOutlineSelected, ViewRectangle);
                    e.Graphics.DrawRectangle(outline, ViewRectangle);
                }
            }
            else if (this.m_NodeType == NodeEnum.Link)
            {
                if (!this.Highlighted)
                {
                    SolidBrush brushpanel = new SolidBrush(Color.LightYellow);
                    SolidBrush brushhead= new SolidBrush(Color.DeepSkyBlue);
                    e.Graphics.FillRectangle(brushpanel, ViewRectangle);
                    e.Graphics.FillRectangle(brushhead, new Rectangle(ViewRectangle.X, ViewRectangle.Y, ViewRectangle.Width, (int)(m_oView.ParentPanel.NodeHeaderSize * m_oView.CurrentViewZoom)));
                    e.Graphics.DrawRectangle(m_oView.ParentPanel.NodeOutline, ViewRectangle);
                }
                else
                {
                    Pen outline = new System.Drawing.Pen(Color.Red, 2);
                    e.Graphics.FillRectangle(m_oView.ParentPanel.NodeFillSelected, ViewRectangle);
                    e.Graphics.FillRectangle(m_oView.ParentPanel.NodeHeaderFill, new Rectangle(ViewRectangle.X, ViewRectangle.Y, ViewRectangle.Width, (int)(m_oView.ParentPanel.NodeHeaderSize * m_oView.CurrentViewZoom)));
                    //e.Graphics.DrawRectangle(m_oView.ParentPanel.NodeOutlineSelected, ViewRectangle);
                    e.Graphics.DrawRectangle(outline, ViewRectangle);
                }
 
            }

            // VALID/INVALID NODE

            Point v_CtrlSignalPosition = m_oView.ParentPanel.ViewToControl(new Point(X + Width - 20, Y + 4));
            Rectangle v_SignalRectangle = new Rectangle(v_CtrlSignalPosition.X, v_CtrlSignalPosition.Y, (int)(16 * m_oView.CurrentViewZoom), (int)(16 * m_oView.CurrentViewZoom));

            if (this.IsValid())
            {
                e.Graphics.DrawImage(NodeGraphResources.NodeValid, v_SignalRectangle);
            }
            else
            {
                e.Graphics.DrawImage(NodeGraphResources.NodeInvalid, v_SignalRectangle);
            }

            /// IF SUFFICENT ZOOM LEVEL = DRAW TEXT
            if (m_oView.CurrentViewZoom > m_oView.ParentPanel.NodeTitleZoomThreshold)
            {
                // DrawText
                e.Graphics.DrawString(this.Name, m_oView.ParentPanel.NodeScaledTitleFont, m_oView.ParentPanel.NodeTextShadow, new Point(ScaledX + (int)(2 * m_oView.CurrentViewZoom) + 1, ScaledY + (int)(2 * m_oView.CurrentViewZoom) + 1));
                e.Graphics.DrawString(this.Name, m_oView.ParentPanel.NodeScaledTitleFont, m_oView.ParentPanel.NodeText, new Point(ScaledX + (int)(2 * m_oView.CurrentViewZoom), ScaledY + (int)(2 * m_oView.CurrentViewZoom)));
            }

            //Transport Connectors

            for (int i_ConnectorIndex = 0; i_ConnectorIndex < this.m_OPConnectors.Count; i_ConnectorIndex++)
            {
                this.m_OPConnectors[i_ConnectorIndex].Draw(e, i_ConnectorIndex);
            }

            for (int i_ConnectorIndex = 0; i_ConnectorIndex < this.m_Connectors.Count; i_ConnectorIndex++)
            {
                this.m_Connectors[i_ConnectorIndex].Draw(e, i_ConnectorIndex);
            }

            for (int i_ConnectorIndex = 0; i_ConnectorIndex < this.m_IOPConnectors.Count; i_ConnectorIndex++)
            {
                this.m_IOPConnectors[i_ConnectorIndex].Draw(e, i_ConnectorIndex);
            }

            //Comment
            if (this.m_sComment != "")
            {
                e.Graphics.DrawString(this.m_sComment, m_oView.ParentPanel.NodeScaledTitleFont, m_oView.ParentPanel.NodeText, new Point(ScaledX, ScaledY - (int)(16 * m_oView.CurrentViewZoom)));
            }

            // Post-draw event
            //if (this.onPostDraw != null) onPostDraw(this, e);
        }

        #region Properties

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public float Risk
        {
            get { return _Risk; }
            set { _Risk = value; }
        }

        #endregion
    }
}
